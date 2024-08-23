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
    public partial class frmAlteraProducao : Form
    {
        public OrdemProducaoDAL dal;
        OrdemProducao o;
        public frmAlteraProducao(OrdemProducao po, OrdemProducaoDAL pdal)
        {
            o = po;
            dal = pdal;
            InitializeComponent();
        }

        private void frmAlteraProducao_Load(object sender, EventArgs e)
        {
            cboStatus.DataSource = dal.getStatus();
            cboStatus.DisplayMember = "Text";
            cboStatus.ValueMember = "iValue";
            cboStatus.SelectedValue = o.StatusProducao;

            cboLocalProducao.DataSource = new LocalProducaoDAL().GetCombo();
            cboLocalProducao.DisplayMember = "Text";
            cboLocalProducao.ValueMember = "iValue";
            cboLocalProducao.SelectedIndex = -1;

            cboArmazem.DataSource = new ArmazemDAL().GetCombo();
            cboArmazem.DisplayMember = "Text";
            cboArmazem.ValueMember = "iValue";
            cboArmazem.SelectedIndex = -1;

            cboDeposito.DataSource = new DepositoDAL().GetCombo();
            cboDeposito.DisplayMember = "Text";
            cboDeposito.ValueMember = "iValue";
            cboDeposito.SelectedIndex = -1;

            cboLocalizacao.DataSource = new LocalizacaoDAL().GetCombo();
            cboLocalizacao.DisplayMember = "Text";
            cboLocalizacao.ValueMember = "iValue";
            cboLocalizacao.SelectedIndex = -1;

            if (o.IdLocalProducao != null)
            {
                cboLocalProducao.SelectedValue = o.IdLocalProducao;
            }

            var produtos = new OrdemProducaoProdutoDAL().getListByOP(o.IdOrdemProducao).ToList();
            dgvProduto.AutoGenerateColumns = false;
            dgvProduto.DataSource = produtos.Select(x => new {
                IdOrdemProducaoProduto = x.IdOrdemProducaoProduto,
                NomeProduto = x.Produto.NomeProduto,
                Cor = x.Cor == null ? "" : x.Cor.Descricao,
                Estilo = x.Estilo == null ? "" : x.Estilo.Descricao,
                Tamanho = x.Tamanho == null ? "" : x.Tamanho.Descricao,
                Config = x.Config == null ? "" : x.Config.Descricao,
                Qtde = x.Qtde }).ToList();

            txtData.Text = Convert.ToDateTime(o.DataProgramada).ToShortDateString();
            txtHora.Text = Convert.ToDateTime(o.DataProgramada).ToShortTimeString();
            txtOP.Text = "Op: " + o.NumeroOP.ToString() + "-" + dal.getPlanoNome(Convert.ToInt32(o.IdPlanoProducao)) + " - "; 
            if(o.StatusProducao == 5 || o.StatusProducao == 6)
            {
                button1.Visible = false;
            }
        }

        private void CadastraHistorico(string Texto)
        {
            OrdemProducaoHistoricoDAL hdal = new OrdemProducaoHistoricoDAL();
            OrdemProducaoHistorico oh = new OrdemProducaoHistorico();
            oh.IdOrdemProducao = o.IdOrdemProducao;
            oh.Descricao = Texto;
            oh.Data = DateTime.Now;
            oh.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
            hdal.Insert(oh);
            hdal.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Status = Convert.ToInt32(cboStatus.SelectedValue);
            if(Status == 1)
            {
                o.StatusProducao = Status;
                o.DataFinal = null;
                o.DataInicial = null;
                o.DataProgramada = DateTime.Now;
                CadastraHistorico("Enviada para Aguardando Liberação");
            }
            if (Status == 2)
            {
                try
                {
                    if (string.IsNullOrEmpty(cboLocalProducao.Text))
                    {
                        Util.Aplicacao.ShowMessage("Informe o local de produção");
                    }
                    o.StatusProducao = Status;
                    o.DataFinal = null;
                    o.DataInicial = Convert.ToDateTime(txtData.Text + " " + txtHora.Text);
                    o.DataProgramada = Convert.ToDateTime(txtData.Text + " " + txtHora.Text);
                    o.IdLocalProducao = Convert.ToInt32(cboLocalProducao.SelectedValue);
                    CadastraHistorico("OP Liberada para produção");
                }
                catch 
                {
                    Util.Aplicacao.ShowMessage("Verifique a data e hora de liberação");
                }
                
            }
            if(Status == 3)
            {
                o.StatusProducao = Status;
                CadastraHistorico("OP enviada para Controle de Qualidade");  
            }

            if (Status == 4)
            {
                o.StatusProducao = Status;
                CadastraHistorico("OP enviada para Embalagem");
            }

            if (Status == 5)
            {
                try
                {
                    o.StatusProducao = Status;
                    o.DataFinal = Convert.ToDateTime(txtData.Text + " " + txtHora.Text);
                    CadastraHistorico("OP Finalizada");
                    //Gera Estoque e baixa materiais
                    BLL.BLInventario idal = new BLL.BLInventario();
                    int IdArmazem = 0;
                    if (!string.IsNullOrEmpty(cboArmazem.Text)) IdArmazem = Convert.ToInt32(cboArmazem.SelectedValue);
                    int IdDeposito = 0;
                    if (!string.IsNullOrEmpty(cboDeposito.Text)) IdDeposito = Convert.ToInt32(cboDeposito.SelectedValue);
                    int IdLocalizacao = 0;
                    if (!string.IsNullOrEmpty(cboLocalizacao.Text)) IdLocalizacao = Convert.ToInt32(cboLocalizacao.SelectedValue);
                    idal.EntraOrdemProducao(o, IdArmazem, IdLocalizacao, IdDeposito);
                    Util.Aplicacao.ShowMessage("Ordem de Produção finalizada com sucesso!");
                }
                catch 
                {
                    Util.Aplicacao.ShowMessage("Verifique a data e hora de liberação");
                } 
            }

            if (Status == 6)
            {
                o.StatusProducao = Status;
                CadastraHistorico("OP Cancelada");
            }
            dal.Update(o);
            dal.Save();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmOrdemProducaoCad cad = new frmOrdemProducaoCad(o);
            cad.dal = dal;
            cad.ShowDialog();

            o = dal.GetByID(o.IdOrdemProducao);
            var produtos = new OrdemProducaoProdutoDAL().getListByOP(o.IdOrdemProducao).ToList();
            dgvProduto.AutoGenerateColumns = false;
            dgvProduto.DataSource = produtos.Select(x => new {
                IdOrdemProducaoProduto = x.IdOrdemProducaoProduto,
                NomeProduto = x.Produto.NomeProduto,
                Cor = x.Cor == null ? "" : x.Cor.Descricao,
                Estilo = x.Estilo == null ? "" : x.Estilo.Descricao,
                Tamanho = x.Tamanho == null ? "" : x.Tamanho.Descricao,
                Config = x.Config == null ? "" : x.Config.Descricao,
                Qtde = x.Qtde
            }).ToList();
        }
    }
}
