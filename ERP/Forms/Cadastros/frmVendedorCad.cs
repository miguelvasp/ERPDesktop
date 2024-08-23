using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP.Cadastros
{
    public partial class frmVendedorCad : RibbonForm
    {
        Vendedor v = new Vendedor();
        public VendedorDAL dal = new VendedorDAL();
        UnidadeFederacaoDAL ufdal = new UnidadeFederacaoDAL(new DB_ERPContext());
        CidadeDAL cidDal = new CidadeDAL();

        public frmVendedorCad(Vendedor vendedor)
        {
            v = vendedor;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmVendedorCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregaCombos();

            if (v.IdVendedor == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            List<DropList> Lista = new List<DropList>();
            Lista.Add(new DropList() { Text = "Percentual", Value = "Percentual" });
            Lista.Add(new DropList() { Text = "Valor", Value = "Valor" });
            cboTipoMeta.DataSource = Lista;
            cboTipoMeta.ValueMember = "Value";
            cboTipoMeta.DisplayMember = "Text";
            cboTipoMeta.SelectedIndex = -1;

            Cursor.Current = Cursors.Default;
        }

        private void CarregaCombos()
        {
            CarregaUF();
            CarregarGerente();

             
            cboPerfilFornecedor.DataSource = new PerfilFornecedorDAL().GetCombo();
            cboPerfilFornecedor.ValueMember = "iValue";
            cboPerfilFornecedor.DisplayMember = "Text";
            cboPerfilFornecedor.SelectedIndex = -1;

            cboFornecedor.DataSource = new FornecedorDAL().GetCombo();
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.SelectedIndex = -1;

        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            txtNome.Text = v.Nome;
            txtCNPJ.Text = v.CPF_CNPJ;
            txtIE.Text = v.IE_RG;
            txtCPrincipal.Text = v.ComissaoPrincipal.ToString();
            txtCAdicional.Text = v.ComissaoAdicional.ToString();
            chkGerente.Checked = v.Gerencia;
            chkRepresentante.Checked = v.Representante;
            chkComissaoExtra.Checked = v.ComissaoExtra == null ? false : Convert.ToBoolean(v.ComissaoExtra);
            txtEndereco.Text = v.Endereco;
            txtNumero.Text = v.Numero;
            txtComplemento.Text = v.Complemento;
            txtBairro.Text = v.Bairro;
            cboFornecedor.SelectedValue = v.IdFornecedor == null ? 0 : v.IdFornecedor;
            cboPerfilFornecedor.SelectedValue = v.IdPerfilFornecedor == null ? 0 : v.IdPerfilFornecedor;

            if (v.IdUF != null && v.IdUF != 0)
            {
                cboUF.SelectedValue = v.IdUF;

                int IdUF = Convert.ToInt32(cboUF.SelectedValue);
                var cidades = cidDal.Get().Where(x => x.IdUF == IdUF).ToList();
                cboCidade.DataSource = cidades;
                cboCidade.DisplayMember = "Nome";
                cboCidade.ValueMember = "IdCidade";
                cboCidade.SelectedIndex = -1;
            }

            if (v.IdCidade != null && v.IdCidade != 0)
            {
                cboCidade.SelectedValue = v.IdCidade;
            }

            txtTelefone.Text = v.Telefone;
            txtFax.Text = v.Telefone2;
            txtCelular.Text = v.Celular;
            cboGerente.SelectedValue = v.IdGerente;
            txtEmail.Text = v.Email;
            txtSite.Text = v.Site;
            chkBloqueado.Checked = v.Bloqueado;
            txtBloqueio.Text = v.MotivoBloqueio;
            dataGridView1.Visible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Rows.Clear();

            //carregamos o combo do grid

            if (v.VendedorMetas != null)
            {
                foreach (VendedorMetas vm in v.VendedorMetas)
                {
                    dataGridView1.Rows.Add(vm.IdMetaVendedor, vm.Sequencia, vm.ValorInicial, vm.ValorFinal, vm.TipoMeta, vm.ValorPremio);
                }
            }

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            v = new Vendedor();
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEmail.Text))
            {
                if (!Util.Validacao.ValidaEmail(txtEmail.Text))
                {
                    Util.Aplicacao.ShowMessage("Email inválido!");
                    return;
                }
            }

            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    v.Nome = txtNome.Text;
                    v.CPF_CNPJ = txtCNPJ.Text;
                    v.IE_RG = txtIE.Text;
                    v.ComissaoPrincipal = Convert.ToDecimal(txtCPrincipal.Text);
                    if (!String.IsNullOrEmpty(txtCAdicional.Text))
                    {
                        v.ComissaoAdicional = Convert.ToDecimal(txtCAdicional.Text);
                    }

                    v.Gerencia = chkGerente.Checked;
                    v.Representante = chkRepresentante.Checked;
                    v.ComissaoExtra = chkComissaoExtra.Checked;
                    v.Endereco = txtEndereco.Text;
                    v.Numero = txtNumero.Text;
                    v.Complemento = txtComplemento.Text;
                    v.Bairro = txtBairro.Text;
                    v.IdPerfilFornecedor = Convert.ToInt32(cboPerfilFornecedor.SelectedValue);
                    v.IdFornecedor = Convert.ToInt32(cboFornecedor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboUF.Text))
                    {
                        v.IdUF = Convert.ToInt32(cboUF.SelectedValue);
                    }

                    if (!String.IsNullOrEmpty(cboCidade.Text))
                    {
                        v.IdCidade = Convert.ToInt32(cboCidade.SelectedValue);
                    }
                    v.Telefone = txtTelefone.Text;
                    v.Telefone2 = txtFax.Text;
                    v.Celular = txtCelular.Text;
                    if (!String.IsNullOrEmpty(cboGerente.Text))
                    {
                        v.IdGerente = Convert.ToInt32(cboGerente.SelectedValue);
                    }

                    v.Email = txtEmail.Text;
                    v.Site = txtSite.Text;
                    v.Bloqueado = chkBloqueado.Checked;
                    v.MotivoBloqueio = txtBloqueio.Text;

                    if (v.IdVendedor == 0)
                    {
                        dal.VendedorRepository.Insert(v);
                    }
                    else
                    {
                        dal.VendedorRepository.Update(v);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    if (v.VendedorMetas == null)
                    {
                        v.VendedorMetas = new List<VendedorMetas>();
                    }

                    ////grava as metas do vendedor
                    //foreach(DataGridViewRow r in dataGridView1.Rows)
                    //{
                    //    if(r.Cells[0].Value != null)
                    //    {
                    //        try
                    //        {
                    //            VendedorMetas vm = null;
                    //            if(r.Cells[0].Value.ToString() == "0")
                    //            {
                    //                vm = new VendedorMetas();
                    //                vm.IdMetaVendedor = Convert.ToInt32(r.Cells[0].Value.ToString());
                    //                vm.IdVendedor = v.IdVendedor;
                    //                vm.Sequencia = r.Cells[1].Value.ToString();
                    //                vm.ValorInicial = Convert.ToDecimal(r.Cells[2].Value.ToString());
                    //                vm.ValorFinal = Convert.ToDecimal(r.Cells[3].Value.ToString());
                    //                vm.TipoMeta = r.Cells[4].Value.ToString();
                    //                vm.ValorPremio = Convert.ToDecimal(r.Cells[3].Value.ToString());
                    //            }
                    //            else
                    //            {
                    //                int idMetaVendedor = Convert.ToInt32(r.Cells[0].Value.ToString());
                    //                vm = v.VendedorMetas.Where(x => x.IdMetaVendedor == idMetaVendedor).FirstOrDefault();
                    //            }

                    //            if (vm.IdMetaVendedor == 0)
                    //            {
                    //                dal.VendedorMetaRepository.Insert(vm);
                    //            }
                    //            else
                    //            {
                    //                dal.VendedorMetaRepository.Update(vm);
                    //            }
                    //        }
                    //        catch(Exception ex)
                    //        {
                    //            Util.Aplicacao.ShowErrorMessage(ex);
                    //        }

                    //    }
                    //}
                    //dal.Save();

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
            if (Util.Aplicacao.ShowQuestionMessage("Qualquer alteração efetuada será perdida, deseja continuar?") == DialogResult.Yes)
            {
                CarregaDados();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == DialogResult.Yes)
            {
                try
                {
                    int id = v.IdVendedor; ;
                    foreach (var meta in v.VendedorMetas)
                    {
                        dal.VendedorMetaRepository.Delete(meta.IdMetaVendedor);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    dal.VendedorRepository.Delete(id);

                    this.Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowMessage("Este registro não pode ser excluído." + "\n" + "\n" + "Erro: " + ex.Message);
                }
            }
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //string Erro = "";
            //bool preencheu = false;


            //if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null)
            //{
            //    Erro += "Informe a sequência \n";
            //}
            //else
            //{
            //    preencheu = true;
            //}

            //if (dataGridView1.Rows[e.RowIndex].Cells[2].Value == null)
            //{
            //    Erro += "Informe o valor inicial \n";
            //}
            //else
            //{
            //    preencheu = true;
            //    if(!Util.Validacao.IsNumber(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()))
            //    {
            //        Erro += "Valor incial deve ser um valor numérico";
            //    }
            //}

            //if (dataGridView1.Rows[e.RowIndex].Cells[3].Value == null)
            //{
            //    Erro += "Informe o valor final \n";
            //}
            //else
            //{
            //    preencheu = true;
            //    if (!Util.Validacao.IsNumber(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()))
            //    {
            //        Erro += "Valor final deve ser um valor numérico";
            //    }
            //}

            //if (dataGridView1.Rows[e.RowIndex].Cells[4].Value == null)
            //{
            //    Erro += "Informe o tipo de meta \n";
            //}
            //else
            //{
            //    preencheu = true;
            //}

            //if (dataGridView1.Rows[e.RowIndex].Cells[5].Value == null)
            //{
            //    Erro += "Informe o valor do premio \n";
            //}
            //else
            //{
            //    if (!Util.Validacao.IsNumber(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()))
            //    {
            //        Erro += "Valor do premio deve ser um valor numérico";
            //    }
            //}


            //if(!String.IsNullOrEmpty(Erro) && preencheu)
            //{
            //    e.Cancel = true;
            //    MessageBox.Show(Erro);
            //}
            //else
            //{
            //    if (dataGridView1.Rows[e.RowIndex].Cells[0].Value == null)
            //    {
            //        dataGridView1.Rows[e.RowIndex].Cells[0].Value = "0";
            //    }
            //}
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (v.IdVendedor == 0)
            {
                Util.Aplicacao.ShowMessage("Salve as informações do vendedor antes de lançar as metas.");
                return;
            }


            limpaMeta();
            dataGridView1.Visible = false;
            txtSeq.Focus();
        }

        protected void limpaMeta()
        {
            lbID.Text = "0";
            txtSeq.Text = "";
            txtVInicial.Text = "";
            txtVFinal.Text = "";
            cboTipoMeta.SelectedIndex = -1;
            txtValorPremio.Text = "";
        }

        private void frmVendedorCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                VendedorMetas vm = null;
                if (lbID.Text == "0")
                {
                    vm = new VendedorMetas();
                }
                else
                {
                    int id = Convert.ToInt32(lbID.Text);
                    vm = v.VendedorMetas.Where(x => x.IdMetaVendedor == id).FirstOrDefault();
                }

                vm.IdVendedor = v.IdVendedor;
                vm.IdMetaVendedor = Convert.ToInt32(lbID.Text);
                vm.Sequencia = txtSeq.Text;
                vm.ValorInicial = Convert.ToDecimal(txtVInicial.Text);
                vm.ValorFinal = Convert.ToDecimal(txtVFinal.Text);
                vm.TipoMeta = cboTipoMeta.SelectedValue.ToString();
                vm.ValorPremio = Convert.ToDecimal(txtValorPremio.Text);

                if (vm.IdMetaVendedor == 0)
                {
                    dal.VendedorMetaRepository.Insert(vm);
                }
                else
                {
                    dal.VendedorMetaRepository.Update(vm);
                }
                dal.Save();
                CarregaDados();

            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowMessage("Por favor verifique os dados informados." + "\n" + "\n" + "Erro: " + ex.Message);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
            VendedorMetas vm = v.VendedorMetas.Where(x => x.IdMetaVendedor == id).FirstOrDefault();
            lbID.Text = vm.IdMetaVendedor.ToString();
            txtSeq.Text = vm.Sequencia;
            txtVInicial.Text = vm.ValorInicial.ToString();
            txtVFinal.Text = vm.ValorFinal.ToString();
            cboTipoMeta.SelectedValue = vm.TipoMeta;
            txtValorPremio.Text = vm.ValorPremio.ToString();
            dataGridView1.Visible = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja eliminar o registro?") == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
                dal.VendedorMetaRepository.Delete(id);
                dal.Save();
                CarregaDados();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpaMeta();
            CarregaDados();
        }

        private void cboTipoMeta_Enter(object sender, EventArgs e)
        {
            cboTipoMeta.DroppedDown = true;
        }

        #region CarregamentoCombos
        private void CarregarGerente()
        {
            cboGerente.DataSource = new FuncionarioDAL().GetCombo();
            cboGerente.DisplayMember = "Text";
            cboGerente.ValueMember = "iValue";
            cboGerente.SelectedIndex = -1;
        }

        private void CarregaUF()
        {
            //Carrega uf
            var ufs = ufdal.Get().OrderBy(x => x.UF).ToList();
            cboUF.DataSource = ufs;
            cboUF.DisplayMember = "UF";
            cboUF.ValueMember = "IdUF";
            cboUF.SelectedIndex = -1;
        }
        #endregion

        private void cboUF_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboUF.Text))
            {
                int IdUF = Convert.ToInt32(cboUF.SelectedValue);
                var cidades = cidDal.Get().Where(x => x.IdUF == IdUF).ToList();
                cboCidade.DataSource = cidades;
                cboCidade.DisplayMember = "Nome";
                cboCidade.ValueMember = "IdCidade";
                cboCidade.SelectedIndex = -1;
            }
        }
    }
}
