using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmTotalDimensoes : Form
    {
        ValoresCentroCustoDAL dal = new ValoresCentroCustoDAL();
        TotalDimensoesDAL tdDAL = new TotalDimensoesDAL();
        TotalDimensoes td = new TotalDimensoes();

        int IdValoresCentroCusto = 0;

        public frmTotalDimensoes(ValoresCentroCustoDAL pDal, TotalDimensoes pTD)
        {
            td = pTD;
            InitializeComponent();
        }

        private void frmTotalDimensoes_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregaDimensaoDe();
            CarregaDimensaoAte();

            if (td.IdTotalDimensoes != 0)
            {
                CarregaDados();
            }

            cboDimensaoDe.Focus();

            Cursor.Current = Cursors.Default;
        }

        private void frmTotalDimensoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        protected void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (td.IdCentroCustoDe != null)
                cboDimensaoDe.SelectedValue = td.IdCentroCustoDe;
            if (td.IdCentroCustoAte != null)
                cboDimensaoAte.SelectedValue = td.IdCentroCustoAte;

            Cursor.Current = Cursors.Default;
        }

        protected void CarregaDimensaoDe()
        {
            cboDimensaoDe.DataSource = new CentroCustoDAL().GetCombo();
            cboDimensaoDe.DisplayMember = "Text";
            cboDimensaoDe.ValueMember = "iValue";
            cboDimensaoDe.SelectedIndex = -1;
        }

        protected void CarregaDimensaoAte()
        {
            cboDimensaoAte.DataSource = new CentroCustoDAL().GetCombo();
            cboDimensaoAte.DisplayMember = "Text";
            cboDimensaoAte.ValueMember = "iValue";
            cboDimensaoAte.SelectedIndex = -1;
        }

        private void LimpaControles()
        {
            cboDimensaoDe.SelectedIndex = -1;
            cboDimensaoAte.SelectedIndex = -1;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    if (!String.IsNullOrEmpty(cboDimensaoDe.Text))
                        td.IdCentroCustoDe = Convert.ToInt32(cboDimensaoDe.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDimensaoAte.Text))
                        td.IdCentroCustoAte = Convert.ToInt32(cboDimensaoAte.SelectedValue);

                    if (td.IdTotalDimensoes == 0)
                    {
                        tdDAL.Insert(td);
                    }
                    else
                    {
                        tdDAL.Update(td);
                    }

                    tdDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }

                btnIncluir.Focus();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Por favor verifique as informações faltantes.");
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            LimpaControles();
            td = new TotalDimensoes();
            td.IdTotalDimensoes = 0;
            td.IdValoresCentroCusto = IdValoresCentroCusto;
            cboDimensaoDe.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (td.IdTotalDimensoes != 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == DialogResult.Yes)
                {
                    try
                    {
                        tdDAL.Delete(td.IdTotalDimensoes);
                        tdDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
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
}
