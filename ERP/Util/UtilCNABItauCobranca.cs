using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Util
{
    public static class UtilCNABItauCobranca
    {

        #region ItauRemessa

        /// <summary>
        /// ARQUIVO REMESSA/RETORNO - REGISTRO HEADER DE ARQUIVO
        /// </summary>
        /// <param name="CodigoBanco">N.º DO BANCO NA CÂMARA DE COMPENSAÇÃO</param>
        /// <param name="CodigoLote">LOTE DE SERVIÇO</param>
        /// <param name="TipoRegistro">REGISTRO HEADER DE ARQUIVO</param>
        /// <param name="Brancos_1">COMPLEMENTO DE REGISTRO</param>
        /// <param name="CodigoInscricao">TIPO DE INSCRIÇÃO DA EMPRESA</param>
        /// <param name="InscricaoNumero">N.º DE INSCRIÇÃO DA EMPRESA</param>
        /// <param name="Brancos_2">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Zero_1">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Agencia">AGÊNCIA MANTENEDORA DA CONTA</param>
        /// <param name="Brancos_3">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Zero_2">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Conta">NÚMERO DA CONTA CORRENTE DA EMPRESA</param>
        /// <param name="Brancos_4">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Dac">DÍGITO DE AUTO-CONFERÊNCIA AG./CONTA EMPRESA</param>
        /// <param name="NomeEmpresa">NOME POR EXTENSO DA EMPRESA 'MÃE'</param>
        /// <param name="NomeBanco">NOME POR EXTENSO DO BANCO COBRADOR</param>
        /// <param name="Brancos_5">COMPLEMENTO DE REGISTRO</param>
        /// <param name="CodigoArquivo">CÓDIGO REMESSA / RETORNO</param>
        /// <param name="DataGeracao">DATA DE GERAÇÃO DO ARQUIVO</param>
        /// <param name="HoraGeracao">HORA DE GERAÇÃO DO ARQUIVO</param>
        /// <param name="NumSeqArquivoRetorno">NÚMERO SEQUENCIAL DO ARQUIVO RETORNO</param>
        /// <param name="LayoutArquivo">N.º DA VERSÃO DO LAYOUT DO ARQUIVO</param>
        /// <param name="Zero_3">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Brancos_6">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Zero_4">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Brancos_7">COMPLEMENTO DE REGISTRO</param>
        /// <returns></returns>
        public static string RemessaHeader(
                                            int CodigoBanco,
                                            int CodigoLote,
                                            int TipoRegistro,
                                            string Brancos_1,
                                            int CodigoInscricao,
                                            int InscricaoNumero,
                                            string Brancos_2,
                                            int Zero_1,
                                            int Agencia,
                                            string Brancos_3,
                                            int Zero_2,
                                            int Conta,
                                            string Brancos_4,
                                            int Dac,
                                            string NomeEmpresa,
                                            string NomeBanco,
                                            string Brancos_5,
                                            int CodigoArquivo,
                                            DateTime DataGeracao,
                                            DateTime HoraGeracao,
                                            int NumSeqArquivoRetorno,
                                            int LayoutArquivo,
                                            int Zero_3,
                                            string Brancos_6,
                                            int Zero_4,
                                            string Brancos_7
                                        )
        {
            string Header = "";


            Header += Util.PreencheCampoInt(CodigoBanco, 3);
            Header += Util.PreencheCampoInt(CodigoLote, 4);
            Header += Util.PreencheCampoInt(TipoRegistro, 1);
            Header += Util.PreencheCampoString(Brancos_1, 9);
            Header += Util.PreencheCampoInt(CodigoInscricao, 1);
            Header += Util.PreencheCampoInt(InscricaoNumero, 14);
            Header += Util.PreencheCampoString(Brancos_2, 20);
            Header += Util.PreencheCampoInt(Zero_1, 1);
            Header += Util.PreencheCampoInt(Agencia, 4);
            Header += Util.PreencheCampoString(Brancos_3, 1);
            Header += Util.PreencheCampoInt(Zero_2, 7);
            Header += Util.PreencheCampoInt(Conta, 5);
            Header += Util.PreencheCampoString(Brancos_4, 1);
            Header += Util.PreencheCampoInt(Dac, 1);
            Header += Util.PreencheCampoString(NomeEmpresa, 30);
            Header += Util.PreencheCampoString(NomeBanco, 30);
            Header += Util.PreencheCampoString(Brancos_5, 10);
            Header += Util.PreencheCampoInt(CodigoArquivo, 1);
            Header += Util.PreencheCampoData(DataGeracao, 8);
            Header += Util.PreencheCampoHora(HoraGeracao, 6);
            Header += Util.PreencheCampoInt(NumSeqArquivoRetorno, 6);
            Header += Util.PreencheCampoInt(LayoutArquivo, 3);
            Header += Util.PreencheCampoInt(Zero_3, 5);
            Header += Util.PreencheCampoString(Brancos_6, 54);
            Header += Util.PreencheCampoInt(Zero_4, 3);
            Header += Util.PreencheCampoString(Brancos_7, 12);
            return Header;
        }

        /// <summary>
        /// ARQUIVO REMESSA/RETORNO - REGISTRO HEADER DE LOTE
        /// </summary>
        /// <param name="CodigoBanco">N.º DO BANCO NA CÂMARA DE COMPENSAÇÃO</param>
        /// <param name="CodigoLote">LOTE DE SERVIÇO</param>
        /// <param name="TipoRegistro">REGISTRO HEADER DE LOTE</param>
        /// <param name="Operacao">TIPO DE OPERAÇÃO</param>
        /// <param name="CodigoServico">IDENTIFICAÇÃO DO TIPO DE SERVIÇO</param>
        /// <param name="Zero_1">COMPLEMENTO DE REGISTRO</param>
        /// <param name="LayoutLote">N.º DA VERSÃO DO LAYOUT DO LOTE</param>
        /// <param name="Brancos_1">COMPLEMENTO DE REGISTRO</param>
        /// <param name="CodigoInscricao">TIPO DE INSCRIÇÃO DA EMPRESA</param>
        /// <param name="InscricaoNumero">N.º DE INSCRIÇÃO DA EMPRESA</param>
        /// <param name="Brancos_2">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Zero_2">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Agencia">AGÊNCIA MANTENEDORA DA CONTA</param>
        /// <param name="Brancos_3">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Zero_3">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Conta">NÚMERO DA CONTA CORRENTE</param>
        /// <param name="Brancos_4">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Dac">DÍGITO DE AUTO-CONFERÊNCIA AG./CONTA EMPRESA</param>
        /// <param name="NomeEmpresa">NOME DA EMPRESA</param>
        /// <param name="Brancos_5">COMPLEMENTO DE REGISTRO</param>
        /// <param name="NumSeqArquivoRet">NÚMERO SEQUENCIAL DO ARQUIVO RETORNO</param>
        /// <param name="DataGravacao">DATA DE GRAVAÇÃO DO ARQUIVO</param>
        /// <param name="DataCredito">DATA DO CRÉDITO</param>
        /// <param name="Brancos_6">COMPLEMENTO DE REGISTRO</param>
        /// <returns></returns>
        public static string RemessaHeaderLote(
                                                int CodigoBanco,
                                                int CodigoLote,
                                                int TipoRegistro,
                                                string Operacao,
                                                int CodigoServico,
                                                int Zero_1,
                                                int LayoutLote,
                                                string Brancos_1,
                                                int CodigoInscricao,
                                                int InscricaoNumero,
                                                string Brancos_2,
                                                int Zero_2,
                                                int Agencia,
                                                string Brancos_3,
                                                int Zero_3,
                                                int Conta,
                                                string Brancos_4,
                                                int Dac,
                                                string NomeEmpresa,
                                                string Brancos_5,
                                                int NumSeqArquivoRet,
                                                DateTime DataGravacao,
                                                DateTime DataCredito,
                                                string Brancos_6
                                                )
        {
            string HeaderLote = "";

            HeaderLote += Util.PreencheCampoInt(CodigoBanco, 3);
            HeaderLote += Util.PreencheCampoInt(CodigoLote, 4);
            HeaderLote += Util.PreencheCampoInt(TipoRegistro, 1);
            HeaderLote += Util.PreencheCampoString(Operacao, 1);
            HeaderLote += Util.PreencheCampoInt(CodigoServico, 2);
            HeaderLote += Util.PreencheCampoInt(Zero_1, 2);
            HeaderLote += Util.PreencheCampoInt(LayoutLote, 3);
            HeaderLote += Util.PreencheCampoString(Brancos_1, 1);
            HeaderLote += Util.PreencheCampoInt(CodigoInscricao, 1);
            HeaderLote += Util.PreencheCampoInt(InscricaoNumero, 15);
            HeaderLote += Util.PreencheCampoString(Brancos_2, 20);
            HeaderLote += Util.PreencheCampoInt(Zero_2, 1);
            HeaderLote += Util.PreencheCampoInt(Agencia, 4);
            HeaderLote += Util.PreencheCampoString(Brancos_3, 1);
            HeaderLote += Util.PreencheCampoInt(Zero_3, 7);
            HeaderLote += Util.PreencheCampoInt(Conta, 5);
            HeaderLote += Util.PreencheCampoString(Brancos_4, 1);
            HeaderLote += Util.PreencheCampoInt(Dac, 1);
            HeaderLote += Util.PreencheCampoString(NomeEmpresa, 30);
            HeaderLote += Util.PreencheCampoString(Brancos_5, 80);
            HeaderLote += Util.PreencheCampoInt(NumSeqArquivoRet, 8);
            HeaderLote += Util.PreencheCampoData(DataGravacao, 8);
            HeaderLote += Util.PreencheCampoData(DataCredito, 8);
            HeaderLote += Util.PreencheCampoString(Brancos_6, 33);

            return HeaderLote;
        }

        /// <summary>
        /// ARQUIVO REMESSA - REGISTRO DETALHE - SEGMENTO P - (OBRIGATÓRIO)
        /// </summary>
        /// <param name="CodigoBanco">N.º DO BANCO NA CÂMARA DE COMPENSAÇÃO</param>
        /// <param name="CodigoLote">LOTE DE SERVIÇO</param>
        /// <param name="TipoRegistro">REGISTRO DETALHE</param>
        /// <param name="NumeroRegistro">N.º SEQUENCIAL DO REGISTRO NO LOTE</param>
        /// <param name="Segmento">CÓD. SEGMENTO DO REGISTRO DETALHE</param>
        /// <param name="Branco_1">COMPLEMENTO DE REGISTRO</param>
        /// <param name="CodigoOcorrencia">IDENTIFICAÇÃO DA OCORRÊNCIA</param>
        /// <param name="Zero_1">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Agencia">AGÊNCIA MANTENEDORA DA CONTA</param>
        /// <param name="Branco_2">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Zero_2">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Conta">NÚMERO DA CONTA CORRENTE DA EMPRESA</param>
        /// <param name="Branco_3">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Dac_Empresa">DÍGITO DE AUTO-CONFERÊNCIA AG./CONTA EMPRESA</param>
        /// <param name="NumeroCarteira">NÚMERO DA CARTEIRA NO BANCO</param>
        /// <param name="NossoNumero">IDENTIFICAÇÃO DO TÍTULO NO BANCO</param>
        /// <param name="Dac_NossoNumero">DÍGITO DE AUTO-CONFERÊNCIA NOSSO NÚMERO</param>
        /// <param name="Branco_4">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Zero_3">COMPLEMENTO DE REGISTRO</param>
        /// <param name="NumeroDocumento">NÚMERO DO DOCUMENTO DE COBRANÇA (DUPL.NP...)</param>
        /// <param name="Branco_5">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Vencimento">DATA DE VENCIMENTO DO TÍTULO</param>
        /// <param name="ValorTitulo">VALOR NOMINAL DO TÍTULO</param>
        /// <param name="AgenciaCobradora">AGÊNCIA ONDE O TÍTULO SERÁ COBRADO</param>
        /// <param name="Dac_AgenciaCobradora">DÍGITO AUTO-CONFERÊNCIA AGÊNCIA COBRADORA</param>
        /// <param name="EspecieTitulo">ESPÉCIE DO TÍTULO</param>
        /// <param name="Aceite">IDENTIFICAÇÃO DE TÍTULO ACEITO/NÃO ACEITO -- (A = SIM) -- (N = NÃO)</param>
        /// <param name="DataEmissaoTitulo">DATA DA EMISSÃO DO TÍTULO</param>
        /// <param name="Zero_4">COMPLEMENTO DE REGISTRO</param>
        /// <param name="DataJurosMora">DATA BASE P/COBRANÇA DE JUROS DE MORA</param>
        /// <param name="JurosUmDia">VALOR DE MORA POR DIA DE ATRASO</param>
        /// <param name="Zero_5">COMPLEMENTO DE REGISTRO</param>
        /// <param name="DataDesconto">DATA LIMITE DO 1º DESCONTO</param>
        /// <param name="ValorDesconto">VALOR DO 1º DESCONTO A SER CONCEDIDO</param>
        /// <param name="ValorIOF">VALOR DO IOF A SER RECOLHIDO P/NOTAS SEGURO</param>
        /// <param name="ValorAbatimento">VALOR DO ABATIMENTO</param>
        /// <param name="UsoEmpresa">IDENTIFICAÇÃO DO TÍTULO NA EMPRESA</param>
        /// <param name="CodigoNegativacaoProtesto">CÓDIGO PARA NEGATIVAÇÃO OU PROTESTO</param>
        /// <param name="PrazoNegativacaoProtesto">NÚMERO DE DIAS PARA NEGATIVAÇÃO OU PROTESTO</param>
        /// <param name="CodigoBaixa">CÓDIGO PARA BAIXA</param>
        /// <param name="PrazoBaixa">NÚMERO DE DIAS PARA BAIXA</param>
        /// <param name="Zero_6">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Branco_6">COMPLEMENTO DE REGISTRO</param>
        /// <returns></returns>
        public static string RemessaSegmentoP(
                                                int CodigoBanco,
                                                int CodigoLote,
                                                int TipoRegistro,
                                                int NumeroRegistro,
                                                string Segmento,
                                                string Branco_1,
                                                int CodigoOcorrencia,
                                                int Zero_1,
                                                int Agencia,
                                                string Branco_2,
                                                int Zero_2,
                                                int Conta,
                                                string Branco_3,
                                                int Dac_Empresa,
                                                int NumeroCarteira,
                                                int NossoNumero,
                                                int Dac_NossoNumero,
                                                string Branco_4,
                                                int Zero_3,
                                                string NumeroDocumento,
                                                string Branco_5,
                                                int Vencimento,//Confirmar se eh Data
                                                decimal ValorTitulo,
                                                int AgenciaCobradora,
                                                int Dac_AgenciaCobradora,
                                                int EspecieTitulo,
                                                string Aceite,
                                                DateTime DataEmissaoTitulo,
                                                int Zero_4,
                                                DateTime DataJurosMora, //Confirmar se eh Data
                                                decimal JurosUmDia,
                                                int Zero_5,
                                                DateTime DataDesconto,
                                                decimal ValorDesconto,
                                                decimal ValorIOF,
                                                decimal ValorAbatimento,
                                                string UsoEmpresa,
                                                int CodigoNegativacaoProtesto,
                                                int PrazoNegativacaoProtesto,
                                                int CodigoBaixa,
                                                int PrazoBaixa,
                                                int Zero_6,
                                                string Branco_6
                                            )
        {
            string SegmentoP = "";

            SegmentoP += Util.PreencheCampoInt(CodigoBanco, 3);
            SegmentoP += Util.PreencheCampoInt(CodigoLote, 4);
            SegmentoP += Util.PreencheCampoInt(TipoRegistro, 1);
            SegmentoP += Util.PreencheCampoInt(NumeroRegistro, 5);
            SegmentoP += Util.PreencheCampoString(Segmento, 1);
            SegmentoP += Util.PreencheCampoString(Branco_1, 1);
            SegmentoP += Util.PreencheCampoInt(CodigoOcorrencia, 2);
            SegmentoP += Util.PreencheCampoInt(Zero_1, 1);
            SegmentoP += Util.PreencheCampoInt(Agencia, 4);
            SegmentoP += Util.PreencheCampoString(Branco_2, 1);
            SegmentoP += Util.PreencheCampoInt(Zero_2, 7);
            SegmentoP += Util.PreencheCampoInt(Conta, 5);
            SegmentoP += Util.PreencheCampoString(Branco_3, 1);
            SegmentoP += Util.PreencheCampoInt(Dac_Empresa, 1);
            SegmentoP += Util.PreencheCampoInt(NumeroCarteira, 3);
            SegmentoP += Util.PreencheCampoInt(NossoNumero, 8);
            SegmentoP += Util.PreencheCampoInt(Dac_NossoNumero, 1);
            SegmentoP += Util.PreencheCampoString(Branco_4, 8);
            SegmentoP += Util.PreencheCampoInt(Zero_3, 5);
            SegmentoP += Util.PreencheCampoString(NumeroDocumento, 10);
            SegmentoP += Util.PreencheCampoString(Branco_5, 5);
            SegmentoP += Util.PreencheCampoInt(Vencimento, 8);//Confirmar se eh Data
            SegmentoP += Util.PreencheCampoDecimal(ValorTitulo, 13);
            SegmentoP += Util.PreencheCampoInt(AgenciaCobradora, 5);
            SegmentoP += Util.PreencheCampoInt(Dac_AgenciaCobradora, 1);
            SegmentoP += Util.PreencheCampoInt(EspecieTitulo, 2);
            SegmentoP += Util.PreencheCampoString(Aceite, 1);
            SegmentoP += Util.PreencheCampoData(DataEmissaoTitulo, 8);
            SegmentoP += Util.PreencheCampoInt(Zero_4, 1);
            SegmentoP += Util.PreencheCampoData(DataJurosMora, 8); //Confirmar se eh Data
            SegmentoP += Util.PreencheCampoDecimal(JurosUmDia, 13);
            SegmentoP += Util.PreencheCampoInt(Zero_5, 1);
            SegmentoP += Util.PreencheCampoData(DataDesconto, 8);
            SegmentoP += Util.PreencheCampoDecimal(ValorDesconto, 13);
            SegmentoP += Util.PreencheCampoDecimal(ValorIOF, 13);
            SegmentoP += Util.PreencheCampoDecimal(ValorAbatimento, 13);
            SegmentoP += Util.PreencheCampoString(UsoEmpresa, 25);
            SegmentoP += Util.PreencheCampoInt(CodigoNegativacaoProtesto, 1);
            SegmentoP += Util.PreencheCampoInt(PrazoNegativacaoProtesto, 2);
            SegmentoP += Util.PreencheCampoInt(CodigoBaixa, 1);
            SegmentoP += Util.PreencheCampoInt(PrazoBaixa, 2);
            SegmentoP += Util.PreencheCampoInt(Zero_6, 13);
            SegmentoP += Util.PreencheCampoString(Branco_6, 1);

            return SegmentoP;
        }

        /// <summary>
        /// ARQUIVO REMESSA - REGISTRO DETALHE - SEGMENTO Q - (OBRIGATÓRIO)
        /// </summary>
        /// <param name="CodigoBanco">N.º DO BANCO NA CÂMARA DE COMPENSAÇÃO</param>
        /// <param name="CodigoLote">LOTE DE SERVIÇO</param>
        /// <param name="TipoRegistro">REGISTRO DETALHE</param>
        /// <param name="NumeroRegistro">N.º SEQUENCIAL DO REGISTRO NO LOTE</param>
        /// <param name="Segmento">CÓD. SEGMENTO DO REGISTRO DETALHE</param>
        /// <param name="Branco_1">COMPLEMENTO DE REGISTRO</param>
        /// <param name="CodigoOcorrencia">IDENTIFICAÇÃO DA OCORRÊNCIA</param>
        /// <param name="CodigoInscricaoPagador">TIPO DE INSCRIÇÃO DO PAGADOR ('1' – CPF)('2' – CNPJ)</param>
        /// <param name="InscricaoNumeroPagador">N.º DE INSCRIÇÃO DO PAGADOR</param>
        /// <param name="NomePagador">NOME DO PAGADOR</param>
        /// <param name="Branco_2">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Logradouro">RUA, NÚMERO, E COMPLEMENTO DO PAGADOR</param>
        /// <param name="Bairro">BAIRRO DO PAGADOR</param>
        /// <param name="CEP">CEP DO PAGADOR</param>
        /// <param name="SufixoCEP">SUFIXO DO CEP DO PAGADOR</param>
        /// <param name="Cidade">CIDADE DO PAGADOR</param>
        /// <param name="UF">UNIDADE DA FEDERAÇÃO DO PAGADOR</param>
        /// <param name="CodigoInscricaoSacadorAvarista">TIPO DE INSCRIÇÃO SACADOR/AVALISTA ('1' – CPF)('2' – CNPJ)</param>
        /// <param name="InscricaoNumeroSacadorAvarista">NÚMERO DE INSCRIÇÃO DO SACADOR/AVALISTA</param>
        /// <param name="NomeSacadorAvarista">NOME DO SACADOR/AVALISTA</param>
        /// <param name="Branco_3">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Zero_1">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Branco_4">COMPLEMENTO DE REGISTRO</param>
        /// <returns></returns>
        public static string RemessaSegmentoQ(
                                                int CodigoBanco,
                                                int CodigoLote,
                                                int TipoRegistro,
                                                int NumeroRegistro,
                                                string Segmento,
                                                string Branco_1,
                                                int CodigoOcorrencia,
                                                int CodigoInscricaoPagador,
                                                int InscricaoNumeroPagador,
                                                string NomePagador,
                                                string Branco_2,
                                                string Logradouro,
                                                string Bairro,
                                                int CEP,
                                                int SufixoCEP,
                                                string Cidade,
                                                string UF,
                                                int CodigoInscricaoSacadorAvarista,
                                                int InscricaoNumeroSacadorAvarista,
                                                string NomeSacadorAvarista,
                                                string Branco_3,
                                                int Zero_1,
                                                string Branco_4
                                            )
        {
            string SegmentoQ = "";

            SegmentoQ += Util.PreencheCampoInt(CodigoBanco, 3);
            SegmentoQ += Util.PreencheCampoInt(CodigoLote, 4);
            SegmentoQ += Util.PreencheCampoInt(TipoRegistro, 1);
            SegmentoQ += Util.PreencheCampoInt(NumeroRegistro, 5);
            SegmentoQ += Util.PreencheCampoString(Segmento, 1);
            SegmentoQ += Util.PreencheCampoString(Branco_1, 1);
            SegmentoQ += Util.PreencheCampoInt(CodigoOcorrencia, 2);
            SegmentoQ += Util.PreencheCampoInt(CodigoInscricaoPagador, 1);
            SegmentoQ += Util.PreencheCampoInt(InscricaoNumeroPagador, 15);
            SegmentoQ += Util.PreencheCampoString(NomePagador, 30);
            SegmentoQ += Util.PreencheCampoString(Branco_2, 10);
            SegmentoQ += Util.PreencheCampoString(Logradouro, 40);
            SegmentoQ += Util.PreencheCampoString(Bairro, 15);
            SegmentoQ += Util.PreencheCampoInt(CEP, 5);
            SegmentoQ += Util.PreencheCampoInt(SufixoCEP, 3);
            SegmentoQ += Util.PreencheCampoString(Cidade, 15);
            SegmentoQ += Util.PreencheCampoString(UF, 2);
            SegmentoQ += Util.PreencheCampoInt(CodigoInscricaoSacadorAvarista, 1);
            SegmentoQ += Util.PreencheCampoInt(InscricaoNumeroSacadorAvarista, 15);
            SegmentoQ += Util.PreencheCampoString(NomeSacadorAvarista, 30);
            SegmentoQ += Util.PreencheCampoString(Branco_3, 10);
            SegmentoQ += Util.PreencheCampoInt(Zero_1, 3);
            SegmentoQ += Util.PreencheCampoString(Branco_4, 28);

            return SegmentoQ;
        }

        /// <summary>
        /// ARQUIVO REMESSA - REGISTRO DETALHE - SEGMENTO R - (OPCIONAL)
        /// O registro R é opcional, deve ser utilizado quando o cliente beneficiário tiver interesse em 
        /// registrar ou alterar o valor ou percentual de desconto e/ou multa diferente para cada título. 
        /// Válido somente para carteiras de Cobrança com registro, pode ser utilizado a qualquer momento 
        /// sem necessidade de cadastro prévio junto ao Banco. 
        /// 
        /// O arquivo remessa poderá conter esse registro opcional quando apresentar ocorrência “01 – Entrada” 
        /// ou “49 – Alteração de dados extras”  para multa. 
        /// 
        ///Só poderá ser enviado um tipo de registro do Segmento R, quando o tipo de segmento P anterior, tiver 
        ///ocorrência 01 (Entrada) ou ocorrência 31 (Alteração de Outros Dados).    
        ///
        ///Qualquer outra ocorrência diferente de 01 e 31 informada no registro com segmento tipo P, será 
        ///considerada erro com envio de mensagem de  erro - Registro inválido.
        /// </summary>
        /// <param name="CodigoBanco">N.º DO BANCO NA CÂMARA DE COMPENSAÇÃO</param>
        /// <param name="CodigoLote">LOTE DE SERVIÇO</param>
        /// <param name="TipoRegistro">REGISTRO DETALHE</param>
        /// <param name="NumeroRegistro">N.º SEQUENCIAL DO REGISTRO NO LOTE</param>
        /// <param name="Segmento">CÓD. SEGMENTO DO REGISTRO DETALHE</param>
        /// <param name="Branco_1">COMPLEMENTO DE REGISTRO</param>
        /// <param name="CodigoOcorrencia">IDENTIFICAÇÃO DA OCORRÊNCIA</param>
        /// <param name="Zero_1">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Data2_Desconto">DATA DO 2º DESCONTO</param>
        /// <param name="Valor2_Desconto">VALOR DO 2º DESCONTO A SER CONCEDIDO</param>
        /// <param name="Zero_2">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Data3_Desconto">DATA DO 3º DESCONTO</param>
        /// <param name="Valor3_Desconto">VALOR DO 3º DESCONTO A SER CONCEDIDO</param>
        /// <param name="CodigoMulta">CÓDIGO DA MULTA</param>
        /// <param name="DataMulta">DATA DA MULTA</param>
        /// <param name="Multa">VALOR/PERCENTUAL A SER APLICADO</param>
        /// <param name="Branco_2">COMPLEMENTO DE REGISTRO</param>
        /// <param name="InformacaoPagador">CONTEÚDO INDICADO SERÁ IMPRESSO NO RODAPÉ DO CAMPO 'INSTRUÇÕES'</param>
        /// <param name="Branco_3">COMPLEMENTO DE REGISTRO</param>
        /// <param name="CodigoOcorrenciaPagador">CÓDIGOS DE OCORRÊNCIA DO PAGADOR</param>
        /// <param name="Zero_3">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Branco_4">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Zero_4">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Branco_5">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Zero_5">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Branco_6">COMPLEMENTO DE REGISTRO</param>
        /// <returns></returns>
        public static string RemessaSegmentoR(
                                                int CodigoBanco,
                                                int CodigoLote,
                                                int TipoRegistro,
                                                int NumeroRegistro,
                                                string Segmento,
                                                string Branco_1,
                                                int CodigoOcorrencia,
                                                int Zero_1,
                                                DateTime Data2_Desconto,
                                                decimal Valor2_Desconto,
                                                int Zero_2,
                                                DateTime Data3_Desconto,
                                                decimal Valor3_Desconto,
                                                int CodigoMulta,
                                                DateTime DataMulta,//Confirmar o Tipo.
                                                string Multa,
                                                string Branco_2,
                                                string InformacaoPagador,
                                                string Branco_3,
                                                int CodigoOcorrenciaPagador,
                                                int Zero_3,
                                                string Branco_4,
                                                int Zero_4,
                                                string Branco_5,
                                                int Zero_5,
                                                string Branco_6
                                            )
        {
            string SegmentoR = "";

            SegmentoR += Util.PreencheCampoInt(CodigoBanco, 3);
            SegmentoR += Util.PreencheCampoInt(CodigoLote, 4);
            SegmentoR += Util.PreencheCampoInt(TipoRegistro, 1);
            SegmentoR += Util.PreencheCampoInt(NumeroRegistro, 5);
            SegmentoR += Util.PreencheCampoString(Segmento, 1);
            SegmentoR += Util.PreencheCampoString(Branco_1, 1);
            SegmentoR += Util.PreencheCampoInt(CodigoOcorrencia, 2);
            SegmentoR += Util.PreencheCampoInt(Zero_1, 1);
            SegmentoR += Util.PreencheCampoData(Data2_Desconto, 8);
            SegmentoR += Util.PreencheCampoDecimal(Valor2_Desconto, 13);
            SegmentoR += Util.PreencheCampoInt(Zero_2, 1);
            SegmentoR += Util.PreencheCampoData(Data3_Desconto, 8);
            SegmentoR += Util.PreencheCampoDecimal(Valor3_Desconto, 13);
            SegmentoR += Util.PreencheCampoInt(CodigoMulta, 1);
            SegmentoR += Util.PreencheCampoData(DataMulta, 8);//Confirmar o Tipo.
            SegmentoR += Util.PreencheCampoString(Multa, 13);
            SegmentoR += Util.PreencheCampoString(Branco_2, 10);
            SegmentoR += Util.PreencheCampoString(InformacaoPagador, 40);
            SegmentoR += Util.PreencheCampoString(Branco_3, 60);
            SegmentoR += Util.PreencheCampoInt(CodigoOcorrenciaPagador, 8);
            SegmentoR += Util.PreencheCampoInt(Zero_3, 8);
            SegmentoR += Util.PreencheCampoString(Branco_4, 1);
            SegmentoR += Util.PreencheCampoInt(Zero_4, 12);
            SegmentoR += Util.PreencheCampoString(Branco_5, 2);
            SegmentoR += Util.PreencheCampoInt(Zero_5, 1);
            SegmentoR += Util.PreencheCampoString(Branco_6, 9);

            return SegmentoR;
        }

        /// <summary>
        /// ARQUIVO REMESSA - REGISTRO DETALHE - SEGMENTO Y - (OPCIONAL PARA INFORMAÇÃO DE DADOS DO SACADOR AVALISTA)
        /// Sacador - Dados sobre o BENEFICIÁRIO original do título de cobrança.
        /// </summary>
        /// <param name="CodigoBanco"></param>
        /// <param name="CodigoLote"></param>
        /// <param name="TipoRegistro"></param>
        /// <param name="NumeroRegistro"></param>
        /// <param name="Segmento"></param>
        /// <param name="Branco_1"></param>
        /// <param name="CodigoOcorrencia"></param>
        /// <param name="CodigoRegistroOpcional"></param>
        /// <param name="CodigoInscricao"></param>
        /// <param name="InscricaoNumero"></param>
        /// <param name="NomeSacadorAvalista"></param>
        /// <param name="EnderecoSacador"></param>
        /// <param name="BairroSacador"></param>
        /// <param name="CepSacador"></param>
        /// <param name="CidadeSacador"></param>
        /// <param name="UFSacador"></param>
        /// <param name="Branco"></param>
        /// <returns></returns>
        public static string RemessaSegmentoY(
                                                int CodigoBanco,
                                                int CodigoLote,
                                                int TipoRegistro,
                                                int NumeroRegistro,
                                                string Segmento,
                                                string Branco_1,
                                                int CodigoOcorrencia,
                                                int CodigoRegistroOpcional,
                                                int CodigoInscricao,
                                                int InscricaoNumero,
                                                string NomeSacadorAvalista,
                                                string EnderecoSacador,
                                                string BairroSacador,
                                                int CepSacador,
                                                string CidadeSacador,
                                                string UFSacador,
                                                string Branco
                                            )
        {
            string SegmentoY = "";

            SegmentoY += Util.PreencheCampoInt(CodigoBanco, 3);
            SegmentoY += Util.PreencheCampoInt(CodigoLote, 4);
            SegmentoY += Util.PreencheCampoInt(TipoRegistro, 1);
            SegmentoY += Util.PreencheCampoInt(NumeroRegistro, 5);
            SegmentoY += Util.PreencheCampoString(Segmento, 1);
            SegmentoY += Util.PreencheCampoString(Branco_1, 1);
            SegmentoY += Util.PreencheCampoInt(CodigoOcorrencia, 2);
            SegmentoY += Util.PreencheCampoInt(CodigoRegistroOpcional, 2);
            SegmentoY += Util.PreencheCampoInt(CodigoInscricao, 1);
            SegmentoY += Util.PreencheCampoInt(InscricaoNumero, 15);
            SegmentoY += Util.PreencheCampoString(NomeSacadorAvalista, 40);
            SegmentoY += Util.PreencheCampoString(EnderecoSacador, 40);
            SegmentoY += Util.PreencheCampoString(BairroSacador, 15);
            SegmentoY += Util.PreencheCampoInt(CepSacador, 8);
            SegmentoY += Util.PreencheCampoString(CidadeSacador, 15);
            SegmentoY += Util.PreencheCampoString(UFSacador, 2);
            SegmentoY += Util.PreencheCampoString(Branco, 85);

            return SegmentoY;
        }

        /// <summary>
        /// ARQUIVO REMESSA/RETORNO - REGISTRO TRAILER DE LOTE
        /// NESTE REGISTRO SÃO TOTALIZADOS OS DADOS DO LOTE
        /// </summary>
        /// <param name="CodigoBanco">N.º DO BANCO NA CÂMARA DE COMPENSAÇÃO</param>
        /// <param name="CodigoLote">LOTE DE SERVIÇO</param>
        /// <param name="TipoRegistro">REGISTRO TRAILER DO LOTE</param>
        /// <param name="Branco_1">COMPLEMENTO DE REGISTRO</param>
        /// <param name="QtdeRegistros">QUANTIDADE DE REGISTROS DO LOTE</param>
        /// <param name="QtdeCobrancaSimple">QTDE. DE TÍTULOS EM COBRANÇA SIMPLES</param>
        /// <param name="ValorCobrancaSimple">VALOR TOTAL TÍTULOS EM COBRANÇA SIMPLES</param>
        /// <param name="QtdeCobrancaVinculada">QTDE. DE TÍTULOS EM COBRANÇA VINCULADA</param>
        /// <param name="ValorCobrancaVinculada">VALOR TOTAL TÍTULOS EM COBRANÇA VINCULADA</param>
        /// <param name="Zero">COMPLEMENTO DE REGISTRO</param>
        /// <param name="AvisoBancario">REFERÊNCIA DO AVISO BANCÁRIO</param>
        /// <param name="Branco">COMPLEMENTO DE REGISTRO</param>
        /// <returns></returns>
        public static string RemessaTrailerLote(
                                                int CodigoBanco,
                                                int CodigoLote,
                                                int TipoRegistro,
                                                string Branco_1,
                                                int QtdeRegistros,
                                                int QtdeCobrancaSimple,
                                                decimal ValorCobrancaSimple,
                                                int QtdeCobrancaVinculada,
                                                decimal ValorCobrancaVinculada,
                                                int Zero,
                                                string AvisoBancario,
                                                string Branco
                                                )
        {
            string TrailerLote = "";

            TrailerLote += Util.PreencheCampoInt(CodigoBanco, 3);
            TrailerLote += Util.PreencheCampoInt(CodigoLote, 4);
            TrailerLote += Util.PreencheCampoInt(TipoRegistro, 1);
            TrailerLote += Util.PreencheCampoString(Branco_1, 9);
            TrailerLote += Util.PreencheCampoInt(QtdeRegistros, 6);
            TrailerLote += Util.PreencheCampoInt(QtdeCobrancaSimple, 6);
            TrailerLote += Util.PreencheCampoDecimal(ValorCobrancaSimple, 15);
            TrailerLote += Util.PreencheCampoInt(QtdeCobrancaVinculada, 6);
            TrailerLote += Util.PreencheCampoDecimal(ValorCobrancaVinculada, 15);
            TrailerLote += Util.PreencheCampoInt(Zero, 46);
            TrailerLote += Util.PreencheCampoString(AvisoBancario, 8);
            TrailerLote += Util.PreencheCampoString(Branco, 117);

            return TrailerLote;
        }

        /// <summary>
        /// ARQUIVO REMESSA/RETORNO - REGISTRO TRAILER DE ARQUIVO
        /// </summary>
        /// <param name="CodigoBanco">N.º DO BANCO NA CÂMARA DE COMPENSAÇÃO</param>
        /// <param name="CodigoLote">LOTE DE SERVIÇO</param>
        /// <param name="Registro">REGISTRO TRAILER DE ARQUIVO</param>
        /// <param name="Branco_1">COMPLEMENTO DE REGISTRO</param>
        /// <param name="TotalLotes">QUANTIDADE DE LOTES DO ARQUIVO</param>
        /// <param name="TotalRegistros">QUANTIDADE DE REGISTROS DO ARQUIVO</param>
        /// <param name="Zero">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Branco_2">COMPLEMENTO DE REGISTRO</param>
        /// <returns></returns>
        public static string RemessaTrailer(
                                            int CodigoBanco,
                                            int CodigoLote,
                                            int Registro,
                                            string Branco_1,
                                            int TotalLotes,
                                            int TotalRegistros,
                                            int Zero,
                                            string Branco_2
                                            )
        {
            string Trailer = "";
            Trailer += Util.PreencheCampoInt(CodigoBanco, 3);
            Trailer += Util.PreencheCampoInt(CodigoLote, 4);
            Trailer += Util.PreencheCampoInt(Registro, 1);
            Trailer += Util.PreencheCampoString(Branco_1, 9);
            Trailer += Util.PreencheCampoInt(TotalLotes, 6);
            Trailer += Util.PreencheCampoInt(TotalRegistros, 6);
            Trailer += Util.PreencheCampoInt(Zero, 6);
            Trailer += Util.PreencheCampoString(Branco_2, 205);
            return Trailer;
        }

        /// <summary>
        /// ARQUIVO RETORNO - REGISTRO DETALHE - SEGMENTO T - (OBRIGATÓRIO)
        /// </summary>
        /// <param name="CodigoBanco">N.º DO BANCO NA CÂMARA DE COMPENSAÇÃO</param>
        /// <param name="CodigoLote">LOTE DE SERVIÇO</param>
        /// <param name="TipoRegistro">REGISTRO DETALHE</param>
        /// <param name="NumeroRegistro">N.º SEQUENCIAL DO REGISTRO NO LOTE</param>
        /// <param name="Segmento">CÓD. SEGMENTO DO REGISTRO DETALHE</param>
        /// <param name="BoletoDDA">INDICADOR DE BOLETO DDA</param>
        /// <param name="CodigoOcorrencia">IDENTIFICAÇÃO DA OCORRÊNCIA</param>
        /// <param name="Zero_1">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Agencia">AGÊNCIA MANTENEDORA DA CONTA</param>
        /// <param name="Zero_2">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Conta">N.º DA CONTA CORRENTE DA EMPRESA</param>
        /// <param name="Zero_3">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Dac_Empresa">DÍGITO DE AUTO-CONFERÊNCIA AG/CONTA EMPRESA</param>
        /// <param name="NumeroCarteira">NÚMERO DA CARTEIRA NO BANCO</param>
        /// <param name="NossoNumero">IDENTIFICAÇÃO DO TÍTULO NO BANCO</param>
        /// <param name="Dac_NossoNumero">DÍGITO DE AUTO-CONFERÊNCIA NOSSO NÚMERO</param>
        /// <param name="Branco_1">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Zero_4">COMPLEMENTO DE REGISTRO</param>
        /// <param name="SeuNumero">N.º DOCUMENTO DE COBRANÇA (DUPL.NP...)</param>
        /// <param name="Branco_2">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Vencimento">DATA DO VENCIMENTO DO TÍTULO</param>
        /// <param name="ValorTitulo">VALOR NOMINAL DO TÍTULO</param>
        /// <param name="Zero_5">COMPLEMENTO DE REGISTRO</param>
        /// <param name="AgenciaCobradora">AG. COBRADORA, AG. DE LIQUIDAÇÃO OU BAIXA</param>
        /// <param name="Dac_AgenciaCobradora">DÍGITO AUTO-CONFERÊNCIA AGÊNCIA COBRADORA</param>
        /// <param name="UsoEmpresa">IDENTIFICAÇÃO DO TÍTULO NA EMPRESA</param>
        /// <param name="Zero_6">COMPLEMENTO DE REGISTRO</param>
        /// <param name="CodigoInscricao">TIPO DE INSCRIÇÃO DO PAGADOR</param>
        /// <param name="InscricaoNumero">NÚMERO DE INSCRIÇÃO DO PAGADOR</param>
        /// <param name="NomePagador">NOME DO PAGADOR</param>
        /// <param name="Branco_3">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Zero_7">COMPLEMENTO DE REGISTRO</param>
        /// <param name="TarifasCustas">VALOR DA DESPESA DE COBRANÇA, CUSTAS SÃO REPASSADAS AO CARTÓRIO</param>
        /// <param name="erros">IDENTIFICAÇÃO PARA REGISTROS REJEITADOS</param>
        /// <param name="CodigoLiquidacao">MEIO PELO QUAL O TÍTULO FOI LIQUIDADO</param>
        /// <param name="Branco_4">COMPLEMENTO DE REGISTRO</param>
        /// <returns></returns>
        public static string RemessaSegmentoT(
                                                int CodigoBanco,
                                                int CodigoLote,
                                                int TipoRegistro,
                                                int NumeroRegistro,
                                                string Segmento,
                                                string BoletoDDA,
                                                int CodigoOcorrencia,
                                                int Zero_1,
                                                int Agencia,
                                                int Zero_2,
                                                int Conta,
                                                int Zero_3,
                                                int Dac_Empresa,
                                                int NumeroCarteira,
                                                int NossoNumero,
                                                int Dac_NossoNumero,
                                                string Branco_1,
                                                int Zero_4,
                                                string SeuNumero,
                                                string Branco_2,
                                                DateTime Vencimento,
                                                decimal ValorTitulo,
                                                int Zero_5,
                                                int AgenciaCobradora,
                                                int Dac_AgenciaCobradora,
                                                string UsoEmpresa,
                                                int Zero_6,
                                                int CodigoInscricao,
                                                int InscricaoNumero,
                                                string NomePagador,
                                                string Branco_3,
                                                int Zero_7,
                                                decimal TarifasCustas,
                                                int erros,
                                                string CodigoLiquidacao,
                                                string Branco_4
                                            )
        {
            string RemessaT = "";

            RemessaT += Util.PreencheCampoInt(CodigoBanco, 3);
            RemessaT += Util.PreencheCampoInt(CodigoLote, 4);
            RemessaT += Util.PreencheCampoInt(TipoRegistro, 1);
            RemessaT += Util.PreencheCampoInt(NumeroRegistro, 5);
            RemessaT += Util.PreencheCampoString(Segmento, 1);
            RemessaT += Util.PreencheCampoString(BoletoDDA, 1);
            RemessaT += Util.PreencheCampoInt(CodigoOcorrencia, 2);
            RemessaT += Util.PreencheCampoInt(Zero_1, 1);
            RemessaT += Util.PreencheCampoInt(Agencia, 4);
            RemessaT += Util.PreencheCampoInt(Zero_2, 8);
            RemessaT += Util.PreencheCampoInt(Conta, 5);
            RemessaT += Util.PreencheCampoInt(Zero_3, 1);
            RemessaT += Util.PreencheCampoInt(Dac_Empresa, 1);
            RemessaT += Util.PreencheCampoInt(NumeroCarteira, 3);
            RemessaT += Util.PreencheCampoInt(NossoNumero, 8);
            RemessaT += Util.PreencheCampoInt(Dac_NossoNumero, 1);
            RemessaT += Util.PreencheCampoString(Branco_1, 8);
            RemessaT += Util.PreencheCampoInt(Zero_4, 1);
            RemessaT += Util.PreencheCampoString(SeuNumero, 10);
            RemessaT += Util.PreencheCampoString(Branco_2, 5);
            RemessaT += Util.PreencheCampoData(Vencimento, 8);
            RemessaT += Util.PreencheCampoDecimal(ValorTitulo, 13);
            RemessaT += Util.PreencheCampoInt(Zero_5, 3);
            RemessaT += Util.PreencheCampoInt(AgenciaCobradora, 5);
            RemessaT += Util.PreencheCampoInt(Dac_AgenciaCobradora, 1);
            RemessaT += Util.PreencheCampoString(UsoEmpresa, 25);
            RemessaT += Util.PreencheCampoInt(Zero_6, 2);
            RemessaT += Util.PreencheCampoInt(CodigoInscricao, 1);
            RemessaT += Util.PreencheCampoInt(InscricaoNumero, 15);
            RemessaT += Util.PreencheCampoString(NomePagador, 30);
            RemessaT += Util.PreencheCampoString(Branco_3, 10);
            RemessaT += Util.PreencheCampoInt(Zero_7, 10);
            RemessaT += Util.PreencheCampoDecimal(TarifasCustas, 13);
            RemessaT += Util.PreencheCampoInt(erros, 8);
            RemessaT += Util.PreencheCampoString(CodigoLiquidacao, 2);
            RemessaT += Util.PreencheCampoString(Branco_4, 17);

            return RemessaT;
        }

        /// <summary>
        /// ARQUIVO RETORNO - REGISTRO DETALHE - SEGMENTO U - (OBRIGATÓRIO)
        /// </summary>
        /// <param name="CodigoBanco">N.º DO BANCO NA CÂMARA DE COMPENSAÇÃO</param>
        /// <param name="CodigoLote">LOTE DE SERVIÇO</param>
        /// <param name="Registro">REGISTRO DETALHE</param>
        /// <param name="NumeroRegistro">N.º SEQUENCIAL DO REGISTRO NO LOTE</param>
        /// <param name="Segmento">CÓD. SEGMENTO DO REGISTRO DETALHE</param>
        /// <param name="Branco_1">COMPLEMENTO DE REGISTRO</param>
        /// <param name="CodigoOcorrencia">IDENTIFICAÇÃO DA OCORRÊNCIA</param>
        /// <param name="JurosMulta">JUROS DE MORA/MULTA</param>
        /// <param name="ValorDesconto">VALOR DO DESCONTO CONCEDIDO</param>
        /// <param name="ValorAbatimento">VALOR DO ABATIMENTO CONCEDIDO</param>
        /// <param name="ValorIOF">VALOR DO IOF RECOLHIDO</param>
        /// <param name="ValorCreditado1">VALOR LANÇADO EM CONTA CORRENTE</param>
        /// <param name="ValorCreditado2">VALOR LANÇADO EM CONTA CORRENTE</param>
        /// <param name="Zero_1">COMPLEMENTO DE REGISTRO</param>
        /// <param name="DataOcorrenciaBanco">DATA DE OCORRÊNCIA NO BANCO (DATA DA GERAÇÃO DO ARQUIVO)</param>
        /// <param name="DataCredito">DATA DE CRÉDITO DESTA LIQUIDAÇÃO</param>
        /// <param name="OcorrenciaPagador">CÓDIGO DA OCORRÊNCIA DO PAGADOR</param>
        /// <param name="DataOcorrenciaPagador">DATA DA OCORRÊNCIA DO PAGADOR</param>
        /// <param name="ValorOcorrencia">VALOR DA OCORRÊNCIA DO PAGADOR</param>
        /// <param name="Branco_2">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Zero_2">COMPLEMENTO DE REGISTRO</param>
        /// <param name="Branco_3">COMPLEMENTO DE REGISTRO</param>
        /// <returns></returns>
        public static string RemessaSegmentoU(int CodigoBanco,
                                                int CodigoLote,
                                                int Registro,
                                                int NumeroRegistro,
                                                string Segmento,
                                                string Branco_1,
                                                int CodigoOcorrencia,
                                                decimal JurosMulta,
                                                decimal ValorDesconto,
                                                decimal ValorAbatimento,
                                                decimal ValorIOF,
                                                decimal ValorCreditado1,
                                                decimal ValorCreditado2,
                                                int Zero_1,
                                                DateTime DataOcorrenciaBanco,
                                                DateTime DataCredito,
                                                int OcorrenciaPagador,
                                                DateTime DataOcorrenciaPagador,
                                                decimal ValorOcorrencia,
                                                string Branco_2,
                                                int Zero_2,
                                                string Branco_3
                                                )
        {

            string RemessaU = "";

            RemessaU += Util.PreencheCampoInt(CodigoBanco, 3);
            RemessaU += Util.PreencheCampoInt(CodigoLote, 4);
            RemessaU += Util.PreencheCampoInt(Registro, 1);
            RemessaU += Util.PreencheCampoInt(NumeroRegistro, 5);
            RemessaU += Util.PreencheCampoString(Segmento, 1);
            RemessaU += Util.PreencheCampoString(Branco_1, 1);
            RemessaU += Util.PreencheCampoInt(CodigoOcorrencia, 2);
            RemessaU += Util.PreencheCampoDecimal(JurosMulta, 13);
            RemessaU += Util.PreencheCampoDecimal(ValorDesconto, 13);
            RemessaU += Util.PreencheCampoDecimal(ValorAbatimento, 13);
            RemessaU += Util.PreencheCampoDecimal(ValorIOF, 13);
            RemessaU += Util.PreencheCampoDecimal(ValorCreditado1, 13);
            RemessaU += Util.PreencheCampoDecimal(ValorCreditado2, 13);
            RemessaU += Util.PreencheCampoInt(Zero_1, 30);
            RemessaU += Util.PreencheCampoData(DataOcorrenciaBanco, 8);
            RemessaU += Util.PreencheCampoData(DataCredito, 8);
            RemessaU += Util.PreencheCampoInt(OcorrenciaPagador, 4);
            RemessaU += Util.PreencheCampoData(DataOcorrenciaPagador, 8);
            RemessaU += Util.PreencheCampoDecimal(ValorOcorrencia, 13);
            RemessaU += Util.PreencheCampoString(Branco_2, 30);
            RemessaU += Util.PreencheCampoInt(Zero_2, 23);
            RemessaU += Util.PreencheCampoString(Branco_3, 7);

            return RemessaU;
        }

        #endregion
    }
}
