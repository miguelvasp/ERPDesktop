using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmRoteiroOperacao : RibbonForm
    {
        public RoteiroOperacaoDAL dal = new RoteiroOperacaoDAL();
        RoteiroOperacaoLinhasDAL ldal = new RoteiroOperacaoLinhasDAL();
        RoteiroOperacaoRecursosDAL rdal = new RoteiroOperacaoRecursosDAL();

        RoteiroOperacao c = new RoteiroOperacao();

        public frmRoteiroOperacao(RoteiroOperacao pC)
        {
            c = pC;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmAutoridadeCad_Load(object sender, EventArgs e)
        {

            CarregaCombos();
            if (c.IdRoteiroOperacao == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void CarregaCombos()
        {
            List<ComboItem> tarefas = new List<ComboItem>();
            tarefas.Add(new ComboItem() {iValue = 1, Text = "Todos"});
            tarefas.Add(new ComboItem() {iValue = 2, Text = "Preço hora; Taxa Trabalho"});
            cboTaxaTarefa.DataSource = tarefas;
            cboTaxaTarefa.DisplayMember = "Text";
            cboTaxaTarefa.ValueMember = "iValue";
            cboTaxaTarefa.SelectedIndex = -1;

            List<ComboItem> tipo = new List<ComboItem>();
            tipo.Add(new ComboItem() { iValue = 1, Text = "Rigido" });
            tipo.Add(new ComboItem() { iValue = 2, Text = "Flexivel" });
            cboTipoVinculo.DataSource = tipo;
            cboTipoVinculo.DisplayMember = "Text";
            cboTipoVinculo.ValueMember = "iValue";
            cboTipoVinculo.SelectedIndex = -1;
        }

        private void frmAutoridadeCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            txtAtividade.Text = c.Atividade;
            txtPrioridade.Text = c.Prioridade == null ? "" : c.Prioridade.ToString();
            txtSequencia.Text = c.Sequencia == null ? "" : c.Sequencia.ToString();
            txtAcumulado.Text = c.Acumulado == null ? "" : c.Acumulado.ToString();
            txtPorcentagemSucata.Text = c.PorcentagemSucata == null ? "" : c.PorcentagemSucata.ToString();
            txtProximo.Text = c.Proximo == null ? "" : c.Proximo.ToString();
            cboTaxaTarefa.SelectedValue = c.TaxaHoraTrabalhoTarefa == null ? 0 : c.TaxaHoraTrabalhoTarefa;
            cboTipoVinculo.SelectedValue = c.TipoVinculo == null ? 0 : c.TipoVinculo;
            CarregaGridLinhas();
            CarregaGridRecursos();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void CarregaGridRecursos()
        {
            //throw new NotImplementedException();
        }

        

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            int id = c.IdRoteiro;
            c = new RoteiroOperacao();
            c.IdRoteiro = id;
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
                    c.Prioridade = null;
                    c.Sequencia = null;
                    c.Acumulado = null;
                    c.PorcentagemSucata = null;
                    c.Proximo = null;
                    c.TaxaHoraTrabalhoTarefa = null;
                    c.TipoVinculo = null;

                    c.Atividade = txtAtividade.Text;
                    if (!String.IsNullOrEmpty(txtPrioridade.Text)) c.Prioridade = Convert.ToInt32(txtPrioridade.Text);
                    if (!String.IsNullOrEmpty(txtSequencia.Text)) c.Sequencia = Convert.ToInt32(txtSequencia.Text);
                    if (!String.IsNullOrEmpty(txtAcumulado.Text)) c.Acumulado = Convert.ToDecimal(txtAcumulado.Text);
                    if (!String.IsNullOrEmpty(txtPorcentagemSucata.Text)) c.PorcentagemSucata = Convert.ToInt32(txtPorcentagemSucata.Text);
                    if (!String.IsNullOrEmpty(txtProximo.Text)) c.Proximo = Convert.ToInt32(txtProximo.Text);
                    if (!String.IsNullOrEmpty(cboTaxaTarefa.Text)) c.TaxaHoraTrabalhoTarefa = Convert.ToInt32(cboTaxaTarefa.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoVinculo.Text)) c.TipoVinculo = Convert.ToInt32(cboTipoVinculo.SelectedValue);

                    if (c.IdRoteiroOperacao == 0)
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
                int id = c.IdRoteiroOperacao;
                dal.Delete(id); 
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                this.Close();
            }
        }

        private void btnAddLinhas_Click(object sender, EventArgs e)
        {
            if(c.IdRoteiroOperacao == 0)
            {
                Util.Aplicacao.ShowMessage("Antes de salvar os dados grave as informações do Roteiro de operação.");
                return;
            }
            RoteiroOperacaoLinhas rl = new RoteiroOperacaoLinhas();
            rl.IdRoteiroOperacao = c.IdRoteiroOperacao;
            frmRoteiroOperacaoLinhas frm = new frmRoteiroOperacaoLinhas(rl);
            frm.dal = ldal;
            frm.ShowDialog();
            CarregaGridLinhas();
        }

        private void CarregaGridLinhas()
        {
            var lista = ldal.GetByOperacaoLinhasId(c.IdRoteiroOperacao);
            dgLinhas.AutoGenerateColumns = false;
            dgLinhas.DataSource = lista;
        }

        private void dgLinhas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgLinhas.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dgLinhas.Rows[dgLinhas.SelectedRows[0].Index].Cells[0].Value);
                RoteiroOperacaoLinhas rl = ldal.GetByID(id);
                rl.IdRoteiroOperacao = c.IdRoteiroOperacao;
                frmRoteiroOperacaoLinhas frm = new frmRoteiroOperacaoLinhas(rl);
                frm.dal = ldal;
                frm.ShowDialog();
                CarregaGridLinhas();
            }
            
        }
    }
}

