using ERP.DAL;
using ERP.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCotacaoMoedaCad : RibbonForm
    {
        public MoedaDAL dal;
        MoedaCotacao cotacao = null;

        public frmCotacaoMoedaCad(MoedaCotacao mc)
        {
            cotacao = mc;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cotacao = new MoedaCotacao();
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
                    cotacao.Data = DateTime.Parse(txtData.Text);
                    cotacao.Valor = Convert.ToDecimal(txtValor.Text);
                    cotacao.IdMoeda = Convert.ToInt32(cboMoeda.SelectedValue);

                    if (cotacao.IdMoedaCotacao == 0)
                    {
                        dal.MCRepository.Insert(cotacao);
                    }
                    else
                    {
                        dal.MCRepository.Update(cotacao);
                    }
                    dal.Save();
                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowMessage("Por favor verifique os dados informados e os campos obrigatórios." + "\n" + "\n" + "Erro: " + ex.Message);
                }
            }
            else
            {
                Util.Aplicacao.ShowMessage("Por favor verifique os dados informados e os campos obrigatórios.");
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
                    int id = cotacao.IdMoedaCotacao;
                    dal.MCRepository.Delete(id);
                    dal.Save();
                    Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowMessage("Este registro não pode ser excluído." + "\n" + "\n" + "Erro: " + ex.Message);
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregaDados();
        }

        private void frmCotacaoMoedaCad_Load(object sender, EventArgs e)
        {
            //Carrega o combo
            var moedas = dal.MRepository.Get().OrderBy(x => x.Descricao).ToList();
            cboMoeda.DataSource = moedas;
            cboMoeda.ValueMember = "IdMoeda";
            cboMoeda.DisplayMember = "Descricao";
            cboMoeda.SelectedIndex = -1;

            if (cotacao.IdMoedaCotacao == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
        }

        private void CarregaDados()
        {
            cboMoeda.SelectedValue = cotacao.IdMoeda;
            txtData.Text = cotacao.Data.ToShortDateString();
            txtValor.Text = cotacao.Valor.ToString("N4");
            lbCodigo.Text = cotacao.IdMoedaCotacao.ToString();
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtValor.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
    }
}
