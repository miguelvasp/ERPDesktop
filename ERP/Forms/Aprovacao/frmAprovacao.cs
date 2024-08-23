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
using ERP.BLL;
using ERP.Compras;

namespace ERP.Aprovacao
{
    public partial class frmAprovacao : Form
    {
        int TipoDocumento;
        int iUsuario = Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"));
        string Senha = Util.Util.Descriptografar(new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).Senha);
        BLAprovacaoDocumentos blAprovacao = new BLAprovacaoDocumentos();
        PedidoCompraDAL pcDal = new PedidoCompraDAL();
        PedidoCompraAprovacaoDAL pcaDal = new PedidoCompraAprovacaoDAL();
        PedidoVendaDAL pvDal = new PedidoVendaDAL();
        PedidoVendaAprovacaoDAL pvaDal = new PedidoVendaAprovacaoDAL();



        public frmAprovacao(int pTipoDocumento)
        {
            TipoDocumento = pTipoDocumento;
            InitializeComponent();
        }

        private void frmAprovacao_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            BLAprovacaoDocumentos bla = new BLAprovacaoDocumentos();
            var lista = bla.GetDocumentos(TipoDocumento, iUsuario);
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = lista;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = false;
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value);
                if (TipoDocumento == 1)//Pedido de Compras
                {
                    PedidoCompra pc = pcDal.PCRepository.GetByID(id);
                    frmPedidoComprasCad pcCad = new frmPedidoComprasCad(pcDal, pc);
                    pcCad.ShowDialog();
                }
                else if (TipoDocumento == 2)//Pedido Vendas
                {
                    PedidoVenda pv = pvDal.PVRepository.GetByID(id);
                    frmPedidoVendasCad pvCad = new frmPedidoVendasCad(pvDal, pv);
                    pvCad.ShowDialog();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ckeckCount = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if ((bool)chk.Value == true)
                    ckeckCount += 1;
            }
            if (ckeckCount == 0)
            {
                Util.Aplicacao.ShowMessage("Nenhum registro selecionado");
                return;
            }

            if (txtSenha.Text.ToUpper() == Senha.ToUpper())
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if ((bool)chk.Value == true)
                    {

                        DataGridViewTextBoxCell txId = (DataGridViewTextBoxCell)row.Cells[1];
                        DataGridViewTextBoxCell txSeq = (DataGridViewTextBoxCell)row.Cells[2];

                        int id = Convert.ToInt32(txId.Value);
                        int Sequencia = Convert.ToInt32(txSeq.Value);
                        if (TipoDocumento == 1)
                        {
                            PedidoCompra pc = pcDal.PCRepository.GetByID(id);
                            List<PedidoCompraItem> ItensCompras = pcDal.GetItensByPedido(id);
                            AprovacaoNivel nivel = blAprovacao.GetNexNivel("PC", Sequencia);
                            pc.StatusAprovacao = nivel.IdAprovacaoNivel;
                            pcDal.PCRepository.Update(pc);
                            pcDal.Save(Util.Util.GetAppSettings("IdUsuario"));

                            //Lança o valor no historico
                            PedidoCompraAprovacao pa = new PedidoCompraAprovacao();
                            pa.Data = DateTime.Now;
                            pa.IdPedidoCompra = pc.IdPedidoCompra;
                            pa.NovoStatus = nivel.Nome;
                            pa.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                            pcaDal.Insert(pa);
                            pcaDal.Save();



                            //Verifica se o pedido de Compras foi Liberado então gera Estoque.
                            if (nivel.Nome == "Liberado")
                            {
                                foreach (PedidoCompraItem pci in ItensCompras)
                                {
                                    BLInventario blInv = new BLInventario();
                                    //blInv.EntradaNoEstoqueReserva(pci.IdProduto,
                                    //                              pc.IdDeposito,
                                    //                              pc.IdArmazem,
                                    //                              pci.IdLocalizacao,
                                    //                              pci.IdVariantesConfig,
                                    //                              pci.IdVariantesTamanho,
                                    //                              pci.IdVariantesCor,
                                    //                              pci.IdVariantesEstilo,
                                    //                              pci.IdUnidade,
                                    //                              pci.IdPedidoCompraItem,
                                    //                              pci.IdNCM,
                                    //                              pci.Quantidade);
                                }
                            }
                        }
                        else if (TipoDocumento == 2)
                        {
                            PedidoVenda pv = pvDal.PVRepository.GetByID(id);
                            AprovacaoNivel nivel = blAprovacao.GetNexNivel("PV", Sequencia);
                            pv.StatusAprovacao = nivel.IdAprovacaoNivel;
                            pv.Status = 2; //passa o status para separação
                            pvDal.PVRepository.Update(pv);
                            pvDal.Save(Util.Util.GetAppSettings("IdUsuario"));

                            //Lança o valor no historico
                            PedidoVendaAprovacao pa = new PedidoVendaAprovacao();
                            pa.Data = DateTime.Now;
                            pa.IdPedidoVenda = pv.IdPedidoVenda;
                            pa.NovoStatus = nivel.Nome;
                            pa.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                            pvaDal.Insert(pa);
                            pvaDal.Save();
                        }

                        //DEpois de atualizar recarrega o grid
                        CarregaGrid();
                        txtSenha.Text = "";
                        txtSenha.Focus();
                    }

                }
            }
            else
            {
                Util.Aplicacao.ShowMessage("Senha incorreta");
            }
        }
    }
}
