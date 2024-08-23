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
    public partial class frmPlanoProducaoControleQualidade : Form
    {
        PlanoProducaoControleQualidadeDAL qDal = new PlanoProducaoControleQualidadeDAL();
        PlanoProducao p = new PlanoProducao();
        PlanoProducaoControleQualidade mp = new PlanoProducaoControleQualidade();
        public frmPlanoProducaoControleQualidade(PlanoProducaoControleQualidadeDAL pmDal, PlanoProducao pP, PlanoProducaoControleQualidade mp)
        {
            p = pP;
            qDal = pmDal;
            this.mp = mp;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Util.Validacao.ValidaCampos(this))
                {
                    if (Util.Aplicacao.ShowQuestionMessage("Deseja adicionar o item de controle de qualidade na produção?") == DialogResult.Yes)
                    {
                        mp.Descricao = txtDescricao.Text;
                        mp.Aspecto = txtVisual.Text; 
                        if (mp.IdPlanoProducaoControleQualidade == 0)
                        {
                            qDal.Insert(mp);
                            
                        }
                        else
                        {
                            qDal.Update(mp);
                        }
                        qDal.Save();
                        this.Close();
                    }
                }
                else
                {
                    Util.Aplicacao.ShowMessage("Verifique as informações");
                }
            }
            catch
            {
                Util.Aplicacao.ShowMessage("Verifique as informações");
            } 
        }

        private void frmPlanoProducaoMaterial_Load(object sender, EventArgs e)
        { 

            if(mp.IdPlanoProducaoControleQualidade > 0)
            {
                txtDescricao.Text = mp.Descricao;
                txtVisual.Text = mp.Aspecto;
                button2.Visible = true;
            }
            else
            {
                button2.Visible = false;
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja apagar o item de controle de qualidade?") == DialogResult.Yes)
            {
                qDal.Delete(mp.IdPlanoProducaoControleQualidade);
                qDal.Save();
                this.Close();
            }
        }
    }
}
