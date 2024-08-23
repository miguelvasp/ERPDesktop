using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmMatrizCFOPCad : RibbonForm
    {
        public MatrizCFOPDAL dal;
        MatrizCFOP mCFOP = new MatrizCFOP();

        public frmMatrizCFOPCad(MatrizCFOP pMCFOP)
        {
            mCFOP = pMCFOP;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmMatrizCFOPCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarCFOP();
            CarregarGrupoCFOP();
            CarregarOperacao();
            CarregarTipodeTransacao();

            if (mCFOP.IdMatrizCFOP == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmMatrizCFOPCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = mCFOP.IdMatrizCFOP.ToString();
            txtDescricao.Text = mCFOP.Descricao;
            if (mCFOP.IdCFOP != null)
                cboCFOP.SelectedValue = mCFOP.IdCFOP;
            if (mCFOP.IdGrupoCFOP != null)
                cboGrupoCFOP.SelectedValue = mCFOP.IdGrupoCFOP;
            if (mCFOP.IdOperacao != null)
                cboOperacao.SelectedValue = mCFOP.IdOperacao;
            cboTipoTransacao.SelectedValue = mCFOP.TipoTransacao.ToString();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        protected void CarregarCFOP()
        {
            cboCFOP.DataSource = new CFOPDAL().GetCombo();
            cboCFOP.DisplayMember = "Text";
            cboCFOP.ValueMember = "iValue";
            cboCFOP.SelectedIndex = -1;
        }

        protected void CarregarGrupoCFOP()
        {
            cboGrupoCFOP.DataSource = new GrupoCFOPDAL().GetCombo();
            cboGrupoCFOP.DisplayMember = "Text";
            cboGrupoCFOP.ValueMember = "iValue";
            cboGrupoCFOP.SelectedIndex = -1;
        }

        protected void CarregarOperacao()
        {
            cboOperacao.DataSource = new OperacaoDAL().GetCombo();
            cboOperacao.DisplayMember = "Text";
            cboOperacao.ValueMember = "iValue";
            cboOperacao.SelectedIndex = -1;
        }

        private void CarregarTipodeTransacao()
        {
            List<DropList> lista = Util.EnumERP.CarregarTipodeTransacao();

            cboTipoTransacao.DisplayMember = "Text";
            cboTipoTransacao.ValueMember = "Value";
            cboTipoTransacao.DataSource = lista;
            cboTipoTransacao.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            mCFOP = new MatrizCFOP();
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

                    mCFOP.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboCFOP.Text))
                        mCFOP.IdCFOP = Convert.ToInt32(cboCFOP.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoCFOP.Text))
                        mCFOP.IdGrupoCFOP = Convert.ToInt32(cboGrupoCFOP.SelectedValue);
                    if (!String.IsNullOrEmpty(cboOperacao.Text))
                        mCFOP.IdOperacao = Convert.ToInt32(cboOperacao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoTransacao.Text))
                        mCFOP.TipoTransacao = Convert.ToInt32(cboTipoTransacao.SelectedValue);

                    if (mCFOP.IdMatrizCFOP == 0)
                    {
                        dal.Insert(mCFOP);
                    }
                    else
                    {
                        dal.Update(mCFOP);
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
                    int id = mCFOP.IdMatrizCFOP;
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