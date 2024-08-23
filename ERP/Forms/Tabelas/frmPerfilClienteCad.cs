using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPerfilClienteCad : RibbonForm
    {
        public PerfilClienteDAL dal;
        PerfilCliente pc = new PerfilCliente();

        public frmPerfilClienteCad(PerfilCliente ppc)
        {
            pc = ppc;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmPerfilClienteCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarCliente();
            CarregarGrupoCliente();
            CarregarRelacaoAoGrupo();
            CarregarConta();
            CarregarLiquidar();
            CarregarPagamentoAntecipado();
            CarregarDesconto();
            CarregarBaixa();
            CarregarJuros();
            CarregarMulta();
            CarregarTransferenciaImpostos();

            if (pc.IdPerfilCliente == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmPerfilClienteCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = pc.IdPerfilCliente.ToString();
            txtNome.Text = pc.Nome;
            txtDescricao.Text = pc.Descricao;
            if (pc.RelacaoGrupo != null)
                cboRelacaoGrupo.SelectedValue = pc.RelacaoGrupo.ToString();
            if (pc.IdCliente != null)
                cboCliente.SelectedValue = pc.IdCliente;
            if (pc.IdGrupoCliente != null)
                cboGrupoCliente.SelectedValue = pc.IdGrupoCliente;

            if (pc.IdContaContabil != null)
                cboConta.SelectedValue = pc.IdContaContabil;
            if (pc.IdContaContabilLiquidar != null)
                cboLiquidar.SelectedValue = pc.IdContaContabilLiquidar;
            if (pc.IdContaContabilPagamentoAntecipado != null)
                cboPagamentoAntecipado.SelectedValue = pc.IdContaContabilPagamentoAntecipado;
            if (pc.IdContaContabilDesconto != null)
                cboDesconto.SelectedValue = pc.IdContaContabilDesconto;
            if (pc.IdContaContabilBaixa != null)
                cboBaixa.SelectedValue = pc.IdContaContabilBaixa;
            if (pc.IdContaContabilJuros != null)
                cboJuros.SelectedValue = pc.IdContaContabilJuros;
            if (pc.IdContaContabilMulta != null)
                cboMulta.SelectedValue = pc.IdContaContabilMulta;
            if (pc.IdContaContabilTransferenciaImposto != null)
                cboTransferenciaImpostos.SelectedValue = pc.IdContaContabilTransferenciaImposto;

            chkBaixa.Checked = pc.Baixa;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        protected void CarregarCliente()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboCliente.DataSource = new ClienteDAL().GetCombo(sEmpresa);
            cboCliente.DisplayMember = "Text";
            cboCliente.ValueMember = "iValue";
            cboCliente.SelectedIndex = -1;
        }

        protected void CarregarGrupoCliente()
        {
            GrupoClienteDAL gcdal = new GrupoClienteDAL();

            var gc = gcdal.Get().OrderBy(o => o.Descricao).ToList();
            cboGrupoCliente.DataSource = gc;
            cboGrupoCliente.ValueMember = "IdGrupoCliente";
            cboGrupoCliente.DisplayMember = "Descricao";
            cboGrupoCliente.SelectedIndex = -1;
        }

        private void CarregarRelacaoAoGrupo()
        {
            List<DropList> lista = Util.EnumERP.CarregarRelacaoAoGrupo();

            cboRelacaoGrupo.DisplayMember = "Text";
            cboRelacaoGrupo.ValueMember = "Value";
            cboRelacaoGrupo.DataSource = lista;
            cboRelacaoGrupo.SelectedIndex = -1;
        }

        protected void CarregarConta()
        {
            cboConta.DataSource = new ContaContabilDAL().GetCombo();
            cboConta.DisplayMember = "Text";
            cboConta.ValueMember = "iValue";
            cboConta.SelectedIndex = -1;
        }

        protected void CarregarLiquidar()
        {
            cboLiquidar.DataSource = new ContaContabilDAL().GetCombo();
            cboLiquidar.DisplayMember = "Text";
            cboLiquidar.ValueMember = "iValue";
            cboLiquidar.SelectedIndex = -1;
        }

        protected void CarregarPagamentoAntecipado()
        {
            cboPagamentoAntecipado.DataSource = new ContaContabilDAL().GetCombo();
            cboPagamentoAntecipado.DisplayMember = "Text";
            cboPagamentoAntecipado.ValueMember = "iValue";
            cboPagamentoAntecipado.SelectedIndex = -1;
        }

        protected void CarregarDesconto()
        {
            cboDesconto.DataSource = new ContaContabilDAL().GetCombo();
            cboDesconto.DisplayMember = "Text";
            cboDesconto.ValueMember = "iValue";
            cboDesconto.SelectedIndex = -1;
        }

        protected void CarregarBaixa()
        {
            cboBaixa.DataSource = new ContaContabilDAL().GetCombo();
            cboBaixa.DisplayMember = "Text";
            cboBaixa.ValueMember = "iValue";
            cboBaixa.SelectedIndex = -1;
        }

        protected void CarregarJuros()
        {
            cboJuros.DataSource = new ContaContabilDAL().GetCombo();
            cboJuros.DisplayMember = "Text";
            cboJuros.ValueMember = "iValue";
            cboJuros.SelectedIndex = -1;
        }

        protected void CarregarMulta()
        {
            cboMulta.DataSource = new ContaContabilDAL().GetCombo();
            cboMulta.DisplayMember = "Text";
            cboMulta.ValueMember = "iValue";
            cboMulta.SelectedIndex = -1;
        }

        protected void CarregarTransferenciaImpostos()
        {
            cboTransferenciaImpostos.DataSource = new ContaContabilDAL().GetCombo();
            cboTransferenciaImpostos.DisplayMember = "Text";
            cboTransferenciaImpostos.ValueMember = "iValue";
            cboTransferenciaImpostos.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            pc = new PerfilCliente();
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

                    pc.Nome = txtNome.Text;
                    pc.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboRelacaoGrupo.Text))
                        pc.RelacaoGrupo = Convert.ToInt32(cboRelacaoGrupo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCliente.Text))
                        pc.IdCliente = Convert.ToInt32(cboCliente.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoCliente.Text))
                        pc.IdGrupoCliente = Convert.ToInt32(cboGrupoCliente.SelectedValue);

                    if (!String.IsNullOrEmpty(cboConta.Text))
                        pc.IdContaContabil = Convert.ToInt32(cboConta.SelectedValue);
                    if (!String.IsNullOrEmpty(cboLiquidar.Text))
                        pc.IdContaContabilLiquidar = Convert.ToInt32(cboLiquidar.SelectedValue);
                    else
                        pc.IdContaContabilLiquidar = null;

                    if (!String.IsNullOrEmpty(cboPagamentoAntecipado.Text))
                        pc.IdContaContabilPagamentoAntecipado = Convert.ToInt32(cboPagamentoAntecipado.SelectedValue);
                    else
                        pc.IdContaContabilPagamentoAntecipado = null;

                    if (!String.IsNullOrEmpty(cboDesconto.Text))
                        pc.IdContaContabilDesconto = Convert.ToInt32(cboDesconto.SelectedValue);
                    else
                        pc.IdContaContabilDesconto = null;

                    if (!String.IsNullOrEmpty(cboBaixa.Text))
                        pc.IdContaContabilBaixa = Convert.ToInt32(cboBaixa.SelectedValue);
                    else
                        pc.IdContaContabilBaixa = null;

                    if (!String.IsNullOrEmpty(cboJuros.Text))
                        pc.IdContaContabilJuros = Convert.ToInt32(cboJuros.SelectedValue);
                    else
                        pc.IdContaContabilJuros = null;

                    if (!String.IsNullOrEmpty(cboMulta.Text))
                        pc.IdContaContabilMulta = Convert.ToInt32(cboMulta.SelectedValue);
                    else
                        pc.IdContaContabilMulta = null;

                    if (!String.IsNullOrEmpty(cboTransferenciaImpostos.Text))
                        pc.IdContaContabilTransferenciaImposto = Convert.ToInt32(cboTransferenciaImpostos.SelectedValue);
                    else
                        pc.IdContaContabilTransferenciaImposto = null;

                    pc.Baixa = chkBaixa.Checked;

                    if (pc.IdPerfilCliente == 0)
                    {
                        dal.Insert(pc);
                    }
                    else
                    {
                        dal.Update(pc);
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
                    int id = pc.IdPerfilCliente;
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

        private void cboRelacaoGrupo_Leave(object sender, EventArgs e)
        {
            int grupo = 0;
            if (!String.IsNullOrEmpty(cboRelacaoGrupo.Text))
                grupo = Convert.ToInt32(cboRelacaoGrupo.SelectedValue);

            cboCliente.Tag = "1";
            cboGrupoCliente.Tag = "1";

            if (grupo == 1) //Grupo
            {
                cboCliente.Tag = "";
            }
            else if (grupo == 2) // Tabela
            {
                cboGrupoCliente.Tag = "";
            }
            else if (grupo == 3) // Todos
            {
                cboCliente.Tag = "";
                cboGrupoCliente.Tag = "";
            }
        }
    }
}