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
    public partial class frmTempoTrabalhoItem : RibbonForm
    {
        public TempoTrabalhoLinhasDAL dal = new TempoTrabalhoLinhasDAL();
        TempoTrabalhoLinhas ti = new TempoTrabalhoLinhas();


        public frmTempoTrabalhoItem(TempoTrabalhoLinhas pTi)
        {
            ti = pTi;
            InitializeComponent(); 
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmDiasPagamentoCad_Load(object sender, EventArgs e)
        {
            CarregarDiaSemana();
            if (ti.IdTempoTrabalhoLinha == 0)
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
            cboDiaSemana.SelectedValue = ti.DiaSemana == null ? 0 : Convert.ToInt32(ti.DiaSemana);
            txtDe.Text = ti.De == null ? "" : ti.De.ToString();
            txtAte.Text = ti.Ate == null ? "" : ti.Ate.ToString();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            ti = new TempoTrabalhoLinhas(); 
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
                     //limpa os valores
                    ti.DiaSemana = null;
                    ti.De = null;
                    ti.Ate = null;

                    if (!String.IsNullOrEmpty(cboDiaSemana.Text)) ti.DiaSemana = Convert.ToInt32(cboDiaSemana.SelectedValue);

                    try
                    {
                        var ta1 = txtDe.Text.Split(':');
                        TimeSpan t1 = new TimeSpan(Convert.ToInt32(ta1[0]), Convert.ToInt32(ta1[1]), 0 );
                        ti.De = t1;
                    }
                    catch
                    {
                        Util.Aplicacao.ShowMessage("Verifique os períodos de tempo.");
                        return;
                    }

                    try
                    {
                        var ta2 = txtAte.Text.Split(':');
                        TimeSpan t2 = new TimeSpan(Convert.ToInt32(ta2[0]), Convert.ToInt32(ta2[1]), 0);
                        ti.Ate = t2;
                    }
                    catch
                    {
                        Util.Aplicacao.ShowMessage("Verifique os períodos de tempo.");
                        return;
                    }


                    if (ti.IdTempoTrabalhoLinha == 0)
                    {
                        dal.Insert(ti);
                    }
                    else
                    {
                        dal.Update(ti);
                    }

                    dal.Save();
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
                    int id = ti.IdTempoTrabalhoLinha;

                    dal.Delete(id);
                    dal.Save();

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

         

        private void txtDiaMes_KeyPress(object sender, KeyPressEventArgs e)
        {
             
        }
    }
}
