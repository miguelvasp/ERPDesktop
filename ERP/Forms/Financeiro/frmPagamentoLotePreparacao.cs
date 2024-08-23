using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPagamentoLotePreparacao : Form
    {
        PagamentoLoteDAL dal = new PagamentoLoteDAL();
        PagamentoLoteItemDAL idal = new PagamentoLoteItemDAL();
        ContasPagarBaixaDAL bdal = new ContasPagarBaixaDAL();
        PagamentoLoteChequeTerceiroDAL chdal = new PagamentoLoteChequeTerceiroDAL();
        ContasPagarChequeTerceirosDAL cbChDal = new ContasPagarChequeTerceirosDAL();
        ContasPagarDAL cpDal = new ContasPagarDAL();


        decimal Soma = 0;
        public frmPagamentoLotePreparacao()
        {
            InitializeComponent();
            CarregaCombos();
        }

        private void CarregaCombos()
        {
            cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(Util.Util.GetAppSettings("IdEmpresa"));
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.SelectedIndex = -1;

            cboFornecedorBaixa.DataSource = new FornecedorDAL().GetCombo2(Util.Util.GetAppSettings("IdEmpresa"));
            cboFornecedorBaixa.DisplayMember = "Text";
            cboFornecedorBaixa.ValueMember = "iValue";
            cboFornecedorBaixa.SelectedIndex = -1;

            cboClienteBaixa.DataSource = new ClienteDAL().GetCombo(Util.Util.GetAppSettings("IdEmpresa"));
            cboClienteBaixa.DisplayMember = "Text";
            cboClienteBaixa.ValueMember = "iValue";
            cboClienteBaixa.SelectedIndex = -1;

            cboContaBancariaBaixa.DataSource = new EmpresaDAL().GetContasBancarias(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
            cboContaBancariaBaixa.ValueMember = "iValue";
            cboContaBancariaBaixa.DisplayMember = "Text";
            cboContaBancariaBaixa.SelectedIndex = -1;

            cboContaContabilBaixa.DataSource = new ContaContabilDAL().GetComboByTipo(1);
            cboContaContabilBaixa.ValueMember = "iValue";
            cboContaContabilBaixa.DisplayMember = "Text";
            cboContaContabilBaixa.SelectedIndex = -1;

            cboMetodoPagamento.DataSource = new MetodoPagamentoDAL().GetCombo();
            cboMetodoPagamento.ValueMember = "iValue";
            cboMetodoPagamento.DisplayMember = "Text";
            cboMetodoPagamento.SelectedIndex = -1;

            cboMetodoPagamentoBaixa.DataSource = new MetodoPagamentoDAL().GetCombo();
            cboMetodoPagamentoBaixa.ValueMember = "iValue";
            cboMetodoPagamentoBaixa.DisplayMember = "Text";
            cboMetodoPagamentoBaixa.SelectedIndex = -1;
        }

        private void CarregaGrid()
        {
            DateTime De = Convert.ToDateTime(txtVencimentoDe.Text + " 00:00:00");
            DateTime Ate = Convert.ToDateTime(txtVencimentoAte.Text + " 23:59:00");
            int IdFornecedor = String.IsNullOrEmpty(cboFornecedor.Text) ? 0 : Convert.ToInt32(cboFornecedor.SelectedValue);
            int IdMetodoPagamento = String.IsNullOrEmpty(cboMetodoPagamento.Text) ? 0 : Convert.ToInt32(cboMetodoPagamento.SelectedValue);
            var lista = dal.GetVencimentos(De, Ate, IdFornecedor, IdMetodoPagamento);
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = lista;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void cboGrupoVariantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void frmBuscaProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        

        private void frmBuscaProduto_Load(object sender, EventArgs e)
        {
            CarregaCombos();
            txtVencimentoDe.Text = DateTime.Now.ToShortDateString();
            txtVencimentoAte.Text = DateTime.Now.ToShortDateString();
        }

        private void LimpaPagamento()
        {
            CarregaGrid();
            pblBotao.Visible = false;
            dgv.Visible = true;
            cboMetodoPagamentoBaixa.SelectedIndex = -1;
            cboFornecedorBaixa.SelectedIndex = -1;
            cboClienteBaixa.SelectedIndex = -1;
            cboContaBancariaBaixa.SelectedIndex = -1;
            cboContaContabilBaixa.SelectedIndex = -1;
            Soma = 0;
            btnConfirmar.Visible = true;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            dgv.Visible = false;
            pblBotao.Visible = true;
            pblBotao.Dock = DockStyle.Fill;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var cell = dgv[e.ColumnIndex, e.RowIndex];
                if (cell.OwningColumn.Name == "chkSelecionar")
                {
                    if (cell.EditedFormattedValue.ToString().ToLower() == "true")
                    {
                        dgv[9, e.RowIndex].Value = dgv[8, e.RowIndex].Value;
                    }
                    else
                    {
                        dgv[9, e.RowIndex].Value = "";
                    }
                }
            }
            CalculaSelecao();
            //if (e.RowIndex >= 0)
            //{
            //    if(Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells[2].Value))
            //    {
            //        dgv.Rows[e.RowIndex].Cells[9].Value = dgv.Rows[e.RowIndex].Cells[8].Value;
            //    } 
            //    else
            //    {
            //        dgv.Rows[e.RowIndex].Cells[9].Value = "";
            //    }
            //}
        }

        private void CalculaSelecao()
        {
            dgv.EndEdit();
            Soma = 0;
            foreach(DataGridViewRow dr in dgv.Rows)
            {
                if(Convert.ToBoolean(dr.Cells[2].Value))
                {
                    Soma += Convert.ToDecimal(dr.Cells[9].Value.ToString().Replace(".", ""));
                }
            }

            lbTotal.Text = "Valor selecionado R$ " + Soma.ToString("N2");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBox1.Checked;
            foreach(DataGridViewRow dr in dgv.Rows)
            {
                dr.Cells[2].Value = check;
                if(check)
                {
                    dr.Cells[9].Value = dr.Cells[8].Value;
                }
                else
                {
                    dr.Cells[9].Value = "";
                }
            }
            CalculaSelecao();
        }

        private void BuscaCheques()
        {
            try
            {
                if(!String.IsNullOrEmpty(cboMetodoPagamentoBaixa.Text))
                {
                    int IdMetodoPagamento = Convert.ToInt32(cboMetodoPagamentoBaixa.SelectedValue);
                    MetodoPagamento mp = new MetodoPagamentoDAL().GetByID(IdMetodoPagamento);
                    if (mp.TipoPagamento.ToString() == "3")
                    {
                        if(!String.IsNullOrEmpty(cboContaBancariaBaixa.Text))
                        {
                            var ChequesList = new ChequeDAL().BuscaCheques(Convert.ToInt32(cboContaBancariaBaixa.SelectedValue));
                            cboCheque.DataSource = ChequesList;
                            cboCheque.DisplayMember = "Text";
                            cboCheque.ValueMember = "iValue";
                            cboCheque.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch
            { 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            int IdFornecedorBaixa = String.IsNullOrEmpty(cboFornecedorBaixa.Text) ? 0 : Convert.ToInt32(cboFornecedorBaixa.SelectedValue);
            int IdClienteBaixa = String.IsNullOrEmpty(cboClienteBaixa.Text) ? 0 : Convert.ToInt32(cboClienteBaixa.SelectedValue);
            int IdContaContabilBaixa = String.IsNullOrEmpty(cboContaContabilBaixa.Text) ? 0 : Convert.ToInt32(cboContaContabilBaixa.SelectedValue);
            int IdContaBancariaBaixa = String.IsNullOrEmpty(cboContaBancariaBaixa.Text) ? 0 : Convert.ToInt32(cboContaBancariaBaixa.SelectedValue);
            int IdMetodoPagamento = String.IsNullOrEmpty(cboMetodoPagamentoBaixa.Text) ? 0 : Convert.ToInt32(cboMetodoPagamentoBaixa.SelectedValue);
            int IdCheque = String.IsNullOrEmpty(cboCheque.Text) ? 0 : Convert.ToInt32(cboCheque.SelectedValue);
            if (IdFornecedorBaixa == 0 && IdClienteBaixa == 0 && IdContaBancariaBaixa == 0 && IdContaContabilBaixa == 0)
            {
                Util.Aplicacao.ShowMessage("Selecione o local para pagamento");
                return;
            }

            if(IdMetodoPagamento == 0)
            {
                Util.Aplicacao.ShowMessage("Informe um metodo de pagamento");
            }

            MetodoPagamento mp = new MetodoPagamentoDAL().GetByID(IdMetodoPagamento);
            if(mp.TipoPagamento == 3 || mp.TipoPagamento == 5 || mp.TipoPagamento == 6) //3 -cheque ; 5 pagamento eletronico // 6 cheque terceiros
            {
                if(IdContaBancariaBaixa == 0)
                {
                    Util.Aplicacao.ShowMessage("Este metodo de pagamento requer que a conta bancária seja informada!");
                    return;
                }

                

            }

            //Verificar os valores

            //se for cheque de terceiros chama a pesquisa
            List<ChequeTerceiroModelView> cheques = new List<ChequeTerceiroModelView>();
            if (mp.TipoPagamento == 6)
            {
                frmSelecaoChequeTerceiros frmCheques = new frmSelecaoChequeTerceiros();
                frmCheques.ShowDialog();
                cheques = frmCheques.Selecao;

                if(cheques.Count == 0)
                {
                    Util.Aplicacao.ShowMessage("É necessário selecionar os cheques de terceiros.");
                    return;
                }
            }


            PagamentoLote p = new PagamentoLote();
            p.Data = DateTime.Now;
            if (IdFornecedorBaixa > 0) p.IdFornecedor = IdFornecedorBaixa;
            if (IdClienteBaixa > 0) p.IdCliente = IdClienteBaixa;
            if(IdContaBancariaBaixa > 0) p.IdContaBancaria = IdContaBancariaBaixa;
            if (IdContaContabilBaixa > 0) p.IdContaContabil = IdContaContabilBaixa;
            p.IdMetodoPagamento = IdMetodoPagamento;
            p.Valor = Soma;
            p.StatusPagamento = 1;
            dal.Insert(p);
            dal.Save();

            //Pesquisa o cheque da conta bancaria selecionada e marca
            if(mp.TipoPagamento == 3) //cheque da conta
            {
                if (mp.TipoPagamento == 3 && cboCheque.Text == "")
                {
                    Util.Aplicacao.ShowMessage("Informe o número do cheque!");
                    return;
                }
                 
                p.Cheque = Convert.ToInt32(cboCheque.Text);
                p.IdCheque = Convert.ToInt32(cboCheque.SelectedValue);
                ChequeDAL chnDal = new ChequeDAL();
                Cheque ch = chnDal.GetByID(Convert.ToInt32(p.IdCheque));
                ch.IdContaBancaria = p.IdContaBancaria;
                ch.Valor = Soma;
                ch.Emissao = DateTime.Now;
                chnDal.Update(ch);
                chnDal.Save();
            }
            

            //lança os cheques de terceiros
            if (mp.TipoPagamento == 6)
            {
                foreach(var cheque in cheques)
                {
                    PagamentoLoteChequeTerceiro pch = new PagamentoLoteChequeTerceiro();
                    pch.IdPagamentoLote = p.IdPagamentoLote;
                    pch.IdChequeTerceiro = cheque.Id;
                    pch.Valor = cheque.Valor;
                    chdal.Insert(pch);
                    chdal.Save();
                }
                
            }
            
            foreach(DataGridViewRow dr in dgv.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[2].Value))
                {
                    ContasPagarBaixa cpb = new ContasPagarBaixa();
                    cpb.IdContasPagarAberto = Convert.ToInt32(dr.Cells[0].Value); 
                    cpb.DataPagamento = DateTime.Now;
                    cpb.Documento = "PL" + p.IdPagamentoLote.ToString().PadLeft(7, '0');
                    cpb.Observacao = "Baixa efetuada por pagamento em lote";
                    cpb.Valor = Convert.ToDecimal(dr.Cells[9].Value);
                    cpb.IdContaBancaria = p.IdContaBancaria;
                    cpb.IdCliente = p.IdCliente;
                    cpb.IdFornecedor = p.IdFornecedor;
                    cpb.IdContaContabil = p.IdContaContabil;
                    cpb.Liquidada = false;
                    cpb.IdMetodoPagamento = p.IdMetodoPagamento;
                    if (mp.TipoPagamento == 3)
                    {
                        cpb.IdCheque = p.IdCheque;
                        cpb.Cheque = p.Cheque;
                    }
                    bdal.Insert(cpb);
                    bdal.Save();

                    //Atualiza o pagamento
                    ContasPagar cp = cpDal.GetByID(Convert.ToInt32(dr.Cells[1].Value));
                    cpDal.CalculaPagamento(cp);

                    //lança os cheques da empresa
                    if (mp.TipoPagamento == 3)
                    {
                        ChequeItemDAL ciDal = new ChequeItemDAL();
                        ChequeItem ci = new ChequeItem();
                        ci.IdCheque = Convert.ToInt32(cboCheque.SelectedValue);
                        ci.Fornecedor = dr.Cells[3].Value.ToString();

                        ci.Valor = cpb.Valor;
                        ciDal.Insert(ci);
                        ciDal.Save();
                    }

                        //lança os cheques de terceiros
                    if (mp.TipoPagamento == 6)
                    {
                        foreach (var cheque in cheques)
                        {
                            ContasPagarChequeTerceiros chtBaixa = new ContasPagarChequeTerceiros();
                            chtBaixa.IdChequeTerceiro = cheque.Id;
                            chtBaixa.IdContasPagar = Convert.ToInt32(dr.Cells[1].Value);
                            chtBaixa.IdContasPagarBaixa = Convert.ToInt32(dr.Cells[0].Value);
                            cbChDal.Insert(chtBaixa);
                            cbChDal.Save();

                            //Atualiza o cheque
                            ChequeTerceirosDAL chttDal = new ChequeTerceirosDAL();
                            ChequeTerceiros cheq = chttDal.GetByID(cheque.Id);
                            cheq.IdContasPagarBaixa = chtBaixa.IdContasPagarBaixa;
                            chttDal.Update(cheq);
                            chttDal.Save();
                        }
                    }
                    


                    PagamentoLoteItem pi = new PagamentoLoteItem();
                    pi.IdPagamentoLote = p.IdPagamentoLote;
                    pi.IdContasPagarAberto = Convert.ToInt32(dr.Cells[0].Value);
                    pi.IdContasPagarBaixa = cpb.IdContasPagarBaixa;
                    pi.Valor = Convert.ToDecimal(dr.Cells[9].Value);
                    pi.StatusBaixa = 1;//A confirmar
                    idal.Insert(pi);
                    idal.Save();
                } 
            }

            //Após finalizar o processo da a mensagem e fecha a janela
            Util.Aplicacao.ShowMessage("Geração de pagamento com sucesso.");
            this.Close();
            

        }

        private void cboContaBancariaBaixa_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscaCheques();
        }

        private void cboMetodoPagamentoBaixa_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscaCheques();
        }
    }
}
