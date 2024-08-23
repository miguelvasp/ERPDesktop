using ERP.Auxiliares;
using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCalendarioDatas : RibbonForm
    {
        public CalendarioDataDAL dal = new CalendarioDataDAL();
        CalendarioData d = new CalendarioData();
        CalendarioDataLinhasDAL idal = new CalendarioDataLinhasDAL();

        public frmCalendarioDatas(CalendarioData pd)
        {
            d = pd;
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
            if (d.IdCalendarioData == 0)
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
            cboDiaSemana.DataSource = new TempoTrabalhoLinhasDAL().GetDiasSemana();
            cboDiaSemana.DisplayMember = "Text";
            cboDiaSemana.ValueMember = "iValue";
            cboDiaSemana.SelectedIndex = -1;

            cboFeriado.DataSource = new FeriadoDAL().GetCombo();
            cboFeriado.DisplayMember = "Text";
            cboFeriado.ValueMember = "iValue";
            cboFeriado.SelectedIndex = -1;

            List<ComboItem> controle = new List<ComboItem>();
            controle.Add(new ComboItem() { iValue = 1, Text = "Fechado" });
            controle.Add(new ComboItem() { iValue = 2, Text = "Em aberto" });
            cboControle.DataSource = controle;
            cboControle.DisplayMember = "Text";
            cboControle.ValueMember = "iValue";
            cboControle.SelectedIndex = -1;
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
            txtData.Text = d.Data.ToString();
            cboDiaSemana.SelectedValue = d.DiaSemana == null ? 0 : d.DiaSemana;
            cboFeriado.SelectedValue = d.IdFeriado == null ? 0 : d.IdFeriado;
            cboControle.SelectedValue = d.Controle == null ? 0 : d.Controle;
            CarregaGrid();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }
        
        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            int? idCalendario = d.IdCalendario;
            d = new CalendarioData();
            d.IdCalendario = idCalendario;
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
                    d.IdFeriado = null;
                    d.DiaSemana = null;
                    d.Controle = null;
                    d.Data = Convert.ToDateTime(txtData.Text);
                    if (!String.IsNullOrEmpty(cboFeriado.Text)) d.IdFeriado = Convert.ToInt32(cboFeriado.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDiaSemana.Text)) d.DiaSemana = Convert.ToInt32(cboDiaSemana.SelectedValue);
                    if (!String.IsNullOrEmpty(cboControle.Text)) d.Controle = Convert.ToInt32(cboControle.SelectedValue);

                    if (d.IdCalendarioData == 0)
                    {
                        dal.Insert(d);
                    }
                    else
                    {
                        dal.Update(d);
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
                try
                {
                    int id = d.IdCalendarioData;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (d.IdCalendarioData == 0)
            {
                Util.Aplicacao.ShowMessage("Salve os dados antes de adicionar itens");
                return;
            }

            CalendarioDataLinhas cd = new CalendarioDataLinhas();
            cd.IdCalendarioData = d.IdCalendarioData;
            frmCalendarioDataLinhas linha = new frmCalendarioDataLinhas(cd);
            linha.dal = idal;
            linha.ShowDialog();
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            var lista = idal.GetByDataId(d.IdCalendarioData);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value);
                    CalendarioDataLinhas cd = idal.GetByID(id);
                    cd.IdCalendarioData = d.IdCalendarioData;
                    frmCalendarioDataLinhas linha = new frmCalendarioDataLinhas(cd);
                    linha.dal = idal;
                    linha.ShowDialog();
                    CarregaGrid();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }
    }
}

