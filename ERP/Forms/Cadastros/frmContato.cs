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
using ERP.DAL;

namespace ERP
{
    public partial class frmContato : RibbonForm
    {
        string Origem;
        int Id;
        Contato c = new Contato();
        public ContatoDAL contatoDal = new ContatoDAL();
        public frmContato(string pOrigem, int pId, Contato pCon)
        {
            Origem = pOrigem;
            Id = pId;
            c = pCon;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmTelefone_Load(object sender, EventArgs e)
        {
            CarregaDados();
        }

        protected void CarregaDados()
        {
            txtNome.Text = c.Nome;
            txtCPF.Text = c.CPF;
            txtEmail.Text = c.EMail;
            CarregaEnderecos();
            CarregaTelefones();
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtCPF.Text))
            //{
            //    string cpf = txtCPF.Text.Replace(",", "").Replace(".", "").Replace("-", "").Trim();
            //    if (!Util.Validacao.ValidaCPF.IsCpf(cpf))
            //    {
            //        Util.Aplicacao.ShowMessage("CPF inválido!");
            //        return;
            //    }
            //}

            if (!String.IsNullOrEmpty(txtEmail.Text))
            {
                if (!Util.Validacao.ValidaEmail(txtEmail.Text))
                {
                    Util.Aplicacao.ShowMessage("Email inválido!");
                    return;
                }
            }

            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    c.Nome = txtNome.Text;
                    c.CPF = txtCPF.Text.Replace(",", "").Replace(".", "").Replace("-", "").Trim();
                    c.EMail = txtEmail.Text;
                    c.IdEndereco = null;
                    c.IdTelefone = null;
                    if (c.IdContato == 0)
                    {
                        contatoDal.CRepository.Insert(c);
                        contatoDal.Save();
                        //Vincula o endereço a sua origem
                        if (Origem == "Transporte")
                        {
                            TransportadoraContato tc = new TransportadoraContato();
                            tc.IdTransportadora = Id;
                            tc.IdContato = c.IdContato;
                            TransportadoraDAL transpDal = new TransportadoraDAL();
                            transpDal.TCRepository.Insert(tc);
                            transpDal.Save();
                        }
                        if (Origem == "Cliente")
                        {
                            ClienteContato tc = new ClienteContato();
                            tc.IdCliente = Id;
                            tc.IdContato = c.IdContato;
                            ClienteContatoDAL cDal = new ClienteContatoDAL();
                            cDal.Insert(tc);
                            cDal.Save();
                        }
                        if (Origem == "Fornecedor")
                        {
                            FornecedorContato tc = new FornecedorContato();
                            tc.IdFornecedor = Id;
                            tc.IdContato = c.IdContato;
                            FornecedorContatoDAL fDal = new FornecedorContatoDAL();
                            fDal.Insert(tc);
                            fDal.Save();
                        }
                    }
                    else
                    {
                        contatoDal.CRepository.Update(c);
                        contatoDal.Save();
                    }

                    Util.Aplicacao.ShowMessage("Informações Salvas.");
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowMessage("Por Favor verifique os dados, não foi possível gravar as informações." + "\n" + "\n" + "Erro: " + ex.Message);
                }
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (c.IdContato != 0)
            {
                frmEndereco cad = new frmEndereco("Contato", c.IdContato, new Endereco());
                cad.ShowDialog();
                CarregaEnderecos();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Salve as informações principais para poder cadastrar endereços.");
            }
        }

        protected void CarregaEnderecos()
        {
            EnderecoDAL edal = new EnderecoDAL(new DB_ERPContext());
            var Enderecos = edal.getContato(c.IdContato).Select(x => new { x.IdContatoEndereco, x.Endereco.IdEndereco, x.Endereco.TipoEndereco.Descricao, x.Endereco.Logradouro, x.Endereco.Numero, x.Endereco.Bairro, x.Endereco.Cidade.Nome }).ToList();
            grEndereco.RowHeadersVisible = false;
            grEndereco.DataSource = Enderecos;
        }

        private void grEndereco_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grEndereco.Rows.Count > 0)
            {
                string sId = grEndereco.Rows[e.RowIndex].Cells[1].Value.ToString();
                int id = Convert.ToInt32(sId);
                EnderecoDAL endDal = new EnderecoDAL(new DB_ERPContext());
                Endereco en = endDal.GetByID(id);
                frmEndereco cad = new frmEndereco("Contato", c.IdContato, en);
                cad.dal = endDal;
                cad.ShowDialog();
                CarregaEnderecos();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (grEndereco.Rows.Count > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Confirma a exclusão do endereço") == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(grEndereco.Rows[grEndereco.SelectedRows[0].Index].Cells[0].Value.ToString());
                    ContatoEndereco te = contatoDal.CERepository.GetByID(id);
                    int IdEndereco = te.IdEndereco;

                    //apaga o relacionamento
                    contatoDal.CERepository.Delete(id);
                    contatoDal.Save();

                    //apaga o endereço
                    EnderecoDAL eDal = new EnderecoDAL(new DB_ERPContext());
                    eDal.Delete(te.IdEndereco);
                    eDal.Save();
                    CarregaEnderecos();
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (c.IdContato != 0)
            {
                frmTelefone cad = new frmTelefone("Contato", c.IdContato, new Telefone());
                cad.ShowDialog();
                CarregaTelefones();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Salve as informações principais para poder cadastrar telefones.");
            }
        }

        protected void CarregaTelefones()
        {
            TelefoneDAL tDal = new TelefoneDAL(new DB_ERPContext());
            var telefones = tDal.getContato(c.IdContato).Select(x => new { x.IdContatoTelefone, x.IdTelefone, x.Telefone.TipoTelefone.Descricao, x.Telefone.CodigoPais, x.Telefone.DDD, x.Telefone.NumeroTelefone }).ToList();
            grTelefone.RowHeadersVisible = false;
            grTelefone.DataSource = telefones;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (grTelefone.Rows.Count > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Confirma a exclusão do telefone") == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(grTelefone.Rows[grTelefone.SelectedRows[0].Index].Cells[1].Value.ToString());
                    ContatoDAL dal = new ContatoDAL();
                    ContatoTelefone te = dal.CTRepository.GetByID(id);
                    int Idtelefone = te.IdTelefone;

                    //apaga o relacionamento
                    dal.CTRepository.Delete(id);
                    dal.Save();

                    //apaga o endereço
                    TelefoneDAL eDal = new TelefoneDAL(new DB_ERPContext());
                    eDal.Delete(te.IdTelefone);
                    eDal.Save();
                    CarregaTelefones();
                }
            }
        }
    }
}
