using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Estoques
{
    public partial class frmInventarioPesquisa : Form
    {
        List<InventarioEstoque> Lista = new List<InventarioEstoque>();
        InventarioEstoqueDAL dal = new InventarioEstoqueDAL();
        public frmInventarioPesquisa()
        {
            InitializeComponent();
        }

        private void frmInventarioPesquisa_Load(object sender, EventArgs e)
        {
            CarregaCombos();
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
            int IdProduto = 0;
            int IdDeposito = 0;
            int IdArmazem = 0;
            int IdLocalizacao = 0;
            int IdVariantesConfig = 0;
            int IdVariantesTamanho = 0;
            int IdVariantesCor = 0;
            int IdVariantesEstilo = 0;
            int numero = 0;
            if (!String.IsNullOrEmpty(txtNumero.Text)) numero = Convert.ToInt32(txtNumero.Text);
            if (!String.IsNullOrEmpty(cboProduto.Text)) IdProduto = Convert.ToInt32(cboProduto.SelectedValue);
            if (!String.IsNullOrEmpty(cboDeposito.Text)) IdDeposito = Convert.ToInt32(cboDeposito.SelectedValue);
            if (!String.IsNullOrEmpty(cboArmazem.Text)) IdArmazem = Convert.ToInt32(cboArmazem.SelectedValue);
            if (!String.IsNullOrEmpty(cboLocalizacao.Text)) IdLocalizacao = Convert.ToInt32(cboLocalizacao.SelectedValue);
            if (!String.IsNullOrEmpty(cboConfiguracao.Text)) IdVariantesConfig = Convert.ToInt32(cboConfiguracao.SelectedValue);
            if (!String.IsNullOrEmpty(cboTamanho.Text)) IdVariantesTamanho = Convert.ToInt32(cboTamanho.SelectedValue);
            if (!String.IsNullOrEmpty(cboCor.Text)) IdVariantesCor = Convert.ToInt32(cboCor.SelectedValue);
            if (!String.IsNullOrEmpty(cboEstilo.Text)) IdVariantesEstilo = Convert.ToInt32(cboEstilo.SelectedValue);
            //IdTipoDocumento = Convert.ToInt32(cboTipoEstoque.SelectedValue); 
            Lista = dal.getByParams(
                numero,
                    IdProduto,
                    IdDeposito,
                    IdArmazem,
                    IdLocalizacao,
                    IdVariantesConfig,
                    IdVariantesTamanho,
                    IdVariantesCor,
                    IdVariantesEstilo
                );
            var inventarios = Lista.Select(p => new {
                Numero = p.Numero,
                IdInventarioEstoque = p.IdInventarioEstoque,
                Codigo = p.Produto.Codigo,
                NomeProduto = p.Produto.NomeProduto,
                Deposito = p.Deposito == null ? "" : p.Deposito.Descricao,
                Armazem = p.Armazem == null ? "" : p.Armazem.Descricao,
                Localizacao = p.Localizacao == null ? "" : p.Localizacao.Nome,
                Cor = p.VariantesCor == null ? "" : p.VariantesCor.Descricao,
                Tamanho = p.VariantesTamanho == null ? "" : p.VariantesTamanho.Descricao,
                Estilo = p.VariantesEstilo == null ? "" : p.VariantesEstilo.Descricao,
                Config = p.VariantesConfig == null ? "" : p.VariantesConfig.Descricao,
                Unidade = p.Unidade == null ? "" : p.Unidade.UnidadeMedida,
                QtdeEstoque = p.QtdeEstoque,
                QtdeInventario = p.QtdeInventario,
                Status = p.Status
            }).ToList();
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = inventarios;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0)
                {
                    int num = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["numero"].Value);
                    frmInventarioEstoqueCad frm = new frmInventarioEstoqueCad(num);
                    frm.ShowDialog();
                }
            }
            catch
            {

            }
        }
    }
}
