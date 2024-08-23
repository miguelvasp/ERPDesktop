using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.Models;
using ERP.DAL;
using ERP.Util;

namespace ERP
{
    public partial class frmEndereco : RibbonForm
    {
        UnidadeFederacaoDAL ufdal = new UnidadeFederacaoDAL(new DB_ERPContext());
        CidadeDAL cidDal = new CidadeDAL();
        TipoEnderecoDAL teDal = new TipoEnderecoDAL(new DB_ERPContext());
        PaisDAL paisDal = new PaisDAL();
        public EnderecoDAL dal = new EnderecoDAL(new DB_ERPContext());

        string Origem = "";
        int Id = 0;
        Endereco en = null;

        public frmEndereco(string pOrigem, int pId, Endereco pEnd)
        {
            Origem = pOrigem;
            Id = pId;
            en = pEnd;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }


        private void frmEnderecoCad_Load(object sender, EventArgs e)
        {
            //carrega tipo endereço
            var tpe = teDal.Get().OrderBy(x => x.Descricao).ToList();
            cboTpEnd.DataSource = tpe;
            cboTpEnd.DisplayMember = "Descricao";
            cboTpEnd.ValueMember = "IdTipoEndereco";
            cboTpEnd.SelectedIndex = 1;

            //carrega paises
            var paises = paisDal.Get().OrderBy(x => x.NomePais).ToList();
            cboPais.DataSource = paises;
            cboPais.DisplayMember = "NomePais";
            cboPais.ValueMember = "IdPais";
            cboPais.SelectedIndex = -1;

            //Carrega uf
            var ufs = ufdal.Get().OrderBy(x => x.UF).ToList();
            cboUF.DataSource = ufs;
            cboUF.DisplayMember = "UF";
            cboUF.ValueMember = "IdUF";
            cboUF.SelectedIndex = -1;
            if(en.IdEndereco != 0)
            {
                CarregaDados();
            }
            else
            {
                var pais = paises.Where(x => x.NomePais == "Brasil").FirstOrDefault();// new PaisDAL().getByParams("Brasil", "", "").FirstOrDefault();
                if(pais != null)
                {
                    cboPais.SelectedValue = pais.IdPais;
                }
            }
            cboUF.SelectedValue = 26;


            List<ComboItem> cid = new List<ComboItem>();
            cid.Add(new ComboItem() { Text = "Pilar do Sul", iValue = 5213 });
            cboCidade.DataSource = cid;
            cboCidade.DisplayMember = "Text";
            cboCidade.ValueMember = "iValue";



        }

        private void CarregaDados()
        {
            lbCodigo.Text = en.IdEndereco.ToString();
            cboTpEnd.SelectedValue = en.IdTipoEndereco;
            cboPais.SelectedValue = en.IdPais;
            cboUF.SelectedValue = en.IdUF;
            if (en.IdUF != 0)
            {
                int IdUF = Convert.ToInt32(cboUF.SelectedValue);
                var cidades = cidDal.Get().Where(x => x.IdUF == IdUF).ToList();
                cboCidade.DataSource = cidades;
                cboCidade.DisplayMember = "Nome";
                cboCidade.ValueMember = "IdCidade";
                cboCidade.SelectedIndex = -1;
            }
            cboCidade.SelectedValue = en.IdCidade;
            txtLog.Text = en.Logradouro;
            txtBairro.Text = en.Bairro;
            txtCEP.Text = en.CodigoPostal;
            txtNumero.Text = en.Numero;
            txtCompl.Text = en.Complemento;
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    //grava os dados do endereço
                    en.IdTipoEndereco = Convert.ToInt32(cboTpEnd.SelectedValue);
                    en.IdPais = Convert.ToInt32(cboPais.SelectedValue);
                    en.IdUF = Convert.ToInt32(cboUF.SelectedValue);
                    en.IdCidade = Convert.ToInt32(cboCidade.SelectedValue);
                    en.Logradouro = txtLog.Text;
                    en.Bairro = txtBairro.Text;
                    en.CodigoPostal = txtCEP.Text;
                    en.Numero = txtNumero.Text;
                    en.Complemento = txtCompl.Text;
                    if (en.IdEndereco == 0)
                    {
                        dal.Insert(en);
                        dal.Save();

                        //Vincula o endereço a sua origem
                        if (Origem == "Transporte")
                        {
                            TransportadoraEndereco te = new TransportadoraEndereco();
                            te.IdTransportadora = Id;
                            te.IdEndereco = en.IdEndereco;
                            TransportadoraDAL transpDal = new TransportadoraDAL();
                            transpDal.TERepository.Insert(te);
                            transpDal.Save();
                        }
                        else if (Origem == "Contato")
                        {
                            ContatoEndereco te = new ContatoEndereco();
                            te.IdContato = Id;
                            te.IdEndereco = en.IdEndereco;
                            ContatoDAL contatoDal = new ContatoDAL();
                            contatoDal.CERepository.Insert(te);
                            contatoDal.Save();
                        }
                        else if (Origem == "Contador")
                        {
                            ContadorEndereco te = new ContadorEndereco();
                            te.IdContador = Id;
                            te.IdEndereco = en.IdEndereco;
                            ContadorDAL contadorDal = new ContadorDAL();
                            contadorDal.CERepository.Insert(te);
                            contadorDal.Save();
                        }
                        else if (Origem == "Cliente")
                        {
                            ClienteEndereco te = new ClienteEndereco();
                            te.IdCliente = Id;
                            te.IdEndereco = en.IdEndereco;
                            ClienteDAL clienteDal = new ClienteDAL();
                            clienteDal.CERepository.Insert(te);
                            clienteDal.Save();
                        }
                        else if (Origem == "Fornecedor")
                        {
                            FornecedorEndereco te = new FornecedorEndereco();
                            te.IdFornecedor = Id;
                            te.IdEndereco = en.IdEndereco;
                            FornecedorDAL fornecedorDal = new FornecedorDAL();
                            fornecedorDal.FERepository.Insert(te);
                            fornecedorDal.Save();
                        }
                        else if (Origem == "Funcionario")
                        {
                            FuncionarioEndereco te = new FuncionarioEndereco();
                            te.IdFuncionario = Id;
                            te.IdEndereco = en.IdEndereco;
                            FuncionarioDAL funcionarioDal = new FuncionarioDAL();
                            funcionarioDal.FERepository.Insert(te);
                            funcionarioDal.Save();
                        }
                    }
                    else
                    {
                        dal.Update(en);
                        dal.Save();
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
            }
            else
            {
                Util.Aplicacao.ShowMessage("Por favor verifique as informações faltantes.");
            }
        }

        private void cboUF_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboUF.Text))
            {
                int IdUF = Convert.ToInt32(cboUF.SelectedValue);
                var cidades = cidDal.Get().Where(x => x.IdUF == IdUF).ToList();
                cboCidade.DataSource = cidades;
                cboCidade.DisplayMember = "Nome";
                cboCidade.ValueMember = "IdCidade";
                cboCidade.SelectedIndex = -1;
            }
        }

        private void frmEndereco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboUF_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
