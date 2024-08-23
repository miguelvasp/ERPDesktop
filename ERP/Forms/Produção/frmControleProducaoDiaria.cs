using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.DAL;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using ERP.ModelView;

namespace ERP.Forms.Produção
{
    public partial class frmControleProducaoDiaria : Form
    {
        DateTime dtSelecionada = DateTime.Now;
        OrdemProducaoDAL dal = new OrdemProducaoDAL();
        List<ControleProducaoModelView> clist = new List<ControleProducaoModelView>();
        public frmControleProducaoDiaria()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void frmControleProducaoDiaria_Load(object sender, EventArgs e)
        {
            cboStatus.DataSource = dal.getStatus();
            cboStatus.ValueMember = "iValue";
            cboStatus.DisplayMember = "Text";
            cboStatus.SelectedIndex = 1;

            cboLocalProducao.DataSource = new LocalProducaoDAL().GetCombo();
            cboLocalProducao.DisplayMember = "Text";
            cboLocalProducao.ValueMember = "iValue";
            cboLocalProducao.SelectedIndex = -1;

            CarregaGrid2();
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            CarregaGrid2();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmGeraOP frmg = new frmGeraOP(); 
            frmg.ShowDialog();
            CarregaGrid2();
        }

        private void CarregaGrid2()
        {
            try
            {
                clist.Clear();
                DateTime diaSelecionado = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString() + " 00:00");
                DateTime d0 = diaSelecionado;
                DateTime d1 = diaSelecionado.AddDays(0);
                DateTime d2 = diaSelecionado.AddDays(1);
                DateTime d3 = diaSelecionado.AddDays(2);
                DateTime d4 = diaSelecionado.AddDays(3);
                DateTime d5 = Convert.ToDateTime(diaSelecionado.AddDays(4).ToShortDateString() + " 23:59");
                int Local = string.IsNullOrEmpty(cboLocalProducao.Text) ? 0 : Convert.ToInt32(cboLocalProducao.SelectedValue);
                
                var lista = new OrdemProducaoDAL().getCalendar(d0, d5, Convert.ToInt32(cboStatus.SelectedValue), Local);

                dataGridView2.Columns[1].HeaderText = d1.ToShortDateString() + "\n\r" + d1.ToString("dddd");
                dataGridView2.Columns[2].HeaderText = d2.ToShortDateString() + "\n\r" + d2.ToString("dddd");
                dataGridView2.Columns[3].HeaderText = d3.ToShortDateString() + "\n\r" + d3.ToString("dddd");
                dataGridView2.Columns[4].HeaderText = d4.ToShortDateString() + "\n\r" + d4.ToString("dddd");
                dataGridView2.Columns[5].HeaderText = d5.ToShortDateString() + "\n\r" + d5.ToString("dddd");

                var listagrid = new OrdemProducaoDAL().getByParams(0, 0, 1);
                dataGridView1.Rows.Clear();
                foreach (var v in listagrid.Select(x => new { x.IdOrdemProducao, x.NomePlano, x.NumeroOP, x.Cor }).Distinct().ToList()) 
                {
                    string[] row = new string[] { v.IdOrdemProducao.ToString(), v.NumeroOP.ToString() + "-" + v.NomePlano + " " + v.Cor };
                    dataGridView1.Rows.Add(row);
                }

                List<int> horas = new List<int>() {  6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };


                foreach (int h in horas)
                {

                    string dt = d1.ToShortDateString();
                    foreach (var i in lista.Where(x => x.Hora == h && x.dtstr == dt).ToList())
                    {
                        ControleProducaoModelView c = new ControleProducaoModelView();
                        c.hora = h.ToString();
                        c.d1 = "Op " + i.NumeroOP.ToString() + "\n\r Plano: " + i.NomePlano + " " + i.Cor + "\n\r Local: " + i.Local;
                        clist.Add(c);
                    }
                    dt = d2.ToShortDateString();
                    foreach (var i in lista.Where(x => x.Hora == h && x.dtstr == dt).ToList())
                    {
                        ControleProducaoModelView c = new ControleProducaoModelView();
                        c.hora = h.ToString();
                        c.d2 = "Op " + i.NumeroOP.ToString() + "\n\r Plano: " + i.NomePlano + " " + i.Cor + "\n\r Local: " + i.Local;
                        clist.Add(c);
                    }
                    dt = d3.ToShortDateString();
                    foreach (var i in lista.Where(x => x.Hora == h && x.dtstr == dt).ToList())
                    {
                        ControleProducaoModelView c = new ControleProducaoModelView();
                        c.hora = h.ToString();
                        c.d3 = "Op " + i.NumeroOP.ToString() + "\n\r Plano: " + i.NomePlano + " " + i.Cor + "\n\r Local: " + i.Local;
                        clist.Add(c);
                    }
                    dt = d4.ToShortDateString();
                    foreach (var i in lista.Where(x => x.Hora == h && x.dtstr == dt).ToList())
                    {
                        ControleProducaoModelView c = new ControleProducaoModelView();
                        c.hora = h.ToString();
                        c.d4 = "Op " + i.NumeroOP.ToString() + "\n\r Plano: " + i.NomePlano + " " + i.Cor + "\n\r Local: " + i.Local;
                        clist.Add(c);
                    }
                    dt = d5.ToShortDateString();
                    foreach (var i in lista.Where(x => x.Hora == h && x.dtstr == dt).ToList())
                    {
                        ControleProducaoModelView c = new ControleProducaoModelView();
                        c.hora = h.ToString();
                        c.d5 = "Op " + i.NumeroOP.ToString() + "\n\r Plano: " + i.NomePlano + " " + i.Cor + "\n\r Local: " + i.Local;
                        clist.Add(c);
                    }
                }

                List<ControleProducaoModelView> grupo = new List<ControleProducaoModelView>();

                foreach (int h in horas)
                {
                    string sh = h.ToString();
                    int contagem = 0;
                    int max = 0;
                    contagem = clist.Where(x => x.hora == sh && x.d1 != null).Count();
                    max = contagem > max ? contagem : max;

                    contagem = clist.Where(x => x.hora == sh && x.d2 != null).Count();
                    max = contagem > max ? contagem : max;

                    contagem = clist.Where(x => x.hora == sh && x.d3 != null).Count();
                    max = contagem > max ? contagem : max;

                    contagem = clist.Where(x => x.hora == sh && x.d4 != null).Count();
                    max = contagem > max ? contagem : max;

                    contagem = clist.Where(x => x.hora == sh && x.d5 != null).Count();
                    max = contagem > max ? contagem : max;

                    if (max == 0)
                    {
                        ControleProducaoModelView c = new ControleProducaoModelView();
                        c.hora = getHora(h);
                        c.h = h;
                        c.d1 = " \n\r \n\r ";
                        grupo.Add(c);
                    }
                    else
                    {
                        var gd1 = clist.Where(x => x.hora == sh && x.d1 != null).Select(x => x.d1).Distinct().ToList();
                        var gd2 = clist.Where(x => x.hora == sh && x.d2 != null).Select(x => x.d2).Distinct().ToList();
                        var gd3 = clist.Where(x => x.hora == sh && x.d3 != null).Select(x => x.d3).Distinct().ToList();
                        var gd4 = clist.Where(x => x.hora == sh && x.d4 != null).Select(x => x.d4).Distinct().ToList();
                        var gd5 = clist.Where(x => x.hora == sh && x.d5 != null).Select(x => x.d5).Distinct().ToList();
                        for (int i = 0; i < max; i++)
                        {
                            ControleProducaoModelView c = new ControleProducaoModelView();
                            c.hora = h.ToString();
                            c.hora = getHora(h);
                            c.d1 = gd1.Count >= i + 1 ? gd1[i] : "";
                            c.d2 = gd2.Count >= i + 1 ? gd2[i] : "";
                            c.d3 = gd3.Count >= i + 1 ? gd3[i] : "";
                            c.d4 = gd4.Count >= i + 1 ? gd4[i] : "";
                            c.d5 = gd5.Count >= i + 1 ? gd5[i] : "";
                            if (!string.IsNullOrEmpty(c.d1) || !string.IsNullOrEmpty(c.d2) || !string.IsNullOrEmpty(c.d3) || !string.IsNullOrEmpty(c.d4) || !string.IsNullOrEmpty(c.d5))
                            {
                                grupo.Add(c);
                            }
                        }
                    }


                    var item = clist.Where(x => x.hora == sh).ToList();
                }


                dataGridView2.AutoGenerateColumns = false; 
                dataGridView2.DataSource = grupo; 

            }
            catch (Exception ex)
            {
                 
            } 
        }
 

        private string getHora(int hora)
        {
            if(hora < 10)
            {
                return "0" + hora.ToString() + ":00";
            }
            else
            {
                return hora.ToString() + ":00";
            }
        }

       



        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(cboStatus.Text))
            {
                CarregaGrid2();
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show((sender as Button).Tag.ToString());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CarregaGrid2();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string op = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (!string.IsNullOrEmpty(op))
                {
                    op = op.Replace("Op ", "");
                    int punto = op.IndexOf("P");
                    op = op.Substring(0, punto);
                    int Id = Convert.ToInt32(op);
                    var o = dal.getByNumeroOp(Id);
                    if (o.StatusProducao == 5 || o.StatusProducao == 6)
                    {
                        Util.Aplicacao.ShowMessage("A Ordem de produção não pode ser alterada!");
                    }
                    else
                    {
                        frmAlteraProducao frma = new frmAlteraProducao(o, dal);
                        frma.dal = dal;
                        frma.ShowDialog();
                        CarregaGrid2();
                    }
                }
            }
            catch 
            {
                 
            } 
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                var o = dal.GetByID(id);
                if (o.StatusProducao == 5 || o.StatusProducao == 6)
                {
                    Util.Aplicacao.ShowMessage("A Ordem de produção não pode ser alterada!");
                }
                else
                {
                    frmAlteraProducao frma = new frmAlteraProducao(o, dal);
                    frma.dal = dal;
                    frma.ShowDialog();
                    CarregaGrid2();
                }
            }
            catch
            {

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CarregaGrid2();
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dataGridView2);
        }

        private void cboLocalProducao_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaGrid2();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CarregaGrid2();
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if(e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            //{
            //    dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.SkyBlue;
            //}
        }
    }
}
