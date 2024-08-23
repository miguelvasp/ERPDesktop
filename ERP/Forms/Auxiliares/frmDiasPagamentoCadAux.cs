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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Auxiliares
{
    public partial class frmDiasPagamentoCadAux : RibbonForm
    {
        public DiasPagamentoItemDAL dal = new DiasPagamentoItemDAL();
        DiasPagamentoItem di = new DiasPagamentoItem();


        public frmDiasPagamentoCadAux(DiasPagamentoItem dPgto)
        {
            di = dPgto;
            InitializeComponent();
            CarregarDiaSemana();
            CarregarSemanaMes();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmDiasPagamentoCad_Load(object sender, EventArgs e)
        {
            if (di.IdDiasPagamentoItem == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void frmDiasPagamentoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            cboDiaSemana.SelectedValue = di.DiaSemana == null? 0: Convert.ToInt32(di.DiaSemana);
            cboSemanaMes.SelectedValue = di.SemanaMes == null ? 0 : Convert.ToInt32(di.SemanaMes);
            txtDiaMes.Text = di.DiaMes == null ? "" : di.DiaMes.ToString();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            di = new DiasPagamentoItem(); 
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            cboDiaSemana.Tag = "";
            txtDiaMes.Tag = "";
            if (!String.IsNullOrEmpty(cboSemanaMes.Text))
            {
                if (cboSemanaMes.SelectedValue.ToString() == "1")
                {
                    txtDiaMes.Tag = "1";
                }
                else
                {
                    cboDiaSemana.Tag = "1";
                }
            }

            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    di.DiaSemana = null;
                    di.DiaMes = null;
                    if (!String.IsNullOrEmpty(cboSemanaMes.Text))
                        di.SemanaMes = Convert.ToInt32(cboSemanaMes.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDiaSemana.Text))
                        di.DiaSemana = Convert.ToInt32(cboDiaSemana.SelectedValue);
                    if(!String.IsNullOrEmpty(txtDiaMes.Text)) di.DiaMes = Convert.ToInt32(txtDiaMes.Text);

                    if (di.IdDiasPagamentoItem == 0)
                    {
                        dal.Insert(di);
                    }
                    else
                    {
                        dal.Update(di);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    this.Close(); 
                } 
                catch(Exception ex)
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
                try
                {
                    int id = di.IdDiasPagamentoItem;

                    dal.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    this.Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
            }
        }

        private void CarregarDiaSemana()
        {
            List<ComboItem> lista = new List<ComboItem>();
            lista.Add(new ComboItem() { iValue = 1, Text = "Segunda-feira" });
            lista.Add(new ComboItem() { iValue = 2, Text = "Terça-feira" });
            lista.Add(new ComboItem() { iValue = 3, Text = "Quarta-feira" });
            lista.Add(new ComboItem() { iValue = 4, Text = "Quinta-feira" });
            lista.Add(new ComboItem() { iValue = 5, Text = "Sexta-feira" });
            lista.Add(new ComboItem() { iValue = 6, Text = "Sábado-feira" });
            lista.Add(new ComboItem() { iValue = 7, Text = "Domingo-feira" });

            cboDiaSemana.DisplayMember = "Text";
            cboDiaSemana.ValueMember = "iValue";
            cboDiaSemana.DataSource = lista;
            cboDiaSemana.SelectedIndex = -1;
        }

        private void CarregarSemanaMes()
        {
            List<ComboItem> lista = new List<ComboItem>();
            lista.Add(new ComboItem() { iValue = 1, Text = "Dias" });
            lista.Add(new ComboItem() { iValue = 2, Text = "Semana" });
            cboSemanaMes.DisplayMember = "Text";
            cboSemanaMes.ValueMember = "iValue";
            cboSemanaMes.DataSource = lista;
            cboSemanaMes.SelectedIndex = -1;
        }

        private void txtDiaMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
