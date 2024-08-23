using ERP.Auxiliares;
using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmTempoTrabalhoCad : RibbonForm
    {
        public TempoTrabalhoDAL dal = new TempoTrabalhoDAL();
        TempoTrabalhoLinhasDAL idal = new TempoTrabalhoLinhasDAL();
        TempoTrabalho tt = new TempoTrabalho();


        public frmTempoTrabalhoCad(TempoTrabalho pTT)
        {
            tt = pTT;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmTempoTrabalhoCad_Load(object sender, EventArgs e)
        {
            if (tt.IdTempoTrabalho == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void frmTempoTrabalhoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        { 
            txtDescricao.Text = tt.Descricao;
            chkFechado.Checked = tt.Fechado;
            CarregaGrid();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            tt = new TempoTrabalho(); 
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
                    tt.Descricao = txtDescricao.Text;
                    tt.Fechado = chkFechado.Checked;

                    if (tt.IdTempoTrabalho == 0)
                    {
                        dal.Insert(tt);
                    }
                    else
                    {
                        dal.Update(tt);
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
                int id = tt.IdTempoTrabalho;
                dal.Delete(id);
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tt.IdTempoTrabalho == 0)
            {
                Util.Aplicacao.ShowMessage("É necessário salvar os dados antes de adicionar itens.");
                return;
            }
            TempoTrabalhoLinhas ti = new TempoTrabalhoLinhas();
            ti.IdTempoTrabalho = tt.IdTempoTrabalho;
            frmTempoTrabalhoItem f = new frmTempoTrabalhoItem(ti);
            f.dal = idal;
            f.ShowDialog();
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            var lista = idal.GetByTempoId(tt.IdTempoTrabalho);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["id"].Value);
            TempoTrabalhoLinhas ti = idal.GetByID(id);
            ti.IdTempoTrabalho = tt.IdTempoTrabalho;
            frmTempoTrabalhoItem f = new frmTempoTrabalhoItem(ti);
            f.dal = idal;
            f.ShowDialog();
            CarregaGrid();
        }
    }
}
