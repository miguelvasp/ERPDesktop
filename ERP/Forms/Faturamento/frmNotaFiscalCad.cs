using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ERP.BLL;
using ERP.Auxiliares;
using ERP.Faturamento;
using ERP.Forms.Faturamento;

namespace ERP
{
    public partial class frmNotaFiscalCad : RibbonForm
    {
        public NotaFiscalDAL dal = new NotaFiscalDAL();
        public NotaFiscalItemDAL iDal = new NotaFiscalItemDAL();
        public NotaFiscalVencimentosDAL vDal = new NotaFiscalVencimentosDAL();
        NotaFiscalObsDAL oDal = new NotaFiscalObsDAL();
        public RecebimentoDAL rDal = new RecebimentoDAL();
        public NotaFiscal n = null;
        int iTipoDocumento;

        public frmNotaFiscalCad(NotaFiscal pN, int pTipoDocumento)
        {
            n = pN;
            iTipoDocumento = pTipoDocumento;
            InitializeComponent();
        }

        public frmNotaFiscalCad()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmAutoridadeCad_Load(object sender, EventArgs e)
        {
            CarregaCombos();
            if (n.IdNotaFiscal == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void CarregaCombos()
        {
            //cboCFOP.DataSource = new CFOPDAL().GetCombo();
            //cboCFOP.DisplayMember = "Text";
            //cboCFOP.ValueMember = "iValue";
            //cboCFOP.SelectedIndex = -1;

            cboCidade.DataSource = new CidadeDAL().GetCombo();
            cboCidade.DisplayMember = "Text";
            cboCidade.ValueMember = "iValue";
            cboCidade.SelectedIndex = -1;


            if (iTipoDocumento == 3)//nota fiscal de entrada de fornecedores
            {
                /*Em caso de nota fiscal de entrada de fornecedores o destinatário é a empresa logada e o emitente o fornecedor*/

                Empresa empresa = new EmpresaDAL().ERepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
                List<ComboItem> Dest = new List<ComboItem>();
                Dest.Add(new ComboItem() { iValue = empresa.IdEmpresa, Text = empresa.RazaoSocial });
                cboDestinatario.DataSource = Dest;
                cboDestinatario.DisplayMember = "Text";
                cboDestinatario.ValueMember = "iValue";

                cboEmitente.DataSource = new FornecedorDAL().GetCombo2(Util.Util.GetAppSettings("IdEmpresa"));
                cboEmitente.DisplayMember = "Text";
                cboEmitente.ValueMember = "iValue";
                cboEmitente.SelectedIndex = -1;
            }
            else if (iTipoDocumento == 6)
            {
                Empresa empresa = new EmpresaDAL().ERepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
                List<ComboItem> Emit = new List<ComboItem>();
                Emit.Add(new ComboItem() { iValue = empresa.IdEmpresa, Text = empresa.RazaoSocial });
                cboEmitente.DataSource = Emit;
                cboEmitente.DisplayMember = "Text";
                cboEmitente.ValueMember = "iValue";

                cboDestinatario.DataSource = new ClienteDAL().GetCombo(empresa.IdEmpresa.ToString());
                cboDestinatario.DisplayMember = "Text";
                cboDestinatario.ValueMember = "iValue";
                cboDestinatario.SelectedIndex = -1;
            }
            else if (iTipoDocumento == 8)//nota fiscal de devolucao
            {
                /*Em caso de nota fiscal de entrada de fornecedores o destinatário é a empresa logada e o emitente o fornecedor*/

                Empresa empresa = new EmpresaDAL().ERepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
                List<ComboItem> Dest = new List<ComboItem>();
                Dest.Add(new ComboItem() { iValue = empresa.IdEmpresa, Text = empresa.RazaoSocial });
                cboDestinatario.DataSource = Dest;
                cboDestinatario.DisplayMember = "Text";
                cboDestinatario.ValueMember = "iValue";

                cboEmitente.DataSource = new ClienteDAL().GetCombo(empresa.IdEmpresa.ToString());
                cboEmitente.DisplayMember = "Text";
                cboEmitente.ValueMember = "iValue";
                cboEmitente.SelectedIndex = -1;
            }

            List<ComboItem> direcao = new List<ComboItem>();
            direcao.Add(new ComboItem() { iValue = 1, Text = "Entrada" });
            direcao.Add(new ComboItem() { iValue = 2, Text = "Saída" });
            cboDirecaoCFOP.DataSource = direcao;
            cboDirecaoCFOP.DisplayMember = "Text";
            cboDirecaoCFOP.ValueMember = "iValue";
            cboDirecaoCFOP.SelectedIndex = -1;

            List<ComboItem> documento = new List<ComboItem>();
            documento.Add(new ComboItem() { iValue = 3, Text = "Nota Fiscal Entrada" });
            documento.Add(new ComboItem() { iValue = 6, Text = "Nota Fiscal Vendas" });
            documento.Add(new ComboItem() { iValue = 8, Text = "Nota Fiscal Devolução" });

            cboDocumento.DataSource = documento;
            cboDocumento.DisplayMember = "Text";
            cboDocumento.ValueMember = "iValue";
            cboDocumento.SelectedIndex = -1;



            List<ComboItem> finalidade = new List<ComboItem>();
            finalidade.Add(new ComboItem() { iValue = 1, Text = "Nfe Normal" });
            finalidade.Add(new ComboItem() { iValue = 2, Text = "Nfe Complementar" });
            finalidade.Add(new ComboItem() { iValue = 3, Text = "Nfe Ajuste" });
            finalidade.Add(new ComboItem() { iValue = 4, Text = "Devolução" });

            cboFinalidadeEmissao.DataSource = finalidade;
            cboFinalidadeEmissao.DisplayMember = "Text";
            cboFinalidadeEmissao.ValueMember = "iValue";
            cboFinalidadeEmissao.SelectedIndex = -1;



            List<ComboItem> formaEmissao = new List<ComboItem>();
            formaEmissao.Add(new ComboItem() { iValue = 1, Text = "Emissão normal (não em contingência)" });
            formaEmissao.Add(new ComboItem() { iValue = 2, Text = "Contingência FS-IA, com impressão do DANFE em formulário de segurança" });
            formaEmissao.Add(new ComboItem() { iValue = 3, Text = "Contingência SCAN (Sistema de Contingência do Ambiente Nacional)" });
            formaEmissao.Add(new ComboItem() { iValue = 4, Text = "Contingência DPEC (Declaração Prévia da Emissão em Contingência)" });
            formaEmissao.Add(new ComboItem() { iValue = 5, Text = "Contingência FS-DA, com impressão do DANFE em formulário de segurança" });
            formaEmissao.Add(new ComboItem() { iValue = 6, Text = "Contingência SVC-AN (SEFAZ Virtual de Contingência do AN)" });
            formaEmissao.Add(new ComboItem() { iValue = 7, Text = "Contingência SVC-RS (SEFAZ Virtual de Contingência do RS)" });
            formaEmissao.Add(new ComboItem() { iValue = 9, Text = "Contingência off-line da NFC-e" });
            cboFormaEmissao.DataSource = formaEmissao;
            cboFormaEmissao.DisplayMember = "Text";
            cboFormaEmissao.ValueMember = "iValue";
            cboFormaEmissao.SelectedIndex = -1;

            List<ComboItem> situacao = new List<ComboItem>();
            situacao.Add(new ComboItem() { iValue = 1, Text = "A emitir" });
            situacao.Add(new ComboItem() { iValue = 2, Text = "Emitida" });
            situacao.Add(new ComboItem() { iValue = 3, Text = "Cancelada" });
            cboStatus.DataSource = situacao;
            cboStatus.DisplayMember = "Text";
            cboStatus.ValueMember = "iValue";
            cboStatus.SelectedIndex = -1;


            List<ComboItem> tipoAtendimento = new List<ComboItem>();
            tipoAtendimento.Add(new ComboItem() { iValue = 0, Text = "Não se aplica (por exemplo, para a Nota Fiscal complementar ou de ajuste)" });
            tipoAtendimento.Add(new ComboItem() { iValue = 1, Text = "Operação presencial" });
            tipoAtendimento.Add(new ComboItem() { iValue = 2, Text = "Operação não presencial, pela Internet" });
            tipoAtendimento.Add(new ComboItem() { iValue = 3, Text = "Operação não presencial, Teleatendimento" });
            tipoAtendimento.Add(new ComboItem() { iValue = 4, Text = "NFC-e em operação com entrega em domicílio" });
            tipoAtendimento.Add(new ComboItem() { iValue = 9, Text = "Operação não presencial, outros" });

            cboTipoAtendimento.DataSource = tipoAtendimento;
            cboTipoAtendimento.DisplayMember = "Text";
            cboTipoAtendimento.ValueMember = "iValue";
            cboTipoAtendimento.SelectedIndex = -1;


            cboTipoFrete.DataSource = new CondicaoFreteDAL().GetCombo();
            cboTipoFrete.DisplayMember = "Text";
            cboTipoFrete.ValueMember = "iValue";
            cboTipoFrete.SelectedIndex = -1;

            cboTransportadora.DataSource = new TransportadoraDAL().GetCombo();
            cboTransportadora.DisplayMember = "Text";
            cboTransportadora.ValueMember = "iValue";
            cboTransportadora.SelectedIndex = -1;
        }

        private void frmAutoridadeCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            //cboCFOP.SelectedValue = n.IdCFOP == null ? 0 : n.IdCFOP;
            cboCidade.SelectedValue = n.IdCidade == null ? 0 : n.IdCidade;
            cboDestinatario.SelectedValue = n.IdDestinatario == null ? 0 : n.IdDestinatario;
            cboDirecaoCFOP.SelectedValue = n.DirecaoCFOP == null ? 0 : n.DirecaoCFOP;
            cboDocumento.SelectedValue = n.IdDocumento == null ? 0 : n.IdDocumento;
            cboEmitente.SelectedValue = n.IdEmitente == null ? 0 : n.IdEmitente;
            cboFinalidadeEmissao.SelectedValue = n.FinalidadeEmissao == null ? 0 : n.FinalidadeEmissao;
            cboFormaEmissao.SelectedValue = n.FormaEmissao == null ? 0 : n.FormaEmissao;
            cboStatus.SelectedValue = n.NotaStatus == null ? 0 : n.NotaStatus;
            cboTipoAtendimento.SelectedValue = n.TipoAtendimento == null ? 0 : n.TipoAtendimento;
            cboTipoFrete.SelectedValue = n.TipoFrete == null ? 0 : n.TipoFrete;
            cboTransportadora.SelectedValue = n.IdTransportadora == null ? 0 : n.IdTransportadora;
            txtBairro.Text = n.Bairro == null ? "" : n.Bairro.ToString();
            txtBaseICMS.Text = n.BaseICMS == null ? "" : n.BaseICMS.ToString();
            txtBaseICMSSubs.Text = n.BaseICMSSubs == null ? "" : n.BaseICMSSubs.ToString();
            txtBaseIPI.Text = n.BaseIPI == null ? "" : n.BaseIPI.ToString();
            txtCEP.Text = n.CEP == null ? "" : n.CEP.ToString();
            txtChaveNFe.Text = n.ChaveNFe == null ? "" : n.ChaveNFe.ToString();
            txtCNPJ.Text = n.CNPJ == null ? "" : n.CNPJ.ToString();
            txtComplemento.Text = n.Complemento == null ? "" : n.Complemento.ToString();
            txtDataAutorizacao.Text = n.DataAutorizacao == null ? "" : n.DataAutorizacao.ToString();
            txtDataCancelamento.Text = n.DataCancelamento == null ? "" : n.DataCancelamento.ToString();
            txtDataEntrada.Text = n.DataEntrada == null ? "" : n.DataEntrada.ToString();
            txtDataEntrega.Text = n.DataEntrega == null ? "" : n.DataEntrega.ToString();
            txtDataSaida.Text = n.DataSaida == null ? "" : n.DataSaida.ToString();
            txtEmissao.Text = n.DataEmissao == null ? "" : n.DataEmissao.ToString();
            txtEndereco.Text = n.Endereco == null ? "" : n.Endereco.ToString();
            txtEspecie.Text = n.Especie == null ? "" : n.Especie.ToString();
            txtIdNotaFiscal.Text = n.IdNotaFiscal.ToString();
            txtIE.Text = n.IE == null ? "" : n.IE.ToString();
            txtJustificativa.Text = n.JustificativaCancelamento == null ? "" : n.JustificativaCancelamento.ToString();
            txtNumero.Text = n.Numero == null ? "" : n.Numero.ToString();
            txtNumeroEndereco.Text = n.EnderecoNumero == null ? "" : n.EnderecoNumero.ToString();
            txtPesoBruto.Text = n.PesoBruto == null ? "" : n.PesoBruto.ToString();
            txtPesoLiquido.Text = n.PesoLiquido == null ? "" : n.PesoLiquido.ToString();
            txtPlaca.Text = n.TransPlaca == null ? "" : n.TransPlaca.ToString();
            txtProtocolo.Text = n.Protocolo == null ? "" : n.Protocolo.ToString();
            txtQuantidade.Text = n.Quantidade == null ? "" : n.Quantidade.ToString();
            txtSerie.Text = n.Serie == null ? "" : n.Serie.ToString();
            txtTelefone.Text = n.Telefone == null ? "" : n.Telefone.ToString();
            txtTotalNota.Text = n.TotalNF == null ? "0,0000" : n.TotalNF.ToString();
            txtUF.Text = n.UF == null ? "" : n.UF.ToString();
            txtUFtrans.Text = n.TransUF == null ? "" : n.TransUF.ToString();
            txtValorDesconto.Text = n.ValorDesconto == null ? "0,0000" : n.ValorDesconto.ToString();
            txtValorFrete.Text = n.ValorFrete == null ? "0,0000" : n.ValorFrete.ToString();
            txtValorICMS.Text = n.ValorICMS == null ? "0,0000" : n.ValorICMS.ToString();
            txtValorICMSSubs.Text = n.ValorICMSSubs == null ? "0,0000" : n.ValorICMSSubs.ToString();
            txtValorIPI.Text = n.ValorIPI == null ? "0,0000" : n.ValorIPI.ToString();
            txtValorMercadorias.Text = n.ValorMercadoria == null ? "0,0000" : n.ValorMercadoria.ToString();
            txtValorSeguro.Text = n.ValorSeguro == null ? "0,0000" : n.ValorSeguro.ToString();
            txtVolumes.Text = n.Volumes == null ? "0,0000" : n.Volumes.ToString();
            txtNomeOperacao.Text = n.NomeOperacao;
            txtNFEResultado.Text = n.NFeResultado;
            txtRef.Text = n.NFeReferencia;
            CarregaGrid();
            CarregaVencimentos();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            if(n.IdDocumento == 6)
            {
                if (!string.IsNullOrEmpty(n.Numero))
                {
                    ribbonPanel2.Enabled = true;
                }
                else
                {
                    ribbonPanel2.Enabled = false;
                }
            }
        }

        private void CarregaVencimentos()
        {
            var lista = vDal.GetByNF(n.IdNotaFiscal);
            dgVencimentos.AutoGenerateColumns = false;
            dgVencimentos.DataSource = lista;
        }
         
        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            n = new NotaFiscal();
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    n.Bairro = null;
                    n.BaseICMS = null;
                    n.BaseICMSSubs = null;
                    n.BaseIPI = null;
                    n.CEP = null;
                    n.CNPJ = null;
                    n.Complemento = null;
                    n.DataEntrada = null;
                    n.DataEntrega = null;
                    n.DataSaida = null;
                    n.Endereco = null;
                    n.Especie = null; 
                    n.DirecaoCFOP = null; 
                    n.FinalidadeEmissao = null;
                    n.FormaEmissao = null;
                    n.TipoAtendimento = null;
                    n.TipoFrete = null;
                    n.IdTransportadora = null;
                    n.IE = null;
                    n.Numero = null;
                    n.EnderecoNumero = null;
                    n.PesoBruto = null;
                    n.PesoLiquido = null;
                    n.TransPlaca = null;
                    n.Quantidade = null;
                    n.Serie = null;
                    n.Telefone = null;
                    n.TotalNF = null;
                    n.UF = null;
                    n.TransUF = null;
                    n.ValorDesconto = null;
                    n.ValorFrete = null;
                    n.ValorICMS = null;
                    n.ValorICMSSubs = null;
                    n.ValorIPI = null;
                    n.ValorMercadoria = null;
                    n.ValorSeguro = null;
                    n.Volumes = null;

                    //if (!String.IsNullOrEmpty(cboCFOP.Text)) n.IdCFOP = Convert.ToInt32(cboCFOP.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCidade.Text)) n.IdCidade = Convert.ToInt32(cboCidade.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDestinatario.Text)) n.IdDestinatario = Convert.ToInt32(cboDestinatario.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDirecaoCFOP.Text)) n.DirecaoCFOP = Convert.ToInt32(cboDirecaoCFOP.SelectedValue);
                    if (!String.IsNullOrEmpty(cboEmitente.Text)) n.IdEmitente = Convert.ToInt32(cboEmitente.SelectedValue);
                    if (!String.IsNullOrEmpty(cboFinalidadeEmissao.Text)) n.FinalidadeEmissao = Convert.ToInt32(cboFinalidadeEmissao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboFormaEmissao.Text)) n.FormaEmissao = Convert.ToInt32(cboFormaEmissao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoAtendimento.Text)) n.TipoAtendimento = Convert.ToInt32(cboTipoAtendimento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoFrete.Text)) n.TipoFrete = Convert.ToInt32(cboTipoFrete.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTransportadora.Text)) n.IdTransportadora = Convert.ToInt32(cboTransportadora.SelectedValue);
                    if (!String.IsNullOrEmpty(txtBairro.Text)) n.Bairro = txtBairro.Text;
                    if (!String.IsNullOrEmpty(txtBaseICMS.Text)) n.BaseICMS = Convert.ToDecimal(txtBaseICMS.Text);
                    if (!String.IsNullOrEmpty(txtBaseICMSSubs.Text)) n.BaseICMSSubs = Convert.ToDecimal(txtBaseICMSSubs.Text);
                    if (!String.IsNullOrEmpty(txtBaseIPI.Text)) n.BaseIPI = Convert.ToDecimal(txtBaseIPI.Text);
                    if (!String.IsNullOrEmpty(txtCEP.Text)) n.CEP = txtCEP.Text;
                    if (!String.IsNullOrEmpty(txtChaveNFe.Text)) n.ChaveNFe = txtChaveNFe.Text;
                    if (!String.IsNullOrEmpty(txtCNPJ.Text)) n.CNPJ = txtCNPJ.Text;
                    if (!String.IsNullOrEmpty(txtComplemento.Text)) n.Complemento = txtComplemento.Text;
                    if (!String.IsNullOrEmpty(txtDataEntrada.Text)) n.DataEntrada = Convert.ToDateTime(txtDataEntrada.Text);
                    if (!String.IsNullOrEmpty(txtDataEntrega.Text)) n.DataEntrega = Convert.ToDateTime(txtDataEntrega.Text);
                    if (!String.IsNullOrEmpty(txtDataSaida.Text)) n.DataSaida = Convert.ToDateTime(txtDataSaida.Text);
                    if (!String.IsNullOrEmpty(txtEmissao.Text)) n.DataEmissao = Convert.ToDateTime(txtEmissao.Text);
                    if (!String.IsNullOrEmpty(txtEndereco.Text)) n.Endereco = txtEndereco.Text;
                    if (!String.IsNullOrEmpty(txtEspecie.Text)) n.Especie = txtEspecie.Text;
                    if (!String.IsNullOrEmpty(txtIE.Text)) n.IE = txtIE.Text;
                    if (!String.IsNullOrEmpty(txtNumero.Text)) n.Numero = txtNumero.Text;
                    if (!String.IsNullOrEmpty(txtNumeroEndereco.Text)) n.EnderecoNumero = txtNumeroEndereco.Text;
                    if (!String.IsNullOrEmpty(txtPesoBruto.Text)) n.PesoBruto = Convert.ToDecimal(txtPesoBruto.Text);
                    if (!String.IsNullOrEmpty(txtPesoLiquido.Text)) n.PesoLiquido = Convert.ToDecimal(txtPesoLiquido.Text);
                    if (!String.IsNullOrEmpty(txtPlaca.Text)) n.TransPlaca = txtPlaca.Text;
                    if (!String.IsNullOrEmpty(txtQuantidade.Text)) n.Quantidade = Convert.ToDecimal(txtQuantidade.Text);
                    if (!String.IsNullOrEmpty(txtSerie.Text)) n.Serie = txtSerie.Text;
                    if (!String.IsNullOrEmpty(txtTelefone.Text)) n.Telefone = txtTelefone.Text;
                    if (!String.IsNullOrEmpty(txtTotalNota.Text)) n.TotalNF = Convert.ToDecimal(txtTotalNota.Text);
                    if (!String.IsNullOrEmpty(txtUF.Text)) n.UF = txtUF.Text;
                    if (!String.IsNullOrEmpty(txtUFtrans.Text)) n.TransUF = txtUFtrans.Text;
                    if (!String.IsNullOrEmpty(txtValorDesconto.Text)) n.ValorDesconto = Convert.ToDecimal(txtValorDesconto.Text);
                    if (!String.IsNullOrEmpty(txtValorFrete.Text)) n.ValorFrete = Convert.ToDecimal(txtValorFrete.Text);
                    if (!String.IsNullOrEmpty(txtValorICMS.Text)) n.ValorICMS = Convert.ToDecimal(txtValorICMS.Text);
                    if (!String.IsNullOrEmpty(txtValorICMSSubs.Text)) n.ValorICMSSubs = Convert.ToDecimal(txtValorICMSSubs.Text);
                    if (!String.IsNullOrEmpty(txtValorIPI.Text)) n.ValorIPI = Convert.ToDecimal(txtValorIPI.Text);
                    if (!String.IsNullOrEmpty(txtValorMercadorias.Text)) n.ValorMercadoria = Convert.ToDecimal(txtValorMercadorias.Text);
                    if (!String.IsNullOrEmpty(txtValorSeguro.Text)) n.ValorSeguro = Convert.ToDecimal(txtValorSeguro.Text);
                    if (!String.IsNullOrEmpty(txtVolumes.Text)) n.Volumes = Convert.ToDecimal(txtVolumes.Text);
                    n.NomeOperacao = txtNomeOperacao.Text;
                    n.NFeReferencia = txtRef.Text;

                    if (n.IdNotaFiscal == 0)
                    {
                        dal.Insert(n);
                    }
                    else
                    {
                        dal.Update(n);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
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
            if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == System.Windows.Forms.DialogResult.Yes)
            {
                int id = n.IdNotaFiscal;
                dal.Delete(id);
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void CarregaGrid()
        {
            var lista = iDal.GetByNFGrid(n.IdNotaFiscal);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista;

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = oDal.getByNotaId(n.IdNotaFiscal);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["id"].Value);


                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void maskedTextBox5_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value);
                NotaFiscalItem nfi = iDal.GetByID(id);
                frmNotaFiscalItemCad frmItem = new frmNotaFiscalItemCad(nfi);
                frmItem.dal = iDal;
                frmItem.ShowDialog();
                CarregaGrid();
            }
        }

        private void rbConfirmar_Click(object sender, EventArgs e)
        {
            



            if(n.DirecaoCFOP == 2)
            {
                if (cboTipoFrete.Text == "")
                {
                    Util.Aplicacao.ShowMessage("Informe o tipo de frete");
                    return;
                }

                //verifica os itens
                var lista = iDal.GetByNF(n.IdNotaFiscal);
                foreach (var i in lista)
                {
                    if (i.IdCFOP == null || i.IdCFOP == 0)
                    {
                        Util.Aplicacao.ShowMessage("informe o CFOP dos itens!");
                        return;
                    }

                    if (i.IdNCM == null)
                    {
                        Util.Aplicacao.ShowMessage("informe o NCM dos itens!");
                        return;
                    }
                }
            }
            

            



            if (Util.Aplicacao.ShowQuestionMessage("Deseja confirmar os dados da nota fiscal? \n Uma vez confirmada a operação não poderá ser desfeita.") == System.Windows.Forms.DialogResult.Yes)
            {
                string Message = "";
                EmpresaDAL edal = new EmpresaDAL();
                Empresa emp = edal.getByIdEmpresa(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
                //Nota Fiscal de Entrada
                if (n.IdDocumento == 3)
                {
                    /* 
                     * Gera Contas a pagar 
                     * Caso a operação seja efetuada com sucesso, guarda o ID do contas a pagar na nota fiscal
                     * Caso aconteça um erro o objeto contas a pagar retorna nulo juntamente com a mensagem de erro
                     */
                    BLNotaFiscal blnota = new BLNotaFiscal();
                    if (blnota.VerificaGeracaoContasPagarCompras(n.IdNotaFiscal))
                    {
                        if (n.IdContasPagar == null)
                        {
                            BLContasPagar blContasPagar = new BLContasPagar();
                            ContasPagar cp = blContasPagar.GeraAPartirDaNotaEntrada(n, out Message);
                            if (cp == null)
                            {
                                Util.Aplicacao.ShowMessage("Não foi possível gerar contas a pagar. \n" + Message);
                                return;
                            }
                            else
                            {
                                n.IdContasPagar = cp.IdContasPagar;
                            }
                        }
                    }


                    /*
                     * Gera a entrada dos produtos no estoque
                     * desde que a operação informada no pedido de compras esteja com flag de estoque
                     */
                   
                    //blInvetario.AtualizaEstoqueFinanceiro(n, iDal.GetByNF(n.IdNotaFiscal));


                    /*
                     *Atualiza os produtos com o valor de compra, desde que o valor da nota seja maior
                     * 
                     * Efetua a entrada no estoque
                     */
                    ProdutoDAL pdal = new ProdutoDAL();
                    var listai = iDal.getItens(n.IdNotaFiscal);
                    var Depositos = new DepositoDAL().Get().ToList();
                    int? iddd = null;
                    foreach (var i in listai)
                    {
                        Produto pr = pdal.ProdutoRepository.GetByID(i.IdProduto);
                        if(pr != null)
                        {
                            //Atualiza o preço de venda do produto
                            if(pr.VendaPrecoUnit < (i.ValorTotal / i.Quantidade))
                            {
                                pr.VendaPrecoUnit = (i.ValorTotal / i.Quantidade);
                                pr.VendaPreco = (i.ValorTotal / i.Quantidade);
                                pdal.ProdutoRepository.Update(pr);
                                pdal.Save();
                            }


                            //Da entrada no estoque
                            BLInventario blInvetario = new BLInventario();
                            blInvetario.EntradaNoEstoqueFisico(pr.IdProduto,
                                                               Depositos.Count > 0 ? Depositos[0].IdDeposito : iddd,
                                                               null,
                                                               null,
                                                               null,
                                                               null,
                                                               null,
                                                               null,
                                                               pr.ComprasIdUnidade,
                                                               n.IdNotaFiscal,
                                                               pr.FiscalIdNCM,
                                                               i.Quantidade * (i.Conversao == null ? 1 : i.Conversao),
                                                               (i.ValorTotal /( i.Quantidade * (i.Conversao == null ? 1 : i.Conversao))),
                                                               DateTime.Now,
                                                               null,
                                                               "NFE " + n.Numero);
                        }
                    }


                    //Se passou pelas duas gerações sem erros seta a not como confirmada para que não seja possível  efetuar alterações.
                    n.NFConfirmada = true;
                    dal.Update(n);
                    dal.Save();
                    CarregaDados();
                    Util.Aplicacao.ShowMessage("Nota fiscal confirmada.");
                }

                //Nota Fiscal de Vendas
                if (n.IdDocumento == 6)
                {

                    if (!string.IsNullOrEmpty(n.Numero))
                    {
                        Util.Aplicacao.ShowMessage("Nota fiscal já foi confirmada!");
                        return;
                    }


                    //Operacao operacaoNF = dal.getNFOperacaoVenda(n.IdNotaFiscal);
                    ////Verifica os vencimentos

                    //if(Convert.ToBoolean(operacaoNF.TransacoesFinanceiras))
                    //{
                    //    if (dgVencimentos.Rows.Count == 0)
                    //    {
                    //        Util.Aplicacao.ShowMessage("Nota Fiscal sem vencimentos.");
                    //        return;
                    //    }
                    //}



                    /*
                     * Gera a saida  dos produtos no estoque 
                     */
                    // BLInventario blInvetario = new BLInventario();
                    // blInvetario.BaixaNotaVendas(n.IdNotaFiscal);
                    //List<NotaFiscalItem> itens = iDal.GetByNF(n.IdNotaFiscal);
                    //foreach (NotaFiscalItem i in itens)
                    //{
                    //    blInvetario.BaixaEstoqueProduto((int)i.IdProduto, i.IdCor, i.IdEstilo, i.IdConfiguracao, i.IdTamanho, (decimal)i.Quantidade, n.IdNotaFiscal);//adicionar as variantes.
                    //}



                    BLNotaFiscal blnota = new BLNotaFiscal();
                    //if (blnota.VerificaGeracaoContasPagarCompras(n.IdNotaFiscal))
                    //{
                    
                    //}






                    //Se passou pelas duas gerações sem erros seta a not como confirmada para que não seja possível  efetuar alterações.
                    n.NFConfirmada = true;
                    //atribui o numero da nota fiscal
                    int? nota = emp.UltimaNotaFiscal == null ? 0 : emp.UltimaNotaFiscal;
                    nota = nota + 1;
                    n.Numero = nota.ToString();
                    n.NotaStatus = 2;
                    emp.UltimaNotaFiscal = nota;
                    edal.ERepository.Update(emp);
                    edal.Save();


                    dal.Update(n);
                    dal.Save();


                    //if (Convert.ToBoolean(operacaoNF.TransacoesFinanceiras))
                    //{
                    //    /* 
                    //    * Gera Contas a receber
                    //    * Caso a operação seja efetuada com sucesso, guarda o ID do contas a receber na nota fiscal
                    //    * Caso aconteça um erro o objeto contas a pagar retorna nulo juntamente com a mensagem de erro
                    //    */
                    //    //if (n.IdContasReceber == null)
                    //    //{
                    //    //    BLContasReceber blContasReceber = new BLContasReceber();
                    //    //    ContasReceber cr = blContasReceber.GeraAPartirDaNotaVenda(n, out Message);
                    //    //    if (cr == null)
                    //    //    {
                    //    //        Util.Aplicacao.ShowMessage("Não foi possível gerar contas a receber. \n" + Message);
                    //    //        return;
                    //    //    }
                    //    //    else
                    //    //    {
                    //    //        n.IdContasReceber = cr.IdContasReceber;
                    //    //    }
                    //    //}

                    //    /* 
                    //     * Gera a comissão a pagar para os vendedores
                    //     */
                    //    //blnota.dal = dal;
                    //    //blnota.GeraComissao(n.IdNotaFiscal);
                    //}
                    

                    CarregaDados();
                    Util.Aplicacao.ShowMessage("Nota fiscal confirmada.");
                }
            }
        }

        private void rbSalvarXML_Click(object sender, EventArgs e)
        {
            List<int> NotasSelecionadas = new List<int>();
            NotasSelecionadas.Add(n.IdNotaFiscal);

            using (frmNFeProcessa frm = new frmNFeProcessa(NotasSelecionadas, "Salvar"))
            {
                frm.nfDal = dal;
                frm.ShowDialog();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtNumero.Text == "")
            {
                if (MessageBox.Show("Deseja recalcular a nota fiscal?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    BLNotaFiscal bl = new BLNotaFiscal();
                    bl.dal = dal;
                    bl.iDal = iDal;
                    bl.CalculaNota(n.IdNotaFiscal);
                    CarregaDados();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (n.IdNotaFiscal == 0)
            {
                Util.Aplicacao.ShowMessage("Salve as informações da nota fiscal antes de adicionar itens");
                return;
            }
            NotaFiscalItem nfi = new NotaFiscalItem();
            nfi.IdNotaFiscal = n.IdNotaFiscal;
            frmNotaFiscalItemCad item = new frmNotaFiscalItemCad(nfi);
            item.ShowDialog();
        }

        private void rbVAlidar_Click(object sender, EventArgs e)
        {
            List<int> NotasSelecionadas = new List<int>();
            NotasSelecionadas.Add(n.IdNotaFiscal);

            using (frmNFeProcessa frm = new frmNFeProcessa(NotasSelecionadas, "Validar"))
            {
                frm.nfDal = dal;
                frm.ShowDialog();
            }
        }

        private void rbTransmitir_Click(object sender, EventArgs e)
        {
            List<int> NotasSelecionadas = new List<int>();
            NotasSelecionadas.Add(n.IdNotaFiscal);

            using (frmNFeProcessa frm = new frmNFeProcessa(NotasSelecionadas, "Transmitir"))
            {
                frm.nfDal = dal;
                frm.ShowDialog();
            }

            n = dal.GetByID(n.IdNotaFiscal);
            CarregaDados();
        }

        private void rbConsulta_Click(object sender, EventArgs e)
        {
            List<int> NotasSelecionadas = new List<int>();
            NotasSelecionadas.Add(n.IdNotaFiscal);

            using (frmNFeProcessa frm = new frmNFeProcessa(NotasSelecionadas, "Consultar"))
            {
                frm.nfDal = dal;
                frm.ShowDialog();
            }
        }

        private void rbDanfe_Click(object sender, EventArgs e)
        {
            List<int> NotasSelecionadas = new List<int>();
            NotasSelecionadas.Add(n.IdNotaFiscal);

            using (frmNFeProcessa frm = new frmNFeProcessa(NotasSelecionadas, "Impressao"))
            {
                frm.nfDal = dal;
                frm.ShowDialog();
            }
        }

        private void rbCancelar_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja cancelar a nota fiscal?") == DialogResult.Yes)
            {
                List<int> NotasSelecionadas = new List<int>();
                NotasSelecionadas.Add(n.IdNotaFiscal);

                using (frmNFeProcessa frm = new frmNFeProcessa(NotasSelecionadas, "Cancelar"))
                {
                    frm.nfDal = dal;
                    frm.ShowDialog();
                }
                n = dal.GetByID(n.IdNotaFiscal);
                CarregaDados();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtObservacao.Text)) return;

            NotaFiscalObs no = new NotaFiscalObs();
            no.Observacao = txtObservacao.Text;
            no.IdNotaFiscal = n.IdNotaFiscal;
            oDal.Insert(no);
            oDal.Save();
            CarregaGrid();
            txtObservacao.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Util.Aplicacao.ShowQuestionMessage("Deseja eliminar a observação?") == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[1].Value);
                oDal.Delete(id);
                oDal.Save();
                CarregaGrid();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BLL.BLNotaFiscal bl = new BLNotaFiscal();
            bl.RecalculaVencimentos(n.IdNotaFiscal, vDal);
            CarregaVencimentos();
        }

        private void rbEtiqueta_Click(object sender, EventArgs e)
        {
            List<Util.Etiqueta> etiquetas = new List<Util.Etiqueta>();
            var lista = iDal.getItens(n.IdNotaFiscal);
            foreach(var i in lista)
            {
                Util.Etiqueta et = new Util.Etiqueta();
                et.CodigoBarras = i.IdProduto.ToString();
                et.Codigo = i.Codigo;
                et.Descricao = i.Descricao;
                et.Qtde = Convert.ToInt32(i.Quantidade);
                etiquetas.Add(et);
            }

            frmImprimir frmi = new frmImprimir(etiquetas);
            frmi.ShowDialog();
        }

        private void rbConferencia_Click(object sender, EventArgs e)
        {
            frmCorrigeProdutos frmcc = new frmCorrigeProdutos(n.IdNotaFiscal); 
            frmcc.ShowDialog();
        }
    }
}

 