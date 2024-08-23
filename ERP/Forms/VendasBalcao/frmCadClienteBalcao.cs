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

namespace ERP.Forms.VendasBalcao
{
    public partial class frmCadClienteBalcao : Form
    {
        public Cliente c = new Cliente();
        ClienteDAL dal = new ClienteDAL();
        public frmCadClienteBalcao()
        {
            InitializeComponent();
        }

        private void frmCadClienteBalcao_Load(object sender, EventArgs e)
        {
            LimpaCampos();
            List<ComboItem> cid = new CidadeDAL().GetCombo();
            
            cid.Insert(0,new ComboItem() { Text = "Pilar do Sul", iValue = 5213 });
            txtCidade.DataSource = cid;
            txtCidade.DisplayMember = "Text";
            txtCidade.ValueMember = "iValue";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cnpj = txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "").Trim();
            if (cnpj.Length == 14)
            {
                c.Tipo = 2;
                if (!Util.Validacao.ValidaCNPJ.IsCnpj(cnpj))
                {
                    Util.Aplicacao.ShowMessage("CNPJ inválido!");
                    return;
                }
            }
            else
            {
                if (!Util.Validacao.ValidaCPF.IsCpf(cnpj))
                {
                    Util.Aplicacao.ShowMessage("CPF inválido!");
                    return;
                }
            }

            if (cnpj.Length == 14)
            {
                c.Tipo = 1;
                if (string.IsNullOrEmpty(txtIe.Text))
                {
                    Util.Aplicacao.ShowMessage("Informe a Inscrição estadual!");
                    return;
                }
            }

            if (string.IsNullOrEmpty(txtRazao.Text) || string.IsNullOrEmpty(txtender.Text) || string.IsNullOrEmpty(txtnumero.Text))
            {
                Util.Aplicacao.ShowMessage("Preencha todas as informações!");
                return;
            }

            c.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
            c.Tipo = cnpj.Length == 14 ? 2 : 1;
            c.CNPJ = cnpj;
            c.InscricaoEstadual = txtIe.Text;
            c.RazaoSocial = txtRazao.Text;
            c.Logradouro = txtender.Text;
            c.Nro = txtnumero.Text;
            c.Bairro = txtBairro.Text;
            c.IdCidade = Convert.ToInt32(txtCidade.SelectedValue);
            var cidade = new CidadeDAL().GetByID((int)c.IdCidade);
            var uf = new UnidadeFederacaoDAL(new DB_ERPContext()).GetByID(cidade.IdUF);
            c.IdUf = uf.IdUF;
            c.CEP = txtCEP.Text;
            c.IdPais = 1;

            if(c.IdCliente == 0)
            {
                dal.CRepository.Insert(c);
            }
            else
            {
                dal.CRepository.Update(c);
            }
            dal.Save();
            LimpaCampos();
            this.Close();

        }

        private void CarregarDados()
        {
            txtIe.Text = c.InscricaoEstadual;
            txtRazao.Text = c.RazaoSocial;
            txtender.Text = c.Logradouro;
            txtnumero.Text = c.Nro;
            txtBairro.Text = c.Bairro;
            txtCidade.SelectedValue = c.IdCidade;
            txtCEP.Text = c.CEP; 
        }

        private void LimpaCampos()
        {
            txtIe.Text = "";
            txtRazao.Text = "";
            txtender.Text = "";
            txtnumero.Text = "";
            txtBairro.Text = "";
            txtCidade.SelectedValue = 5213;
            txtCEP.Text = "18185000";
        }

        private void txtCNPJ_Leave(object sender, EventArgs e)
        {
            string cnpj = txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "").Trim();
            if (cnpj.Length == 14)
            {
                if (!Util.Validacao.ValidaCNPJ.IsCnpj(cnpj))
                {
                    Util.Aplicacao.ShowMessage("CNPJ inválido!");
                    return;
                }
            }
            else
            {
                if (!Util.Validacao.ValidaCPF.IsCpf(cnpj))
                {
                    Util.Aplicacao.ShowMessage("CPF inválido!");
                    return;
                }
            }

            var cliente = dal.ConsultaCNPJ(txtCNPJ.Text);
            if(cliente != null)
            {
                c = cliente;
                CarregarDados();
            }
        }
    }
}
