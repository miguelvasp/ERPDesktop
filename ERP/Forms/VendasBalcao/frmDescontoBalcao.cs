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

namespace ERP.Forms.VendasBalcao
{
    public partial class frmDescontoBalcao : Form
    {
        int IdCliente = 0;
        decimal DescontoMaximo = 0;
        public frmDescontoBalcao(int pidCliente)
        {
            IdCliente = pidCliente;
            InitializeComponent();
        }

        private void frmDescontoBalcao_Load(object sender, EventArgs e)
        {
            try
            {
                var cliente = new ClienteDAL().CRepository.GetByID(IdCliente);
                var grupo = new GrupoClienteDAL().GetByID(Convert.ToInt32(cliente.IdGrupoCliente));
                DescontoMaximo = grupo.PercentualDesconto;
                txtDesconto.Text = DescontoMaximo.ToString();
            }
            catch  
            {
                Util.Aplicacao.ShowMessage("Não foi possivel estabelecer o desconto para o cliente, verifique o cadastro do cliente > grupo de clientes");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDesconto.Text))
                {
                    txtDesconto.Text = "0";
                }

                if (Convert.ToDecimal(txtDesconto.Text) > DescontoMaximo)
                {
                    Util.Aplicacao.ShowMessage("Desconto máximo para o cliente de " + DescontoMaximo.ToString() + "%");
                    return;
                }

                this.Close();
            }
            catch  
            {
                 
            } 
        }
    }
}
