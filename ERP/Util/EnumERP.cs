using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Util
{
    public static class EnumERP
    {
        public enum SimNao
        {
            Sim = 1,
            Não = 2
        }

        public enum TipoPrograma
        {
            Formulario = 1,
            Cadastro = 2,
            Relatorio = 3
        }

        public static List<DropList> CarregarTipoPrograma()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(TipoPrograma));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum TipoPessoa
        {
            Física = 1,
            Jurídica = 2,
            Estrangeira = 3
        }

        public static List<DropList> CarregarTipoPessoa()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(TipoPessoa));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum Bloqueado
        {
            Não = 1,
            Fatura = 2,
            Tudo = 3,
            Pagamento = 4
        }

        public static List<DropList> CarregarBloqueado()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(Bloqueado));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum Suspenso
        {
            Não = 1,
            Fatura = 2,
            Tudo = 3,
            Pagamento = 4
        }

        public static List<DropList> CarregarSuspenso()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(Suspenso));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }


        public enum PropostaDECR
        {
            Débito = 1,
            Crédito = 2
        }

        public static List<DropList> CarregarPropostaDECR()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(PropostaDECR));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum VendaMarkup
        {
            [Description("Nenhum")]
            Nenhum = 1,
            [Description("Índice De Contribuição")]
            IndiceDeContribuicao = 2,
            [Description("Percentual Encargos ")]
            PercentualEncargos = 3
        }

        public static List<DropList> CarregarVendaMarkup()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(VendaMarkup));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum VendaUsarProdutoAlternativo
        {
            [Description("Sempre")]
            Sempre = 1,
            [Description("Sem Estoque")]
            SemEstoque = 2,
            [Description("Nunca")]
            Nunca = 3
        }

        public enum VendaAtualizaPrecoBase
        {
            [Description("Preço de Compra")]
            PrecoCompra = 1,
            [Description("Custo")]
            Custo = 2
        }

        public enum ProducaoLiberacao
        {
            [Description("Início")]
            Inicio = 1,
            [Description("Conclusão")]
            Conclusao = 2,
            [Description("Manual")]
            Manual = 3
        }

        public enum ProducaoTipoProducao
        {
            [Description("Nenhum")]
            Nenhum = 1,
            [Description("Co-Produto")]
            CoProduto = 2,
            [Description("Sub-Produto")]
            SubProduto = 3,
            [Description("Item de planejamento")]
            ItemDePlanejamento = 4,
            [Description("BOM")]
            BOM = 5,
            [Description("Fórmula")]
            Formula = 6
        }

        public enum CustoABC
        {
            [Description("A")]
            A = 1,
            [Description("B")]
            B = 2,
            [Description("C")]
            C = 3
        }

        public enum ParametrosParaCalculo
        {
            [Description("Porcentagem do Valor Líquido")]
            PorcentagemDoValorLiquido = 1,
            [Description("Porcentagem do Valor Bruto")]
            PorcentagemDoValorBruto = 2,
            [Description("Porcentagem do Imposto")]
            PorcentagemDoImposto = 3,
            [Description("Valor por Unidade")]
            ValorPorUnidade = 4,
            [Description("Porcentagem do Valor Líquido Calculada")]
            PorcentagemDoValorLiquidoCalculada = 5,
            [Description("Porcentagem do Valor Bruto no Mês")]
            PorcentagemDoValorBrutoMês = 6
        }

        public static List<DropList> CarregarParametrosParaCalculo()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(ParametrosParaCalculo));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum BaseMarginal
        {
            [Description("Valor Líquido por Linha")]
            ValorLiquidoPorLinha = 1,
            [Description("Valor Líquido por Unidade")]
            ValorLiquidoPorUnidade = 2,
            [Description("Valor Líquido do Saldo da Fatura")]
            ValorLiquidoDoSaldoDaFatura = 3,
            [Description("Valor Bruto por Linha")]
            ValorBrutoPorLinha = 4,
            [Description("Valor Bruto por Unidade")]
            ValorBrutoPorUnidade = 5,
            [Description("Total da Fatura Incluindo Outros Valores de Imposto")]
            TotalDaFaturaIncluindoOutrosCaloresDeImposto = 6
        }

        public static List<DropList> CarregarBaseMarginal()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(BaseMarginal));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum MetodoCalculo
        {
            [Description("Intervalo")]
            Intervalo = 1,
            [Description("Valor Total")]
            ValorTotal = 2
        }

        public static List<DropList> CarregarMetodoCalculo()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(MetodoCalculo));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum DataDoCalculo
        {
            [Description("Data de Lançamento")]
            DataDeLançamento = 1,
            [Description("Data do Documento")]
            DataDoDocumento = 2
        }

        public static List<DropList> CarregarDataDoCalculo()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(DataDoCalculo));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum TipoImposto
        {
            [Description("PCC")]
            PCC = 1,
            [Description("PIS")]
            PIS = 2,
            [Description("COFINS")]
            COFINS = 3,
            [Description("CSLL")]
            CSLL = 4,
            [Description("IR")]
            IR = 5,
            [Description("ISS")]
            ISS = 6,
            [Description("Outros")]
            Outros = 7,
            [Description("Nenhum")]
            Nenhum = 8
        }

        public static List<DropList> CarregarTipoImposto()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(TipoImposto));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum MetodoSustituicaoTributaria
        {
            [Description("Preço tabelado ou máximo sugerido")]
            PrecoTabeladoMaximoSugerido = 0,
            [Description("Lista Negativa - Valor")]
            ListaNegativa = 1,
            [Description("Lista Positiva - Valor")]
            ListaPositiva = 2,
            [Description("Lista Neutra - Valor")]
            ListaNeutra = 3,
            [Description("Margem Valor Agregado (%) - Markup")]
            MargemValorAgregado = 4,
            [Description("Pauta - Valor")]
            Pauta = 5,
            [Description("Nenhum")]
            Nenhum = 6, 
        }

        public static List<DropList> CarregarMetodoSustituicaoTributaria()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(MetodoSustituicaoTributaria));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum ValorFiscal
        {
            [Description("Com Crédito/Débito")]
            ComCréditoDébito = 1,
            [Description("Sem Crédito/Débito (Isento ou Não Tributável)")]
            SemCréditoDébito = 2,
            [Description("Sem Crédito/Débito (Outros)")]
            SemCréditoDébitoOutros = 3
        }

        public static List<DropList> CarregarValorFiscal()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(ValorFiscal));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum IntervaloDoPeriodo
        {
            [Description("Dias")]
            Dias = 1,
            [Description("Meses")]
            Meses = 2,
            [Description("Anos")]
            Anos = 3
        }

        public static List<DropList> CarregarIntervaloDoPeriodo()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(IntervaloDoPeriodo));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum AutoridadesAgencia
        {
            [Description("Justiça Federal")]
            JusticaFederal = 1,
            [Description("Justiça Estadual")]
            JustiçaEstadual = 2,
            [Description("Secex/RFB")]
            SecexRFB = 3,
            [Description("Sefaz")]
            Sefaz = 4,
            [Description("Outros")]
            Outros = 5
        }

        public static List<DropList> CarregarAutoridadesAgencia()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(AutoridadesAgencia));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum AutoridadesFormaDeArredondamento
        {
            [Description("Normal")]
            Normal = 1,
            [Description("Para Baixo")]
            ParaBaixo = 2,
            [Description("Vantagem Própria")]
            VantagemPropria = 3
        }

        public static List<DropList> CarregarAutoridadesFormaDeArredondamento()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(AutoridadesFormaDeArredondamento));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum CalculoDeComissaoRelacaoDeItem
        {
            [Description("Tabela")]
            Tabela = 1,
            [Description("Grupo")]
            Grupo = 2,
            [Description("Todos")]
            Todos = 3
        }

        public static List<DropList> CarregarRelacaoDeItem()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(CalculoDeComissaoRelacaoDeItem));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum RelacaoAoGrupo
        {
            [Description("Grupo")]
            Grupo = 1,
            [Description("Tabela")]
            Tabela = 2,
            [Description("Todos")]
            Todos = 3
        }

        public static List<DropList> CarregarRelacaoAoGrupo()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(RelacaoAoGrupo));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum CalculoDeComissaoDesconto
        {
            [Description("Antes do Desconto de Linha")]
            AntesDoDescontoDeLinha = 1,
            [Description("Depois do Desconto de Linha")]
            DepoisDoDescontoDeLinha = 2,
            [Description("Depois do Desconto Total")]
            DepoisDoDescontoTotal = 3
        }

        public static List<DropList> CarregarCalculoDeComissaoDesconto()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(CalculoDeComissaoDesconto));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum CalculoDeComissaoAplicacao
        {
            [Description("Receita")]
            Receita = 1,
            [Description("Margem")]
            Margem = 2
        }

        public static List<DropList> CarregarCalculoDeComissaoAplicacao()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(CalculoDeComissaoAplicacao));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum CalculoDeComissaoPagamento
        {
            [Description("Faturamento")]
            Faturamento = 1,
            [Description("Vencimento")]
            Vencimento = 2
        }

        public static List<DropList> CarregarCalculoDeComissaoPagamento()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(CalculoDeComissaoPagamento));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum TipoComissao
        {
            [Description("Comissão")]
            Comissao = 1,
            [Description("Comissão Adicional")]
            ComissaoAdicional = 2,
            [Description("Choque")]
            ComissaoExtra = 3
        }

        public static List<DropList> CarregarTipoComissao()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(TipoComissao));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }
        
        public enum EncargosAutomaticosCategoria
        {
            [Description("Fixo")]
            Fixo = 1,
            [Description("Peças")]
            Peças = 2,
            [Description("Porcentagem")]
            Porcentagem = 3
        }

        public enum EncargosAutomaticosRelacaoDeItem
        {
            [Description("Tabela")]
            Tabela = 1,
            [Description("Grupo")]
            Grupo = 2,
            [Description("Todos")]
            Todos = 3
        }

        public enum EncargosAutomaticosRelacaoAoGrupo
        {
            [Description("Grupo")]
            Grupo = 1,
            [Description("Tabela")]
            Tabela = 2,
            [Description("Todos")]
            Todos = 3
        }

        public enum CodigoDeEncargosTipo
        {
            [Description("Frete")]
            Frete = 1,
            [Description("Seguro")]
            Seguro = 2,
            [Description("Siscomex")]
            Siscomex = 3,
            [Description("Cota Patronal")]
            CotaPatronal = 4,
            [Description("Outros Encargos")]
            OutrosEncargos = 5
        }

        public static List<DropList> CarregarCodigoDeEncargosTipo()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(CodigoDeEncargosTipo));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum CodigoDeEncargosLancamentoTipo
        {
            [Description("Item")]
            Item = 1,
            [Description("Conta Contábil")]
            ContaContabil = 2,
            [Description("Fornecedor/Cliente")]
            FornecedorCliente = 3
        }

        public static List<DropList> CarregarCodigoDeEncargosLancamentoTipo()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(CodigoDeEncargosLancamentoTipo));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum CodigoDeJurosDiaMes
        {
            [Description("Dia")]
            Dia = 1,
            [Description("Mês")]
            Mes = 2
        }

        public static List<DropList> CarregarCodigoDeJurosDiaMes()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(CodigoDeJurosDiaMes));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum CondicoesEncargoDeFrete
        {
            [Description("Não Aplicavel")]
            NãoAplicavel = 1,
            [Description("NA Terceiro Cobrar")]
            NATerceiroCobrar = 2,
            [Description("Principal")]
            Principal = 3,
            [Description("Complemento e Manuseio")]
            ComplementoManuseio = 4,
            [Description("Principal, Complemento e Manuseio")]
            PrincipalComplementoManuseio = 5
        }

        public static List<DropList> CarregarCondicoesEncargoDeFrete()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(CondicoesEncargoDeFrete));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum ModoEntregaServicos
        {
            [Description("Diversos")]
            Diversos = 1,
            [Description("Terestre")]
            Terestre = 2,
            [Description("Aereo")]
            Aereo = 3,
            [Description("Retirada")]
            Retirada = 4
        }

        public static List<DropList> CarregarModoEntregaServicos()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(ModoEntregaServicos));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum PlanoPagamentoTipoDeDistribuicao
        {
            [Description("Total")]
            Total = 1,
            [Description("Quantidade Fixa")]
            QuantidadeFixa = 2,
            [Description("Valor Fixo")]
            ValorFixo = 3,
            [Description("Especificado")]
            Especificado = 4
        }

        public static List<DropList> CarregarTipoDeDistribuicao()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(PlanoPagamentoTipoDeDistribuicao));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum PlanoPagamentoPagamentoPor
        {
            [Description("Dias")]
            Dias = 1,
            [Description("Mês")]
            Mes = 2,
            [Description("Ano")]
            Ano = 3
        }

        public static List<DropList> CarregarPagamentoPor()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(PlanoPagamentoPagamentoPor));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum PlanoPagamentoAlocacaoImpostos
        {
            [Description("Porpocional")]
            Porpocional = 1,
            [Description("Primeira Prestação")]
            PrimeiraPrestacao = 2,
            [Description("Última Prestação")]
            UltimaPrestacao = 3
        }

        public static List<DropList> CarregarAlocacaoImpostos()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(PlanoPagamentoAlocacaoImpostos));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum PlanoPagamentoPorcentagemValor
        {
            [Description("Porcentagem")]
            Porcentagem = 1,
            [Description("Valor")]
            Valor = 2
        }

        public static List<DropList> CarregarPorcentagemValor()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(PlanoPagamentoPorcentagemValor));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum CondicaoPagamentoMetodoPagamento
        {
            [Description("Líquido")]
            Liquido = 1,
            [Description("Mês")]
            Mes = 2,
            [Description("Trimestal")]
            Trimestal = 3,
            [Description("Anual")]
            Anual = 4,
            [Description("Semanal")]
            Semanal = 5,
            [Description("C.O.D")]
            COD = 6,
            [Description("Dia de Fechamento")]
            DiaFechamento = 7
        }

        public static List<DropList> CarregarMetodoPagamento()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(CondicaoPagamentoMetodoPagamento));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum MetodoPagamentoPeriodo
        {
            [Description("Fatura")]
            Fatura = 1,
            [Description("Data")]
            Data = 2,
            [Description("Semana")]
            Semana = 3,
            [Description("Total")]
            Total = 4
        }

        public static List<DropList> CarregarMetodoPagamentoPeriodo()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(MetodoPagamentoPeriodo));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum MetodoPagamentoStatusDoPagamento
        {
            [Description("Nenhum")]
            Nenhum = 1,
            [Description("Enviado")]
            Enviado = 2,
            [Description("Recebido")]
            Recebido = 3,
            [Description("Aprovado")]
            Aprovado = 4,
            [Description("Rejeitado")]
            Rejeitado = 5
        }

        public static List<DropList> CarregarMetodoPagamentoStatusDoPagamento()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(MetodoPagamentoStatusDoPagamento));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum MetodoPagamentoTipoDePagamento
        {
            [Description("Outros")]
            Outros = 1,
            [Description("Letra de Câmbio")]
            LetraCambio = 2,
            [Description("Cheque")]
            Cheque = 3,
            [Description("Cartão")]
            Cartao = 4,
            [Description("Pagamento Eletrônico")]
            PagamentoEletronico = 5,
            [Description("Cheque de Terceiros")]
            ChequeTerceiros = 6
        }

        public static List<DropList> CarregarMetodoPagamentoTipoDePagamento()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(MetodoPagamentoTipoDePagamento));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum MetodoPagamentoTipoDeConta
        {
            [Description("Razão")]
            Razão = 1,
            [Description("Cliente")]
            Cliente = 2,
            [Description("Fornecedor")]
            Fornecedor = 3,
            [Description("Banco")]
            Banco = 4
        }

        public static List<DropList> CarregarMetodoPagamentoTipoDeConta()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(MetodoPagamentoTipoDeConta));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum DiasDePagamentoSemanaMes
        {
            [Description("Dias")]
            Dias = 1,
            [Description("Semana")]
            Semana = 2
        }

        public static List<DropList> CarregarSemanaMes()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(DiasDePagamentoSemanaMes));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum DiasDePagamentoDiaDaSemana
        {
            [Description("Segunda-Feira")]
            SegundaFeira = 1,
            [Description("Terça-Feira")]
            TerçaFeira = 2,
            [Description("Quarta-Feira")]
            QuartaFeira = 3,
            [Description("Quinta-Feira")]
            QuintaFeira = 4,
            [Description("Sexta-Feira")]
            SextaFeira = 5,
            [Description("Sábado")]
            Sabado = 6,
            [Description("Domingo")]
            Domingo = 7
        }

        public static List<DropList> CarregarDiaDaSemana()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(DiasDePagamentoDiaDaSemana));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum EspecificacaoDePagamentoControleDeExportacao
        {
            [Description("Conta Bancária Fornecedor")]
            ContabancariaFornecedor = 1,
            [Description("Código de Barras")]
            Codigodebarras = 2
        }

        public static List<DropList> CarregarControleDeExportacao()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(EspecificacaoDePagamentoControleDeExportacao));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        public enum TipodeTransacao
        {
            [Description("Compra")]
            Compra = 1,
            [Description("Venda")]
            Venda = 2,
            [Description("Ambos")]
            Ambos = 3
        }

        public static List<DropList> CarregarTipodeTransacao()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(TipodeTransacao));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum TipodeLocalizacao
        {
            [Description("Local de Separação")]
            LocalDeSeparacao = 1,
            [Description("Doca de Entrada")]
            DocaDeEntrada = 2,
            [Description("Doca de Saída")]
            DocaDeSaida = 3,
            [Description("Local de Entrada de Produção")]
            LocalEntradaProducao = 4,
            [Description("Local de Inspeção")]
            LocalDeInspecao = 5
        }

        public static List<DropList> CarregarTipodeLocalizacao()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(TipodeLocalizacao));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum Restricao
        {
            [Description("Externo")]
            Externo = 1,
            [Description("Interno")]
            Interno = 2
        }

        public static List<DropList> CarregarRestricao()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(Restricao));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum TipoTransacao
        {
            [Description("Compra")]
            Compra = 1,
            [Description("Venda")]
            Venda = 2,
            [Description("Devolução")]
            Devolucao = 3,
            [Description("Transferência entre Empresas")]
            TransferenciaEntreEmpresas = 4,
            [Description("Remessa")]
            Remessa = 5
        }

        public static List<DropList> CarregarTipoTransacao()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(TipoTransacao));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum MetodoCalculoDepreciacao
        {
            [Description("Vida Útil Linear")]
            VidaUtilLinear = 1,
            [Description("Vida Útil Linear Restante")]
            VidaUtilLinearRestante = 2,
            [Description("Fator")]
            Fator = 3
        }

        public static List<DropList> CarregarMetodoCalculoDepreciacao()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(MetodoCalculoDepreciacao));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum FrequenciaDepreciacao
        {
            [Description("Anual")]
            Anual = 1,
            [Description("Mensal")]
            Mensal = 2,
            [Description("Trimestral")]
            Trimestral = 3,
            [Description("Semestral")]
            Semestral = 4
        }

        public static List<DropList> CarregarFrequenciaDepreciacao()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(FrequenciaDepreciacao));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum BasePercentual
        {
            [Description("Percentual do valor bruto no mês")]
            PercentualValorBrutoMes = 1,
            [Description("Percentual do valor bruto")]
            PercentualValorBruto = 2,
            [Description("Percentual do valor Líquido")]
            PercentualValorLiquido = 3
        }

        public static List<DropList> CarregarBasePercentual()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(BasePercentual));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum FormaDeArredondamento
        {
            [Description("Normal")]
            Normal = 1,
            [Description("Para Baixo")]
            ParaBaixo = 2
        }

        public static List<DropList> CarregarFormaDeArredondamento()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(FormaDeArredondamento));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum DescontoAVistaCalculo
        {
            [Description("Líquido")]
            Liquido = 1,
            [Description("Mês Atual")]
            MesAtual = 2,
            [Description("Trimestre Atual")]
            TrimestreAtual = 3,
            [Description("Ano Atual")]
            AnoAtual = 4,
            [Description("Semana Atual")]
            SemanaAtual = 5
        }

        public static List<DropList> CarregarDescontoAVistaCalculo()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(DescontoAVistaCalculo));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum NivelDeLancamento
        {
            [Description("Atual")]
            Atual = 1,
            [Description("Operação")]
            Operacao = 2,
            [Description("Impostos")]
            Impostos = 3
        }

        public static List<DropList> CarregarNivelDeLancamento()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(NivelDeLancamento));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum Convencao
        {
            [Description("Semestre")]
            Semestre = 1,
            [Description("Meio do Mês ( Primeiro dia)")]
            PrimeiroDia = 2,
            [Description("Meio do Mês ( Decimo quinto dia)")]
            DecimoQuintoDia = 3,
            [Description("Mês inteiro")]
            MesInteiro = 4,
            [Description("Meio do trimeste")]
            MeioTrimestre = 5,
            [Description("Semestre (início)")]
            SemestreInicio = 6,
            [Description("Semestre (próximo ano)")]
            SemestreProximoAno = 7
        }

        public static List<DropList> CarregarConvencao()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(Convencao));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum Reducao
        {
            [Description("Percentual Chave")]
            PercentualChave = 1,
            [Description("Transações Chave")]
            TransacoesChave = 2,
            [Description("Transações Período Dinâmico")]
            TransacoesPeriodoDinamico = 3
        }

        public static List<DropList> CarregarReducao()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(Reducao));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum Cobertura
        {
            [Description("Período")]
            Periodo = 1,
            [Description("Necessidade")]
            Necessidade = 2,
            [Description("Mín e Máx")]
            MinMax = 3,
            [Description("Manual")]
            Manual = 4
        }

        public static List<DropList> CarregarCobertura()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(Cobertura));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum StatusProducao
        {
            [Description("Criado")]
            Criado = 1,
            [Description("Previsto")]
            Previsto = 2,
            [Description("Progrado")]
            Progrado = 3,
            [Description("Liberada")]
            Liberada = 4,
            [Description("Iniciada")]
            Iniciada = 5,
            [Description("Informada como Conluída")]
            InformadaComoConcluida = 6,
            [Description("Conluída")]
            Concluida = 7
        }

        public static List<DropList> CarregarStatusProducao()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(StatusProducao));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum ReduzirPrevisao
        {
            [Description("Ordens")]
            Ordens = 1,
            [Description("Todas as Transações")]
            TodasAsTransacoes = 2
        }

        public static List<DropList> CarregarReduzirPrevisao()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(ReduzirPrevisao));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum TipoGrupoAtivo
        {
            [Description("Tângivel")]
            Tangivel = 1,
            [Description("Intângivel")]
            Intangivel = 2,
            [Description("Financeiro")]
            Financeiro = 3,
            [Description("Terrenos e Edifícios")]
            TerrenosEdificio = 4,
            [Description("Reputação da empresa")]
            ReputacaoDaEmpresa = 5,
            [Description("Outros")]
            Outros = 6
        }

        public static List<DropList> CarregarTipoGrupoAtivo()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(TipoGrupoAtivo));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum TipoPropriedade
        {
            [Description("Ativo Fixo")]
            AtivoFixo = 1,
            [Description("Propiedade duradora")]
            PropiedadeDuradora = 2,
            [Description("Outros")]
            Outros = 3
        }

        public static List<DropList> CarregarTipoPropriedade()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(TipoPropriedade));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum TipoConta
        {
            [Description("Despesa de compra, não faturada")]
            DespesaCompraNaoFaturada = 1,
            [Description("Compra, recebimento de estoque")]
            CompraRecebimentoEstoque = 2,
            [Description("Despesa de compra para produto")]
            DespesaCompraParaProduto = 3,
            [Description("Compra, desconto")]
            CompraDesconto = 4,
            [Description("Estoque, saída")]
            EstoqueSaída = 5,
            [Description("Estoque, perda")]
            EstoquePerda = 6,
            [Description("Estoque, recebimento de")]
            EstoqueRecebimento = 7,
            [Description("Estoque, lucro")]
            EstoqueLucro = 8,
            [Description("Ordem de venda, saída da")]
            OrdemVendaSaida = 9,
            [Description("Ordem de venda, consumo da")]
            OrdemVendaConsumo = 10,
            [Description("Encargo")]
            Encargo = 11,
            [Description("Variação de estoque")]
            VariacaoEstoque = 12,
            [Description("Pagamento antecipado")]
            PagamentoAntecipado = 13,
            [Description("Despesa de compra para despesa")]
            DespesaCompraParaDespesa = 14
        }

        public static List<DropList> CarregarTipoConta()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(TipoConta));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum TipoContaAtivo
        {
            [Description("Ajuste de Aquisição")]
            AjusteAquisicao = 1,
            [Description("Ajuste de Depreciação")]
            AjusteDepreciacao = 2,
            [Description("Ajuste de Desvalorização")]
            AjusteDesvalorizacao = 3,
            [Description("Ajuste de Valorização")]
            AjusteValorizacao = 4,
            [Description("Alienação - Sucata")]
            AlienacaoSucata = 5,
            [Description("Alienação - Venda")]
            AlienacaoVenda = 6,
            [Description("Aquisição")]
            Aquisicao = 7,
            [Description("Depreciação")]
            Depreciacao = 8,
            [Description("Reavaliação")]
            Reavaliacao = 9,
            [Description("Tipo de transação")]
            TipoTransacao = 10
        }

        public static List<DropList> CarregarTipoContaAtivo()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(TipoContaAtivo));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum RelacaoAtivo
        {
            [Description("Tabela")]
            Tabela = 1,
            [Description("Grupo")]
            Grupo = 2,
            [Description("Todos")]
            Todos = 3
        }

        public static List<DropList> CarregarRelacaoAtivo()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(RelacaoAtivo));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum GrupoAtivo
        {
            [Description("Grupo")]
            Grupo = 1,
            [Description("Tabela")]
            Tabela = 2,
            [Description("Todos")]
            Todos = 3
        }

        public static List<DropList> CarregarGrupoAtivo()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(GrupoAtivo));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum Operacao
        {
            [Description("Perda")]
            Perda = 1,
            [Description("Lucro")]
            Lucro = 2,
            [Description("Todos")]
            Todos = 3
        }

        public static List<DropList> CarregarOperacao()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(Operacao));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum RelacaoContratoComercial
        {
            [Description("Preço de Compra")]
            PrecoDeCompra = 1,
            [Description("Desconto de linha (Compras)")]
            DescontoDeLinhaCompras = 2,
            [Description("Desconto Combinado (Compras)")]
            DescontoCombinadoCompras = 3,
            [Description("DescontoTotal (Compras)")]
            DescontoTotalCompras = 4,
            [Description("Preço de Venda")]
            PrecoDeVenda = 5,
            [Description("Desconto de linha (Vendas)")]
            DescontoDeLinhaVendas = 6,
            [Description("Desconto Combinado (Vendas)")]
            DescontoCombinadoVendas = 7,
            [Description("Desconto Total (Vendas)")]
            DescontoTotalVendas = 8,
            [Description("Desconto Varejista")]
            DescontoVarejista = 9
        }

        public static List<DropList> CarregarRelacaoContratoComercial()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(RelacaoContratoComercial));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum TipoAjusteContrato
        {
            [Description("Valor")]
            Valor = 1,
            [Description("Percentual em Valor")]
            PercentualEmValor = 2,
            [Description("Percentual")]
            Percentual = 3,
            [Description("Percentual em Percentual")]
            PercentualEmPercentual = 4
        }


        public static List<DropList> CarregarTipoAjusteContrato()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(TipoAjusteContrato));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum TipoGrupoPrecoDesconto
        {
            [Description("Grupo de preços")]
            GrupoPreços = 1,
            [Description("Grupo desconto de linha")]
            GrupoDescontoLinha = 2,
            [Description("Grupo desconto combinado")]
            GrupoDescontoCombinado = 3,
            [Description("Grupo desconto total")]
            GrupoDescontoTotal = 4,
            [Description("Grupo desconto varejo")]
            GrupoDescontoVarejo = 5
        }

        public static List<DropList> CarregarTipoGrupoPrecoDesconto()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(TipoGrupoPrecoDesconto));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum ModeloEstoque
        {
            [Description("PEPS")]
            PEPS = 1,
            [Description("UEPS")]
            UEPS = 2,
            [Description("Média Ponderada")]
            MediaPonderada = 3
        }

        public static List<DropList> CarregarModeloEstoque()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(ModeloEstoque));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum ModuloGrupoPrecoDesconto
        {
            [Description("Compras")]
            Compras = 1,
            [Description("Vendas")]
            Vendas = 2,
            [Description("Produto")]
            Produto = 3
        }

        public static List<DropList> CarregarModuloGrupoPrecoDesconto()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(ModuloGrupoPrecoDesconto));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum Meses
        {
            [Description("Janeiro")]
            Janeiro = 1,
            [Description("Fevereiro")]
            Fevereiro = 2,
            [Description("Março")]
            Marco = 3,
            [Description("Abril")]
            Abril = 4,
            [Description("Maio")]
            Maio = 5,
            [Description("Junho")]
            Junho = 6,
            [Description("Julho")]
            Julho = 7,
            [Description("Agosto")]
            Agosto = 8,
            [Description("Setembro")]
            Setembro = 9,
            [Description("Outubro")]
            Outubro = 10,
            [Description("Novembro")]
            Novembro = 11,
            [Description("Dezembro")]
            Dezembro = 12
        }

        public static List<DropList> CarregarMeses()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(Meses));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum StatusPedido
        {
            [Description("Em Aberto")]
            Aberto = 1,
            [Description("Separação")]
            Separacao = 2,
            [Description("A Faturar")]
            AFaturar = 3,
            [Description("Faturado")]
            Faturado = 4,
            [Description("Faturado Parcialmente")]
            FaturadoParcial = 5,
            [Description("Cancelado")]
            Cancelado = 6,
            [Description("Saldo Cancelado")]
            SaldoCancelado = 7
        }

        #region CFOP
        public enum Localizacao
        {
            [Description("Mesmo Estado")]
            MesmoEstado = 1,
            [Description("Fora do Estado")]
            ForaDoEstado = 2,
            [Description("Fora do País/Região")]
            ForaDoPaisRegiao = 3
        }

        public static List<DropList> CarregarLocalizacao()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(Localizacao));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum Direcao
        {
            [Description("Entrada")]
            Entrada = 1,
            [Description("Saída")]
            Saida = 2
        }

        public static List<DropList> CarregarDirecao()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(Direcao));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }

        public enum Finalidade
        {
            [Description("Nenhum")]
            Nenhum = 1,
            [Description("Transferência entre Empresas")]
            TransferenciaEntreEmpresas = 2,
            [Description("Remessa")]
            Remessa = 3,
            [Description("Devolução")]
            Devolucao = 4
        }

        public static List<DropList> CarregarFinalidade()
        {
            //Get attributes from the enum
            Array enumValueArray = Enum.GetValues(typeof(Finalidade));
            List<DropList> lista = new List<DropList>();

            foreach (Enum enumValue in enumValueArray)
            {
                object value = Convert.ChangeType(enumValue, enumValue.GetTypeCode());

                DropList d = new DropList();
                d.Text = GetEnumDescription(enumValue);
                d.Value = value.ToString();
                lista.Add(d);
            }

            return lista;
        }
        #endregion
    }
}
