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

namespace ERP
{
    public partial class frmEmpresaCad : RibbonForm
    {
        public EmpresaDAL dal;
        Empresa emp = new Empresa();
        UnidadeFederacaoDAL ufdal = new UnidadeFederacaoDAL(new DB_ERPContext());
        CidadeDAL cidDal = new CidadeDAL();

        public frmEmpresaCad(Empresa pEmpresa)
        {
            
            emp = pEmpresa;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmEmpresaCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregaContador();
            CarregaUF();
            CarregaMoeda();
            CarregaCRT();


            if (emp.IdEmpresa == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                btnProcurarImagem.Enabled = true;
                btnLimparLogo.Enabled = true;
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmEmpresaCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = emp.IdEmpresa.ToString();
            txtRazao.Text = emp.RazaoSocial;
            txtFantasia.Text = emp.Fantasia;
            txtCNPJ.Text = emp.CNPJ;
            txtInscricao.Text = emp.IE;
            if (emp.Logo != null)
            {
                picLogo.Image = Util.Util.ByteArrayToImage(emp.Logo);
            }

            if (emp.IdUF != null && emp.IdUF != 0)
            {
                cboUF.SelectedValue = emp.IdUF;

                int IdUF = Convert.ToInt32(cboUF.SelectedValue);
                var cidades = cidDal.GetByIdUF(IdUF);
                cboCidade.DataSource = cidades;
                cboCidade.DisplayMember = "Nome";
                cboCidade.ValueMember = "IdCidade";
                cboCidade.SelectedIndex = -1;
            }

            if (emp.IdCidade != null && emp.IdCidade != 0)
            {
                cboCidade.SelectedValue = emp.IdCidade;
            }

            txtLog.Text = emp.Endereco;
            txtBairro.Text = emp.Bairro;
            txtCEP.Text = emp.CEP;
            txtNumero.Text = emp.Numero;
            txtCompl.Text = emp.Complemento;
            txtTelefone.Text = emp.Telefone;
            txtTelefone2.Text = emp.Telefone2;
            cboMoeda.SelectedValue = emp.IdMoeda == null ? 0 : emp.IdMoeda;
            txtFax.Text = emp.Fax;
            cboRegimeTributario.SelectedValue = emp.CRT == null ? 0 : Convert.ToInt32(emp.CRT);
            txtEmail.Text = emp.Email;
            if (emp.IdContador != null)
                cboContador.SelectedValue = emp.IdContador;

            CarregaContasBancarias();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            btnProcurarImagem.Enabled = false;
            btnLimparLogo.Enabled = false;

            Cursor.Current = Cursors.Default;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            emp = new Empresa();
            lbCodigo.Text = "0";
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            btnProcurarImagem.Enabled = true;
            btnLimparLogo.Enabled = true;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            btnProcurarImagem.Enabled = true;
            btnLimparLogo.Enabled = true;
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            string cnpj = txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "").Trim();
            if (!string.IsNullOrEmpty(cnpj))
            {
                if (!Util.Validacao.ValidaCNPJ.IsCnpj(cnpj))
                {
                    Util.Aplicacao.ShowMessage("CNPJ inválido!");
                    return;
                }
                else //verifica se o CNPJ já está cadastrado
                {
                    if (dal.ConsultaCNPJ(cnpj, emp.IdEmpresa))
                    {
                        Util.Aplicacao.ShowMessage("CNPJ já existe na base de dados.");
                        return;
                    }
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

                    emp.RazaoSocial = txtRazao.Text;
                    emp.Fantasia = txtFantasia.Text;
                    emp.CNPJ = txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "").Trim();
                    emp.IE = txtInscricao.Text;
                    emp.IdUF = Convert.ToInt32(cboUF.SelectedValue);
                    emp.IdCidade = Convert.ToInt32(cboCidade.SelectedValue);
                    emp.Endereco = txtLog.Text;
                    emp.Bairro = txtBairro.Text;
                    emp.CEP = txtCEP.Text;
                    emp.Numero = txtNumero.Text;
                    emp.Complemento = txtCompl.Text;
                    emp.Telefone = txtTelefone.Text;
                    emp.Telefone2 = txtTelefone2.Text;
                    emp.Fax = txtFax.Text;
                    emp.Email = txtEmail.Text;
                    emp.IdMoeda = Convert.ToInt32(cboMoeda.SelectedValue);
                    emp.CRT = Convert.ToInt32(cboRegimeTributario.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContador.Text))
                        emp.IdContador = Convert.ToInt32(cboContador.SelectedValue);

                    if (picLogo.Image != null)
                    {
                        emp.Logo = Util.Util.ImageToByteArray(picLogo.Image);
                    }
                    else
                    {
                        emp.Logo = null;
                    }

                    if (emp.IdEmpresa == 0)
                    {
                        emp.UltimaFatura = 0;
                        emp.UltimaNotaFiscal = 0;
                        emp.UltimaNotaFiscalProvisoria = 0;
                        emp.UltimaNotaServico = 0;
                        emp.UltimoConhecimento = 0;
                        emp.UltimoPedidoCompras = 0;
                        emp.UltimoPedidoVendas = 0;
                        emp.UltimoRecebimento = 0;

                        dal.ERepository.Insert(emp);
                    }
                    else
                    {
                        dal.ERepository.Update(emp);
                    }

                    dal.Save();
                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                    btnProcurarImagem.Enabled = false;
                    btnLimparLogo.Enabled = false;
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
                btnProcurarImagem.Enabled = false;
                btnLimparLogo.Enabled = false;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == System.Windows.Forms.DialogResult.Yes)
            {
                int id = emp.IdEmpresa;
                dal.ERepository.Delete(id);
                dal.Save();
                this.Close();
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

        protected void CarregaContador()
        {
            cboContador.DataSource = new ContadorDAL().GetCombo();
            cboContador.DisplayMember = "Text";
            cboContador.ValueMember = "iValue";
            cboContador.SelectedIndex = -1;
        }

        protected void CarregaCRT()
        {
            List<ComboItem> CTR = new List<ComboItem>();
            CTR.Add(new ComboItem() { iValue = 1, Text = "Simples Nacional" });
            CTR.Add(new ComboItem() { iValue = 2, Text = "Simples Nacional - excesso de sublimite de receita bruta" });
            CTR.Add(new ComboItem() { iValue = 3, Text = "Regime Normal" });
            cboRegimeTributario.DataSource = CTR;
            cboRegimeTributario.DisplayMember = "Text";
            cboRegimeTributario.ValueMember = "iValue";
            cboRegimeTributario.SelectedIndex = -1;
        }

        protected void CarregaMoeda()
        {
            cboMoeda.DataSource = new MoedaDAL().GetCombo();
            cboMoeda.DisplayMember = "Text";
            cboMoeda.ValueMember = "iValue";
            cboMoeda.SelectedIndex = -1;
        }

        protected void CarregaContasBancarias()
        {
            ContaBancariaDAL cbdal = new ContaBancariaDAL();
            var lista = cbdal.getEmpresa(emp.IdEmpresa).Select(x => new { x.IdContaBancaria, x.IdEmpresa, Banco = x.ContaBancaria.Banco.NomeBanco, Agencia = x.ContaBancaria.Agencia + "-" + x.ContaBancaria.DigitoAgencia, Conta = x.ContaBancaria.Conta + "-" + x.ContaBancaria.DigitoConta }).ToList();
            grContaBancaria.AutoGenerateColumns = false;
            grContaBancaria.RowHeadersVisible = false;
            grContaBancaria.DataSource = lista;
        }

        private void CarregaUF()
        {
            //Carrega uf
            var ufs = ufdal.Get().OrderBy(x => x.UF).ToList();
            cboUF.DataSource = ufs;
            cboUF.DisplayMember = "UF";
            cboUF.ValueMember = "IdUF";
            cboUF.SelectedIndex = -1;
        }

        private void tsbAdicionarContaBancaria_Click(object sender, EventArgs e)
        {
            if (emp.IdEmpresa != 0)
            {
                frmContaBancaria cad = new frmContaBancaria("Empresa", emp.IdEmpresa, new ContaBancaria());
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
                    EmpresaContaBancaria ccb = dal.ECBRepository.GetByID(id);
                    int IdContaBancaria = ccb.IdContaBancaria;

                    //apaga o relacionamento
                    dal.ECBRepository.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    //apaga a Conta Bancária
                    ContaBancariaDAL cbDal = new ContaBancariaDAL();
                    cbDal.Delete(ccb.IdContaBancaria);
                    cbDal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaContasBancarias();
                }
            }
        }

        private void grContaBancaria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //int id = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
            //ContaBancaria conta = dal.GetByID(id);
            //frmContaBancariaCad contabancaria = new frmContaBancariaCad(conta);
            //contabancaria.dal = dal;
            if (grContaBancaria.Rows.Count > 0)
            {
                string sId = grContaBancaria.Rows[e.RowIndex].Cells[1].Value.ToString();
                int id = Convert.ToInt32(sId);
                ContaBancariaDAL cbDal = new ContaBancariaDAL();
                ContaBancaria cb = cbDal.GetByID(id);
                //frmContaBancaria cad = new frmContaBancaria("Empresa", emp.IdEmpresa, cb);
                //cad.dal = cbDal;
                //cad.ShowDialog();
                //int id = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                ContaBancaria conta = cbDal.GetByID(id);
                frmContaBancariaCad contabancaria = new frmContaBancariaCad(conta);
                contabancaria.dal = cbDal;
                contabancaria.ShowDialog();
                CarregaContasBancarias();
            }
        }

        private void btnProcurarImagem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Ler arquivo para o Logo";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Util.Util.CurrentBitmap = new Bitmap(ofd.FileName);
  
                    picLogo.Image = Util.Util.ResizeImage(140, 60);
                }
            }
        }

        private void btnLimparLogo_Click(object sender, EventArgs e)
        {
            picLogo.Image = null;
        }

        private void rbbConfiguracao_Click(object sender, EventArgs e)
        {
            if (emp.IdEmpresa != 0)
            {
                frmEmpresaConfiguracao frm = new frmEmpresaConfiguracao(emp.IdEmpresa);
                frm.ShowDialog();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Salve as informações principais para poder cadastrar as configurações.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
