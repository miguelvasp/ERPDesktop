using ERP.DAL;
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

namespace ERP
{
    public partial class frmFavoritos : Form
    {
        int idUsuario;
        List<string> FavoritosLista = new List<string>();
        FavoritosDAL dal = new FavoritosDAL();
        List<ComboItem> Grupos = new List<ComboItem>();
        
        public frmFavoritos(int pIdUsuario)
        {
            this.idUsuario = pIdUsuario;
            InitializeComponent();
        }


        private void MontaFavoritos()
        {
            List<Favoritos> Favoritos = dal.getByUsuario(idUsuario);
            treeView1.Nodes.Clear();

            List<TreeNode> treeNodes = new List<TreeNode>();
            List<TreeNode> Forms = new List<TreeNode>();
            List<TreeNode> Reports = new List<TreeNode>();
           

            //adiciona os forms
            foreach (Favoritos f in Favoritos.Where(x => x.Grupo == "Forms").OrderBy(x => x.Nome).ToList())
            {
                TreeNode t = new TreeNode();
                t.Text = f.Nome;
                t.Tag = f.Form;
                t.ImageIndex = 0;
                t.SelectedImageIndex = 0;
             
                Forms.Add(t);
                //adiciona a lista de programas
                FavoritosLista.Add(f.Form);

            }
            treeNodes.Add(new TreeNode("Formulários", 0, 0, Forms.ToArray()));

            foreach (Favoritos f in Favoritos.Where(x => x.Grupo == "Reports").OrderBy(x => x.Nome).ToList())
            {
                TreeNode t = new TreeNode();
                t.Text = f.Nome;
                t.Tag = f.Form;
                t.ImageIndex = 1;
                t.SelectedImageIndex = 1; 
                Reports.Add(t);
                //adiciona a lista de programas
                FavoritosLista.Add(f.Form);
            }
            treeNodes.Add(new TreeNode("Relatórios", 1, 1, Reports.ToArray()));

            treeView1.Nodes.AddRange(treeNodes.ToArray());
            treeView1.ExpandAll();



            //carrega o combo com os programas que ainda estão disponiveis conforme as permissões
            var Programas = new ProgramaDAL().GetByUserIdFavorito(idUsuario, FavoritosLista).ToList();
            cboFavoritos.DataSource = Programas;
            cboFavoritos.ValueMember = "Formulario";
            cboFavoritos.DisplayMember = "Nome";
            cboFavoritos.SelectedIndex = -1;

            cboGrupo.SelectedIndex = -1;
            Grupos.Clear();
            Grupos.Add(new ComboItem() { Text = "Formulários", Value = "Forms" });
            Grupos.Add(new ComboItem() { Text = "Relatorios", Value = "Reports" });
            cboGrupo.DataSource = Grupos;
            cboGrupo.DisplayMember = "Text";
            cboGrupo.ValueMember = "Value";
            cboGrupo.SelectedIndex = -1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(cboGrupo.Text) || !String.IsNullOrEmpty(cboGrupo.Text))
            {
                Favoritos f = new Favoritos();
                f.IdUsuario = idUsuario;
                f.Nome = cboFavoritos.Text;
                f.Form = cboFavoritos.SelectedValue.ToString();
                f.Grupo = cboGrupo.SelectedValue.ToString();
                dal.Insert(f);
                dal.Save();
                MontaFavoritos();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string form = treeView1.SelectedNode.Tag.ToString();
            Favoritos f = dal.getByUsuario(idUsuario).Where(x => x.Form == form).FirstOrDefault();
            if(f != null)
            {
                dal.Delete(f.IdFavorito);
                dal.Save();
                MontaFavoritos();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFavoritos_Load(object sender, EventArgs e)
        {
            MontaFavoritos();
        }
    }
}
