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
    public partial class frmListaMateriaisCad : RibbonForm
    {
        public ListaMateriaisDAL dal = new ListaMateriaisDAL();
        ListaMateriaisItemDAL iDal = new ListaMateriaisItemDAL();
        ListaMateriais l = new ListaMateriais();

        public frmListaMateriaisCad(ListaMateriais li)
        {
            l = li;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmGrupoImpostosCad_Load(object sender, EventArgs e)
        {
            CarregaCombos();
            if (l.IdListaMateriais == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        

        private void CarregaGrid()
        {
            var lista = iDal.GetByLista(l.IdListaMateriais);
            dgCodigos.AutoGenerateColumns = false;
            dgCodigos.DataSource = lista;
        }

        private void CarregaDados()
        {
            txtNome.Text = l.Nome;
            chkAprovado.Checked = l.Aprovado;
            txtAprovador.Text = l.NomeAprovador;
            cboTipo.SelectedValue = l.Bom_Formula == null ? 0 : Convert.ToInt32(l.Bom_Formula);
            cboArmazem.SelectedValue = l.IdArmazem == null ? 0 : Convert.ToInt32(l.IdArmazem);
            cboGrupoLancamento.SelectedValue = l.IdGrupoLancamento == null ? 0 : Convert.ToInt32(l.IdGrupoLancamento);
            CarregaGrid();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            l = new ListaMateriais(); 
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
                    l.Nome = txtNome.Text;
                    l.Aprovado = chkAprovado.Checked;
                    if (chkAprovado.Checked && String.IsNullOrEmpty(l.NomeAprovador))
                    {
                        int id = Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"));
                        Usuario u = new UsuarioDAL().URepository.GetByID(id);
                        l.NomeAprovador = u.NomeCompleto;
                    }
                    l.Bom_Formula = Convert.ToInt32(cboTipo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboArmazem.Text)) l.IdArmazem = Convert.ToInt32(cboArmazem.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoLancamento.Text)) l.IdGrupoLancamento = Convert.ToInt32(cboGrupoLancamento.SelectedValue);

                    if (l.IdListaMateriais == 0)
                    {
                        l.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                        dal.Insert(l);
                    }
                    else
                    {
                        dal.Update(l);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                }
                catch(Exception ex)
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
                try
                {
                    int id = l.IdListaMateriais;

                    dal.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    this.Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
            }
        }

        private void CarregaCombos()
        {
            List<ComboItem> TipoProducao = new List<ComboItem>();
            TipoProducao.Add(new ComboItem() { iValue = 1, Text = "Nenhum" });
            TipoProducao.Add(new ComboItem() { iValue = 2, Text = "Co-Produto" });
            TipoProducao.Add(new ComboItem() { iValue = 3, Text = "Sub-Produto" });
            TipoProducao.Add(new ComboItem() { iValue = 4, Text = "Item de planejamento" });
            TipoProducao.Add(new ComboItem() { iValue = 5, Text = "BOM" });
            TipoProducao.Add(new ComboItem() { iValue = 6, Text = "Formula" });
            cboTipo.DataSource = TipoProducao;
            cboTipo.DisplayMember = "Text";
            cboTipo.ValueMember = "iValue";
            cboTipo.SelectedIndex = -1;

            cboArmazem.DataSource = new ArmazemDAL().GetCombo();
            cboArmazem.DisplayMember = "Text";
            cboArmazem.ValueMember = "iValue";
            cboArmazem.SelectedIndex = -1;

            cboGrupoLancamento.DataSource = new GrupoLancamentoDAL().GetCombo();
            cboGrupoLancamento.DisplayMember = "Text";
            cboGrupoLancamento.ValueMember = "iValue";
            cboGrupoLancamento.SelectedIndex = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(l.IdListaMateriais == 0 )
            {
                Util.Aplicacao.ShowMessage("É necessário salvar as informações da lista de materiais antes de adicionar produtos.");
                return;
            }
            try
            {
                ListaMateriaisItem li = new ListaMateriaisItem();
                li.IdListaMateriais = l.IdListaMateriais;
                frmListaMateriaisItem frmListaItem = new frmListaMateriaisItem(li);
                frmListaItem.dal = iDal;
                frmListaItem.ShowDialog();
                CarregaGrid();
            }
            catch (Exception ex)
            {
                CarregaGrid();
            }
            
        }

        private void dgCodigos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgCodigos.Rows[dgCodigos.SelectedRows[0].Index].Cells[0].Value);
                ListaMateriaisItem li = iDal.GetByID(id); 
                frmListaMateriaisItem frmListaItem = new frmListaMateriaisItem(li);
                frmListaItem.dal = iDal;
                frmListaItem.ShowDialog();
                CarregaGrid();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }
    }
}
