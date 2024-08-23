using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmAutoridadeCad : RibbonForm
    {
        public AutoridadeDAL dal;
        Autoridade aut = new Autoridade();

        public frmAutoridadeCad(Autoridade pAut)
        {
            aut = pAut;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmAutoridadeCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarAutoridadesAgencia();
            CarregaFornecedores();
            CarregarAutoridadesFormaDeArredondamento();

            if (aut.IdAutoridade == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmAutoridadeCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = aut.IdAutoridade.ToString();
            txtNomeAutoridade.Text = aut.NomeAutoridade;
            txtDescricao.Text = aut.Descricao;
            txtIdentificacao.Text = aut.IdentificacaoAutoridade;
            cboAgencia.SelectedValue = aut.Agencia.ToString();
            cboFornecedor.SelectedValue = aut.IdFornecedor;
            cboFormaArredondamento.SelectedValue = aut.FormaArredondamento.ToString();
            txtArredondamento.Text = aut.Arredondamento.ToString("N4");

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarAutoridadesAgencia()
        {
            List<DropList> lista = Util.EnumERP.CarregarAutoridadesAgencia();

            cboAgencia.DisplayMember = "Text";
            cboAgencia.ValueMember = "Value";
            cboAgencia.DataSource = lista;
            cboAgencia.SelectedIndex = -1;
        }

        protected void CarregaFornecedores()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(sEmpresa);
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.SelectedIndex = -1;
        }

        private void CarregarAutoridadesFormaDeArredondamento()
        {
            List<DropList> lista = Util.EnumERP.CarregarAutoridadesFormaDeArredondamento();

            cboFormaArredondamento.DisplayMember = "Text";
            cboFormaArredondamento.ValueMember = "Value";
            cboFormaArredondamento.DataSource = lista;
            cboFormaArredondamento.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            aut = new Autoridade();
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

                    aut.NomeAutoridade = txtNomeAutoridade.Text;
                    aut.Descricao = txtDescricao.Text;
                    aut.IdentificacaoAutoridade = txtIdentificacao.Text;
                    if (!String.IsNullOrEmpty(cboAgencia.Text))
                        aut.Agencia = Convert.ToInt32(cboAgencia.SelectedValue);

                    if (!String.IsNullOrEmpty(cboFornecedor.Text))
                        aut.IdFornecedor = Convert.ToInt32(cboFornecedor.SelectedValue);

                    if (!String.IsNullOrEmpty(cboFormaArredondamento.Text))
                        aut.FormaArredondamento = Convert.ToInt32(cboFormaArredondamento.SelectedValue);
                    aut.Arredondamento = Convert.ToDecimal(txtArredondamento.Text);

                    if (aut.IdAutoridade == 0)
                    {
                        dal.Insert(aut);
                    }
                    else
                    {
                        dal.Update(aut);
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
                    int id = aut.IdAutoridade;
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

        private void txtArredondamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtArredondamento.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
    }
}

