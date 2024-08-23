using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmRoteiroCad : RibbonForm
    {
        public RoteiroDAL dal = new RoteiroDAL();
        RoteiroOperacaoDAL idal = new RoteiroOperacaoDAL();
        Roteiro c = new Roteiro();

        public frmRoteiroCad(Roteiro pC)
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

            if (c.IdRoteiro == 0)
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
            cboAprovador.DataSource = new FuncionarioDAL().GetCombo();
            cboAprovador.DisplayMember = "Text";
            cboAprovador.ValueMember = "iValue";
            cboAprovador.SelectedIndex = -1;

            cboGrupoLancamento.DataSource = new GrupoLancamentoDAL().GetCombo();
            cboGrupoLancamento.DisplayMember = "Text";
            cboGrupoLancamento.ValueMember = "iValue";
            cboGrupoLancamento.SelectedIndex = -1;
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
            chkAprovado.Checked = c.Aprovado;
            cboAprovador.SelectedValue = c.IdFuncionarioAprovador == null ? 0 : c.IdFuncionarioAprovador;
            cboAprovarRoteiro.SelectedValue = c.AprovarRoteiro == null ? 0 : c.AprovarRoteiro;
            cboGrupoLancamento.SelectedValue = c.IdGrupoLancamento == null ? 0 : c.IdGrupoLancamento;
            chkVerificarRoteiro.Checked = c.VerificarRoteiro;
            CarregaGrid();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }
        
        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            c = new Roteiro();
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
                    c.IdFuncionarioAprovador = null;
                    c.AprovarRoteiro = null;
                    c.IdGrupoLancamento = null;

                    c.Descricao = txtDescricao.Text;
                    c.Aprovado = chkAprovado.Checked;
                    if (!String.IsNullOrEmpty(cboAprovador.Text)) c.IdFuncionarioAprovador = Convert.ToInt32(cboAprovador.SelectedValue);
                    if (!String.IsNullOrEmpty(cboAprovarRoteiro.Text)) c.AprovarRoteiro = Convert.ToInt32(cboAprovarRoteiro.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoLancamento.Text)) c.IdGrupoLancamento = Convert.ToInt32(cboGrupoLancamento.SelectedValue);
                    c.VerificarRoteiro = chkVerificarRoteiro.Checked;

                    if (c.IdRoteiro == 0)
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
                int id = c.IdRoteiro;
                dal.Delete(id);
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c.IdRoteiro == 0)
            {
                Util.Aplicacao.ShowMessage("Salve os dados do roteiro antes de adicionar datas.");
                return;
            }

            RoteiroOperacao cd = new RoteiroOperacao();
            cd.IdRoteiro = c.IdRoteiro;
            frmRoteiroOperacao frm = new frmRoteiroOperacao(cd);
            frm.dal = idal;
            frm.ShowDialog();
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            var lista = idal.GetByRoteiroId(c.IdRoteiro);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista;
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["id"].Value);
                    RoteiroOperacao cd = idal.GetByID(id);
                    frmRoteiroOperacao frm = new frmRoteiroOperacao(cd);
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

