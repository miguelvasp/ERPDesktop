using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPerfilDepreciacaoCad : RibbonForm
    {
        public PerfilDepreciacaoDAL dal;
        PerfilDepreciacao pd = new PerfilDepreciacao();

        public frmPerfilDepreciacaoCad(PerfilDepreciacao pPD)
        {
            pd = pPD;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmPerfilDepreciacaoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarMetodoCalculoDepreciacao();
            CarregarFrequenciaDepreciacao();

            if (pd.IdPerfilDepreciacao == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmPerfilDepreciacaoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = pd.IdPerfilDepreciacao.ToString();
            txtDescricao.Text = pd.Descricao;
            if (pd.MetodoCalculo != null)
                cboMetodoCalculo.SelectedValue = pd.MetodoCalculo.ToString();
            if (pd.Frequencia != null)
                cboFrequencia.SelectedValue = pd.Frequencia.ToString();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarMetodoCalculoDepreciacao()
        {
            List<DropList> lista = Util.EnumERP.CarregarMetodoCalculoDepreciacao();

            cboMetodoCalculo.DisplayMember = "Text";
            cboMetodoCalculo.ValueMember = "Value";
            cboMetodoCalculo.DataSource = lista;
            cboMetodoCalculo.SelectedIndex = -1;
        }

        private void CarregarFrequenciaDepreciacao()
        {
            List<DropList> lista = Util.EnumERP.CarregarFrequenciaDepreciacao();

            cboFrequencia.DisplayMember = "Text";
            cboFrequencia.ValueMember = "Value";
            cboFrequencia.DataSource = lista;
            cboFrequencia.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            pd = new PerfilDepreciacao();
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

                    pd.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboMetodoCalculo.Text))
                        pd.MetodoCalculo = Convert.ToInt32(cboMetodoCalculo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboFrequencia.Text))
                        pd.Frequencia = Convert.ToInt32(cboFrequencia.SelectedValue);

                    if (pd.IdPerfilDepreciacao == 0)
                    {
                        dal.Insert(pd);
                    }
                    else
                    {
                        dal.Update(pd);
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
                    int id = pd.IdPerfilDepreciacao;
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
