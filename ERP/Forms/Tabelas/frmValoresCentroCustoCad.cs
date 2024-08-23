using ERP.DAL;
using ERP.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmValoresCentroCustoCad : RibbonForm
    {
        public ValoresCentroCustoDAL dal;
        TotalDimensoesDAL tdDal = new TotalDimensoesDAL();
        ValoresCentroCusto vcc = new ValoresCentroCusto();

        public frmValoresCentroCustoCad(ValoresCentroCusto pVCC)
        {
            vcc = pVCC;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmValoresCentroCustoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            LimparCamposDatas();

            if (vcc.IdValoresCentroCusto == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                MostrarDimensaoTotalizadora();
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmValoresCentroCustoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = vcc.IdValoresCentroCusto.ToString();
            txtNome.Text = vcc.Nome;
            txtDescricao.Text = vcc.Descricao;

            if (vcc.DataInicio != null && vcc.DataInicio != DateTime.MinValue)
                dtpDataInicial.Value = vcc.DataInicio;

            if (vcc.DataFinal != null && vcc.DataFinal != DateTime.MinValue)
                dtpDataFinal.Value = vcc.DataFinal;

            chkDimensaoTotalizadora.Checked = vcc.DimensaoTotalizadora;

            CarregaGridTotalDimensao();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            MostrarDimensaoTotalizadora();

            Cursor.Current = Cursors.Default;
        }

        private void HabilitarCamposTotalDimensoes(bool value)
        {
            btnAddTotalDimensoes.Enabled = value;
            dgvTotalDimensoes.Enabled = value;
        }

        private void LimparCamposDatas()
        {
            dtpDataInicial.Checked = true;
            dtpDataInicial.CustomFormat = " ";
            dtpDataInicial.Format = DateTimePickerFormat.Custom;

            dtpDataFinal.Checked = true;
            dtpDataFinal.CustomFormat = " ";
            dtpDataFinal.Format = DateTimePickerFormat.Custom;
        }

        private void MostrarDimensaoTotalizadora()
        {
            if (vcc.IdValoresCentroCusto != 0)
            {
                if (chkDimensaoTotalizadora.Checked)
                {
                    HabilitarCamposTotalDimensoes(chkDimensaoTotalizadora.Enabled);
                }
                else
                {
                    HabilitarCamposTotalDimensoes(false);
                }
            }
            else
            {
                HabilitarCamposTotalDimensoes(false);
            }
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            vcc = new ValoresCentroCusto();
            lbCodigo.Text = "0";
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            MostrarDimensaoTotalizadora();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            MostrarDimensaoTotalizadora();
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    vcc.Nome = txtNome.Text;
                    vcc.Descricao = txtDescricao.Text;

                    vcc.DataInicio = DateTime.Parse(dtpDataInicial.Value.ToString("dd/MM/yyyy"));
                    vcc.DataFinal = DateTime.Parse(dtpDataFinal.Value.ToString("dd/MM/yyyy"));

                    vcc.DimensaoTotalizadora = chkDimensaoTotalizadora.Checked;

                    if (vcc.IdValoresCentroCusto == 0)
                    {
                        dal.Insert(vcc);
                    }
                    else
                    {
                        dal.Update(vcc);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                    MostrarDimensaoTotalizadora();
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
                MostrarDimensaoTotalizadora();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    int id = vcc.IdValoresCentroCusto;
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

        private void dtpDataInicial_ValueChanged(object sender, EventArgs e)
        {
            if (!dtpDataInicial.Checked)
            {
                dtpDataInicial.CustomFormat = " ";
                dtpDataInicial.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtpDataInicial.CustomFormat = null;
                dtpDataInicial.Format = DateTimePickerFormat.Short;
            }
        }

        private void dtpDataFinal_ValueChanged(object sender, EventArgs e)
        {
            if (!dtpDataFinal.Checked)
            {
                dtpDataFinal.CustomFormat = " ";
                dtpDataFinal.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtpDataFinal.CustomFormat = null;
                dtpDataFinal.Format = DateTimePickerFormat.Short;
            }
        }

        private void chkDimensaoTotalizadora_CheckedChanged(object sender, EventArgs e)
        {
            MostrarDimensaoTotalizadora();
        }

        #region TotalDimensoes
        private void CarregaGridTotalDimensao()
        {
            var lista = tdDal.getItensTotalDimensao(vcc.IdValoresCentroCusto).ToList();
            dgvTotalDimensoes.DataSource = lista;
            dgvTotalDimensoes.AutoGenerateColumns = false;
            dgvTotalDimensoes.RowHeadersVisible = false;
        }

        private void dgvTotalDimensoes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvTotalDimensoes.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dgvTotalDimensoes.Rows[e.RowIndex].Cells[0].Value.ToString());
                    TotalDimensoes td = tdDal.GetByID(id);
                    frmTotalDimensoes cad = new frmTotalDimensoes(dal, td);
                    cad.ShowDialog();
                    CarregaGridTotalDimensao();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void btnAddTotalDimensoes_Click(object sender, EventArgs e)
        {
            TotalDimensoes td = new TotalDimensoes();
            td.IdValoresCentroCusto = vcc.IdValoresCentroCusto;
            frmTotalDimensoes addItem = new frmTotalDimensoes(dal, td);
            addItem.ShowDialog();
            CarregaGridTotalDimensao();
        }
        #endregion
    }
}