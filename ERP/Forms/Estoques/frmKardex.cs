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
using ERP.ModelView;

namespace ERP 
{
    public partial class frmKardex : Form
    { 
        public frmKardex()
        {
            InitializeComponent();
        }

        private void frmConsultaEstoque_Load(object sender, EventArgs e)
        {
            CarregaCombos();
            txtDe.Text = DateTime.Now.ToShortDateString();
            txtAte.Text = DateTime.Now.ToShortDateString();
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

            List<ComboItem> tpEstoque = new List<ComboItem>();
            tpEstoque.Add(new ComboItem() { iValue = 3, Text = "Estoque Físico" });
            tpEstoque.Add(new ComboItem() { iValue = 1, Text = "Compras" });


            //cboTipoEstoque.DataSource = tpEstoque;
            //cboTipoEstoque.ValueMember = "iValue";
            //cboTipoEstoque.DisplayMember = "Text"; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            int IdProduto = 0; 
            int IdVariantesConfig = 0;
            int IdVariantesTamanho = 0;
            int IdVariantesCor = 0;
            int IdVariantesEstilo = 0;
            DateTime de = Convert.ToDateTime(txtDe.Text + " 00:00");
            DateTime ate = Convert.ToDateTime(txtAte.Text + " 23:59");

            if (!String.IsNullOrEmpty(cboProduto.Text)) IdProduto = Convert.ToInt32(cboProduto.SelectedValue); 
            if (!String.IsNullOrEmpty(cboConfiguracao.Text)) IdVariantesConfig = Convert.ToInt32(cboConfiguracao.SelectedValue);
            if (!String.IsNullOrEmpty(cboTamanho.Text)) IdVariantesTamanho = Convert.ToInt32(cboTamanho.SelectedValue);
            if (!String.IsNullOrEmpty(cboCor.Text)) IdVariantesCor = Convert.ToInt32(cboCor.SelectedValue);
            if (!String.IsNullOrEmpty(cboEstilo.Text)) IdVariantesEstilo = Convert.ToInt32(cboEstilo.SelectedValue);

            KardexDAL dal = new KardexDAL();
            dal.ConsultaKardex(IdProduto, IdVariantesCor, IdVariantesEstilo, IdVariantesTamanho, IdVariantesConfig, de, ate);
            var lista = dal.getByUsuario();
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = lista; 

            if(lista.Count > 0)
            {
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ERP.CrystalReports.frmCrystalReportViewer frm = new frmCrystalReportViewer("Kardex");
            List<FiltroRelatorio> FiltrosRelatorio = new List<FiltroRelatorio>();
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "Id", Valor = Util.Util.GetAppSettings("IdUsuario") });
            frm.FiltrosRelatorio = FiltrosRelatorio; 
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            frmBuscaProduto frmb = new frmBuscaProduto();
            frmb.ShowDialog();
            var p = frmb.ProdutoSelecionado;
            if(p != null)
            {
                cboProduto.SelectedValue = p.IdProduto;
                cboConfiguracao.SelectedValue = p.IdVariantesConfig == null ? 0 : p.IdVariantesConfig;
                cboCor.SelectedValue = p.IdVariantesCor == null ? 0 : p.IdVariantesCor;
                cboEstilo.SelectedValue = p.IdVariantesEstilo == null ? 0 : p.IdVariantesEstilo;
                cboTamanho.SelectedValue = p.IdVariantesTamanho == null ? 0 : p.IdVariantesTamanho;
            }
        }
    }
}
