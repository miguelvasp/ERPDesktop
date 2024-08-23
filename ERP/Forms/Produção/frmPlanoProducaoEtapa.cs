using ERP.DAL;
using ERP.Forms.Produção;
using ERP.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPlanoProducaoEtapa : RibbonForm
    {
        public PlanoProducaoDAL dal = new PlanoProducaoDAL();
        public PlanoProducaoEtapaDAL eDal = new PlanoProducaoEtapaDAL();
        PlanoProducaoMateriaPrimaDAL mDal = new PlanoProducaoMateriaPrimaDAL();
        PlanoProducaoEtapa p = new PlanoProducaoEtapa();
        public PlanoProducao plano;
        public frmPlanoProducaoEtapa(PlanoProducaoEtapa pC, PlanoProducaoDAL pdal, PlanoProducaoEtapaDAL peDal)
        {
            this.dal = pdal;
            this.eDal = peDal;
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
             
            if (p.IdPlanoProducaoEtapa == 0)
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

       

        private void CarregaDados()
        {
            txtNome.Text = p.Nome;
            txtTempo.Text = p.Tempo;
            txtOrdem.Text = p.Ordem.ToString();
            CarregaGrid();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }



        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            p = new PlanoProducaoEtapa();
            CarregaGrid();
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
                    p.Nome = txtNome.Text;
                    p.Tempo = txtTempo.Text;
                    p.Ordem = Convert.ToInt32(txtOrdem.Text);
                    if (p.IdPlanoProducaoEtapa == 0)
                    { 
                        eDal.Insert(p);
                    }
                    else
                    {
                        eDal.Update(p);
                    }

                    eDal.Save();
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
                int id = p.IdPlanoProducaoEtapa;
                mDal.apagaMateriais(id);
                dal.Delete(id);
                dal.Save();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (p.IdPlanoProducao == 0)
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
                var lista = new PlanoProducaoMateriaPrimaDAL().getByEtapa(p.IdPlanoProducaoEtapa);
                var mat = lista.Select(x => new
                {
                    Id = x.IdPlanoProducaoMateriaPrima,
                    Codigo = x.Produto.Codigo,
                    Nome = x.Produto.NomeProduto,
                    Densidade = x.Densidade,
                    Volume = x.Volume,
                    Peso = x.Peso,
                    PesoTotal = x.PesoTotal,
                    VolumeTotal = x.VolumeTotal
                }).ToList();
                dgvMat.AutoGenerateColumns = false;
                dgvMat.DataSource = mat;
            }
            catch (Exception ex)
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
            if(p.IdPlanoProducaoEtapa == 0)
            {
                Util.Aplicacao.ShowMessage("Salve as informações da etapa antes de cadastrar os materiais");
                return;
            }
            PlanoProducaoMateriaPrima mp = new PlanoProducaoMateriaPrima();
            mp.IdPlanoProducao = plano.IdPlanoProducao;
            mp.IdPlanoProducaoEtapa = p.IdPlanoProducaoEtapa;
            frmPlanoProducaoMaterial frmm = new frmPlanoProducaoMaterial(mDal, plano, mp);
            frmm.ShowDialog();
            CarregaGrid();
        }

        private void dgvMat_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvMat.Rows[e.RowIndex].Cells[0].Value);
                var mp = mDal.GetByID(id);
                frmPlanoProducaoMaterial frmm = new frmPlanoProducaoMaterial(mDal, plano, mp);
                frmm.ShowDialog();
                CarregaGrid();
            }
            catch  
            {
                 
            }
        }
    }
}

