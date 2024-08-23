using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoEstoqueCad : RibbonForm
    {
        public GrupoEstoqueDAL dal;
        GrupoEstoque ge = new GrupoEstoque();

        public frmGrupoEstoqueCad(GrupoEstoque pGE)
        {
            ge = pGE;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmGrupoEstoqueCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarModeloEstoque();

            if (ge.IdGrupoEstoque == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmGrupoEstoqueCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = ge.IdGrupoEstoque.ToString();
            txtNome.Text = ge.Nome;
            txtDescricao.Text = ge.Descricao;
            chkEstoque.Checked = ge.Estoque;
            chkEstoqueNegativo.Checked = ge.EstoqueNegativo;
            chkEstoqueFisico.Checked = ge.EstoqueFisico;
            chkEstoqueFinanceiro.Checked = ge.EstoqueFinanceiro;
            chkLoteFornecedor.Checked = ge.LoteFornecedor;

            if (ge.ModeloEstoque != null)
                cboModeloEstoque.SelectedValue = ge.ModeloEstoque.ToString();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarModeloEstoque()
        {
            List<DropList> lista = Util.EnumERP.CarregarModeloEstoque();

            cboModeloEstoque.DisplayMember = "Text";
            cboModeloEstoque.ValueMember = "Value";
            cboModeloEstoque.DataSource = lista;
            cboModeloEstoque.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            ge = new GrupoEstoque();
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

                    ge.Nome = txtNome.Text;
                    ge.Descricao = txtDescricao.Text;

                    ge.Estoque = chkEstoque.Checked;
                    ge.EstoqueNegativo = chkEstoqueNegativo.Checked;
                    ge.EstoqueFisico = chkEstoqueFisico.Checked;
                    ge.EstoqueFinanceiro = chkEstoqueFinanceiro.Checked;
                    ge.LoteFornecedor = chkLoteFornecedor.Checked;

                    if (!String.IsNullOrEmpty(cboModeloEstoque.Text))
                        ge.ModeloEstoque = Convert.ToInt32(cboModeloEstoque.SelectedValue);

                    if (ge.IdGrupoEstoque == 0)
                    {
                        dal.Insert(ge);
                    }
                    else
                    {
                        dal.Update(ge);
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
                    int id = ge.IdGrupoEstoque;
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
    }
}