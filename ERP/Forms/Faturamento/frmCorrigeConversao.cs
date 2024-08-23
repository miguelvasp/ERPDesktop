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

namespace ERP.Forms.Faturamento
{
    public partial class frmCorrigeConversao : Form
    {
        public List<vwDanfe> dados;
        public frmCorrigeConversao(List<vwDanfe> pdados)
        {
            dados = pdados;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dados = null;
            this.Close();
        }

        private void frmCorrigeConversao_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dados;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool Erro = false;

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                string un = dr.Cells[3].Value.ToString().ToUpper();
                if(un == "CX")
                {
                    string qtde = dr.Cells[5].Value.ToString();
                    if(qtde == "1")
                    {
                        Erro = true;
                    }
                } 
            }

            if(Erro)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Existem itens com a unidade Caixa com conversão = 1, isto pode gerar erros, pois caixas contém mais de uma unidade, no estoque e no valor de compra, deseja continuar?") == DialogResult.No)
                {
                    return;
                }
            }
            

            if (Util.Aplicacao.ShowQuestionMessage("Confirma a conversão das notas fiscais? uma vez confirmada a nota fiscal não poderá ser alterada") == DialogResult.Yes)
            {
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    int Id = Convert.ToInt32(dr.Cells[0].Value);
                    var item = dados.Where(x => x.INF_ITEM == Id).FirstOrDefault();
                    item.Conversao = Convert.ToInt32(dr.Cells[5].Value);
                }

                this.Close();
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
