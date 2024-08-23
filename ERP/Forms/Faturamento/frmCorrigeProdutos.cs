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

namespace ERP.Forms.Faturamento
{
    public partial class frmCorrigeProdutos : Form
    {
        public ProdutoDAL pdal = new ProdutoDAL();
        GrupoProdutoDAL gdal = new DAL.GrupoProdutoDAL();
        public List<GrupoProduto> Grupos = new DAL.GrupoProdutoDAL().Get().OrderBy(x => x.Nome).ToList();
        int IdNotaFiscal = 0;
        public frmCorrigeProdutos(int Id)
        {
            IdNotaFiscal = Id;
            InitializeComponent();
        }

        private void frmCorrigeProdutos_Load(object sender, EventArgs e)
        {

            cboGrupo.DataSource = new GrupoProdutoDAL().GetCombo();
            cboGrupo.DisplayMember = "Text";
            cboGrupo.ValueMember = "iValue";
            cboGrupo.SelectedIndex = -1;

            if (IdNotaFiscal != 0)
            {
                cboGrupo.Visible = false;
                label1.Visible = false;
            }


            (dataGridView1.Columns[3] as DataGridViewComboBoxColumn).DataSource = Grupos.Select(x => x.Nome).ToList();
            var produtos = new NotaFiscalItemDAL().GetByNF(IdNotaFiscal);
            foreach (var p in produtos)
            {
                dataGridView1.Rows.Add(new string[] {
                    p.IdProduto.ToString(),
                    p.Produto.Codigo,
                    p.Produto.NomeProduto,
                    p.Produto.GrupoProduto == null ? "" : p.Produto.GrupoProduto.Nome,
                    p.Produto.VendaMagemLucro.ToString(),
                    p.Produto.VendaPrecoUnit.ToString() });
            }
        }

        private void cboGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();


        }

        private void Buscar()
        {
            if (IdNotaFiscal == 0)
            {
                try
                {
                    dataGridView1.Rows.Clear();
                    if(chkDuplicados.Checked)
                    {
                        var produtos = pdal.getDuplicados();
                        foreach (var p in produtos)
                        {
                            dataGridView1.Rows.Add(new string[] {
                            p.IdProduto.ToString(),
                            p.Codigo,
                            p.NomeProduto,
                            p.GrupoProduto == null ? "" : p.GrupoProduto.Nome,
                            p.VendaMagemLucro.ToString(),
                            p.VendaPrecoUnit.ToString() });
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(cboGrupo.Text) || !string.IsNullOrEmpty(txtCodigo.Text))
                        {
                            int IdGrupoBusca = string.IsNullOrEmpty(cboGrupo.Text) ? 0 : Convert.ToInt32(cboGrupo.SelectedValue);
                            var prod = pdal.getByGrupo(IdGrupoBusca, txtCodigo.Text);
                            foreach (var p in prod)
                            {
                                dataGridView1.Rows.Add(new string[] {
                            p.IdProduto.ToString(),
                            p.Codigo,
                            p.NomeProduto,
                            p.GrupoProduto == null ? "" : p.GrupoProduto.Nome,
                            p.VendaMagemLucro.ToString(),
                            p.VendaPrecoUnit.ToString() });
                            }
                        }
                        else
                        {
                            var produtos = pdal.getSemGrupo();
                            foreach (var p in produtos)
                            {
                                dataGridView1.Rows.Add(new string[] {
                            p.IdProduto.ToString(),
                            p.Codigo,
                            p.NomeProduto,
                            p.GrupoProduto == null ? "" : p.GrupoProduto.Nome,
                            p.VendaMagemLucro.ToString(),
                            p.VendaPrecoUnit.ToString() });
                            }
                        }
                    }
                    
                }
                catch
                {

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            if (Util.Aplicacao.ShowQuestionMessage("Deseja salvar as alterações?") == DialogResult.Yes)
            {
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    int Id = Convert.ToInt32(dr.Cells[0].Value);
                    Produto p = pdal.GetByID(Id);
                    p.NomeProduto = dr.Cells[2].Value.ToString();

                    string grupo = dr.Cells[3].Value.ToString();
                    GrupoProduto g = gdal.getByNome(grupo);
                    if (g != null)
                    {
                        p.IdGrupoProduto = g.IdGrupoProduto;
                    }

                    p.VendaMagemLucro = Convert.ToDecimal(dr.Cells[4].Value);
                    p.VendaPrecoUnit = Convert.ToDecimal(dr.Cells[5].Value);
                    pdal.ProdutoRepository.Update(p);
                    pdal.Save();
                }
                Util.Aplicacao.ShowMessage("Valores alterados com sucesso!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMargem.Text))
            {
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    dr.Cells[4].Value = txtMargem.Text;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                string Codigo = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[1].Value.ToString();
                if(!string.IsNullOrEmpty(Codigo))
                {
                    if(Util.Aplicacao.ShowQuestionMessage($"Tem certeza que deseja unificar o estoque dos produtos com código {Codigo}?") == DialogResult.Yes)
                    {
                        SQLDataLayer odal = new SQLDataLayer();
                        odal.UnificaEstoque(Codigo);
                        Buscar();
                    }
                }
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void chkDuplicados_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDuplicados.Checked)
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
            Buscar();
        }
    }
}
