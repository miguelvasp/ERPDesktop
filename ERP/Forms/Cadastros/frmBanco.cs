using ERP.DAL;
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

namespace ERP.Cadastros
{
    public partial class frmBanco : FormPage
    {
        private BancoDAL bancoDAL; 

        public frmBanco()
        {
            InitializeComponent(); 

            bancoDAL = new BancoDAL(new DB_ERPContext());

            this.pnl = pnlForm;

            CarregarBancos();
        }


        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void dgvBanco_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            txtIdBanco.Text = dgvBanco.Rows[row].Cells[0].Value.ToString();
            txtNumeroBanco.Text = dgvBanco.Rows[row].Cells[1].Value.ToString();
            txtNomeBanco.Text = dgvBanco.Rows[row].Cells[2].Value.ToString();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.bancoDAL.Dispose();
        }

        private void CarregarBancos()
        {
            LimparCampos();

            var banco = bancoDAL.Get().Select(u => new { u.IdBanco, u.NumeroBanco, u.NomeBanco }).ToList();

            dgvBanco.AutoGenerateColumns = false;

            dgvBanco.DataSource = banco;
        }

        private void LimparCampos()
        {
            txtIdBanco.Text = "";
            txtNumeroBanco.Text = "";
            txtNomeBanco.Text = "";
        }

        private bool ValidarCampos()
        {
            bool valido = true;

            if (String.IsNullOrEmpty(txtNomeBanco.Text))
            {
                MessageBox.Show("O campo Nome é obrigatório!", "Cadastro de Bancos", MessageBoxButtons.OK);
                valido = false;
            }

            return valido;
        }

        private void frmBanco_Load(object sender, EventArgs e)
        {

        }
    }
}
