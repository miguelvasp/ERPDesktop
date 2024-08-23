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
using ERP.Models;

namespace ERP.Vendas
{
    public partial class frmConfirmaSeparacao : Form
    {
        vwPedidoVendaSeparacaoDAL vDal = new vwPedidoVendaSeparacaoDAL();
        PedidoVendaItemDAL idal = new PedidoVendaItemDAL();
        PedidoVendaDAL pDal = new PedidoVendaDAL();
        public frmConfirmaSeparacao()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

        }

        private void frmConfirmaSeparacao_Load(object sender, EventArgs e)
        {
            cbocliente.DataSource = vDal.GetComboClientesEmSeparacao();
            cbocliente.DisplayMember = "Text";
            cbocliente.ValueMember = "iValue";
            cbocliente.SelectedIndex = -1;
        }

        private void cbocliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaGrid();
            
        }

        private void CarregaGrid()
        {
            try
            {
                if (!String.IsNullOrEmpty(cbocliente.Text))
                {
                    var lista = vDal.GetByCliente(Convert.ToInt32(cbocliente.SelectedValue));
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = lista;
                    foreach (DataGridViewRow dr in dataGridView1.Rows)//Traz os itens ja marcados
                    {
                        dr.Cells[1].Value = true;
                        dr.Cells[10].Value = dr.Cells[9].Value;
                    }
                }
            }
            catch  
            { 
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var cell = dataGridView1[e.ColumnIndex, e.RowIndex];
                if (cell.OwningColumn.Name == "chkSelecionar")
                {
                    if (cell.EditedFormattedValue.ToString().ToLower() == "true")
                    {
                        dataGridView1[10, e.RowIndex].Value = dataGridView1[9, e.RowIndex].Value; 
                    }
                    else
                    {
                        dataGridView1[10, e.RowIndex].Value = "";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Util.Aplicacao.ShowQuestionMessage("Deseja enviar os itens selecionados para faturamento?") == System.Windows.Forms.DialogResult.Yes)
            {
                bool Erro = false;
                foreach(DataGridViewRow dr in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(dr.Cells[1].Value))
                    { 
                        try
                        {
                            decimal qtde = Convert.ToDecimal(dr.Cells[10].Value);
                        }
                        catch(Exception ex)
                        {
                            Erro = true;
                        }
                    }
                }

                if(Erro)
                {
                    Util.Aplicacao.ShowMessage("Verifique as quantidades informadas.");
                    return;
                }
                else
                {
                    foreach(DataGridViewRow dr in dataGridView1.Rows)
                    {
                        if (Convert.ToBoolean(dr.Cells[1].Value))
                        {
                            int id = Convert.ToInt32(dr.Cells[0].Value);
                            PedidoVendaItem i = idal.GetByID(id);
                            i.QuantidadePorFaturar = Convert.ToDecimal(dr.Cells[10].Value);
                            idal.Update(i);
                            idal.Save();

                            PedidoVenda pv = pDal.PVRepository.GetByID(i.IdPedidoVenda);
                            pv.Status = (int)Util.EnumERP.StatusPedido.AFaturar;
                            pDal.PVRepository.Update(pv);
                            pDal.Save(Util.Util.GetAppSettings("IdUsuario"));
                        }
                    }
                    CarregaGrid();
                    Util.Aplicacao.ShowMessage("Itens liberados para faturamento com sucesso.");
                }
            }
        }

        private void chkSeleciona_CheckedChanged(object sender, EventArgs e)
        {
             
            foreach(DataGridViewRow dr in dataGridView1.Rows)
            {
                dr.Cells[1].Value = chkSeleciona.Checked;
                if(chkSeleciona.Checked)
                {
                    dr.Cells[10].Value = dr.Cells[9].Value;
                }
                else
                {
                    dr.Cells[10].Value = "";
                }
            }
             
        }
    }
}
