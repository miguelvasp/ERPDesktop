using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmUnidadeFederacaoNCMCad : RibbonForm
    {
        public UnidadeFederacaoNCMDAL dal;
        UnidadeFederacaoNCM uf = new UnidadeFederacaoNCM();
        UnidadeFederacaoDAL udal = new UnidadeFederacaoDAL(new DB_ERPContext());

        public frmUnidadeFederacaoNCMCad(UnidadeFederacaoNCM pUF)
        {
            uf = pUF;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmUnidadeFederacaoNCMCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregaUF();
            CarregaNCM();

            if (uf.IdUFNCM == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmUnidadeFederacaoNCMCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = uf.IdUFNCM.ToString();
            cboUF.SelectedValue = uf.IdUF;
            if (uf.IdNCM != null)
                cboNCM.SelectedValue = uf.IdNCM;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        protected void CarregaNCM()
        {
            cboNCM.DataSource = new ClassificacaoFiscalDAL().GetCombo();
            cboNCM.DisplayMember = "Text";
            cboNCM.ValueMember = "iValue";
            cboNCM.SelectedIndex = -1;
        }

        private void CarregaUF()
        {
            var UFs = udal.Get().OrderBy(x => x.UF).ToList();
            cboUF.DataSource = UFs;
            cboUF.ValueMember = "IdUF";
            cboUF.DisplayMember = "UF";
            cboUF.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            uf = new UnidadeFederacaoNCM();
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

                    uf.IdUF = Convert.ToInt32(cboUF.SelectedValue);
                    if (!String.IsNullOrEmpty(cboNCM.Text))
                        uf.IdNCM = Convert.ToInt32(cboNCM.SelectedValue);

                    if (uf.IdUFNCM == 0)
                    {
                        dal.Insert(uf);
                    }
                    else
                    {
                        dal.Update(uf);
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
                    int id = uf.IdUFNCM;
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