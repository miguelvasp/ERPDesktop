using ERP.DAL;
using ERP.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCentroCustoCad : RibbonForm
    {
        public CentroCustoDAL dal;
        ValoresCentroCustoDAL vDal = new ValoresCentroCustoDAL();
        CentroCusto cc = new CentroCusto();

        public frmCentroCustoCad(CentroCusto pCC)
        {
            cc = pCC;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmCentroCustoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (cc.IdCentroCusto == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = cc.IdCentroCusto.ToString();
            txtCodigo.Text = cc.Codigo;
            txtDescricao.Text = cc.Descricao;

            CarregaGrid();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = vDal.GetByCentroCusto(cc.IdCentroCusto);
            dgValores.AutoGenerateColumns = false;
            dgValores.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cc = new CentroCusto();
            lbCodigo.Text = "0";
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
                    Cursor.Current = Cursors.WaitCursor;

                    cc.Codigo = txtCodigo.Text;
                    cc.Descricao = txtDescricao.Text;
                    if (cc.IdCentroCusto == 0)
                    {
                        //verifica que possam existir somente 5 cadastros de centro de custo
                        var centros = dal.Get();
                        if (centros.Count() >= 5)
                        {
                            Util.Aplicacao.ShowMessage("Só é possível efetuar o cadastro de 5 centros de custo!");
                            return;
                        }

                        dal.Insert(cc);
                    }
                    else
                    {
                        dal.Update(cc);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
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
                    int id = cc.IdCentroCusto;
                    dal.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowMessage("Este registro não pode ser excluído." + "\n" + "\n" + "Erro: " + ex.Message);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValoresCentroCusto v = new ValoresCentroCusto();
            v.IdCentroCusto = cc.IdCentroCusto;
            frmValoresCentroCustoCad frmv = new frmValoresCentroCustoCad(v);
            frmv.dal = vDal;

            frmv.ShowDialog();
            CarregaGrid();

        }

        private void dgValores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgValores.Rows[dgValores.SelectedRows[0].Index].Cells[0].Value);
            ValoresCentroCusto v = vDal.GetByID(id);
            v.IdCentroCusto = cc.IdCentroCusto;
            frmValoresCentroCustoCad frmv = new frmValoresCentroCustoCad(v);
            frmv.dal = vDal;
            frmv.ShowDialog();
            CarregaGrid();
        }
    }
}