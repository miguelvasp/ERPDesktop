using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Models;
using ERP.DAL;
using ERP.Util; 
using Impactro.Cobranca;
using Impactro.Layout;
using Impactro.WindowsControls;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;

namespace ERP.BLL
{
    public class BLBoletoBancario
    {
        public BoletoBancarioDAL dal = new BoletoBancarioDAL();
        public BLBoletoBancario()
        {

        }
        /// <summary>
        /// Gera o boleto temporario a partir de uma conta a receber
        /// </summary>
        /// <param name="IdRecebimento"></param>
        /// <returns></returns>
        public void GeraBoletoContasReceber(int IdContasReceber, int IdContaBancaria)
        {
            //verifica se já existem boletos para esse recebimento
            var achados = dal.getByIdConta(IdContasReceber); 
            if(achados != null && achados.Count > 0)
            {
                return;
            }

            //CALCULA O NOSSO NUMERO
            // NF + NUMERO PARCELA
            string NNumero = "";
            var nf = new NotaFiscalDAL().getNFNumeroByContaReceber(IdContasReceber);
            ContasReceberAbertoDAL crdal = new ContasReceberAbertoDAL();

            var lista = crdal.getByIdConta(IdContasReceber);
            foreach(var cr in lista)
            {
                if (!String.IsNullOrEmpty(nf))
                {

                    NNumero = nf + "-" + cr.NumeroParcela.ToString();
                } 
                var v = cr; 
                var e = new EmpresaDAL().getByIdEmpresa(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
                var cb = new ContaBancariaDAL().GetByID(IdContaBancaria);
                var conta = new ContasReceberDAL().GetByID(IdContasReceber);
                BoletoBancario b = new BoletoBancario();
                b.IdContasReceber = IdContasReceber;
                b.IdContaBancaria = cb.IdContaBancaria;
                b.IdContasReceberAberto = v.IdContasReceberAberto;
                b.CedenteNome = e.RazaoSocial;
                b.CedenteEndereco = e.Endereco + ", " + e.Numero + " - " + e.Bairro + " - " + e.Cidade.Nome;
                b.CedenteCNPJ = e.CNPJ;
                b.CedenteBanco = cb.Banco.NumeroBanco + "-" + cb.Banco.NomeBanco;
                b.CedenteAgencia = cb.Agencia + (string.IsNullOrEmpty(cb.DigitoAgencia) ? "" : "-" + cb.DigitoAgencia);
                b.CedenteConta = cb.Conta + (string.IsNullOrEmpty(cb.DigitoConta) ? "" : "-" + cb.DigitoConta);
                b.CedenteCarteira = cb.BoletoCarteira;
                b.CedenteModalidade = cb.BoletoModalidade;
                b.CedenteConvenio = cb.BoletoConvenio;
                b.CedenteCodCedente = cb.BoletoCodCedente;
                //b.CedenteUsoBanco = ;
                //b.CedenteCIP = ;
                b.SacadoNome = conta.Cliente.RazaoSocial;
                if (conta.Cliente.CNPJ.Length == 14)
                {
                    b.SacadoDocumento = Util.Util.FormatString(conta.Cliente.CNPJ, Util.Util.TypeString.CNPJ);
                }
                else
                {
                    b.SacadoDocumento = Util.Util.FormatString(conta.Cliente.CNPJ, Util.Util.TypeString.CPF);
                }

                var enderecos = conta.Cliente.ClienteEndereco.ToList();
                b.SacadoEndereco = enderecos[0].Endereco.Logradouro + ", " + enderecos[0].Endereco.Numero;// + " - " + enderecos[0].Endereco.Bairro + " - " + enderecos[0].Endereco.Cidade.Nome;
                b.SacadoCidade = enderecos[0].Endereco.Cidade.Nome;
                b.SacadoBairro = enderecos[0].Endereco.Bairro;
                b.SacadoCEP = enderecos[0].Endereco.CodigoPostal;
                b.SacadoUF = enderecos[0].Endereco.UnidadeFederacao.UF;
                //b.SacadoAvalista = ;

                b.BoletoNossoDocumento = conta.Documento;
                b.BoletoParcelaNumero = 1;
                b.BoletoParcelaTotal = 1;
                b.BoletoQuantidade = 1;
                b.BoletoValorUnitario = v.ValorLiquido;
                b.BoletoValorDocumento = v.ValorLiquido;
                b.BoletoDataDocumento = DateTime.Now;
                b.BoletoDataVencimento = v.Vencimento;
                //b.BoletoEspecie = Especies.RC;
                b.BoletoDataProcessamento = DateTime.Now;
                b.BoletoValorMora = 0;
                b.BoletoPercentualMulta = 0;
                b.BoletoPercentualMora = 0;
                //b.BoletoDataPagamento = ;
                b.BoletoCalculaMultaMora = true;
                //b.BoletoValorDesconto = ;
                //b.BoletoDataDesconto = ;
                //b.BoletoValorAcrescimo = ;
                //b.BoletoValorOutros = ;
                b.BoletoInstrucoes = "";
                b.BoletoStatus = "Emitido";
                dal.Insert(b);
                dal.Save();
                if (String.IsNullOrEmpty(NNumero))
                {
                    b.BoletoNossoNumero = "1" + (IdContasReceber.ToString() + cr.NumeroParcela.ToString()).PadLeft(9, '0');
                    b.BoletoNossoDocumento = IdContasReceber.ToString() + "-" + cr.NumeroParcela.ToString();
                }
                else
                {
                    b.BoletoNossoNumero = NNumero.PadLeft(10, '0');
                    b.BoletoNossoDocumento = NNumero;
                }

                dal.Update(b);
                dal.Save();
                
            }
        }

        public string GerarBoleto(BoletoBancario bol)
        {
            // Definição dos dados do cedente
            Impactro.Cobranca.

            CedenteInfo Cedente = new CedenteInfo();
            Cedente.Cedente = bol.CedenteNome;// "Nome do cedente (teste)";
            Cedente.Endereco = bol.CedenteEndereco;// "Endereço xxx";
            Cedente.CNPJ = Util.Util.FormatString(bol.CedenteCNPJ, Util.Util.TypeString.CNPJ);// "05.343.346/0001-12";
            Cedente.Banco = bol.CedenteBanco.Substring(0, 3);// "341";
            Cedente.Agencia = bol.CedenteAgencia;// "0161";
            Cedente.Conta = bol.CedenteConta; //"68972-7";
            Cedente.Carteira = bol.CedenteCarteira;// "18";
            Cedente.Modalidade = bol.CedenteModalidade;// "19";
            Cedente.Convenio = bol.CedenteConvenio; // "123456";    // ATENÇÃO: Alguns Bancos usam um código de convenio para remapear a conta do clientes
            Cedente.CodCedente = bol.CedenteConvenio;// "123456";  // outros bancos chama isto de Codigo do Cedente ou Código do Cliente
                                            // outros usam os 2 campos para controles distintos!
                                            // Veja com atenção qual é o seu caso e qual destas variáveis deve ser usadas!
                                            // Olhe sempre os exemplos em ASP.Net se tiver dúvidas, pois lá há um exemplo para cada banco
            Cedente.UsoBanco = "";
            // Cedente.CIP = "456";         // se for informado esse campo o layout muda um pouco

            // Definição dos dados do sacado
            SacadoInfo Sacado = new SacadoInfo();
            Sacado.Sacado = bol.SacadoNome;// "Nome do sacado (Teste)";
            Sacado.Documento = bol.SacadoDocumento;// "123.456.789-99";
            Sacado.Endereco = bol.SacadoEndereco;// "Av. Paulista, 1234";
            Sacado.Cidade = bol.SacadoCidade;// "São Paulo";
            Sacado.Bairro = bol.SacadoBairro;// "Centro";
            Sacado.Cep = Util.Util.FormatString(bol.SacadoCEP, Util.Util.TypeString.CEP);// "12345-123";
            Sacado.UF = bol.SacadoUF;// "SP";
            Sacado.Avalista = bol.SacadoAvalista;// "Banco XPTO - CNPJ: 123.456.789/00001-23";
            
            // Definição das Variáveis do boleto
            BoletoInfo Boleto = new BoletoInfo();
            Boleto.NossoNumero = bol.BoletoNossoNumero;// "12345";
            Boleto.NumeroDocumento = bol.BoletoNossoDocumento;
            Boleto.ParcelaNumero = Convert.ToInt32(bol.BoletoParcelaNumero);// //2;
            Boleto.ParcelaTotal = Convert.ToInt32(bol.BoletoParcelaTotal);// 6;
            Boleto.Quantidade = Convert.ToInt32(bol.BoletoQuantidade);// 5;
            Boleto.ValorUnitario = Convert.ToDouble(bol.BoletoValorUnitario);// 20;
            Boleto.ValorDocumento = Convert.ToDouble(bol.BoletoQuantidade * bol.BoletoValorUnitario);// Boleto.Quantidade * Boleto.ValorUnitario;
            Boleto.DataDocumento = Convert.ToDateTime(bol.BoletoDataDocumento);//
            Boleto.DataVencimento = Convert.ToDateTime(bol.BoletoDataVencimento);// DateTime.Now.AddDays(-30);
            Boleto.Especie = Especies.DM;
            
            //Boleto.DataDocumento = DateTime.Now;     // Por padrão é  a data atual, geralmente é a data em que foi feita a compra/pedido, antes de ser gerado o boleto para pagamento
            Boleto.DataProcessamento = DateTime.Now; // Por padrão é a data atual, pode ser usado como a data em que foi impresso o boleto

            Boleto.ValorMora = 0;
            Boleto.PercentualMulta = 0; // % no mês
            Boleto.PercentualMora = 0; // % ao dia...

            // Se for especificado a data de pagamento esta será usada como base para o calculo do numero de dias em que será pago
            //Boleto.DataPagamento = Boleto.DataVencimento.AddDays(60);

            // Ativa o calculo de Juros+Mora
            Boleto.CalculaMultaMora = true;

            // Outros valores opcionais
            //Boleto.ValorDesconto = 10;
            //Boleto.DataDesconto = DateTime.Now.AddDays(-10);
            //Boleto.ValorAcrescimo = 3;
            //Boleto.ValorOutras = 12.34;
            Boleto.Instrucoes = bol.BoletoInstrucoes;

            // Personaliza o boleto com seu logo
            BoletoForm bltFrm = new BoletoForm();
            //bltFrm.Boleto.CedenteLogo = new System.Drawing.Bitmap("");
           
            // monta o boleto com os dados específicos nas classes
            bltFrm.MakeBoleto(Cedente, Sacado, Boleto);
            //PrintRecibo(bltFrm);
            // É possivel também customizar a linha referente o local de pagamento:
            string tempPath = System.IO.Path.GetTempPath() + "Boleto" + bol.IdBoleto.ToString() + ".jpg";  
            bltFrm.Boleto.LocalPagamento = "Pague Preferencialmente no " + bol.CedenteBanco.Replace(bol.CedenteBanco.Substring(0, 5), "")  + " ou na rede bancária até o vencimento";
            bltFrm.Boleto.Save(tempPath);
            return tempPath;
            //Graphics myGraphics = Graphics.FromImage(bltFrm.Boleto.ImageBoleto());
            //bltFrm.Boleto.Render(myGraphics);
             
        }

        void PrintRecibo(BoletoForm oBoletoForm)
        {
            Boleto blt = oBoletoForm.Boleto;

            // Aqui não pode conter o clear por causa da impressão que chama o PreRender() antes
            if (true)
            {
                blt.ExibeReciboSacado = true;
                int nTop = !blt.Carne && blt.ExibeReciboSacado ? (true ? 120 : 110) + 60 : 105;
                //int nWidth = blt.Carne ? 169 + 50 : 169;
                blt.CalculaBoleto();
                int nWidth = blt.RenderBoleto.Width;

                //if (chkMaisEspaco.Checked && blt.ExibeReciboSacado)
                    nTop += 100;
                //else if (chkMaisEspaco.Checked)
                //    nTop += 50;

                // As 2 linhas abaixão, dentro desta logica nção é necessário pois quando se define se será carne ou não é criado o layout devido
                //if (blt.RenderBoleto == null)
                //    blt.RenderBoleto = new BoletoNormal();

                // Verifica se os campos já foram criados
                // Por padrão são criados por ultimo, dentro do render, mas para customizar precisam ser criados antes
                // Usando as funções internas direta do boleto não é necessário usar
                //if (blt.RenderBoleto.Count == -1)
                //    blt.RenderBoleto.MakeFields(blt);

                // Este metodo já checa se existe um objeto de renderização, chamando CalculaBoleto(), e renderizando os campos baiscos
                // Isso retorna uma instancia de FieldDraw, onde no maximo é possivel definir apenas uma propriedade na mesma linha
                FieldDraw f;
                // Linha 1

                f = blt.AddFieldDraw(0, 0 + nTop, null, "COMPROVANTE DE ENTREGA DE BOLETO", nWidth - 40, 7);
                f.Align = StringAlignment.Center;
                f.Destaque = true;
                blt.AddFieldDraw(nWidth - 40, 0 + nTop, "Nota Fiscal", "1234").Destaque = true; // Outra forma mais simples de adicionar elementos

                // Linha 2
                // é possivel adicionar linhas diretamente dentro do render Boleto, desde que se tenha feita as checagens anteriores
                blt.RenderBoleto.Add(new FieldDraw(0, 7 + nTop, "Cliente (Razão social)", blt.Sacado, nWidth, 7, StringAlignment.Near));
                // Na pratica a primeira informação adicionar é sempre bom fazer usando o AddFieldDraw, e depois vocês faz como quiser

                // Linha 3
                blt.RenderBoleto.Add(new FieldDraw(0, 14 + nTop, "Nosso Número", blt.NossoNumeroExibicao, nWidth - 80, 7, StringAlignment.Near));
                blt.RenderBoleto.Add(new FieldDraw(nWidth - 80, 14 + nTop, "Data de Vencimento", blt.DataVencimento.ToString("dd/MM/yyyy"), 40, 7, StringAlignment.Center));
                blt.RenderBoleto.Add(new FieldDraw(nWidth - 40, 14 + nTop, "Valor do Documento", blt.ValorDocumento.ToString("C")));

                // Linha 4 - Usando a inclusão direta, só para definir as principais propriedades
                blt.AddFieldDraw(0, 22 + nTop, "Identificação e assinatura do recebedor", "", nWidth - 80, 10);
                blt.AddFieldDraw(nWidth - 80, 22 + nTop, "Documento de Identidade", "", 40, 10);
                blt.AddFieldDraw(nWidth - 40, 22 + nTop, "Data Recebimento", "", 40, 10);
            }

            // Depois de tudo 'desenhado' pode-se alterar algo que foi feito
            // pois na verdade não foi ainda desenhado, e sim montado um array com o que será desenhado
            if (true)
            {
                // Desde que esteja de fato tudo definido
                blt.CalculaBoleto();

                int nSize = blt.RenderBoleto.Count;
                bool lAchou = false;
                for (int n = 0; n < nSize; n++)
                {
                    // Acha o campo Demostrativo que ocupa 100% do layout
                    if (blt.RenderBoleto.Get(n).Campo == "Demonstrativo")
                    {
                        lAchou = true;
                        blt.RenderBoleto.Get(n).Campo = "Demonstrativo da Cobrança"; // Personaliza o texto
                        blt.RenderBoleto.Get(n).Height += 50;
                    }
                    else if (lAchou)
                        // Desloca tudo adiante em 50 pixel para baixo
                        blt.RenderBoleto.Get(n).Y += 50;
                }

                // A logica para aumentar o campo de isntrução é quase a mesma
                lAchou = false;
                bool lAchouFim = false;
                for (int n = 0; n < nSize; n++)
                {
                    // O que muda é que o campo não tem todo o tamnho do layout então os campos laterais não podem ser empurrados para baixo
                    if (blt.RenderBoleto.Get(n).Campo == BoletoTextos.Instrucoes)
                    {
                        lAchou = true;
                        blt.RenderBoleto.Get(n).Campo = "Instruções para Pagamento"; // Personaliza o texto
                        blt.RenderBoleto.Get(n).Height += 50;
                    }
                    else if (lAchouFim)
                        // Desloca tudo adiante em 50 pixel para baixo
                        blt.RenderBoleto.Get(n).Y += 50;
                    else if (lAchou)
                    {
                        // os campos são inserido em ordem sequencial
                        // então depois de adicionar os elementos laterais, o restante tem que ser deslocado
                        lAchouFim = blt.RenderBoleto.Get(n).X == 0;
                        if (lAchouFim)
                        {
                            blt.RenderBoleto.Get(n).Y += 50;
                            blt.RenderBoleto.Get(n - 1).Height += 50; // Aumenta o taamnho do campo anterior
                        }
                    }
                }
            }
            // salva o boleto em uma imagem
            blt.Save("teste.png");
        }

        public string GerarArquivoRemessa()
        {
            // Definição dos dados do cedente - QUEM RECEBE / EMITE o boleto
            CedenteInfo Cedente = new CedenteInfo();
            Cedente.Cedente = "TESTE QUALQUER LTDA";
            Cedente.CNPJ = "12123123/0001-01";
            Cedente.Layout = LayoutTipo.Auto;

            // ABAIXO DESCOMENTE o bloco de dados do banco que pretende usar

            // SANTANDER
            //Cedente.Banco = "033";
            //Cedente.Agencia = "1234-1";
            //Cedente.Conta = "001234567-8";
            //Cedente.CodCedente = "1231230";
            //Cedente.CarteiraTipo = "5";
            //Cedente.Carteira = "101";
            //Cedente.CedenteCOD = "33333334892001304444"; // 20 digitos (note que o final, é o numero da conta, sem os ultios 2 digitos)
            //Cedente.Convenio = "0000000000000000002222220"; // 25 digitos
            //Cedente.useSantander = true; //importante para gerar o código de barras correto (por questão de compatibilidade o padrão é false)

            // BRADESCO
            Cedente.Banco = "237-2";
            Cedente.Agencia = "1510";
            Cedente.Conta = "001466-4";
            Cedente.Carteira = "09";
            Cedente.CedenteCOD = "00000000000001111111"; // 20 digitos

            // ITAU
            //Cedente.CedenteCOD = "514432001";
            //Cedente.Banco = "341-1";
            //Cedente.Agencia = "6260";
            //Cedente.Conta = "01607-3";
            //Cedente.Carteira = "109";

            // Banco do Brasil
            //Cedente.Banco = "001-9";
            //Cedente.Agencia = "294-1";
            //Cedente.Conta = "004570-6";
            //Cedente.Carteira = "18";
            //Cedente.Modalidade = "21";
            //Cedente.Convenio = "859120";

            // CAIXA 
            //Cedente.Banco = "104";
            //Cedente.Agencia = "123-4";
            //Cedente.Conta = "5678-9";
            //Cedente.Carteira = "2";          // Código da Carteira
            //Cedente.Convenio = "02";         // CNPJ do PV da conta do cliente
            //Cedente.CodCedente = "455932";   // Código do Cliente(cedente)
            //Cedente.Modalidade = "14";       // G069 - CC = 14 (título Registrado emissão Cedente)
            //Cedente.Endereco = "Rua Sei la aonde";
            //Cedente.Informacoes =
            //    "SAC CAIXA: 0800 726 0101 (informações, reclamações, sugestões e elogios)<br/>" +
            //    "Para pessoas com deficiência auditiva ou de fala: 0800 726 2492<br/>" +
            //    "Ouvidoria: 0800 725 7474 (reclamações não solucionadas e denúncias)<br/>" +
            //    "<a href='http://caixa.gov.br' target='_blank'>caixa.gov.br</a>";
            //BoletoTextos.LocalPagamento = "PREFERENCIALMENTE NAS CASAS LOTÉRICAS ATÉ O VALOR LIMITE";

            // SICRED
            //Cedente.Banco = "748-2";
            //Cedente.Agencia = "1234-5";
            //Cedente.Conta = "98765-1";
            //Cedente.CodCedente = "12345";
            //Cedente.Modalidade = "04";

            // UNICRED
            //Cedente.Banco = "091-4";
            //Cedente.Agencia = "1234-5";
            //Cedente.Conta = "98765-1";
            //Cedente.CodCedente = "12345";

            //Definição dos dados do sacado
            SacadoInfo Sacado = new SacadoInfo();
            Sacado.Sacado = "Fábio F S";
            Sacado.Documento = "192.211.498-70";
            Sacado.Endereco = "Rua 21 de Abril 1001 ap 21";
            Sacado.Cidade = "São Paulo";
            Sacado.Bairro = "Brás";
            Sacado.Cep = "03047-000";
            Sacado.UF = "SP";
            Sacado.Email = "fabio@impactro.com.br";
            Sacado.Avalista = "Avalista";

            LayoutBancos r = new LayoutBancos();
            r.Init(Cedente);
            r.Lote = CobUtil.GetInt("lote");
            r.ShowDumpLine = false;
            //r.onRegBoleto = r_onRegBoleto; // Para personalizar as linhas com os campos adicionais

            for (int n = 0; n < Int32.Parse("1"); n++)
            {
                //Definição das Variáveis do boleto
                BoletoInfo Boleto = new BoletoInfo();
                Boleto.BoletoID = n;
                Boleto.NossoNumero = (Int32.Parse("txtNossoNumero") + n).ToString();
                Boleto.NumeroDocumento = Boleto.NossoNumero;
                Boleto.ValorDocumento = double.Parse("txtValor") + n;
                Boleto.DataDocumento = DateTime.Now;
                Boleto.DataVencimento = DateTime.Parse("txtVencimento").AddDays(n);
                Boleto.Instrucoes = "Todas as informações deste bloqueto são de exclusiva responsabilidade do cedente";

                // outros campos opcionais
                Boleto.ValorMora = Boleto.ValorDocumento * 0.2 / 30; // Vale lembrar que o juros pode ser tão pequeno que as vezes pode sair como isento
                Boleto.PercentualMulta = 0.03;
                Boleto.ValorDesconto = n;
                Boleto.DataDesconto = DateTime.Now;
                Boleto.ValorOutras = -n; // abatimentos 

                /* Exemplo de uso valido apenas para o Bradesco (Página 21 do arquivo: layout_cobranca_port_BRADESCO.pdf)
                 * Cada banco usa estes campos da forma que eles querem
                
                157 a 160 - 1ª / 2ª Instrução
                Campo destinado para pré-determinar o protesto do Título ou a baixa por decurso de prazo, quando do registro.
                Não havendo interesse, preencher com Zeros.
                Porém, caso a Empresa deseje se utilizar da instrução automática de protesto ou da baixa por decurso de prazo, abaixo os procedimentos:
                
                Protesto:
                - posição 157 a 158 = Indicar o código “06” - (Protestar).
                - posição 159 a 160 = Indicar o número de dias a protestar (mínimo 5 dias).
                
                Protesto Falimentar:
                - posição 157 a 158 = Indicar o código “05” – (Protesto Falimentar)
                - posição 159 a 160 = Indicar o número de dias a protestar (mínimo 5 dias).
                
                Decurso de Prazo:
                - posição 157 a 158 = Indicar o código “18” – (Decurso de prazo).
                - posição 159 a 160 = Indicar o número de dias para baixa por decurso de prazo.

                Nota: A posição 157 a 158, também poderá ser utilizada para definir as seguintes mensagens, a serem impressas nos Boletos de cobrança, emitidas pelo Banco:
                08 Não cobrar juros de mora
                09 Não receber após o vencimento
                10 Multa de 10% após o 4º dia do Vencimento.
                11 Não receber após o 8º dia do vencimento.
                12 Cobrar encargos após o 5º dia do vencimento.
                13 Cobrar encargos após o 10º dia do vencimento.
                14 Cobrar encargos após o 15º dia do vencimento
                15 Conceder desconto mesmo se pago após o vencimento.
                Atenção: Essas instruções deverão ser enviadas no Arquivo-Remessa, quando da entrada, desde que o código de ocorrência na posição 109 a 110 do registro de transação, seja “01”, para as instruções de protesto, o CNPJ / CPF e o endereço do Sacado deverão ser informados corretamente.
                */
                Boleto.Instrucao1 = 6; // Protestar
                Boleto.Instrucao2 = 7; // Depois de 7 dias do vencimento

                // No bRadesco não é usado o campo Comando, mas outros bancos podem usar
                // Boleto.Comando = 0;

                // As linhas a seguir customiza qualquer valor sem precisar usar o evento 'r.onRegBoleto' o que torna a implementação mais simples
                // A forma mais pratica e segura é sempre usar os enumeradores
                // Mas é possivel usar as duas opções como neste exemplo, mas os valores personalizados tem sempre prioridade pois são inserridos por ultimo apos todos calculos, e processamento de eventos, portanto use com cuidado!
                Boleto.SetRegEnumValue(CNAB400Remessa1Sicredi.TipoJuros, "B");    // (posição 19) // Apenas se atente para a diferença do nome para SetRegEnumValue()
                Boleto.SetRegKeyValue("CNAB400Remessa1Sicredi.Alteracao", "E");   // (posição 71) // É possivel adicionar o nome e valor do enumerador, isso é compativel com VB6
                // Cuidado ao deixar algo explicito diretamente: 
                // Boleto.SetRegKeyValue("Emissao", "B"); // posição 74 // ou simplesmente informar o nome do campo, mas cuidado pois há layouts que usam mais de um tipo de registro e as vezes tem nomes iguais mas as funções podem ser diferentes
                Boleto.SetRegEnumValue(CNAB400Remessa1Bradesco.Condicao, 1); // Apenas para Bradesco enviar o boleto para residencia

                // Gera um registro
                //Boleto.Sacado = Sacado; // obrigatório para o registro
                r.Add(Boleto, Sacado);
            }

            // o numero de exemplo '123' é apenas um numero de teste
            // este numero é muito importante que seja gerado de forma exclusiva e sequencial
            return r.Remessa(); //r.CNAB400(123);
        }

        public DataTable CarregarArquivoRetorno(out string Message)
        {
            try
            {
                // Tipo de estrutura a ser decodificada (enumerador de layout)

                /* Exemplo de registros de retorno bradesco
                10205491613000192000000900462012390740000000000000000000000004000000000000000000530000000000000000000000000903190515000000000500000000000000000053040615000000001547823703152  000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000                          0800000000                                                                  000006
                10205491613000192000000900462012390740000000000000000000000005000000000000000000610000000000000000000000000903190515000000000600000000000000000061050615000000001557823703152  000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000                          0800000000                                                                  000007
                102054916130001920000009004620123907400000000000000000000000060000000000000000007P000000000000000000000000090319051500000000070000000000000000007P060615000000001567823703152  000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000                          0800000000                                                                  000008
                10205491613000192000000900462012390740000000000000000000000007000000000000000000880000000000000000000000000903190515000000000800000000000000000088070615000000001577823703152  000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000                          0800000000                                                                  000009
                 */
                // A classe Layout tem diversos metodos genericos para fazer qualquer codificação e decodificação de textos de acordo com os tipos de enumeradores passados em seu contrutor
                //Layout lay = new Layout(typeof(CNAB400Retorno1Bradesco));
                //Layout lay = new Layout(typeof(CNAB240CobrancaRetorno));
                //Layout lay = new Layout(typeof(CNAB400Retorno1Bradesco));
                //Layout lay = new Layout(typeof(CNAB240SegmentoTCaixa));
                //Layout lay = new Layout(typeof(CNAB400Retorno1Itau));

                // Coloca o texto em questão para ser interpretado
                //lay.Conteudo = txtRetorno.Text;

                // Internamente a classe de Layour armazena todos os dados e por gerar outros objetos como um DataTable com uma das estruturas
                //gv.DataSource = lay.Table(lay.GetLayoutType(0));

                LayoutBancos r = new LayoutBancos(); // classe genérica para qualquer banco, compatível até com ActiveX
                r.Init(new CedenteInfo { Banco = "341", Layout = LayoutTipo.Auto });
                r.Boletos.AddErroType = BoletoDuplicado.Ignore;
                Layout ret = r.Retorno("txtRetorno");

                DataTable tb = new DataTable();
                tb.Columns.Add("NossoNumero", typeof(string));
                tb.Columns.Add("NumeroDocumento", typeof(string));
                tb.Columns.Add("DataDocumento", typeof(DateTime));
                tb.Columns.Add("DataVencimento", typeof(DateTime));
                tb.Columns.Add("DataPagamento", typeof(DateTime));
                tb.Columns.Add("ValorDocumento", typeof(double));
                tb.Columns.Add("ValorPago", typeof(double));
                foreach (string nn in r.Boletos.NossoNumeros)
                {
                    // é possivel le os dados de cada boleto
                    BoletoInfo Boleto = r.Boletos[nn];
                    tb.Rows.Add(
                        Boleto.NossoNumero,
                        Boleto.NumeroDocumento,
                        Boleto.DataDocumento,
                        Boleto.DataVencimento,
                        Boleto.DataPagamento,
                        Boleto.ValorDocumento,
                        Boleto.ValorPago);
                }

                if (string.IsNullOrEmpty(r.ErroLinhas))
                    Message = "OK";
                else
                    Message = "Arquivo processado mas as linhas abaixo estão parcialmente duplicadas\r\n" + r.ErroLinhas;
                // Isso ocorre quando o banco toma alguma ação, ou algum sistema errou, trate essa linha a parte manualmente, ou algum euristica.
                // em: r.Boletos.Duplicados há a relação destes boletos

                return tb;
            }
            catch (Exception ex)
            {
                Message = "";
                while (ex != null)
                {
                    Message += ex.Message + "\r\n" + ex.StackTrace;
                    ex = ex.InnerException;
                }

                return null;
            }
        }

    }
}
