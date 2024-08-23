using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.Models;
using ERP.DAL;

namespace ERP 
{
    public partial class frmGrupoRoteiroLinhas : RibbonForm
    {
        public GrupoRoteiroLinhaDAL dal = new GrupoRoteiroLinhaDAL();
        GrupoRoteiroLinha ci = new GrupoRoteiroLinha();

        public frmGrupoRoteiroLinhas(GrupoRoteiroLinha pci)
        {
            ci = pci;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmConfGrupoImpostoRetidoCad_Load(object sender, EventArgs e)
        {
            CarregaCombo();
            CarregaDados();
        }

        private void CarregaDados()
        {
            cboTipo.SelectedValue = ci.TipoRoteiroTrabalho == null ? 0 : ci.TipoRoteiroTrabalho;
            chkAtivacao.Checked = ci.Ativacao;
            chkCapacidade.Checked = ci.Capacidade;
            chkGerenciamentoTrabalho.Checked = ci.GerenciamentoTrabalho;
            chkHorarioTrabalho.Checked = ci.HorarioTrabalho;
        }

        private void CarregaCombo()
        {
           
            List<ComboItem> tipos = new List<ComboItem>();
            tipos.Add(new ComboItem() { iValue = 1, Text = "Fila antes"});
            tipos.Add(new ComboItem() { iValue = 2, Text = "Instalação"});
            tipos.Add(new ComboItem() { iValue = 3, Text = "Processar"});
            tipos.Add(new ComboItem() { iValue = 4, Text = "Sobrepor"});
            tipos.Add(new ComboItem() { iValue = 5, Text = "Transporte"});
            tipos.Add(new ComboItem() { iValue = 6, Text = "Fila Depois"});
            tipos.Add(new ComboItem() { iValue = 7, Text = "Custo Indireto"});
            cboTipo.DataSource = tipos;
            cboTipo.DisplayMember = "Text";
            cboTipo.ValueMember = "iValue";
            cboTipo.SelectedIndex = -1;
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            if(Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    if(!String.IsNullOrEmpty(cboTipo.Text)) ci.TipoRoteiroTrabalho = Convert.ToInt32(cboTipo.SelectedValue);
                    ci.Ativacao = chkAtivacao.Checked;
                    ci.Capacidade = chkCapacidade.Checked;
                    ci.GerenciamentoTrabalho = chkGerenciamentoTrabalho.Checked;
                    ci.HorarioTrabalho = chkHorarioTrabalho.Checked;


                    if (ci.IdGrupoRoteiroLinha == 0)
                    {
                        dal.Insert(ci);
                    }
                    else
                    {
                        dal.Update(ci);
                    }
                    dal.Save();
                    this.Close();
                }
                catch
                {
                    Util.Aplicacao.ShowMessage("Verifique os dados informados");
                }
            } 
        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
            if(Util.Aplicacao.ShowQuestionMessage("Deseja remover a configuração?") == System.Windows.Forms.DialogResult.Yes)
            {
                dal.Delete(ci.IdGrupoRoteiroLinha);
                dal.Save();
                this.Close();
            }
        }
    }
}
