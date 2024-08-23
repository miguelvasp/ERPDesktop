using ERP.CrystalReports;
using ERP.DAL;
using ERP.Forms.Produção;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmOrdemProducaoCad : RibbonForm
    {
        public OrdemProducaoDAL dal = new OrdemProducaoDAL();
        OrdemProducaoEtapaDAL eDal = new OrdemProducaoEtapaDAL();
        OrdemProducaoControleQualidadeDAL qDal = new OrdemProducaoControleQualidadeDAL();
        OrdemProducaoMateriaPrimaDAL mDal = new OrdemProducaoMateriaPrimaDAL();
        OrdemProducaoProdutoDAL pDal = new OrdemProducaoProdutoDAL();

        OrdemProducao p = new OrdemProducao();

        public frmOrdemProducaoCad(OrdemProducao pC)
        {
            p = pC;
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
            if (p.IdOrdemProducao == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void frmAutoridadeCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaCombos()
        {
            List<ComboItem> tipo = new List<ComboItem>();
            tipo.Add(new ComboItem() { iValue = 1, Text = "Normal" });
            tipo.Add(new ComboItem() { iValue = 2, Text = "Urgente" });
            cboTipoProducao.DataSource = tipo;
            cboTipoProducao.ValueMember = "iValue";
            cboTipoProducao.DisplayMember = "Text";
            cboTipoProducao.SelectedIndex = -1;

            cboStatus.DataSource = dal.getStatus();
            cboStatus.ValueMember = "iValue";
            cboStatus.DisplayMember = "Text";
            cboStatus.SelectedIndex = -1;

        }

        private void CarregaDados()
        {
            txtNumeroOP.Text = p.NumeroOP.ToString();
            cboTipoProducao.SelectedValue = p.TipoProducao;
            cboStatus.SelectedValue = p.StatusProducao;
            txtPlano.Text = dal.getPlanoNome(Convert.ToInt32(p.IdPlanoProducao));
            txtQtde.Text = p.Quantidade.ToString();
            txtLote.Text = p.Lote.Ano.ToString() + p.Lote.numero.ToString();
            txtDtProgramada.Text = p.DataProgramada.ToString();
            txtDtInicio.Text = p.DataInicial.ToString();
            txtDtFim.Text = p.DataFinal.ToString();
            CarregaGrid(); 
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }



        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            //p = new OrdemProducao();
            //CarregaGrid();
            //Util.Aplicacao.LimpaControles(this);
            //Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            if(p.StatusProducao == 6 || p.StatusProducao == 5)
            {
                Util.Aplicacao.ShowMessage("Ordem de produção não pode ser modificada");
                return;
            }


            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    p.TipoProducao = Convert.ToInt32(cboTipoProducao.SelectedValue);
                    p.StatusProducao = Convert.ToInt32(cboStatus.SelectedValue);
                    p.DataProgramada = Util.Validacao.IsDateTime(txtDtProgramada.Text);
                    p.DataFinal = Util.Validacao.IsDateTime(txtDtFim.Text);
                    p.DataInicial = Util.Validacao.IsDateTime(txtDtInicio.Text);
                    dal.Update(p); 
                    dal.Save();

                    OrdemProducaoMateriaPrimaDAL odal = new OrdemProducaoMateriaPrimaDAL();
                    //Salva os dados dos materiais
                    foreach(DataGridViewRow dr in dgvEtapa.Rows)
                    {
                        int Id = Convert.ToInt32(dr.Cells[0].Value);
                        var m = odal.GetByID(Id);
                        if(m != null)
                        {
                            m.LitrosTotal = Convert.ToDecimal(dr.Cells[6].Value);
                            m.KilosTotal = Convert.ToDecimal(dr.Cells[7].Value);
                            odal.Update(m);
                            odal.Save();
                        } 
                        
                    }


                    //Salva os dados dos produtos acabados
                    OrdemProducaoProdutoDAL pdal = new OrdemProducaoProdutoDAL();
                    //Salva os dados dos materiais
                    foreach (DataGridViewRow dr in dgvProduto.Rows)
                    {
                        int Id = Convert.ToInt32(dr.Cells[0].Value);
                        var prd = pdal.GetByID(Id);
                        if(prd != null)
                        {
                            prd.Qtde = Convert.ToDecimal(dr.Cells[2].Value);
                            pdal.Update(prd);
                            pdal.Save();
                        }
                        
                    }


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
                int id = p.IdOrdemProducao;
                dal.Delete(id);
                dal.Save();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (p.IdOrdemProducao == 0)
            {
                Util.Aplicacao.ShowMessage("Salve os dados  antes de adicionar informações.");
                return;
            }

             
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            try
            {
                var Etapas = new OrdemProducaoEtapaDAL().getListByOP(p.IdOrdemProducao);
                foreach(var e in Etapas)
                {
                    foreach(var m in e.Materiais)
                    {
                        string[] row = new string[] { m.IdOrdemProducaoMateriaPrima.ToString(), e.Nome, e.Tempo, m.Produto.NomeProduto, m.Densidade.ToString(), m.PesoTotal.ToString(), m.LitrosTotal.ToString(), m.KilosTotal.ToString() };
                        dgvEtapa.Rows.Add(row);
                    }
                    
                } 

                var qualidade = p.Qualidade.ToList();
                dgvQualidade.AutoGenerateColumns = false;
                dgvQualidade.DataSource = qualidade;

                var produtos = new OrdemProducaoProdutoDAL().getListByOP(p.IdOrdemProducao).ToList();
                dgvProduto.AutoGenerateColumns = false;
                var dtgprodutos = produtos.Select(x => new { x.IdOrdemProducaoProduto, x.Produto.NomeProduto, x.Qtde }).ToList();
                dgvProduto.Rows.Clear();
                foreach (var m in dtgprodutos)
                {
                    string[] row = new string[] { m.IdOrdemProducaoProduto.ToString(), m.NomeProduto, m.Qtde.ToString() };
                    dgvProduto.Rows.Add(row);
                } 


            }
            catch(Exception ex)
            {

                 
            }
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
             
        }

        private void dgvEtapa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvEtapa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void button3_Click(object sender, EventArgs e)
        {
             
        }

        private void dgvQualidade_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void rbPrint_Click(object sender, EventArgs e)
        {
            frmCrystalReportViewer frm = new frmCrystalReportViewer("OrdemProducao");
            List<FiltroRelatorio> FiltrosRelatorio = new List<FiltroRelatorio>();
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "Id", Valor = p.IdOrdemProducao.ToString() });
            frm.FiltrosRelatorio = FiltrosRelatorio; 
            frm.ShowDialog();
        }

        private void rbImport_Click(object sender, EventArgs e)
        {
             
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
             
        }

        private void button4_Click(object sender, EventArgs e)
        {
             
        }

        private void cboCor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

