using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmSegmentoCad : RibbonForm
    {
        public SegmentoDAL dal;
        Segmento seg = new Segmento();
        public SubSegmentoDAL sdal = new SubSegmentoDAL();

        public frmSegmentoCad(Segmento pSeg)
        {
            seg = pSeg;
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmSegmentoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregaSegmento();

            if (seg.IdSegmento == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmSegmentoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = seg.IdSegmento.ToString();
            txtNome.Text = seg.Nome;
            txtDescricao.Text = seg.Descricao;
            if (seg.IdProximoSegmento != null)
                cboProximoSegmento.SelectedValue = seg.IdProximoSegmento;
            chkObrigatorio.Checked = seg.Obrigatorio;
            CarregaGrid();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        protected void CarregaSegmento()
        {
            cboProximoSegmento.DataSource = new SegmentoDAL().GetCombo();
            cboProximoSegmento.DisplayMember = "Text";
            cboProximoSegmento.ValueMember = "iValue";
            cboProximoSegmento.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            seg = new Segmento();
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

                    seg.Nome = txtNome.Text;
                    seg.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboProximoSegmento.Text))
                        seg.IdProximoSegmento = Convert.ToInt32(cboProximoSegmento.SelectedValue);
                    seg.Obrigatorio = chkObrigatorio.Checked;

                    if (seg.IdSegmento == 0)
                    {
                        dal.Insert(seg);
                    }
                    else
                    {
                        dal.Update(seg);
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
                    int id = seg.IdSegmento;
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
            if (seg.IdSegmento == 0)
            {
                Util.Aplicacao.ShowMessage("Por favor salve as informações do segmento para adicionar subsegmentos");
                return;
            }

            SubSegmento sg = new SubSegmento();
            sg.IdSegmento = seg.IdSegmento;
            frmSubSegmentoCad frmsub = new frmSubSegmentoCad(sg);
            frmsub.dal = sdal;

            frmsub.ShowDialog();
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var SubSegmento = new SubSegmentoDAL().GetByIDSegmento(seg.IdSegmento).OrderBy(x => x.Nome).ToList();
            dgSubsegmento.AutoGenerateColumns = false;
            dgSubsegmento.DataSource = SubSegmento;

            Cursor.Current = Cursors.Default;
        }

        private void dgSubsegmento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgSubsegmento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgSubsegmento.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dgSubsegmento.Rows[dgSubsegmento.SelectedRows[0].Index].Cells[0].Value);
                SubSegmento sg = sdal.GetByID(id);
                frmSubSegmentoCad frmsub = new frmSubSegmentoCad(sg);
                frmsub.dal = sdal;
                frmsub.ShowDialog();
                CarregaGrid();
            }

        }
    }
}
