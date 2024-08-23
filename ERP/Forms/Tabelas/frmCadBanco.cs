using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCadBanco : RibbonForm
    {
        Banco banco = new Banco();
        BancoDAL dal = new BancoDAL();

        public frmCadBanco(Banco pbanco)
        {
            banco = pbanco;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void frmCadBanco_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (banco.IdBanco == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmCadBanco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = banco.IdBanco.ToString();
            txtNome.Text = banco.NomeBanco;
            txtNumero.Text = banco.NumeroBanco;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            banco = new Banco();
            lbCodigo.Text = "0";
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
            //if(ValidaCampos())
            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    banco.NomeBanco = txtNome.Text;
                    banco.NumeroBanco = txtNumero.Text;
                    if (banco.IdBanco == 0)
                    {
                        dal.Insert(banco);
                    }
                    else
                    {
                        dal.Update(banco);
                    }
                    dal.Save();
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
                    int id = banco.IdBanco;
                    dal.Delete(id);
                    dal.Save();
                    Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowMessage("Este registro não pode ser excluído." + "\n" + "\n" + "Erro: " + ex.Message);
                }
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
