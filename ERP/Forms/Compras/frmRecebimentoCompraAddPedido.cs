using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmRecebimentoCompraAddPedido : Form
    {
        RecebimentoDAL dal = new RecebimentoDAL();
        Recebimento r = new Recebimento();
        int IdRecebimento = 0;
        List<ModelView.RecebimentoItemModelView> lista;
        public frmRecebimentoCompraAddPedido(RecebimentoDAL pDal, int pIdRecebimento, List<ModelView.RecebimentoItemModelView> plista)
        {
            dal = pDal;
            IdRecebimento = pIdRecebimento;
            lista = plista;
            InitializeComponent();
        }

        private void frmRecebimentoCompraAddPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void frmRecebimentoCompraAddPedido_Load(object sender, EventArgs e)
        {
            CarregaItensPedidos();
        }

        private void CarregaItensPedidos()
        {
            r = dal.RRepository.Get(w => w.IdRecebimento.Equals(IdRecebimento), null, "Usuario,Fornecedor").FirstOrDefault();

            txtRecebimento.Text = r.RecebimentoNumero.ToString();
            txtData.Text = r.DataFisica.ToShortDateString();
            txtUsuario.Text = r.Usuario.NomeCompleto;
            txtFornecedor.Text = r.Fornecedor.NomeFantasia;

             
            List<PedidoComprasItemModelView> pci = new vwPedidosCompraRecebimentoDAL().GetItensByFornecedor(r.IdFornecedor);

            if (pci != null && pci.Count() > 0)
            {
                ////baixa os itens existentes no recebimento
                //if (lista != null && lista.Count() > 0)
                //{
                //    foreach (var i in lista)
                //    {
                //        if (i.QuantidadeRecebida > 0)
                //        {
                //            var it = pci.Where(x => x.IdPedidoCompraItem == i.IdPedidoCompraItem).FirstOrDefault();
                //            if (it != null)
                //            {
                //                it.QuantidadeAReceber = it.QuantidadeAReceber - i.QuantidadeRecebida;
                //            }
                //        }
                //    }
                //} 
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = pci; 
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                dgv.EndEdit();

                //verifica os valores
                bool erro = false;
                foreach (DataGridViewRow dr in dgv.Rows)
                {
                    if (Convert.ToBoolean(dr.Cells[0].Value))
                    {
                        decimal qtdeAberto = Convert.ToDecimal(dr.Cells[7].Value);
                        decimal qtdeReceber = Convert.ToDecimal(dr.Cells[8].Value);
                        if(qtdeReceber > qtdeAberto)
                        {
                            erro = true;
                        }
                    }
                }

                if(erro)
                {
                    Util.Aplicacao.ShowMessage("A quantidade recebida não pode ser superior a quantidade a receber");
                    return;
                }


                foreach (DataGridViewRow dr in dgv.Rows)
                {
                    if (Convert.ToBoolean(dr.Cells[0].Value))
                    {
                        int idPedido = Convert.ToInt32(dr.Cells[1].Value);
                        int idPedidoItem = Convert.ToInt32(dr.Cells[2].Value);
                        decimal QuantidadeRecebida = Convert.ToDecimal(dr.Cells[8].Value);
                        decimal Saldo = Convert.ToDecimal(dr.Cells[9].Value);
                        decimal ValorTotal = Convert.ToDecimal(dr.Cells[12].Value);

                        if (QuantidadeRecebida > 0)
                        {
                            PedidoCompraItem pci = dal.PCIRepository.Get(w => w.IdPedidoCompra.Equals(idPedido), null, "Produto").FirstOrDefault();
                            if (pci != null)
                            {
                                RecebimentoItem r = new RecebimentoItem();

                                r.IdRecebimento = IdRecebimento;
                                r.IdPedidoCompra = idPedido;
                                r.IdPedidoCompraItem = idPedidoItem;
                                r.IdProduto = pci.IdProduto;
                                r.NomeProduto = pci.Produto.NomeProduto;

                                r.QuantidadeRecebida = QuantidadeRecebida;
                                if (pci.IdUnidade.HasValue) r.IdUnidade = pci.IdUnidade.Value;
                                if (pci.PrecoUnitario.HasValue) r.ValorUnitario = pci.PrecoUnitario.Value;
                                r.ValorTotal = ValorTotal;

                                if (pci.DescontoValor.HasValue) r.Desconto = pci.DescontoValor.Value;
                                r.Seguro = 0;
                                r.Frete = 0;
                                r.DespesasAcessorias = 0;
                                r.Royalties = 0;
                                if (pci.ValorLiquido.HasValue) r.ValorLiquido = pci.ValorLiquido.Value;

                                if (pci.IdVariantesEstilo.HasValue) r.IdVariantesEstilo = pci.IdVariantesEstilo.Value;
                                if (pci.IdVariantesCor.HasValue) r.IdVariantesCor = pci.IdVariantesCor.Value;
                                if (pci.IdVariantesTamanho.HasValue) r.IdVariantesTamanho = pci.IdVariantesTamanho.Value;
                                r.IdVariantesConfig = pci.IdVariantesConfig;
                                if (pci.IdGrupoLotes.HasValue) r.IdGrupoLotes = pci.IdGrupoLotes.Value;
                                if (pci.IdGrupoSeries.HasValue) r.IdGrupoSeries = pci.IdGrupoSeries.Value;
                                if (pci.IdArmazem.HasValue) r.IdArmazem = pci.IdArmazem.Value;
                                if (pci.IdDeposito.HasValue) r.IdDeposito = pci.IdDeposito.Value;
                                if (pci.IdLocalizacao.HasValue) r.IdLocalizacao = pci.IdLocalizacao.Value;

                                if (pci.IdGrupodeAtivo.HasValue) r.IdGrupoAtivo = pci.IdGrupodeAtivo.Value;
                                if (pci.IdMetodoPreciacao.HasValue) r.IdMetodoDepreciacao = pci.IdMetodoPreciacao.Value;
                                if (pci.IdAtivoFixo.HasValue) r.IdAtivoFixo = pci.IdAtivoFixo.Value;

                                dal.RIRepository.Insert(r);

                                // Alterando os valores do Item do Pedido //
                                pci.QuantidadeRecebida = QuantidadeRecebida;
                                pci.QuantidadeAReceber = pci.QuantidadeAReceber - QuantidadeRecebida;

                                if (pci.QuantidadeAReceber == 0)
                                {
                                    pci.Status = "T"; // Total
                                }
                                else
                                {
                                    pci.Status = "P"; // Parcial
                                }

                                dal.PCIRepository.Update(pci);

                                dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                                // Gravação do Status do Pedido de Compra //
                                PedidoCompra p = new PedidoCompra();
                                p = dal.PCRepository.GetByID(idPedido);

                                decimal soma = dal.GetSumQuantidadeAReceber(idPedido);

                                if (soma == 0)
                                {
                                    p.Status = "Atendido";
                                }
                                else
                                {
                                    p.Status = "Parcial";
                                }

                                dal.PCRepository.Update(p);
                                dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                            }
                        }
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var cell = dgv[e.ColumnIndex, e.RowIndex];
                if (cell.OwningColumn.Name == "QuantidadeRecebida")
                {
                    var cellQtde = dgv[8, e.RowIndex];
                    var cellSaldo = dgv[9, e.RowIndex];
                    var cellValorUnitario = dgv[11, e.RowIndex];
                    var cellValorTotal = dgv[12, e.RowIndex];

                    decimal Qtde = (decimal)cellQtde.Value;
                    decimal QtdeRecebida = (decimal)cell.Value;
                    decimal ValorUnitario = (decimal)cellValorUnitario.Value;

                    if (QtdeRecebida > 0)
                    {
                        if (QtdeRecebida > Qtde)
                        {
                            cell.Value = (decimal)0;
                            Util.Aplicacao.ShowMessage("Quantidade Recebida é maior que a Quantidade do pedido, verifique.");
                        }
                        else
                        {
                            cellSaldo.Value = Qtde - QtdeRecebida;
                            cellValorTotal.Value = ValorUnitario * QtdeRecebida;
                        }
                    }
                    else
                    {
                        cellSaldo.Value = Qtde - QtdeRecebida;
                        cellValorTotal.Value = ValorUnitario * QtdeRecebida;
                    }
                }
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var cell = dgv[e.ColumnIndex, e.RowIndex];
                    if (cell.OwningColumn.Name == "chkSelecionar")
                    {

                        decimal Qtde = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells[7].Value);
                        decimal QtdeRecebida = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells[8].Value);
                        decimal zerado = 0.00m;
                        if (cell.EditedFormattedValue.ToString().ToLower() == "true")
                        {
                            dgv.Rows[e.RowIndex].Cells[8].Value = Qtde;
                            //dgv.Rows[e.RowIndex].Cells[9].Value = 0;
                        }
                        else
                        {
                            dgv.Rows[e.RowIndex].Cells[8].Value = zerado;
                            //dgv.Rows[e.RowIndex].Cells[9].Value = Qtde - QtdeRecebida;
                        }
                    }
                }
            }
            catch 
            {
                 
            }
            
        }
    }
}
