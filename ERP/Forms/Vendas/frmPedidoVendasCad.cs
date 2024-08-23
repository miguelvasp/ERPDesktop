using ERP.Auxiliares;
using ERP.BLL;
using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using ERP.Relatorios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPedidoVendasCad : RibbonForm
    {
        PedidoVendaAlocacaoEncargosDAL alocalDal = new PedidoVendaAlocacaoEncargosDAL();
        PedidoVendaDAL dal = new PedidoVendaDAL();
        PedidoVendaCentroCustoDAL pvDal = new PedidoVendaCentroCustoDAL();
        PedidoVenda p = new PedidoVenda();
        PedidoVendaItemApuracaoImpostoDAL impostosDal = new PedidoVendaItemApuracaoImpostoDAL();
        PedidoVendaEncargosDAL encargosDal = new PedidoVendaEncargosDAL();

        Configuracao confEmpresa = new ConfiguracaoDAL().GetByEmpresa(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
        Empresa emp = new EmpresaDAL().getByIdEmpresa(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
        string UFCliente = "";
        string UFEmpresa = "";
        int IdCFOP = 0;
        string CasasDecimais = "F2";
        int IdCodCliente = 0;

        public frmPedidoVendasCad(PedidoVendaDAL pDal, PedidoVenda pPedido)
        {
            dal = pDal;
            p = pPedido;

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmPedidoVendasCad_Load(object sender, EventArgs e)
        {
            CarregaCombos();
            cboTipoAtendimento.SelectedValue = 1;//atendimento presencial

            if (p.IdPedidoVenda == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

                TratarCorCampoDesabilitado();
            }
            else
            {
                CarregaDados();
            }
            cboCliente.Focus();
            CalculaValorTotalPedido();
        }

        private void frmPedidoVendasCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SendKeys.SendWait("{ENTER}");
                SendKeys.Send("{TAB}");
            }

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (p.IdPedidoVenda == 0)
            {
                Util.Aplicacao.ShowMessage("O pedido não se encontra disponível para edição.");
                return;
            }

            if(string.IsNullOrEmpty(cboCFOP.Text))
            {
                Util.Aplicacao.ShowMessage("Informe o CFOP");
                return;
            }

            PedidoVendaItem pi = new PedidoVendaItem();
            pi.IdPedidoVenda = p.IdPedidoVenda;
            frmPedidoVendasAddItem addItem = new frmPedidoVendasAddItem(dal, pi, Convert.ToInt32(cboCFOP.SelectedValue));
            addItem.impostoDal = impostosDal; 
            addItem.ShowDialog();
            CarregaGrid();
            CalculaValorTotalPedido();
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            p = new PedidoVenda();
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            TratarCorCampoDesabilitado();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            IdCodCliente = Convert.ToInt32(cboCliente.SelectedValue);

            if (p.IdPedidoVenda == 0)
            {
                Util.Aplicacao.ShowMessage("O pedido não se encontra disponível para edição.");
                return;
            }

            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            
            TratarCorCampoDesabilitado();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Qualquer alteração efetuada será perdida, deseja continuar?") == DialogResult.Yes)
            {
                CarregaDados();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
        }

        private void btnCancelarSaldo_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja cancelar o saldo deste pedido?") == DialogResult.Yes)
            {
                try
                {
                    p.Status = (int)Util.EnumERP.StatusPedido.SaldoCancelado;
                    dal.PVRepository.Update(p);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    List<PedidoVendaItem> lista = dal.GetItensByPedido(p.IdPedidoVenda);
                    foreach (PedidoVendaItem i in lista)
                    {
                        i.StatusLinha = (int)Util.EnumERP.StatusPedido.Cancelado;
                        dal.PVIRepository.Update(i);
                        dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    }

                    Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (p.IdPedidoVenda > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Deseja cancelar este pedido?") == DialogResult.Yes)
                {
                    try
                    {
                        p.Status = (int)ERP.Util.EnumERP.StatusPedido.Cancelado;
                        dal.PVRepository.Update(p);
                        dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                        Close();
                    }
                    catch (Exception ex)
                    {
                        Util.Aplicacao.ShowErrorMessage(ex);
                    }
                }
            }
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboTipoOrdem.Text != null)
                {
                    if (cboTipoOrdem.SelectedValue.ToString() == "2")
                    {
                        txtMotivoDevolucao.Tag = 1;
                        if (dal.ConsultaPedidoReferencia(Convert.ToInt32(p.IdOrdemReferencia), Convert.ToInt32(p.IdCliente)) == 0)
                        {
                            Util.Aplicacao.ShowMessage("Pedido de referência não encontrado");
                            return;
                        }
                    }
                    else
                    {
                        txtMotivoDevolucao.Tag = "";
                    }
                }

                if (!String.IsNullOrEmpty(cboCondicao.Text))
                {
                    cboPlanoPagamento.Tag = "";
                }
                else
                {
                    cboPlanoPagamento.Tag = "1";
                }


                if (Util.Validacao.ValidaCampos(this))
                {
                    p.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                    p.IdCliente = Convert.ToInt32(cboCliente.SelectedValue);
                    p.IdMoeda = Convert.ToInt32(cboMoeda.SelectedValue);
                    p.PrazoEntrega = Convert.ToInt32(txtPrazo.Text);

                    p.IdPlanoPagamento = null;
                    p.IdCondicaoPagamento = Convert.ToInt32(cboCondicao.SelectedValue);
                    p.DataEntrega = Convert.ToDateTime(txtDataEntrega.Text);
                    p.Observacao = txtObservacao.Text;
                    if (!String.IsNullOrEmpty(cboGrupoCliente.Text)) p.IdGrupoCliente = Convert.ToInt32(cboGrupoCliente.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPerfilClientes.Text)) p.IdPerfilCliente = Convert.ToInt32(cboPerfilClientes.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCFPS.Text)) p.IdCFPS = Convert.ToInt32(cboCFPS.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoEncargos.Text)) p.IdGrupoEncargos = Convert.ToInt32(cboGrupoEncargos.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoDesconto.Text)) p.IdGrupoDesconto = Convert.ToInt32(cboGrupoDesconto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTextoPadrao.Text)) p.IdTextoPadrao = Convert.ToInt32(cboTextoPadrao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoOrdem.Text)) p.TipoOrdem = Convert.ToInt32(cboTipoOrdem.SelectedValue);
                    if (!String.IsNullOrEmpty(cboMetodoPagamento.Text)) p.IdMetodoPagamento = Convert.ToInt32(cboMetodoPagamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPlanoPagamento.Text)) p.IdPlanoPagamento = Convert.ToInt32(cboPlanoPagamento.SelectedValue);

                    if (!String.IsNullOrEmpty(cboGrupoImposto.Text)) p.IdGrupoImposto = Convert.ToInt32(cboGrupoImposto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoImpostoRetido.Text)) p.IdGrupoImpostoRetido = Convert.ToInt32(cboGrupoImpostoRetido.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTeleVendas.Text)) p.IdTeleVendas = Convert.ToInt32(cboTeleVendas.SelectedValue);
                    if (!String.IsNullOrEmpty(cboVendedor.Text)) p.IdVendedor = Convert.ToInt32(cboVendedor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboOperacao.Text)) p.IdOperacao = Convert.ToInt32(cboOperacao.SelectedValue);
                      
                    if (!String.IsNullOrEmpty(cboTransportadora.Text)) p.IdTransportadora = Convert.ToInt32(cboTransportadora.SelectedValue);
                    if (!String.IsNullOrEmpty(cboArmazem.Text)) p.IdArmazem = Convert.ToInt32(cboArmazem.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDeposito.Text)) p.IdDeposito = Convert.ToInt32(cboDeposito.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCFOP.Text)) p.IdCFOP = Convert.ToInt32(cboDeposito.SelectedValue);
                    p.MotivoDevolucao = txtMotivoDevolucao.Text;
                    if (!String.IsNullOrEmpty(cboContratoComercial.Text)) p.IdContratoComercial = Convert.ToInt32(cboContratoComercial.SelectedValue);
                    if (!String.IsNullOrEmpty(txtPedidoReferencia.Text)) p.IdOrdemReferencia = Convert.ToInt32(txtPedidoReferencia.Text);

                    if (!String.IsNullOrEmpty(cboModoEntrega.Text)) p.IdModoEntrega = Convert.ToInt32(cboModoEntrega.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCondicaoEntrega.Text)) p.IdCondicaoEntrega = Convert.ToInt32(cboCondicaoEntrega.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoFrete.Text)) p.TipoFrete = Convert.ToInt32(cboTipoFrete.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoAtendimento.Text)) p.TipoAtendimento = Convert.ToInt32(cboTipoAtendimento.SelectedValue);
                    p.IdCFOP = Convert.ToInt32(cboCFOP.SelectedValue);
                    if (p.IdPedidoVenda == 0)
                    {
                        p.Data = DateTime.Now;
                        p.Status = (int)Util.EnumERP.StatusPedido.Aberto; 
                        p.Emissao = DateTime.Now;
                        dal.PVRepository.Insert(p);
                        dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                        ImportaClienteCentroCusto();
                    }
                    else
                    {
                        if (IdCodCliente == Convert.ToInt32(cboCliente.SelectedValue))
                        {
                            dal.PVRepository.Update(p);
                            dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                        }
                        else
                        {
                            ExcluirClienteCentroCusto();

                            dal.PVRepository.Update(p);
                            dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                            
                            ImportaClienteCentroCusto();                            
                        }
                    }

                    //Gera os Encargos
                    encargosDal.GeraEncargos(p.IdPedidoVenda, p.IdGrupoEncargos);
                    CalculaEncargos();
                    CarregaDados();
                    tabControl1.SelectedTab = tabPage2;
                }
                else
                {
                    Util.Aplicacao.ShowMessage("Por favor verifique as informações faltantes.");
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void ExcluirClienteCentroCusto()
        {
            PedidoVendaCentroCustoDAL pvccDal = new PedidoVendaCentroCustoDAL();
            var lista = pvccDal.GetIdsPedidoVendasCentroCusto(p.IdPedidoVenda);
            if (lista != null && lista.Count > 0)
            {
                foreach (var item in lista)
                {
                    pvccDal.Delete(item);
                    pvccDal.Save();
                }
            }
            
        }

        private void ImportaClienteCentroCusto()
        {
            ClienteCentroCustoDAL cliDal = new ClienteCentroCustoDAL();
            var listacccli = cliDal.GetValoresCadastrados(Convert.ToInt32(cboCliente.SelectedValue));

            if (listacccli != null && listacccli.Count > 0)
            {
                PedidoVendaCentroCusto pvcc = new PedidoVendaCentroCusto();
                PedidoVendaCentroCustoDAL pvccDal = new PedidoVendaCentroCustoDAL();
                foreach (var item in listacccli)
                {
                    pvcc.IdPedidoVenda = p.IdPedidoVenda;
                    pvcc.IdValoresCentroCusto = item.Value;

                    pvccDal.Insert(pvcc);
                    pvccDal.Save();
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmRepPedidoVendasViewer viewer = new frmRepPedidoVendasViewer(p.IdPedidoVenda);
            viewer.ShowDialog();
        }

        private void btnLibera_Click(object sender, EventArgs e)
        {
            //verifica se o PC tem itens
            if (dgv.Rows.Count == 0)
            {
                Util.Aplicacao.ShowMessage("Informe os itens do pedido de vendas.");
                return;
            }

            if (Util.Aplicacao.ShowQuestionMessage("Deseja finalizar e liberar o Pedido de Vendas?") == DialogResult.Yes)
            {
                int idEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));

                //procura o primeiro status de aprovaçao
                AprovacaoNivel an = new AprovacaoDocumentoDAL().GetFirtsByNivel("PV");
                p.StatusAprovacao = an.IdAprovacaoNivel;
                txtStatusAprovacao.Text = an.Nome;

                EmpresaDAL empDal = new EmpresaDAL();
                Empresa empresa = empDal.ERepository.GetByID(idEmpresa);
                int ultimoPedidoVendas = empresa.UltimoPedidoVendas.HasValue ? empresa.UltimoPedidoVendas.Value + 1 : 1;
                empresa.UltimoPedidoVendas = ultimoPedidoVendas;
                empDal.ERepository.Update(empresa);
                empDal.Save();

                p.PedidoNumero = ultimoPedidoVendas;

                //Caso nao exista mais de que o nivel de aprovação Liberado, ele já muda o status para separãção = 2
                if (an.Nome == "Liberado")
                {
                    p.Status = 2;
                }
                dal.PVRepository.Update(p);
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                Usuario usu = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario")));

                //guarda o historico da aprovação
                PedidoVendaAprovacao pa = new PedidoVendaAprovacao();
                pa.IdPedidoVenda = p.IdPedidoVenda;
                pa.Data = DateTime.Now;
                pa.NovoStatus = txtStatusAprovacao.Text;
                pa.Usuario = usu.NomeCompleto;

                PedidoVendaAprovacaoDAL paDal = new PedidoVendaAprovacaoDAL();
                paDal.Insert(pa);
                paDal.Save();

                Util.Aplicacao.ShowMessage("Pedido liberado com sucesso.");

                //CarregaDados();
                tabControl1.SelectedIndex = 0;
                btnAdiciona_Click(new object(), new EventArgs());
            }
        }

        private void cboCliente_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboCliente.Text))
            {
                Cliente c = new ClienteDAL().CRepository.GetByID(Convert.ToInt32(cboCliente.SelectedValue));

                if (c.Tipo == 1)
                {
                    lblCNPJ.Text = "CPF";
                    txtCNPJ.Mask = "999.999.999-99";
                }
                else
                {
                    lblCNPJ.Text = "CNPJ";
                    txtCNPJ.Mask = "99.999.999/9999-99";
                }

                txtCNPJ.Text = c.CNPJ;

                if (c.IdTextoPadrao != null) { cboGrupoCliente.SelectedValue = c.IdTextoPadrao; }
                if (c.IdGrupoCliente != null) { cboGrupoCliente.SelectedValue = c.IdGrupoCliente; }
                if (c.IdGrupoImposto != null) { cboGrupoImposto.SelectedValue = c.IdGrupoImposto; }
                if (c.IdImpostoRetido != null) { cboGrupoImpostoRetido.SelectedValue = c.IdImpostoRetido; }
                if (c.IdCondicaoPagamento != null) { cboCondicao.SelectedValue = c.IdCondicaoPagamento; }
                if (c.IdMetodoPagamento != null) { cboMetodoPagamento.SelectedValue = c.IdMetodoPagamento; }
                if (c.IdPlanoPagamento != null) { cboPlanoPagamento.SelectedValue = c.IdPlanoPagamento; }
                if (c.IdTextoPadrao != null) { cboTextoPadrao.SelectedValue = c.IdTextoPadrao; }
                if (c.IdVendedor != null) { cboVendedor.SelectedValue = c.IdVendedor; }
                if (c.IdModoEntrega != null) { cboModoEntrega.SelectedValue = c.IdModoEntrega; }
                if (c.IdGrupoEncargos != null) { cboGrupoEncargos.SelectedValue = c.IdGrupoEncargos; }

                UFEmpresa = emp.Cidade.UnidadeFederacao.UF;
                var ce = c.ClienteEndereco.ToList();
                UFCliente = ce[0].Endereco.Cidade.UnidadeFederacao.UF;
                //Procura as configurações da empresa
                if (confEmpresa == null) confEmpresa = new Configuracao();
                if (Convert.ToBoolean(confEmpresa.UsarPadraoVendas))
                {
                    if (c.IdModoEntrega == null || c.IdModoEntrega == 0)
                    {
                        cboModoEntrega.SelectedValue = confEmpresa.IdModoEntregaVendas == null ? 0 : confEmpresa.IdModoEntregaVendas;
                    }

                    txtPrazo.Text = confEmpresa.PrazoEntrega == null ? "" : confEmpresa.PrazoEntrega.ToString();
                    cboMoeda.SelectedValue = emp.IdMoeda == null ? 0 : emp.IdMoeda;
                    cboArmazem.SelectedValue = confEmpresa.IdArmazemVendas == null ? 0 : Convert.ToInt32(confEmpresa.IdArmazemVendas);
                    cboDeposito.SelectedValue = confEmpresa.IdDepositoVendas == null ? 0 : Convert.ToInt32(confEmpresa.IdDepositoVendas);
                } 
            }
        }

        private void cboOperacao_Leave(object sender, EventArgs e)
        {
            if (cboOperacao.Text != "")
            {
                var op = new OperacaoDAL().GetByID(Convert.ToInt32(cboOperacao.SelectedValue));
                if (op != null)
                {
                    cboPerfilClientes.SelectedValue = op.IdPerfilCliente == null ? 0 : Convert.ToInt32(op.IdPerfilCliente);
                    p.CriarTransacoesContabeis = Convert.ToBoolean(op.TransacoesContabeis);
                    p.MovimentaEstoque = Convert.ToBoolean(op.MovimentaEstoque);
                    if(UFCliente == UFEmpresa)
                    {
                        IdCFOP = op.IdCFOPInterno == null ? 0 : Convert.ToInt32(op.IdCFOPInterno);
                    }
                    else
                    {
                        IdCFOP = op.IDCFOPExterno == null ? 0 : Convert.ToInt32(op.IDCFOPExterno);
                    }
                    cboCFOP.SelectedValue = IdCFOP;
                }
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (string.IsNullOrEmpty(cboCFOP.Text))
            {
                Util.Aplicacao.ShowMessage("Informe o CFOP");
                return;
            }

            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    PedidoVendaItem pi = dal.PVIRepository.GetByID(id);
                    frmPedidoVendasAddItem cad = new frmPedidoVendasAddItem(dal, pi, Convert.ToInt32(cboCFOP.SelectedValue));
                    cad.impostoDal = impostosDal;
                    cad.ShowDialog();
                    CarregaGrid();
                    CalculaValorTotalPedido();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void txtPrazo_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPrazo.Text))
            {
                if (Util.Validacao.IsNumber(txtPrazo.Text))
                {
                    txtDataEntrega.Value = DateTime.Now.AddDays(Convert.ToInt32(txtPrazo.Text));
                }
            }
        }

        private void CarregaAprovacoes()
        {
            var lista = new PedidoVendaAprovacaoDAL().GetByIdPedido(p.IdPedidoVenda);
            dgAprovacao.AutoGenerateColumns = false;
            dgAprovacao.DataSource = lista;
        }

        protected void CarregaCentrosdeCusto()
        {
            var lista = pvDal.GetByPedidoVenda(p.IdPedidoVenda);

            dgCentros.AutoGenerateColumns = false;
            dgCentros.DataSource = lista;
        }

        private void CarregaCombos()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            #region DadosPedido
            cboCliente.DataSource = new ClienteDAL().GetCombo(sEmpresa);
            cboCliente.DisplayMember = "Text";
            cboCliente.ValueMember = "iValue";
            cboCliente.SelectedIndex = -1;

            List<ComboItem> tpAtend = new List<ComboItem>();
            tpAtend.Add(new ComboItem() { iValue = 0, Text = "Não se aplica (por exemplo, para a Nota Fiscal complementar ou de ajuste)" });
            tpAtend.Add(new ComboItem() { iValue = 1, Text = "Operação presencial" });
            tpAtend.Add(new ComboItem() { iValue = 2, Text = "Operação não presencial, pela Internet" });
            tpAtend.Add(new ComboItem() { iValue = 3, Text = "Operação não presencial, Teleatendimento" });
            tpAtend.Add(new ComboItem() { iValue = 4, Text = "NFC-e em operação com entrega em domicílio" });
            tpAtend.Add(new ComboItem() { iValue = 9, Text = "Operação não presencial, outros" });
            cboTipoAtendimento.DataSource = tpAtend;
            cboTipoAtendimento.DisplayMember = "Text";
            cboTipoAtendimento.ValueMember = "iValue";
            cboTipoAtendimento.SelectedIndex = -1;

            List<ComboItem> TipoOrdem = new List<ComboItem>();
            TipoOrdem.Add(new ComboItem() { iValue = 1, Text = "Ordem de Venda" });
            TipoOrdem.Add(new ComboItem() { iValue = 2, Text = "Devolução" });
            cboTipoOrdem.DataSource = TipoOrdem;
            cboTipoOrdem.DisplayMember = "Text";
            cboTipoOrdem.ValueMember = "iValue";

            cboGrupoCliente.DataSource = new GrupoClienteDAL().GetCombo();
            cboGrupoCliente.DisplayMember = "Text";
            cboGrupoCliente.ValueMember = "iValue";
            cboGrupoCliente.SelectedIndex = -1;

            cboMoeda.DataSource = new MoedaDAL().MRepository.Get();
            cboMoeda.DisplayMember = "Codigo";
            cboMoeda.ValueMember = "IdMoeda";
            cboMoeda.SelectedIndex = -1;

            cboGrupoImposto.DataSource = new GrupoImpostoDAL().getCombo();
            cboGrupoImposto.DisplayMember = "Text";
            cboGrupoImposto.ValueMember = "iValue";
            cboGrupoImposto.SelectedIndex = -1;

            cboGrupoImpostoRetido.DataSource = new GrupoImpostoRetidoDAL().GetCombo();
            cboGrupoImpostoRetido.DisplayMember = "Text";
            cboGrupoImpostoRetido.ValueMember = "iValue";
            cboGrupoImpostoRetido.SelectedIndex = -1;

            cboTeleVendas.DataSource = new FuncionarioDAL().GetComboTelevendas();
            cboTeleVendas.DisplayMember = "Text";
            cboTeleVendas.ValueMember = "iValue";
            cboTeleVendas.SelectedIndex = -1;

            cboVendedor.DataSource = new VendedorDAL().GetCombo();
            cboVendedor.DisplayMember = "Text";
            cboVendedor.ValueMember = "iValue";
            cboVendedor.SelectedIndex = -1;

            cboOperacao.DataSource = new OperacaoDAL().GetCombo();
            cboOperacao.DisplayMember = "Text";
            cboOperacao.ValueMember = "iValue";
            cboOperacao.SelectedIndex = -1;

            cboPerfilClientes.DataSource = new PerfilClienteDAL().GetCombo();
            cboPerfilClientes.DisplayMember = "Text";
            cboPerfilClientes.ValueMember = "iValue";
            cboPerfilClientes.SelectedIndex = -1;

            cboCFPS.DataSource = new CFPSDAL().GetCombo();
            cboCFPS.DisplayMember = "Text";
            cboCFPS.ValueMember = "iValue";
            cboCFPS.SelectedIndex = -1;
            #endregion

            #region Entrega
            cboTransportadora.DataSource = new TransportadoraDAL().GetCombo();
            cboTransportadora.DisplayMember = "Text";
            cboTransportadora.ValueMember = "iValue";
            cboTransportadora.SelectedIndex = -1;

            cboCFOP.DataSource = new CFOPDAL().GetCombo();
            cboCFOP.DisplayMember = "Text";
            cboCFOP.ValueMember = "iValue";
            cboCFOP.SelectedIndex = -1;

            List<ComboItem> TipoFrete = new List<ComboItem>();
            TipoFrete.Add(new ComboItem() { iValue = 1, Text = "CIF" });
            TipoFrete.Add(new ComboItem() { iValue = 2, Text = "FOB" });
            cboTipoFrete.DataSource = TipoFrete;
            cboTipoFrete.DisplayMember = "Text";
            cboTipoFrete.ValueMember = "iValue";
            cboTipoFrete.SelectedIndex = -1;

            cboArmazem.DataSource = new ArmazemDAL().GetCombo();
            cboArmazem.DisplayMember = "Text";
            cboArmazem.ValueMember = "iValue";
            cboArmazem.SelectedIndex = -1;

            cboDeposito.DataSource = new DepositoDAL().GetCombo();
            cboDeposito.DisplayMember = "Text";
            cboDeposito.ValueMember = "iValue";
            cboDeposito.SelectedIndex = -1;

            cboModoEntrega.DataSource = new ModoEntregaDAL().GetCombo();
            cboModoEntrega.DisplayMember = "Text";
            cboModoEntrega.ValueMember = "iValue";
            cboModoEntrega.SelectedIndex = -1;

            cboCondicaoEntrega.DataSource = new ModoEntregaDAL().GetCombo();
            cboCondicaoEntrega.DisplayMember = "Text";
            cboCondicaoEntrega.ValueMember = "iValue";
            cboCondicaoEntrega.SelectedIndex = -1;

            cboTextoPadrao.DataSource = new TextoPadraoDAL().GetCombo();
            cboTextoPadrao.DisplayMember = "Text";
            cboTextoPadrao.ValueMember = "iValue";
            cboTextoPadrao.SelectedIndex = -1;
            #endregion

            #region Financeiro
            cboCondicao.DataSource = new CondicaoPagamentoDAL().GetComboVendas();
            cboCondicao.DisplayMember = "Text";
            cboCondicao.ValueMember = "iValue";
            cboCondicao.SelectedIndex = -1;

            cboMetodoPagamento.DataSource = new MetodoPagamentoDAL().GetCombo();
            cboMetodoPagamento.DisplayMember = "Text";
            cboMetodoPagamento.ValueMember = "iValue";
            cboMetodoPagamento.SelectedIndex = -1;

            cboPlanoPagamento.DataSource = new PlanoPagamentoDAL().GetCombo();
            cboPlanoPagamento.DisplayMember = "Text";
            cboPlanoPagamento.ValueMember = "iValue";
            cboPlanoPagamento.SelectedIndex = -1;

            cboContratoComercial.DataSource = new ContratoComercialDAL().GetCombo("vendas", sEmpresa);
            cboContratoComercial.DisplayMember = "Text";
            cboContratoComercial.ValueMember = "iValue";
            cboContratoComercial.SelectedIndex = -1;

            cboGrupoEncargos.DataSource = new GrupoEncargosDAL().getCombo();
            cboGrupoEncargos.DisplayMember = "Text";
            cboGrupoEncargos.ValueMember = "iValue";
            cboGrupoEncargos.SelectedIndex = -1;

            cboGrupoDesconto.DataSource = new GrupoDescontosDAL().GetCombo();
            cboGrupoDesconto.DisplayMember = "Text";
            cboGrupoDesconto.ValueMember = "iValue";
            cboGrupoDesconto.SelectedIndex = -1;
            #endregion

        }

        private void CarregaDados()
        {
            try
            {
                //verifica se o pedido já foi liberado
                if (p.PedidoNumero != null && p.PedidoNumero > 0)
                {
                    btnLibera.Enabled = false;
                }
                else
                {
                    btnLibera.Enabled = true;
                }

                if (p.StatusAprovacao != null)
                {
                    AprovacaoNivelDAL anDal = new AprovacaoNivelDAL();
                    AprovacaoNivel an = anDal.GetByID(Convert.ToInt32(p.StatusAprovacao));
                    if (an != null)
                        txtStatusAprovacao.Text = an.Nome;
                }

                txtNumeroPedido.Text = p.PedidoNumero == null ? "" : p.PedidoNumero.ToString();
                txtIdPedido.Text = p.IdPedidoVenda.ToString();

                if (p.Data == DateTime.MinValue)
                {
                    txtData.Text = DateTime.Now.ToShortDateString();
                }
                else
                {
                    txtData.Text = p.Data.ToShortDateString();
                }
                cboTipoAtendimento.SelectedValue = p.TipoAtendimento == null ? 0 : p.TipoAtendimento;
                cboCliente.SelectedValue = p.IdCliente == null ? 0 : p.IdCliente;
                Cliente c = new ClienteDAL().CRepository.GetByID(Convert.ToInt32(cboCliente.SelectedValue));

                if (c != null)
                {
                    if (c.Tipo == 1)
                    {
                        lblCNPJ.Text = "CPF";
                        txtCNPJ.Mask = "999.999.999-99";
                    }
                    else
                    {
                        lblCNPJ.Text = "CNPJ";
                        txtCNPJ.Mask = "99.999.999/9999-99";
                    }

                    txtCNPJ.Text = c.CNPJ;
                }

                cboMoeda.SelectedValue = p.IdMoeda == null ? 0 : p.IdMoeda;
                txtPrazo.Text = p.PrazoEntrega.ToString();
                if (p.Emissao == DateTime.MinValue)
                {
                    txtEmissao.Text = DateTime.Now.ToShortDateString();
                }
                else
                {
                    txtEmissao.Text = p.Emissao.ToShortDateString();
                }
                cboCondicao.SelectedValue = p.IdCondicaoPagamento == null ? 0 : p.IdCondicaoPagamento;

                if (p.Emissao == DateTime.MinValue)
                {
                    txtDataEntrega.Text = DateTime.Now.ToShortDateString();
                }
                else
                {
                    txtDataEntrega.Text = p.DataEntrega.ToShortDateString();
                }

                txtObservacao.Text = p.Observacao;
                cboGrupoCliente.SelectedValue = p.IdGrupoCliente == null ? 0 : p.IdGrupoCliente;
                cboPerfilClientes.SelectedValue = p.IdPerfilCliente == null ? 0 : p.IdPerfilCliente;
                cboCFPS.SelectedValue = p.IdCFPS == null ? 0 : p.IdCFPS;
                cboGrupoEncargos.SelectedValue = p.IdGrupoEncargos == null ? 0 : p.IdGrupoEncargos;
                cboGrupoDesconto.SelectedValue = p.IdGrupoDesconto == null ? 0 : p.IdGrupoDesconto;
                cboTextoPadrao.SelectedValue = p.IdTextoPadrao == null ? 0 : p.IdTextoPadrao;
                cboTipoOrdem.SelectedValue = p.TipoOrdem == null ? 0 : p.TipoOrdem;
                cboMetodoPagamento.SelectedValue = p.IdMetodoPagamento == null ? 0 : p.IdMetodoPagamento;
                cboPlanoPagamento.SelectedValue = p.IdPlanoPagamento == null ? 0 : p.IdPlanoPagamento;

                cboGrupoImposto.SelectedValue = p.IdGrupoImposto == null ? 0 : p.IdGrupoImposto;
                cboGrupoImpostoRetido.SelectedValue = p.IdGrupoImpostoRetido == null ? 0 : p.IdGrupoImpostoRetido;
                cboTeleVendas.SelectedValue = p.IdTeleVendas == null ? 0 : p.IdTeleVendas;
                cboVendedor.SelectedValue = p.IdVendedor == null ? 0 : p.IdVendedor;
                cboOperacao.SelectedValue = p.IdOperacao == null ? 0 : p.IdOperacao;
                cboTransportadora.SelectedValue = p.IdTransportadora == null ? 0 : p.IdTransportadora;
                cboArmazem.SelectedValue = p.IdArmazem == null ? 0 : p.IdArmazem;
                cboDeposito.SelectedValue = p.IdDeposito == null ? 0 : p.IdDeposito;
                txtMotivoDevolucao.Text = p.MotivoDevolucao;
                cboContratoComercial.SelectedValue = p.IdContratoComercial == null ? 0 : p.IdContratoComercial;
                txtPedidoReferencia.Text = p.IdOrdemReferencia.ToString();

                cboModoEntrega.SelectedValue = p.IdModoEntrega == null ? 0 : p.IdModoEntrega;
                cboCondicaoEntrega.SelectedValue = p.IdCondicaoEntrega == null ? 0 : p.IdCondicaoEntrega;
                cboTipoFrete.SelectedValue = p.TipoFrete == null ? 0 : p.TipoFrete;
                cboCFOP.SelectedValue = p.IdCFOP == null ? 0 : p.IdCFOP;
                switch (p.Status)
                {
                    case 1: txtStatus.Text = "Em Aberto"; break;
                    case 2: txtStatus.Text = "Separação"; break;
                    case 3: txtStatus.Text = "A Faturar"; break;
                    case 4: txtStatus.Text = "Faturado"; break;
                    case 5: txtStatus.Text = "Faturado Parcialmente"; break;
                    case 6: txtStatus.Text = "Cancelado"; break;
                    case 7: txtStatus.Text = "Saldo Cancelado"; break;
                }

                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

                if (p.IdPedidoVenda != 0)
                {
                    btnAdd.Enabled = true;
                    dgv.Enabled = true;
                }
                else
                {
                    txtEmissao.Text = DateTime.Now.ToShortDateString();
                    btnAdd.Enabled = false;
                    dgv.Enabled = false;
                }

                //se o pedido foi finalizado nao deixa alterar
                if (p.Status == 3 || p.Status == 4 || p.Status == 5)
                {
                    btnAlterar.Enabled = false;
                    btnAdd.Enabled = false;
                    dgv.Enabled = false;
                }

                CarregaGrid();
                CarregaAprovacoes();
                CarregaCentrosdeCusto();
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void CarregaGrid()
        {
            var lista = dal.GetItens(p.IdPedidoVenda).ToList();

            dgv.AutoGenerateColumns = false;
            dgv.DataSource = lista;
            if (lista.Count > 0)
            {
                btnVerImpostos.Visible = true;
                btnVerImpostos.Enabled = true;
                btnContabilidade.Visible = true;
                btnContabilidade.Enabled = true;
            }
        }

        private void tsbAddCentroCusto_Click(object sender, EventArgs e)
        {
            if (p.IdPedidoVenda == 0)
            {
                Util.Aplicacao.ShowMessage("Salve os dados do pedido de venda antes de adicionar centros de custo.");
                return;
            }

            frmCentroCustoAux frmCC = new frmCentroCustoAux("PV", p.IdPedidoVenda);
            frmCC.pvdal = pvDal;
            frmCC.ShowDialog();
            CarregaCentrosdeCusto();
        }

        private void tsbExcluirCentroCusto_Click(object sender, EventArgs e)
        {
            if (dgCentros.Rows.Count > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir o centro de custo selecionado?") == DialogResult.Yes)
                {
                    
                    int id = Convert.ToInt32(dgCentros.Rows[dgCentros.SelectedRows[0].Index].Cells[0].Value);
                    try
                    {
                        pvDal.Delete(id);
                        pvDal.Save();
                        CarregaCentrosdeCusto();
                    }
                    catch (Exception ex)
                    {
                        Util.Aplicacao.ShowErrorMessage(ex);
                    }
                }
            }
        }

        private void TratarCorCampoDesabilitado()
        {
            txtNumeroPedido.BackColor = SystemColors.Control;
            txtIdPedido.BackColor = SystemColors.Control;
            txtData.BackColor = SystemColors.Control;
            txtStatus.BackColor = SystemColors.Control;
            txtStatusAprovacao.BackColor = SystemColors.Control;
            txtEmissao.BackColor = SystemColors.Control;
        }

        private void btnVerImpostos_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value);
                frmListaImpostosVendas frmimpostos = new frmListaImpostosVendas(id);
                frmimpostos.dal = impostosDal;
                frmimpostos.ShowDialog();
            }
        }

        private void rbEncargos_Click(object sender, EventArgs e)
        {
            if (p.IdPedidoVenda == 0)
            {
                Util.Aplicacao.ShowMessage("Por favor salve os dados do pedido antes de visualizar os encargos");
                return;
            }

            frmPedidoVendaAlocaEncargos frmAloc = new frmPedidoVendaAlocaEncargos(p.IdPedidoVenda);
            frmAloc.encargoDal = encargosDal;
            frmAloc.alocalDal = alocalDal;
            frmAloc.ShowDialog();
            CalculaEncargos();
        }
        
        private void CalculaEncargos()
        {
            BLImpostoEncargosVendas blImpostos = new BLImpostoEncargosVendas();
            blImpostos.dal = new PedidoVendaItemApuracaoImpostoDAL();
            blImpostos.pedidoDal = dal;
            blImpostos.GeraEncargos(p.IdPedidoVenda);
        }

        private void btnTotais_Click(object sender, EventArgs e)
        {
            if (p.IdPedidoVenda != 0)
            {
                PedidosTotaisModelView totais = dal.getTotaisPedido(p.IdPedidoVenda);
                using (frmPedidoTotais frm = new frmPedidoTotais(totais))
                {
                    frm.ShowDialog();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value);
                frmListaContabilidadeVendas frmcontabilidade = new frmListaContabilidadeVendas(id);
                frmcontabilidade.ShowDialog();
            }
        }

        private void cboTeleVendas_Leave(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(cboTeleVendas.Text))
            {
                cboTipoAtendimento.SelectedValue = 3;
            }
        }

        private void CalculaValorTotalPedido()
        {
            PedidosTotaisModelView totais = dal.getTotaisPedido(p.IdPedidoVenda);
            lbValorTotal.Text = "Valor total das mercadorias: R$ " + totais.TotalProdutos.ToString("N2");
        }
    }
}
