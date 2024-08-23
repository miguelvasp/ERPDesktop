using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmLancamentoCad : Form
    {
        public LancamentoDAL dal;
        TipoLancamentoDAL tplDal = new TipoLancamentoDAL();
        Lancamento lanc = new Lancamento();
        int idTipoLancamento = 1;
        int idTipoDocumento = 1;

        public frmLancamentoCad(Lancamento pLanc)
        {
            lanc = pLanc;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void frmLancamentoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarTipoLancamento();

            if (lanc != null)
            {
                TipoLancamento tl = tplDal.GetByID(lanc.IdTipoLancamento);
                if (tl != null)
                {
                    int tpDocumento = tl.IdTipoDocumento;
                    if (tpDocumento == 1)
                    {
                        TabPage t = tbcLancamento.TabPages[0];
                        tbcLancamento.SelectedTab = t;

                        foreach (var item in grbVendas.Controls)
                        {
                            if (item is System.Windows.Forms.RadioButton)
                            {
                                if (((System.Windows.Forms.RadioButton)item).Tag.ToString() == lanc.IdTipoLancamento.ToString())
                                {
                                    ((System.Windows.Forms.RadioButton)(item)).Checked = false;
                                    ((System.Windows.Forms.RadioButton)(item)).Checked = true;
                                    break;
                                }
                            }
                        }
                    }
                    else if (tpDocumento == 2)
                    {
                        TabPage t = tbcLancamento.TabPages[1];
                        tbcLancamento.SelectedTab = t;

                        foreach (var item in grbCompras.Controls)
                        {
                            if (item is System.Windows.Forms.RadioButton)
                            {
                                if (((System.Windows.Forms.RadioButton)item).Tag.ToString() == lanc.IdTipoLancamento.ToString())
                                {
                                    ((System.Windows.Forms.RadioButton)(item)).Checked = false;
                                    ((System.Windows.Forms.RadioButton)(item)).Checked = true;
                                    break;
                                }
                            }
                        }
                    }
                    else if (tpDocumento == 3)
                    {
                        TabPage t = tbcLancamento.TabPages[2];
                        tbcLancamento.SelectedTab = t;

                        foreach (var item in grbEstoque.Controls)
                        {
                            if (item is System.Windows.Forms.RadioButton)
                            {
                                if (((System.Windows.Forms.RadioButton)item).Tag.ToString() == lanc.IdTipoLancamento.ToString())
                                {
                                    ((System.Windows.Forms.RadioButton)(item)).Checked = false;
                                    ((System.Windows.Forms.RadioButton)(item)).Checked = true;
                                    break;
                                }
                            }
                        }
                    }
                    else if (tpDocumento == 4)
                    {
                        TabPage t = tbcLancamento.TabPages[3];
                        tbcLancamento.SelectedTab = t;

                        foreach (var item in grbProducao.Controls)
                        {
                            if (item is System.Windows.Forms.RadioButton)
                            {
                                if (((System.Windows.Forms.RadioButton)item).Tag.ToString() == lanc.IdTipoLancamento.ToString())
                                {
                                    ((System.Windows.Forms.RadioButton)(item)).Checked = false;
                                    ((System.Windows.Forms.RadioButton)(item)).Checked = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            CarregarLancamento(idTipoLancamento, idTipoDocumento);

            Cursor.Current = Cursors.Default;
        }

        private void frmLancamentoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            if (r.Checked == true)
            {
                string value = r.Tag.ToString();
                idTipoLancamento = Convert.ToInt32(value);
                CarregarLancamento(idTipoLancamento, idTipoDocumento);
            }
        }

        private void tbcLancamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcLancamento.SelectedTab == tbcLancamento.TabPages["tbpVendas"])//your specific tabname
            {
                idTipoDocumento = 1;
                ((System.Windows.Forms.RadioButton)(grbVendas.Controls[0])).Checked = false;
                ((System.Windows.Forms.RadioButton)(grbVendas.Controls[0])).Checked = true;
            }
            else if (tbcLancamento.SelectedTab == tbcLancamento.TabPages["tbpCompras"])//your specific tabname
            {
                idTipoDocumento = 2;
                ((System.Windows.Forms.RadioButton)(grbCompras.Controls[0])).Checked = false;
                ((System.Windows.Forms.RadioButton)(grbCompras.Controls[0])).Checked = true;
            }
            else if (tbcLancamento.SelectedTab == tbcLancamento.TabPages["tbpEstoque"])//your specific tabname
            {
                idTipoDocumento = 3;
                ((System.Windows.Forms.RadioButton)(grbEstoque.Controls[0])).Checked = false;
                ((System.Windows.Forms.RadioButton)(grbEstoque.Controls[0])).Checked = true;
            }
            else if (tbcLancamento.SelectedTab == tbcLancamento.TabPages["tbpProducao"])//your specific tabname
            {
                idTipoDocumento = 4;
                ((System.Windows.Forms.RadioButton)(grbProducao.Controls[0])).Checked = false;
                ((System.Windows.Forms.RadioButton)(grbProducao.Controls[0])).Checked = true;
            }
        }

        private void CarregarLancamento(int idTipoLancamento, int idTipoDocumento)
        {
            var lista = dal.getByTipoLancamento(idTipoLancamento);

            if (idTipoDocumento == 1)
            {
                dgvVendas.AutoGenerateColumns = false;
                dgvVendas.RowHeadersVisible = false;
                dgvVendas.DataSource = lista;
            }
            else if (idTipoDocumento == 2)
            {
                dgvCompras.AutoGenerateColumns = false;
                dgvCompras.RowHeadersVisible = false;
                dgvCompras.DataSource = lista;
            }
            else if (idTipoDocumento == 3)
            {
                dgvEstoque.AutoGenerateColumns = false;
                dgvEstoque.RowHeadersVisible = false;
                dgvEstoque.DataSource = lista;
            }
            else if (idTipoDocumento == 4)
            {
                dgvProducao.AutoGenerateColumns = false;
                dgvProducao.RowHeadersVisible = false;
                dgvProducao.DataSource = lista;
            }
        }

        private void CarregarTipoLancamento()
        {
            List<TipoLancamento> tpl = tplDal.Get().OrderBy(o => o.IdTipoDocumento).ToList();

            int loc = 20;
            int tl = 0;
            foreach (TipoLancamento it in tpl)
            {
                RadioButton rb = new RadioButton();

                if (tl != it.IdTipoDocumento)
                {
                    tl = it.IdTipoDocumento;
                    loc = 20;
                    rb.Checked = true;
                }

                rb.Text = it.Descricao;
                rb.Width = 250;
                rb.Location = new Point(20, loc);
                rb.Tag = it.IdTipoLancamento;
                rb.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
                loc = loc + 20;
                switch (it.IdTipoDocumento)
                {
                    case 1:
                        grbVendas.Controls.Add(rb);
                        break;
                    case 2:
                        grbCompras.Controls.Add(rb);
                        break;
                    case 3:
                        grbEstoque.Controls.Add(rb);
                        break;
                    case 4:
                        grbProducao.Controls.Add(rb);
                        break;
                }
            }
        }

        private void ChamarTelaCadastroItem(int tipoDocumento)
        {
            frmLancamentoCadItem cad = new frmLancamentoCadItem(new Lancamento(), tipoDocumento);
            cad.dal = dal;
            cad.idTipoLancamento = idTipoLancamento;
            cad.ShowDialog();
            CarregarLancamento(idTipoLancamento, tipoDocumento);
        }

        private void btnAdicionarVendas_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastroItem(1);
        }

        private void dgvVendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvVendas.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgvVendas.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Lancamento lcm = dal.GetByID(id);
                    frmLancamentoCadItem cad = new frmLancamentoCadItem(lcm, 1);
                    cad.dal = dal;
                    cad.idTipoLancamento = idTipoLancamento;
                    cad.ShowDialog();
                    CarregarLancamento(idTipoLancamento, 1);
                }
            }
            catch { }
        }

        private void btnAdicionarCompras_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastroItem(2);
        }

        private void dgvCompras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCompras.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgvCompras.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Lancamento lcm = dal.GetByID(id);
                    frmLancamentoCadItem cad = new frmLancamentoCadItem(lcm, 2);
                    cad.dal = dal;
                    cad.idTipoLancamento = idTipoLancamento;
                    cad.ShowDialog();
                    CarregarLancamento(idTipoLancamento, 2);
                }
            }
            catch { }
        }

        private void btnAdicionarEstoque_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastroItem(3);
        }

        private void dgvEstoque_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvEstoque.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgvEstoque.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Lancamento lcm = dal.GetByID(id);
                    frmLancamentoCadItem cad = new frmLancamentoCadItem(lcm, 3);
                    cad.dal = dal;
                    cad.idTipoLancamento = idTipoLancamento;
                    cad.ShowDialog();
                    CarregarLancamento(idTipoLancamento, 3);
                }
            }
            catch { }
        }

        private void btnAdicionarProducao_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastroItem(4);
        }

        private void dgvProducao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProducao.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgvProducao.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Lancamento lcm = dal.GetByID(id);
                    frmLancamentoCadItem cad = new frmLancamentoCadItem(lcm, 4);
                    cad.dal = dal;
                    cad.idTipoLancamento = idTipoLancamento;
                    cad.ShowDialog();
                    CarregarLancamento(idTipoLancamento, 4);
                }
            }
            catch { }
        }
    }
}