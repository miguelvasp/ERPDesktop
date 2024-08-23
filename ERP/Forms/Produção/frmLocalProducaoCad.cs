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
    public partial class frmLocalProducaoCad : RibbonForm
    {
        public LocalProducaoDAL dal = new LocalProducaoDAL();
        LocalProducao c = new LocalProducao();

        public frmLocalProducaoCad(LocalProducao pC)
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
            if (c.IdLocalProducao == 0)
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
            cboArmazem.DataSource = new ArmazemDAL().GetCombo();
            cboArmazem.DisplayMember = "Text";
            cboArmazem.ValueMember = "iValue";
            cboArmazem.SelectedIndex = -1;

            cboDepositoEntrada.DataSource = new DepositoDAL().GetCombo();
            cboDepositoEntrada.DisplayMember = "Text";
            cboDepositoEntrada.ValueMember = "iValue";
            cboDepositoEntrada.SelectedIndex = -1;

            cboDepositoSaida.DataSource = new DepositoDAL().GetCombo();
            cboDepositoSaida.DisplayMember = "Text";
            cboDepositoSaida.ValueMember = "iValue";
            cboDepositoSaida.SelectedIndex = -1;
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
            cboArmazem.SelectedValue = c.IdArmazem == null ? 0 : c.IdArmazem;
            cboDepositoEntrada.SelectedValue = c.IdDepositoEntrada == null ? 0 : c.IdDepositoEntrada;
            cboDepositoSaida.SelectedValue = c.IdDepositoSaida == null ? 0 : c.IdDepositoSaida;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            c = new LocalProducao(); 
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
                    c.IdArmazem = null;
                    c.IdDepositoEntrada = null;
                    c.IdDepositoSaida = null;

                    c.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboArmazem.Text)) c.IdArmazem = Convert.ToInt32(cboArmazem.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDepositoEntrada.Text)) c.IdDepositoEntrada = Convert.ToInt32(cboDepositoEntrada.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDepositoSaida.Text)) c.IdDepositoSaida = Convert.ToInt32(cboDepositoSaida.SelectedValue);
                    if (c.IdLocalProducao == 0)
                    {
                        dal.Insert(c);
                    }
                    else
                    {
                        dal.Update(c);
                    }

                    dal.Save();
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
                int id = c.IdLocalProducao;
                dal.Delete(id); 
                dal.Save();
                this.Close();
            }
        }
    }
}

