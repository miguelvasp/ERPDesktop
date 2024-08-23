using ERP.Auxiliares;
using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmVariantesGrupoCad : RibbonForm
    {
        public VariantesGrupoDAL dal = new VariantesGrupoDAL();
        VariantesGrupoItemDAL idal = new VariantesGrupoItemDAL();
        VariantesGrupo vg = new VariantesGrupo();

        public frmVariantesGrupoCad(VariantesGrupo v)
        {
            vg = v;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmUnidade_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (vg.IdVariantesGrupo == 0)
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

            txtDesc.Text = vg.Descricao;
            CarregaGrid();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            vg = new VariantesGrupo();
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

                    vg.Descricao = txtDesc.Text;
                    if (vg.IdVariantesGrupo == 0)
                    {
                        dal.Insert(vg);
                    }
                    else
                    {
                        dal.Update(vg);
                    }
                    dal.Save();
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
                    int id = vg.IdVariantesGrupo;
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

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = idal.GetByGrupoId(vg.IdVariantesGrupo);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["id"].Value);
            VariantesGrupoItem vi = idal.GetByID(id);
            vi.IdVariantesGrupo = vg.IdVariantesGrupo;
            frmVariantesGrupoItemAux f = new frmVariantesGrupoItemAux(vi);
            f.dal = idal;
            f.ShowDialog();
            CarregaGrid();
        }

        private void btnAddConfig_Click(object sender, EventArgs e)
        {
            if (vg.IdVariantesGrupo == 0)
            {
                Util.Aplicacao.ShowMessage("É necessário salvar as informações do grupo antes de adicionar itens.");
                return;
            }
            VariantesGrupoItem vi = new VariantesGrupoItem();
            vi.IdVariantesGrupo = vg.IdVariantesGrupo;
            frmVariantesGrupoItemAux f = new frmVariantesGrupoItemAux(vi);
            f.dal = idal;
            f.ShowDialog();
            CarregaGrid();
        }
    }
}
