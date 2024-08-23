using ERP.DAL;
using ERP.Forms.VendasBalcao;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPedidoVendasBalcao : Form
    {
        public PedidoBalcaoDAL dal = new PedidoBalcaoDAL();
        PedidoBalcaoPagamentoDAL fdal = new PedidoBalcaoPagamentoDAL();
        PedidoBalcaoProdutoDAL prdal = new PedidoBalcaoProdutoDAL();
        PedidoBalcaoCrediarioDAL pcdal = new PedidoBalcaoCrediarioDAL();
        PedidoBalcao p = null; 
        List<PedidoBalcaoPagamento> listap = new List<PedidoBalcaoPagamento>();
        //List<produtoGrid> lista = new List<produtoGrid>();
        vwEstoqueSintetico produto = new vwEstoqueSintetico();
        //PedidoBalcaoProduto produtoTemp = null;
        decimal LimiteCredito = 0;
        int IdPedidoBalcaox = 0;
        bool AlterouProduto = false;
        bool AlterouPagamento = false;
        decimal Desconto = 0;
        decimal DescontoMaximo = 0;
        decimal totalProdutos = 0;
        decimal vdesc = 0;

        public frmPedidoVendasBalcao(int pId = 6)
        {
            IdPedidoBalcaox = pId;
            InitializeComponent(); 
        }

        private void frmPedidoVendas_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnAddCliente, "Cadastrar novo Cliente");
            ToolTip1.SetToolTip(this.button1, "Pesquisar Clientes");
            ToolTip1.SetToolTip(this.btnAddPagamento, "Adicionar Pagamento");
            CarregaDados(); 
        }

        private void CarregaDados()
        {
            

            if (IdPedidoBalcaox > 0)
            {
                p = dal.GetByID(IdPedidoBalcaox);
                Desconto = Convert.ToDecimal(p.PercentualDesconto);
                txtCliente.Text = p.NomeBalcao;
                txtCliente.Tag = p.IdCliente;
                lbpDesconto.Text = "";
                txtDescontoTotal.Text = p.DescontoTotal.ToString();
                txtObs.Text = p.Observacao;
                var prods = prdal.getByPedidoId(p.IdPedidoBalcao);
                //carrega os produtos na lista temp
                
                 

                //se o pedido foi liberado nao pode mais ser alterado
                if (p.Status == "Orçamento")
                {
                    btnConfirma.Enabled = true;
                    btnAdd.Enabled = false;
                    btnDel.Enabled = false;
                    //dgvFormasPagamento.Enabled = false;
                    btnRelatorio.Enabled = true;
                    btnConfirmaPgto.Enabled = true;
                }

                if (p.Status != "Orçamento")
                {
                    btnConfirma.Enabled = false;
                    btnConfirmaPgto.Enabled = false;
                    btnAdd.Enabled = false;
                    btnDel.Enabled = false;
                    dgvFormasPagamento.Enabled = false;
                    btnRelatorio.Enabled = true; 
                    toolStripButton1.Enabled = true;
                    int diasDaCompra = DateTime.Compare(Convert.ToDateTime(p.Data), DateTime.Now);
                    if (diasDaCompra <= 7)
                    {
                        btnDevolucao.Enabled = true;
                        dgvProdutos.Columns[8].Visible = true;
                    }

                    
                }

                if(p.IdNotaFiscal != null && p.IdNotaFiscal > 0)
                {
                    toolStripButton1.Enabled = false;
                    button1.Enabled = false;
                }
            }
            else
            {
                NovoPedido();
            }
            
            LimpaProduto();
            CalculaValores();
            CarregaGrid();
        }

        private void LimpaProduto()
        {
            txtCodigo.Text = "";
            txtCodigo.Tag = "";
            txtDescricao.Text = "";
            txtQtde.Text = "";
            txtVlUnit.Text = "";
            txtEstoque.Text = "";
            txtDados.Text = "";
           
            lbIdProduto.Text = "0";
        }

      

         

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if(string.IsNullOrEmpty(txtCodigo.Text))
                {
                    return;
                }
                BuscaProduto();
            }
        }

       

        private void BuscaProduto()
        {
            frmPesquisaProdutoBalcao frm = new frmPesquisaProdutoBalcao(txtCodigo.Text);
            if(frm.selecionado != null)
            {
                produto = frm.selecionado;
            }
            else
            {
                frm.ShowDialog();
                produto = frm.selecionado;
            }

            if(produto != null)
            {
                txtCodigo.Text = produto.Codigo;
                txtCodigo.Tag = produto.IdProduto;
                txtDescricao.Text = produto.NomeProduto;
                txtVlUnit.Text = Convert.ToDecimal(produto.VendaPrecoUnit).ToString("N2");
                txtQtde.Text = "1";
                txtEstoque.Text = produto.Quantidade.ToString();
                txtDados.Text = produto.Descricao;
                
                btnAdd.Enabled = true;
            }
            
        }
         
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodigo.Tag.ToString()))
                { 
                    if(lbIdPedidoBalcaoProduto.Text == "0")
                    {
                        PedidoBalcaoProduto pedpi = new PedidoBalcaoProduto();
                        pedpi.IdPedidoBalcao = p.IdPedidoBalcao;
                        pedpi.IdProduto = Convert.ToInt32(txtCodigo.Tag);
                        pedpi.Qtde = Convert.ToDecimal(txtQtde.Text);
                        pedpi.ValorUnitario = Convert.ToDecimal(txtVlUnit.Text);
                        pedpi.Desconto = 0;
                             
                        pedpi.ValorTotal = (pedpi.Qtde * pedpi.ValorUnitario) - pedpi.Desconto;
                        prdal.Insert(pedpi);
                        prdal.Save();
                        lbIdPedidoBalcaoProduto.Text = "0";
                    }
                    else
                    {
                        int pbpId = Convert.ToInt32(dgvProdutos.Rows[dgvProdutos.SelectedRows[0].Index].Cells[0].Value);
                        PedidoBalcaoProduto pedp = prdal.GetByID(pbpId);
                        pedp.Qtde = Convert.ToDecimal(txtQtde.Text);
                        pedp.ValorUnitario = Convert.ToDecimal(txtVlUnit.Text);
                        pedp.Desconto = 0;
                             
                        pedp.ValorTotal = (pedp.Qtde * pedp.ValorUnitario) - pedp.Desconto;
                        prdal.Update(pedp);
                        prdal.Save();
                        lbIdPedidoBalcaoProduto.Text = "0";
                    } 
                }
                LimpaProduto();
                
                txtCodigo.Focus();
                CalculaValores();
                CarregaGrid();
                txtCodigo.Tag = "";
                btnAdd.Enabled = false;
                btnDel.Enabled = false;
                AlterouProduto = true;
            }
            catch(Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            } 
        }

        private void CarregaGrid()
        {
            var cliente = new ClienteDAL().CRepository.GetByID(Convert.ToInt32(txtCliente.Tag));
            var grupo = new GrupoClienteDAL().GetByID(Convert.ToInt32(cliente.IdGrupoCliente));
            decimal pDesconto = 0;
            if(grupo != null)
            {
                pDesconto =  grupo.PercentualDesconto;
            }
            
            


            var listaprod = new PedidoBalcaoProdutoDAL().getByPedidoId(p.IdPedidoBalcao);
            var produtosl = listaprod.Select(x =>
                   new
                   {
                       IdPedidoBalcaoProduto = x.IdPedidoBalcaoProduto,
                       Codigo = x.Produto == null ? "" : x.Produto.Codigo,
                       NomeProduto = x.Produto == null ? "" : x.Produto.NomeProduto,
                       Qtde = x.Qtde,
                       ValorUnitario = x.ValorUnitario,
                       Desconto = x.Desconto,
                       ValorTotal = x.ValorTotal
                   }
                ).ToList();
            dgvProdutos.AutoGenerateColumns = false;
            dgvProdutos.DataSource = produtosl;

            totalProdutos = Convert.ToDecimal(produtosl.Sum(x => x.Qtde * x.ValorUnitario));

            DescontoMaximo = (pDesconto * totalProdutos) / 100.00M;
            lbpDesconto.Text = "Desconto Máximo: " + DescontoMaximo.ToString("f2");


            vdesc = Convert.ToDecimal(produtosl.Sum(x => x.Desconto));

            lbTotal.Text = (totalProdutos - vdesc).ToString("f2");


            listap = new PedidoBalcaoPagamentoDAL().getByPedidoId(p.IdPedidoBalcao);
            dgvFormasPagamento.AutoGenerateColumns = false;
            dgvFormasPagamento.DataSource = listap;


            //Carrega o Crediario
            var listacred = new PedidoBalcaoCrediarioDAL().getByIdPedidoBalcao(p.IdPedidoBalcao);
            if(listacred.Count > 0)
            {
                toolStripButton2.Enabled = true;
            }
            else
            {
                toolStripButton2.Enabled = false;
            }

            dgvCrediario.AutoGenerateColumns = false;
            dgvCrediario.DataSource = listacred;

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            NovoPedido();
        }

        private void NovoPedido()
        { 
            btnRelatorio.Enabled = false;
            btnConfirma.Enabled = true;
            btnConfirmaPgto.Enabled = false;
            dgvFormasPagamento.Enabled = true;
            btnAdd.Enabled = true;
            txtCliente.Text = "CONSUMIDOR FINAL";
            txtCliente.Tag = "3";
            p = new PedidoBalcao();
            p.IdUsuario = Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"));
            p.Data = DateTime.Now;
            p.NomeBalcao = txtCliente.Text;
            p.IdCliente = Convert.ToInt32(txtCliente.Tag);
            p.PercentualDesconto = 0;
            p.DescontoTotal = 0;
            p.IdCondicaoPagamento = 1;
            p.Status = "Orçamento";
            dal.Insert(p);
            dal.Save();

            LimpaProduto();
            btnAdd.Enabled = false;
            btnDel.Enabled = false;
            txtCodigo.Focus();
        }

        private void CalculaValores()
        {
            if(string.IsNullOrEmpty(txtDescontoTotal.Text))
            {
                txtDescontoTotal.Text = "0";
            }

            if(Util.Util.IsNumber(txtDescontoTotal.Text))
            {
                prdal.RateiaDesconto(p.IdPedidoBalcao, Convert.ToDecimal(txtDescontoTotal.Text));
                CarregaGrid();
            } 
            //Calcula o troco 
            decimal dinheiro = Convert.ToDecimal(listap.Where(x => x.FormaPagamento == "DINHEIRO").Sum(x => x.Valor));
            decimal CARTAO = Convert.ToDecimal(listap.Where(x => x.FormaPagamento != "DINHEIRO").Sum(x => x.Valor));
            decimal valorapagar = (Convert.ToDecimal(lbTotal.Text) - (dinheiro + CARTAO));
            if(valorapagar < 0)
            {
                valorapagar = 0;
            }
            lbTotalPago.Text = valorapagar.ToString("f2"); 
            lbTroco.Text = "0,00";
            if(dinheiro > Convert.ToDecimal(lbTotal.Text))
            {
                lbTroco.Text = (dinheiro - Convert.ToDecimal(lbTotal.Text)).ToString("f2");
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            try
            {
                prdal.Delete(Convert.ToInt32(lbIdPedidoBalcaoProduto.Text));
                prdal.Save();
            }
            catch (Exception)
            {
                 
            }
            

            LimpaProduto();
            CalculaValores();
            CarregaGrid();
            txtCodigo.Focus();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //if(!string.IsNullOrEmpty(cboFormasPagamento.Text) && !string.IsNullOrEmpty(txtvlPago.Text))
            //{
            //    PedidoBalcaoPagamento pg = new PedidoBalcaoPagamento();
            //    pg.FormaPagamento = cboFormasPagamento.Text;
            //    pg.Valor = Convert.ToDecimal(txtvlPago.Text);
            //    listap.Add(pg);
            //}
            //CalculaValores();
        }

        private void dgvFormasPagamento_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //CalculaValores();
        }

        private void dgvFormasPagamento_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //CalculaValores();
            //AlterouPagamento = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBuscaCliente frmc = new frmBuscaCliente();
            frmc.ShowDialog(); 
            if(string.IsNullOrEmpty(frmc.Nome))
            {
                txtCliente.Text = "CONSUMIDOR FINAL";
                txtCliente.Tag = "3";
                LimiteCredito = 0;
                
            }
            else
            {
                txtCliente.Text = frmc.Nome;
                txtCliente.Tag = frmc.IdCliente;
                if(p == null)
                {
                    p = new PedidoBalcao();
                }
                if(p.IdPedidoBalcao > 0)
                {
                    p.IdCliente = Convert.ToInt32(frmc.IdCliente);
                    p.NomeBalcao = txtCliente.Text;
                    dal.Update(p);
                    dal.Save();

                }

                //Verifica se o Cliente possui Limite de Credito
                var Cliente = new ClienteDAL().CRepository.GetByID(Convert.ToInt32(txtCliente.Tag));
                LimiteCredito = 0;
                LimiteCredito = Cliente.LimiteCredito;
                
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            LimpaProduto();
            txtCodigo.Focus();
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            if(p == null)
            {
                p = new PedidoBalcao();
            }

            if (p.Status != "Orçamento")
            {
                Util.Aplicacao.ShowMessage("Pedido já foi confirmado, não pode ser alterado!");
                return;
            }

             


            if(Util.Aplicacao.ShowQuestionMessage("Deseja salvar os dados do pedido de vendas?") == DialogResult.Yes)
            {

                SalvaDados();
                // CarregaDados(); 
                btnConfirmaPgto.Enabled = true;
                btnRelatorio.Enabled = true;
            }
            CarregaGrid();
        }

        private void SalvaDados()
        {

            if (p.IdPedidoBalcao == 0)
            {
                p = new PedidoBalcao();
                p.IdUsuario = Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"));
                p.Data = DateTime.Now;
            }
            else
            {
                p = dal.GetByID(p.IdPedidoBalcao);
            }

            p.NomeBalcao = txtCliente.Text;
            p.IdCliente = Convert.ToInt32(txtCliente.Tag);
            p.PercentualDesconto = Desconto;
            p.DescontoTotal = Convert.ToDecimal(txtDescontoTotal.Text);
            p.Observacao = txtObs.Text;
            if(string.IsNullOrEmpty(p.Status))
            {
                p.Status = "Liberado";
            }
            
            //p.IdCondicaoPagamento = Convert.ToInt32(cboCondicao.SelectedValue);
            if (p.IdPedidoBalcao == 0)
            {
                dal.Insert(p);
            }
            else
            {
                dal.Update(p);
            }

            dal.Save(); 
             


            p.Dinheiro = listap.Where(x => x.FormaPagamento == "DINHEIRO").Sum(x => x.Valor);
            p.Credito = listap.Where(x => x.FormaPagamento.Contains("CARTÃO CRÉDITO")).Sum(x => x.Valor);
            p.Debito = listap.Where(x => x.FormaPagamento == "CARTÃO DÉBITO").Sum(x => x.Valor);
            p.Crediario = listap.Where(x => x.FormaPagamento.Contains("CREDIARIO LOJA")).Sum(x => x.Valor);
            p.Total = Convert.ToDecimal(lbTotal.Text);
            p.Troco = Convert.ToDecimal(lbTroco.Text);
            dal.Update(p);
            dal.Save();
            //btnConfirma.Enabled = false;
            btnAdd.Enabled = false;
            btnDel.Enabled = false;
            //dgvFormasPagamento.Enabled = false;
        }

        private void dgvProdutos_DoubleClick(object sender, EventArgs e)
        {
            if (p.Status == "Pago")
            {
                Util.Aplicacao.ShowMessage("Pedido já foi pago, não pode ser alterado!");
                return;
            }


            if (dgvProdutos.Rows.Count > 0)
            {
                lbIdPedidoBalcaoProduto.Text = dgvProdutos.Rows[dgvProdutos.SelectedRows[0].Index].Cells[0].Value.ToString();
                var pg = new PedidoBalcaoProdutoDAL().GetByID(Convert.ToInt32(lbIdPedidoBalcaoProduto.Text)); 
                txtCodigo.Tag = pg.IdProduto.ToString();
                txtCodigo.Text = pg.Produto.Codigo;
                txtDescricao.Text = pg.Produto.NomeProduto;
                txtQtde.Text = pg.Qtde.ToString();
                txtVlUnit.Text = pg.ValorUnitario.ToString();
                btnAdd.Enabled = true;
                btnDel.Enabled = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (p.Status != "Orçamento")
            {
                Util.Aplicacao.ShowMessage("Pedido já foi confirmado, não pode ser alterado!");
                return;
            }

            if (Convert.ToDecimal(lbTotalPago.Text) > 0)
            {
                Util.Aplicacao.ShowMessage("Verifique os valores e a forma de pagamento!");
                return;
            }

            string tipoPagamento = "Pago";


            //Verifica as formas de pagamento
            int Qtde = 0;
            foreach(DataGridViewRow dr in dgvFormasPagamento.Rows)
            {
                if(dr.Cells[1].Value != null)
                {
                    if (dr.Cells[1].Value.ToString() == "CREDIARIO LOJA 30 DIAS")
                    {
                        if (Qtde < 1) Qtde = 1;
                    }

                    if (dr.Cells[1].Value.ToString() == "CREDIARIO LOJA 30/60 DIAS")
                    {
                        if (Qtde < 2) Qtde = 2;
                    }

                    if (dr.Cells[1].Value.ToString() == "CREDIARIO LOJA 30/60/90 DIAS")
                    {
                        Qtde = 3;
                    }
                } 
            }

            int qtdeCredito = 0;
            foreach (DataGridViewRow dr in dgvFormasPagamento.Rows)
            {
                if (dr.Cells[1].Value != null)
                {
                    if (dr.Cells[1].Value.ToString() == "CARTÃO CRÉDITO")
                    {
                        if (qtdeCredito < 1) qtdeCredito = 1;
                    }

                    if (dr.Cells[1].Value.ToString() == "CARTÃO CRÉDITO 2x")
                    {
                        if (qtdeCredito < 2) qtdeCredito = 2;
                    }

                    if (dr.Cells[1].Value.ToString() == "CARTÃO CRÉDITO 3x")
                    {
                        if (qtdeCredito < 3) qtdeCredito = 3;
                    }

                    if (dr.Cells[1].Value.ToString() == "CARTÃO CRÉDITO 4x")
                    {
                        if (qtdeCredito < 4) qtdeCredito = 4;
                    }
                }
            }

            if (Qtde > 0)
            {
                tipoPagamento = "Crediario";
                if(p.IdCliente == 3)
                {
                    Util.Aplicacao.ShowMessage("Não é possível efetuar crediario da loja para consumidor final, selecione um cliente cadastrado");
                    return;
                }
                //verifica os dados do Cliente
                Cliente cl = new ClienteDAL().CRepository.GetByID(p.IdCliente);
                if(string.IsNullOrEmpty(cl.RazaoSocial) || string.IsNullOrEmpty(cl.CNPJ) || string.IsNullOrEmpty(cl.Logradouro) || string.IsNullOrEmpty(cl.Nro) || string.IsNullOrEmpty(cl.Bairro) || string.IsNullOrEmpty(cl.IdCidade.ToString()))
                {
                    Util.Aplicacao.ShowMessage("Dados do cliente faltando verifique os campos de Razão Social, CPF e endereço");
                    return;
                }

                //se passou por todas as validações gera as cobranças
                DateTime hj = DateTime.Now;
                PedidoBalcaoCrediario c1 = new PedidoBalcaoCrediario();
                c1.IdPedidoBalcao = p.IdPedidoBalcao;
                c1.Data = hj;
                c1.Contador = 1;
                c1.Vencimento = hj.AddDays(30);
                c1.Valor = p.Crediario / Qtde;
                c1.ValorExtenso = Util.Valores.toExtenso(Convert.ToDecimal(c1.Valor));
                c1.IdCliente = p.IdCliente;
                pcdal.Insert(c1);
                pcdal.Save();

                if(Qtde >= 2)
                {
                    PedidoBalcaoCrediario c2 = new PedidoBalcaoCrediario();
                    c2.IdPedidoBalcao = p.IdPedidoBalcao;
                    c2.Data = hj;
                    c2.Contador = 2;
                    c2.Vencimento = hj.AddDays(60);
                    c2.Valor = p.Crediario / Qtde;
                    c2.ValorExtenso = Util.Valores.toExtenso(Convert.ToDecimal(c2.Valor));
                    c2.IdCliente = p.IdCliente;
                    pcdal.Insert(c2);
                    pcdal.Save();
                }

                if (Qtde >= 3)
                {
                    PedidoBalcaoCrediario c2 = new PedidoBalcaoCrediario();
                    c2.IdPedidoBalcao = p.IdPedidoBalcao;
                    c2.Data = hj;
                    c2.Contador = 2;
                    c2.Vencimento = hj.AddDays(60);
                    c2.Valor = p.Crediario / Qtde;
                    c2.ValorExtenso = Util.Valores.toExtenso(Convert.ToDecimal(c2.Valor));
                    c2.IdCliente = p.IdCliente;
                    pcdal.Insert(c2);
                    pcdal.Save();
                } 
            }
             

            if(Util.Aplicacao.ShowQuestionMessage("Confirma o pagamento?") == DialogResult.Yes)
            {
                SalvaDados();
                p.IdUsuarioPagamento = Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"));
                p.Status = tipoPagamento;
                p.IdCondicaoPagamento = 1;
                //Controla a condição de pagamento
                if (Qtde > 0)
                {
                    
                    switch (Qtde)
                    {
                        case 1: p.IdCondicaoPagamento = 3; break; //30 dias
                        case 2: p.IdCondicaoPagamento = 4; break; //30/60 dias
                        case 3: p.IdCondicaoPagamento = 2; break; //30/60/90
                    }
                }
                else
                {
                    if(qtdeCredito > 0)
                    {
                        switch (qtdeCredito)
                        {
                            case 1: p.IdCondicaoPagamento = 3; break; //30 dias
                            case 2: p.IdCondicaoPagamento = 4; break; //30/60 dias
                            case 3: p.IdCondicaoPagamento = 2; break; //30/60/90
                            case 4: p.IdCondicaoPagamento = 5; break; //30/60/90/120 DDL
                        }
                    }
                }
               
                dal.Update(p);
                dal.Save();
                btnConfirma.Enabled = false;
                btnConfirmaPgto.Enabled = false;
                btnRelatorio.Enabled = true; 

                //Gera contas a receber 
                BLL.BLContasReceber bl = new BLL.BLContasReceber();
                bool Credito = p.IdCondicaoPagamento == 1 ? false : true;

                //bl.GeraAPartirDoPedidoBalcao(p.IdPedidoBalcao, Credito);
                bl.GerarRecebimentoDoPedidoBalcao(p.IdPedidoBalcao);
                //Baixa Estoque
                BLL.BLInventario bli = new BLL.BLInventario();
                bli.BaixaPedidoBalcao(p.IdPedidoBalcao);
                // CarregaDados();
                btnConfirmaPgto.Enabled = false; 
                toolStripButton1.Enabled = true;
                Util.Aplicacao.ShowMessage("Pagamento confirmado");

                CarregaGrid();
            }
            
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            CrystalReports.frmCrystalReportViewer frmv = new CrystalReports.frmCrystalReportViewer("PedidoBalcao");
            List<FiltroRelatorio> FiltrosRelatorio = new List<FiltroRelatorio>();
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "Id", Valor = p.IdPedidoBalcao.ToString() });
            frmv.FiltrosRelatorio = FiltrosRelatorio;
            frmv.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddCliente_Click(object sender, EventArgs e)
        {
            frmCadClienteBalcao frmcl = new frmCadClienteBalcao();
            frmcl.ShowDialog();

            if(frmcl.c.IdCliente > 0)
            {
                txtCliente.Text = frmcl.c.RazaoSocial;
                txtCliente.Tag = frmcl.c.IdCliente;
                if (p == null)
                {
                    p = new PedidoBalcao();
                }
                if (p.IdPedidoBalcao > 0)
                {
                    p.IdCliente = Convert.ToInt32(frmcl.c.IdCliente);
                    p.NomeBalcao = txtCliente.Text;
                    dal.Update(p);
                    dal.Save(); 
                }
            } 
        }

        private void btnNF_Click(object sender, EventArgs e)
        {
            try
            {
                txtDescontoTotal.Text = "0,00";
                frmDescontoBalcao frmd = new frmDescontoBalcao(Convert.ToInt32(txtCliente.Tag));
                frmd.ShowDialog();
                Desconto = Convert.ToDecimal(frmd.txtDesconto.Text);
                if (Desconto < 0) Desconto = 0;

                lbpDesconto.Text = "% = " + Desconto.ToString("f2");
                CalculaValores();
                CarregaGrid();
            }
            catch  
            {
                 
            } 
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if(p.IdPedidoBalcao == 0)
            {
                return;
            }

            

            if(p.IdNotaFiscal == null || p.IdNotaFiscal == 0)
            {
                if(txtCliente.Tag.ToString() != "3")//Consumidor final
                {
                    if (Util.Aplicacao.ShowQuestionMessage("Deseja emitir a nota fiscal?") == DialogResult.Yes)
                    {
                        BLL.BLNotaFiscal bl = new BLL.BLNotaFiscal();
                        bl.dal = new NotaFiscalDAL();
                        bl.iDal = new NotaFiscalItemDAL();
                        bl.vDal = new NotaFiscalVencimentosDAL();
                        NotaFiscal nf = bl.GeraNotaFiscalVendasBalcao(p.IdPedidoBalcao, dal);
                        p = dal.GetByID(p.IdPedidoBalcao);
                        CarregaDados();
                        frmNotaFiscalCad frmnf = new frmNotaFiscalCad(nf, 6);
                        frmnf.ShowDialog();
                        toolStripButton1.Enabled = false;
                        button1.Enabled = false;
                    }
                    
                }
                else
                {
                    Util.Aplicacao.ShowMessage("Selecionie um cliente!");
                }
            }
            else
            {
                Util.Aplicacao.ShowMessage("Pedido já possui nota fiscal");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CrystalReports.frmCrystalReportViewer frmv = new CrystalReports.frmCrystalReportViewer("NotaPromissoria");
            List<FiltroRelatorio> FiltrosRelatorio = new List<FiltroRelatorio>();
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "IdPedidoBalcao", Valor = p.IdPedidoBalcao.ToString() });
            frmv.FiltrosRelatorio = FiltrosRelatorio;
            frmv.ShowDialog();
        }

        private void frmPedidoVendasBalcao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                try
                {
                    txtCodigo.Text = "";
                    BuscaProduto(); 
                }
                catch (Exception ex)
                { }
            }
        }

        private void txtDescontoTotal_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void txtDescontoTotal_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDescontoTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (Util.Util.IsNumber(txtDescontoTotal.Text))
                {
                    CalculaValores();
                }
            }     
        }

        private void btnAddPagamento_Click(object sender, EventArgs e)
        {
            PedidoBalcaoPagamento pf = new PedidoBalcaoPagamento();
            pf.IdPedidoBalcao = p.IdPedidoBalcao;
            frmAddPagamento frmap = new frmAddPagamento(pf);
            frmap.dal = fdal;
            frmap.ShowDialog();
            CarregaGrid();
            CalculaValores();
        }

        private void dgvFormasPagamento_DoubleClick(object sender, EventArgs e)
        {
            if(dgvFormasPagamento.Rows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvFormasPagamento.Rows[dgvFormasPagamento.SelectedRows[0].Index].Cells[0].Value);
                var pp = fdal.GetByID(Id);
                frmAddPagamento frmap = new frmAddPagamento(pp);
                frmap.dal = fdal;
                frmap.ShowDialog();
                CarregaGrid();
                CalculaValores();
            }
        }

        private void btnDevolucao_Click(object sender, EventArgs e)
        {

        }
    }



    class produtoGrid
    {
        public int IdPedidoBalcaoProduto { get; set; }
        public int IdProduto { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Qtde { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Desconto { get; set; }
    }
}
