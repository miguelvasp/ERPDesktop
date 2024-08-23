using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPedidoVendaAlocaEncargos : Form
    {

        public PedidoVendaAlocacaoEncargosDAL alocalDal;
        PedidoVendaAlocacaoEncargos al = new PedidoVendaAlocacaoEncargos();
        public PedidoVendaEncargosDAL encargoDal;
        List<PedidoVendaEncargos> Encargos = new List<PedidoVendaEncargos>();
        int IdPedidoVenda;


        public frmPedidoVendaAlocaEncargos(int pIdPedidoVenda)
        {
            IdPedidoVenda = pIdPedidoVenda;
            InitializeComponent();
            CarregaCombos();
        }

        private void CarregaCombos()
        {
            List<ComboItem> dist = new List<ComboItem>();///1- ; 2- 3- ; 
            dist.Add(new ComboItem() { iValue = 1, Text = "Quantidade" });
            dist.Add(new ComboItem() { iValue = 2, Text = "Valor Líquido" });
            dist.Add(new ComboItem() { iValue = 3, Text = "Por linha" });
            cboDistribuirPor.DataSource = dist;
            cboDistribuirPor.DisplayMember = "Text";
            cboDistribuirPor.ValueMember = "iValue";

            List<ComboItem> linhas = new List<ComboItem>();
            linhas.Add(new ComboItem() { iValue = 1, Text = "Todas os itens" });
            linhas.Add(new ComboItem() { iValue = 2, Text = "Itens Positivos" });
            linhas.Add(new ComboItem() { iValue = 3, Text = "Itens Negativos" });
            cboLinhas.DataSource = linhas;
            cboLinhas.DisplayMember = "Text";
            cboLinhas.ValueMember = "iValue";


        }
        
        

        private void frmBuscaProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        

        private void frmBuscaProduto_Load(object sender, EventArgs e)
        {
            al = alocalDal.GetByPedidoVenda(IdPedidoVenda);
            if(al != null)
            {
                cboDistribuirPor.SelectedValue = al.DistribuirPor == null ? 0 : al.DistribuirPor;
                cboLinhas.SelectedValue = al.Linhas == null ? 0 : al.Linhas;
                chkDistribuirTudo.Checked = al.DistribuirTudo == null ? false : Convert.ToBoolean(al.DistribuirTudo);
                chkRecebidoSeparado.Checked = al.Recebido_Separado == null ? false : Convert.ToBoolean(al.Recebido_Separado);
            }

            Encargos = encargoDal.GetPedidoVendaEncargos(IdPedidoVenda);
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = Encargos; 

        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if(Util.Aplicacao.ShowQuestionMessage("Confirma os dados dos encargos?") == DialogResult.Yes)
            {
                if (al == null) al = new PedidoVendaAlocacaoEncargos();
                al.IdPedidoVenda = IdPedidoVenda;
                al.DistribuirPor = Convert.ToInt32(cboDistribuirPor.SelectedValue);
                al.Linhas = Convert.ToInt32(cboLinhas.SelectedValue);
                al.DistribuirTudo = chkDistribuirTudo.Checked;
                al.Recebido_Separado = chkRecebidoSeparado.Checked; 
                if(al.IdPedidoVendaAlocaEncargos == 0)
                {
                    alocalDal.Insert(al);
                }
                else
                {
                    alocalDal.Update(al);
                }
                alocalDal.Save();

                //Salva os valores dos encargos
                dgv.EndEdit();
                foreach(DataGridViewRow dr in dgv.Rows)
                {
                    if(dr.Cells[2].Value != null)
                    {
                        if(Util.Util.IsNumber(dr.Cells[2].Value.ToString()))
                        {
                            PedidoVendaEncargos enc = encargoDal.GetByID(Convert.ToInt32(dr.Cells[0].Value));
                            enc.Valor = Convert.ToDecimal(dr.Cells[2].Value);
                            encargoDal.Update(enc);
                            encargoDal.Save();
                        }
                    }
                }
                this.Close();
            }
        }
    }
}
