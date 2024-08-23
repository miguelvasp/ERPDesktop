using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
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
    public partial class frmUsuarioPermissao : RibbonForm
    {
        public int idUsuario = 0;
        private PermissaoDAL pDal = new PermissaoDAL();

        public frmUsuarioPermissao(int id)
        {
            idUsuario = id;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
            show_chkBox();
        }

        private void frmUsuarioPermissao_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles(this, btnGrava);
            CarregaDados();
        }

        private void CarregaDados()
        {
            List<UsuarioPermissao> permissao = new List<UsuarioPermissao>();
            permissao = pDal.GetListUsuarioAcesso(idUsuario);

            dgv.Rows.Clear();
            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.ReadOnly = false;
            if (permissao != null)
            {
                foreach (var item in permissao.OrderBy(x => x.DescricaoPrograma))
                {
                    dgv.Rows.Add(item.IdPermissao, item.IdUsuario, item.NomeUsuario, item.IdPerfil, item.DescricaoPerfil, item.IdPrograma, item.DescricaoPrograma, item.Visual, item.Incluir, item.Alterar, item.Excluir);
                    dgv.Columns[6].ReadOnly = true;
                    dgv.Columns[6].DefaultCellStyle.BackColor = Color.LightGray;
                }

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    foreach (var item in permissao)
                    {
                        int idPrograma = Convert.ToInt32(dgv.Rows[i].Cells[5].Value);
                        if (!item.PermiteManutencao && idPrograma == item.IdPrograma)
                        {
                            DataGridViewCell cell = dgv.Rows[i].Cells[8];
                            DataGridViewCheckBoxCell chkCell = cell as DataGridViewCheckBoxCell;
                            chkCell.Value = false;
                            chkCell.FlatStyle = FlatStyle.Flat;
                            chkCell.Style.ForeColor = Color.DarkGray;
                            cell.ReadOnly = true;

                            cell = dgv.Rows[i].Cells[9];
                            chkCell = cell as DataGridViewCheckBoxCell;
                            chkCell.Value = false;
                            chkCell.FlatStyle = FlatStyle.Flat;
                            chkCell.Style.ForeColor = Color.DarkGray;
                            cell.ReadOnly = true;

                            cell = dgv.Rows[i].Cells[10];
                            chkCell = cell as DataGridViewCheckBoxCell;
                            chkCell.Value = false;
                            chkCell.FlatStyle = FlatStyle.Flat;
                            chkCell.Style.ForeColor = Color.DarkGray;
                            cell.ReadOnly = true;

                        }

                    }
                }

                txtPerfil.Text = permissao[0].DescricaoPerfil;
                txtUsuario.Text = permissao[0].NomeUsuario;
            }
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        int idPermissao = Convert.ToInt32(dgv.Rows[i].Cells[0].Value);
                        if (idPermissao == 0)
                        {
                            Permissao up = new Permissao();
                            up.IdPermissao = 0;
                            up.IdUsuario = Convert.ToInt32(dgv.Rows[i].Cells[1].Value);
                            up.IdPerfil = Convert.ToInt32(dgv.Rows[i].Cells[3].Value);
                            up.IdPrograma = Convert.ToInt32(dgv.Rows[i].Cells[5].Value);
                            up.Visualizar = Convert.ToBoolean(dgv.Rows[i].Cells[7].EditedFormattedValue);
                            up.Incluir = Convert.ToBoolean(dgv.Rows[i].Cells[8].EditedFormattedValue);
                            up.Alterar = Convert.ToBoolean(dgv.Rows[i].Cells[9].EditedFormattedValue);
                            up.Excluir = Convert.ToBoolean(dgv.Rows[i].Cells[10].EditedFormattedValue);

                            pDal.PURepository.Insert(up);
                        }
                        else
                        {
                            var up = pDal.PURepository.GetByID(idPermissao);
                            up.Visualizar = Convert.ToBoolean(dgv.Rows[i].Cells[7].EditedFormattedValue);
                            up.Incluir = Convert.ToBoolean(dgv.Rows[i].Cells[8].EditedFormattedValue);
                            up.Alterar = Convert.ToBoolean(dgv.Rows[i].Cells[9].EditedFormattedValue);
                            up.Excluir = Convert.ToBoolean(dgv.Rows[i].Cells[10].EditedFormattedValue);

                            pDal.PURepository.Update(up);
                        }

                    }

                    pDal.Save();

                    Util.Aplicacao.ShowMessage("Permissões salvas com sucesso.");
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
            }
        }

        private void show_chkBox()
        {
            for (int ndx = 7; ndx < 11; ndx++)
            {
                var rect = dgv.GetCellDisplayRectangle(ndx, -1, true);
                var x = rect.X + 5;
                var y = 3;
                Rectangle nrect = new Rectangle(x, y, rect.Width, rect.Height);
                CheckBox checkboxHeader = new CheckBox();
                checkboxHeader.BackColor = Color.Transparent;
                checkboxHeader.Name = "checkboxHeader" + ndx;
                checkboxHeader.Size = new Size(18, 18);
                checkboxHeader.Location = nrect.Location;
                checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);
                dgv.Controls.Add(checkboxHeader);
            }
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            var headerBox = (CheckBox)sender;
            var b = headerBox.Checked;
            var c = int.Parse(headerBox.Name.Replace("checkboxHeader", ""));
            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (!dgv.Rows[i].Cells[c].ReadOnly)
                    dgv.Rows[i].Cells[c].Value = headerBox.Checked;
            }
        }
    }
}
