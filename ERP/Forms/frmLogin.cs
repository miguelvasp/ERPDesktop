using ERP.DAL;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmLogin : Form
    {
        private UsuarioDAL uDal = new UsuarioDAL();
        private decimal? VersaoSistemaApp =  6.6M;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
           // this.AcceptButton = btnLogin;


            cboEmpresa.DataSource = new EmpresaDAL().GetCombo();
            cboEmpresa.DisplayMember = "Text";
            cboEmpresa.ValueMember = "iValue";
            ConfiguracaoDAL confDal = new ConfiguracaoDAL();
            decimal? Versao = confDal.ConsultaVersao();
            if(VersaoSistemaApp > Versao)
            {
                confDal.AtualizaVersao(VersaoSistemaApp);
            }

            if(Versao > VersaoSistemaApp)
            {
                Util.Aplicacao.ShowMessage("Versao do Sistema diferente da versão em produção.\n\rPor favor atualize o sistema.");
                Application.Exit();
            }


            Util.Util.SetAppSettings("IdUsuario", "");
            Util.Util.SetAppSettings("IdEmpresa", "");

            Util.Util.showBalloon("Selecione a empresa e informe suas credenciais.");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    panel1.Visible = true;
                    Application.DoEvents();

                    var usu = uDal.Login(txtUsuario.Text, txtSenha.Text);
                    Application.DoEvents();

                    if (usu == null)
                    {
                        panel1.Visible = false;
                        Application.DoEvents();
                        MessageBox.Show("Usuário/Senha inválido!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        frmMenu menu = new frmMenu();
                        Util.Util.SetAppSettings("IdUsuario", usu.IdUsuario.ToString());
                        Util.Util.SetAppSettings("IdEmpresa", cboEmpresa.SelectedValue.ToString());
                        menu.Show();

                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool ValidarCampos()
        {
            bool valido = true;

            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                valido = false;
                MessageBox.Show("Usuário deve estar preenchido, verifique!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtSenha.Text))
            {
                valido = false;
                MessageBox.Show("Senha deve estar preenchida, verifique!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return valido;
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
        }
    }
}
