using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.DAL;
using ERP.Models;
using ERP.Relatorios;

namespace ERP.Cadastros
{
    public partial class frmTabelas : Form
    {
        string Tabela;

        ArmazemDAL armazemDAL = new ArmazemDAL();
        AvaliacaoCreditoDAL avaliacaoCreditoDAL = new AvaliacaoCreditoDAL();
        MoedaDAL moedaDal = new MoedaDAL();
        CodigoIsencaoDAL codigoIsencaoDAL = new CodigoIsencaoDAL();
        ContaGerencialDAL contaGerencialDAL = new ContaGerencialDAL();
        ContaPlanoReferencialDAL contaPRDAL = new ContaPlanoReferencialDAL();
        CodigoContratoComercialDAL codigoContratoComercialDAL = new CodigoContratoComercialDAL();
        CodigoServicoDAL CodigoServicoDAL = new CodigoServicoDAL();
        DepartamentoDAL departamentoDAL = new DepartamentoDAL();
        DepositoDAL depositoDAL = new DepositoDAL();
        EmbalagemDAL EmbalagemDAL = new EmbalagemDAL();
        EspecieDAL especieDAL = new EspecieDAL();
        FormaPagamentoDAL formaPagamentoDAL = new FormaPagamentoDAL();
        GrupoComissaoDAL grupoComissaoDAL = new GrupoComissaoDAL();
        GrupoCustoDAL GrupoCustoDAL = new GrupoCustoDAL();
        GrupoDescontosDAL grupoDescontoDal = new GrupoDescontosDAL();
        GrupoEncargosDAL GrupoEncargosDAL = new GrupoEncargosDAL();
        GrupoImpostoItemDAL grupoImpostoItemDAL = new GrupoImpostoItemDAL();
        GrupoItensSuplementaresDAL GrupoItensSuplementaresDAL = new GrupoItensSuplementaresDAL();
        GrupoLancamentoDAL GrupoLancamentoDAL = new GrupoLancamentoDAL();
        GrupoLotesDAL GrupoLotesDAL = new GrupoLotesDAL();
        GrupoProducaoDAL GrupoProducaoDAL = new GrupoProducaoDAL();
        GrupoProdutoDAL grupoProdutoDAL = new GrupoProdutoDAL();
        GrupoSeriesDAL GrupoSeriesDAL = new GrupoSeriesDAL();
        ImpostoRetidoDAL impostoRetidoDAL = new ImpostoRetidoDAL();
        TipoItemDAL TipoItemDAL = new TipoItemDAL();
        TipoPagamentoDAL tipoPagamentoDAL = new TipoPagamentoDAL();
        TipoTransacaoBancariaDAL TipoTBDAL = new TipoTransacaoBancariaDAL();
        LinhaNegocioDAL linhaNegocioDAL = new LinhaNegocioDAL();
        VariantesConfigDAL VariantesConfigDAL = new VariantesConfigDAL();
        VariantesCorDAL VariantesCorDAL = new VariantesCorDAL();
        VariantesEstiloDAL VariantesEstiloDAL = new VariantesEstiloDAL();
        VariantesGrupoDAL VariantesGrupoDAL = new VariantesGrupoDAL();
        VariantesTamanhoDAL VariantesTamanhoDAL = new VariantesTamanhoDAL();
        GrupoAlocacaoFreteDAL GrupoAlocacaoFreteDAL = new GrupoAlocacaoFreteDAL();
        GrupoCFOPDAL grupoCFOPDAL = new GrupoCFOPDAL();

        public frmTabelas(string pNomeTabela)
        {
            Tabela = pNomeTabela;
            InitializeComponent();
        }

        protected void LimpaCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            lbID.Text = "0";
        }

        protected void VinculaDados()
        {
            dgv.Columns.Add("Id", "Id");
            dgv.Columns[0].Visible = false;
            textBox2.Visible = false;
            lbCampo2.Visible = false;
            textBox3.Visible = false;
            lbCampo3.Visible = false;
            textBox4.Visible = false;
            lbCampo4.Visible = false;

            switch (Tabela)
            {
                case "AvaliacaoCredito":
                    lbCampo1.Text = "Nome";
                    lbCampo2.Text = "Valor";
                    textBox1.MaxLength = 255;
                    textBox2.Visible = true;
                    dgv.Columns.Add("Nome", "Nome");
                    dgv.Columns.Add("Valor", "Valor");
                    break;
                case "CodigoContratoComercial":
                    {
                        lbCampo1.Text = "Código";
                        lbCampo2.Text = "Descrição";
                        dgv.Columns.Add("Codigo", "Código");
                        dgv.Columns.Add("Descricao", "Descrição");
                        textBox1.MaxLength = 20;
                        textBox2.MaxLength = 255;
                        textBox2.Visible = true;
                        lbCampo2.Visible = true;
                    } break;
                case "TipoTransacaoBancaria":
                case "CodigoIsencao":
                case "ContaGerencial":
                case "ContaPlanoReferencial":
                case "GrupoImpostoItem":
                case "FormaPagamento":
                case "TipoPagamento":
                case "VariantesCor":
                case "VariantesEstilo":
                case "VariantesConfig":
                    lbCampo1.Text = "Descrição";
                    lbCampo2.Text = "Código";
                    textBox2.MaxLength = 255;
                    textBox2.Visible = true;
                    dgv.Columns.Add("Descricao", "Descrição");
                    dgv.Columns.Add("Codigo", "Código");
                    break;
                case "VariantesTamanho":
                case "Moeda":
                    {
                        lbCampo1.Text = "Código";
                        lbCampo2.Text = "Descrição";
                        dgv.Columns.Add("Codigo", "Código");
                        dgv.Columns.Add("Descricao", "Descrição");
                        textBox2.Visible = true;
                        lbCampo2.Visible = true;
                    } break;

                case "Armazem":
                case "Departamento":
                case "Deposito":
                case "Especie":
                case "GrupoProduto":
                case "LinhaNegocio":
                    {
                        lbCampo1.Text = "Nome";
                        lbCampo2.Text = "Descrição";
                        dgv.Columns.Add("Nome", "Nome");
                        dgv.Columns.Add("Descricao", "Descrição");
                        textBox2.MaxLength = 255;
                        textBox2.Visible = true;
                        lbCampo2.Visible = true;
                    } break;

                default:
                    lbCampo1.Text = "Descrição";
                    dgv.Columns.Add("Descricao", "Descrição");
                    break;
            }
        }

        #region SalvaObjetos
        protected void Salvar()
        {
            Cursor.Current = Cursors.WaitCursor;

            switch (Tabela)
            {
                case "Armazem":
                    {
                        if (lbID.Text == "0")
                        {
                            Armazem am = new Armazem();
                            am.Nome = textBox1.Text;
                            am.Descricao = textBox2.Text;
                            armazemDAL.Insert(am);
                        }
                        else
                        {
                            Armazem am = armazemDAL.GetByID(Convert.ToInt32(lbID.Text));
                            am.Nome = textBox1.Text;
                            am.Descricao = textBox2.Text;
                            armazemDAL.Update(am);
                        }

                        armazemDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;
                case "AvaliacaoCredito":
                    {
                        if (lbID.Text == "0")
                        {
                            AvaliacaoCredito ac = new AvaliacaoCredito();
                            ac.Nome = textBox1.Text;
                            ac.Valor = Convert.ToDecimal(textBox2.Text);
                            avaliacaoCreditoDAL.Insert(ac);
                        }
                        else
                        {
                            AvaliacaoCredito ac = avaliacaoCreditoDAL.GetByID(Convert.ToInt32(lbID.Text));
                            ac.Nome = textBox1.Text;
                            avaliacaoCreditoDAL.Update(ac);
                        }

                        avaliacaoCreditoDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;
                case "Moeda":
                    {
                        if (lbID.Text == "0")
                        {
                            Moeda m = new Moeda();
                            m.Codigo = textBox1.Text;
                            m.Descricao = textBox2.Text;
                            moedaDal.MRepository.Insert(m);
                        }
                        else
                        {
                            Moeda m = moedaDal.MRepository.GetByID(Convert.ToInt32(lbID.Text));
                            m.Codigo = textBox1.Text;
                            m.Descricao = textBox2.Text;
                            moedaDal.MRepository.Update(m);
                        }
                        moedaDal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;

                case "CodigoIsencao":
                    {
                        if (lbID.Text == "0")
                        {
                            CodigoIsencao ci = new CodigoIsencao();
                            ci.Codigo = textBox1.Text;
                            ci.Descricao = textBox2.Text;
                            codigoIsencaoDAL.Insert(ci);
                        }
                        else
                        {
                            CodigoIsencao ci = codigoIsencaoDAL.GetByID(Convert.ToInt32(lbID.Text));
                            ci.Codigo = textBox1.Text;
                            ci.Descricao = textBox2.Text;
                            codigoIsencaoDAL.Update(ci);
                        }

                        codigoIsencaoDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;
                case "ContaGerencial":
                    {
                        if (lbID.Text == "0")
                        {
                            ContaGerencial cg = new ContaGerencial();
                            cg.Codigo = textBox1.Text;
                            cg.Descricao = textBox2.Text;
                            contaGerencialDAL.Insert(cg);
                        }
                        else
                        {
                            ContaGerencial cg = contaGerencialDAL.GetByID(Convert.ToInt32(lbID.Text));
                            cg.Codigo = textBox1.Text;
                            cg.Descricao = textBox2.Text;
                            contaGerencialDAL.Update(cg);
                        }

                        contaGerencialDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;
                case "ContaPlanoReferencial":
                    {
                        if (lbID.Text == "0")
                        {
                            ContaPlanoReferencial cpr = new ContaPlanoReferencial();
                            cpr.Codigo = textBox1.Text;
                            cpr.Descricao = textBox2.Text;
                            contaPRDAL.Insert(cpr);
                        }
                        else
                        {
                            ContaPlanoReferencial cpr = contaPRDAL.GetByID(Convert.ToInt32(lbID.Text));
                            cpr.Codigo = textBox1.Text;
                            cpr.Descricao = textBox2.Text;
                            contaPRDAL.Update(cpr);
                        }

                        contaPRDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;
                case "Departamento":
                    {
                        if (lbID.Text == "0")
                        {
                            Departamento dp = new Departamento();
                            dp.Nome = textBox1.Text;
                            dp.Descricao = textBox2.Text;
                            departamentoDAL.Insert(dp);
                        }
                        else
                        {
                            Departamento dp = departamentoDAL.GetByID(Convert.ToInt32(lbID.Text));
                            dp.Nome = textBox1.Text;
                            dp.Descricao = textBox2.Text;
                            departamentoDAL.Update(dp);
                        }

                        departamentoDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;

                case "Deposito":
                    {
                        if (lbID.Text == "0")
                        {
                            Deposito dp = new Deposito();
                            dp.Nome = textBox1.Text;
                            dp.Descricao = textBox2.Text;
                            depositoDAL.Insert(dp);
                        }
                        else
                        {
                            Deposito dp = depositoDAL.GetByID(Convert.ToInt32(lbID.Text));
                            dp.Nome = textBox1.Text;
                            dp.Descricao = textBox2.Text;
                            depositoDAL.Update(dp);
                        }

                        depositoDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;

                case "Especie":
                    {
                        if (lbID.Text == "0")
                        {
                            Especie esp = new Especie();
                            esp.Nome = textBox1.Text;
                            esp.Descricao = textBox2.Text;
                            especieDAL.Insert(esp);
                        }
                        else
                        {
                            Especie esp = especieDAL.GetByID(Convert.ToInt32(lbID.Text));
                            esp.Nome = textBox1.Text;
                            esp.Descricao = textBox2.Text;
                            especieDAL.Update(esp);
                        }

                        especieDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;

                case "GrupoDesconto":
                    {
                        if (lbID.Text == "0")
                        {
                            GrupoDescontos tb = new GrupoDescontos();
                            tb.Descricao = textBox1.Text;
                            grupoDescontoDal.Insert(tb);
                        }
                        else
                        {
                            GrupoDescontos tb = grupoDescontoDal.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Descricao = textBox1.Text;
                            grupoDescontoDal.Update(tb);
                        }
                        grupoDescontoDal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;
                case "GrupoEncargos":
                    {
                        if (lbID.Text == "0")
                        {
                            GrupoEncargos tb = new GrupoEncargos();
                            tb.Descricao = textBox1.Text;
                            GrupoEncargosDAL.Insert(tb);
                        }
                        else
                        {
                            GrupoEncargos tb = GrupoEncargosDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Descricao = textBox1.Text;
                            GrupoEncargosDAL.Update(tb);
                        }
                        GrupoEncargosDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;
                case "GrupoItensSuplementares":
                    {
                        if (lbID.Text == "0")
                        {
                            GrupoItensSuplementares tb = new GrupoItensSuplementares();
                            tb.Descricao = textBox1.Text;
                            GrupoItensSuplementaresDAL.Insert(tb);
                        }
                        else
                        {
                            GrupoItensSuplementares tb = GrupoItensSuplementaresDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Descricao = textBox1.Text;
                            GrupoItensSuplementaresDAL.Update(tb);
                        }
                        GrupoItensSuplementaresDAL.Save();
                    } break;
                case "GrupoComissao":
                    {
                        if (lbID.Text == "0")
                        {
                            GrupoComissao gc = new GrupoComissao();
                            gc.Descricao = textBox1.Text;
                            grupoComissaoDAL.Insert(gc);
                        }
                        else
                        {
                            GrupoComissao gc = grupoComissaoDAL.GetByID(Convert.ToInt32(lbID.Text));
                            gc.Descricao = textBox1.Text;
                            grupoComissaoDAL.Update(gc);
                        }
                        grupoComissaoDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;
                case "GrupoCusto":
                    {
                        if (lbID.Text == "0")
                        {
                            GrupoCusto tb = new GrupoCusto();
                            tb.Descricao = textBox1.Text;
                            GrupoCustoDAL.Insert(tb);
                        }
                        else
                        {
                            GrupoCusto tb = GrupoCustoDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Descricao = textBox1.Text;
                            GrupoCustoDAL.Update(tb);
                        }
                        GrupoCustoDAL.Save();
                    } break;
                case "GrupoLancamento":
                    {
                        if (lbID.Text == "0")
                        {
                            GrupoLancamento tb = new GrupoLancamento();
                            tb.Descricao = textBox1.Text;
                            GrupoLancamentoDAL.Insert(tb);
                        }
                        else
                        {
                            GrupoLancamento tb = GrupoLancamentoDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Descricao = textBox1.Text;
                            GrupoLancamentoDAL.Update(tb);
                        }
                        GrupoLancamentoDAL.Save();
                    } break;

                case "GrupoProduto":
                    {
                        if (lbID.Text == "0")
                        {
                            GrupoProduto gp = new GrupoProduto();
                            gp.Nome = textBox1.Text;
                            gp.Descricao = textBox2.Text;
                            grupoProdutoDAL.Insert(gp);
                        }
                        else
                        {
                            GrupoProduto gp = grupoProdutoDAL.GetByID(Convert.ToInt32(lbID.Text));
                            gp.Nome = textBox1.Text;
                            gp.Descricao = textBox2.Text;
                            grupoProdutoDAL.Update(gp);
                        }

                        grupoProdutoDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;

                case "Embalagem":
                    {
                        if (lbID.Text == "0")
                        {
                            Embalagem tb = new Embalagem();
                            tb.Descricao = textBox1.Text;
                            EmbalagemDAL.Insert(tb);
                        }
                        else
                        {
                            Embalagem tb = EmbalagemDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Descricao = textBox1.Text;
                            EmbalagemDAL.Update(tb);
                        }
                        EmbalagemDAL.Save();
                    } break;
                case "FormaPagamento":
                    {
                        if (lbID.Text == "0")
                        {
                            FormaPagamento fp = new FormaPagamento();
                            fp.Codigo = textBox1.Text;
                            fp.Descricao = textBox2.Text;
                            formaPagamentoDAL.Insert(fp);
                        }
                        else
                        {
                            FormaPagamento fp = formaPagamentoDAL.GetByID(Convert.ToInt32(lbID.Text));
                            fp.Codigo = textBox1.Text;
                            fp.Descricao = textBox2.Text;
                            formaPagamentoDAL.Update(fp);
                        }
                        formaPagamentoDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;
                case "GrupoImpostoItem":
                    {
                        if (lbID.Text == "0")
                        {
                            GrupoImpostoItem tb = new GrupoImpostoItem();
                            tb.Codigo = textBox1.Text;
                            tb.Descricao = textBox2.Text;
                            grupoImpostoItemDAL.Insert(tb);
                        }
                        else
                        {
                            GrupoImpostoItem tb = grupoImpostoItemDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Codigo = textBox1.Text;
                            tb.Descricao = textBox2.Text;
                            grupoImpostoItemDAL.Update(tb);
                        }
                        grupoImpostoItemDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;

                case "GrupoLotes":
                    {
                        if (lbID.Text == "0")
                        {
                            GrupoLotes tb = new GrupoLotes();
                            tb.Descricao = textBox1.Text;
                            GrupoLotesDAL.Insert(tb);
                        }
                        else
                        {
                            GrupoLotes tb = GrupoLotesDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Descricao = textBox1.Text;
                            GrupoLotesDAL.Update(tb);
                        }
                        GrupoLotesDAL.Save();
                    } break;
                case "GrupoSeries":
                    {
                        if (lbID.Text == "0")
                        {
                            GrupoSeries tb = new GrupoSeries();
                            tb.Descricao = textBox1.Text;
                            GrupoSeriesDAL.Insert(tb);
                        }
                        else
                        {
                            GrupoSeries tb = GrupoSeriesDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Descricao = textBox1.Text;
                            GrupoSeriesDAL.Update(tb);
                        }
                        GrupoSeriesDAL.Save();
                    } break;
                case "TipoItem":
                    {
                        if (lbID.Text == "0")
                        {
                            TipoItem tb = new TipoItem();
                            tb.Descricao = textBox1.Text;
                            TipoItemDAL.Insert(tb);
                        }
                        else
                        {
                            TipoItem tb = TipoItemDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Descricao = textBox1.Text;
                            TipoItemDAL.Update(tb);
                        }
                        TipoItemDAL.Save();
                    } break;
                case "TipoPagamento":
                    {
                        if (lbID.Text == "0")
                        {
                            TipoPagamento tp = new TipoPagamento();
                            tp.Codigo = textBox1.Text;
                            tp.Descricao = textBox2.Text;
                            tipoPagamentoDAL.Insert(tp);
                        }
                        else
                        {
                            TipoPagamento tp = tipoPagamentoDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tp.Codigo = textBox1.Text;
                            tp.Descricao = textBox2.Text;
                            tipoPagamentoDAL.Update(tp);
                        }
                        tipoPagamentoDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;
                case "TipoTransacaoBancaria":
                    {
                        if (lbID.Text == "0")
                        {
                            TipoTransacaoBancaria ttb = new TipoTransacaoBancaria();
                            ttb.Codigo = textBox1.Text;
                            ttb.Descricao = textBox2.Text;
                            TipoTBDAL.Insert(ttb);
                        }
                        else
                        {
                            TipoTransacaoBancaria ttb = TipoTBDAL.GetByID(Convert.ToInt32(lbID.Text));
                            ttb.Codigo = textBox1.Text;
                            ttb.Descricao = textBox2.Text;
                            TipoTBDAL.Update(ttb);
                        }

                        TipoTBDAL.Save();
                    } break;

                case "CodigoContratoComercial":
                    {
                        if (lbID.Text == "0")
                        {
                            CodigoContratoComercial tb = new CodigoContratoComercial();
                            tb.Codigo = textBox1.Text;
                            tb.Descricao = textBox2.Text;
                            codigoContratoComercialDAL.Insert(tb);
                        }
                        else
                        {
                            CodigoContratoComercial tb = codigoContratoComercialDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Codigo = textBox1.Text;
                            tb.Descricao = textBox2.Text;
                            codigoContratoComercialDAL.Update(tb);
                        }
                        codigoContratoComercialDAL.Save();
                    } break;

                case "CodigoServico":
                    {
                        if (lbID.Text == "0")
                        {
                            CodigoServico tb = new CodigoServico();
                            tb.Descricao = textBox1.Text;
                            CodigoServicoDAL.Insert(tb);
                        }
                        else
                        {
                            CodigoServico tb = CodigoServicoDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Descricao = textBox1.Text;
                            CodigoServicoDAL.Update(tb);
                        }
                        CodigoServicoDAL.Save();
                    } break;

                case "GrupoProducao":
                    {
                        if (lbID.Text == "0")
                        {
                            GrupoProducao tb = new GrupoProducao();
                            tb.Descricao = textBox1.Text;
                            GrupoProducaoDAL.Insert(tb);
                        }
                        else
                        {
                            GrupoProducao tb = GrupoProducaoDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Descricao = textBox1.Text;
                            GrupoProducaoDAL.Update(tb);
                        }
                        GrupoProducaoDAL.Save();
                    } break;

                case "ImpostoRetido":
                    {
                        if (lbID.Text == "0")
                        {
                            ImpostoRetido tb = new ImpostoRetido();
                            tb.Descricao = textBox1.Text;
                            impostoRetidoDAL.Insert(tb);
                        }
                        else
                        {
                            ImpostoRetido tb = impostoRetidoDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Descricao = textBox1.Text;
                            impostoRetidoDAL.Update(tb);
                        }
                        impostoRetidoDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;

                case "LinhaNegocio":
                    {
                        if (lbID.Text == "0")
                        {
                            LinhaNegocio ln = new LinhaNegocio();
                            ln.Nome = textBox1.Text;
                            ln.Descricao = textBox2.Text;
                            linhaNegocioDAL.Insert(ln);
                        }
                        else
                        {
                            LinhaNegocio ln = linhaNegocioDAL.GetByID(Convert.ToInt32(lbID.Text));
                            ln.Nome = textBox1.Text;
                            ln.Descricao = textBox2.Text;
                            linhaNegocioDAL.Update(ln);
                        }

                        linhaNegocioDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;

                case "VariantesConfig":
                    {
                        if (lbID.Text == "0")
                        {
                            VariantesConfig tb = new VariantesConfig();
                            tb.Descricao = textBox1.Text;
                            tb.Codigo = textBox2.Text;
                            VariantesConfigDAL.Insert(tb);
                        }
                        else
                        {
                            VariantesConfig tb = VariantesConfigDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Descricao = textBox1.Text;
                            tb.Codigo = textBox2.Text;
                            VariantesConfigDAL.Update(tb);
                        }
                        VariantesConfigDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;
                case "VariantesCor":
                    {
                        if (lbID.Text == "0")
                        {
                            VariantesCor tb = new VariantesCor();
                            tb.Codigo = textBox1.Text;
                            tb.Descricao = textBox2.Text;
                            VariantesCorDAL.Insert(tb);
                        }
                        else
                        {
                            VariantesCor tb = VariantesCorDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Codigo = textBox1.Text;
                            tb.Descricao = textBox2.Text;
                            VariantesCorDAL.Update(tb);
                        }
                        VariantesCorDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;
                case "VariantesEstilo":
                    {
                        if (lbID.Text == "0")
                        {
                            VariantesEstilo tb = new VariantesEstilo();
                            tb.Codigo = textBox1.Text;
                            tb.Descricao = textBox2.Text;
                            VariantesEstiloDAL.Insert(tb);
                        }
                        else
                        {
                            VariantesEstilo tb = VariantesEstiloDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Codigo = textBox1.Text;
                            tb.Descricao = textBox2.Text;
                            VariantesEstiloDAL.Update(tb);
                        }
                        VariantesEstiloDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;
                case "VariantesGrupo":
                    {
                        if (lbID.Text == "0")
                        {
                            VariantesGrupo tb = new VariantesGrupo();
                            tb.Descricao = textBox1.Text;
                            VariantesGrupoDAL.Insert(tb);
                        }
                        else
                        {
                            VariantesGrupo tb = VariantesGrupoDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Descricao = textBox1.Text;
                            VariantesGrupoDAL.Update(tb);
                        }
                        VariantesGrupoDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;
                case "VariantesTamanho":
                    {
                        if (lbID.Text == "0")
                        {
                            VariantesTamanho tb = new VariantesTamanho();
                            tb.Codigo = textBox1.Text;
                            tb.Descricao = textBox2.Text;
                            VariantesTamanhoDAL.Insert(tb);
                        }
                        else
                        {
                            VariantesTamanho tb = VariantesTamanhoDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Codigo = textBox1.Text;
                            tb.Descricao = textBox2.Text;
                            VariantesTamanhoDAL.Update(tb);
                        }
                        VariantesTamanhoDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;
                case "GrupoAlocacaoFrete":
                    {
                        if (lbID.Text == "0")
                        {
                            GrupoAlocacaoFrete tb = new GrupoAlocacaoFrete();
                            tb.Descricao = textBox1.Text;
                            GrupoAlocacaoFreteDAL.Insert(tb);
                        }
                        else
                        {
                            GrupoAlocacaoFrete tb = GrupoAlocacaoFreteDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Descricao = textBox1.Text;
                            GrupoAlocacaoFreteDAL.Update(tb);
                        }
                        GrupoAlocacaoFreteDAL.Save();
                    } break;
                case "GrupoCFOP":
                    {
                        if (lbID.Text == "0")
                        {
                            GrupoCFOP tb = new GrupoCFOP();
                            tb.Descricao = textBox1.Text;
                            grupoCFOPDAL.Insert(tb);
                        }
                        else
                        {
                            GrupoCFOP tb = grupoCFOPDAL.GetByID(Convert.ToInt32(lbID.Text));
                            tb.Descricao = textBox1.Text;
                            grupoCFOPDAL.Update(tb);
                        }
                        grupoCFOPDAL.Save(Util.Util.GetAppSettings("IdUsuario"));
                    } break;

            }
            LimpaCampos();
            CarregaDados();
            textBox1.Focus();

            Cursor.Current = Cursors.Default;
        }
        #endregion

        private void frmTabelas_Load(object sender, EventArgs e)
        {
            VinculaDados();
            CarregaDados();
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            dgv.AutoGenerateColumns = false;
            dgv.Rows.Clear();

            switch (Tabela)
            {
                case "Armazem":
                    {
                        var am = armazemDAL.Get().OrderBy(x => x.Nome).ToList();
                        foreach (var d in am) { dgv.Rows.Add(d.IdArmazem, d.Nome, d.Descricao); }
                    } break;
                case "AvaliacaoCredito":
                    {
                        var ac = avaliacaoCreditoDAL.Get().OrderBy(x => x.Nome).ToList();
                        foreach (var d in ac) { dgv.Rows.Add(d.IdAvaliacaoCredito, d.Nome, d.Valor); }
                    } break;
                case "Moeda":
                    {
                        var moedas = moedaDal.MRepository.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var m in moedas) { dgv.Rows.Add(m.IdMoeda, m.Descricao, m.Codigo); }
                    } break;
                case "CodigoIsencao":
                    {
                        var ci = codigoIsencaoDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in ci) { dgv.Rows.Add(d.IdCodigoIsencao, d.Codigo, d.Descricao); }
                    } break;
                case "ContaGerencial":
                    {
                        var cg = contaGerencialDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in cg) { dgv.Rows.Add(d.IdContaGerencial, d.Codigo, d.Descricao); }
                    } break;
                case "ContaPlanoReferencial":
                    {
                        var cpr = contaPRDAL.Get().OrderBy(x => x.Codigo).ToList();
                        foreach (var d in cpr) { dgv.Rows.Add(d.IdContaPlanoReferencial, d.Codigo, d.Descricao); }
                    } break;
                case "Departamento":
                    {
                        var dp = departamentoDAL.Get().OrderBy(x => x.Nome).ToList();
                        foreach (var d in dp) { dgv.Rows.Add(d.IdDepartamento, d.Nome, d.Descricao); }
                    } break;
                case "Deposito":
                    {
                        var dp = depositoDAL.Get().OrderBy(x => x.Nome).ToList();
                        foreach (var d in dp) { dgv.Rows.Add(d.IdDeposito, d.Nome, d.Descricao); }
                    } break;
                case "Especie":
                    {
                        var esp = especieDAL.Get().OrderBy(x => x.Nome).ToList();
                        foreach (var d in esp) { dgv.Rows.Add(d.IdEspecie, d.Nome, d.Descricao); }
                    } break;
                case "GrupoDesconto":
                    {
                        var tb = grupoDescontoDal.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdGrupoDescontos, d.Descricao); }
                    } break;
                case "GrupoEncargos":
                    {
                        var tb = GrupoEncargosDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdGrupoEncargos, d.Descricao); }
                    } break;
                case "GrupoItensSuplementares":
                    {
                        var tb = GrupoItensSuplementaresDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdGrupoItensSuplementares, d.Descricao); }
                    } break;
                case "GrupoComissao":
                    {
                        var gc = grupoComissaoDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in gc) { dgv.Rows.Add(d.IdGrupoComissao, d.Descricao); }
                    } break;

                case "GrupoCusto":
                    {
                        var tb = GrupoCustoDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdGrupoCusto, d.Descricao); }
                    } break;
                case "GrupoLancamento":
                    {
                        var tb = GrupoLancamentoDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdGrupoLancamento, d.Descricao); }
                    } break;
                case "GrupoProduto":
                    {
                        var gp = grupoProdutoDAL.Get().OrderBy(x => x.Nome).ToList();
                        foreach (var d in gp) { dgv.Rows.Add(d.IdGrupoProduto, d.Nome, d.Descricao); }
                    } break;
                case "Embalagem":
                    {
                        var tb = EmbalagemDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdEmbalagem, d.Descricao); }
                    } break;
                case "FormaPagamento":
                    {
                        var fp = formaPagamentoDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in fp) { dgv.Rows.Add(d.IdFormaPagamento, d.Codigo, d.Descricao); }
                    } break;
                case "GrupoImpostoItem":
                    {
                        var tb = grupoImpostoItemDAL.Get().OrderBy(x => x.Codigo).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdGrupoImpostoItem, d.Codigo, d.Descricao); }
                    } break;
                case "GrupoLotes":
                    {
                        var tb = GrupoLotesDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdGrupoLotes, d.Descricao); }
                    } break;
                case "GrupoSeries":
                    {
                        var tb = GrupoSeriesDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdGrupoSeries, d.Descricao); }
                    } break;
                case "TipoItem":
                    {
                        var tb = TipoItemDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdTipoItem, d.Descricao); }
                    } break;
                case "TipoPagamento":
                    {
                        var tp = tipoPagamentoDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tp) { dgv.Rows.Add(d.IdTipoPagamento, d.Codigo, d.Descricao); }
                    } break;
                case "TipoTransacaoBancaria":
                    {
                        var ttb = TipoTBDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in ttb) { dgv.Rows.Add(d.IdTipoTransacaoBancaria, d.Codigo, d.Descricao); }
                    } break;
                case "CodigoContratoComercial":
                    {
                        var tb = codigoContratoComercialDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdCodigoContratoComercial, d.Codigo, d.Descricao); }
                    } break;
                case "CodigoServico":
                    {
                        var tb = CodigoServicoDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdCodigoServico, d.Descricao); }
                    } break;
                case "GrupoProducao":
                    {
                        var tb = GrupoProducaoDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdGrupoProducao, d.Descricao); }
                    } break;
                case "ImpostoRetido":
                    {
                        var tb = impostoRetidoDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdImpostoRetido, d.Descricao); }
                    } break;
                case "LinhaNegocio":
                    {
                        var lns = linhaNegocioDAL.Get().OrderBy(x => x.Nome).ToList();
                        foreach (var ln in lns) { dgv.Rows.Add(ln.IdLinhaNegocio, ln.Nome, ln.Descricao); }
                    } break;
                case "VariantesConfig":
                    {
                        var tb = VariantesConfigDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdVariantesConfig, d.Descricao, d.Codigo); }
                    } break;
                case "VariantesCor":
                    {
                        var tb = VariantesCorDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdVariantesCor, d.Codigo, d.Descricao); }
                    } break;
                case "VariantesEstilo":
                    {
                        var tb = VariantesEstiloDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdVariantesEstilo, d.Codigo, d.Descricao); }
                    } break;
                case "VariantesGrupo":
                    {
                        var tb = VariantesGrupoDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdVariantesGrupo, d.Descricao); }
                    } break;
                case "VariantesTamanho":
                    {
                        var tb = VariantesTamanhoDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdVariantesTamanho, d.Codigo, d.Descricao); }
                    } break;
                case "GrupoAlocacaoFrete":
                    {
                        var tb = GrupoAlocacaoFreteDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdGrupoAlocacaoFrete, d.Descricao); }
                    } break;
                case "GrupoCFOP":
                    {
                        var tb = grupoCFOPDAL.Get().OrderBy(x => x.Descricao).ToList();
                        foreach (var d in tb) { dgv.Rows.Add(d.IdGrupoCFOP, d.Descricao); }
                    } break;
            }

            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Columns[0].Width = 400;
            dgv.Columns[1].Width = 300;
            if (dgv.ColumnCount == 3)
            {
                dgv.Columns[2].Width = 300;
            }
            else if (dgv.ColumnCount == 4)
            {
                dgv.Columns[3].Width = 400;
            }
            else if (dgv.ColumnCount == 5)
            {
                dgv.Columns[4].Width = 400;
            }

            Util.Aplicacao.DataGridViewAutosizeColumns(dgv);

            Cursor.Current = Cursors.Default;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            pnlNovo.Visible = true;
            textBox1.Focus();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaDados();
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            pnlNovo.Visible = false;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0 && e.RowIndex > -1)
            {
                lbID.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (dgv.Columns.Count > 2)
                {
                    if (dgv.Rows[e.RowIndex].Cells[2].Value != null)
                        textBox2.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                }
                pnlNovo.Visible = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString());
                    switch (Tabela)
                    {
                        case "Armazem": { armazemDAL.Delete(id); armazemDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "AvaliacaoCredito": { avaliacaoCreditoDAL.Delete(id); avaliacaoCreditoDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "Moeda": { moedaDal.MRepository.Delete(id); moedaDal.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "CodigoIsencao": { codigoIsencaoDAL.Delete(id); codigoIsencaoDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "ContaGerencial": { contaGerencialDAL.Delete(id); contaGerencialDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "ContaPlanoReferencial": { contaPRDAL.Delete(id); contaPRDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "Departamento": { departamentoDAL.Delete(id); departamentoDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "Deposito": { depositoDAL.Delete(id); depositoDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "Especie": { especieDAL.Delete(id); especieDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "FormaPagamento": { formaPagamentoDAL.Delete(id); formaPagamentoDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "GrupoComissao": { grupoComissaoDAL.Delete(id); grupoComissaoDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "GrupoCusto": { GrupoCustoDAL.Delete(id); GrupoCustoDAL.Save(); } break;
                        case "GrupoDesconto": { grupoDescontoDal.Delete(id); grupoDescontoDal.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "GrupoEncargos": { GrupoEncargosDAL.Delete(id); GrupoEncargosDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "GrupoItensSuplementares": { GrupoItensSuplementaresDAL.Delete(id); GrupoItensSuplementaresDAL.Save(); } break;
                        case "GrupoLancamento": { GrupoLancamentoDAL.Delete(id); GrupoLancamentoDAL.Save(); } break;
                        case "GrupoProduto": { grupoProdutoDAL.Delete(id); grupoProdutoDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "Embalagem": { EmbalagemDAL.Delete(id); EmbalagemDAL.Save(); } break;
                        case "GrupoImpostoItem": { grupoImpostoItemDAL.Delete(id); grupoImpostoItemDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "GrupoLotes": { GrupoLotesDAL.Delete(id); GrupoLotesDAL.Save(); } break;
                        case "GrupoSeries": { GrupoSeriesDAL.Delete(id); GrupoSeriesDAL.Save(); } break;
                        case "TipoItem": { TipoItemDAL.Delete(id); TipoItemDAL.Save(); } break;
                        case "TipoPagamento": { tipoPagamentoDAL.Delete(id); tipoPagamentoDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "TipoTransacaoBancaria": { TipoTBDAL.Delete(id); TipoTBDAL.Save(); } break;
                        case "CodigoContratoComercial": { codigoContratoComercialDAL.Delete(id); codigoContratoComercialDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "CodigoServico": { CodigoServicoDAL.Delete(id); CodigoServicoDAL.Save(); } break;
                        case "GrupoProducao": { GrupoProducaoDAL.Delete(id); GrupoProducaoDAL.Save(); } break;
                        case "ImpostoRetiro": { impostoRetidoDAL.Delete(id); impostoRetidoDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "LinhaNegocio": { linhaNegocioDAL.Delete(id); linhaNegocioDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "VariantesConfig": { VariantesConfigDAL.Delete(id); VariantesConfigDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "VariantesCor": { VariantesCorDAL.Delete(id); VariantesCorDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "VariantesEstilo": { VariantesEstiloDAL.Delete(id); VariantesEstiloDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "VariantesGrupo": { VariantesGrupoDAL.Delete(id); VariantesGrupoDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "VariantesTamanho": { VariantesTamanhoDAL.Delete(id); VariantesTamanhoDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                        case "GrupoAlocacaoFrete": { GrupoAlocacaoFreteDAL.Delete(id); GrupoAlocacaoFreteDAL.Save(); } break;
                        case "GrupoCFOP": { grupoCFOPDAL.Delete(id); grupoCFOPDAL.Save(Util.Util.GetAppSettings("IdUsuario")); } break;
                    }

                    CarregaDados();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowMessage("Não foi possível excluir o registro, verifique se ele não está sendo utilizado por outro processo." + "\n" + "\n" + "Erro: " + ex.Message);
                }
            }
        }

        private void frmTabelas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, Tabela + ".csv");
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            switch (Tabela)
            {
                case "Armazem":
                    {
                        var lst = armazemDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Armazéns", "Nome", "Descrição", "", "");
                    } break;
                case "AvaliacaoCredito":
                    {
                        var lst = avaliacaoCreditoDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Avaliação de Crédito", "Id", "Nome", "Valor", "");
                    } break;
                case "Moeda":
                    {
                        var lst = moedaDal.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Moedas", "Código", "Descrição", "", "");
                    } break;
                case "CodigoIsencao":
                    {
                        var lst = codigoIsencaoDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Código de Isenção", "Código", "Descrição", "", "");
                    } break;
                case "ContaGerencial":
                    {
                        var lst = contaGerencialDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Conta Gerencial", "Código", "Descrição", "", "");
                    } break;
                case "ContaPlanoReferencial":
                    {
                        var lst = contaPRDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Conta Plano Referencial", "Código", "Descrição", "Data Inicial", "Data Fim");
                    } break;
                case "Departamento":
                    {
                        var lst = departamentoDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Departamentos", "Nome", "Descrição", "", "");
                    } break;
                case "Deposito":
                    {
                        var lst = depositoDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Depósitos", "Nome", "Descrição", "", "");
                    } break;
                case "Especie":
                    {
                        var lst = especieDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Espécies", "Nome", "Descrição", "", "");
                    } break;
                case "GrupoDesconto":
                    {
                        var lst = grupoDescontoDal.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Grupo Desconto", "Descrição", "", "", "");
                    } break;
                case "GrupoEncargos":
                    {
                        var lst = GrupoEncargosDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Grupo Encargos", "Nome", "Descrição", "", "");
                    } break;
                case "GrupoItensSuplementares":
                    {
                        var lst = GrupoItensSuplementaresDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Grupo Itens Suplementares", "Descrição", "", "", "");
                    } break;
                case "GrupoComissao":
                    {
                        var lst = grupoComissaoDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Grupo Comissão", "Descrição", "", "", "");
                    } break;
                case "GrupoCusto":
                    {
                        var lst = GrupoCustoDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Grupo Custo", "Descrição", "", "", "");
                    } break;
                case "GrupoLancamento":
                    {
                        var lst = GrupoLancamentoDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Lançamento", "Descrição", "", "", "");
                    } break;
                case "GrupoProduto":
                    {
                        var lst = grupoProdutoDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Grupo Produto", "Nome", "Descrição", "", "");
                    } break;
                case "Embalagem":
                    {
                        var lst = EmbalagemDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Embalagem", "Descrição", "", "", "");
                    } break;
                case "FormaPagamento":
                    {
                        var lst = formaPagamentoDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Forma de Pagamento", "Código", "Descrição", "", "");
                    } break;
                case "GrupoImpostoItem":
                    {
                        var lst = grupoImpostoItemDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Grupo Impostos Item", "Código", "Descrição", "", "");
                    } break;
                case "GrupoLotes":
                    {
                        var lst = GrupoLotesDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Grupo Lotes", "Descrição", "", "", "");
                    } break;
                case "GrupoSeries":
                    {
                        var lst = GrupoSeriesDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Grupo Série", "Descrição", "", "", "");
                    } break;
                case "TipoItem":
                    {
                        var lst = TipoItemDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Tipo Item", "Descrição", "", "", "");
                    } break;
                case "TipoPagamento":
                    {
                        var lst = tipoPagamentoDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Tipo de Pagamento", "Código", "Descrição", "", "");
                    } break;
                case "TipoTransacaoBancaria":
                    {
                        var lst = TipoTBDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório de Tipo de Transação Bancária", "Código", "Descrição", "", "");
                    } break;
                case "CodigoContratoComercial":
                    {
                        var lst = codigoContratoComercialDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório Código Contrato Comercial", "Código", "Descrição", "", "");
                    } break;
                case "CodigoServico":
                    {
                        var lst = CodigoServicoDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório Código Serviço", "Código", "Nome", "Descrição", "");
                    } break;
                case "GrupoProducao":
                    {
                        var lst = GrupoProducaoDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório Grupo Produção", "Descrição", "", "", "");
                    } break;
                case "ImpostoRetido":
                    {
                        var lst = impostoRetidoDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório Imposto Retido", "Descrição", "", "", "");
                    } break;
                case "LinhaNegocio":
                    {
                        var lst = linhaNegocioDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório Linha de Negócio", "Nome", "Descrição", "", "");
                    } break;
                case "VariantesConfig":
                    {
                        var lst = VariantesConfigDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório Variantes Config", "Código", "Descrição", "", "");
                    } break;
                case "VariantesCor":
                    {
                        var lst = VariantesCorDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório Variantes Cor", "Código", "Descrição", "", "");
                    } break;
                case "VariantesEstilo":
                    {
                        var lst = VariantesEstiloDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório Variantes Estilo", "Código", "Descrição", "", "");
                    } break;
                case "VariantesGrupo":
                    {
                        var lst = VariantesGrupoDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório Variantes Grupo", "Descrição", "", "", "");
                    } break;
                case "VariantesTamanho":
                    {
                        var lst = VariantesTamanhoDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório Variantes Tamanho", "Código", "Descrição", "", "");
                    } break;
                case "GrupoAlocacaoFrete":
                    {
                        var lst = GrupoAlocacaoFreteDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório Grupo Alocação Frete", "Descrição", "", "", "");
                    } break;
                case "GrupoCFOP":
                    {
                        var lst = grupoCFOPDAL.GetDataReport();
                        dt = Util.Aplicacao.GenericReportDataTable(lst);
                        ShowReport(dt, "Relatório Grupo CFOP", "Descrição", "", "", "");
                    } break;
            }
        }

        private static void ShowReport(DataTable dt, string prtTitulo, string prtTexto1, string prtTexto2, string prtTexto3, string prtTexto4)
        {
            if (dt.Rows.Count > 0)
            {
                frmReportTabelas r = new frmReportTabelas(dt, prtTitulo, prtTexto1, prtTexto2, prtTexto3, prtTexto4);
                r.ShowDialog();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Não existe dados para gerar o relatório!");
            }
        }
    }
}
