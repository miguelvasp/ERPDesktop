using ERP.DAL;
using ERP.Models;
using ERP.BLL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmSelecionaLote : Form
    {
        ProdutoDAL dal = new ProdutoDAL();
        public int IdInventarioSelecionado = 0; 

        public frmSelecionaLote(int? IdProduto, int? IdDeposito, int? IdArmazem, int? IdLocalizacao, int? IdVariantesConfig, int? IdVariantesTamanho, int? IdVariantesCor, int? IdVariantesEstilo, int? IdTipoDocumento, string LoteFornecedor, string LoteInterno, DateTime? DataFabricacao, DateTime? DataVencimento, DateTime? DataValidade, DateTime? DataAvisoPrateleira)
        {
            InitializeComponent();
            BLInventario bli = new BLInventario();
            var lista = bli.ConsultaEstoqueAnalitico(IdProduto, IdDeposito, IdArmazem, IdLocalizacao, IdVariantesConfig, IdVariantesTamanho, IdVariantesCor, IdVariantesEstilo, IdTipoDocumento, LoteFornecedor, LoteInterno, DataFabricacao, DataVencimento, DataValidade, DataAvisoPrateleira);
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = lista;
        }  

        private void MontaProduto()
        {
            try
            {
                if (dgv.Rows.Count > 0)
                { 
                    IdInventarioSelecionado = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value); 
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0 && e.RowIndex > -1)
            {
                MontaProduto();
                this.Close();
            }
        }
         

        private void frmBuscaProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
         

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            MontaProduto();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IdInventarioSelecionado = 0;
            this.Close();
        }

        private void frmBuscaProduto_Load(object sender, EventArgs e)
        {
            //carrega os clientes
            
        }
    }
}
