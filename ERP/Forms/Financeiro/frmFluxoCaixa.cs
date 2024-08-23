using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.DAL;

namespace ERP.Financeiro
{
    public partial class frmFluxoCaixa : Form
    {
        SQLDataLayer sqlDal = new SQLDataLayer();
        FluxoCaixaDAL dal = new FluxoCaixaDAL();
        int IdUsuario = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));


        public frmFluxoCaixa()
        {
            InitializeComponent();
        }

        private void ReorganizaColunas()
        {
            string Tipo = rbPrevisto.Checked ? "P" : "R";
            
            foreach (DataGridViewColumn dc in dataGridView1.Columns)
            {
                dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (dc.Name != "Conta")
                {
                    dc.Width = 90;
                }
                dc.Visible = false;
            }

            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            DateTime dt = DateTime.Now;
            //oculta todos os campos
            if (!rb30Dias.Checked)
            {
                int Contador = 0;
                int qtdeMeses = rb6Meses.Checked ? 6 : 12;
                foreach (DataGridViewColumn dc in dataGridView1.Columns)
                {
                    if (dc.Name != "Conta")
                    {
                        Contador++;
                        if(Contador <= qtdeMeses)
                        {
                            int ano = dt.Year; 
                            int ultimodia = DateTime.DaysInMonth(ano, dt.Month);
                            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(dt.Month));
                            dc.HeaderText = mes + "/" + ano.ToString();
                            dc.Visible = true;
                            dt = new DateTime(ano, dt.Month, 1);
                            sqlDal.AddFluxo(dt, dt.AddMonths(1).AddDays(-1), Contador, Tipo, IdUsuario);
                            dt = dt.AddMonths(1);
                        }
                    }
                    else
                    {
                        dc.Visible = true;
                    }
                }
            }
            else
            {
                int Contador = 0;
                foreach (DataGridViewColumn dc in dataGridView1.Columns)
                {
                    dc.Visible = true;
                    if (dc.Name != "Conta")
                    {
                        Contador++;
                        dc.HeaderText = dt.ToShortDateString(); 
                        sqlDal.AddFluxo(dt, dt, Contador, Tipo, IdUsuario);
                        dt = dt.AddDays(1);
                    }
                }
            }

            //GERA OS TOTAIS
            var dados = sqlDal.CalculaTotais(Convert.ToDecimal(txtSaldo.Text), IdUsuario);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dados;// dal.getByUserId(IdUsuario);
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns["Tipo"].Visible = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                { 

                    if (row.Cells["Tipo"].Value.ToString() == "2")
                    {
                        row.DefaultCellStyle.BackColor = Color.OrangeRed;
                    } 

                    if (row.Cells["Tipo"].Value.ToString() == "5")
                    {
                        row.DefaultCellStyle.BackColor = Color.OrangeRed;
                    }

                    if (row.Cells["Tipo"].Value.ToString() == "6")
                    {
                        row.DefaultCellStyle.BackColor = Color.Gray;
                    }
                }
                catch 
                {
                     
                }
                
            }
                
        }

        private void frmFluxoCaixa_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn dc in dataGridView1.Columns)
            {
                dc.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReorganizaColunas();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dataGridView1);
        }
    }

   
}
