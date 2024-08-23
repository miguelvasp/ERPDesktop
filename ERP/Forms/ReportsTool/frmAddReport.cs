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

namespace ERP.Forms.ReportsTool
{
    public partial class frmAddReport : Form
    {
        ReportCuboDAL rcDal = new ReportCuboDAL();
        ReportHeaderDAL dal = new ReportHeaderDAL();
        ReportFieldsDAL idal = new ReportFieldsDAL();
        ReportCubo Origem = new ReportCubo();
        ReportHeader r = new ReportHeader();
        List<ReportFields> Campos = new List<ReportFields>();
        int Id = 0;

        public frmAddReport(int pId = 0)
        {
            Id = pId;
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        btnAnterior.Enabled = false;
                        btnProximo.Enabled = true;
                        btnFinalizar.Enabled = false;
                    }break;
                case 1:
                    {
                        btnAnterior.Enabled = true;
                        btnProximo.Enabled = true;
                        btnFinalizar.Enabled = false;
                    }
                    break;
                case 2:
                    {
                        btnAnterior.Enabled = true;
                        btnProximo.Enabled = true;
                        btnFinalizar.Enabled = false;
                    }
                    break;
                case 3:
                    {
                        btnAnterior.Enabled = true;
                        btnProximo.Enabled = false;
                        btnFinalizar.Enabled = true;
                    }
                    break;
            }
        }

        private void CarregaGrupos()
        {
            //Carrega campos Selecionados
            var CamposDisponiveis = Origem.Campos.ToList();
            lstCampos.Items.Clear();
            lstCampos2.Items.Clear();
            lstCampos3.Items.Clear();
            lstAgrupamento.Items.Clear();
            lstFiltros.Items.Clear();

            lstFiltros.DisplayMember = "Text";
            lstFiltros.ValueMember = "iValue";

            foreach (var i in Campos)
            {
                var c = CamposDisponiveis.Where(x => x.IdReportCuboFields == i.IdReportCuboFields).FirstOrDefault();
                if(c != null)
                {
                    lstCampos.Items.Add(c.Titulo);
                    lstCampos2.Items.Add(c.Titulo);
                    lstCampos3.Items.Add(c.Titulo);
                }
            }


            //Adiciona os itens de agrupamento
            foreach (var y in Campos.Where(x => x.Agrupamento == true).OrderBy(x => x.AgrupamentoOrdem).ToList())
            {
                var c = CamposDisponiveis.Where(x => x.IdReportCuboFields == y.IdReportCuboFields).FirstOrDefault();
                if (c != null)
                {
                    lstAgrupamento.Items.Add(c.Titulo); 
                }
            }

            //Adiciona os itens de filtros
            foreach (var z in Campos.Where(x => !string.IsNullOrEmpty(x.Filtro)).ToList())
            {
                var c = CamposDisponiveis.Where(x => x.IdReportCuboFields == z.IdReportCuboFields).FirstOrDefault();
                if (c != null)
                {

                    string a = "";
                    //um campo pode ter mais de um filtro, eles sao agrupados separados por pornto e virgula
                    string[] filtros = z.Filtro.Split(';');
                    foreach(var s in filtros)
                    {
                        if(!string.IsNullOrEmpty(s))
                        {
                            switch (s)
                            {
                                case ">": a = $"{c.Titulo} - Forma de pesquisa: maior que (>)"; break;
                                case ">=": a = $"{c.Titulo} - Forma de pesquisa: maior ou igual que (>=)"; break;
                                case "=": a = $"{c.Titulo} - Forma de pesquisa: igual que (=)"; break;
                                case "<": a = $"{c.Titulo} - Forma de pesquisa: menor que (<)"; break;
                                case "<=": a = $"{c.Titulo} - Forma de pesquisa: menor ou igual que (<=)"; break;
                                case "<>": a = $"{c.Titulo} - Forma de pesquisa: diferente de (<>)"; break;
                            }
                            if (!string.IsNullOrEmpty(a))
                            {
                                ComboItem com = new ComboItem();
                                com.iValue = c.IdReportCuboFields;
                                com.Value = s;
                                com.Text = a;
                                lstFiltros.Items.Add(com); 
                            }
                        } 
                    } 
                }
            }


            //Recarrega o grid
            Origem = rcDal.GetByID(Convert.ToInt32(cboOrigem.SelectedValue));
            dgvFields.AutoGenerateColumns = false;
            var listaCamposSelecionados = Campos.Select(x => x.IdReportCuboFields).ToList();
            dgvFields.DataSource = Origem.Campos.Where(x => !listaCamposSelecionados.Contains(x.IdReportCuboFields)).ToList();
        }

        private void frmAddReport_Load(object sender, EventArgs e)
        {
            cboOrigem.DataSource = rcDal.getCombo();
            cboOrigem.DisplayMember = "Text";
            cboOrigem.ValueMember = "iValue";
            cboOrigem.SelectedIndex = -1;

            if(Id > 0)
            {
                r = dal.GetByID(Id);
                Campos = idal.getByReportId(Id);
                cboOrigem.SelectedValue = r.IdRepCubo;
                txtNome.Text = r.Nome;
                Origem = rcDal.GetByID(Convert.ToInt32(r.IdRepCubo));
                dgvFields.AutoGenerateColumns = false;
                dgvFields.DataSource = Origem.Campos.ToList();

                CarregaGrupos();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboOrigem.Text))
            {
                Util.Aplicacao.ShowMessage("Selecione a origem dos dados!");
                return;
            }

            Origem = rcDal.GetByID(Convert.ToInt32(cboOrigem.SelectedValue));
            dgvFields.AutoGenerateColumns = false;
            dgvFields.DataSource = Origem.Campos.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(dgvFields.Rows.Count == 0)
            {
                return;
            }
            int id = Convert.ToInt32(dgvFields.Rows[dgvFields.SelectedRows[0].Index].Cells[0].Value);
            if(Campos.Where(x => x.IdReportCuboFields == id).Count() == 0)
            {
                Campos.Add(new ReportFields() { IdReportCuboFields = id, Filtro = "" });
                CarregaGrupos();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach(var i in Origem.Campos.ToList())
            {
                int id = i.IdReportCuboFields;
                if (Campos.Where(x => x.IdReportCuboFields == id).Count() == 0)
                {
                    Campos.Add(new ReportFields() { IdReportCuboFields = id, Filtro = "" }); 
                } 
            }
            CarregaGrupos();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Campos.Clear();
            CarregaGrupos();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                var CamposDisponiveis = Origem.Campos.ToList();
                string s = lstCampos.SelectedItems[0].ToString();
                var i = CamposDisponiveis.Where(x => x.Titulo == s).FirstOrDefault();
                var campo = Campos.Where(x => x.IdReportCuboFields == i.IdReportCuboFields).FirstOrDefault();
                Campos.Remove(campo);
                CarregaGrupos();
            }
            catch
            {
                
            } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var CamposDisponiveis = Origem.Campos.ToList();
                string s = lstCampos2.SelectedItems[0].ToString();
                var i = CamposDisponiveis.Where(x => x.Titulo == s).FirstOrDefault();
                var campo = Campos.Where(x => x.IdReportCuboFields == i.IdReportCuboFields).FirstOrDefault();
                campo.Agrupamento = true;
                campo.AgrupamentoOrdem = Campos.Where(x => x.Agrupamento == true).Max(x => x.AgrupamentoOrdem) + 10;
                CarregaGrupos();
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var CamposDisponiveis = Origem.Campos.ToList();
                string s = lstAgrupamento.SelectedItems[0].ToString();
                var i = CamposDisponiveis.Where(x => x.Titulo == s).FirstOrDefault();
                var campo = Campos.Where(x => x.IdReportCuboFields == i.IdReportCuboFields).FirstOrDefault();
                campo.Agrupamento = false;
                campo.AgrupamentoOrdem = null;
                CarregaGrupos();
            }
            catch
            {

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                var CamposDisponiveis = Origem.Campos.ToList();
                string s = lstCampos3.SelectedItems[0].ToString();
                var i = CamposDisponiveis.Where(x => x.Titulo == s).FirstOrDefault();
                var campo = Campos.Where(x => x.IdReportCuboFields == i.IdReportCuboFields).FirstOrDefault();
                frmAddFiltro frmad = new frmAddFiltro();
                frmad.ShowDialog();
                string str = frmad.comboBox1.SelectedValue.ToString();
                campo.Filtro += str + ";";
                CarregaGrupos();
            }
            catch
            {

            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = tabControl1.SelectedIndex - 1;
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(Util.Aplicacao.ShowQuestionMessage("Deseja cancelar as alterãções efetuadas?") == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            //verificar os campos
            if(string.IsNullOrEmpty(txtNome.Text))
            {
                Util.Aplicacao.ShowMessage("Informe o nome do relatório!");
                return;
            }

            if (string.IsNullOrEmpty(cboOrigem.Text))
            {
                Util.Aplicacao.ShowMessage("Informe a origem dos dados!");
                return;
            }

            if (Campos.Count == 0)
            {
                Util.Aplicacao.ShowMessage("Selecione os campos do relatório!");
                return;
            }

            if (Campos.Where(x => !string.IsNullOrEmpty(x.Filtro)).Count() == 0)
            {
                Util.Aplicacao.ShowMessage("Informe os filtros do relatório!");
                return;
            }

            r.IdRepCubo = Convert.ToInt32(cboOrigem.SelectedValue);
            r.Nome = txtNome.Text;

            if(r.IdReportHeader == 0)
            {
                dal.Insert(r);
            }
            else
            {
                dal.Update(r);
            }
            dal.Save();

            idal.DeleteByReportId(r.IdReportHeader);

            foreach(var i in Campos)
            {
                i.IdReportHeader = r.IdReportHeader;
                idal.Insert(i);
                idal.Save();
            }

            Util.Aplicacao.ShowMessage("Dados salvos com sucesso");
            this.Close();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                var CamposDisponiveis = Origem.Campos.ToList();
                ComboItem ci = (ComboItem)lstFiltros.SelectedItems[0]; 
                var i = CamposDisponiveis.Where(x => x.IdReportCuboFields == ci.iValue).FirstOrDefault();
                var campo = Campos.Where(x => x.IdReportCuboFields == i.IdReportCuboFields).FirstOrDefault();
                campo.Filtro = campo.Filtro.Replace(ci.Value, "");
                CarregaGrupos();
            }
            catch
            {

            }
        }
    }
}