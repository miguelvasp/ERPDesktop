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
using ERP.Models;

namespace ERP
{
    public partial class frmTelefone : RibbonForm
    {
        string Origem;
        int Id;
        Telefone Tel = new Telefone();
        public TelefoneDAL tDal = new TelefoneDAL(new DB_ERPContext());
        public frmTelefone(string pOrigem, int pId, Telefone pTel)
        {
            Origem = pOrigem;
            Id = pId;
            Tel = pTel;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmTelefone_Load(object sender, EventArgs e)
        {
            TipoTelefoneDAL tpDal = new TipoTelefoneDAL(new DB_ERPContext());
            var tipos = tpDal.Get().OrderBy(x => x.Descricao).ToList();
            cboTpTel.DataSource = tipos;
            cboTpTel.DisplayMember = "Descricao";
            cboTpTel.ValueMember = "IdTipoTelefone";
            cboTpTel.SelectedIndex = -1;
            if(Tel.IdTelefone != 0)
            {
                CarregaDados();
            }
            else
            {
                txtPais.Text = "+55";
            }
            
        }

        protected void CarregaDados()
        {
            cboTpTel.SelectedValue = Tel.IdTipoTelefone;
            txtPais.Text = Tel.CodigoPais;
            txtDDD.Text = Tel.DDD;
            txtTel.Text = Tel.NumeroTelefone;
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            
            if(Util.Validacao.ValidaCampos(this))
            {
                Tel.IdTipoTelefone = Convert.ToInt32(cboTpTel.SelectedValue);
                Tel.CodigoPais = txtPais.Text;
                Tel.DDD = txtDDD.Text;
                Tel.NumeroTelefone = txtTel.Text;
                if(Tel.IdTelefone == 0)
                {
                    tDal.Insert(Tel);
                    tDal.Save();
                    //Vincula o endereço a sua origem
                    if (Origem == "Transporte")
                    {
                        TransportadoraTelefone te = new TransportadoraTelefone();
                        te.IdTransportadora = Id;
                        te.IdTelefone = Tel.IdTelefone;
                        TransportadoraDAL transpDal = new TransportadoraDAL();
                        transpDal.TTRepository.Insert(te);
                        transpDal.Save();
                    }
                    else if(Origem == "Contato")
                    {
                        ContatoTelefone te = new ContatoTelefone();
                        te.IdContato = Id;
                        te.IdTelefone = Tel.IdTelefone;
                        ContatoDAL contatoDal = new ContatoDAL();
                        contatoDal.CTRepository.Insert(te);
                        contatoDal.Save();
                    }
                    else if (Origem == "Contador")
                    {
                        ContadorTelefone te = new ContadorTelefone();
                        te.IdContador = Id;
                        te.IdTelefone = Tel.IdTelefone;
                        ContadorDAL contadorDal = new ContadorDAL();
                        contadorDal.CTRepository.Insert(te);
                        contadorDal.Save();
                    }
                    else if (Origem == "Cliente")
                    {
                        ClienteTelefone te = new ClienteTelefone();
                        te.IdCliente = Id;
                        te.IdTelefone = Tel.IdTelefone;
                        ClienteDAL clienteDal = new ClienteDAL();
                        clienteDal.CTRepository.Insert(te);
                        clienteDal.Save();
                    }
                    else if (Origem == "Fornecedor")
                    {
                        FornecedorTelefone te = new FornecedorTelefone();
                        te.IdFornecedor = Id;
                        te.IdTelefone = Tel.IdTelefone;
                        FornecedorDAL fornecedorDal = new FornecedorDAL();
                        fornecedorDal.FTRepository.Insert(te);
                        fornecedorDal.Save();
                    }
                    else if (Origem == "Funcionario")
                    {
                        FuncionarioTelefone te = new FuncionarioTelefone();
                        te.IdFuncionario = Id;
                        te.IdTelefone = Tel.IdTelefone;
                        FuncionarioDAL funcionarioDal = new FuncionarioDAL();
                        funcionarioDal.FTRepository.Insert(te);
                        funcionarioDal.Save();
                    }
                }
                else
                {
                    tDal.Update(Tel);
                    tDal.Save();
                }
                this.Close();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Por favor verifique as informações.");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
