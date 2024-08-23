using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPeriodoLiquidacaoImpostoCad : RibbonForm
    {
        public PeriodoLiquidacaoImpostoDAL dal;
        public PeriodoLiquidacaoImpostoVencDAL vDal = new PeriodoLiquidacaoImpostoVencDAL();
        PeriodoLiquidacaoImposto pli = new PeriodoLiquidacaoImposto();
        List<PeriodoLiquidacaoImpostoVenc> Vencimentos = new List<PeriodoLiquidacaoImpostoVenc>();

        public frmPeriodoLiquidacaoImpostoCad(PeriodoLiquidacaoImposto pPLI)
        {
            pli = pPLI;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmPeriodoLiquidacaoImpostoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarCondicaoPagamento();
            CarregarAutoridade();
            CarregarIntervaloDoPeriodo();

            if (pli.IdPeriodoLiquidacaoImposto == 0)
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

            lbCodigo.Text = pli.IdPeriodoLiquidacaoImposto.ToString();
            txtCodigo.Text = pli.Codigo;
            txtDescricao.Text = pli.Descricao;
            if (pli.IdCondicaoPagamento != null)
                cboCondicao.SelectedValue = pli.IdCondicaoPagamento;
            if (pli.IdAutoridade != null)
                cboAutoridade.SelectedValue = pli.IdAutoridade;
            if (pli.IntervaloPeriodo != null)
                cboIntervaloPeriodo.SelectedValue = pli.IntervaloPeriodo.ToString();

            txtNumeroUnidade.Text = pli.NumeroUnidade.ToString();
            CarregaVencimentos();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarAutoridade()
        {
            cboAutoridade.DataSource = new AutoridadeDAL().GetCombo();
            cboAutoridade.DisplayMember = "Text";
            cboAutoridade.ValueMember = "iValue";
            cboAutoridade.SelectedIndex = -1;
        }

        private void CarregarCondicaoPagamento()
        {
            cboCondicao.DataSource = new CondicaoPagamentoDAL().GetCombo();
            cboCondicao.DisplayMember = "Text";
            cboCondicao.ValueMember = "iValue";
            cboCondicao.SelectedIndex = -1;
        }

        private void CarregarIntervaloDoPeriodo()
        {
            List<DropList> lista = Util.EnumERP.CarregarIntervaloDoPeriodo();

            cboIntervaloPeriodo.DisplayMember = "Text";
            cboIntervaloPeriodo.ValueMember = "Value";
            cboIntervaloPeriodo.DataSource = lista;
            cboIntervaloPeriodo.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            pli = new PeriodoLiquidacaoImposto();
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

                    pli.Codigo = txtCodigo.Text;
                    pli.Descricao = txtDescricao.Text;
                    pli.IdCondicaoPagamento = Convert.ToInt32(cboCondicao.SelectedValue);
                    pli.IdAutoridade = Convert.ToInt32(cboAutoridade.SelectedValue);

                    if (!String.IsNullOrEmpty(cboIntervaloPeriodo.Text))
                        pli.IntervaloPeriodo = Convert.ToInt32(cboIntervaloPeriodo.SelectedValue);

                    pli.NumeroUnidade = Convert.ToInt32(txtNumeroUnidade.Text);

                    if (pli.IdPeriodoLiquidacaoImposto == 0)
                    {
                        dal.Insert(pli);
                    }
                    else
                    {
                        dal.Update(pli);
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
                    int id = pli.IdPeriodoLiquidacaoImposto;
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

        private void txtNumeroUnidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CarregaVencimentos()
        {
            Vencimentos = vDal.GetVencimentoByPeriodoId(pli.IdPeriodoLiquidacaoImposto);
            dgVencimentos.AutoGenerateColumns = false;
            dgVencimentos.DataSource = Vencimentos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pli.IdPeriodoLiquidacaoImposto == 0)
            {
                Util.Aplicacao.ShowMessage("É necessário salvar os dados do período antes de gerar vencimentos");
                return;
            }

            //calcula o dia
            DateTime dia = new DateTime();
            DateTime Ate = new DateTime();
            if (Vencimentos.Count == 0)
            {
                dia = DateTime.Now.AddDays(1);
            }
            else
            {
                dia = Convert.ToDateTime(Vencimentos.Max(x => x.Ate));
                dia = dia.AddDays(1);
            }

            int intervalo = Convert.ToInt32(cboIntervaloPeriodo.SelectedValue);
            int periodo = Convert.ToInt32(txtNumeroUnidade.Text);

            switch (intervalo)
            {
                case 1: Ate = dia.AddDays(periodo); break;
                case 2: Ate = dia.AddMonths(periodo); break;
                case 3: Ate = dia.AddYears(periodo); break;
            }

            PeriodoLiquidacaoImpostoVenc p = new PeriodoLiquidacaoImpostoVenc();
            p.IdPeriodoLiquidacaoImposto = pli.IdPeriodoLiquidacaoImposto;
            p.De = dia;
            p.Ate = Ate;
            vDal.Insert(p);
            vDal.Save();
            CarregaVencimentos();
        }

        private void dgVencimentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgVencimentos.Rows[dgVencimentos.SelectedRows[0].Index].Cells[0].Value);
            PeriodoLiquidacaoImpostoVenc p = vDal.GetByID(id);
            frmPeriodoLiquidacaoImpostoVencCad f = new frmPeriodoLiquidacaoImpostoVencCad(p);
            f.dal = vDal;
            f.ShowDialog();
            CarregaVencimentos();
        }
    }
}
