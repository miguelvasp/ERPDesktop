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
    public partial class frmUsuario : Form
    {
        private UsuarioDAL uRepository = new UsuarioDAL();
        private PermissaoDAL uPermissao = new PermissaoDAL();

        public frmUsuario()
        {
            InitializeComponent();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmUsuarioCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            var lista = uRepository.getByParams(txtNome.Text, txtLogin.Text, txtEMail.Text);

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = lista;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    if (e.ColumnIndex == 4)
                    {
                        int IdUsuarioCorrente = Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"));
                        var permissao = uPermissao.GetUsuarioAcessoFormulario("frmUsuarioPermissao", IdUsuarioCorrente);

                        if (permissao.Visualizar)
                        {
                            int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                            Usuario usu = uRepository.URepository.GetByID(id);
                            frmUsuarioPermissao cad = new frmUsuarioPermissao(usu.IdUsuario);
                            cad.ShowDialog();
                            CarregaGrid();
                        }
                        else
                        {
                            Util.Aplicacao.ShowMessage("Seu usuário não tem permissão de alterar as permissões.");
                        }
                    }
                }
            }
            catch { }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    if (e.ColumnIndex != 4)
                    {
                        int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                        Usuario usu = uRepository.URepository.GetByID(id);
                        frmUsuarioCad cad = new frmUsuarioCad(usu);
                        cad.uRepository = uRepository;
                        cad.ShowDialog();
                        CarregaGrid();
                    }
                }
            }
            catch { }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmUsuarioCad cad = new frmUsuarioCad(new Usuario());
            cad.uRepository = uRepository;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void tsbPesquisa_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = !pnlPesquisa.Visible;
            txtNome.Text = "";
            txtLogin.Text = "";
            txtEMail.Text = "";
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }
    }
}
