using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCodigoServicoCad : RibbonForm
    {
        UnidadeFederacaoDAL ufdal = new UnidadeFederacaoDAL(new DB_ERPContext());
        CidadeDAL cidDal = new CidadeDAL();
        PaisDAL paisDal = new PaisDAL();

        public CodigoServicoDAL dal;
        CodigoServico cs = new CodigoServico();

        public frmCodigoServicoCad(CodigoServico pCS)
        {
            cs = pCS;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmCodigoServicoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //carrega paises
            var paises = paisDal.Get().OrderBy(x => x.NomePais).ToList();
            cboPais.DataSource = paises;
            cboPais.DisplayMember = "NomePais";
            cboPais.ValueMember = "IdPais";
            cboPais.SelectedIndex = -1;

            //Carrega uf
            var ufs = ufdal.Get().OrderBy(x => x.UF).ToList();
            cboUF.DataSource = ufs;
            cboUF.DisplayMember = "UF";
            cboUF.ValueMember = "IdUF";
            cboUF.SelectedIndex = -1;

            if (cs.IdCodigoServico == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmCodigoServicoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = cs.IdCodigoServico.ToString();
            txtCodigo.Text = cs.Codigo;
            txtDescricao.Text = cs.Descricao;
            txtNome.Text = cs.Nome;
            cboPais.SelectedValue = cs.IdPais;
            cboUF.SelectedValue = cs.IdUF;
            if (cs.IdUF != 0)
            {
                int IdUF = Convert.ToInt32(cboUF.SelectedValue);
                var cidades = cidDal.Get().Where(x => x.IdUF == IdUF).ToList();
                cboCidade.DataSource = cidades;
                cboCidade.DisplayMember = "Nome";
                cboCidade.ValueMember = "IdCidade";
                cboCidade.SelectedIndex = -1;
            }
            cboCidade.SelectedValue = cs.IdCidade;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cs = new CodigoServico();
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

                    cs.Codigo = txtCodigo.Text;
                    cs.Nome = txtNome.Text;
                    cs.Descricao = txtDescricao.Text;
                    cs.IdPais = Convert.ToInt32(cboPais.SelectedValue);
                    cs.IdUF = Convert.ToInt32(cboUF.SelectedValue);
                    cs.IdCidade = Convert.ToInt32(cboCidade.SelectedValue);

                    if (cs.IdCodigoServico == 0)
                    {
                        dal.Insert(cs);
                    }
                    else
                    {
                        dal.Update(cs);
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
                    int id = cs.IdCodigoServico;
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

        private void cboUF_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboUF.Text))
            {
                int IdUF = Convert.ToInt32(cboUF.SelectedValue);
                var cidades = cidDal.Get().Where(x => x.IdUF == IdUF).ToList();
                cboCidade.DataSource = cidades;
                cboCidade.DisplayMember = "Nome";
                cboCidade.ValueMember = "IdCidade";
                cboCidade.SelectedIndex = -1;
            }
        }
    }
}
