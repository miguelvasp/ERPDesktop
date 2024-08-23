using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCondPgtoCad : RibbonForm
    {

        CondicaoPagamento cp = new CondicaoPagamento();
        public CondicaoPagamentoDAL dal = new CondicaoPagamentoDAL();
        PlanoPagamentoDAL ppdal = new PlanoPagamentoDAL();
        DiasPagamentoDAL dpdal = new DiasPagamentoDAL();
        CondicaoPagamentoIntervaloDAL idal = new CondicaoPagamentoIntervaloDAL();
        List<CondicaoPagamentoIntervalo> Parcelas = new List<CondicaoPagamentoIntervalo>();

        public frmCondPgtoCad(CondicaoPagamento pcp)
        {
            cp = pcp;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmCondPgtoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarMetodoPagamento();
            CarregaPlanoPagamento();
            CarregaDiasPagamento();

            if (cp.IdCondicaoPagamento == 0)
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

            lbCodigo.Text = cp.IdCondicaoPagamento.ToString();
            txtNome.Text = cp.Nome;
            txtDescricao.Text = cp.Descricao;
            cboMetodoPagamento.SelectedValue = cp.MetodoPagamento.ToString();
            txtMes.Text = cp.Mes.ToString();
            txtDias.Text = cp.Dias.ToString();
            if (cp.IdPlanoPagamento != null)
                cboPlanoPagamento.SelectedValue = cp.IdPlanoPagamento;
            if (cp.IdDiasPagamento != null)
                cboDiaPagamento.SelectedValue = cp.IdDiasPagamento;
            if (cp.DataCorte != null)
                txtDataCorte.Text = cp.DataCorte.Value.ToShortDateString();
            txtMesAdicional.Text = cp.MesAdicional.ToString();
            txtparcelas.Text = cp.QtdeParcelas.ToString();
            chkForaSemana.Checked = cp.ForaSemana;
            chkCondicaoVendas.Checked = Convert.ToBoolean(cp.CondicaoVendas);

            Parcelas.Clear();
            Parcelas = idal.GetByCondicaoPagamentoId(cp.IdCondicaoPagamento);

            //dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Rows.Clear();
            if (Parcelas != null)
            {
                var lista = Parcelas.Select(x => new { x.IdIntervalo, x.Dias, x.Percentual }).ToList();
                foreach (var it in lista)
                {
                    dataGridView1.Rows.Add(it.IdIntervalo, it.Dias, it.Percentual);
                }
            }

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cp = new CondicaoPagamento();
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

                    cp.IdCondicaoPagamento = Convert.ToInt32(lbCodigo.Text);
                    cp.Nome = txtNome.Text;
                    cp.Descricao = txtDescricao.Text;
                    cp.CondicaoVendas = chkCondicaoVendas.Checked;
                    if (!String.IsNullOrEmpty(cboMetodoPagamento.Text)) cp.MetodoPagamento = Convert.ToInt32(cboMetodoPagamento.SelectedValue);
                    if (!String.IsNullOrEmpty(txtMes.Text)) cp.Mes = Convert.ToInt32(txtMes.Text);
                    if (!String.IsNullOrEmpty(txtDias.Text)) cp.Dias = Convert.ToInt32(txtDias.Text);
                    if (!String.IsNullOrEmpty(cboPlanoPagamento.Text)) cp.IdPlanoPagamento = Convert.ToInt32(cboPlanoPagamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDiaPagamento.Text)) cp.IdDiasPagamento = Convert.ToInt32(cboDiaPagamento.SelectedValue);


                    if (!String.IsNullOrEmpty(txtDataCorte.Text.Replace("/", "").Trim())) cp.DataCorte = DateTime.Parse(txtDataCorte.Text);
                    if (!String.IsNullOrEmpty(txtMesAdicional.Text)) cp.MesAdicional = Convert.ToInt32(txtMesAdicional.Text);
                    if (!String.IsNullOrEmpty(txtparcelas.Text)) cp.QtdeParcelas = Convert.ToInt32(txtparcelas.Text);
                    cp.ForaSemana = chkForaSemana.Checked;


                    //verifica as parcelas
                    bool ParcelasOk = true;
                    decimal total = 0;
                    Parcelas.Clear();
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        try
                        {
                            CondicaoPagamentoIntervalo it = new CondicaoPagamentoIntervalo();
                            dataGridView1.EndEdit();

                            if (dataGridView1.Rows[i].Cells[1].Value != null && dataGridView1.Rows[i].Cells[2].Value != null)
                            {
                                string dias = dataGridView1.Rows[i].Cells[1].Value.ToString();
                                string Percentual = dataGridView1.Rows[i].Cells[2].Value.ToString();
                                if (dataGridView1.Rows[i].Cells[0].Value != null)
                                {
                                    it.IdIntervalo = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                                }
                                it.Dias = Convert.ToInt32(dias);
                                it.Percentual = Convert.ToDecimal(Percentual);
                                Parcelas.Add(it);
                                total += it.Percentual;
                            }
                        }
                        catch
                        {
                            ParcelasOk = false;
                        }
                    }

                    if (total != 100)
                    {
                        ParcelasOk = false;
                    }

                    if (Parcelas.Count != cp.QtdeParcelas)
                    {
                        ParcelasOk = false;
                    }

                    if (ParcelasOk)
                    {
                        if (cp.IdCondicaoPagamento == 0)
                        {
                            dal.Insert(cp);
                        }
                        else
                        {
                            dal.Update(cp);
                        }
                        dal.Save();

                        idal.ApagaIntervalos(cp.IdCondicaoPagamento);
                        foreach (CondicaoPagamentoIntervalo i in Parcelas)
                        {
                            i.IdCondicaoPagamento = cp.IdCondicaoPagamento;
                            idal.Insert(i);
                            idal.Save();
                        }
                        CarregaDados();
                        Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                    }
                    else
                    {
                        Util.Aplicacao.ShowMessage("Por favor verifique as parcelas.");
                    }
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
                    int id = cp.IdCondicaoPagamento;
                    idal.ApagaIntervalos(cp.IdCondicaoPagamento);
                    dal.Save();
                    dal.Delete(id);
                    dal.Save();
                    Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowMessage("Este registro não pode ser excluído." + "\n" + "\n" + "Erro: " + ex.Message);
                }
            }
        }

        private void frmCondPgtoCad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregarMetodoPagamento()
        {
            List<DropList> lista = Util.EnumERP.CarregarMetodoPagamento();

            cboMetodoPagamento.DisplayMember = "Text";
            cboMetodoPagamento.ValueMember = "Value";
            cboMetodoPagamento.DataSource = lista;
            cboMetodoPagamento.SelectedIndex = -1;
        }

        protected void CarregaPlanoPagamento()
        {
            cboPlanoPagamento.DataSource = new PlanoPagamentoDAL().GetCombo();
            cboPlanoPagamento.DisplayMember = "Text";
            cboPlanoPagamento.ValueMember = "iValue";
            cboPlanoPagamento.SelectedIndex = -1;
        }

        protected void CarregaDiasPagamento()
        {
            cboDiaPagamento.DataSource = new DiasPagamentoDAL().GetCombo();
            cboDiaPagamento.DisplayMember = "Text";
            cboDiaPagamento.ValueMember = "iValue";
            cboDiaPagamento.SelectedIndex = -1;
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }
    }
}
