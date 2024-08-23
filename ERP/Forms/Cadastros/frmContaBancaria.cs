using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmContaBancaria : RibbonForm
    {
        public ContaBancariaDAL dal = new ContaBancariaDAL();
        BancoDAL dalb = new BancoDAL();
        MoedaDAL mDal = new MoedaDAL();

        string Origem = "";
        int Id = 0;
        ContaBancaria cc = null;

        public frmContaBancaria(string pOrigem, int pId, ContaBancaria pConta)
        {
            Origem = pOrigem;
            Id = pId;
            cc = pConta;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmContaBancaria_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarBancos();
            CarregarPaises();

            CarregaDados();

            Cursor.Current = Cursors.Default;
        }

        private void CarregarBancos()
        {
            var bancos = dalb.Get().OrderBy(x => x.NomeBanco).ToList();
            cboBanco.DataSource = bancos;
            cboBanco.ValueMember = "IdBanco";
            cboBanco.DisplayMember = "NomeBanco";
            cboBanco.SelectedIndex = -1;
        }

        private void CarregarPaises()
        {
            //carrega paises
            cboPais.DataSource = new PaisDAL().GetCombo();
            cboPais.DisplayMember = "Text";
            cboPais.ValueMember = "iValue";
            cboPais.SelectedIndex = -1;
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            cboBanco.SelectedValue = cc.IdBanco;
            txtNomeConta.Text = cc.NomeConta;
            txtAgencia.Text = cc.Agencia;
            txtDigitoAgencia.Text = cc.DigitoAgencia;
            txtConta.Text = cc.Conta;
            txtDigitoConta.Text = cc.DigitoConta;
            txtNossoNumero.Text = cc.NossoNumero;
            txtCarteira.Text = cc.Carteira;
            if (cc.IdPais != null) cboPais.SelectedValue = cc.IdPais;

            lbCodigo.Text = cc.IdContaBancaria.ToString();

            Cursor.Current = Cursors.Default;
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    //grava os dados da Conta Bancária
                    cc.IdBanco = Convert.ToInt32(cboBanco.SelectedValue);
                    cc.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                    cc.NomeConta = txtNomeConta.Text;
                    cc.Agencia = txtAgencia.Text;
                    cc.DigitoAgencia = txtDigitoAgencia.Text;
                    cc.Conta = txtConta.Text;
                    cc.DigitoConta = txtDigitoConta.Text;
                    cc.DataConciliacao = DateTime.Now;
                    cc.DataInicio = DateTime.Now;
                    cc.SaldoInicial = 0;
                    cc.NossoNumero = txtNossoNumero.Text;
                    cc.Carteira = txtCarteira.Text;
                    if (!String.IsNullOrEmpty(cboPais.Text))
                        cc.IdPais = Convert.ToInt32(cboPais.SelectedValue);

                    if (cc.IdContaBancaria == 0)
                    {
                        dal.Insert(cc);
                        dal.Save();

                        //Vincula o endereço a sua origem
                        if (Origem == "Cliente")
                        {
                            ClienteContaBancaria ccb = new ClienteContaBancaria();
                            ccb.IdCliente = Id;
                            ccb.IdContaBancaria = cc.IdContaBancaria;

                            ClienteDAL cDal = new ClienteDAL();
                            cDal.CCBRepository.Insert(ccb);
                            cDal.Save();
                        }
                        else if (Origem == "Fornecedor")
                        {
                            FornecedorContaBancaria fcb = new FornecedorContaBancaria();
                            fcb.IdFornecedor = Id;
                            fcb.IdContaBancaria = cc.IdContaBancaria;

                            FornecedorDAL fDal = new FornecedorDAL();
                            fDal.FCBRepository.Insert(fcb);
                            fDal.Save();
                        }
                        else if (Origem == "Funcionario")
                        {
                            FuncionarioContaBancaria fcb = new FuncionarioContaBancaria();
                            fcb.IdFuncionario = Id;
                            fcb.IdContaBancaria = cc.IdContaBancaria;

                            FuncionarioDAL fDal = new FuncionarioDAL();
                            fDal.FCBRepository.Insert(fcb);
                            fDal.Save();
                        }
                        else if (Origem == "Empresa")
                        {
                            EmpresaContaBancaria ecb = new EmpresaContaBancaria();
                            ecb.IdEmpresa = Id;
                            ecb.IdContaBancaria = cc.IdContaBancaria;

                            EmpresaDAL eDal = new EmpresaDAL();
                            eDal.ECBRepository.Insert(ecb);
                            eDal.Save();
                        }
                    }
                    else
                    {
                        dal.Update(cc);
                        dal.Save();
                    }
                    this.Close();
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
