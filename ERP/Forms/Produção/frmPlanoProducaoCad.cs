using ERP.CrystalReports;
using ERP.DAL;
using ERP.Forms.Produção;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPlanoProducaoCad : RibbonForm
    {
        public PlanoProducaoDAL dal = new PlanoProducaoDAL();
        PlanoProducaoEtapaDAL eDal = new PlanoProducaoEtapaDAL();
        PlanoProducaoControleQualidadeDAL qDal = new PlanoProducaoControleQualidadeDAL();
        PlanoProducaoMateriaPrimaDAL mDal = new PlanoProducaoMateriaPrimaDAL();
        PlanoProducaoProdutoDAL pDal = new PlanoProducaoProdutoDAL();

        PlanoProducao p = new PlanoProducao();

        public frmPlanoProducaoCad(PlanoProducao pC)
        {
            p = pC;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmAutoridadeCad_Load(object sender, EventArgs e)
        {
            txtDtCadastro.Text = DateTime.Now.ToShortDateString();
            CarregaCombos();
            if (p.IdPlanoProducao == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void frmAutoridadeCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaCombos()
        {  
             
            cboCor.DataSource = new VariantesCorDAL().Get();
            cboCor.ValueMember = "IdVariantesCor";
            cboCor.DisplayMember = "Descricao";
            cboCor.SelectedIndex = -1;
            
        }

        private void CarregaDados()
        {
            txtNome.Text = p.Nome;
            txtDtCadastro.Text = p.DataCadastro.ToString();
            txtRevisao.Text = p.Revisao.ToString(); 
            cboCor.SelectedValue = p.IdVariantesCor == null ? 0 : p.IdVariantesCor; 
            txtContainer.Text = p.VolumeContainer.ToString();
            CarregaGrid();
            
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }



        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            p = new PlanoProducao();
            CarregaGrid();
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    p.Nome = txtNome.Text;
                    p.Revisao = Convert.ToDateTime(txtRevisao.Text);
                    p.VolumeContainer = Convert.ToDecimal(txtContainer.Text);
                    p.IdVariantesCor = Convert.ToInt32(cboCor.SelectedValue);
                    if (p.IdPlanoProducao == 0)
                    {
                        p.DataCadastro = DateTime.Now;
                        dal.Insert(p);
                    }
                    else
                    {
                        dal.Update(p);
                    }

                    dal.Save();
                    mDal.CalcularMateriais(p.IdPlanoProducao);
                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
            }
            else
            {
                Util.Aplicacao.ShowMessage("Por favor verifique as informações faltantes.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Qualquer alteração efetuada será perdida, deseja continuar?") == System.Windows.Forms.DialogResult.Yes)
            {
                CarregaDados();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == System.Windows.Forms.DialogResult.Yes)
            {
                var etapas = eDal.getByPlano(p.IdPlanoProducao);
                foreach(var et in etapas)
                {
                    mDal.apagaMateriais(et.IdPlanoProducaoEtapa);
                    eDal.Delete(et.IdPlanoProducaoEtapa);
                    eDal.Save();
                }

                var qualidade = qDal.getByPlano(p.IdPlanoProducao);
                foreach(var q in qualidade)
                {
                    qDal.Delete(q.IdPlanoProducaoControleQualidade);
                    qDal.Save();
                }

                var produtos = new PlanoProducaoProdutoDAL().getByPlanoId(p.IdPlanoProducao);
                foreach(var pr in produtos)
                {
                    pDal.Delete(pr.IdPlanoProducaoProduto);
                    pDal.Save();
                }


                int id = p.IdPlanoProducao;
                dal.Delete(id);
                dal.Save();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (p.IdPlanoProducao == 0)
            {
                Util.Aplicacao.ShowMessage("Salve os dados  antes de adicionar informações.");
                return;
            }

             
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            try
            {
                var etapas = eDal.getByPlano(p.IdPlanoProducao);
                dgvEtapa.AutoGenerateColumns = false;
                dgvEtapa.DataSource = etapas;

                var qualidade = qDal.getByPlano(p.IdPlanoProducao);
                dgvQualidade.AutoGenerateColumns = false;
                dgvQualidade.DataSource = qualidade;

                var produtos = new PlanoProducaoProdutoDAL().getByPlanoId(p.IdPlanoProducao);
                dgvProduto.AutoGenerateColumns = false;
                var prod = produtos.Select(x => new
                {
                    IdPlanoProducaoProduto = x.IdPlanoProducaoProduto,
                    NomeProduto = x.Produto.NomeProduto,
                    Cor = x.Cor == null ? "" : x.Cor.Descricao,
                    Estilo = x.Estilo == null ? "" : x.Estilo.Descricao,
                    Tamanho = x.Tamanho == null ? "" : x.Tamanho.Descricao,
                    Config = x.Config == null ? "" : x.Config.Descricao,
                    QdeProducao = x.QdeProducao
                }).ToList();



                dgvProduto.Rows.Clear();// = prod;
                foreach(var ip in prod)
                {
                    string[] row = new string[]
                    {
                        ip.IdPlanoProducaoProduto.ToString(),
                        ip.NomeProduto,
                        ip.Cor,
                        ip.Estilo,
                        ip.Tamanho,
                        ip.Config,
                        ip.QdeProducao.ToString()
                    };
                    dgvProduto.Rows.Add(row);
                }

                //for (int row = 0; row <= dgvEtapa.Rows.Count - 1; row++)
                //{
                //    ((DataGridViewImageCell)dgvEtapa.Rows[row].Cells[3]).Value = Properties.Resources.no_icon;
                //}
            }
            catch(Exception ex)
            {

                 
            }
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //using (frmBuscaProduto frmBusca = new frmBuscaProduto())
            //{
            //    frmBusca.ShowDialog();
            //    if (frmBusca.ProdutoSelecionado != null)
            //    {
            //        Produto pr = new ProdutoDAL().ProdutoRepository.GetByID(frmBusca.ProdutoSelecionado.IdProduto);
            //        if (pr != null)
            //        {
            //            p.IdProduto = pr.IdProduto;
            //            cboProduto.SelectedValue = pr.IdProduto;  

            //            cboConfig.SelectedValue = frmBusca.ProdutoSelecionado.IdVariantesConfig == null ? 0 : frmBusca.ProdutoSelecionado.IdVariantesConfig;
            //            p.IdVariantesConfig = frmBusca.ProdutoSelecionado.IdVariantesConfig;
            //            cboStilo.SelectedValue = frmBusca.ProdutoSelecionado.IdVariantesEstilo == null ? 0 : frmBusca.ProdutoSelecionado.IdVariantesEstilo;
            //            p.IdVariantesEstilo = frmBusca.ProdutoSelecionado.IdVariantesEstilo;
            //            cboCor.SelectedValue = frmBusca.ProdutoSelecionado.IdVariantesCor == null ? 0 : frmBusca.ProdutoSelecionado.IdVariantesCor;
            //            p.IdVariantesCor = frmBusca.ProdutoSelecionado.IdVariantesCor;
            //            cboTamanho.SelectedValue = frmBusca.ProdutoSelecionado.IdVariantesTamanho == null ? 0 : frmBusca.ProdutoSelecionado.IdVariantesTamanho;
            //            p.IdVariantesTamanho = frmBusca.ProdutoSelecionado.IdVariantesTamanho;
            //            cboUnidade.SelectedValue = frmBusca.ProdutoSelecionado.IdUnidade == null ? 0 : frmBusca.ProdutoSelecionado.IdUnidade;
            //            p.IdUnidade = frmBusca.ProdutoSelecionado.IdUnidade == null ? 0 : frmBusca.ProdutoSelecionado.IdUnidade;
            //        }
            //    }
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(p.IdPlanoProducao == 0)
            {
                Util.Aplicacao.ShowMessage("Salve as informações antes de adicionar etapas");
                return;
            }
            PlanoProducaoEtapa pe = new PlanoProducaoEtapa();
            pe.IdPlanoProducao = p.IdPlanoProducao;
            frmPlanoProducaoEtapa frme = new frmPlanoProducaoEtapa(pe, dal, eDal);
            frme.plano = p;
            frme.ShowDialog();
            CarregaGrid();
        }

        private void dgvEtapa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvEtapa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvEtapa.Rows[e.RowIndex].Cells[0].Value);
                PlanoProducaoEtapa pe = eDal.GetByID(id); 
                frmPlanoProducaoEtapa frme = new frmPlanoProducaoEtapa(pe, dal, eDal);
                frme.plano = p;
                frme.ShowDialog();
                CarregaGrid();
            }
            catch 
            {
 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PlanoProducaoControleQualidade q = new PlanoProducaoControleQualidade();
            q.IdPlanoProducao = p.IdPlanoProducao;
            frmPlanoProducaoControleQualidade frmq = new frmPlanoProducaoControleQualidade(qDal, p, q);
            frmq.ShowDialog();
            CarregaGrid();
        }

        private void dgvQualidade_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvQualidade.Rows[e.RowIndex].Cells[0].Value);
                PlanoProducaoControleQualidade q = qDal.GetByID(id);
                frmPlanoProducaoControleQualidade frmq = new frmPlanoProducaoControleQualidade(qDal, p, q);
                frmq.ShowDialog();
                CarregaGrid();
            }
            catch (Exception ex)
            {
                 
            }
        }

        private void rbPrint_Click(object sender, EventArgs e)
        {
            frmCrystalReportViewer frm = new frmCrystalReportViewer("PlanoProducao");
            List<FiltroRelatorio> FiltrosRelatorio = new List<FiltroRelatorio>();
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "Id", Valor = p.IdPlanoProducao.ToString() });
            frm.FiltrosRelatorio = FiltrosRelatorio; 
            frm.ShowDialog();
        }

        private void rbImport_Click(object sender, EventArgs e)
        {
            if(p.IdPlanoProducao == 0)
            {
                Util.Aplicacao.ShowMessage("Salve os dados antes de efetuar a importação de dados.");
                return;
            }
            frmImportarPlano frmi = new frmImportarPlano(p.IdPlanoProducao);
            frmi.ShowDialog();
            CarregaGrid();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            frmBuscaProduto frmb = new frmBuscaProduto();
            frmb.IdCorProducao = Convert.ToInt32(p.IdVariantesCor);
            frmb.ShowDialog();
            var ps = frmb.ProdutoSelecionado;

            if(ps != null)
            {
                var produto = new ProdutoDAL().ProdutoRepository.GetByID(ps.IdProduto);
                PlanoProducaoProduto pp = new PlanoProducaoProduto();
                pp.IdPlanoProducao = p.IdPlanoProducao;
                pp.IdProduto = ps.IdProduto;
                pp.IdVariantesConfig = ps.IdVariantesConfig;
                pp.IdVariantesCor = ps.IdVariantesCor;
                pp.IdVariantesEstilo = ps.IdVariantesEstilo;
                pp.IdVariantesTamanho = ps.IdVariantesTamanho;
                pp.QdeProducao = produto.QtdeProducao;
                pDal.Insert(pp);
                pDal.Save();
                CarregaGrid();
            }

             
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(dgvProduto.Rows[dgvProduto.SelectedRows[0].Index].Cells[0].Value);
                if(Util.Aplicacao.ShowQuestionMessage("Deseja remover o produto da listagem?") == DialogResult.Yes)
                {
                    pDal.Delete(Id);
                    pDal.Save();
                    CarregaGrid();
                }
            }
            catch 
            {
                 
            }
        }

        private void cboCor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dgvProduto.EndEdit();
            if(Util.Aplicacao.ShowQuestionMessage("Deseja atualizar o fator de produção para os produtos listados?") == DialogResult.Yes)
            {
                foreach(DataGridViewRow dr in dgvProduto.Rows)
                {
                    PlanoProducaoProduto p = pDal.GetByID(Convert.ToInt32(dr.Cells[0].Value));
                    p.QdeProducao = Convert.ToDecimal(dr.Cells[6].Value);
                    pDal.Update(p);
                    pDal.Save();
                }
            }
            CarregaGrid();
        }
    }
}

