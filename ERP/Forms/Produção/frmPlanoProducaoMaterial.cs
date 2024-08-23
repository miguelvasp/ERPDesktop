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

namespace ERP.Forms.Produção
{
    public partial class frmPlanoProducaoMaterial : Form
    {
        PlanoProducaoMateriaPrimaDAL mDal = new PlanoProducaoMateriaPrimaDAL();
        PlanoProducao p = new PlanoProducao();
        PlanoProducaoMateriaPrima mp = new PlanoProducaoMateriaPrima();
        public frmPlanoProducaoMaterial(PlanoProducaoMateriaPrimaDAL pmDal, PlanoProducao pP, PlanoProducaoMateriaPrima mp)
        {
            p = pP;
            mDal = pmDal;
            this.mp = mp;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Util.Validacao.ValidaCampos(this))
                {
                    
                        mp.IdProduto = Convert.ToInt32(cboMaterial.SelectedValue);
                        mp.Densidade = Convert.ToDecimal(txtDensidade.Text);
                        //mp.Volume = Convert.ToDecimal(txtVolume.Text);
                        mp.Peso = Convert.ToDecimal(txtPeso.Text);
                        if (mp.IdPlanoProducaoMateriaPrima == 0)
                        {
                            mDal.Insert(mp);
                            
                        }
                        else
                        {
                            mDal.Update(mp);
                        }
                        mDal.Save();
                        mDal.CalcularMateriais(p.IdPlanoProducao);
                        this.Close();
                    
                }
                else
                {
                    Util.Aplicacao.ShowMessage("Verifique as informações");
                }
            }
            catch(Exception ex)
            {
                Util.Aplicacao.ShowMessage("Verifique as informações " + ex.Message);
            } 
        }

        private void frmPlanoProducaoMaterial_Load(object sender, EventArgs e)
        {
            var lista = new ProdutoDAL().GetComboMateriaPrima();
            cboMaterial.DataSource = lista;
            cboMaterial.DisplayMember = "Text";
            cboMaterial.ValueMember = "iValue";
            cboMaterial.SelectedIndex = -1;

            if(mp.IdPlanoProducaoMateriaPrima > 0)
            {
                cboMaterial.SelectedValue = mp.IdProduto;
                txtDensidade.Text = mp.Densidade.ToString();
                txtPeso.Text = mp.Peso.ToString();
                button2.Visible = true;
            }
            else
            {
                button2.Visible = false;
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja apagar o material na etapa de produção?") == DialogResult.Yes)
            {
                mDal.Delete(mp.IdPlanoProducaoMateriaPrima);
                mDal.Save();
                mDal.CalcularMateriais(p.IdPlanoProducao);
                this.Close();
            }
        }
    }
}
