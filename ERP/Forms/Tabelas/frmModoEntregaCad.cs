using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmModoEntregaCad : RibbonForm
    {
        public ModoEntregaDAL dal;
        ModoEntrega me = new ModoEntrega();

        public frmModoEntregaCad(ModoEntrega pME)
        {
            me = pME;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmModoEntregaCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarGrupoEncargos();
            CarregarModoEntregaServicos();
            CarregarTransportadoras();

            if (me.IdModoEntrega == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmModoEntregaCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = me.IdModoEntrega.ToString();
            txtNome.Text = me.Nome;
            txtDescricao.Text = me.Descricao;
            if (me.IdGrupoEncargos != null)
                cboGrupoEncargos.SelectedValue = me.IdGrupoEncargos;
            if (me.Servicos != null)
                cboServicos.SelectedValue = me.Servicos.ToString();
            if (me.IdTransportadora != null)
                cboTransportadora.SelectedValue = me.IdTransportadora;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarGrupoEncargos()
        {
            cboGrupoEncargos.DataSource = new GrupoEncargosDAL().getCombo();
            cboGrupoEncargos.DisplayMember = "Text";
            cboGrupoEncargos.ValueMember = "iValue";
            cboGrupoEncargos.SelectedIndex = -1;
        }

        private void CarregarModoEntregaServicos()
        {
            List<DropList> lista = Util.EnumERP.CarregarModoEntregaServicos();

            cboServicos.DisplayMember = "Text";
            cboServicos.ValueMember = "Value";
            cboServicos.DataSource = lista;
            cboServicos.SelectedIndex = -1;
        }

        private void CarregarTransportadoras()
        {
            cboTransportadora.DataSource = new TransportadoraDAL().GetCombo();
            cboTransportadora.DisplayMember = "Text";
            cboTransportadora.ValueMember = "iValue";
            cboTransportadora.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            me = new ModoEntrega();
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

                    me.Nome = txtNome.Text;
                    me.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboGrupoEncargos.Text))
                        me.IdGrupoEncargos = Convert.ToInt32(cboGrupoEncargos.SelectedValue);
                    if (!String.IsNullOrEmpty(cboServicos.Text))
                        me.Servicos = Convert.ToInt32(cboServicos.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTransportadora.Text))
                        me.IdTransportadora = Convert.ToInt32(cboTransportadora.SelectedValue);

                    if (me.IdModoEntrega == 0)
                    {
                        dal.Insert(me);
                    }
                    else
                    {
                        dal.Update(me);
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
                    int id = me.IdModoEntrega;
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

