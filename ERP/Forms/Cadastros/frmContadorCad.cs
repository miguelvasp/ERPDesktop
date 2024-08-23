using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmContadorCad : RibbonForm
    {
        Contador c = new Contador();
        public ContadorDAL dal = new ContadorDAL();

        public frmContadorCad(Contador pContador)
        {
            c = pContador;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmContadorCad_Load(object sender, EventArgs e)
        {
            if (c.IdContador == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void CarregaDados()
        {
            lbCodigo.Text = c.IdContador.ToString();
            txtNome.Text = c.Nome;
            txtCPF.Text = c.CPF;
            txtCNPJ.Text = c.CNPJ;
            txtCNPJ.Text = c.CRC;
            txtEmail.Text = c.Email;
            txtInternet.Text = c.Internet;

            CarregaEnderecos();
            CarregaTelefones();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        protected void CarregaEnderecos()
        {
            EnderecoDAL Edal = new EnderecoDAL(new DB_ERPContext());
            var Enderecos = Edal.getContador(c.IdContador).Select(x => new { x.IdContadorEndereco, x.Endereco.IdEndereco, x.Endereco.TipoEndereco.Descricao, x.Endereco.Logradouro, x.Endereco.Numero, x.Endereco.Bairro, x.Endereco.Cidade.Nome }).ToList();
            grEndereco.AutoGenerateColumns = false;
            grEndereco.RowHeadersVisible = false;
            grEndereco.DataSource = Enderecos;
        }

        protected void CarregaTelefones()
        {
            TelefoneDAL tDal = new TelefoneDAL(new DB_ERPContext());
            var telefones = tDal.getContador(c.IdContador).Select(x => new { x.IdContadorTelefone, x.IdTelefone, x.Telefone.TipoTelefone.Descricao, x.Telefone.CodigoPais, x.Telefone.DDD, x.Telefone.NumeroTelefone }).ToList();
            grTelefone.AutoGenerateColumns = false;
            grTelefone.RowHeadersVisible = false;
            grTelefone.DataSource = telefones;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            c = new Contador();
            lbCodigo.Text = "0";
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            string cpf = txtCPF.Text.Replace(",", "").Replace(".", "").Replace("-", "").Trim();
            if (!string.IsNullOrEmpty(cpf))
            {
                if (!Util.Validacao.ValidaCPF.IsCpf(cpf))
                {
                    Util.Aplicacao.ShowMessage("CPF inválido!");
                    return;
                }
            }

            string cnpj = txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "").Trim();
            if (!string.IsNullOrEmpty(cnpj))
            {
                if (!Util.Validacao.ValidaCNPJ.IsCnpj(cnpj))
                {
                    Util.Aplicacao.ShowMessage("CNPJ inválido!");
                    return;
                }
            }

            if (!Util.Validacao.ValidaEmail(txtEmail.Text))
            {
                Util.Aplicacao.ShowMessage("Email inválido!");
                return;
            }

            if (Util.Validacao.ValidaCampos(this))
            {
                c.Nome = txtNome.Text;
                c.CRC = txtCRC.Text;
                c.CNPJ = txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "").Trim();
                c.CPF = txtCPF.Text.Replace(",", "").Replace(".", "").Replace("-", "").Trim();
                c.Email = txtEmail.Text;
                c.Internet = txtInternet.Text;

                if (c.IdContador == 0)
                {
                    dal.CRepository.Insert(c);
                }
                else
                {
                    dal.CRepository.Update(c);
                }

                dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                CarregaDados();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                Util.Aplicacao.ShowMessage("Por favor verifique as informações faltantes.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Qualquer alteração efetuada será perdida, deseja continuar?") == System.Windows.Forms.DialogResult.Yes)
            {
                CarregaDados();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = c.IdContador;
                    dal.CRepository.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    Close();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowMessage("Este registro não pode ser excluído." + "\n" + "\n" + "Erro: " + ex.Message);
            }
        }

        private void tsbAdicionarEndereco_Click(object sender, EventArgs e)
        {
            if (c.IdContador != 0)
            {
                frmEndereco cad = new frmEndereco("Contador", c.IdContador, new Endereco());
                cad.ShowDialog();
                CarregaEnderecos();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Salve as informações principais para poder cadastrar endereços.");
            }
        }

        private void tsbExcluirEndereco_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Confirma a exclusão do endereço") == System.Windows.Forms.DialogResult.Yes)
            {
                int id = Convert.ToInt32(grEndereco.Rows[grEndereco.SelectedRows[0].Index].Cells[0].Value.ToString());
                ContadorEndereco ce = dal.CERepository.GetByID(id);
                int IdEndereco = ce.IdEndereco;

                //apaga o relacionamento
                dal.CERepository.Delete(id);
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                //apaga o endereço
                EnderecoDAL eDal = new EnderecoDAL(new DB_ERPContext());
                eDal.Delete(ce.IdEndereco);
                eDal.Save(Util.Util.GetAppSettings("IdUsuario"));
                CarregaEnderecos();
            }
        }

        private void grEndereco_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grEndereco.Rows.Count > 0)
            {
                string sId = grEndereco.Rows[e.RowIndex].Cells[1].Value.ToString();
                int id = Convert.ToInt32(sId);
                EnderecoDAL endDal = new EnderecoDAL(new DB_ERPContext());
                Endereco en = endDal.GetByID(id);
                frmEndereco cad = new frmEndereco("Contador", c.IdContador, en);
                cad.dal = endDal;
                cad.ShowDialog();
                CarregaEnderecos();
            }
        }

        private void tsbAdicionarTelefone_Click(object sender, EventArgs e)
        {
            if (c.IdContador != 0)
            {
                frmTelefone cad = new frmTelefone("Contador", c.IdContador, new Telefone());
                cad.ShowDialog();
                CarregaTelefones();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Salve as informações principais para poder cadastrar telefones.");
            }
        }

        private void tsbExcluirTelefone_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Confirma a exclusão do telefone") == System.Windows.Forms.DialogResult.Yes)
            {
                int id = Convert.ToInt32(grTelefone.Rows[grTelefone.SelectedRows[0].Index].Cells[1].Value.ToString());
                ContadorTelefone te = dal.CTRepository.GetByID(id);
                int Idtelefone = te.IdTelefone;

                //apaga o relacionamento
                dal.CTRepository.Delete(id);
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                //apaga o endereço
                TelefoneDAL eDal = new TelefoneDAL(new DB_ERPContext());
                eDal.Delete(te.IdTelefone);
                eDal.Save(Util.Util.GetAppSettings("IdUsuario"));
                CarregaTelefones();
            }
        }

        private void grTelefone_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grTelefone.Rows.Count > 0)
            {
                string sId = grTelefone.Rows[e.RowIndex].Cells[1].Value.ToString();
                int id = Convert.ToInt32(sId);
                TelefoneDAL tDal = new TelefoneDAL(new DB_ERPContext());
                Telefone te = tDal.GetByID(id);
                frmTelefone cad = new frmTelefone("Contador", c.IdContador, te);
                cad.tDal = tDal;
                cad.ShowDialog();
                CarregaEnderecos();
            }
        }
    }
}
