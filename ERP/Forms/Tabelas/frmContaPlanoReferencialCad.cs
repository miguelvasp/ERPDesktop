using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmContaPlanoReferencialCad : RibbonForm
    {
        public ContaPlanoReferencialDAL dal = new ContaPlanoReferencialDAL();
        ContaPlanoReferencial c = new ContaPlanoReferencial();

        public frmContaPlanoReferencialCad(ContaPlanoReferencial pc)
        {
            c = pc;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmCorredorCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregaCombos();

            if (c.IdContaPlanoReferencial == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            txtCodigo.Text = c.Codigo;
            txtDescricao.Text = c.Descricao;
            txtDataInicial.Text = c.DataIni == null ? "" : c.DataIni.ToString();
            txtDataFim.Text = c.DataFim == null ? "" : c.DataFim.ToString();
            txtOrdem.Text = c.Ordem == null ? "" : c.Ordem.ToString();
            cboTipo.SelectedValue = c.Tipo == null ? 0 : c.Tipo;
            cboContaPai.SelectedValue = c.IdContaPai == null ? 0 : c.IdContaPai;
            txtNivel.Text = c.Nivel == null ? "" : c.Nivel.ToString();
            txtNatureza.Text = c.Natureza == null ? "" : c.Natureza.ToString();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregaCombos()
        {
            List<ComboItem> lista = new List<ComboItem>();
            lista.Add(new ComboItem() { iValue = 1, Text = "A" });
            lista.Add(new ComboItem() { iValue = 2, Text = "S" });
            cboTipo.DataSource = lista;
            cboTipo.ValueMember = "iValue";
            cboTipo.DisplayMember = "Text";
            cboTipo.SelectedIndex = -1;


            cboContaPai.DataSource = dal.GetCombo();
            cboContaPai.ValueMember = "iValue";
            cboContaPai.DisplayMember = "Text";
            cboContaPai.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            c = new ContaPlanoReferencial();
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

                    c.Ordem = null;
                    c.Tipo = null;
                    c.IdContaPai = null;
                    c.Nivel = null;
                    c.Natureza = null;

                    c.Codigo = txtCodigo.Text;
                    c.Descricao = txtDescricao.Text;
                    c.DataIni = Util.Validacao.IsDateTime(txtDataInicial.Text);
                    c.DataFim = Util.Validacao.IsDateTime(txtDataFim.Text);
                    if (!String.IsNullOrEmpty(txtOrdem.Text)) c.Ordem = Convert.ToInt32(txtOrdem.Text);
                    if (!String.IsNullOrEmpty(cboTipo.Text)) c.Tipo = Convert.ToInt32(cboTipo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContaPai.Text)) c.IdContaPai = Convert.ToInt32(cboContaPai.SelectedValue);
                    if (!String.IsNullOrEmpty(txtNivel.Text)) c.Nivel = Convert.ToInt32(txtNivel.Text);
                    if (!String.IsNullOrEmpty(txtNatureza.Text)) c.Natureza = Convert.ToInt32(txtNatureza.Text);


                    if (c.IdContaPlanoReferencial == 0)
                    {
                        dal.Insert(c);
                    }
                    else
                    {
                        dal.Update(c);
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
                    int id = c.IdContaPlanoReferencial;
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