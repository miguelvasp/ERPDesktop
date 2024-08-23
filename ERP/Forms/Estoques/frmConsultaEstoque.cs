using ERP.DAL;
using ERP.Models;
using ERP.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.CrystalReports;
using ERP.Relatorios;
using ERP.Estoques;
using ERP.Forms.Estoques;

namespace ERP 
{
    public partial class frmConsultaEstoque : Form
    {
        //BLInventario blInv = new BLInventario();
        List<vwEstoqueSintetico> Lista = new List<vwEstoqueSintetico>();
        public frmConsultaEstoque()
        {
            InitializeComponent();
        }

        private void frmConsultaEstoque_Load(object sender, EventArgs e)
        {
            CarregaCombos();
            SQLDataLayer odal = new SQLDataLayer();
            odal.corrigeDepositoEstoque();
            odal.corrigeUnidadeEstoque();
        }

        private void CarregaCombos()
        {
            cboConfiguracao.DataSource = new VariantesConfigDAL().Get();
            cboConfiguracao.ValueMember = "IdVariantesConfig";
            cboConfiguracao.DisplayMember = "Descricao";
            cboConfiguracao.SelectedIndex = -1;

            cboTamanho.DataSource = new VariantesTamanhoDAL().Get();
            cboTamanho.ValueMember = "IdVariantesTamanho";
            cboTamanho.DisplayMember = "Descricao";
            cboTamanho.SelectedIndex = -1;

            cboCor.DataSource = new VariantesCorDAL().Get();
            cboCor.ValueMember = "IdVariantesCor";
            cboCor.DisplayMember = "Descricao";
            cboCor.SelectedIndex = -1;

            cboEstilo.DataSource = new VariantesEstiloDAL().Get();
            cboEstilo.ValueMember = "IdVariantesEstilo";
            cboEstilo.DisplayMember = "Descricao";
            cboEstilo.SelectedIndex = -1;

            cboProduto.DataSource = new ProdutoDAL().GetComboVendas();
            cboProduto.ValueMember = "iValue";
            cboProduto.DisplayMember = "Text";
            cboProduto.SelectedIndex = -1;

            cboDeposito.DataSource = new DepositoDAL().GetCombo();
            cboDeposito.ValueMember = "iValue";
            cboDeposito.DisplayMember = "Text";
            cboDeposito.SelectedIndex = -1;

            cboArmazem.DataSource = new ArmazemDAL().GetCombo();
            cboArmazem.ValueMember = "iValue";
            cboArmazem.DisplayMember = "Text";
            cboArmazem.SelectedIndex = -1;

            cboLocalizacao.DataSource = new LocalizacaoDAL().GetCombo();
            cboLocalizacao.ValueMember = "iValue";
            cboLocalizacao.DisplayMember = "Text";
            cboLocalizacao.SelectedIndex = -1;

            List<ComboItem> tpEstoque = new List<ComboItem>();
            tpEstoque.Add(new ComboItem() { iValue = 3, Text = "Estoque Físico" });
            tpEstoque.Add(new ComboItem() { iValue = 1, Text = "Compras" });


            //cboTipoEstoque.DataSource = tpEstoque;
            //cboTipoEstoque.ValueMember = "iValue";
            //cboTipoEstoque.DisplayMember = "Text"; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int? IdProduto = 0;
            int? IdDeposito = 0;
            int? IdArmazem = 0;
            int? IdLocalizacao = 0;
            int? IdVariantesConfig = 0;
            int? IdVariantesTamanho = 0;
            int? IdVariantesCor = 0;
            int? IdVariantesEstilo = 0;
            int? IdTipoDocumento = 0;

            if (!String.IsNullOrEmpty(cboProduto.Text)) IdProduto = Convert.ToInt32(cboProduto.SelectedValue);
            if (!String.IsNullOrEmpty(cboDeposito.Text)) IdDeposito = Convert.ToInt32(cboDeposito.SelectedValue);
            if (!String.IsNullOrEmpty(cboArmazem.Text)) IdArmazem = Convert.ToInt32(cboArmazem.SelectedValue);
            if (!String.IsNullOrEmpty(cboLocalizacao.Text)) IdLocalizacao = Convert.ToInt32(cboLocalizacao.SelectedValue);
            if (!String.IsNullOrEmpty(cboConfiguracao.Text)) IdVariantesConfig = Convert.ToInt32(cboConfiguracao.SelectedValue);
            if (!String.IsNullOrEmpty(cboTamanho.Text)) IdVariantesTamanho = Convert.ToInt32(cboTamanho.SelectedValue);
            if (!String.IsNullOrEmpty(cboCor.Text)) IdVariantesCor = Convert.ToInt32(cboCor.SelectedValue);
            if (!String.IsNullOrEmpty(cboEstilo.Text)) IdVariantesEstilo = Convert.ToInt32(cboEstilo.SelectedValue);
            //IdTipoDocumento = Convert.ToInt32(cboTipoEstoque.SelectedValue);
            BLInventario blInv = new BLInventario();
            Lista = blInv.ConsultaEstoqueSintetico(
                    IdProduto,
                    IdDeposito,
                    IdArmazem,
                    IdLocalizacao,
                    IdVariantesConfig,
                    IdVariantesTamanho,
                    IdVariantesCor,
                    IdVariantesEstilo,
                    IdTipoDocumento,
                    txtTextoLivre.Text
                );
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = Lista;
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //frmCrystalReportViewer frmv = new frmCrystalReportViewer("ConsultaEstoque");
            //frmv.ConsultaEstoque = Lista as IEnumerable<vwEstoqueSintetico>;
            //frmv.ShowDialog();
            VisualizadorGenerico frmv = new VisualizadorGenerico("ConsultaEstoque");
            frmv.ConsultaEstoque = Lista;
            frmv.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Util.Aplicacao.ShowQuestionMessage("Deseja realmente criar um novo inventário") == DialogResult.Yes)
            {
                InventarioEstoqueDAL invDal = new InventarioEstoqueDAL();
                int Numero = invDal.getMaxInventario();
                foreach(var es in Lista)
                {
                    InventarioEstoque i = new InventarioEstoque();
                    i.IdEmpresa = es.IdEmpresa;
                    i.IdProduto = es.IdProduto;
                    i.IdDeposito = es.IdDeposito;
                    i.IdArmazem = es.IdArmazem;
                    i.IdLocalizacao = es.IdLocalizacao;
                    i.IdVariantesCor = es.IdVariantesCor;
                    i.IdVariantesTamanho = es.IdVariantesTamanho;
                    i.IdVariantesEstilo = es.IdVariantesEstilo;
                    i.IdVariantesConfig = es.IdVariantesConfig;
                    i.IdUnidade = es.IdUnidade;
                    i.QtdeEstoque = es.Quantidade;
                    i.QtdeInventario = es.Quantidade;
                    i.Data = DateTime.Now;
                    i.Status = "Aguardando Confirmação";
                    i.Numero = Numero;
                    invDal.Insert(i);
                    invDal.Save();
                }

                frmInventarioEstoqueCad frm = new frmInventarioEstoqueCad(Numero);
                invDal = null;
                frm.ShowDialog();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmInventarioEstoqueCad frm = new frmInventarioEstoqueCad(1); 
            frm.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                int Id = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value);
                frmHistorico frmh = new frmHistorico(Id);
                frmh.ShowDialog();
            }
        }
    }
}
