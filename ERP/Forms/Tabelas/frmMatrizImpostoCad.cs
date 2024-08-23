using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmMatrizImpostoCad : RibbonForm
    {
        public MatrizImpostosDAL dal;
        MatrizImpostos mi = new MatrizImpostos();

        public frmMatrizImpostoCad(MatrizImpostos pMI)
        {
            mi = pMI;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmMatrizImpostoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregaEmpresa();
            CarregaGrupoCFOP();
            CarregarRelacaoAoGrupo();
            CarregaCliente();
            CarregaGrupoCliente();
            CarregaFornecedor();
            CarregaGrupoFornecedor();
            CarregarRelacaoAoItem();
            CarregaGrupoProduto();
            CarregaGrupoImpostos();
            CarregaGrupoImpostosItem();

            if (mi.IdMatrizImpostos == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmMatrizImpostoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = mi.IdMatrizImpostos.ToString();
            txtDescricao.Text = mi.Descricao;

            cboRelacaoGrupo.SelectedValue = mi.RelacaoGrupo.ToString();

            if (mi.IdEmpresa != null)
                cboEmpresa.SelectedValue = mi.IdEmpresa;
            if (mi.IdGrupoCFOP != null)
                cboGrupoCFOP.SelectedValue = mi.IdGrupoCFOP;
            if (mi.IdCliente != null)
                cboCliente.SelectedValue = mi.IdCliente;
            if (mi.IdGrupoCliente != null)
                cboGrupoCliente.SelectedValue = mi.IdGrupoCliente;
            if (mi.IdFornecedor != null)
                cboFornecedor.SelectedValue = mi.IdFornecedor;
            if (mi.IdGrupoFornecedor != null)
                cboGrupoFornecedor.SelectedValue = mi.IdGrupoFornecedor;
            if (mi.IdGrupoProduto != null)
            {
                cboGrupoProduto.SelectedValue = mi.IdGrupoProduto;
                CarregaProduto(mi.IdGrupoProduto.Value);
            }

            if (mi.IdProduto != null)
                cboProduto.SelectedValue = mi.IdProduto;
            if (mi.IdGrupoImposto != null)
                cboGrupoImpostos.SelectedValue = mi.IdGrupoImposto.Value;
            if (mi.IdGrupoImpostoItem != null)
                cboGrupoImpostosItem.SelectedValue = mi.IdGrupoImpostoItem.Value;

            cboRelacaoItem.SelectedValue = mi.RelacaoItem.ToString();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.WaitCursor;
        }

        protected void CarregaEmpresa()
        {
            cboEmpresa.DataSource = new EmpresaDAL().GetCombo();
            cboEmpresa.DisplayMember = "Text";
            cboEmpresa.ValueMember = "iValue";
            cboEmpresa.SelectedIndex = -1;
        }

        protected void CarregaGrupoCFOP()
        {
            cboGrupoCFOP.DataSource = new GrupoCFOPDAL().GetCombo();
            cboGrupoCFOP.DisplayMember = "Text";
            cboGrupoCFOP.ValueMember = "iValue";
            cboGrupoCFOP.SelectedIndex = -1;
        }

        private void CarregarRelacaoAoGrupo()
        {
            List<DropList> lista = Util.EnumERP.CarregarRelacaoAoGrupo();

            cboRelacaoGrupo.DisplayMember = "Text";
            cboRelacaoGrupo.ValueMember = "Value";
            cboRelacaoGrupo.DataSource = lista;
            cboRelacaoGrupo.SelectedIndex = -1;
        }

        protected void CarregaCliente()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboCliente.DataSource = new ClienteDAL().GetCombo(sEmpresa);
            cboCliente.DisplayMember = "Text";
            cboCliente.ValueMember = "iValue";
            cboCliente.SelectedIndex = -1;
        }

        protected void CarregaGrupoCliente()
        {
            cboGrupoCliente.DataSource = new GrupoClienteDAL().GetCombo();
            cboGrupoCliente.DisplayMember = "Text";
            cboGrupoCliente.ValueMember = "iValue";
            cboGrupoCliente.SelectedIndex = -1;
        }

        protected void CarregaFornecedor()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(sEmpresa);
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.SelectedIndex = -1;
        }

        protected void CarregaGrupoFornecedor()
        {
            cboGrupoFornecedor.DataSource = new GrupoFornecedorDAL().GetCombo();
            cboGrupoFornecedor.DisplayMember = "Text";
            cboGrupoFornecedor.ValueMember = "iValue";
            cboGrupoFornecedor.SelectedIndex = -1;
        }

        private void CarregarRelacaoAoItem()
        {
            List<DropList> lista = Util.EnumERP.CarregarRelacaoDeItem();

            cboRelacaoItem.DisplayMember = "Text";
            cboRelacaoItem.ValueMember = "Value";
            cboRelacaoItem.DataSource = lista;
            cboRelacaoItem.SelectedIndex = -1;
        }

        protected void CarregaProduto(int pIdGrupoProduto)
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboProduto.DataSource = new ProdutoDAL().getProdutosGruposCombo(pIdGrupoProduto, sEmpresa);
            cboProduto.DisplayMember = "Codigo";
            cboProduto.ValueMember = "IdProduto";
            cboProduto.SelectedIndex = -1;
        }

        protected void CarregaGrupoProduto()
        {
            cboGrupoProduto.DataSource = new GrupoProdutoDAL().GetCombo();
            cboGrupoProduto.DisplayMember = "Text";
            cboGrupoProduto.ValueMember = "iValue";
            cboGrupoProduto.SelectedIndex = -1;
        }

        protected void CarregaGrupoImpostos()
        {
            cboGrupoImpostos.DataSource = new GrupoImpostoDAL().getCombo();
            cboGrupoImpostos.DisplayMember = "Text";
            cboGrupoImpostos.ValueMember = "iValue";
            cboGrupoImpostos.SelectedIndex = -1;
        }

        protected void CarregaGrupoImpostosItem()
        {
            cboGrupoImpostosItem.DataSource = new GrupoImpostoItemDAL().GetCombo();
            cboGrupoImpostosItem.DisplayMember = "Text";
            cboGrupoImpostosItem.ValueMember = "iValue";
            cboGrupoImpostosItem.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            mi = new MatrizImpostos();
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

                    mi.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboEmpresa.Text))
                        mi.IdEmpresa = Convert.ToInt32(cboEmpresa.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoCFOP.Text))
                        mi.IdGrupoCFOP = Convert.ToInt32(cboGrupoCFOP.SelectedValue);
                    if (!String.IsNullOrEmpty(cboRelacaoGrupo.Text))
                        mi.RelacaoGrupo = Convert.ToInt32(cboRelacaoGrupo.SelectedValue);

                    if (!String.IsNullOrEmpty(cboCliente.Text))
                        mi.IdCliente = Convert.ToInt32(cboCliente.SelectedValue);
                    else
                        mi.IdCliente = null;

                    if (!String.IsNullOrEmpty(cboGrupoCliente.Text))
                        mi.IdGrupoCliente = Convert.ToInt32(cboGrupoCliente.SelectedValue);
                    else
                        mi.IdGrupoCliente = null;

                    if (!String.IsNullOrEmpty(cboFornecedor.Text))
                        mi.IdFornecedor = Convert.ToInt32(cboFornecedor.SelectedValue);
                    else
                        mi.IdFornecedor = null;

                    if (!String.IsNullOrEmpty(cboGrupoFornecedor.Text))
                        mi.IdGrupoFornecedor = Convert.ToInt32(cboGrupoFornecedor.SelectedValue);
                    else
                        mi.IdGrupoFornecedor = null;

                    if (!String.IsNullOrEmpty(cboRelacaoItem.Text))
                        mi.RelacaoItem = Convert.ToInt32(cboRelacaoItem.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoProduto.Text))
                        mi.IdGrupoProduto = Convert.ToInt32(cboGrupoProduto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboProduto.Text))
                        mi.IdProduto = Convert.ToInt32(cboProduto.SelectedValue);
                    else
                        mi.IdProduto = null;

                    if (!String.IsNullOrEmpty(cboGrupoImpostos.Text))
                        mi.IdGrupoImposto = Convert.ToInt32(cboGrupoImpostos.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoImpostosItem.Text))
                        mi.IdGrupoImpostoItem = Convert.ToInt32(cboGrupoImpostosItem.SelectedValue);

                    if (mi.IdMatrizImpostos == 0)
                    {
                        dal.Insert(mi);
                    }
                    else
                    {
                        dal.Update(mi);
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
                    int id = mi.IdMatrizImpostos;
                    dal.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    this.Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowMessage("Este registro não pode ser excluído." + "\n" + "\n" + "Erro: " + ex.Message);
                }
            }
        }

        private void cboGrupoProduto_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboGrupoProduto.Text))
            {
                int idGP = Convert.ToInt32(cboGrupoProduto.SelectedValue);
                CarregaProduto(idGP);
            }
        }
    }
}
