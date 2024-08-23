using ERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Forms.ReportsTool
{
    public partial class frmAddFiltro : Form
    {
        public frmAddFiltro()
        {
            InitializeComponent();
        }

        private void frmAddFiltro_Load(object sender, EventArgs e)
        {
            List<ComboItem> itens = new List<ComboItem>();
            itens.Add(new ComboItem() { Value = ">", Text = "Maior que..." });
            itens.Add(new ComboItem() { Value = ">=", Text = "Maior ou igual que..." });
            itens.Add(new ComboItem() { Value = "=", Text = "Igual a..." });
            itens.Add(new ComboItem() { Value = "<", Text = "Menor que..." });
            itens.Add(new ComboItem() { Value = "<=", Text = "Menor ou igual que..." });
            itens.Add(new ComboItem() { Value = "<>", Text = "Diferente de..." });
            comboBox1.DataSource = itens;
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
            comboBox1.SelectedIndex = -1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
