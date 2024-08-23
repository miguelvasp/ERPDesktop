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

namespace ERP
{
    public partial class frmUsuarioCad : RibbonForm
    {
        private Usuario usu = new Usuario();
        public UsuarioDAL uRepository;
        private PermissaoDAL pRepository = new PermissaoDAL();
        private PerfilDAL pDal = new PerfilDAL();

        public frmUsuarioCad(Usuario usuario)
        {
            usu = usuario;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmUsuarioCad_Load(object sender, EventArgs e)
        {
            if (usu.IdUsuario == 0)
            {
                CarregarPerfil();
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }
        
        private void frmUsuarioCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            CarregarPerfil();

            cboPerfil.SelectedValue = usu.IdPerfil;
            txtNome.Text = usu.NomeCompleto;
            chkAtivo.Checked = usu.Ativo;
            txtLogin.Text = usu.Login;
            txtEMail.Text = usu.EMail;
            if (!string.IsNullOrEmpty(usu.Senha))
            {
                txtSenha.Text = Util.Util.Descriptografar(usu.Senha);
            }

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void CarregarPerfil()
        {
            //Carrega o combo

            var perfis = pDal.PRepository.Get().Where(w => w.Ativo == true).OrderBy(o => o.Nome).ToList();
            cboPerfil.DataSource = perfis;
            cboPerfil.ValueMember = "IdPerfil";
            cboPerfil.DisplayMember = "Nome";

            cboPerfil.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            usu = new Usuario();
            lblCodigo.Text = "0";
            CarregarPerfil();

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
                if (ValidarCampos())
                {
                    try
                    {
                        int idUsuario = usu.IdUsuario;
                        if (usu.IdUsuario == 0)
                        {
                            Usuario u = new Usuario();
                            u.IdUsuario = idUsuario;
                            u.IdPerfil = Convert.ToInt32(cboPerfil.SelectedValue);
                            u.NomeCompleto = txtNome.Text; ;
                            u.Login = txtLogin.Text;
                            u.EMail = txtEMail.Text;
                            u.Ativo = chkAtivo.Checked;
                            u.Senha = Util.Util.Criptografar(txtSenha.Text);

                            uRepository.URepository.Insert(u);
                        }
                        else
                        {
                            var u = uRepository.URepository.GetByID(idUsuario);
                            if (u != null)
                            {
                                // Verifica se houve mudança nos perfis e apaga as permissões deste usuário //
                                if (usu.IdPerfil != u.IdPerfil)
                                {
                                    var uaList = pRepository.PURepository.Get().Where(w => w.IdUsuario.Equals(idUsuario)).ToList();
                                    foreach (var item in uaList)
                                    {
                                        pRepository.PURepository.Delete(item.IdPermissao);
                                    }
                                }

                                u.IdPerfil = Convert.ToInt32(cboPerfil.SelectedValue);
                                u.NomeCompleto = txtNome.Text; ;
                                u.Login = txtLogin.Text;
                                u.EMail = txtEMail.Text;
                                u.Ativo = chkAtivo.Checked;
                                u.Senha = Util.Util.Criptografar(txtSenha.Text);
                            }

                            uRepository.URepository.Update(u);
                        }
                                                
                        uRepository.Save(Util.Util.GetAppSettings("IdUsuario"));

                        Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                    }
                    catch (Exception ex)
                    {
                        Util.Aplicacao.ShowErrorMessage(ex);
                    }
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
                    int idUsuario = usu.IdUsuario;
                    Usuario u = uRepository.URepository.GetByID(idUsuario);
                    if (u != null)
                    {
                        u.Ativo = false;

                        uRepository.URepository.Update(u);
                        uRepository.Save();
                    }
                    else
                    {
                        Util.Aplicacao.ShowMessage("Usuário não encontrado!");
                    }
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
            }
        }

        private bool ValidarCampos()
        {
            bool valido = true;

            if (!Util.Validacao.ValidaEmail(txtEMail.Text))
            {
                valido = false;
                Util.Aplicacao.ShowMessage("Email inválido!");
            }

            if (usu.IdUsuario == 0)
            {
                if (uRepository.ConsultaLogin(txtLogin.Text) != null)
                {
                    valido = false;
                    Util.Aplicacao.ShowMessage("Login já cadastrado, verifique!");
                }
            }

            return valido;
        }
    }
}
