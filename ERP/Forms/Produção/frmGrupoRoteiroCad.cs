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
    public partial class frmGrupoRoteiroCad : RibbonForm
    {
        public GrupoRoteiroDAL dal = new GrupoRoteiroDAL();
        GrupoRoteiroLinhaDAL idal = new GrupoRoteiroLinhaDAL();
        GrupoRoteiro c = new GrupoRoteiro();

        public frmGrupoRoteiroCad(GrupoRoteiro pC)
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
            if (c.IdGrupoRoteiro == 0)
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
            txtDescricao.Text = c.Descricao;
            chkCalcularQuantidade.Checked = c.CalcularQuantidade;
            chkCalcularTempoExecusao.Checked = c.CalcularTempoExecusao;
            chkCalcularTempoPreparacao.Checked = c.CalcularTempoPreparacao;
            chkConsumoAutomaticoTempoExecusao.Checked = c.ConsumoAutomaticoTempoExecusao;
            chkConsumoAutomaticoTempoPreparacao.Checked = c.ConsumoAutomaticoTempoPreparacao;
            chkRelatarOperacaoComoConcluida.Checked = c.RelatarOperacaoComoConcluida;
            chkRelatarQuantidadeComoConcluida.Checked = c.RelatarQuantidadeComoConcluida;
            CarregaGrid();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            c = new GrupoRoteiro();
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
                    c.Descricao = txtDescricao.Text;
                    c.CalcularQuantidade = chkCalcularQuantidade.Checked;
                    c.CalcularTempoExecusao = chkCalcularTempoExecusao.Checked;
                    c.CalcularTempoPreparacao = chkCalcularTempoPreparacao.Checked;
                    c.ConsumoAutomaticoTempoExecusao = chkConsumoAutomaticoTempoExecusao.Checked;
                    c.ConsumoAutomaticoTempoPreparacao = chkConsumoAutomaticoTempoPreparacao.Checked;
                    c.RelatarOperacaoComoConcluida = chkRelatarOperacaoComoConcluida.Checked;
                    c.RelatarQuantidadeComoConcluida = chkRelatarQuantidadeComoConcluida.Checked;

                    if (c.IdGrupoRoteiro == 0)
                    {
                        dal.Insert(c);
                    }
                    else
                    {
                        dal.Update(c);
                    }

                    dal.Save();
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
                int id = c.IdGrupoRoteiro;
                dal.Delete(id);
                dal.Save();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c.IdGrupoRoteiro == 0)
            {
                Util.Aplicacao.ShowMessage("Salve os dados do grupo roteiro antes de adicionar datas.");
                return;
            }

            GrupoRoteiroLinha cd = new GrupoRoteiroLinha();
            cd.IdGrupoRoteiro = c.IdGrupoRoteiro;
            frmGrupoRoteiroLinhas frm = new frmGrupoRoteiroLinhas(cd);
            frm.dal = idal;
            frm.ShowDialog();
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            var lista = idal.GetByGrupoId(c.IdGrupoRoteiro);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["id"].Value);
                    GrupoRoteiroLinha cd = idal.GetByID(id);
                    cd.IdGrupoRoteiro = c.IdGrupoRoteiro;
                    frmGrupoRoteiroLinhas frm = new frmGrupoRoteiroLinhas(cd);
                    frm.dal = idal;
                    frm.ShowDialog();
                    CarregaGrid();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }
    }
}

