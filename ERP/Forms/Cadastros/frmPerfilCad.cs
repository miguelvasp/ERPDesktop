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
    public partial class frmPerfilCad : RibbonForm
    {
        private Perfil prf = new Perfil();
        private PerfilDAL pDal = new PerfilDAL();
        private PerfilModuloDAL pmRepository = new PerfilModuloDAL();
        private PermissaoDAL pRepository = new PermissaoDAL();

        public frmPerfilCad(Perfil perfil)
        {
            prf = perfil;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmPerfilCad_Load(object sender, EventArgs e)
        {
            if (prf.IdPerfil == 0)
            {
                CarregarPerfis(prf.IdPerfil);

                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void CarregaDados()
        {
            lblCodigo.Text = prf.IdPerfil.ToString();
            txtNome.Text = prf.Nome;
            txtDescricao.Text = prf.Descricao;
            chkAtivo.Checked = prf.Ativo;

            CarregarPerfis(prf.IdPerfil);

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void CarregarPerfis(int IdPerfil)
        {
            var modulos = pmRepository.MRepository.Get().OrderBy(c => c.Nome).ToList();
            List<Modulo> ModuloDisponivel = modulos;
            List<Modulo> ModulosUtilizado = new List<Modulo>();

            if (IdPerfil != 0)
            {
                var p = pmRepository.PRepository.GetByID(IdPerfil);

                foreach (var item in p.PerfilModulo.OrderBy(a => a.Modulo.Nome))
                {
                    ModuloDisponivel.Remove(item.Modulo);
                    ModulosUtilizado.Add(item.Modulo);
                }
            }

            ltbDisponivel.Items.Clear();
            foreach (var item in ModuloDisponivel)
            {
                ltbDisponivel.ValueMember = "IdModulo";
                ltbDisponivel.DisplayMember = "Nome";
                ltbDisponivel.Items.Add(item);
            }

            ltbSelecionado.Items.Clear();
            foreach (var item in ModulosUtilizado)
            {
                ltbSelecionado.ValueMember = "IdModulo";
                ltbSelecionado.DisplayMember = "Nome";
                ltbSelecionado.Items.Add(item);
            }
        }

        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            for (int x = 0; x <= ltbDisponivel.Items.Count; x++)
            {
                if (ltbDisponivel.GetSelected(x) == true)
                {
                    var item = ltbDisponivel.SelectedItems[0];
                    ltbSelecionado.ValueMember = "IdModulo";
                    ltbSelecionado.DisplayMember = "Nome";
                    ltbSelecionado.Items.Add(item);
                    ltbDisponivel.Items.Remove(ltbDisponivel.SelectedItems[0]);

                    break;
                }
            }
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            for (int x = 0; x <= ltbSelecionado.Items.Count; x++)
            {
                if (ltbSelecionado.GetSelected(x) == true)
                {
                    var item = ltbSelecionado.SelectedItems[0];
                    ltbDisponivel.ValueMember = "IdModulo";
                    ltbDisponivel.DisplayMember = "Nome";
                    ltbDisponivel.Items.Add(item);
                    ltbSelecionado.Items.Remove(ltbSelecionado.SelectedItems[0]);

                    break;
                }
            }
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            prf = new Perfil();
            lblCodigo.Text = "0";
            CarregarPerfis(prf.IdPerfil);

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
                    int idPerfil = prf.IdPerfil;
                    if (prf.IdPerfil != 0)
                    {
                        var p = pmRepository.PRepository.GetByID(idPerfil);
                        p.Nome = txtNome.Text; ;
                        p.Descricao = txtDescricao.Text;
                        p.Ativo = chkAtivo.Checked;

                        var pmOld = pmRepository.PMRepository.Get().Where(pm => pm.IdPerfil.Equals(idPerfil)).ToList();
                        if (pmOld != null || pmOld.Count > 0)
                        {
                            foreach (var item in pmOld)
                            {
                                bool existPM = false;

                                for (int i = 0; i < ltbSelecionado.Items.Count; i++)
                                {
                                    int idModulo = ((ERP.Models.Modulo)(ltbSelecionado.Items[i])).IdModulo;

                                    if (item.IdModulo == idModulo)
                                    {
                                        existPM = true;
                                        break;
                                    }
                                }

                                if (!existPM)
                                {
                                    pmRepository.PMRepository.Delete(item.IdPerfilModulo);
                                }
                            }
                        }

                        for (int i = 0; i < ltbSelecionado.Items.Count; i++)
                        {
                            int idModulo = ((ERP.Models.Modulo)(ltbSelecionado.Items[i])).IdModulo;
                            var apNew = pmRepository.PMRepository.Get().Where(pm => pm.IdPerfil.Equals(idPerfil) && pm.IdModulo.Equals(idModulo)).ToList();
                            if (apNew == null || apNew.Count() == 0)
                            {
                                PerfilModulo pm = new PerfilModulo();
                                pm.IdPerfilModulo = 0;
                                pm.IdPerfil = prf.IdPerfil;
                                pm.IdModulo = idModulo;

                                p.PerfilModulo.Add(pm);
                            }
                        }

                        pmRepository.PRepository.Update(p);
                    }
                    else
                    {
                        Perfil p = new Perfil();
                        p.IdPerfil = idPerfil;
                        p.Nome = txtNome.Text; ;
                        p.Descricao = txtDescricao.Text;
                        p.Ativo = chkAtivo.Checked;
                        p.PerfilModulo = new List<PerfilModulo>();

                        for (int i = 0; i < ltbSelecionado.Items.Count; i++)
                        {
                            int idModulo = ((ERP.Models.Modulo)(ltbSelecionado.Items[i])).IdModulo;

                            PerfilModulo pm = new PerfilModulo();
                            pm.IdPerfilModulo = 0;
                            pm.IdPerfil = prf.IdPerfil;
                            pm.IdModulo = idModulo;

                            p.PerfilModulo.Add(pm);
                        }

                        pmRepository.PRepository.Insert(p);
                    }

                    pmRepository.Save(Util.Util.GetAppSettings("IdUsuario"));

                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
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
                    int idPerfil = prf.IdPerfil;
                    Perfil p = pDal.PRepository.GetByID(idPerfil);
                    if (p != null)
                    {
                        if (p.Usuario != null && p.Usuario.Count == 0)
                        {
                            var ua = pRepository.PURepository.Get().Where(w => w.IdPerfil.Equals(idPerfil)).ToList();
                            foreach (var item in ua)
                            {
                                pRepository.PURepository.Delete(item.IdPermissao);
                            }

                            pRepository.PFRepository.Delete(idPerfil);
                            pRepository.Save();
                        }
                        else
                        {
                            Util.Aplicacao.ShowMessage("Perfil não pode ser apagado, pois está vinculado a usuário!");
                        }
                    }
                    else
                    {
                        Util.Aplicacao.ShowMessage("Perfil não encontrado!");
                    }
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
            }
        }
    }
}
