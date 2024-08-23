using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCodigoImpostoRetidoCad : RibbonForm
    {
        public CodigoImpostoRetidoDAL dal;
        CodigoImpostoRetido cir = new CodigoImpostoRetido();
        ValoresImpostoRetidoDAL vDal = new ValoresImpostoRetidoDAL();
        LimiteImpostoRetidoDAL lDal = new LimiteImpostoRetidoDAL();

        public frmCodigoImpostoRetidoCad(CodigoImpostoRetido pCIR)
        {
            cir = pCIR;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmCodigoImpostoRetidoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarTipoImposto();
            CarregarPercentualValor();
            CarregarMoeda();
            CarregarPeriodoLiquidacaoImposto();
            CarregarContaContabil();
            CarregarContaContabilRetidoAReceber();
            CarregarContaContabilLiquidacao();
            CarregarBase();
            CarregarFormaDeArredondamento();
            CarregarMetodoCalculo();
            CarregaValores();

            if (cir.IdCodigoImpostoRetido == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmCodigoImpostoRetidoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = cir.IdCodigoImpostoRetido.ToString();
            txtCodigo.Text = cir.Codigo;
            txtDescricao.Text = cir.Descricao;
            if (cir.TipoImposto != null)
                cboTipoImposto.SelectedValue = cir.TipoImposto;
            //if (cir.IdPercentualValor != null)
            //    cboPercentualValor.SelectedValue = cir.IdPercentualValor;

            txtPercentualValor.Text = cir.PercentualValor.ToString();

            if (cir.IdMoeda != null)
                cboMoeda.SelectedValue = cir.IdMoeda;
            if (cir.IdPeriodoLiquidacaoImposto != null)
                cboPeriodoLiquidacao.SelectedValue = cir.IdPeriodoLiquidacaoImposto;
            txtCodigoReceita.Text = cir.CodigoReceita;
            if (cir.IdContaContabil != null)
                cboContaContabil.SelectedValue = cir.IdContaContabil;
            if (cir.IdContaContabilRetidoAReceber != null)
                cboRetidoAReceber.SelectedValue = cir.IdContaContabilRetidoAReceber;
            if (cir.IdContaContabilLiquidacao != null)
                cboLiquidacao.SelectedValue = cir.IdContaContabilLiquidacao;
            if (cir.Base != null)
                cboBase.SelectedValue = cir.Base.ToString();
            chkDeduzirINSS.Checked = cir.DeduzirINSS;
            if (cir.Arredondamento != null)
                txtArredondamento.Text = cir.Arredondamento.Value.ToString("N4");
            if (cir.FormaArredondamento != null)
                cboFormaArredondamento.SelectedValue = cir.FormaArredondamento.ToString();
            if (cir.MetodoCalculo != null)
                cboMetodoCalculo.SelectedValue = cir.MetodoCalculo.ToString();
            CarregaLimites();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarBase()
        {
            List<DropList> lista = Util.EnumERP.CarregarBasePercentual();

            cboBase.DisplayMember = "Text";
            cboBase.ValueMember = "Value";
            cboBase.DataSource = lista;
            cboBase.SelectedIndex = -1;
        }

        private void CarregarContaContabil()
        {
            cboContaContabil.DataSource = new ContaContabilDAL().GetCombo();
            cboContaContabil.DisplayMember = "Text";
            cboContaContabil.ValueMember = "iValue";
            cboContaContabil.SelectedIndex = -1;
        }

        private void CarregarContaContabilRetidoAReceber()
        {
            cboRetidoAReceber.DataSource = new ContaContabilDAL().GetCombo();
            cboRetidoAReceber.DisplayMember = "Text";
            cboRetidoAReceber.ValueMember = "iValue";
            cboRetidoAReceber.SelectedIndex = -1;
        }

        private void CarregarContaContabilLiquidacao()
        {
            cboLiquidacao.DataSource = new ContaContabilDAL().GetCombo();
            cboLiquidacao.DisplayMember = "Text";
            cboLiquidacao.ValueMember = "iValue";
            cboLiquidacao.SelectedIndex = -1;
        }

        private void CarregarFormaDeArredondamento()
        {
            List<DropList> lista = Util.EnumERP.CarregarFormaDeArredondamento();

            cboFormaArredondamento.DisplayMember = "Text";
            cboFormaArredondamento.ValueMember = "Value";
            cboFormaArredondamento.DataSource = lista;
            cboFormaArredondamento.SelectedIndex = -1;
        }

        private void CarregarMetodoCalculo()
        {
            List<DropList> lista = Util.EnumERP.CarregarMetodoCalculo();

            cboMetodoCalculo.DisplayMember = "Text";
            cboMetodoCalculo.ValueMember = "Value";
            cboMetodoCalculo.DataSource = lista;
            cboMetodoCalculo.SelectedIndex = -1;
        }

        private void CarregarMoeda()
        {
            cboMoeda.DataSource = new MoedaDAL().GetCombo();
            cboMoeda.DisplayMember = "Text";
            cboMoeda.ValueMember = "iValue";
            cboMoeda.SelectedIndex = -1;
        }

        private void CarregarPercentualValor()
        {
            //cboPercentualValor.DataSource = new JuridicaoImpostoDAL().GetCombo();
            //cboPercentualValor.DisplayMember = "Text";
            //cboPercentualValor.ValueMember = "iValue";
            //cboPercentualValor.SelectedIndex = -1;
        }

        private void CarregarPeriodoLiquidacaoImposto()
        {
            cboPeriodoLiquidacao.DataSource = new PeriodoLiquidacaoImpostoDAL().GetCombo();
            cboPeriodoLiquidacao.DisplayMember = "Text";
            cboPeriodoLiquidacao.ValueMember = "iValue";
            cboPeriodoLiquidacao.SelectedIndex = -1;
        }

        private void CarregarTipoImposto()
        {
            List<DropList> lista = Util.EnumERP.CarregarTipoImposto();

            cboTipoImposto.DisplayMember = "Text";
            cboTipoImposto.ValueMember = "Value";
            cboTipoImposto.DataSource = lista;
            cboTipoImposto.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cir = new CodigoImpostoRetido();
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

                    cir.Codigo = txtCodigo.Text;
                    cir.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboTipoImposto.Text))
                        cir.TipoImposto = Convert.ToInt32(cboTipoImposto.SelectedValue);


                    //if (!String.IsNullOrEmpty(cboPercentualValor.Text))
                    //    cir.IdPercentualValor = Convert.ToInt32(cboPercentualValor.SelectedValue);

                    if (!String.IsNullOrEmpty(txtPercentualValor.Text))
                    {
                        cir.PercentualValor = Convert.ToDecimal(txtPercentualValor.Text);
                    }

                    if (!String.IsNullOrEmpty(cboMoeda.Text))
                        cir.IdMoeda = Convert.ToInt32(cboMoeda.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPeriodoLiquidacao.Text))
                        cir.IdPeriodoLiquidacaoImposto = Convert.ToInt32(cboPeriodoLiquidacao.SelectedValue);
                    cir.CodigoReceita = txtCodigoReceita.Text;

                    if (!String.IsNullOrEmpty(cboContaContabil.Text))
                        cir.IdContaContabil = Convert.ToInt32(cboContaContabil.SelectedValue);
                    if (!String.IsNullOrEmpty(cboRetidoAReceber.Text))
                        cir.IdContaContabilRetidoAReceber = Convert.ToInt32(cboRetidoAReceber.SelectedValue);
                    if (!String.IsNullOrEmpty(cboLiquidacao.Text))
                        cir.IdContaContabilLiquidacao = Convert.ToInt32(cboLiquidacao.SelectedValue);

                    if (!String.IsNullOrEmpty(cboBase.Text))
                        cir.Base = Convert.ToInt32(cboBase.SelectedValue);
                    cir.DeduzirINSS = chkDeduzirINSS.Checked;
                    cir.Arredondamento = Convert.ToDecimal(txtArredondamento.Text);
                    if (!String.IsNullOrEmpty(cboFormaArredondamento.Text))
                        cir.FormaArredondamento = Convert.ToInt32(cboFormaArredondamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboMetodoCalculo.Text))
                        cir.MetodoCalculo = Convert.ToInt32(cboMetodoCalculo.SelectedValue);

                    if (cir.IdCodigoImpostoRetido == 0)
                    {
                        dal.Insert(cir);
                    }
                    else
                    {
                        dal.Update(cir);
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
                    int id = cir.IdCodigoImpostoRetido;
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

        private void txtCodigoReceita_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtArredondamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtArredondamento.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void btnAddValores_Click(object sender, EventArgs e)
        {
            if (cir.IdCodigoImpostoRetido == 0)
            {
                Util.Aplicacao.ShowMessage("É necessário salvar os dados do código de imposto antes de adicionar valores.");
                return;
            }

            ValoresImpostoRetido v = new ValoresImpostoRetido();
            v.IdCodigoImpostoRetido = cir.IdCodigoImpostoRetido;
            frmValoresImpostoRetidoCad frm = new frmValoresImpostoRetidoCad(v);
            frm.dal = vDal;
            frm.ShowDialog();
            CarregaValores();
        }

        private void CarregaValores()
        {
            var lista = vDal.GetByCodigoImposto(cir.IdCodigoImpostoRetido);
            dgValores.DataSource = lista;
            dgValores.AutoGenerateColumns = false;
        }

        private void btnAddLimite_Click(object sender, EventArgs e)
        {
            LimiteImpostoRetido lr = new LimiteImpostoRetido();
            lr.IdCodigoImpostoretido = cir.IdCodigoImpostoRetido;
            frmLimiteImpostoRetidoCad f = new frmLimiteImpostoRetidoCad(lr);
            f.dal = lDal;
            f.ShowDialog();
            CarregaLimites();
        }

        private void CarregaLimites()
        {
            var lista = lDal.GetByCodigoImpostoRetido(cir.IdCodigoImpostoRetido);
            dgLimite.AutoGenerateColumns = false;
            dgLimite.DataSource = lista;
        }

        private void dgLimite_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgLimite.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dgLimite.Rows[dgLimite.SelectedRows[0].Index].Cells[0].Value);
                LimiteImpostoRetido lr = lDal.GetByID(id);
                frmLimiteImpostoRetidoCad f = new frmLimiteImpostoRetidoCad(lr);
                f.dal = lDal;
                f.ShowDialog();
                CarregaLimites();
            }
        }

        private void dgValores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgValores.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dgValores.Rows[dgValores.SelectedRows[0].Index].Cells["id"].Value);
                ValoresImpostoRetido v = vDal.GetByID(id);
                v.IdCodigoImpostoRetido = cir.IdCodigoImpostoRetido;
                frmValoresImpostoRetidoCad frm = new frmValoresImpostoRetidoCad(v);
                frm.dal = vDal;
                frm.ShowDialog();
                CarregaValores();
            }
        }
    }
}
