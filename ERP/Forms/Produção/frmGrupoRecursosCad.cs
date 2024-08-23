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
    public partial class frmGrupoRecursosCad : RibbonForm
    {
        public GrupoRecursosDAL dal = new GrupoRecursosDAL();
        GrupoRecursoLinhaDAL idal = new GrupoRecursoLinhaDAL();
        GrupoRecursos c = new GrupoRecursos();

        public frmGrupoRecursosCad(GrupoRecursos pC)
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
            CarregaCombo();

            if (c.IdGrupoRecursos == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void CarregaCombo()
        {
            cboArmazem.DataSource = new ArmazemDAL().GetCombo();
            cboArmazem.DisplayMember = "Text";
            cboArmazem.ValueMember = "iValue";
            cboArmazem.SelectedIndex = -1;
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
            cboArmazem.SelectedValue = c.IdArmazem == null ? 0 : c.IdArmazem;
            CarregaGrid();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            c = new GrupoRecursos();
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
                    c.IdArmazem = null;
                    c.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboArmazem.Text)) c.IdArmazem = Convert.ToInt32(cboArmazem.SelectedValue);

                    if (c.IdGrupoRecursos == 0)
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
                int id = c.IdGrupoRecursos;
                dal.Delete(id);
                dal.Save();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c.IdGrupoRecursos == 0)
            {
                Util.Aplicacao.ShowMessage("Salve os dados do calendário antes de adicionar datas.");
                return;
            }

            GrupoRecursoLinha cd = new GrupoRecursoLinha();
            cd.IdGrupoRecurso = c.IdGrupoRecursos;
            frmGrupoRecursosLinhas frm = new frmGrupoRecursosLinhas(cd);
            frm.dal = idal;
            frm.ShowDialog();
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            var lista = idal.GetByGrupoId(c.IdGrupoRecursos);

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
                    GrupoRecursoLinha cd = idal.GetByID(c.IdGrupoRecursos);
                    cd.IdGrupoRecurso = c.IdGrupoRecursos;
                    frmGrupoRecursosLinhas frm = new frmGrupoRecursosLinhas(cd);
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

