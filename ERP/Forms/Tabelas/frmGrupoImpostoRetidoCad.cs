using ERP.Auxiliares;
using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoImpostoRetidoCad : RibbonForm
    {
        public GrupoImpostoRetidoDAL dal;
        ConfGrupoImpostoRetidoDAL cidal = new ConfGrupoImpostoRetidoDAL();
        GrupoImpostoRetido gir = new GrupoImpostoRetido();
        List<ConfImpostoRetidoModelView> Configuracoes = new List<ConfImpostoRetidoModelView>();

        public frmGrupoImpostoRetidoCad(GrupoImpostoRetido pGIR)
        {
            gir = pGIR;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmGrupoImpostoRetidoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregaCodigoImpostoRetido();
            CarregaGrid();
            if (gir.IdGrupoImpostoRetido == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmGrupoImpostoRetidoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = gir.IdGrupoImpostoRetido.ToString();
            txtCodigo.Text = gir.Codigo;
            txtDescricao.Text = gir.Descricao;
            chkReverterImpostoDescontoAVista.Checked = gir.ReverterImpostoDescontoAVista;
            //if (gir.IdCodigoImpostoRetido != null)
            //    cboCodigoImpostoRetido.SelectedValue = gir.IdCodigoImpostoRetido;

            // txtAliquota.Text = gir.Aliquota.ToString("N4");
            // txtExclusao.Text = gir.Exclusao.ToString("N4");
            CarregaGrid();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        protected void CarregaCodigoImpostoRetido()
        {
            //cboCodigoImpostoRetido.DataSource = new CodigoImpostoRetidoDAL().GetCombo();
            //cboCodigoImpostoRetido.DisplayMember = "Text";
            //cboCodigoImpostoRetido.ValueMember = "iValue";
            //cboCodigoImpostoRetido.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            gir = new GrupoImpostoRetido();
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

                    gir.Codigo = txtCodigo.Text;
                    gir.Descricao = txtDescricao.Text;
                    gir.ReverterImpostoDescontoAVista = chkReverterImpostoDescontoAVista.Checked;
                    //if (!String.IsNullOrEmpty(cboCodigoImpostoRetido.Text))
                    //    gir.IdCodigoImpostoRetido = Convert.ToInt32(cboCodigoImpostoRetido.SelectedValue);

                    //gir.Aliquota = Convert.ToDecimal(txtAliquota.Text);
                    //gir.Exclusao = Convert.ToDecimal(txtExclusao.Text);

                    if (gir.IdGrupoImpostoRetido == 0)
                    {
                        dal.Insert(gir);
                    }
                    else
                    {
                        dal.Update(gir);
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
                    int id = gir.IdGrupoImpostoRetido;
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

        private void txtAliquota_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            //{
            //    if (Regex.IsMatch(txtAliquota.Text, "^\\d*\\,\\d{4}$"))
            //        e.Handled = true;
            //}
            //else
            //{
            //    e.Handled = e.KeyChar != (char)Keys.Back;
            //}
        }

        private void txtExclusao_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            //{
            //    if (Regex.IsMatch(txtExclusao.Text, "^\\d*\\,\\d{4}$"))
            //        e.Handled = true;
            //}
            //else
            //{
            //    e.Handled = e.KeyChar != (char)Keys.Back;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gir.IdGrupoImpostoRetido == 0)
            {
                Util.Aplicacao.ShowMessage("É necessário salvar as informações do grupo de impostos antes de adicionar configurações.");
                return;
            }
            try
            {
                ConfGrupoImpostoRetido c = new ConfGrupoImpostoRetido();
                c.IdGrupoImpostoRetido = gir.IdGrupoImpostoRetido;
                frmCalendarioDataLinha frmConf = new frmCalendarioDataLinha(c);
                frmConf.dal = cidal;
                frmConf.ShowDialog();
                CarregaGrid();
            }
            catch
            {
                CarregaGrid();
            }
        }


        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            Configuracoes = cidal.GetByGrupoRetido(gir.IdGrupoImpostoRetido);
            dgConfiguracoes.AutoGenerateColumns = false;
            dgConfiguracoes.DataSource = Configuracoes;

            Cursor.Current = Cursors.Default;
        }

        private void dgConfiguracoes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgConfiguracoes.Rows[dgConfiguracoes.SelectedRows[0].Index].Cells[0].Value);
            ConfGrupoImpostoRetido c = cidal.GetByID(id);
            frmCalendarioDataLinha frmConf = new frmCalendarioDataLinha(c);
            frmConf.dal = cidal;
            frmConf.ShowDialog();
            CarregaGrid();
        }


    }
}
