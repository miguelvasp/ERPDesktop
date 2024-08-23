using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmFuncionarioCad : RibbonForm
    {
        Funcionario f = new Funcionario();
        public FuncionarioDAL dal = new FuncionarioDAL();

        public frmFuncionarioCad(Funcionario pF)
        {
            f = pF;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmFuncionarioCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregaCombos();

            if (f.IdFuncionario == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmFuncionarioCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaCombos()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboVendedor.DataSource = new VendedorDAL().GetCombo();
            cboVendedor.DisplayMember = "Text";
            cboVendedor.ValueMember = "iValue";
            cboVendedor.SelectedIndex = -1;

            cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(sEmpresa);
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.SelectedIndex = -1;
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = f.IdFuncionario.ToString();
            txtNome.Text = f.Nome;
            txtFantasia.Text = f.NomeFantasia;
            txtCPF.Mask = "999.999.999-99";
            txtCPF.Text = f.CPF;
            txtRG.Text = f.RG;

            cboVendedor.SelectedValue = f.IdVendedor == null ? 0 : f.IdVendedor;
            cboFornecedor.SelectedValue = f.IdFornecedor == null ? 0 : f.IdFornecedor;
            chkTelevendas.Checked = f.Televendas == null ? false : Convert.ToBoolean(f.Televendas);
            CarregaEnderecos();
            CarregaTelefones();
            CarregaContasBancarias();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        protected void CarregaEnderecos()
        {
            EnderecoDAL Edal = new EnderecoDAL(new DB_ERPContext());
            var Enderecos = Edal.getFuncionario(f.IdFuncionario).Select(x => new { x.IdFuncionarioEndereco, x.Endereco.IdEndereco, x.Endereco.TipoEndereco.Descricao, x.Endereco.Logradouro, x.Endereco.Numero, x.Endereco.Bairro, x.Endereco.Cidade.Nome }).ToList();
            grEndereco.AutoGenerateColumns = false;
            grEndereco.RowHeadersVisible = false;
            grEndereco.DataSource = Enderecos;
        }

        protected void CarregaTelefones()
        {
            TelefoneDAL tDal = new TelefoneDAL(new DB_ERPContext());
            var telefones = tDal.getFuncionario(f.IdFuncionario).Select(x => new { x.IdFuncionarioTelefone, x.IdTelefone, x.Telefone.TipoTelefone.Descricao, x.Telefone.CodigoPais, x.Telefone.DDD, x.Telefone.NumeroTelefone }).ToList();
            grTelefone.AutoGenerateColumns = false;
            grTelefone.RowHeadersVisible = false;
            grTelefone.DataSource = telefones;
        }

        protected void CarregaContasBancarias()
        {
            ContaBancariaDAL cbdal = new ContaBancariaDAL();
            var lista = cbdal.getFuncionario(f.IdFuncionario).Select(x => new { x.IdFuncionarioContaBancaria, x.IdContaBancaria, x.IdFuncionario, Banco = x.ContaBancaria.Banco.NomeBanco, Agencia = x.ContaBancaria.Agencia + "-" + x.ContaBancaria.DigitoAgencia, Conta = x.ContaBancaria.Conta + "-" + x.ContaBancaria.DigitoConta }).ToList();
            grContaBancaria.AutoGenerateColumns = false;
            grContaBancaria.RowHeadersVisible = false;
            grContaBancaria.DataSource = lista;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            try
            {
                f = new Funcionario();
                lbCodigo.Text = "0";
                Util.Aplicacao.LimpaControles(this);
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            string cpf = txtCPF.Text.Replace(",", "").Replace(".", "").Replace("-", "").Replace("/", "");


            if (!Util.Validacao.ValidaCPF.IsCpf(cpf))
            {
                Util.Aplicacao.ShowMessage("CPF inválido!");
                return;
            }

            if (!Util.Validacao.ValidaEmail(txtEmail.Text))
            {
                Util.Aplicacao.ShowMessage("Email inválido!");
                return;
            }

            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    f.Nome = txtNome.Text;
                    f.NomeFantasia = txtFantasia.Text;
                    f.CPF = txtCPF.Text.Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "");
                    f.RG = txtRG.Text;
                    f.EMail = txtEmail.Text;
                    f.Televendas = chkTelevendas.Checked;

                    if (!String.IsNullOrEmpty(cboVendedor.Text)) f.IdVendedor = Convert.ToInt32(cboVendedor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboFornecedor.Text)) f.IdFornecedor = Convert.ToInt32(cboFornecedor.SelectedValue);

                    if (f.IdFuncionario == 0)
                    {
                        dal.FRepository.Insert(f);
                    }
                    else
                    {
                        dal.FRepository.Update(f);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
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
                    int id = f.IdFuncionario;
                    dal.FRepository.Delete(id);
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
            if (f.IdFuncionario != 0)
            {
                frmEndereco cad = new frmEndereco("Funcionario", f.IdFuncionario, new Endereco());
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
                FuncionarioEndereco ce = dal.FERepository.GetByID(id);
                int IdEndereco = ce.IdEndereco;

                //apaga o relacionamento
                dal.FERepository.Delete(id);
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
            if (f.IdFuncionario != 0)
            {
                if (grEndereco.Rows.Count > 0)
                {
                    string sId = grEndereco.Rows[e.RowIndex].Cells[1].Value.ToString();
                    int id = Convert.ToInt32(sId);
                    EnderecoDAL endDal = new EnderecoDAL(new DB_ERPContext());
                    Endereco en = endDal.GetByID(id);
                    frmEndereco cad = new frmEndereco("Funcionario", f.IdFuncionario, en);
                    cad.dal = endDal;
                    cad.ShowDialog();
                    CarregaEnderecos();
                }
            }
        }

        private void tsbAdicionarTelefone_Click(object sender, EventArgs e)
        {
            if (f.IdFuncionario != 0)
            {
                frmTelefone cad = new frmTelefone("Funcionario", f.IdFuncionario, new Telefone());
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
            if (grTelefone.Rows.Count > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Confirma a exclusão do telefone") == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(grTelefone.Rows[grTelefone.SelectedRows[0].Index].Cells[1].Value.ToString());
                    FuncionarioTelefone te = dal.FTRepository.GetByID(id);
                    int Idtelefone = te.IdTelefone;

                    //apaga o relacionamento
                    dal.FTRepository.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    //apaga o endereço
                    TelefoneDAL eDal = new TelefoneDAL(new DB_ERPContext());
                    eDal.Delete(te.IdTelefone);
                    eDal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaTelefones();
                }
            }
        }

        private void grTelefone_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (f.IdFuncionario != 0)
            {
                if (grTelefone.Rows.Count > 0)
                {
                    string sId = grTelefone.Rows[e.RowIndex].Cells[1].Value.ToString();
                    int id = Convert.ToInt32(sId);
                    TelefoneDAL tDal = new TelefoneDAL(new DB_ERPContext());
                    Telefone te = tDal.GetByID(id);
                    frmTelefone cad = new frmTelefone("Funcionario", f.IdFuncionario, te);
                    cad.tDal = tDal;
                    cad.ShowDialog();
                    CarregaEnderecos();
                }
            }
        }

        private void tsbAdicionarContaBancaria_Click(object sender, EventArgs e)
        {
            if (f.IdFuncionario != 0)
            {
                frmContaBancaria cad = new frmContaBancaria("Funcionario", f.IdFuncionario, new ContaBancaria());
                cad.ShowDialog();
                CarregaContasBancarias();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Salve as informações principais para poder cadastrar contas bancárias.");
            }
        }

        private void tsbExcluirContaBancaria_Click(object sender, EventArgs e)
        {
            if (grContaBancaria.Rows.Count > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Confirma a exclusão da conta bancária") == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(grContaBancaria.Rows[grContaBancaria.SelectedRows[0].Index].Cells[0].Value.ToString());
                    FuncionarioContaBancaria fcb = dal.FCBRepository.GetByID(id);
                    int IdContaBancaria = fcb.IdContaBancaria;

                    //apaga o relacionamento
                    dal.FCBRepository.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    //apaga a Conta Bancária
                    ContaBancariaDAL cbDal = new ContaBancariaDAL();
                    cbDal.Delete(fcb.IdContaBancaria);
                    cbDal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaContasBancarias();
                }
            }
        }

        private void grContaBancaria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grContaBancaria.Rows.Count > 0)
            {
                string sId = grContaBancaria.Rows[e.RowIndex].Cells[1].Value.ToString();
                int id = Convert.ToInt32(sId);
                ContaBancariaDAL cbDal = new ContaBancariaDAL();
                ContaBancaria cb = cbDal.GetByID(id);
                frmContaBancaria cad = new frmContaBancaria("Funcionario", f.IdFuncionario, cb);
                cad.dal = cbDal;
                cad.ShowDialog();
                CarregaContasBancarias();
            }
        }
    }
}
