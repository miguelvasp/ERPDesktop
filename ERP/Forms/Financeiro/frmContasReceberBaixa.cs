﻿using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmContasReceberBaixa : RibbonForm
    {

        public ContasReceberDAL pagDal;
        public ContasReceberChequeTerceirosDAL chDal = new ContasReceberChequeTerceirosDAL();
        ChequeTerceirosDAL chhDal = new ChequeTerceirosDAL();
        ContasReceberBaixa c = new ContasReceberBaixa();
        public ContasReceber cp;

        public frmContasReceberBaixa(ContasReceberBaixa pC)
        {
            c = pC;
            InitializeComponent();
        }

        public frmContasReceberBaixa()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmAutoridadeCad_Load(object sender, EventArgs e)
        {
            CarregaCombos();
            if (c.IdContasReceberBaixa == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void CarregaCombos()
        {
            cboConta.DataSource = new EmpresaDAL().GetContasBancarias(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
            cboConta.ValueMember = "iValue";
            cboConta.DisplayMember = "Text";
            cboConta.SelectedIndex = -1;
        }

        private void frmAutoridadeCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            txtData.Text = c.DataPagamento.ToString();
            txtDocumento.Text = c.Documento;
            txtValor.Text = c.Valor.ToString();
            txtCheque.Text = c.NumeroCheque;
            cboConta.SelectedValue = c.IdContaBancaria == null ? 0 : c.IdContaBancaria;
            txtObs.Text = c.Observacao;
            CarregaGrid();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }



        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(c.IdContasReceberAberto);
            c = new ContasReceberBaixa();
            c.IdContasReceberAberto = id;
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
                    c.IdContaBancaria = null;
                    c.DataPagamento = Convert.ToDateTime(txtData.Text);
                    c.Documento = txtDocumento.Text;
                    c.Valor = Convert.ToDecimal(txtValor.Text);
                    c.NumeroCheque = txtCheque.Text;
                    if (cboConta.Text != "") c.IdContaBancaria = Convert.ToInt32(cboConta.SelectedValue);
                    txtObs.Text = c.Observacao;


                    if (c.IdContasReceberBaixa == 0)
                    {
                        pagDal.BaixasDal.Insert(c);
                    }
                    else
                    {
                        pagDal.BaixasDal.Update(c);
                    }

                    pagDal.BaixasDal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaDados();
                    pagDal.CalculaRecebimento(cp);
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
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
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == System.Windows.Forms.DialogResult.Yes)
            {
                int id = (int)c.IdContasReceberBaixa;
                pagDal.BaixasDal.Delete(id);
                pagDal.BaixasDal.Save(Util.Util.GetAppSettings("IdUsuario"));
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CarregaGrid()
        {
            if(c.IdContasReceberBaixa != null)
            {
                var Lista = chhDal.GetChequesContasReceber((int)c.IdContasReceberBaixa);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = Lista;
            } 
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ChequeTerceiros ch = new ChequeTerceiros();
            using (frmChequeTerceiro cadCheque = new frmChequeTerceiro(ch))
            {
                cadCheque.dal = chhDal;
                cadCheque.ShowDialog();
                ch = cadCheque.c;
                if (ch.IdChequeTerceiro > 0)
                {
                    ContasReceberChequeTerceiros cch = new ContasReceberChequeTerceiros();
                    cch.IdContasReceber = cp.IdContasReceber;
                    cch.IdContasReceberBaixa = c.IdContasReceberBaixa;
                    cch.IdChequeTerceiro = ch.IdChequeTerceiro;
                    chDal.Insert(cch);
                    chDal.Save();
                }
            }
            CarregaGrid();
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            ChequeTerceiros ch = chhDal.GetByID(id);
            using (frmChequeTerceiro cadCheque = new frmChequeTerceiro(ch))
            {
                cadCheque.dal = chhDal;
                cadCheque.ShowDialog();
            }
            CarregaGrid();
        }
    }
}

