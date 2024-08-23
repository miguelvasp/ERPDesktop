using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoImpostosCad : RibbonForm
    {
        public GrupoImpostoDAL dal;
        GrupoImposto gi = new GrupoImposto();
        ConfGrupoImpostoDAL cfDal = new ConfGrupoImpostoDAL();

        public frmGrupoImpostosCad(GrupoImposto gImposto)
        {
            gi = gImposto;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmGrupoImpostosCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (gi.IdGrupoImposto == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmGrupoImpostosCad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var codigos = cfDal.getByGrupoImposto(gi.IdGrupoImposto);
            dgCodigos.AutoGenerateColumns = false;
            dgCodigos.DataSource = codigos;
            

            Cursor.Current = Cursors.Default;
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = gi.IdGrupoImposto.ToString();
            txtCodigoGrupo.Text = gi.CodigoGrupoImposto;
            txtDescricao.Text = gi.Descricao;
            chkReverterImpostoDescontoAVista.Checked = gi.ReverterImpostoDescontoAVista;
            CarregaGrid();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            gi = new GrupoImposto();
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

                    gi.CodigoGrupoImposto = txtCodigoGrupo.Text;
                    gi.Descricao = txtDescricao.Text;
                    gi.ReverterImpostoDescontoAVista = chkReverterImpostoDescontoAVista.Checked;

                    if (gi.IdGrupoImposto == 0)
                    {
                        dal.Insert(gi);
                    }
                    else
                    {
                        dal.Update(gi);
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
                    int id = gi.IdGrupoImposto;

                    dal.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    this.Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gi.IdGrupoImposto == 0)
            {
                Util.Aplicacao.ShowMessage("É necessário salvar as informações do grupo de impostos antes de adicionar configurações.");
                return;
            }
            try
            {
                ConfGrupoImposto c = new ConfGrupoImposto();
                c.IdGrupoImposto = gi.IdGrupoImposto;
                frmConfGrupoImpostoCad frmConf = new frmConfGrupoImpostoCad(c);
                frmConf.dal = cfDal;
                frmConf.ShowDialog();
                CarregaGrid();
            }
            catch 
            {
                CarregaGrid();
            }
        }

        private void dgCodigos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgCodigos.Rows[dgCodigos.SelectedRows[0].Index].Cells[0].Value);
                ConfGrupoImposto c = cfDal.GetByID(id);
                frmConfGrupoImpostoCad frmConf = new frmConfGrupoImpostoCad(c);
                frmConf.dal = cfDal;
                frmConf.ShowDialog();
                CarregaGrid();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }
    }
}
