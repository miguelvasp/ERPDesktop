﻿using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoImpostoRetidoItem : Form
    {
        GrupoImpostoRetidoItemDAL dal = new GrupoImpostoRetidoItemDAL();

        public frmGrupoImpostoRetidoItem()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmGrupoImpostoRetidoItemCad cad = new frmGrupoImpostoRetidoItemCad(new GrupoImpostoRetidoItem());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmGrupoImpostoRetido_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmGrupoImpostoRetidoItemCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtCodigo.Text, txtDescricao.Text).Select(x => new { x.IdGrupoImpostoRetidoItem, x.Codigo, x.Descricao }).ToList();

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, "GrupoImpostoRetidoItem.csv");
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    GrupoImpostoRetidoItem gir = dal.GetByID(id);
                    frmGrupoImpostoRetidoItemCad cad = new frmGrupoImpostoRetidoItemCad(gir);
                    cad.dal = dal;
                    cad.ShowDialog();
                    CarregaGrid();
                }
            }
            catch { }
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void tsbPesquisa_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = !pnlPesquisa.Visible;
            txtCodigo.Text = "";
            txtDescricao.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.getByParams(txtCodigo.Text, txtDescricao.Text);

            var rel = (from g in lst
                       select new
                       {
                           Id = g.IdGrupoImpostoRetidoItem,
                           Código = g.Codigo,
                           Descrição = g.Descricao 
                       }).OrderBy(o => o.Código).ToList();

            DataTable dt = Util.Aplicacao.LINQToDataTable(rel);

            if (dt.Rows.Count > 0)
            {
                ERP.Relatorios.frmRelatorioGenerico frm = new ERP.Relatorios.frmRelatorioGenerico(dt);
                frm.ShowDialog();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Não existe dados para gerar o relatório!");
            }
        }
    }
}
