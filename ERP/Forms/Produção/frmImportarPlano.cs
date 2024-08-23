using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.DAL;


namespace ERP.Forms.Produção
{
    public partial class frmImportarPlano : Form
    {
        PlanoProducaoDAL dal = new PlanoProducaoDAL();
        int IdPlano;
        public frmImportarPlano(int pIdPlano)
        {
            IdPlano = pIdPlano;
            InitializeComponent();
        }

        private void frmImportarPlano_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = dal.getCombo();
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "iValue";
            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(comboBox1.Text))
            {
                int idOrigem = Convert.ToInt32(comboBox1.SelectedValue);
                if(Util.Aplicacao.ShowQuestionMessage("Confirma a importação dos dados?") == DialogResult.Yes)
                {
                    dal.ImportaDados(idOrigem, IdPlano);
                    this.Close();
                }
            }
        }
    }
}
