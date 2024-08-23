using ERP.DAL;
using ERP.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCalendarioCad : RibbonForm
    {
        public CalendarioDAL dal = new CalendarioDAL();
        CalendarioDataDAL idal = new CalendarioDataDAL();
        Calendario c = new Calendario();

        public frmCalendarioCad(Calendario pC)
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
            if (c.IdCalendario == 0)
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
            txtDescricao.Text = c.Descricao;
            txtPadraoHoras.Text = c.PadraoHoraDiaTrabalho == null ? "" : c.PadraoHoraDiaTrabalho.ToString();
            CarregaGrid();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }



        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            c = new Calendario();
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
                    c.PadraoHoraDiaTrabalho = null;
                    c.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(txtPadraoHoras.Text)) c.PadraoHoraDiaTrabalho = Convert.ToInt32(txtPadraoHoras.Text);

                    if (c.IdCalendario == 0)
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
                int id = c.IdCalendario;
                dal.Delete(id);
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c.IdCalendario == 0)
            {
                Util.Aplicacao.ShowMessage("Salve os dados do calendário antes de adicionar datas.");
                return;
            }

            CalendarioData cd = new CalendarioData();
            cd.IdCalendario = c.IdCalendario;
            frmCalendarioDatas frmdata = new frmCalendarioDatas(cd);
            frmdata.dal = idal;
            frmdata.ShowDialog();
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            var lista = idal.getByCalendarioID(c.IdCalendario).Select(x => new
            {
                IdCalendarioData = x.IdCalendarioData,
                Data = x.Data,
                DiaSemana = x.DiaSemana == null ? "" :
                            x.DiaSemana == 1 ? "Segunda-feira" :
                            x.DiaSemana == 2 ? "Terça-feira" :
                            x.DiaSemana == 3 ? "Quarta-feira" :
                            x.DiaSemana == 4 ? "Quinta-feira" :
                            x.DiaSemana == 5 ? "Sexta-feira" :
                            x.DiaSemana == 6 ? "Sábado" :
                            x.DiaSemana == 7 ? "Domingo" : ""
            }).ToList();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["id"].Value);
                    CalendarioData cd = idal.GetByID(id);
                    cd.IdCalendario = c.IdCalendario;
                    frmCalendarioDatas frmdata = new frmCalendarioDatas(cd);
                    frmdata.dal = idal;
                    frmdata.ShowDialog();
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

