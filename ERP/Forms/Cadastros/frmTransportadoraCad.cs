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

namespace ERP
{
    public partial class frmTransportadoraCad : RibbonForm
    {
        Transportadora t = new Transportadora();
        public TransportadoraDAL dal = new TransportadoraDAL();
        UnidadeFederacaoDAL ufdal = new UnidadeFederacaoDAL(new DB_ERPContext());
        CidadeDAL cidDal = new CidadeDAL();


        public frmTransportadoraCad(Transportadora trans)
        {
            t = trans;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmTransportadoraCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (t.IdTransportadora == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = t.IdTransportadora.ToString();
            txtRazao.Text = t.RazaoSocial;
            txtFantasia.Text = t.NomeFantasia;
            txtCNPJ.Text = t.CNPJ;
            txtInscricao.Text = t.InscricaoEstadual;
            txtEmail.Text = t.email;
            txtRNTRC.Text = t.RNTRC;
            CarregaEnderecos();
            CarregaTelefones();
            CarregaContatos();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            t = new Transportadora();
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
            if (!Util.Validacao.ValidaCNPJ.IsCnpj(txtCNPJ.Text))
            {
                Util.Aplicacao.ShowMessage("CNPJ inválido!");
                return;
            }
            else //verifica se o CNPJ já está cadastrado
            {
                if (dal.ConsultaCNPJ(txtCNPJ.Text))
                {
                    Util.Aplicacao.ShowMessage("CNPJ já existe na base de dados.");
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
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    t.RazaoSocial = txtRazao.Text;
                    t.NomeFantasia = txtFantasia.Text;
                    t.CNPJ = txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "");
                    t.InscricaoEstadual = txtInscricao.Text;
                    t.email = txtEmail.Text;
                    t.RNTRC = txtRNTRC.Text;
                    if (t.IdTransportadora == 0)
                    {
                        dal.TRepository.Insert(t);
                    }
                    else
                    {
                        dal.TRepository.Update(t);
                    }
                    dal.Save();
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
                    int id = t.IdTransportadora;
                    dal.TRepository.Delete(id);
                    dal.Save();
                    Close();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowMessage("Este registro não pode ser excluído." + "\n" + "\n" + "Erro: " + ex.Message);
            }
        }

        private void frmTransportadoraCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboUF_Leave(object sender, EventArgs e)
        {


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (t.IdTransportadora != 0)
            {
                frmEndereco cad = new frmEndereco("Transporte", t.IdTransportadora, new Endereco());
                cad.ShowDialog();
                CarregaEnderecos();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Salve as informações principais para poder cadastrar endereços.");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Confirma a exclusão do endereço") == System.Windows.Forms.DialogResult.Yes)
            {
                int id = Convert.ToInt32(grEndereco.Rows[grEndereco.SelectedRows[0].Index].Cells[0].Value.ToString());
                TransportadoraEndereco te = dal.TERepository.GetByID(id);
                int IdEndereco = te.IdEndereco;

                //apaga o relacionamento
                dal.TERepository.Delete(id);
                dal.Save();

                //apaga o endereço
                EnderecoDAL eDal = new EnderecoDAL(new DB_ERPContext());
                eDal.Delete(te.IdEndereco);
                eDal.Save();
                CarregaEnderecos();

            }
        }

        protected void CarregaEnderecos()
        {
            EnderecoDAL Edal = new EnderecoDAL(new DB_ERPContext());
            var Enderecos = Edal.getTranporte(t.IdTransportadora).Select(x => new { x.IdTransportadoraEndereco, x.Endereco.IdEndereco, x.Endereco.TipoEndereco.Descricao, x.Endereco.Logradouro, x.Endereco.Numero, x.Endereco.Bairro, x.Endereco.Cidade.Nome }).ToList();
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
                frmEndereco cad = new frmEndereco("Transporte", t.IdTransportadora, en);
                cad.dal = endDal;
                cad.ShowDialog();
                CarregaEnderecos();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (t.IdTransportadora != 0)
            {
                frmTelefone cad = new frmTelefone("Transporte", t.IdTransportadora, new Telefone());
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
            var telefones = tDal.getTranporte(t.IdTransportadora).Select(x => new { x.IdTransportadoraTelefone, x.IdTelefone, x.Telefone.TipoTelefone.Descricao, x.Telefone.CodigoPais, x.Telefone.DDD, x.Telefone.NumeroTelefone }).ToList();
            grTelefone.RowHeadersVisible = false;
            grTelefone.DataSource = telefones;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Confirma a exclusão do telefone") == System.Windows.Forms.DialogResult.Yes)
            {
                int id = Convert.ToInt32(grTelefone.Rows[grTelefone.SelectedRows[0].Index].Cells[1].Value.ToString());
                TransportadoraTelefone te = dal.TTRepository.GetByID(id);
                int Idtelefone = te.IdTelefone;

                //apaga o relacionamento
                dal.TTRepository.Delete(id);
                dal.Save();

                //apaga o endereço
                TelefoneDAL eDal = new TelefoneDAL(new DB_ERPContext());
                eDal.Delete(te.IdTelefone);
                eDal.Save();
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
                frmTelefone cad = new frmTelefone("Transporte", t.IdTransportadora, te);
                cad.tDal = tDal;
                cad.ShowDialog();
                CarregaEnderecos();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (t.IdTransportadora != 0)
            {
                frmContato cad = new frmContato("Transporte", t.IdTransportadora, new Contato());
                cad.ShowDialog();
                CarregaContatos();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Salve as informações principais para poder cadastrar telefones.");
            }
        }

        protected void CarregaContatos()
        {
            ContatoDAL cdal = new ContatoDAL();
            var lista = cdal.getTransporte(t.IdTransportadora).Select(x => new { x.IdTransportadoraContato, x.IdContato, x.Contato.Nome, x.Contato.EMail }).ToList();
            grContato.DataSource = lista;
        }

        private void grContato_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grContato.Rows.Count > 0)
            {
                string sId = grContato.Rows[e.RowIndex].Cells[1].Value.ToString();
                int id = Convert.ToInt32(sId);
                ContatoDAL cDal = new ContatoDAL();
                Contato te = cDal.CRepository.GetByID(id);
                frmContato cad = new frmContato("Transporte", t.IdTransportadora, te);
                cad.contatoDal = cDal;
                cad.ShowDialog();
                CarregaContatos();
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Confirma a exclusão do contato") == System.Windows.Forms.DialogResult.Yes)
            {
                int id = Convert.ToInt32(grContato.Rows[grContato.SelectedRows[0].Index].Cells[0].Value.ToString());
                TransportadoraContato te = dal.TCRepository.GetByID(id);
                int IdContato = te.IdContato;

                //apaga o relacionamento
                dal.TCRepository.Delete(id);
                dal.Save();

                //apaga o endereço
                ContatoDAL eDal = new ContatoDAL();
                eDal.CRepository.Delete(te.IdContato);
                eDal.Save();
                CarregaContatos();

            }
        }

    }
}
