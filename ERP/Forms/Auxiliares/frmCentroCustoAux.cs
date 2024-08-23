using ERP.DAL;
using ERP.DAL.Cadastros;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP.Auxiliares
{
    public partial class frmCentroCustoAux : Form
    {
        ValoresCentroCustoDAL vDal = new ValoresCentroCustoDAL();
        public FornecedorCentroCustoDAL fdal = new FornecedorCentroCustoDAL();
        public ClienteCentroCustoDAL cdal = new ClienteCentroCustoDAL();
        public PedidoCompraCentroCustoDAL pcdal = new PedidoCompraCentroCustoDAL();
        public PedidoVendaCentroCustoDAL pvdal = new PedidoVendaCentroCustoDAL();
        public PedidoCompraItemCentroCustoDAL pcidal = new PedidoCompraItemCentroCustoDAL();
        public PedidoVendaItemCentroCustoDAL pvidal = new PedidoVendaItemCentroCustoDAL();
        public ProdutoCentroCustoDAL prdal = new ProdutoCentroCustoDAL();

        List<int?> ItensSalvos = new List<int?>();

        string Tipo = "";
        int Id = 0;
        public frmCentroCustoAux(string pTipo, int pId)
        {
            Tipo = pTipo;
            Id = pId;
            InitializeComponent();
        }

        private void frmCentroCustoAux_Load(object sender, EventArgs e)
        {
            //Preenche a listagem dos itens ja existentes.
            if (Tipo == "F") ItensSalvos = fdal.GetValoresCadastrados(Id);
            if (Tipo == "C") ItensSalvos = cdal.GetValoresCadastrados(Id);
            if (Tipo == "PC") ItensSalvos = pcdal.GetValoresCadastrados(Id);
            if (Tipo == "PV") ItensSalvos = pvdal.GetValoresCadastrados(Id);
            if (Tipo == "PCI") ItensSalvos = pcidal.GetValoresCadastrados(Id);
            if (Tipo == "PVI") ItensSalvos = pvidal.GetValoresCadastrados(Id);
            if (Tipo == "PR") ItensSalvos = prdal.GetValoresCadastrados(Id);

            var lista = vDal.GetListagem();
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = lista;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                dgv.EndEdit();
            }
            catch { }

            foreach (DataGridViewRow dr in dgv.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[0].Value))
                {
                    if (Tipo == "F" && !ItensSalvos.Contains(Convert.ToInt32(dr.Cells[1].Value)))
                    {
                        FornecedorCentroCusto fc = new FornecedorCentroCusto();
                        fc.IdFornecedor = Id;
                        fc.IdValoresCentroCusto = Convert.ToInt32(dr.Cells[1].Value);
                        fdal.Insert(fc);
                        fdal.Save();
                    }

                    if (Tipo == "C" && !ItensSalvos.Contains(Convert.ToInt32(dr.Cells[1].Value)))
                    {
                        ClienteCentroCusto cc = new ClienteCentroCusto();
                        cc.IdCliente = Id;
                        cc.IdValoresCentroCusto = Convert.ToInt32(dr.Cells[1].Value);
                        cdal.Insert(cc);
                        cdal.Save();
                    }

                    if (Tipo == "PC" && !ItensSalvos.Contains(Convert.ToInt32(dr.Cells[1].Value)))
                    {
                        PedidoCompraCentroCusto pc = new PedidoCompraCentroCusto();
                        pc.IdPedidoCompra = Id;
                        pc.IdValoresCentroCusto = Convert.ToInt32(dr.Cells[1].Value);
                        pcdal.Insert(pc);
                        pcdal.Save();
                    }

                    if (Tipo == "PCI" && !ItensSalvos.Contains(Convert.ToInt32(dr.Cells[1].Value)))
                    {
                        PedidoCompraItemCentroCusto pc = new PedidoCompraItemCentroCusto();
                        pc.IdPedidoCompraItem = Id;
                        pc.IdValoresCentroCusto = Convert.ToInt32(dr.Cells[1].Value);
                        pcidal.Insert(pc);
                        pcidal.Save();
                    }

                    if (Tipo == "PVI" && !ItensSalvos.Contains(Convert.ToInt32(dr.Cells[1].Value)))
                    {
                        PedidoVendaItemCentroCusto pv = new PedidoVendaItemCentroCusto();
                        pv.IdPedidoVendaItem = Id;
                        pv.IdValoresCentroCusto = Convert.ToInt32(dr.Cells[1].Value);
                        pvidal.Insert(pv);
                        pvidal.Save();
                    }
                    if (Tipo == "PV" && !ItensSalvos.Contains(Convert.ToInt32(dr.Cells[1].Value)))
                    {
                        PedidoVendaCentroCusto pv = new PedidoVendaCentroCusto();
                        pv.IdPedidoVenda = Id;
                        pv.IdValoresCentroCusto = Convert.ToInt32(dr.Cells[1].Value);
                        pvdal.Insert(pv);
                        pvdal.Save();
                    }
                    if (Tipo == "PR" && !ItensSalvos.Contains(Convert.ToInt32(dr.Cells[1].Value)))
                    {
                        ProdutoCentroCusto pr = new ProdutoCentroCusto();
                        pr.IdProduto = Id;
                        pr.IdValoresCentroCusto = Convert.ToInt32(dr.Cells[1].Value);
                        prdal.Insert(pr);
                        prdal.Save();
                    }
                }
            }

            Util.Aplicacao.ShowMessage("Os centros de custo selecionados foram salvos.");
            this.Close();
        }
    }
}
