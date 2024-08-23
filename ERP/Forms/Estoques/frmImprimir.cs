using ERP.Forms.VendasBalcao;
using ERP.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmImprimir : Form
    {
        List<Util.Etiqueta> etiquetas;
        public frmImprimir(List<Util.Etiqueta> pe)
        {
            etiquetas = pe;
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                dr.Cells[0].Value = chkSelect.Checked;
            }
        }

        private void frmImprimir_Load(object sender, EventArgs e)
        {
            foreach(var i in etiquetas)
            {
                dataGridView1.Rows.Add(new string[] { "true", i.CodigoBarras,  i.Codigo, i.Descricao, i.Qtde.ToString() });
            }

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                dr.Cells[0].Value = true;
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            List<Util.Etiqueta> im = new List<Util.Etiqueta>();
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[0].Value))
                {
                    Util.Etiqueta i = new Util.Etiqueta();
                    i.CodigoBarras = dr.Cells[1].Value.ToString().PadLeft(6, '0');
                    i.Codigo = dr.Cells[2].Value.ToString();
                    i.Descricao = dr.Cells[3].Value.ToString();
                    i.Qtde = Convert.ToInt32(dr.Cells[4].Value);
                    im.Add(i);
                }
            }

            Util.Etiqueta bl = new Util.Etiqueta();
            bl.ImprimirEtiquetas(im);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmPesquisaProdutoEtiqueta frmp = new frmPesquisaProdutoEtiqueta();
            frmp.ShowDialog();

            var lista = frmp.et;
            foreach(var i in lista)
            {
                dataGridView1.Rows.Add(new string[] { "true", i.CodigoBarras, i.Codigo, i.Descricao, i.Qtde.ToString() });
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(txtCodigo.Text) && !string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtQtde.Text))
                {
                    Util.Etiqueta et = new Util.Etiqueta();
                    et.Qtde = Convert.ToInt32(txtQtde.Text);
                    dataGridView1.Rows.Add(new string[] { "true", lbIdProduto.Text, txtCodigo.Text, txtNome.Text, txtQtde.Text });
                    txtCodigo.Text = "";
                    txtNome.Text = "";
                    txtQtde.Text = "";
                    lbIdProduto.Text = "";
                    
                }
            }
            catch  
            {
                Util.Aplicacao.ShowMessage("Verifique as informações!");
            }
        }
    }
}
