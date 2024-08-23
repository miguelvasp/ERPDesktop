using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmRecursoCad : RibbonForm
    {
        public RecursosDAL dal = new RecursosDAL();
        Recursos r = new Recursos();

        public frmRecursoCad(Recursos pR)
        {
            r = pR;
            InitializeComponent();
        }

        public frmRecursoCad() { InitializeComponent(); }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmAutoridadeCad_Load(object sender, EventArgs e)
        {
            CarregaCombos();

            if (r.IdRecurso == 0)
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

            cboContaContabilContaPartidaWIP.DataSource = new ContaContabilDAL().GetCombo();
            cboContaContabilContaPartidaWIP.DisplayMember = "Text";
            cboContaContabilContaPartidaWIP.ValueMember = "iValue";
            cboContaContabilContaPartidaWIP.SelectedIndex = -1;

            cboContaContabilContraCusto.DataSource = new ContaContabilDAL().GetCombo();
            cboContaContabilContraCusto.DisplayMember = "Text";
            cboContaContabilContraCusto.ValueMember = "iValue";
            cboContaContabilContraCusto.SelectedIndex = -1;

            cboContaContabilCusto.DataSource = new ContaContabilDAL().GetCombo();
            cboContaContabilCusto.DisplayMember = "Text";
            cboContaContabilCusto.ValueMember = "iValue";
            cboContaContabilCusto.SelectedIndex = -1;

            cboContaContabilWIP.DataSource = new ContaContabilDAL().GetCombo();
            cboContaContabilWIP.DisplayMember = "Text";
            cboContaContabilWIP.ValueMember = "iValue";
            cboContaContabilWIP.SelectedIndex = -1;

            cboFuncionario.DataSource = new FuncionarioDAL().GetCombo();
            cboFuncionario.DisplayMember = "Text";
            cboFuncionario.ValueMember = "iValue";
            cboFuncionario.SelectedIndex = -1;

            cboGrupoRoteiro.DataSource = new GrupoRoteiroDAL().GetCombo();
            cboGrupoRoteiro.DisplayMember = "Text";
            cboGrupoRoteiro.ValueMember = "iValue";
            cboGrupoRoteiro.SelectedIndex = -1;

            cboLocalProducao.DataSource = new LocalProducaoDAL().GetCombo();
            cboLocalProducao.DisplayMember = "Text";
            cboLocalProducao.ValueMember = "iValue";
            cboLocalProducao.SelectedIndex = -1; 

            List<ComboItem> tipos = new List<ComboItem>();
            tipos.Add(new ComboItem() { iValue = 1, Text = "Maquina"});
            tipos.Add(new ComboItem() { iValue = 2, Text = "Fornecedor"});
            tipos.Add(new ComboItem() { iValue = 3, Text = "Ferramenta"});
            tipos.Add(new ComboItem() { iValue = 4, Text = "Recursos humanos"});
            tipos.Add(new ComboItem() { iValue = 5, Text = "Localização"});
            cboTipo.DataSource = tipos;
            cboTipo.DisplayMember = "Text";
            cboTipo.ValueMember = "iValue";
            cboTipo.SelectedIndex = -1;

            List<ComboItem> Unidades = new List<ComboItem>();
            Unidades.Add(new ComboItem() { iValue = 1, Text = "Batidas/horas" });
            Unidades.Add(new ComboItem() { iValue = 2, Text = "Metros/horas" });
            Unidades.Add(new ComboItem() { iValue = 3, Text = "Dados/Horas" });
            cboUnidadeCapacidade.DataSource = Unidades;
            cboUnidadeCapacidade.DisplayMember = "Text";
            cboUnidadeCapacidade.ValueMember = "iValue";
            cboUnidadeCapacidade.SelectedIndex = -1;
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
            cboContaContabilContaPartidaWIP.SelectedValue = r.IdContaContabilContaPartidaWIP == null ? 0 : r.IdContaContabilContaPartidaWIP;
            cboContaContabilContraCusto.SelectedValue = r.IdContaContabilContraCusto == null ? 0 : r.IdContaContabilContraCusto;
            cboContaContabilCusto.SelectedValue = r.IdContaContabilCusto == null ? 0 : r.IdContaContabilCusto;
            cboContaContabilWIP.SelectedValue = r.IdContaContabilWIP == null ? 0 : r.IdContaContabilWIP;
            cboFuncionario.SelectedValue = r.IdFuncionario == null ? 0 : r.IdFuncionario;
            cboGrupoRoteiro.SelectedValue = r.IdGrupoRoteiro == null ? 0 : r.IdGrupoRoteiro;
            cboLocalProducao.SelectedValue = r.IdLocalProducao == null ? 0 : r.IdLocalProducao;
            cboTipo.SelectedValue = r.Tipo == null ? 0 : r.Tipo;
            cboUnidadeCapacidade.SelectedValue = r.UnidadeCapacidade == null ? 0 : r.UnidadeCapacidade;
            chkCapacidadeFinita.Checked = Convert.ToBoolean(r.CapacidadeFinita);
            chkExclusivo.Checked = Convert.ToBoolean(r.Exclusivo);
            chkPropriedadeFinita.Checked = Convert.ToBoolean(r.PropriedadeFinita);
            txtCapacidade.Text = r.Capacidade == null ? "" : r.Capacidade.ToString();
            txtCapacidadeLote.Text = r.CapacidadeLote == null ? "" : r.CapacidadeLote.ToString();
            txtDescricao.Text = r.Descricao == null ? "" : r.Descricao;
            txtHorasTempo.Text = r.HorasTempo == null ? "" : r.HorasTempo.ToString();
            txtPorcentagemEficiencia.Text = r.PorcentagemEficiencia == null ? "" : r.PorcentagemEficiencia.ToString();
            txtPorcentagemPlanoOperacao.Text = r.PorcentagemPlanoOperacao == null ? "" : r.PorcentagemPlanoOperacao.ToString();
            txtPorcentagemSucata.Text = r.PorcentagemSucata == null ? "" : r.PorcentagemSucata.ToString();
            txtTempoEsperaAnterior.Text = r.TempoEsperaAnterior == null ? "" : r.TempoEsperaAnterior.ToString();
            txtTempoEsperaPosterior.Text = r.TempoEsperaPosterior == null ? "" : r.TempoEsperaPosterior.ToString();
            txtTempoExecusao.Text = r.TempoExecusao == null ? "" : r.TempoExecusao.ToString();
            txtTempoPreparacao.Text = r.TempoPreparacao == null ? "" : r.TempoPreparacao.ToString();
            txtTempoTransito.Text = r.TempoTransito == null ? "" : r.TempoTransito.ToString();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

       
        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            r = new Recursos(); 
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
                    r.Capacidade = null; 
                    r.CapacidadeLote = null;
                    r.Descricao = null; 
                    r.HorasTempo = null;
                    r.UnidadeCapacidade = null;
                    r.IdContaContabilContaPartidaWIP = null;
                    r.IdContaContabilContraCusto = null;
                    r.IdContaContabilCusto = null;
                    r.IdContaContabilWIP = null;
                    r.IdFuncionario = null;
                    r.IdGrupoRoteiro = null;
                    r.IdLocalProducao = null;
                    r.Tipo = null;
                    r.PorcentagemEficiencia = null;
                    r.PorcentagemPlanoOperacao = null;
                    r.PorcentagemSucata = null; 
                    r.TempoEsperaAnterior = null;
                    r.TempoEsperaPosterior = null;
                    r.TempoExecusao = null;
                    r.TempoPreparacao = null;
                    r.TempoTransito = null;

                    if (!String.IsNullOrEmpty(cboContaContabilContaPartidaWIP.Text)) r.IdContaContabilContaPartidaWIP = Convert.ToInt32(cboContaContabilContaPartidaWIP.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContaContabilContraCusto.Text)) r.IdContaContabilContraCusto = Convert.ToInt32(cboContaContabilContraCusto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContaContabilCusto.Text)) r.IdContaContabilCusto = Convert.ToInt32(cboContaContabilCusto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContaContabilWIP.Text)) r.IdContaContabilWIP = Convert.ToInt32(cboContaContabilWIP.SelectedValue);
                    if (!String.IsNullOrEmpty(cboFuncionario.Text)) r.IdFuncionario = Convert.ToInt32(cboFuncionario.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoRoteiro.Text)) r.IdGrupoRoteiro = Convert.ToInt32(cboGrupoRoteiro.SelectedValue);
                    if (!String.IsNullOrEmpty(cboLocalProducao.Text)) r.IdLocalProducao = Convert.ToInt32(cboLocalProducao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipo.Text)) r.Tipo = Convert.ToInt32(cboTipo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboUnidadeCapacidade.Text)) r.UnidadeCapacidade = Convert.ToInt32(cboUnidadeCapacidade.SelectedValue);
                    if (!String.IsNullOrEmpty(txtCapacidade.Text)) r.Capacidade = Convert.ToDecimal(txtCapacidade.Text);
                    if (!String.IsNullOrEmpty(txtCapacidadeLote.Text)) r.CapacidadeLote = Convert.ToDecimal(txtCapacidadeLote.Text);
                    if (!String.IsNullOrEmpty(txtDescricao.Text)) r.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(txtHorasTempo.Text)) r.HorasTempo = Convert.ToInt32(txtHorasTempo.Text);
                    if (!String.IsNullOrEmpty(txtPorcentagemEficiencia.Text)) r.PorcentagemEficiencia = Convert.ToDecimal(txtPorcentagemEficiencia.Text);
                    if (!String.IsNullOrEmpty(txtPorcentagemPlanoOperacao.Text)) r.PorcentagemPlanoOperacao = Convert.ToDecimal(txtPorcentagemPlanoOperacao.Text);
                    if (!String.IsNullOrEmpty(txtPorcentagemSucata.Text)) r.PorcentagemSucata = Convert.ToInt32(txtPorcentagemSucata.Text);
                    if (!String.IsNullOrEmpty(txtTempoEsperaAnterior.Text)) r.TempoEsperaAnterior = Convert.ToInt32(txtTempoEsperaAnterior.Text);
                    if (!String.IsNullOrEmpty(txtTempoEsperaPosterior.Text)) r.TempoEsperaPosterior = Convert.ToInt32(txtTempoEsperaPosterior.Text);
                    if (!String.IsNullOrEmpty(txtTempoExecusao.Text)) r.TempoExecusao = Convert.ToInt32(txtTempoExecusao.Text);
                    if (!String.IsNullOrEmpty(txtTempoPreparacao.Text)) r.TempoPreparacao = Convert.ToInt32(txtTempoPreparacao.Text);
                    if (!String.IsNullOrEmpty(txtTempoTransito.Text)) r.TempoTransito = Convert.ToInt32(txtTempoTransito.Text);
                    chkCapacidadeFinita.Checked = r.CapacidadeFinita;
                    chkExclusivo.Checked = r.Exclusivo;
                    chkPropriedadeFinita.Checked = r.PropriedadeFinita;

                    if (r.IdRecurso == 0)
                    {
                        dal.Insert(r);
                    }
                    else
                    {
                        dal.Update(r);
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
                int id = r.IdRecurso;
                dal.Delete(id);
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                this.Close();
            }
        }

        
    }
}

