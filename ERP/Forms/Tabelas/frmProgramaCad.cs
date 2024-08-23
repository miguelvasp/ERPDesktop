using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmProgramaCad : RibbonForm
    {
        public ProgramaDAL dal;
        Programa prg = new Programa();

        public frmProgramaCad(Programa pPrograma)
        {
            prg = pPrograma;
            InitializeComponent();
        }

        private void frmProgramaCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarTipoPrograma();

            if (prg.IdPrograma == 0)
            {
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

            lblCodigo.Text = prg.IdPrograma.ToString();
            txtNome.Text = prg.Nome;
            txtDescricao.Text = prg.Descricao;
            txtFormulario.Text = prg.Formulario;
            chkManutencao.Checked = prg.Manutencao;
            cboTipoPrograma.SelectedValue = prg.TipoPrograma.ToString();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarTipoPrograma()
        {
            List<DropList> lista = Util.EnumERP.CarregarTipoPrograma();

            cboTipoPrograma.DisplayMember = "Text";
            cboTipoPrograma.ValueMember = "Value";
            cboTipoPrograma.DataSource = lista;
            cboTipoPrograma.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            prg = new Programa();
            lblCodigo.Text = "0";
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

                    prg.Nome = txtNome.Text;
                    prg.Descricao = txtDescricao.Text;
                    prg.Formulario = txtFormulario.Text;
                    prg.Manutencao = chkManutencao.Checked;
                    if (!String.IsNullOrEmpty(cboTipoPrograma.Text))
                        prg.TipoPrograma = Convert.ToInt32(cboTipoPrograma.SelectedValue);

                    if (prg.IdPrograma == 0)
                    {
                        dal.Insert(prg);
                    }
                    else
                    {
                        dal.Update(prg);
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
                    int id = prg.IdPrograma;
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
    }
}
