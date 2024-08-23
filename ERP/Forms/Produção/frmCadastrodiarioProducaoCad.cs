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
    public partial class frmCadastrodiarioProducaoCad : RibbonForm
    {
        public CadastroDiarioProducaoDAL dal = new CadastroDiarioProducaoDAL();
        CadastroDiarioProducao c = new CadastroDiarioProducao();

        public frmCadastrodiarioProducaoCad(CadastroDiarioProducao pC)
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
            List<ComboItem> tipos = new List<ComboItem>();
            tipos.Add(new ComboItem() { iValue = 1, Text = "Lista de Separação"});
            tipos.Add(new ComboItem() { iValue = 2, Text = "Relatorio de Conclusão"});
            tipos.Add(new ComboItem() { iValue = 3, Text = "Cartão de Roteiro"});
            tipos.Add(new ComboItem() { iValue = 4, Text = "Ficha de Trabalho"});
            tipos.Add(new ComboItem() { iValue = 5, Text = "Coprodutos"});
            cboTipo.DataSource = tipos;
            cboTipo.DisplayMember = "Text";
            cboTipo.ValueMember = "iValue";
            cboTipo.SelectedIndex = -1;

            if (c.IdCadastroDiarioProducao == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
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
            txtNomeDiario.Text = c.NomeDiario;
            txtSequenciaComprovante.Text = c.IdSequenciaComprovante.ToString();
            txtSequenciaDiario.Text = c.IdSequenciaDiario.ToString();
            cboTipo.SelectedValue = c.TipoDiario == null ? 0 : c.TipoDiario;
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            c = new CadastroDiarioProducao(); 
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
                    c.TipoDiario = null;
                    c.IdSequenciaDiario = null;
                    c.IdSequenciaComprovante = null;

                    if (!String.IsNullOrEmpty(txtSequenciaDiario.Text)) c.IdSequenciaDiario = Convert.ToInt32(txtSequenciaDiario.Text);
                    if (!String.IsNullOrEmpty(txtSequenciaComprovante.Text)) c.IdSequenciaComprovante = Convert.ToInt32(txtSequenciaComprovante.Text);
                    if (!String.IsNullOrEmpty(cboTipo.Text)) c.TipoDiario = Convert.ToInt32(cboTipo.SelectedValue);
                    c.NomeDiario = txtNomeDiario.Text;
                    if (c.IdCadastroDiarioProducao == 0)
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
                int id = c.IdCadastroDiarioProducao;
                dal.Delete(id); 
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
        }

    }
}

