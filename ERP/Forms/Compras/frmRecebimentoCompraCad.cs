using ERP.DAL;
using ERP.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ERP.BLL;
using System.Collections.Generic;

namespace ERP
{
    public partial class frmRecebimentoCompraCad : RibbonForm
    {
        RecebimentoDAL dal = new RecebimentoDAL();
        Recebimento r = new Recebimento();
        List<ModelView.RecebimentoItemModelView> lista;
        public frmRecebimentoCompraCad(RecebimentoDAL pDal, Recebimento pRecebimento)
        {
            dal = pDal;
            r = pRecebimento;

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmRecebimentoCompraCad_Load(object sender, EventArgs e)
        {
            CarregaCombos();

            if (r.IdRecebimento == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                DesabilitaCampos();
            }

            CarregaDados();
        }

        private void DesabilitaCampos()
        {
            txtRecebimento.ReadOnly = true;
            txtRecebimento.Enabled = false;
            txtRecebimento.BackColor = SystemColors.Control;
            txtData.ReadOnly = true;
            txtData.Enabled = false;
            txtData.BackColor = SystemColors.Control;
            txtUsuario.ReadOnly = true;
            txtUsuario.Enabled = false;
            txtUsuario.BackColor = SystemColors.Control;
        }

        private void CarregaCombos()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(sEmpresa);
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.SelectedIndex = -1;
        }

        private void CarregaDados()
        {
            string now = DateTime.Now.ToShortDateString();

            txtRecebimento.Text = r.RecebimentoNumero.ToString();
            txtUsuario.Text = r.Usuario == null ? "" : r.Usuario.NomeCompleto;
            txtData.Text = r.DataFisica == DateTime.MinValue ? now : r.DataFisica.ToShortDateString();

            if (r.DataRecebimento == DateTime.MinValue || r.DataRecebimento == null)
            {
                txtDataRecebimento.Text = now;
            }
            else
            {
                txtDataRecebimento.Text = r.DataRecebimento.ToString();
            } 

            cboFornecedor.SelectedValue = r.IdFornecedor;

            if (r.IdRecebimento != 0)
            {
                btnAdd.Enabled = true;
                btnAddItemPedido.Enabled = true;
                dgvItem.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
                btnAddItemPedido.Enabled = false;
                dgvItem.Enabled = false;
            }

            CarregaGrid();

            if(r.Confirmado != null && Convert.ToBoolean(r.Confirmado))
            {
                btnAdd.Enabled = false;
                btnAddItemPedido.Enabled = false;
                btnConfirmaRecebimento.Enabled = false;
                btnAdiciona.Visible = false;
                btnAlterar.Visible = false;
                btnExcluir.Visible = false;
            }


        }

        private void CarregaGrid()
        {
            
            lista = dal.GetItens(r.IdRecebimento).ToList();
            dgvItem.AutoGenerateColumns = false;
            dgvItem.DataSource = lista;
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (r.IdRecebimento == 0)
            {
                Util.Aplicacao.ShowMessage("Adicione um recebimento.");
                return;
            }

            if (String.IsNullOrEmpty(cboFornecedor.Text))
            {
                Util.Aplicacao.ShowMessage("Selecione um Fornecedor, para que seja possível o cadastramento de itens do recebimento.");
                return;
            }

            RecebimentoItem ri = new RecebimentoItem();
            ri.IdRecebimento = r.IdRecebimento;
            ri.IdRecebimentoItem = 0;

            frmRecebimentoCompraAddItem addItem = new frmRecebimentoCompraAddItem(dal, ri, Convert.ToBoolean(r.Confirmado));
            addItem.ShowDialog();
            CarregaGrid();
        }

        private void btnAddItemPedido_Click(object sender, EventArgs e)
        {

            if (r.IdRecebimento == 0)
            {
                Util.Aplicacao.ShowMessage("Adicione um recebimento.");
                return;
            }

            if (String.IsNullOrEmpty(cboFornecedor.Text))
            {
                Util.Aplicacao.ShowMessage("Selecione um Fornecedor, para que o possa selecionar os itens de um pedido.");
                return;
            }

            frmRecebimentoCompraAddPedido addItem = new frmRecebimentoCompraAddPedido(dal, r.IdRecebimento, lista);
            addItem.ShowDialog();
            CarregaGrid();
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            r = new Recebimento();
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            DesabilitaCampos();

            CarregaDados();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (r.IdRecebimento == 0)
            {
                Util.Aplicacao.ShowMessage("O recebimento não se encontra disponível para edição.");
                return;
            }

            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            DesabilitaCampos();
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            try
            {
                if (Util.Validacao.ValidaCampos(this))
                {
                    r.IdFornecedor = Convert.ToInt32(cboFornecedor.SelectedValue);

                    if (r.IdRecebimento == 0)
                    {
                        r.IdUsuario = Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"));
                        r.DataFisica = DateTime.Now;
                        r.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                        if (!String.IsNullOrEmpty(txtDataRecebimento.Text)) r.DataRecebimento = Convert.ToDateTime(txtDataRecebimento.Text);

                        dal.RRepository.Insert(r);

                        dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                        EmpresaDAL empDal = new EmpresaDAL();
                        Empresa empresa = empDal.ERepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
                        if (!empresa.UltimoRecebimento.HasValue)
                        {
                            r.RecebimentoNumero = 1;
                            empresa.UltimoRecebimento = 1;
                        }
                        else
                        {
                            r.RecebimentoNumero = empresa.UltimoRecebimento.Value + 1;
                            empresa.UltimoRecebimento = empresa.UltimoRecebimento.Value + 1;
                        }

                        dal.RRepository.Update(r);
                        dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                        empDal.ERepository.Update(empresa);
                        empDal.Save();
                    }
                    else
                    {
                        dal.RRepository.Update(r);
                        dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    }

                    CarregaDados();
                }
                else
                {
                    Util.Aplicacao.ShowMessage("Por favor verifique as informações faltantes.");
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Qualquer alteração efetuada será perdida, deseja continuar?") == System.Windows.Forms.DialogResult.Yes)
            {
                CarregaDados();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                DesabilitaCampos();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //
        }

        private void dgvItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvItem.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[0].Value.ToString());
                    RecebimentoItem ri = dal.RIRepository.GetByID(id);

                    frmRecebimentoCompraAddItem cad = new frmRecebimentoCompraAddItem(dal, ri, Convert.ToBoolean(r.Confirmado));
                    cad.ShowDialog();
                    CarregaGrid();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ok = true;
            foreach (DataGridViewRow dr in dgvItem.Rows)
            {
                int id = Convert.ToInt32(dr.Cells[0].Value);
                if (!dal.VerificaItemRecebimento(id))
                {
                    ok = false;
                    dr.DefaultCellStyle.ForeColor = Color.Red;
                }
            }

            if(!ok)
            {
                Util.Aplicacao.ShowMessage("Por favor verifique os lotes e quantidades dos itens em vermelho.");
                return;
            }


            if(Util.Aplicacao.ShowQuestionMessage("Deseja confirmar o recebimento? \n\nApós esta operação as alterações não poderão ser desfeitas.") == System.Windows.Forms.DialogResult.Yes)
            {
                //Verifica se o pedido de compras e a operação vinculada tem o movimentoEstoque = true.
                BLInventario blinventario = new BLInventario();
                bool EntradaNoEstoque = blinventario.VerificaEntradaNoEstoqueFisico(r.IdRecebimento);
                if(!EntradaNoEstoque)
                {
                    if(Util.Aplicacao.ShowQuestionMessage("O pedido de compras está configurado para não movimentar estoque, deseja continuar?") == DialogResult.No)
                    {
                        return;
                    }
                }



                if(EntradaNoEstoque)
                {
                    dal.EntradaEstoque(r.IdRecebimento);
                }
                
                r.Confirmado = true;
                dal.RRepository.Update(r);
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                Util.Aplicacao.ShowMessage("Recebimento confirmado com sucesso.");
                
            }
        }
    }
}
