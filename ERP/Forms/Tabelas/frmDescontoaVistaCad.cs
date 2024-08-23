using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmDescontoaVistaCad : RibbonForm
    {
        public DescontoaVistaDAL dal;
        DescontoaVista dv = new DescontoaVista();

        public frmDescontoaVistaCad(DescontoaVista pDV)
        {
            dv = pDV;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmDescontoaVistaCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarDescontoAVistaCalculo();
            CarregarContaContabilCliente();
            CarregarContaContabilFornecedor();

            if (dv.IdDescontoaVista == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmDescontoaVistaCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = dv.IdDescontoaVista.ToString();
            txtDescricao.Text = dv.Descricao;
            txtMeses.Text = dv.Meses.ToString();
            txtDias.Text = dv.Dias.ToString();

            if (dv.Calculo != null)
                cboCalculo.SelectedValue = dv.Calculo.ToString();
            if (dv.IdContaContabilCliente != null)
                cboContaContabilCliente.SelectedValue = dv.IdContaContabilCliente;
            if (dv.IdContaContabilFornecedor != null)
                cboContaContabilFornecedor.SelectedValue = dv.IdContaContabilFornecedor;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarDescontoAVistaCalculo()
        {
            List<DropList> lista = Util.EnumERP.CarregarDescontoAVistaCalculo();

            cboCalculo.DisplayMember = "Text";
            cboCalculo.ValueMember = "Value";
            cboCalculo.DataSource = lista;
            cboCalculo.SelectedIndex = -1;
        }

        private void CarregarContaContabilCliente()
        {
            cboContaContabilCliente.DataSource = new ContaContabilDAL().GetCombo();
            cboContaContabilCliente.DisplayMember = "Text";
            cboContaContabilCliente.ValueMember = "iValue";
            cboContaContabilCliente.SelectedIndex = -1;
        }

        private void CarregarContaContabilFornecedor()
        {
            cboContaContabilFornecedor.DataSource = new ContaContabilDAL().GetCombo();
            cboContaContabilFornecedor.DisplayMember = "Text";
            cboContaContabilFornecedor.ValueMember = "iValue";
            cboContaContabilFornecedor.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            dv = new DescontoaVista();
            lbCodigo.Text = "0";
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
                    Cursor.Current = Cursors.WaitCursor;

                    dv.Descricao = txtDescricao.Text;
                    dv.Meses = Convert.ToInt32(txtMeses.Text);
                    dv.Dias = Convert.ToInt32(txtDias.Text);

                    if (!String.IsNullOrEmpty(cboCalculo.Text))
                        dv.Calculo = Convert.ToInt32(cboCalculo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContaContabilCliente.Text))
                        dv.IdContaContabilCliente = Convert.ToInt32(cboContaContabilCliente.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContaContabilFornecedor.Text))
                        dv.IdContaContabilFornecedor = Convert.ToInt32(cboContaContabilFornecedor.SelectedValue);

                    if (dv.IdDescontoaVista == 0)
                    {
                        dal.Insert(dv);
                    }
                    else
                    {
                        dal.Update(dv);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
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
                try
                {
                    int id = dv.IdDescontoaVista;
                    dal.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowMessage("Este registro não pode ser excluído." + "\n" + "\n" + "Erro: " + ex.Message);
                }
            }
        }

        private void txtMeses_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}