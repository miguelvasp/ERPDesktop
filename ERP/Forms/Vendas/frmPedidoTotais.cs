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

namespace ERP 
{
    public partial class frmPedidoTotais : Form
    {

        PedidosTotaisModelView p = new PedidosTotaisModelView();
        public frmPedidoTotais(PedidosTotaisModelView pTotais)
        {
            p = pTotais;
            InitializeComponent();
        }

        private void frmPedidoTotais_Load(object sender, EventArgs e)
        { 
            txtTotalImpostos.Text = p.TotalImpostos.ToString("N2");
            txtTotalEncargos.Text = p.TotalEncargos.ToString("N2");
            txtTotalPedido.Text = ((p.TotalProdutos + p.TotalImpostosNaoInclusos + p.TotalEncargos) - (p.TotalDesconto)).ToString("N2");
            txtDescontos.Text = (p.TotalDesconto).ToString("N2");
            txtTotalProdutos.Text = p.TotalProdutos.ToString("N2");
            txtTotalSemDescontoVarejista.Text = (p.TotalDescontoVarejista + p.TotalProdutos + p.TotalImpostosNaoInclusos + p.TotalEncargos - p.TotalDesconto).ToString("N2");
            txtIPI.Text = p.IPI.ToString("N2");
            txtPìs.Text = p.PIS.ToString("N2");
            txtICMS.Text = p.ICMS.ToString("N2");
            txtCofins.Text = p.COFINS.ToString("N2");
            txtIss.Text = p.ISS.ToString("N2");
            txtIrpf.Text = p.IRRF.ToString("N2");
            txtInss.Text = p.INSS.ToString("N2");
            txtImpostoImportacao.Text = p.ImpostoImportacao.ToString("N2");
            txtOutrosImpostos.Text = p.OutrosImpostos.ToString("N2");
            txtCSLL.Text = p.CSLL.ToString("N2");
            txtICMSST.Text = p.ICMSST.ToString("N2");
            txtICMSDiff.Text = p.ICMSDiff.ToString("N2");
        }
    }
}
