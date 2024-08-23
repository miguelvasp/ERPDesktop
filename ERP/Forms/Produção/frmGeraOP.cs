using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.DAL;
using ERP.Models;

namespace ERP.Forms.Produção
{
    public partial class frmGeraOP : Form
    {
        public OrdemProducaoDAL dal = new OrdemProducaoDAL();
        OrdemProducaoEtapaDAL eDal = new OrdemProducaoEtapaDAL();
        OrdemProducaoMateriaPrimaDAL mDal = new OrdemProducaoMateriaPrimaDAL();
        OrdemProducaoControleQualidadeDAL qDal = new OrdemProducaoControleQualidadeDAL();
        OrdemProducaoProdutoDAL pDal = new OrdemProducaoProdutoDAL();
        OrdemProducaoHistoricoDAL hDal = new OrdemProducaoHistoricoDAL();
        bool carregou = false;
        public frmGeraOP()
        { 
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvProduto.EndEdit();
            if(string.IsNullOrEmpty(cboPlanoProducao.Text))
            {
                Util.Aplicacao.ShowMessage("Informe o plano de produção");
                return;
            }
            bool informouQtde = false;
            foreach(DataGridViewRow dr in dgvProduto.Rows)
            {
                if(!string.IsNullOrEmpty(dr.Cells[10].Value.ToString()))
                {
                    informouQtde = true;
                }
            }

            if(!informouQtde)
            {
                Util.Aplicacao.ShowMessage("Informe a quantidade a ser produzida");
                return;
            }

            try
            {
                Convert.ToDateTime(txtPrevisao.Text);
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowMessage("Informe uma data valida");
                return;
            }



            if(Util.Aplicacao.ShowQuestionMessage("Confirma a geração da Ordem de Produção?") == DialogResult.Yes)
            {
                PlanoProducao p = new PlanoProducaoDAL().GetByID(Convert.ToInt32(cboPlanoProducao.SelectedValue));
                OrdemProducao o = new OrdemProducao(); 
                o.IdPlanoProducao = Convert.ToInt32(cboPlanoProducao.SelectedValue);
                o.TipoProducao = Convert.ToInt32(cboTipoProducao.SelectedValue);
                o.StatusProducao = 1;
                o.IdPlanoProducao = p.IdPlanoProducao;
                o.IdVariantesCor = p.IdVariantesCor;
                o.NumeroOP = dal.getNumeroOP();
                o.IdLote = new LoteDAL().geraLote();
                o.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                o.DataProgramada = Convert.ToDateTime(txtPrevisao.Text + " 08:00");
                dal.Insert(o);
                dal.Save();

                //importar produtos
                decimal SomaQtde = 0;
                foreach (DataGridViewRow dr in dgvProduto.Rows)
                {
                    Produto pr = new ProdutoDAL().GetByID(Convert.ToInt32(dr.Cells[0].Value));
                    OrdemProducaoProduto opp = new OrdemProducaoProduto();
                    opp.IdProduto = pr.IdProduto;
                    opp.Qtde = 0;
                    opp.QtdeProducao = Convert.ToDecimal(dr.Cells[10].Value);
                    opp.IdOrdemProducao = o.IdOrdemProducao;
                    if (!string.IsNullOrEmpty(dr.Cells[11].Value.ToString()))
                    {
                        opp.Qtde = Convert.ToDecimal(dr.Cells[11].Value);
                    }
                    if (Util.Validacao.IsNumber(dr.Cells["IdConfig"].Value.ToString()))
                    {
                        opp.IdVariantesConfig = Convert.ToInt32(dr.Cells["IdConfig"].Value);
                    }

                    if (Util.Validacao.IsNumber(dr.Cells["IdCor"].Value.ToString()))
                    {
                        opp.IdVariantesCor = Convert.ToInt32(dr.Cells["IdCor"].Value);
                    }

                    if (Util.Validacao.IsNumber(dr.Cells["IdEstilo"].Value.ToString()))
                    {
                        opp.IdVariantesEstilo = Convert.ToInt32(dr.Cells["IdEstilo"].Value);
                    }

                    if (Util.Validacao.IsNumber(dr.Cells["IdTamanho"].Value.ToString()))
                    {
                        opp.IdVariantesTamanho = Convert.ToInt32(dr.Cells["IdTamanho"].Value);
                    }

                    pDal.Insert(opp);
                    pDal.Save();
                    SomaQtde += (Convert.ToDecimal(opp.Qtde) * Convert.ToDecimal(opp.QtdeProducao));
                }

                o.Quantidade = SomaQtde;
                dal.Update(o);
                dal.Save();

                //Importa Etapas e Materiais
                var Etapas = new PlanoProducaoEtapaDAL().getByPlano(p.IdPlanoProducao);
                foreach(var et in Etapas)
                {
                    OrdemProducaoEtapa oe = new OrdemProducaoEtapa();
                    oe.IdOrdemProducao = o.IdOrdemProducao;
                    oe.Nome = et.Nome;
                    oe.Tempo = et.Tempo;
                    oe.Ordem = et.Ordem;
                    eDal.Insert(oe);
                    eDal.Save();

                    //importa os materiais
                    var mp = new PlanoProducaoMateriaPrimaDAL().getByEtapa(et.IdPlanoProducaoEtapa);
                    foreach(var m in mp)
                    {
                        OrdemProducaoMateriaPrima om = new OrdemProducaoMateriaPrima();
                        om.IdOrdemProducao = o.IdOrdemProducao;
                        om.IdOrdemProducaoEtapa = oe.IdOrdemProducaoEtapa;
                        om.IdProduto = m.IdProduto;
                        om.Quantidade = m.Quantidade;
                        om.Densidade = m.Densidade;
                        om.Peso = m.Peso;
                        om.Volume = m.Volume;
                        om.PesoTotal = m.PesoTotal;
                        om.VolumeTotal = m.VolumeTotal;
                        om.LitrosTotal = ((m.PesoTotal / m.Densidade) * SomaQtde / 1000);
                        om.KilosTotal = m.PesoTotal * SomaQtde / 1000;
                        mDal.Insert(om);
                        mDal.Save();
                    }
                }

                //importa o controle de qualidade
                var cq = new PlanoProducaoControleQualidadeDAL().getByPlano(p.IdPlanoProducao);
                foreach(var q in cq)
                {
                    OrdemProducaoControleQualidade oq = new OrdemProducaoControleQualidade();
                    oq.IdOrdemProducao = o.IdOrdemProducao;
                    oq.Aspecto = q.Aspecto;
                    oq.Descricao = q.Descricao;
                    oq.ToleranciaAmais = q.ToleranciaAmais;
                    oq.ToleranciaAMenos = q.ToleranciaAMenos;
                    oq.Valor = q.Valor;
                    qDal.Insert(oq);
                    qDal.Save();
                }

                OrdemProducaoHistorico oh = new OrdemProducaoHistorico();
                oh.IdOrdemProducao = o.IdOrdemProducao;
                oh.Descricao = "Ordem de Produção cadastrada";
                oh.Data = DateTime.Now;
                oh.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                hDal.Insert(oh);
                hDal.Save();
                dal = null;
                Util.Aplicacao.ShowMessage("Ordem de Produção gerada com sucesso!");
                //frmOrdemProducaoCad cad = new frmOrdemProducaoCad(o);
                ////cad.dal = dal;
                //cad.ShowDialog();
                this.Close();
            }
        }

        private void frmGeraOP_Load(object sender, EventArgs e)
        {
            PlanoProducaoDAL dal = new PlanoProducaoDAL();
            cboPlanoProducao.DataSource = dal.getCombo();
            cboPlanoProducao.ValueMember = "iValue";
            cboPlanoProducao.DisplayMember = "Text";
            cboPlanoProducao.SelectedIndex = -1;

            List<ComboItem> tipos = new List<ComboItem>();
            tipos.Add(new ComboItem() { iValue = 1, Text = "Normal" });
            tipos.Add(new ComboItem() { iValue = 2, Text = "Urgente" });
            cboTipoProducao.DataSource = tipos;
            cboTipoProducao.DisplayMember = "Text";
            cboTipoProducao.ValueMember = "iValue";

            txtPrevisao.Text = DateTime.Now.ToShortDateString();

            carregou = true;
        }

        private void cboPlanoProducao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!carregou)
            {
                return;
            }
            try
            {
                if(!string.IsNullOrEmpty(cboPlanoProducao.Text))
                {
                    int id = Convert.ToInt32(cboPlanoProducao.SelectedValue);
                    var produtos = new PlanoProducaoProdutoDAL().getByPlanoId(id);

                    dgvProduto.Rows.Clear();
                    var lista = produtos.Select(x => new {
                        IdProduto = x.Produto.IdProduto,
                        IdCor = x.IdVariantesCor,
                        IdEstilo = x.IdVariantesEstilo,
                        idTamanho = x.IdVariantesTamanho,
                        idConfig = x.IdVariantesConfig,
                        NomeProduto = x.Produto.NomeProduto,
                        Cor = x.Cor == null ? "" : x.Cor.Descricao,
                        Estilo = x.Estilo == null ? "" : x.Estilo.Descricao,
                        Tamanho = x.Tamanho == null ? "" : x.Tamanho.Descricao,
                        Config = x.Config == null ? "" : x.Config.Descricao,
                        QtdeProducao = x.QdeProducao }).Distinct().ToList();

                    foreach (var p in lista)
                    {
                        if(p.QtdeProducao == null || p.QtdeProducao == 0)
                        {
                            Util.Aplicacao.ShowMessage("Este plano possui produtos com o fator de produção em branco ou com valor zero, corrija o cadastro do plano de produção e tente novamente.");
                            return;
                        }
                    }

                    foreach (var p in lista)
                    {
                        if (p.QtdeProducao != null && p.QtdeProducao > 0)
                        {
                            string[] row = new string[] { p.IdProduto.ToString(), p.IdCor.ToString(), p.IdEstilo.ToString(), p.idTamanho.ToString(), p.idConfig.ToString(), p.NomeProduto, p.Cor, p.Estilo, p.Tamanho, p.Config, p.QtdeProducao.ToString(), "" };
                            dgvProduto.Rows.Add(row);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                 
            }
            
        }
    }
}
