using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmBuscaProduto : Form
    {
        ProdutoDAL dal = new ProdutoDAL();
        public vwPesquisaProduto ProdutoSelecionado;

        bool Carregou = false;
        string Codigo = "";
        string Descricao = "";
        int VariantesGrupo = 0;
        int Cor = 0;
        int Estilo = 0;
        int Tamanho = 0;
        int Config = 0;
        int tipodeproduto = 0;
        public int IdCorProducao = 0;
        string PRAcabado;
        public frmBuscaProduto(string pProdutoAcabado = "N")
        {
            PRAcabado = pProdutoAcabado;
            InitializeComponent();
            CarregaCombos(); 
        }

        private void CarregaCombos()
        {
            cboGrupoVariantes.DataSource = new VariantesGrupoDAL().Get();
            cboGrupoVariantes.DisplayMember = "Descricao";
            cboGrupoVariantes.ValueMember = "IdVariantesGrupo";
            cboGrupoVariantes.SelectedIndex = -1;

            cboConfiguracao.DataSource = new VariantesConfigDAL().Get();
            cboConfiguracao.ValueMember = "IdVariantesConfig";
            cboConfiguracao.DisplayMember = "Descricao";
            cboConfiguracao.SelectedIndex = -1;

            cboTamanho.DataSource = new VariantesTamanhoDAL().Get();
            cboTamanho.ValueMember = "IdVariantesTamanho";
            cboTamanho.DisplayMember = "Descricao";
            cboTamanho.SelectedIndex = -1;
            
            List<ComboItem> ProdutoAcabado = new List<ComboItem>();
            ProdutoAcabado.Add(new ComboItem() { iValue = 1, Text = "Matéria Prima" });
            ProdutoAcabado.Add(new ComboItem() { iValue = 2, Text = "Produto Acabado" });
            ProdutoAcabado.Add(new ComboItem() { iValue = 3, Text = "Insumos" });

            cboProdutoAcabadoMateriaPrima.DataSource = ProdutoAcabado;
            cboProdutoAcabadoMateriaPrima.DisplayMember = "Text";
            cboProdutoAcabadoMateriaPrima.ValueMember = "iValue";
            cboProdutoAcabadoMateriaPrima.SelectedIndex = -1;

            if(PRAcabado == "N")
            {
                cboProdutoAcabadoMateriaPrima.Visible = false;
                label19.Visible = false;
            }
            else
            {
                cboProdutoAcabadoMateriaPrima.SelectedValue = 1;
            }

            cboCor.DataSource = new VariantesCorDAL().Get();
            cboCor.ValueMember = "IdVariantesCor";
            cboCor.DisplayMember = "Descricao";
            cboCor.SelectedIndex = -1;

            if(IdCorProducao > 0)
            {
                cboCor.SelectedValue = IdCorProducao;
                cboCor.Enabled = false;
            }

            cboDescricao.DataSource = new ProdutoDAL().GetComboVendas();
            cboDescricao.ValueMember = "iValue";
            cboDescricao.DisplayMember = "Text";
            cboDescricao.SelectedIndex = -1;

            cboEstilo.DataSource = new VariantesEstiloDAL().Get();
            cboEstilo.ValueMember = "IdVariantesEstilo";
            cboEstilo.DisplayMember = "Descricao";
            cboEstilo.SelectedIndex = -1;
            Carregou = true;
        }

        private void Busca()
        {
            if (Carregou)
            {
                Codigo = txtCodigo.Text;
                Descricao = cboDescricao.Text;
                VariantesGrupo = cboGrupoVariantes.Text == "" ? 0 : Convert.ToInt32(cboGrupoVariantes.SelectedValue);
                Cor = cboCor.Text == "" ? 0 : Convert.ToInt32(cboCor.SelectedValue);
                Estilo = cboEstilo.Text == "" ? 0 : Convert.ToInt32(cboEstilo.SelectedValue);
                Tamanho = cboTamanho.Text == "" ? 0 : Convert.ToInt32(cboTamanho.SelectedValue);
                Config = cboConfiguracao.Text == "" ? 0 : Convert.ToInt32(cboConfiguracao.SelectedValue);
                tipodeproduto = cboProdutoAcabadoMateriaPrima.Text == "" ? 0 : Convert.ToInt32(cboProdutoAcabadoMateriaPrima.SelectedValue);
                var lista = dal.PesquisaProdutos(Codigo, Descricao, VariantesGrupo, Cor, Estilo, Tamanho, Config, tipodeproduto);
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = lista;
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            Busca();
        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {
            Busca();
        }

        private void cboGrupoVariantes_Leave(object sender, EventArgs e)
        {
            Busca();
        }

        private void cboCor_Leave(object sender, EventArgs e)
        {
            Busca();
        }

        private void cboEstilo_Leave(object sender, EventArgs e)
        {
            Busca();
        }

        private void cboTamanho_Leave(object sender, EventArgs e)
        {
            Busca();
        }

        private void cboConfiguracao_Leave(object sender, EventArgs e)
        {
            Busca();
        }

        private void MontaProduto()
        {
            try
            {
                if (dgv.Rows.Count > 0)
                {
                    ProdutoSelecionado = new vwPesquisaProduto();
                    ProdutoSelecionado.IdProduto = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value);
                    var p = dal.GetByID(Convert.ToInt32(ProdutoSelecionado.IdProduto));
                    ProdutoSelecionado.IdUnidade = p.ProducaoIdUnidade;
                    if (dgv.Rows[dgv.SelectedRows[0].Index].Cells["IdVariantesGrupo"].Value != null)
                        ProdutoSelecionado.IdVariantesGrupo = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells["IdVariantesGrupo"].Value);

                    if (dgv.Rows[dgv.SelectedRows[0].Index].Cells["IdVariantesCor"].Value != null)
                        ProdutoSelecionado.IdVariantesCor = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells["IdVariantesCor"].Value);

                    if (dgv.Rows[dgv.SelectedRows[0].Index].Cells["IdVariantesEstilo"].Value != null)
                        ProdutoSelecionado.IdVariantesEstilo = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells["IdVariantesEstilo"].Value);

                    if (dgv.Rows[dgv.SelectedRows[0].Index].Cells["IdVariantesTamanho"].Value != null)
                        ProdutoSelecionado.IdVariantesTamanho = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells["IdVariantesTamanho"].Value);

                    if (dgv.Rows[dgv.SelectedRows[0].Index].Cells["IdVariantesConfig"].Value != null)
                        ProdutoSelecionado.IdVariantesConfig = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells["IdVariantesConfig"].Value);
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0 && e.RowIndex > -1)
            {
                MontaProduto();
                this.Close();
            }
        }

        private void cboGrupoVariantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Busca();
        }

        private void frmBuscaProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");

            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Busca();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            MontaProduto();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ProdutoSelecionado = null;
            this.Close();
        }

        private void frmBuscaProduto_Load(object sender, EventArgs e)
        {
            //carrega os clientes
            if(IdCorProducao > 0)
            {
                Busca();
            }
            
        }

        private void cboDescricao_SelectedIndexChanged(object sender, EventArgs e)
        {
            Busca();
        }
    }
}
