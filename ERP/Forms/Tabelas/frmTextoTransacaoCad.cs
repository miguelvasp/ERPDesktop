using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmTextoTransacaoCad : RibbonForm
    {
        public TextoTransacaoDAL dal;
        TextoTransacao tp = new TextoTransacao();

        public frmTextoTransacaoCad(TextoTransacao pTP)
        {
            tp = pTP;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmTextoTransacaoCad_Load(object sender, EventArgs e)
        {  
            cboOrigem.DataSource = dal.GetComboOrigemLancamento();
            cboOrigem.ValueMember = "iValue";
            cboOrigem.DisplayMember = "Text";
            cboOrigem.SelectedIndex = -1;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dal.GetTextoTransacaoSubs();

            if (tp.IdTextoTransacao == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            } 
        } 

        private void CarregaDados()
        { 

            cboOrigem.SelectedValue = tp.IdOrigemLancamento == null ? 0 : tp.IdOrigemLancamento;
            txtTexto.Text = tp.Texto;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
             
        }
         

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            tp = new TextoTransacao(); 
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
                    tp.IdOrigemLancamento = Convert.ToInt32(cboOrigem.SelectedValue);
                    tp.Texto = txtTexto.Text;

                    if (tp.IdTextoTransacao == 0)
                    {
                        dal.Insert(tp);
                    }
                    else
                    {
                        dal.Update(tp);
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
                    int id = tp.IdTextoTransacao;
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
    }
}