using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmLocalizacaoAtivoCad : RibbonForm
    {
        public LocalizacaoAtivoDAL dal;
        LocalizacaoAtivo la = new LocalizacaoAtivo();
        UnidadeFederacaoDAL ufdal = new UnidadeFederacaoDAL(new DB_ERPContext());
        CidadeDAL cidDal = new CidadeDAL();

        public frmLocalizacaoAtivoCad(LocalizacaoAtivo pLA)
        {
            la = pLA;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmLocalizacaoAtivoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregaDepartamento();
            CarregaUF();

            if (la.IdLocalizacaoAtivo == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmLocalizacaoAtivoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = la.IdLocalizacaoAtivo.ToString();
            txtDescricao.Text = la.Descricao;

            if (la.IdDepartamento != null)
                cboDepartamento.SelectedValue = la.IdDepartamento;

            txtSala.Text = la.Sala;

            if (la.IdUF != null && la.IdUF != 0)
            {
                cboUF.SelectedValue = la.IdUF;

                int IdUF = Convert.ToInt32(cboUF.SelectedValue);
                var cidades = cidDal.Get().Where(x => x.IdUF == IdUF).ToList();
                cboCidade.DataSource = cidades;
                cboCidade.DisplayMember = "Nome";
                cboCidade.ValueMember = "IdCidade";
                cboCidade.SelectedIndex = -1;
            }
            if (la.IdCidade != null && la.IdCidade != 0)
            {
                cboCidade.SelectedValue = la.IdCidade;
            }

            txtLog.Text = la.Endereco;
            txtBairro.Text = la.Bairro;
            txtCEP.Text = la.CEP;
            txtNumero.Text = la.Numero;
            txtCompl.Text = la.Complemento;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        protected void CarregaDepartamento()
        {
            cboDepartamento.DataSource = new DepartamentoDAL().GetCombo();
            cboDepartamento.DisplayMember = "Text";
            cboDepartamento.ValueMember = "iValue";
            cboDepartamento.SelectedIndex = -1;
        }

        private void CarregaUF()
        {
            //Carrega uf
            var ufs = ufdal.Get().OrderBy(x => x.UF).ToList();
            cboUF.DataSource = ufs;
            cboUF.DisplayMember = "UF";
            cboUF.ValueMember = "IdUF";
            cboUF.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            la = new LocalizacaoAtivo();
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

                    la.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboDepartamento.Text))
                        la.IdDepartamento = Convert.ToInt32(cboDepartamento.SelectedValue);

                    la.Sala = txtSala.Text;
                    la.IdUF = Convert.ToInt32(cboUF.SelectedValue);
                    la.IdCidade = Convert.ToInt32(cboCidade.SelectedValue);
                    la.Endereco = txtLog.Text;
                    la.Bairro = txtBairro.Text;
                    la.CEP = txtCEP.Text;
                    la.Numero = txtNumero.Text;
                    la.Complemento = txtCompl.Text;

                    if (la.IdLocalizacaoAtivo == 0)
                    {
                        dal.Insert(la);
                    }
                    else
                    {
                        dal.Update(la);
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
                    int id = la.IdLocalizacaoAtivo;
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
