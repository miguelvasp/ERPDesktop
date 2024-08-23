using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmModuloCad : RibbonForm
    {
        private Modulo mdl = new Modulo();
        private ModuloDAL dal = new ModuloDAL(new DB_ERPContext());
        private ModuloProgramaDAL mpRepository = new ModuloProgramaDAL();
        private PerfilModuloDAL pmRepository = new PerfilModuloDAL();

        public frmModuloCad(Modulo pModulo)
        {
            mdl = pModulo;
            InitializeComponent();
        }

        private void frmModuloCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (mdl.IdModulo == 0)
            {
                CarregarProgramas(mdl.IdModulo);

                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lblCodigo.Text = mdl.IdModulo.ToString();
            txtNome.Text = mdl.Nome;
            txtDescricao.Text = mdl.Descricao;

            CarregarProgramas(mdl.IdModulo);

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarProgramas(int IdModulo)
        {
            var programas = mpRepository.PRepository.Get().OrderBy(c => c.Nome).ToList();
            List<Programa> programaDisponivel = programas;
            List<Programa> programasUtilizado = new List<Programa>();

            if (IdModulo != 0)
            {
                var p = mpRepository.MRepository.GetByID(IdModulo);

                foreach (var item in p.ModuloPrograma.OrderBy(a => a.Programa.Nome))
                {
                    programaDisponivel.Remove(item.Programa);
                    programasUtilizado.Add(item.Programa);
                }
            }

            ltbDisponivel.Items.Clear();
            foreach (var item in programaDisponivel)
            {
                ltbDisponivel.ValueMember = "IdPrograma";
                ltbDisponivel.DisplayMember = "Nome";
                ltbDisponivel.Items.Add(item);
            }

            ltbSelecionado.Items.Clear();
            foreach (var item in programasUtilizado)
            {
                ltbSelecionado.ValueMember = "IdPrograma";
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
                    ltbSelecionado.ValueMember = "IdPrograma";
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
                    ltbDisponivel.ValueMember = "IdPrograma";
                    ltbDisponivel.DisplayMember = "Nome";
                    ltbDisponivel.Items.Add(item);
                    ltbSelecionado.Items.Remove(ltbSelecionado.SelectedItems[0]);

                    break;
                }
            }
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            mdl = new Modulo();
            lblCodigo.Text = "0";
            CarregarProgramas(mdl.IdModulo);

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

                    int idModulo = mdl.IdModulo;
                    if (mdl.IdModulo != 0)
                    {
                        var m = mpRepository.MRepository.GetByID(idModulo);
                        m.Nome = txtNome.Text;
                        m.Descricao = txtDescricao.Text;

                        var mpOld = mpRepository.MPRepository.Get().Where(mp => mp.IdModulo.Equals(idModulo)).ToList();
                        if (mpOld != null || mpOld.Count > 0)
                        {
                            foreach (var item in mpOld)
                            {
                                bool existMP = false;

                                for (int i = 0; i < ltbSelecionado.Items.Count; i++)
                                {
                                    int idPrograma = ((ERP.Models.Programa)(ltbSelecionado.Items[i])).IdPrograma;

                                    if (item.IdPrograma == idPrograma)
                                    {
                                        existMP = true;
                                        break;
                                    }
                                }

                                if (!existMP)
                                {
                                    // Traz todos os Perfis do módulo que foi alterado//
                                    var perfil = pmRepository.PMRepository.Get().Where(w => w.IdModulo == idModulo).ToList();
                                    if (perfil != null && perfil.Count() > 0)
                                    {
                                        foreach (var iPerfil in perfil)
                                        {
                                            bool existProg = false;
                                            var modulo = pmRepository.PMRepository.Get().Where(w => w.IdPerfil == iPerfil.IdPerfil && w.IdModulo != idModulo).ToList();

                                            foreach (var iModulo in modulo)
                                            {
                                                var prog = mpRepository.MPRepository.Get().Where(w => w.IdModulo == iModulo.IdModulo && w.IdPrograma == item.IdPrograma).FirstOrDefault();
                                                if (prog != null)
                                                {
                                                    existProg = true;
                                                    break;
                                                }
                                            }

                                            if (!existProg)
                                            {
                                                var pu = mpRepository.PURepository.Get().Where(w => w.IdPrograma.Equals(item.IdPrograma) && w.IdPerfil.Equals(iPerfil.IdPerfil)).ToList();
                                                foreach (var itemPermissao in pu)
                                                {
                                                    mpRepository.PURepository.Delete(itemPermissao.IdPermissao);
                                                }
                                            }
                                        }
                                    }

                                    mpRepository.MPRepository.Delete(item.IdModuloPrograma);
                                }
                            }
                        }

                        for (int i = 0; i < ltbSelecionado.Items.Count; i++)
                        {
                            int idPrograma = ((ERP.Models.Programa)(ltbSelecionado.Items[i])).IdPrograma;
                            var apNew = mpRepository.MPRepository.Get().Where(mp => mp.IdModulo.Equals(idModulo) && mp.IdPrograma.Equals(idPrograma)).ToList();
                            if (apNew == null || apNew.Count() == 0)
                            {
                                ModuloPrograma mp = new ModuloPrograma();
                                mp.IdModuloPrograma = 0;
                                mp.IdModulo = idModulo;
                                mp.IdPrograma = idPrograma;

                                m.ModuloPrograma.Add(mp);
                            }
                        }

                        mpRepository.MRepository.Update(m);
                    }
                    else
                    {
                        Modulo m = new Modulo();
                        m.IdModulo = idModulo;
                        m.Nome = txtNome.Text;
                        m.Descricao = txtDescricao.Text;
                        m.ModuloPrograma = new List<ModuloPrograma>();

                        for (int i = 0; i < ltbSelecionado.Items.Count; i++)
                        {
                            int idPrograma = ((ERP.Models.Programa)(ltbSelecionado.Items[i])).IdPrograma;

                            ModuloPrograma mp = new ModuloPrograma();
                            mp.IdModuloPrograma = 0;
                            mp.IdModulo = idModulo;
                            mp.IdPrograma = idPrograma;

                            m.ModuloPrograma.Add(mp);
                        }
                        mpRepository.MRepository.Insert(m);
                    }

                    mpRepository.Save();

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
            if (Util.Aplicacao.ShowQuestionMessage("Qualquer alteração efetuada será perdida, deseja continuar?") == DialogResult.Yes)
            {
                CarregaDados();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == DialogResult.Yes)
            {
                try
                {
                    int idModulo = mdl.IdModulo;
                    Modulo mod = dal.GetByID(idModulo);
                    if (mod != null)
                    {
                        // Traz todos os Programas do módulo //
                        var programas = mpRepository.MPRepository.Get().Where(w => w.IdModulo.Equals(idModulo)).ToList();

                        // Traz todos os Perfis do módulo que foi apagado //
                        var perfil = pmRepository.PMRepository.Get().Where(w => w.IdModulo == idModulo).ToList();

                        foreach (var iProg in programas)
                        {
                            if (perfil != null && perfil.Count() > 0)
                            {
                                foreach (var iPerfil in perfil)
                                {
                                    bool existProg = false;
                                    var modulo = pmRepository.PMRepository.Get().Where(w => w.IdPerfil == iPerfil.IdPerfil && w.IdModulo != idModulo).ToList();

                                    foreach (var iModulo in modulo)
                                    {
                                        var prog = mpRepository.MPRepository.Get().Where(w => w.IdModulo == iModulo.IdModulo && w.IdPrograma == iProg.IdPrograma).FirstOrDefault();
                                        if (prog != null)
                                        {
                                            existProg = true;
                                            break;
                                        }
                                    }

                                    if (!existProg)
                                    {
                                        var pu = mpRepository.PURepository.Get().Where(w => w.IdPrograma.Equals(iProg.IdPrograma) && w.IdPerfil.Equals(iPerfil.IdPerfil)).ToList();
                                        foreach (var itemPermissao in pu)
                                        {
                                            mpRepository.PURepository.Delete(itemPermissao.IdPermissao);
                                        }
                                    }
                                }
                            }
                        }

                        mpRepository.MRepository.Delete(idModulo);
                        mpRepository.Save();

                        this.Close();
                    }
                    else
                    {
                        Util.Aplicacao.ShowMessage("Registro não encontrado.");
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
