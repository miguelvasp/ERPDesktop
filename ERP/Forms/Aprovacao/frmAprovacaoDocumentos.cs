using ERP.Models;
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
using ERP.ModelView;

namespace ERP.Aprovacao
{
    public partial class frmAprovacaoDocumentos : Form
    {
        //List<MultiComboItem> listaUsuarios = new List<MultiComboItem>();
        List<AprovacaoUsuarioModelView> listaUsuarios = new List<AprovacaoUsuarioModelView>();


        AprovacaoDocumentoDAL aDal = new AprovacaoDocumentoDAL();
        AprovacaoNivelDAL nDal = new AprovacaoNivelDAL();
        AprovacaoUsuarioDAL uDal = new AprovacaoUsuarioDAL();

        AprovacaoDocumento ad = new AprovacaoDocumento();
        AprovacaoNivel an = new AprovacaoNivel();

        public frmAprovacaoDocumentos()
        {
            InitializeComponent();
        }

        private void CarregaNiveis()
        {
            dgNiveis.AutoGenerateColumns = false;
            dgNiveis.DataSource = nDal.GetByDocumentoId(ad.IdAprovacaoDocumento);
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //frmCombo combo = new frmCombo(listaUsuarios);
            //combo.Parent = this;
            //combo.Top = this.Top + cboUsuarios.Top;
            //combo.Left = this.Left + cboUsuarios.Left;
            //combo.ShowDialog();
            //if (!String.IsNullOrEmpty(combo.Id))
            //{
            //    cboUsuarios.SelectedValue = Convert.ToInt32(combo.Id);
            //}
        }

        private void frmAprovacaoDocumentos_Load(object sender, EventArgs e)
        {
            pnlDoc.Dock = DockStyle.Fill;
            pnlNivel.Visible = false;
            //listaUsuarios = new UsuarioDAL().GetMultiCombo();
            cboDocs.DataSource = aDal.Get().Select(x => new { x.IdAprovacaoDocumento, x.Nome}).ToList();
            cboDocs.DisplayMember = "Nome";
            cboDocs.ValueMember = "IdAprovacaoDocumento";
            cboDocs.SelectedIndex = -1;

            cboUsuarios.DataSource = new UsuarioDAL().GetMultiCombo();
            cboUsuarios.DisplayMember = "Text2";
            cboUsuarios.ValueMember = "iValue";
            cboUsuarios.SelectedIndex = -1;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboDocs.Text))
            {
                int id = Convert.ToInt32(cboDocs.SelectedValue.ToString());
                ad = aDal.GetByID(id);
                CarregaNiveis();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtNivel.Text = "";
            txtSequencia.Text = "";
            pnlDoc.Visible = false;
            pnlNivel.Dock = DockStyle.Fill;
            pnlNivel.Visible = true;
            an = new AprovacaoNivel();
            an.IdAprovacaoDocumento = ad.IdAprovacaoDocumento;
            pnlAddUsuario.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(cboUsuarios.Text))
            {
                var item = listaUsuarios.Where(x => x.NomeCompleto == cboUsuarios.Text).FirstOrDefault();
                if (item != null) return;

                AprovacaoUsuario au = new AprovacaoUsuario();
                au.IdAprovacaoNivel = an.IdAprovacaoNivel;
                au.IdUsuario = Convert.ToInt32(cboUsuarios.SelectedValue.ToString());
                uDal.Insert(au);
                uDal.Save();
                CarregaUsuariosNivel();
                cboUsuarios.SelectedIndex = -1;
            }
            
        }

        private void CarregaUsuariosNivel()
        {
            listaUsuarios = uDal.GetByNivel(Convert.ToInt32(an.IdAprovacaoNivel));
            var ListaUsuario = listaUsuarios;
            dgUsuarios.AutoGenerateColumns = false;
            dgUsuarios.DataSource = listaUsuarios;
            
        }

        private void dgNiveis_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgNiveis.Rows[dgNiveis.SelectedRows[0].Index].Cells[0].Value);
            an = nDal.GetByID(id);
            txtNivel.Text = an.Nome;
            txtSequencia.Text = an.Sequencia.ToString();
            CarregaUsuariosNivel();
            pnlDoc.Visible = false;
            pnlNivel.Dock = DockStyle.Fill;
            pnlNivel.Visible = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            pnlNivel.Visible = false;
            pnlDoc.Visible = true;
            cboUsuarios.SelectedIndex = -1;
            CarregaNiveis();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if(Util.Aplicacao.ShowQuestionMessage("Deseja apagar o usuário do grupo de aprovadores?") == System.Windows.Forms.DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgUsuarios.Rows[dgUsuarios.SelectedRows[0].Index].Cells[0].Value); 
                uDal.Delete(id);
                uDal.Save();
                CarregaUsuariosNivel();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja apagar nivel de aprovaçao?") == System.Windows.Forms.DialogResult.Yes)
            {
                foreach(var i in listaUsuarios)
                {
                    uDal.Delete(Convert.ToInt32(i.IdAprovacaoUsuario));
                    uDal.Save();
                }

                nDal.Delete(Convert.ToInt32(an.IdAprovacaoNivel));
                nDal.Save();
                pnlDoc.Visible = true;
                pnlNivel.Visible = false;
                CarregaNiveis();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(txtSequencia.Text == "" || txtNivel.Text == "")
            {
                Util.Aplicacao.ShowMessage("Preencha todas as informações.");
                return;
            }

            try
            {
                an.Nome = txtNivel.Text;
                an.Sequencia = Convert.ToInt32(txtSequencia.Text);
                if (an.IdAprovacaoNivel == 0 || an.IdAprovacaoNivel == null)
                {
                    nDal.Insert(an);
                }
                else
                {
                    nDal.Update(an);
                }
                nDal.Save();
                pnlAddUsuario.Enabled = true;
            }
            catch
            {
                Util.Aplicacao.ShowMessage("Verifique as informações.");
            } 
        }
    }
}
