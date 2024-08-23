using ERP.DAL;
using ERP.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoEncargosCad : RibbonForm
    {
        public GrupoEncargosDAL dal;
        CodigoEncargoDAL cDal = new CodigoEncargoDAL();
        GrupoEncargosCodigoEncargoDAL gcDal = new GrupoEncargosCodigoEncargoDAL();
        GrupoEncargos cc = new GrupoEncargos();

        public frmGrupoEncargosCad(GrupoEncargos pCC)
        {
            cc = pCC;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmCentroCustoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CarregaCombos();
            if (cc.IdGrupoEncargos == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                panel1.Visible = true;
            }
            else
            {
                CarregaDados();
                panel1.Visible = false;
            }

            Cursor.Current = Cursors.Default;
        }

        private void CarregaCombos()
        {
            cboEncargos.DataSource = cDal.GetCombo();
            cboEncargos.ValueMember = "iValue";
            cboEncargos.DisplayMember = "Text";
            cboEncargos.SelectedIndex = -1;
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;
             
            txtNome.Text = cc.Nome;
            txtDescricao.Text = cc.Descricao;

            CarregaGrid();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = gcDal.GetGrupoEncargosCodigos(cc.IdGrupoEncargos);
            dgValores.AutoGenerateColumns = false;
            dgValores.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cc = new GrupoEncargos();
            panel1.Visible = true;
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

                    cc.Nome = txtNome.Text;
                    cc.Descricao = txtDescricao.Text;
                    if (cc.IdGrupoEncargos == 0)
                    {  
                        dal.Insert(cc);
                    }
                    else
                    {
                        dal.Update(cc);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    panel1.Visible = false;
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
                    int id = cc.IdGrupoEncargos;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(cboEncargos.Text == "")
            {
                return;
            }

            GrupoEncargosCodigoEncargo gi = new GrupoEncargosCodigoEncargo();
            gi.IdGrupoEncargos = cc.IdGrupoEncargos;
            gi.IdCodigoEncargo = Convert.ToInt32(cboEncargos.SelectedValue);
            gcDal.Insert(gi);
            gcDal.Save();
            cboEncargos.SelectedIndex = -1;

            CarregaGrid();

        }

        private void dgValores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            using (frmCodigoEncargosCad frmcd = new frmCodigoEncargosCad(new CodigoEncargo()))
            {
                frmcd.dal = cDal;
                frmcd.ShowDialog();
            }
            CarregaCombos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dgValores.Rows.Count > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Deseja remover o registro selecionado?") == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgValores.Rows[dgValores.SelectedRows[0].Index].Cells[0].Value);
                    gcDal.Delete(id);
                    gcDal.Save();
                    CarregaGrid();
                }
            } 
        }
    }
}