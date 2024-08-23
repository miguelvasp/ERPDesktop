using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPedidoVendas : Form
    {
        PedidoVendaDAL dal = new PedidoVendaDAL();

        public frmPedidoVendas()
        {
            InitializeComponent();
            txtDataFim.Text = DateTime.Now.ToShortDateString();
            txtDataInicio.Text = DateTime.Now.AddDays(-7).ToShortDateString();
        }

        private void frmPedidoVendas_Load(object sender, EventArgs e)
        {
            CarregaCombos();
            CarregaGrid();
        }

        private void CarregaCombos()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboCliente.DataSource = new ClienteDAL().GetCombo(sEmpresa);
            cboCliente.DisplayMember = "Text";
            cboCliente.ValueMember = "iValue";
            cboCliente.SelectedIndex = -1;

            cboGrupoCliente.DataSource = new GrupoClienteDAL().GetCombo();
            cboGrupoCliente.DisplayMember = "Text";
            cboGrupoCliente.ValueMember = "iValue";
            cboGrupoCliente.SelectedIndex = -1;

            List<ComboItem> Status = new List<ComboItem>();
            Status.Add(new ComboItem() { iValue = 1, Text = "Em Aberto" });
            Status.Add(new ComboItem() { iValue = 2, Text = "Separação" });
            Status.Add(new ComboItem() { iValue = 3, Text = "A Faturar" });
            Status.Add(new ComboItem() { iValue = 4, Text = "Faturado" });
            Status.Add(new ComboItem() { iValue = 5, Text = "Faturado Parcialmente" });
            Status.Add(new ComboItem() { iValue = 6, Text = "Cancelado" });
            Status.Add(new ComboItem() { iValue = 7, Text = "Saldo Cancelado" });
            cboStatus.DataSource = Status;
            cboStatus.DisplayMember = "Text";
            cboStatus.ValueMember = "iValue";
            cboStatus.SelectedIndex = -1;

            cboStatusAprovacao.DataSource = new AprovacaoNivelDAL().GetComboByTipoDocumento(2);
            cboStatusAprovacao.DisplayMember = "Text";
            cboStatusAprovacao.ValueMember = "iValue";
            cboStatusAprovacao.SelectedIndex = -1;

            cboProduto.DataSource = new ProdutoDAL().GetComboCompras();
            cboProduto.DisplayMember = "Text";
            cboProduto.ValueMember = "iValue";
            cboProduto.SelectedIndex = -1;

            cboVariantesConfig.DataSource = new VariantesConfigDAL().Get();
            cboVariantesConfig.ValueMember = "IdVariantesConfig";
            cboVariantesConfig.DisplayMember = "Descricao";
            cboVariantesConfig.SelectedIndex = -1;

            cboEstilo.DataSource = new VariantesEstiloDAL().GetCombo();
            cboEstilo.DisplayMember = "Text";
            cboEstilo.ValueMember = "iValue";
            cboEstilo.SelectedIndex = -1;

            cboCor.DataSource = new VariantesCorDAL().GetCombo();
            cboCor.DisplayMember = "Text";
            cboCor.ValueMember = "iValue";
            cboCor.SelectedIndex = -1;

            cboTamanho.DataSource = new VariantesTamanhoDAL().GetCombo();
            cboTamanho.DisplayMember = "Text";
            cboTamanho.ValueMember = "iValue";
            cboTamanho.SelectedIndex = -1;

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

            List<ComboItem> TipoOrdem = new List<ComboItem>();
            TipoOrdem.Add(new ComboItem() { iValue = 1, Text = "Ordem de Venda" });
            TipoOrdem.Add(new ComboItem() { iValue = 2, Text = "Devolução" });
            cboTipoOrdem.DataSource = TipoOrdem;
            cboTipoOrdem.DisplayMember = "Text";
            cboTipoOrdem.ValueMember = "iValue";
            cboTipoOrdem.SelectedIndex = -1;

            cboTeleVendas.DataSource = new FuncionarioDAL().GetCombo();
            cboTeleVendas.DisplayMember = "Text";
            cboTeleVendas.ValueMember = "iValue";
            cboTeleVendas.SelectedIndex = -1;

            cboVendedor.DataSource = new VendedorDAL().GetCombo();
            cboVendedor.DisplayMember = "Text";
            cboVendedor.ValueMember = "iValue";
            cboVendedor.SelectedIndex = -1;
        }

        private void CarregaGrid()
        {
            List<PedidoVendasModelView> lista = CarregarPedidosLista();

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = lista;
        }

        private List<PedidoVendasModelView> CarregarPedidosLista()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");
            string sCliente = ""; if (cboCliente.SelectedValue != null) sCliente = cboCliente.SelectedValue.ToString();
            string sGrupoCliente = ""; if (cboGrupoCliente.SelectedValue != null) sGrupoCliente = cboGrupoCliente.SelectedValue.ToString();
            string sArmazem = ""; if (cboArmazem.SelectedValue != null) sArmazem = cboArmazem.SelectedValue.ToString();
            string sDeposito = ""; if (cboDeposito.SelectedValue != null) sDeposito = cboDeposito.SelectedValue.ToString();
            string sLocalizacao = ""; if (cboLocalizacao.SelectedValue != null) sLocalizacao = cboLocalizacao.SelectedValue.ToString();
            string sProduto = ""; if (cboProduto.SelectedValue != null) sProduto = cboProduto.SelectedValue.ToString();
            string sConfig = ""; if (cboVariantesConfig.SelectedValue != null) sConfig = cboVariantesConfig.SelectedValue.ToString();
            string sEstilo = ""; if (cboEstilo.SelectedValue != null) sEstilo = cboEstilo.SelectedValue.ToString();
            string sCor = ""; if (cboCor.SelectedValue != null) sCor = cboCor.SelectedValue.ToString();
            string sTamanho = ""; if (cboTamanho.SelectedValue != null) sTamanho = cboTamanho.SelectedValue.ToString();
            string sTipoOrdem = ""; if (cboTipoOrdem.SelectedValue != null) sTipoOrdem = cboTipoOrdem.SelectedValue.ToString();
            string sTeleVendas = ""; if (cboTeleVendas.SelectedValue != null) sTeleVendas = cboTeleVendas.SelectedValue.ToString();
            string sVendedor = ""; if (cboVendedor.SelectedValue != null) sVendedor = cboVendedor.SelectedValue.ToString();
            string sStatus = ""; if (cboStatus.SelectedValue != null) sStatus = cboStatus.SelectedValue.ToString();
            string sStatusAprovacao = ""; if (cboStatusAprovacao.SelectedValue != null) sStatusAprovacao = cboStatusAprovacao.SelectedValue.ToString();
            string sCNPJ = txtCNPJ.Text.Trim();
            
            List<PedidoVendasModelView> lista = dal.GetPedidos(txtDataInicio.Text, txtDataFim.Text, txtDataEntregaDe.Text, txtDataEntregaAte.Text, txtNumPedido.Text, sEmpresa, sCliente, sGrupoCliente, sArmazem, sDeposito, sLocalizacao, sTipoOrdem, sTeleVendas, sVendedor, sProduto, sConfig, sEstilo, sCor, sTamanho, sStatus, sStatusAprovacao, sCNPJ).ToList();

            return lista;
        }

        private string MontarTextoFiltros()
        {
            string filtros = "";

            if (Util.Validacao.IsDateTime(txtDataInicio.Text) != null)
            {
                filtros += "Data De: " + txtDataInicio.Text + "; ";
            }

            if (Util.Validacao.IsDateTime(txtDataFim.Text) != null)
            {
                filtros += "Data Até: " + txtDataFim.Text + "; ";
            }

            if (Util.Validacao.IsDateTime(txtDataEntregaDe.Text) != null)
            {
                filtros += "Data Entrega De: " + txtDataEntregaDe.Text + "; ";
            }

            if (Util.Validacao.IsDateTime(txtDataEntregaAte.Text) != null)
            {
                filtros += "Data Entrega Até: " + txtDataEntregaAte.Text + "; ";
            }

            if (!string.IsNullOrEmpty(txtNumPedido.Text))
            {
                filtros += "N° Pedido: " + txtNumPedido.Text + "; ";
            }

            if (cboCliente.SelectedValue != null)
            {
                filtros += "Cliente: " + ((ERP.Models.ComboItem)(cboCliente.SelectedItem)).Text + "; ";
            }

            if (cboGrupoCliente.SelectedValue != null)
            {
                filtros += "Grupo Cliente: " + ((ERP.Models.ComboItem)(cboGrupoCliente.SelectedItem)).Text + "; ";
            }

            if (cboArmazem.SelectedValue != null)
            {
                filtros += "Armazém: " + ((ERP.Models.ComboItem)(cboArmazem.SelectedItem)).Text + "; ";
            }

            if (cboDeposito.SelectedValue != null)
            {
                filtros += "Depósito: " + ((ERP.Models.ComboItem)(cboDeposito.SelectedItem)).Text + "; ";
            }

            if (cboLocalizacao.SelectedValue != null)
            {
                filtros += "Localização: " + ((ERP.Models.ComboItem)(cboLocalizacao.SelectedItem)).Text + "; ";
            }

            if (cboTipoOrdem.SelectedValue != null)
            {
                filtros += "Tipo Ordem: " + ((ERP.Models.ComboItem)(cboTipoOrdem.SelectedItem)).Text + "; ";
            }

            if (cboTeleVendas.SelectedValue != null)
            {
                filtros += "TeleVendas: " + ((ERP.Models.ComboItem)(cboTeleVendas.SelectedItem)).Text + "; ";
            }

            if (cboVendedor.SelectedValue != null)
            {
                filtros += "Vendedor: " + ((ERP.Models.ComboItem)(cboVendedor.SelectedItem)).Text + "; ";
            }
            
            if (cboProduto.SelectedValue != null)
            {
                filtros += "Produto: " + ((ERP.Models.ComboItem)(cboProduto.SelectedItem)).Text + "; ";
            }

            if (cboVariantesConfig.SelectedValue != null)
            {
                filtros += "Config: " + ((ERP.Models.ComboItem)(cboVariantesConfig.SelectedItem)).Text + "; ";
            }            

            if (cboEstilo.SelectedValue!= null)
            {
                filtros += "Estilo: " + ((ERP.Models.ComboItem)(cboEstilo.SelectedItem)).Text + "; ";
            }

            if (cboCor.SelectedValue != null)
            {
                filtros += "Cor: " + ((ERP.Models.ComboItem)(cboCor.SelectedItem)).Text + "; ";
            }

            if (cboTamanho.SelectedValue != null)
            {
                filtros += "Tamanho: " + ((ERP.Models.ComboItem)(cboTamanho.SelectedItem)).Text + "; ";
            }

            if (cboStatus.SelectedValue != null)
            {
                filtros += "Status: " + ((ERP.Models.ComboItem)(cboStatus.SelectedItem)).Text + "; ";
            }

            if (cboStatusAprovacao.SelectedValue != null)
            {
                filtros += "Status Aprovação: " + ((ERP.Models.ComboItem)(cboStatusAprovacao.SelectedItem)).Text + "; ";
            }

            return filtros;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    PedidoVenda p = dal.PVRepository.GetByID(id);
                    frmPedidoVendasCad cad = new frmPedidoVendasCad(dal, p);
                    cad.Show();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmPedidoVendasCad cad = new frmPedidoVendasCad(dal, new PedidoVenda());
            cad.Show();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, "PedidoVenda.csv");
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void tsbPesquisa_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = !pnlPesquisa.Visible;
        }

        private void txtDataInicio_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void txtDataFim_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboCliente_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboProduto_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void txtNumPedido_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void txtNumPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboGrupoCliente_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboArmazem_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboDeposito_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboLocalizacao_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }
        
        private void cboTipoOrdem_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboTeleVendas_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboVendedor_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboVariantesConfig_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboEstilo_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboCor_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboTamanho_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboStatus_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboStatusAprovacao_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            List<PedidoVendasModelView> lista = CarregarPedidosLista();

            DataTable dt = Util.Aplicacao.LINQToDataTable(lista);

            if (dt.Rows.Count > 0)
            {
                // Montar Filtros //
                string filtros = MontarTextoFiltros();

                ERP.Relatorios.frmRepPedidoVendas frm = new ERP.Relatorios.frmRepPedidoVendas(dt, filtros);
                frm.ShowDialog();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Não existe dados para gerar o relatório!");
            }
        }
    }
}
