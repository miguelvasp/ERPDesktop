using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Cadastros
{
    public partial class frmUnidadeFederativa : FormPage
    {
        private UnidadeFederacaoDAL ufDAL;
        private PaisDAL paisDAL;

        public frmUnidadeFederativa()
        {
            InitializeComponent();

            ufDAL = new UnidadeFederacaoDAL(new DB_ERPContext());
            paisDAL = new PaisDAL(new DB_ERPContext());

            this.pnl = pnlForm;

            CarregarUF();

            CarregarPais();
        }

        private void frmUnidadeFederativa_Load(object sender, EventArgs e)
        {

        }

        private void dgvUF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            txtIdUF.Text = dgvUF.Rows[row].Cells[0].Value.ToString();
            txtUF.Text = dgvUF.Rows[row].Cells[1].Value.ToString();
            txtDescricao.Text = dgvUF.Rows[row].Cells[2].Value.ToString();
            txtICMS.Text = dgvUF.Rows[row].Cells[3].Value.ToString();
            txtICMSSubs.Text = dgvUF.Rows[row].Cells[5].Value.ToString();
            txtIVA.Text = dgvUF.Rows[row].Cells[4].Value.ToString();
            txtCodIBGE.Text = dgvUF.Rows[row].Cells[6].Value.ToString();

            cmbPais.SelectedValue = dgvUF.Rows[row].Cells[7].Value;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.ufDAL.Dispose();
            this.paisDAL.Dispose();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            UnidadeFederacao uf = new UnidadeFederacao();

            try
            {
                if (string.IsNullOrEmpty(txtIdUF.Text))
                {
                    uf.IdUF = 0;
                }
                else
                {
                    uf = ufDAL.GetByID(Convert.ToInt32(txtIdUF.Text));
                }

                uf.UF = txtUF.Text;
                uf.Nome = txtDescricao.Text;
                uf.AliquotaICMS = Convert.ToDouble(txtICMS.Text);
                uf.AliquotaICMSSubs = Convert.ToDouble(txtICMSSubs.Text);
                uf.IVA = Convert.ToDouble(txtIVA.Text);
                uf.IBGE = Convert.ToInt32(txtCodIBGE.Text);
                uf.IdPais = Convert.ToInt32(cmbPais.SelectedValue);

                if (string.IsNullOrEmpty(txtIdUF.Text))
                {
                    ufDAL.Insert(uf);
                }
                else
                {
                    ufDAL.Update(uf);
                }

                ufDAL.Save();

                CarregarUF();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unidade da Federação", MessageBoxButtons.OK);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtIdUF.Text))
                {
                    DialogResult dialogResult = MessageBox.Show("Deseja realmente apagar?", "Unidade de Federação", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        UnidadeFederacao uf = new UnidadeFederacao();
                        uf = ufDAL.GetByID(Convert.ToInt32(txtIdUF.Text));
                        if (uf == null)
                        {
                            MessageBox.Show("Unidade da Federação não encontrada!");
                        }
                        else
                        {
                            ufDAL.Delete(uf.IdUF);
                            ufDAL.Save();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unidade da Federação", MessageBoxButtons.OK);
            }
            finally
            {
                CarregarUF();
            }
        }

        private void txtICMS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtICMSSubs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtCodIBGE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void CarregarUF()
        {
            LimparCampos();

            var uf = ufDAL.Get().Select(u => new { u.IdUF, u.UF, u.Nome, u.AliquotaICMS, u.AliquotaICMSSubs, u.IVA, u.IBGE, u.IdPais, Pais_NomePais = u.Pais.NomePais }).ToList();

            dgvUF.AutoGenerateColumns = false;

            dgvUF.DataSource = uf;
        }

        private void CarregarPais()
        {
            var pais = paisDAL.Get().ToList();

            cmbPais.DataSource = pais;
            cmbPais.DisplayMember = "NomePais";
            cmbPais.ValueMember = "IdPais";  
        }

        private void LimparCampos()
        {
            txtIdUF.Text = "";
            txtUF.Text = "";
            txtDescricao.Text = "";
            txtICMS.Text = "";
            txtICMSSubs.Text = "";
            txtIVA.Text = "";
            txtCodIBGE.Text = "";
            cmbPais.SelectedValue = 1;
        }

        private bool ValidarCampos()
        {
            bool valido = true;

            if (String.IsNullOrEmpty(txtUF.Text))
            {
                MessageBox.Show("O campo UF é obrigatório!", "Unidade da Federação", MessageBoxButtons.OK);
                valido = false;
            }
            else if (String.IsNullOrEmpty(txtDescricao.Text))
            {
                MessageBox.Show("O campo Descrição é obrigatório!", "Unidade da Federação", MessageBoxButtons.OK);
                valido = false;
            }

            return valido;
        }
    }
}
