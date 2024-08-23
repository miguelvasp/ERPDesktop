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
using ERP.Relatorios;

namespace ERP.Estoques
{
    public partial class frmInventarioEstoqueCad : Form
    {
        int Numero;
        List<InventarioEstoque> Lista = new List<InventarioEstoque>();
        public InventarioEstoqueDAL dal = new InventarioEstoqueDAL();
        public frmInventarioEstoqueCad(int pNumero)
        {
            Numero = pNumero;
            InitializeComponent();
        }

        private void frmInventarioEstoqueCad_Load(object sender, EventArgs e)
        {
            CarregaGrids();
        }

        private void CarregaGrids()
        { 
            Lista = dal.getByNumero(Numero);
            //Preenche os itens que tem que inventáriar
            var ListaPendente = Lista.Where(x => x.Status != "Confirmado").ToList();
            dgv.Rows.Clear();
            foreach (var p in ListaPendente)
            {
                dgv.Rows.Add(
                    p.IdInventarioEstoque, 
                    p.Produto.Codigo,
                    p.Produto.NomeProduto,
                    p.Deposito == null ? "" : p.Deposito.Descricao,
                    p.Armazem == null ? "" : p.Armazem.Descricao,
                    p.Localizacao == null ? "" : p.Localizacao.Nome,
                    p.VariantesCor == null ? "" : p.VariantesCor.Descricao,
                    p.VariantesTamanho == null ? "" : p.VariantesTamanho.Descricao,
                    p.VariantesEstilo == null ? "" : p.VariantesEstilo.Descricao,
                    p.VariantesConfig == null ? "" : p.VariantesConfig.Descricao,
                    p.Unidade == null ? "" : p.Unidade.UnidadeMedida,
                    p.QtdeEstoque,
                    p.QtdeInventario,
                    p.Status
                );
            }

            dgvConfirmados.Rows.Clear();
            var ListaConfirmados = Lista.Where(x => x.Status == "Confirmado").ToList();
            foreach (var p in ListaConfirmados)
            {
                dgvConfirmados.Rows.Add(
                    p.IdInventarioEstoque, 
                    p.Produto.Codigo,
                    p.Produto.NomeProduto,
                    p.Deposito == null ? "" : p.Deposito.Descricao,
                    p.Armazem == null ? "" : p.Armazem.Descricao,
                    p.Localizacao == null ? "" : p.Localizacao.Nome,
                    p.VariantesCor == null ? "" : p.VariantesCor.Descricao,
                    p.VariantesTamanho == null ? "" : p.VariantesTamanho.Descricao,
                    p.VariantesEstilo == null ? "" : p.VariantesEstilo.Descricao,
                    p.VariantesConfig == null ? "" : p.VariantesConfig.Descricao,
                    p.Unidade == null ? "" : p.Unidade.UnidadeMedida,
                    p.QtdeEstoque,
                    p.QtdeInventario,
                    p.Status
                );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgv.EndEdit();
            if(dgv.Rows.Count == 0)
            {
                Util.Aplicacao.ShowMessage("Não existem registros de inventário");
                return;
            }

            if(Util.Aplicacao.ShowQuestionMessage("Deseja atualizar o estoque dos items com status Quantidade Confirmada?") == DialogResult.Yes)
            {
                foreach (DataGridViewRow d in dgv.Rows)
                {
                    if (d.Cells[1].Value.ToString() == "Quantidade Confirmada")
                    {
                         
                        int id = Convert.ToInt32(d.Cells[0].Value);
                        InventarioEstoque inventario = Lista.Where(x => x.IdInventarioEstoque == id).FirstOrDefault();
                        if(inventario != null)
                        {
                            decimal Qtde = Convert.ToDecimal(d.Cells["QtdeInventario"].Value);
                            string Tipo = inventario.QtdeEstoque < Qtde ? "E" : "S";
                            //cria o ajuste de estoque
                            AjusteEstoque ae = new AjusteEstoque();
                            ae.Data = DateTime.Now;
                            ae.IdArmazem = inventario.IdArmazem;
                            ae.IdDeposito = inventario.IdDeposito;
                            ae.IdDocumento = inventario.IdInventarioEstoque;
                            ae.IdEmpresa = Convert.ToInt32(inventario.IdEmpresa);
                            ae.IdLocalizacao = inventario.IdLocalizacao;
                            ae.IdProduto = Convert.ToInt32(inventario.IdProduto);
                            ae.IdUnidade = Convert.ToInt32(inventario.IdUnidade);
                            ae.IdVariantesConfig = inventario.IdVariantesConfig;
                            ae.IdVariantesCor = inventario.IdVariantesCor;
                            ae.IdVariantesEstilo = inventario.IdVariantesEstilo;
                            ae.IdVariantesTamanho = inventario.IdVariantesTamanho;
                            ae.Motivo = "Inventário de Estoque N° " + inventario.Numero.ToString();
                            ae.Quantidade = Tipo == "E" ? Qtde - inventario.QtdeEstoque : inventario.QtdeEstoque - Qtde;
                             
                            BLL.BLInventario bl = new BLL.BLInventario();
                            if(Tipo == "E")
                            {
                                bl.AjusteEstoqueEntrada(ae);
                            }
                            else
                            {
                                bl.AjusteEstoqueSaida(ae);
                            }
                            inventario.QtdeInventario = Convert.ToInt32(d.Cells["QtdeInventario"].Value);
                            inventario.Status = "Confirmado";
                            dal.Update(inventario);
                            dal.Save();
                        }
                         
                    }
                } 
                CarregaGrids();
            } 
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(Util.Aplicacao.ShowQuestionMessage("Confirma a eliminação dos itens não confirmados?") == DialogResult.Yes)
            {
                foreach(DataGridViewRow dr in dgv.Rows)
                {
                    int id = Convert.ToInt32(dr.Cells["IdInventarioEstoque"].Value);
                    dal.Delete(id);
                    dal.Save();
                }
                CarregaGrids();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
            VisualizadorGenerico vg = new VisualizadorGenerico("InventarioEstoque");
            vg.InventarioEstoque = Lista;
            vg.ShowDialog();
        }
    }
}
