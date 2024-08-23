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
    public partial class frmDiarioBomCad : RibbonForm
    {
        public DiarioBOMDAL dal = new DiarioBOMDAL();
        DiarioBomLinhaDAL idal = new DiarioBomLinhaDAL();
        DiarioBOM c = new DiarioBOM();

        public frmDiarioBomCad(DiarioBOM pC)
        {
            c = pC;
            c.TipoDiario = 1; //Lista de separação.
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmAutoridadeCad_Load(object sender, EventArgs e)
        {
            cboNomeDiario.DataSource = new CadastroDiarioProducaoDAL().GetCombo();
            cboNomeDiario.DisplayMember = "Text";
            cboNomeDiario.ValueMember = "Text";
            cboNomeDiario.SelectedIndex = -1;

            //cboOrdemProducao.DataSource = new OrdemProducaoDAL().GetOPDiarioBom();
            cboOrdemProducao.DisplayMember = "iValue";
            cboOrdemProducao.ValueMember = "iValue";
            cboOrdemProducao.SelectedIndex = -1;

            if (c.IdDiarioBom == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
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
            cboNomeDiario.SelectedValue = c.NomeDiario;
            cboOrdemProducao.SelectedValue = c.IdOrdemProducao == null ? 0 : c.IdOrdemProducao;
            chkAceitarErro.Checked = c.AceitaErro;
            chkAguardandoCriacao.Checked = c.AguardandoCriacao;
            chkConsumoAutomaricoBOM.Checked = c.ConsumoAutomaticoBOM;
            txtDataLancamento.Text = c.DataLancamento == null ? "" : c.DataLancamento.ToString();
            txtSequenciaComprovante.Text = c.IdSequenciaComprovante == null ? "" : c.IdSequenciaComprovante.ToString();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void CarregaGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            var lista = idal.getLinhas(c.IdDiarioBom).Select(x => new { x.IdDiarioBomLinha, x.Data, x.NumeroItem, x.NumeroLinha, x.QtdeConsumo }).ToList();
            dataGridView1.DataSource = lista;
        }


        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            c = new DiarioBOM();
            c.TipoDiario = 1; //Lista de separação. 
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
                    c.IdOrdemProducao = null;
                    c.DataLancamento = null;
                    c.IdSequenciaComprovante = null;
                    c.NomeDiario = cboNomeDiario.SelectedValue.ToString();
                    if (!String.IsNullOrEmpty(cboOrdemProducao.Text)) c.IdOrdemProducao = Convert.ToInt32(cboOrdemProducao.SelectedValue);
                    if (!String.IsNullOrEmpty(txtSequenciaComprovante.Text)) c.IdSequenciaComprovante = Convert.ToInt32(txtSequenciaComprovante.Text);
                    c.DataLancamento = Util.Validacao.IsDateTime(txtDataLancamento.Text);
                    c.AceitaErro = chkAceitarErro.Checked;
                    c.AguardandoCriacao = chkAguardandoCriacao.Checked;
                    c.ConsumoAutomaticoBOM = chkConsumoAutomaricoBOM.Checked;


                    if (c.IdDiarioBom == 0)
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
                int id = c.IdDiarioBom;
                dal.Delete(id); 
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            DiarioBomLinha dl = new DiarioBomLinha();   
            dl.IdDiarioBom = c.IdDiarioBom;
            frmDiarioBomLinhaCad cad = new frmDiarioBomLinhaCad(dl);
            cad.ShowDialog();
            CarregaGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value);
            DiarioBomLinha dl = idal.GetByID(id);
            dl.IdDiarioBom = c.IdDiarioBom;
            frmDiarioBomLinhaCad cad = new frmDiarioBomLinhaCad(dl);
            cad.ShowDialog();
            CarregaGrid();
        }
    }
}

