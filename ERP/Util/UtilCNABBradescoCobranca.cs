using System;

namespace ERP.Util
{
    public static class UtilCNABBradescoCobranca
    {
        /// <summary>
        /// REGISTRO HEADER DE ARQUIVO
        /// </summary>
        /// <param name="ControleBanco">Código do Banco na Compensação</param>
        /// <param name="ControleLote">Lote de Serviço</param>
        /// <param name="ControleRegistro">Tipo de Registro</param>
        /// <param name="CNAB_1">Uso Exclusivo FEBRABAN / CNAB</param>
        /// <param name="EmpIns_Tipo">Tipo de Inscrição da Empresa</param>
        /// <param name="EmpIns_Numero">Número de Inscrição da Empresa</param>
        /// <param name="Emp_Convenio">Código do Convênio no Banco</param>
        /// <param name="EmpCcAg_Codigo">Agência Mantenedora da Conta</param>
        /// <param name="EmpCcAg_DV">Dígito Verificador da Agência</param>
        /// <param name="EmpCcCon_Numero">Número da Conta Corrente</param>
        /// <param name="EmpCcCon_DV">Dígito Verificador da Conta</param>
        /// <param name="EmpCc_DV">Dígito Verificador da Ag/Conta</param>
        /// <param name="Emp_Nome">Nome da Empresa</param>
        /// <param name="NomeBanco">Nome do Banc</param>
        /// <param name="CNAB_2">Uso Exclusivo FEBRABAN / CNAB</param>
        /// <param name="Arq_Codigo">Código Remessa / Retorno</param>
        /// <param name="Arq_DataGeracao">Data de Geração do Arquivo</param>
        /// <param name="Arq_HoraGeracao">Hora de Geração do Arquivo</param>
        /// <param name="Arq_SequenciaNSA">Número Seqüencial do Arquivo</param>
        /// <param name="Arq_LayoutArq">No da Versão do Layout do Arquivo</param>
        /// <param name="Arq_Densidade">Densidade de Gravação do Arquivo</param>
        /// <param name="ReservadoBanco">Para Uso Reservado do Banco</param>
        /// <param name="ReservadoEmpresa" >Para Uso Reservado da Empresa</param>
        /// <param name="CNAB_3">Uso Exclusivo FEBRABAN / CNAB</param>
        /// <returns></returns>
        public static string RegistroHeaderArquivo(int ControleBanco,
                                                   int ControleLote,
                                                   int ControleRegistro,
                                                   string CNAB_1,
                                                   int EmpIns_Tipo,
                                                   int EmpIns_Numero,
                                                   string Emp_Convenio,
                                                   int EmpCcAg_Codigo,
                                                   string EmpCcAg_DV,
                                                   int EmpCcCon_Numero,
                                                   string EmpCcCon_DV,
                                                   string EmpCc_DV,
                                                   string Emp_Nome,
                                                   string NomeBanco,
                                                   string CNAB_2,
                                                   int Arq_Codigo,
                                                   DateTime Arq_DataGeracao,
                                                   DateTime Arq_HoraGeracao,
                                                   int Arq_SequenciaNSA,
                                                   int Arq_LayoutArq,
                                                   int Arq_Densidade,
                                                   string ReservadoBanco,
                                                   string ReservadoEmpresa,
                                                   string CNAB_3
                                                  )
        {
            string HeaderArquivo = "";

            HeaderArquivo += Util.PreencheCampoInt(ControleBanco, 3);
            HeaderArquivo += Util.PreencheCampoInt(ControleLote, 4);
            HeaderArquivo += Util.PreencheCampoInt(ControleRegistro, 1);
            HeaderArquivo += Util.PreencheCampoString(CNAB_1, 9);
            HeaderArquivo += Util.PreencheCampoInt(EmpIns_Tipo, 1);
            HeaderArquivo += Util.PreencheCampoInt(EmpIns_Numero, 14);
            HeaderArquivo += Util.PreencheCampoString(Emp_Convenio, 20);
            HeaderArquivo += Util.PreencheCampoInt(EmpCcAg_Codigo, 5);
            HeaderArquivo += Util.PreencheCampoString(EmpCcAg_DV, 1);
            HeaderArquivo += Util.PreencheCampoInt(EmpCcCon_Numero, 12);
            HeaderArquivo += Util.PreencheCampoString(EmpCcCon_DV, 1);
            HeaderArquivo += Util.PreencheCampoString(EmpCc_DV, 1);
            HeaderArquivo += Util.PreencheCampoString(Emp_Nome, 30);
            HeaderArquivo += Util.PreencheCampoString(NomeBanco, 30);
            HeaderArquivo += Util.PreencheCampoString(CNAB_2, 10);
            HeaderArquivo += Util.PreencheCampoInt(Arq_Codigo, 1);
            HeaderArquivo += Util.PreencheCampoData(Arq_DataGeracao, 8);
            HeaderArquivo += Util.PreencheCampoHora(Arq_HoraGeracao, 6);
            HeaderArquivo += Util.PreencheCampoInt(Arq_SequenciaNSA, 6);
            HeaderArquivo += Util.PreencheCampoInt(Arq_LayoutArq, 3);
            HeaderArquivo += Util.PreencheCampoInt(Arq_Densidade, 5);
            HeaderArquivo += Util.PreencheCampoString(ReservadoBanco, 20);
            HeaderArquivo += Util.PreencheCampoString(ReservadoEmpresa, 20);
            HeaderArquivo += Util.PreencheCampoString(CNAB_3, 29);

            return HeaderArquivo;
        }

        /// <summary>
        /// REGISTRO TRAILER DE ARQUIVO
        /// </summary>
        /// <param name="ControleBanco">Código do Banco na Compensação</param>
        /// <param name="ControleLote">Lote de Serviço</param>
        /// <param name="ControleRegistro">Tipo de Registro</param>
        /// <param name="CNAB_1">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <param name="Tot_QtdeLotes">Quantidade de Lotes do Arquivo</param>
        /// <param name="Tot_QtdeRegistros">Quantidade de Registros do Arquivo</param>
        /// <param name="Tot_QtdeContasConc">Qtde de Contas p/ Conc. (Lotes)</param>
        /// <param name="CNAB_2">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <returns></returns>
        public static string RegistroTrailerArquivo(int ControleBanco,
                                                   int ControleLote,
                                                   int ControleRegistro,
                                                   string CNAB_1,
                                                   int Tot_QtdeLotes,
                                                   int Tot_QtdeRegistros,
                                                   int Tot_QtdeContasConc,
                                                   string CNAB_2
                                                   )
        {
            string TrailerArquivo = "";

            TrailerArquivo += Util.PreencheCampoInt(ControleBanco, 3);
            TrailerArquivo += Util.PreencheCampoInt(ControleLote, 4);
            TrailerArquivo += Util.PreencheCampoInt(ControleRegistro, 1);
            TrailerArquivo += Util.PreencheCampoString(CNAB_1, 9);
            TrailerArquivo += Util.PreencheCampoInt(Tot_QtdeLotes, 6);
            TrailerArquivo += Util.PreencheCampoInt(Tot_QtdeRegistros, 6);
            TrailerArquivo += Util.PreencheCampoInt(Tot_QtdeContasConc, 6);
            TrailerArquivo += Util.PreencheCampoString(CNAB_2, 205);

            return TrailerArquivo;
        }

        /// <summary>
        /// REGISTRO HEADER DE LOTE
        /// </summary>
        /// <param name="ControleBanco">Código do Banco na Compensação</param>
        /// <param name="ControleLote">Lote de Serviço</param>
        /// <param name="ControleRegistro">Tipo de Registro</param>
        /// <param name="ServicoOperacao">Tipo de Operação</param>
        /// <param name="ServicoServico">Tipo de Serviço</param>
        /// <param name="ServicoCNAB">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <param name="ServicoLayoutLote">Nº da Versão do Layout do Lote</param>
        /// <param name="CNAB_1">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <param name="EmpIns_Tipo">Tipo de Inscrição da Empresa</param>
        /// <param name="EmpIns_Numero">Nº de Inscrição da Empresa</param>
        /// <param name="Emp_Convenio">Código do Convênio no Banco</param>
        /// <param name="EmpCcAg_Codigo">Agência Mantenedora da Conta</param>
        /// <param name="EmpCcAg_DV">Dígito Verificador da Conta</param>
        /// <param name="EmpCcCont_Numero">Número da Conta Corrente</param>
        /// <param name="EmpCcCont_DV">Dígito Verificador da Conta</param>
        /// <param name="EmpCc_DV">Dígito Verificador da Ag/Conta</param>
        /// <param name="Emp_Nome">Nome da Empresa</param>
        /// <param name="Informcacao1">Mensagem 1</param>
        /// <param name="Informcacao2">Mensagem 2</param>
        /// <param name="ContrCobNumRemRet">Número Sequencial Remessa/Retorno</param>
        /// <param name="ContrCobDataGravacao">Data de Gravação Remessa/Retorno</param>
        /// <param name="DataCredito">Data do Crédito</param>
        /// <param name="CNAB_2">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <returns></returns>
        public static string RegistroHeaderLote(int ControleBanco,
                                                int ControleLote,
                                                int ControleRegistro,
                                                string ServicoOperacao,
                                                int ServicoServico,
                                                string ServicoCNAB,
                                                int ServicoLayoutLote,
                                                string CNAB_1,
                                                int EmpIns_Tipo,
                                                int EmpIns_Numero,
                                                string Emp_Convenio,
                                                int EmpCcAg_Codigo,
                                                string EmpCcAg_DV,
                                                int EmpCcCont_Numero,
                                                string EmpCcCont_DV,
                                                string EmpCc_DV,
                                                string Emp_Nome,
                                                string Informcacao1,
                                                string Informcacao2,
                                                int ContrCobNumRemRet,
                                                DateTime ContrCobDataGravacao,
                                                DateTime DataCredito,
                                                string CNAB_2
                                                )
        {
            string HeaderLote = "";

            HeaderLote += Util.PreencheCampoInt(ControleBanco, 3);
            HeaderLote += Util.PreencheCampoInt(ControleLote, 4);
            HeaderLote += Util.PreencheCampoInt(ControleRegistro, 1);
            HeaderLote += Util.PreencheCampoString(ServicoOperacao, 1);
            HeaderLote += Util.PreencheCampoInt(ServicoServico, 2);
            HeaderLote += Util.PreencheCampoString(ServicoCNAB, 2);
            HeaderLote += Util.PreencheCampoInt(ServicoLayoutLote, 3);
            HeaderLote += Util.PreencheCampoString(CNAB_1, 1);
            HeaderLote += Util.PreencheCampoInt(EmpIns_Tipo, 1);
            HeaderLote += Util.PreencheCampoInt(EmpIns_Numero, 15);
            HeaderLote += Util.PreencheCampoString(Emp_Convenio, 20);
            HeaderLote += Util.PreencheCampoInt(EmpCcAg_Codigo, 5);
            HeaderLote += Util.PreencheCampoString(EmpCcAg_DV, 1);
            HeaderLote += Util.PreencheCampoInt(EmpCcCont_Numero, 12);
            HeaderLote += Util.PreencheCampoString(EmpCcCont_DV, 1);
            HeaderLote += Util.PreencheCampoString(EmpCc_DV, 1);
            HeaderLote += Util.PreencheCampoString(Emp_Nome, 30);
            HeaderLote += Util.PreencheCampoString(Informcacao1, 40);
            HeaderLote += Util.PreencheCampoString(Informcacao2, 40);
            HeaderLote += Util.PreencheCampoInt(ContrCobNumRemRet, 8);
            HeaderLote += Util.PreencheCampoData(ContrCobDataGravacao, 8);
            HeaderLote += Util.PreencheCampoData(DataCredito, 8);
            HeaderLote += Util.PreencheCampoString(CNAB_2, 33);

            return HeaderLote;
        }

        /// <summary>
        /// REGISTRO DETALHE - SEGMENTO P (OBRIGATÓRIO - REMESSA)
        /// </summary>
        /// <param name="ControleBanco">Código do Banco na Compensação</param>
        /// <param name="ControleLote">Lote de Serviço</param>
        /// <param name="ControleRegistro">Tipo de Registro</param>
        /// <param name="ServNumRegistro">Nº Sequencial do Registro no Lote</param>
        /// <param name="ServSegmento">Cód. Segmento do Registro Detalhe</param>
        /// <param name="ServCNAB">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <param name="ServCodMov">Código de Movimento Remessa</param>
        /// <param name="CcAg_Codigo">Agência Mantenedora da Conta</param>
        /// <param name="CcAg_DV">Dígito Verificador da Agência</param>
        /// <param name="CcConta_Numero">Número da Conta Corrente</param>
        /// <param name="CcConta_DV">Dígito Verificador da Conta</param>
        /// <param name="Cc_DV">Dígito Verificador da Ag/Co</param>
        /// <param name="IdentTitulo">Identificação do Produto</param>
        /// <param name="Zeros">Zeros</param>
        /// <param name="NossoNumero">Nosso Número</param>
        /// <param name="DigitoNossoNumero">Digito do nosso Número</param>
        /// <param name="CarCob_Carteira">Código da Carteira</param>
        /// <param name="CarCob_Cadastramento">Forma de Cadastr. do Título no Ba</param>
        /// <param name="CarCob_Documento">Tipo de Documento</param>
        /// <param name="CarCobEmi_Bloqueto">Identificação da Emissão do Bloqueto</param>
        /// <param name="CarCobDis_Bloqueto">Identificação da Distribuição</param>
        /// <param name="NumeroDocumento">Número do Documento de Cobrança</param>
        /// <param name="DataVencimentoTitulo">Data de Vencimento do Título</param>
        /// <param name="ValorTitulo">Valor Nominal do Título</param>
        /// <param name="AgenciaCobradora">Agência Encarregada da Cobrança</param>
        /// <param name="DV_Agencia">Dígito Verificador da Agênc</param>
        /// <param name="EspecieTitulo">Espécie do Título</param>
        /// <param name="Aceite">Identific. de Título Aceito/Não Acei</param>
        /// <param name="DataemissaoTitulo">Data da Emissão do Título</param>
        /// <param name="JurCodJurosMora">Código do Juros de Mora</param>
        /// <param name="JurDataJurosMora">Data do Juros de Mora</param>
        /// <param name="JurJurosMora">Juros de Mora por Dia/Taxa</param>
        /// <param name="DescCodDesconto">Código do Desconto 1</param>
        /// <param name="DescDataDesconto">Data do Desconto 1</param>
        /// <param name="DescDesconto">Valor/Percentual a ser Concedido</param>
        /// <param name="ValorIOF">Valor do IOF a ser Recolhido</param>
        /// <param name="ValorAbatimento">Valor do Abatimento</param>
        /// <param name="UsoEmpBeneficiario">Identificação do Título na Empresa</param>
        /// <param name="CodProtesto">Código para Protesto</param>
        /// <param name="PrazoProtesto">Número de Dias para Protesto</param>
        /// <param name="CodBaixaDevolucao">Código para Baixa/Devolução</param>
        /// <param name="PrazoBaixaDevolucao">Número de Dias para Baixa/Devolução</param>
        /// <param name="CodigoMoeda">Código da Moeda</param>
        /// <param name="NumeroContrato">Nº do Contrato da Operação de Créd.</param>
        /// <param name="CNAB">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <returns></returns>
        public static string RegistroSegmentoP(int ControleBanco,
                                                int ControleLote,
                                                int ControleRegistro,
                                                int ServNumRegistro,
                                                string ServSegmento,
                                                string ServCNAB,
                                                int ServCodMov,
                                                int CcAg_Codigo,
                                                string CcAg_DV,
                                                int CcConta_Numero,
                                                string CcConta_DV,
                                                string Cc_DV,
                                                int IdentTitulo,
                                                int Zeros,
                                                int NossoNumero,
                                                int DigitoNossoNumero,
                                                int CarCob_Carteira,
                                                int CarCob_Cadastramento,
                                                string CarCob_Documento,
                                                int CarCobEmi_Bloqueto,
                                                string CarCobDis_Bloqueto,
                                                string NumeroDocumento,
                                                DateTime DataVencimentoTitulo,
                                                decimal ValorTitulo,
                                                int AgenciaCobradora,
                                                string DV_Agencia,
                                                int EspecieTitulo,
                                                string Aceite,
                                                DateTime DataemissaoTitulo,
                                                int JurCodJurosMora,
                                                DateTime JurDataJurosMora,
                                                decimal JurJurosMora,
                                                int DescCodDesconto,
                                                DateTime DescDataDesconto,
                                                decimal DescDesconto,
                                                decimal ValorIOF,
                                                decimal ValorAbatimento,
                                                string UsoEmpBeneficiario,
                                                int CodProtesto,
                                                int PrazoProtesto,
                                                int CodBaixaDevolucao,
                                                string PrazoBaixaDevolucao,
                                                int CodigoMoeda,
                                                int NumeroContrato,
                                                string CNAB
                                                )
        {
            string SegmentoP = "";

            SegmentoP += Util.PreencheCampoInt(ControleBanco, 3);
            SegmentoP += Util.PreencheCampoInt(ControleLote, 4);
            SegmentoP += Util.PreencheCampoInt(ControleRegistro, 1);
            SegmentoP += Util.PreencheCampoInt(ServNumRegistro, 5);
            SegmentoP += Util.PreencheCampoString(ServSegmento, 1);
            SegmentoP += Util.PreencheCampoString(ServCNAB, 1);
            SegmentoP += Util.PreencheCampoInt(ServCodMov, 2);
            SegmentoP += Util.PreencheCampoInt(CcAg_Codigo, 5);
            SegmentoP += Util.PreencheCampoString(CcAg_DV, 1);
            SegmentoP += Util.PreencheCampoInt(CcConta_Numero, 12);
            SegmentoP += Util.PreencheCampoString(CcConta_DV, 1);
            SegmentoP += Util.PreencheCampoString(Cc_DV, 1);
            SegmentoP += Util.PreencheCampoInt(IdentTitulo, 3);
            SegmentoP += Util.PreencheCampoInt(Zeros, 5);
            SegmentoP += Util.PreencheCampoInt(NossoNumero, 11);
            SegmentoP += Util.PreencheCampoInt(DigitoNossoNumero, 1);
            SegmentoP += Util.PreencheCampoInt(CarCob_Carteira, 1);
            SegmentoP += Util.PreencheCampoInt(CarCob_Cadastramento, 1);
            SegmentoP += Util.PreencheCampoString(CarCob_Documento, 1);
            SegmentoP += Util.PreencheCampoInt(CarCobEmi_Bloqueto, 1);
            SegmentoP += Util.PreencheCampoString(CarCobDis_Bloqueto, 1);
            SegmentoP += Util.PreencheCampoString(NumeroDocumento, 15);
            SegmentoP += Util.PreencheCampoData(DataVencimentoTitulo, 8);
            SegmentoP += Util.PreencheCampoDecimal(ValorTitulo, 13);
            SegmentoP += Util.PreencheCampoInt(AgenciaCobradora, 5);
            SegmentoP += Util.PreencheCampoString(DV_Agencia, 1);
            SegmentoP += Util.PreencheCampoInt(EspecieTitulo, 2);
            SegmentoP += Util.PreencheCampoString(Aceite, 1);
            SegmentoP += Util.PreencheCampoData(DataemissaoTitulo, 8);
            SegmentoP += Util.PreencheCampoInt(JurCodJurosMora, 1);
            SegmentoP += Util.PreencheCampoData(JurDataJurosMora, 8);
            SegmentoP += Util.PreencheCampoDecimal(JurJurosMora, 13);
            SegmentoP += Util.PreencheCampoInt(DescCodDesconto, 1);
            SegmentoP += Util.PreencheCampoData(DescDataDesconto, 8);
            SegmentoP += Util.PreencheCampoDecimal(DescDesconto, 13);
            SegmentoP += Util.PreencheCampoDecimal(ValorIOF, 13);
            SegmentoP += Util.PreencheCampoDecimal(ValorAbatimento, 13);
            SegmentoP += Util.PreencheCampoString(UsoEmpBeneficiario, 25);
            SegmentoP += Util.PreencheCampoInt(CodProtesto, 1);
            SegmentoP += Util.PreencheCampoInt(PrazoProtesto, 2);
            SegmentoP += Util.PreencheCampoInt(CodBaixaDevolucao, 1);
            SegmentoP += Util.PreencheCampoString(PrazoBaixaDevolucao, 3);
            SegmentoP += Util.PreencheCampoInt(CodigoMoeda, 2);
            SegmentoP += Util.PreencheCampoInt(NumeroContrato, 10);
            SegmentoP += Util.PreencheCampoString(CNAB, 1);

            return SegmentoP;
        }

        /// <summary>
        /// REGISTRO DETALHE - SEGMENTO Q (OBRIGATÓRIO - REMESSA)
        /// </summary>
        /// <param name="ControleBanco">Código do Banco na Compensação</param>
        /// <param name="ControleLote">Lote de Serviço</param>
        /// <param name="ControleRegistro">Tipo de Registro</param>
        /// <param name="ServNumRegistro">Nº Sequencial do Registro no Lote</param>
        /// <param name="ServSegmento">Cód. Segmento do Registro Detalhe</param>
        /// <param name="ServCNAB">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <param name="ServCodMov">Código de Movimento Remessa</param>
        /// <param name="DadPagInsTipo">Dados do Pagador - Tipo de Inscrição</param>
        /// <param name="DadPagInsNumero">Dados do Pagador - Número de Inscrição</param>
        /// <param name="DadPagNome">Dados do Pagador - Nome</param>
        /// <param name="DadPagEndereco">Dados do Pagador - Endereço</param>
        /// <param name="DadPagBairro">Dados do Pagador - Bairro</param>
        /// <param name="DadPagCEP">Dados do Pagador - CEP</param>
        /// <param name="DadPagSufCEP">Dados do Pagador - Sufixo do CEP</param>
        /// <param name="DadPagCidade">Dados do Pagador - Cidade</param>
        /// <param name="DadPagUF">Dados do Pagador - Unidade da Federação</param>
        /// <param name="SacAvalInsTipo">Tipo de Inscrição</param>
        /// <param name="SacAvalInsNumero">Número de Inscrição</param>
        /// <param name="SacAvalNome">Nome do Pagadorr/Avalista</param>
        /// <param name="BancoCorrespondente">Cód. Bco. Corresp. na Compensação</param>
        /// <param name="NossoNumBanCorrespondente">Nosso Nº no Banco Correspondente</param>
        /// <param name="CNAB">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <returns></returns>
        public static string RegistroSegmentoQ(int ControleBanco,
                                                int ControleLote,
                                                int ControleRegistro,
                                                int ServNumRegistro,
                                                string ServSegmento,
                                                string ServCNAB,
                                                int ServCodMov,
                                                int DadPagInsTipo,
                                                int DadPagInsNumero,
                                                string DadPagNome,
                                                string DadPagEndereco,
                                                string DadPagBairro,
                                                int DadPagCEP,
                                                int DadPagSufCEP,
                                                string DadPagCidade,
                                                string DadPagUF,
                                                int SacAvalInsTipo,
                                                int SacAvalInsNumero,
                                                string SacAvalNome,
                                                int BancoCorrespondente,
                                                string NossoNumBanCorrespondente,
                                                string CNAB
                                                )
        {
            string SegmentoQ = "";

            SegmentoQ += Util.PreencheCampoInt(ControleBanco, 3);
            SegmentoQ += Util.PreencheCampoInt(ControleLote, 4);
            SegmentoQ += Util.PreencheCampoInt(ControleRegistro, 1);
            SegmentoQ += Util.PreencheCampoInt(ServNumRegistro, 5);
            SegmentoQ += Util.PreencheCampoString(ServSegmento, 1);
            SegmentoQ += Util.PreencheCampoString(ServCNAB, 1);
            SegmentoQ += Util.PreencheCampoInt(ServCodMov, 2);
            SegmentoQ += Util.PreencheCampoInt(DadPagInsTipo, 1);
            SegmentoQ += Util.PreencheCampoInt(DadPagInsNumero, 15);
            SegmentoQ += Util.PreencheCampoString(DadPagNome, 40);
            SegmentoQ += Util.PreencheCampoString(DadPagEndereco, 40);
            SegmentoQ += Util.PreencheCampoString(DadPagBairro, 15);
            SegmentoQ += Util.PreencheCampoInt(DadPagCEP, 5);
            SegmentoQ += Util.PreencheCampoInt(DadPagSufCEP, 3);
            SegmentoQ += Util.PreencheCampoString(DadPagCidade, 15);
            SegmentoQ += Util.PreencheCampoString(DadPagUF, 2);
            SegmentoQ += Util.PreencheCampoInt(SacAvalInsTipo, 1);
            SegmentoQ += Util.PreencheCampoInt(SacAvalInsNumero, 15);
            SegmentoQ += Util.PreencheCampoString(SacAvalNome, 40);
            SegmentoQ += Util.PreencheCampoInt(BancoCorrespondente, 3);
            SegmentoQ += Util.PreencheCampoString(NossoNumBanCorrespondente, 20);
            SegmentoQ += Util.PreencheCampoString(CNAB, 8);

            return SegmentoQ;
        }

        /// <summary>
        /// REGISTRO DETALHE - SEGMENTO R (OPCIONAL - REMESSA)
        /// </summary>
        /// <param name="ControleBanco">Código do Banco na Compensação</param>
        /// <param name="ControleLote">Lote de Serviço</param>
        /// <param name="ControleRegistro">Tipo de Registro</param>
        /// <param name="ServNumRegistro">Nº Sequencial do Registro no Lote</param>
        /// <param name="ServSegmento">Cód. Segmento do Registro Detalhe</param>
        /// <param name="ServCNAB">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <param name="ServCodMov">Código de Movimento Remessa</param>
        /// <param name="Desc2CodDesc2">Código do Desconto 2</param>
        /// <param name="Desc2DataDesc2">Data do Desconto 2</param>
        /// <param name="Desc2DescontoDesc2">Valor/Percentual a ser Concedido</param>
        /// <param name="Desc3CodDesc3">Código do Desconto 3</param>
        /// <param name="Desc3DataDesc3">Data do Desconto 3</param>
        /// <param name="Desc3DescontoDesc3">Valor/Percentual a Ser Concedido</param>
        /// <param name="MultaCodMulta">Código da Multa</param>
        /// <param name="MultaDataMulta">Data da Multa</param>
        /// <param name="MultaValorMulta">Valor/Percentual a Ser Aplicado</param>
        /// <param name="InformacaoPagador">Informação ao Pagador</param>
        /// <param name="Informacao3">Mensagem 3</param>
        /// <param name="Informacao4">Mensagem 4</param>
        /// <param name="CNAB_1">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <param name="CodOcorPagador">Cód. Ocor. do Pagador</param>
        /// <param name="DadDebBanco">Cód. do Banco na Conta do Débito</param>
        /// <param name="DadDebAgenciaCodigo">Código da Agência do Débito</param>
        /// <param name="DadDebAgenciaDV">Dígito Verificador da Agência</param>
        /// <param name="DadDebCcDebito">Conta Corrente para Débito</param>
        /// <param name="DadDebCcDebitoDV">Dígito Verificador da Conta</param>
        /// <param name="DadDebCcDV">Dígito Verificador Ag/Conta</param>
        /// <param name="IdentEmiAviDéb">Aviso para Débito Automático</param>
        /// <param name="CNAB_2">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <returns></returns>
        public static string RegistroSegmentoR(int ControleBanco,
                                                int ControleLote,
                                                int ControleRegistro,
                                                int ServNumRegistro,
                                                string ServSegmento,
                                                string ServCNAB,
                                                int ServCodMov,
                                                int Desc2CodDesc2,
                                                DateTime Desc2DataDesc2,
                                                decimal Desc2DescontoDesc2,
                                                int Desc3CodDesc3,
                                                DateTime Desc3DataDesc3,
                                                decimal Desc3DescontoDesc3,
                                                int MultaCodMulta,
                                                DateTime MultaDataMulta,
                                                decimal MultaValorMulta,
                                                string InformacaoPagador,
                                                string Informacao3,
                                                string Informacao4,
                                                string CNAB_1,
                                                int CodOcorPagador,
                                                int DadDebBanco,
                                                int DadDebAgenciaCodigo,
                                                string DadDebAgenciaDV,
                                                int DadDebCcDebito,
                                                string DadDebCcDebitoDV,
                                                string DadDebCcDV,
                                                int IdentEmiAviDéb,
                                                string CNAB_2
                                                )
        {
            string SegmentoR = "";

            SegmentoR += Util.PreencheCampoInt(ControleBanco, 3);
            SegmentoR += Util.PreencheCampoInt(ControleLote, 4);
            SegmentoR += Util.PreencheCampoInt(ControleRegistro, 1);
            SegmentoR += Util.PreencheCampoInt(ServNumRegistro, 5);
            SegmentoR += Util.PreencheCampoString(ServSegmento, 1);
            SegmentoR += Util.PreencheCampoString(ServCNAB, 1);
            SegmentoR += Util.PreencheCampoInt(ServCodMov, 2);
            SegmentoR += Util.PreencheCampoInt(Desc2CodDesc2, 1);
            SegmentoR += Util.PreencheCampoData(Desc2DataDesc2, 8);
            SegmentoR += Util.PreencheCampoDecimal(Desc2DescontoDesc2, 13);
            SegmentoR += Util.PreencheCampoInt(Desc3CodDesc3, 1);
            SegmentoR += Util.PreencheCampoData(Desc3DataDesc3, 8);
            SegmentoR += Util.PreencheCampoDecimal(Desc3DescontoDesc3, 13);
            SegmentoR += Util.PreencheCampoInt(MultaCodMulta, 1);
            SegmentoR += Util.PreencheCampoData(MultaDataMulta, 8);
            SegmentoR += Util.PreencheCampoDecimal(MultaValorMulta, 13);
            SegmentoR += Util.PreencheCampoString(InformacaoPagador, 10);
            SegmentoR += Util.PreencheCampoString(Informacao3, 40);
            SegmentoR += Util.PreencheCampoString(Informacao4, 40);
            SegmentoR += Util.PreencheCampoString(CNAB_1, 20);
            SegmentoR += Util.PreencheCampoInt(CodOcorPagador, 8);
            SegmentoR += Util.PreencheCampoInt(DadDebBanco, 3);
            SegmentoR += Util.PreencheCampoInt(DadDebAgenciaCodigo, 5);
            SegmentoR += Util.PreencheCampoString(DadDebAgenciaDV, 1);
            SegmentoR += Util.PreencheCampoInt(DadDebCcDebito, 12);
            SegmentoR += Util.PreencheCampoString(DadDebCcDebitoDV, 1);
            SegmentoR += Util.PreencheCampoString(DadDebCcDV, 1);
            SegmentoR += Util.PreencheCampoInt(IdentEmiAviDéb, 1);
            SegmentoR += Util.PreencheCampoString(CNAB_2, 9);

            return SegmentoR;
        }

        /// <summary>
        /// REGISTRO DETALHE - SEGMENTO S (OPCIONAL - REMESSA)
        /// </summary>
        /// <param name="ControleBanco">Código do Banco na Compensação</param>
        /// <param name="ControleLote">Lote de Serviço</param>
        /// <param name="ControleRegistro">Tipo de Registr</param>
        /// <param name="ServNumRegistro">Nº Sequencial do Registro no Lote</param>
        /// <param name="ServSegmento">Cód. Segmento do Registro Detalhe</param>
        /// <param name="ServCNAB">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <param name="ServCodMov">Código de Movimento Remessa</param>
        /// <param name="TipoImpressao_1_2">Identificação da Impressão</param>
        /// <param name="NumLinha">Número da Linha a ser Impressa</param>
        /// <param name="Mensagem">Mensagem a ser Impressa</param>
        /// <param name="TipoFonte">Tipo do Caracter a ser Impresso</param>
        /// <param name="CNAB_1">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <param name="TipoImpressao_3">Identificação da Impressão</param>
        /// <param name="Informacao5">Mensagem 5</param>
        /// <param name="Informacao6">Mensagem 6</param>
        /// <param name="Informacao7">Mensagem 7</param>
        /// <param name="Informacao8">Mensagem 8</param>
        /// <param name="Informacao9">Mensagem 9</param>
        /// <param name="CNAB_2">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <returns></returns>
        public static string RegistroSegmentoS(int ControleBanco,
                                                int ControleLote,
                                                int ControleRegistro,
                                                int ServNumRegistro,
                                                string ServSegmento,
                                                string ServCNAB,
                                                int ServCodMov,
                                                int TipoImpressao_1_2,
                                                int NumLinha,
                                                string Mensagem,
                                                int TipoFonte,
                                                string CNAB_1,
                                                int TipoImpressao_3,
                                                string Informacao5,
                                                string Informacao6,
                                                string Informacao7,
                                                string Informacao8,
                                                string Informacao9,
                                                string CNAB_2
                                                )
        {
            string SegmentoS = "";

            SegmentoS += Util.PreencheCampoInt(ControleBanco, 3);
            SegmentoS += Util.PreencheCampoInt(ControleLote, 4);
            SegmentoS += Util.PreencheCampoInt(ControleRegistro, 1);
            SegmentoS += Util.PreencheCampoInt(ServNumRegistro, 5);
            SegmentoS += Util.PreencheCampoString(ServSegmento, 1);
            SegmentoS += Util.PreencheCampoString(ServCNAB, 1);
            SegmentoS += Util.PreencheCampoInt(ServCodMov, 2);
            SegmentoS += Util.PreencheCampoInt(TipoImpressao_1_2, 1);
            SegmentoS += Util.PreencheCampoInt(NumLinha, 2);
            SegmentoS += Util.PreencheCampoString(Mensagem, 140);
            SegmentoS += Util.PreencheCampoInt(TipoFonte, 2);
            SegmentoS += Util.PreencheCampoString(CNAB_1, 78);
            SegmentoS += Util.PreencheCampoInt(TipoImpressao_3, 1);
            SegmentoS += Util.PreencheCampoString(Informacao5, 40);
            SegmentoS += Util.PreencheCampoString(Informacao6, 40);
            SegmentoS += Util.PreencheCampoString(Informacao7, 40);
            SegmentoS += Util.PreencheCampoString(Informacao8, 40);
            SegmentoS += Util.PreencheCampoString(Informacao9, 40);
            SegmentoS += Util.PreencheCampoString(CNAB_2, 22);

            return SegmentoS;
        }

        /// <summary>
        /// REGISTRO DETALHE - SEGMENTO Y-01 (OPCIONAL – REMESSA/RETORNO).
        /// REGISTRO OPCIONAL PARA INFORMAÇÃO DE DADOS DO SACADOR AVALISTA
        /// </summary>
        /// <param name="ControleBanco"></param>
        /// <param name="ControleLote"></param>
        /// <param name="ControleRegistro"></param>
        /// <param name="ServNumRegistro"></param>
        /// <param name="ServSegmento"></param>
        /// <param name="ServCNAB"></param>
        /// <param name="ServCodMov"></param>
        /// <param name="CodRegOpcional"></param>
        /// <param name="SacadorInsTipo"></param>
        /// <param name="SacadorInsNumero"></param>
        /// <param name="SacadorNome"></param>
        /// <param name="SacadorEndereco"></param>
        /// <param name="SacadorBairro"></param>
        /// <param name="SacadorCEP"></param>
        /// <param name="SacadorCEPSufixo"></param>
        /// <param name="SacadorCidade"></param>
        /// <param name="SacadorUF"></param>
        /// <param name="CNAB"></param>
        /// <returns></returns>
        public static string RegistroSegmentoY1(int ControleBanco,
                                                int ControleLote,
                                                int ControleRegistro,
                                                int ServNumRegistro,
                                                string ServSegmento,
                                                string ServCNAB,
                                                int ServCodMov,
                                                int CodRegOpcional,
                                                int SacadorInsTipo,
                                                int SacadorInsNumero,
                                                string SacadorNome,
                                                string SacadorEndereco,
                                                string SacadorBairro,
                                                int SacadorCEP,
                                                int SacadorCEPSufixo,
                                                string SacadorCidade,
                                                string SacadorUF,
                                                string CNAB
                                                )
        {
            string SegmentoY1 = "";

            SegmentoY1 += Util.PreencheCampoInt(ControleBanco, 3);
            SegmentoY1 += Util.PreencheCampoInt(ControleLote, 4);
            SegmentoY1 += Util.PreencheCampoInt(ControleRegistro, 1);
            SegmentoY1 += Util.PreencheCampoInt(ServNumRegistro, 5);
            SegmentoY1 += Util.PreencheCampoString(ServSegmento, 1);
            SegmentoY1 += Util.PreencheCampoString(ServCNAB, 1);
            SegmentoY1 += Util.PreencheCampoInt(ServCodMov, 2);
            SegmentoY1 += Util.PreencheCampoInt(CodRegOpcional, 2);
            SegmentoY1 += Util.PreencheCampoInt(SacadorInsTipo, 1);
            SegmentoY1 += Util.PreencheCampoInt(SacadorInsNumero, 15);
            SegmentoY1 += Util.PreencheCampoString(SacadorNome, 40);
            SegmentoY1 += Util.PreencheCampoString(SacadorEndereco, 40);
            SegmentoY1 += Util.PreencheCampoString(SacadorBairro, 15);
            SegmentoY1 += Util.PreencheCampoInt(SacadorCEP, 5);
            SegmentoY1 += Util.PreencheCampoInt(SacadorCEPSufixo, 3);
            SegmentoY1 += Util.PreencheCampoString(SacadorCidade, 15);
            SegmentoY1 += Util.PreencheCampoString(SacadorUF, 2);
            SegmentoY1 += Util.PreencheCampoString(CNAB, 85);

            return SegmentoY1;
        }

        /// <summary>
        /// REGISTRO DETALHE - SEGMENTO Y-50 (OPCIONAL - REMESSA/RETORNO)
        /// REGISTRO OPCIONAL PARA INFORMAÇÃO DE RATEIO DE CRÉDITO
        /// </summary>
        /// <param name="ControleBanco">Código do Banco na Compensação</param>
        /// <param name="ControleLote">Lote de Serviço</param>
        /// <param name="ControleRegistro">Tipo de Registro</param>
        /// <param name="ServNumRegistro">Nº Sequencial do Registro no Lote</param>
        /// <param name="ServSegmento">Cód. Segmento do Registro Detalhe</param>
        /// <param name="ServCNAB">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <param name="ServCodMov">Código de Movimento Remessa</param>
        /// <param name="CodRegOpcional">Identificação Registro Opcional</param>
        /// <param name="CcAgenciaCod">Agência Mantenedora da Conta</param>
        /// <param name="CcAgenciaDV">Dígito Verificador da Agência</param>
        /// <param name="CcContaNumero">Número da Conta Corrente</param>
        /// <param name="CcContaDV">Dígito Verificador da Conta</param>
        /// <param name="CcDV">Dígito Verificador da Ag/Conta</param>
        /// <param name="IdentificacaoTitulo">Identificação do Produto</param>
        /// <param name="Zeros">Zeros</param>
        /// <param name="NossoNumero">Nosso Número</param>
        /// <param name="DigitoNossoNumero">Dígito do Nosso Número</param>
        /// <param name="CodCalcRateioBeneficiario">1. Valor Cobrado - 2. Valor Registro - 3. Rateio p/ Menor Valor</param>
        /// <param name="TipoValorInform">1. % (Percentual) - 2. Valor ou Quantidade</param>
        /// <param name="ValorQuantidadePercentual">Valor ou Quantidade - % (Percentual)</param>
        /// <param name="CodigoBanco">Código Banco p/ Cred. Benef.</param>
        /// <param name="CcAgenciaCodBenef">Código Agência p/ Cred. Benef.</param>
        /// <param name="CcAgenciaDVBenef">Dígito Agência p/ Cred. Benef</param>
        /// <param name="CcContaNumeroBenef">C/C p/ Cred. Beneficiário</param>
        /// <param name="CcContaDVBenef">Dígito C/C p/ Créd. Beneficiário</param>
        /// <param name="CcDVBenef">Dígito Ag/Conta Beneficiário</param>
        /// <param name="NomeBeneficiario">Nome do Beneficiário</param>
        /// <param name="Parcela">Ident. Parcela do Rateio</param>
        /// <param name="Floating">Qtde. Dias p/ Créd. Beneficiário</param>
        /// <param name="DataCredito">Data Crédito Beneficiário</param>
        /// <param name="MotivoOcorrido">Identificação das Rejeições</param>
        /// <param name="CNAB">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <returns></returns>
        public static string RegistroSegmentoY50(int ControleBanco,
                                                int ControleLote,
                                                int ControleRegistro,
                                                int ServNumRegistro,
                                                string ServSegmento,
                                                string ServCNAB,
                                                int ServCodMov,
                                                int CodRegOpcional,
                                                int CcAgenciaCod,
                                                string CcAgenciaDV,
                                                int CcContaNumero,
                                                string CcContaDV,
                                                string CcDV,
                                                string IdentificacaoTitulo,
                                                int Zeros,//Não tem Tipo Verificar
                                                int NossoNumero,//Não tem Tipo Verificar
                                                int DigitoNossoNumero,//Não tem Tipo Verificar
                                                int CodCalcRateioBeneficiario,
                                                int TipoValorInform,
                                                decimal ValorQuantidadePercentual, //Confirmar
                                                int CodigoBanco,
                                                int CcAgenciaCodBenef,
                                                string CcAgenciaDVBenef,
                                                int CcContaNumeroBenef,
                                                string CcContaDVBenef,
                                                string CcDVBenef,
                                                string NomeBeneficiario,
                                                string Parcela,
                                                int Floating,
                                                DateTime DataCredito,
                                                int MotivoOcorrido,
                                                string CNAB
                                                )
        {
            string SegmentoY50 = "";

            SegmentoY50 += Util.PreencheCampoInt(ControleBanco, 3);
            SegmentoY50 += Util.PreencheCampoInt(ControleLote, 4);
            SegmentoY50 += Util.PreencheCampoInt(ControleRegistro, 1);
            SegmentoY50 += Util.PreencheCampoInt(ServNumRegistro, 5);
            SegmentoY50 += Util.PreencheCampoString(ServSegmento, 1);
            SegmentoY50 += Util.PreencheCampoString(ServCNAB, 1);
            SegmentoY50 += Util.PreencheCampoInt(ServCodMov, 2);
            SegmentoY50 += Util.PreencheCampoInt(CodRegOpcional, 2);
            SegmentoY50 += Util.PreencheCampoInt(CcAgenciaCod, 5);
            SegmentoY50 += Util.PreencheCampoString(CcAgenciaDV, 1);
            SegmentoY50 += Util.PreencheCampoInt(CcContaNumero, 12);
            SegmentoY50 += Util.PreencheCampoString(CcContaDV, 1);
            SegmentoY50 += Util.PreencheCampoString(CcDV, 1);
            SegmentoY50 += Util.PreencheCampoString(IdentificacaoTitulo, 3);
            SegmentoY50 += Util.PreencheCampoInt(Zeros, 5);//Não tem Tipo Verificar
            SegmentoY50 += Util.PreencheCampoInt(NossoNumero, 11);//Não tem Tipo Verificar
            SegmentoY50 += Util.PreencheCampoInt(DigitoNossoNumero, 1);//Não tem Tipo Verificar
            SegmentoY50 += Util.PreencheCampoInt(CodCalcRateioBeneficiario, 1);
            SegmentoY50 += Util.PreencheCampoInt(TipoValorInform, 1);
            SegmentoY50 += Util.PreencheCampoDecimal(ValorQuantidadePercentual, 12); //Confirmar
            SegmentoY50 += Util.PreencheCampoInt(CodigoBanco, 3);
            SegmentoY50 += Util.PreencheCampoInt(CcAgenciaCodBenef, 5);
            SegmentoY50 += Util.PreencheCampoString(CcAgenciaDVBenef, 1);
            SegmentoY50 += Util.PreencheCampoInt(CcContaNumeroBenef, 12);
            SegmentoY50 += Util.PreencheCampoString(CcContaDVBenef, 1);
            SegmentoY50 += Util.PreencheCampoString(CcDVBenef, 1);
            SegmentoY50 += Util.PreencheCampoString(NomeBeneficiario, 40);
            SegmentoY50 += Util.PreencheCampoString(Parcela, 6);
            SegmentoY50 += Util.PreencheCampoInt(Floating, 3);
            SegmentoY50 += Util.PreencheCampoData(DataCredito, 8);
            SegmentoY50 += Util.PreencheCampoInt(MotivoOcorrido, 10);
            SegmentoY50 += Util.PreencheCampoString(CNAB, 74);

            return SegmentoY50;
        }

        /// <summary>
        /// Registro Detalhe - Segmento T (Obrigatório - Retorno)
        /// </summary>
        /// <param name="ControleBanco">Código do Banco na Compensação</param>
        /// <param name="ControleLote">Lote de Serviço</param>
        /// <param name="ControleRegistro">Tipo de Registro</param>
        /// <param name="ServNumRegistro">Número Sequencial Registro no Lote</param>
        /// <param name="ServSegmento">Código Segmento do Registro Detalhe</param>
        /// <param name="ServCNAB">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <param name="ServCodMov">Código de Movimento Retorno</param>
        /// <param name="CcAgenciaCod">Agência Mantenedora da Conta</param>
        /// <param name="CcAgenciaDV">Dígito Verificador da Agência</param>
        /// <param name="CcContaNumero">Número da Conta Corrente</param>
        /// <param name="CcContaDV">Dígito Verificador da Conta</param>
        /// <param name="CcDV">Dígito Verificador da Ag/Conta</param>
        /// <param name="NossoNumero">Identificação do Título</param>
        /// <param name="Carteira">Código da Carteira</param>
        /// <param name="NumeroDocumento">Número do Documento de Cobrança</param>
        /// <param name="Vencimento">Data do Vencimento do Título</param>
        /// <param name="ValorTitulo">Valor Nominal do Título</param>
        /// <param name="BancoCobrReceb">Número do Banco</param>
        /// <param name="AgCobrReceb">Agência Cobradora/Recebedora</param>
        /// <param name="DV">Dígito Verificador da Agência</param>
        /// <param name="UsoEmpresa">Identificação do Título na Empresa</param>
        /// <param name="CodigoMoeda">Código da Moeda</param>
        /// <param name="PagadorInsTipo">Tipo de Inscrição</param>
        /// <param name="PagadorInsNumero">Número de Inscrição</param>
        /// <param name="PagadorNome">Nome</param>
        /// <param name="NumeroContrato">Nº do Contr. da Operação de Crédito</param>
        /// <param name="ValorTarCustas">Valor da Tarifa / Custas</param>
        /// <param name="MotivoOcorrencia">Identificação para Rejeições, Tarifas, Custas, Liquidação e Baixas</param>
        /// <param name="CNAB">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <returns></returns>
        public static string RegistroSegmentoT(int ControleBanco,
                                                int ControleLote,
                                                int ControleRegistro,
                                                int ServNumRegistro,
                                                string ServSegmento,
                                                string ServCNAB,
                                                int ServCodMov,
                                                int CcAgenciaCod,
                                                string CcAgenciaDV,
                                                int CcContaNumero,
                                                string CcContaDV,
                                                string CcDV,
                                                string NossoNumero,
                                                int Carteira,
                                                string NumeroDocumento,
                                                DateTime Vencimento,
                                                decimal ValorTitulo,
                                                int BancoCobrReceb,
                                                int AgCobrReceb,
                                                int DV,
                                                string UsoEmpresa,
                                                int CodigoMoeda,
                                                int PagadorInsTipo,
                                                int PagadorInsNumero,
                                                string PagadorNome,
                                                int NumeroContrato,
                                                decimal ValorTarCustas,
                                                string MotivoOcorrencia,
                                                string CNAB
                                                )
        {
            string SegmentoT = "";

            SegmentoT += Util.PreencheCampoInt(ControleBanco, 3);
            SegmentoT += Util.PreencheCampoInt(ControleLote, 4);
            SegmentoT += Util.PreencheCampoInt(ControleRegistro, 1);
            SegmentoT += Util.PreencheCampoInt(ServNumRegistro, 5);
            SegmentoT += Util.PreencheCampoString(ServSegmento, 1);
            SegmentoT += Util.PreencheCampoString(ServCNAB, 1);
            SegmentoT += Util.PreencheCampoInt(ServCodMov, 2);
            SegmentoT += Util.PreencheCampoInt(CcAgenciaCod, 5);
            SegmentoT += Util.PreencheCampoString(CcAgenciaDV, 1);
            SegmentoT += Util.PreencheCampoInt(CcContaNumero, 12);
            SegmentoT += Util.PreencheCampoString(CcContaDV, 1);
            SegmentoT += Util.PreencheCampoString(CcDV, 1);
            SegmentoT += Util.PreencheCampoString(NossoNumero, 20);
            SegmentoT += Util.PreencheCampoInt(Carteira, 1);
            SegmentoT += Util.PreencheCampoString(NumeroDocumento, 15);
            SegmentoT += Util.PreencheCampoData(Vencimento, 8);
            SegmentoT += Util.PreencheCampoDecimal(ValorTitulo, 13);
            SegmentoT += Util.PreencheCampoInt(BancoCobrReceb, 3);
            SegmentoT += Util.PreencheCampoInt(AgCobrReceb, 5);
            SegmentoT += Util.PreencheCampoInt(DV, 1);
            SegmentoT += Util.PreencheCampoString(UsoEmpresa, 25);
            SegmentoT += Util.PreencheCampoInt(CodigoMoeda, 2);
            SegmentoT += Util.PreencheCampoInt(PagadorInsTipo, 1);
            SegmentoT += Util.PreencheCampoInt(PagadorInsNumero, 15);
            SegmentoT += Util.PreencheCampoString(PagadorNome, 40);
            SegmentoT += Util.PreencheCampoInt(NumeroContrato, 10);
            SegmentoT += Util.PreencheCampoDecimal(ValorTarCustas, 13);
            SegmentoT += Util.PreencheCampoString(MotivoOcorrencia, 13);
            SegmentoT += Util.PreencheCampoString(CNAB, 17);

            return SegmentoT;
        }

        /// <summary>
        /// REGISTRO DETALHE - SEGMENTO U (OBRIGATÓRIO - RETORNO)
        /// </summary>
        /// <param name="ControleBanco">Código do Banco na Compensação</param>
        /// <param name="ControleLote">Lote de Serviço</param>
        /// <param name="ControleRegistro">Tipo de Registro</param>
        /// <param name="ServNumRegistro">Nº Sequencial do Registro no Lote</param>
        /// <param name="ServSegmento">Cód. Segmento do Registro Detalhe</param>
        /// <param name="ServCNAB">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <param name="ServCodMov">Código de Movimento Retor</param>
        /// <param name="DadTitAcrescimos">Juros / Multa / Encargos</param>
        /// <param name="DadTitVlrDesconto">Valor do Desconto Concedido</param>
        /// <param name="DadTitVlrAbatimento">Valor do Abat. Concedido/Cancel</param>
        /// <param name="DadTitVlrIOF">Valor do IOF Recolhido</param>
        /// <param name="DadTitVlrPago">Valor Pago pelo Pagador</param>
        /// <param name="DadTitVlrLiquido">Valor Líquido a ser Creditado</param>
        /// <param name="OtrasDespensas">Valor de Outras Despesas</param>
        /// <param name="OtrosCreditos">Valor de Outros Créditos</param>
        /// <param name="DataOcorrencia">Data da Ocorrência</param>
        /// <param name="DataCredito">Data da Efetivação do Crédito</param>
        /// <param name="OcorrPagCodigo">Código da Ocorrência</param>
        /// <param name="OcorrPagDataOcorrencia">Data da Ocorrência</param>
        /// <param name="OcorrPagValorOcorrencia">Valor da Ocorrência</param>
        /// <param name="OcorrPagComplOcorrencia">Complem. da Ocorrência</param>
        /// <param name="CodBcoCorr">Cód. Banco Correspondente Comp</param>
        /// <param name="NossoNumBcoCorr">Nosso Nº Banco Correspondente</param>
        /// <param name="CNAB">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <returns></returns>
        public static string RegistroSegmentoU(int ControleBanco,
                                                int ControleLote,
                                                int ControleRegistro,
                                                int ServNumRegistro,
                                                string ServSegmento,
                                                string ServCNAB,
                                                int ServCodMov,
                                                decimal DadTitAcrescimos,
                                                decimal DadTitVlrDesconto,
                                                decimal DadTitVlrAbatimento,
                                                decimal DadTitVlrIOF,
                                                decimal DadTitVlrPago,
                                                decimal DadTitVlrLiquido,
                                                decimal OtrasDespensas,
                                                decimal OtrosCreditos,
                                                DateTime DataOcorrencia,
                                                DateTime DataCredito,
                                                string OcorrPagCodigo,
                                                DateTime OcorrPagDataOcorrencia,
                                                decimal OcorrPagValorOcorrencia,
                                                string OcorrPagComplOcorrencia,
                                                int CodBcoCorr,
                                                int NossoNumBcoCorr,
                                                string CNAB
                                                )
        {
            string SegmentoU = "";

            SegmentoU += Util.PreencheCampoInt(ControleBanco, 3);
            SegmentoU += Util.PreencheCampoInt(ControleLote, 4);
            SegmentoU += Util.PreencheCampoInt(ControleRegistro, 1);
            SegmentoU += Util.PreencheCampoInt(ServNumRegistro, 5);
            SegmentoU += Util.PreencheCampoString(ServSegmento, 1);
            SegmentoU += Util.PreencheCampoString(ServCNAB, 1);
            SegmentoU += Util.PreencheCampoInt(ServCodMov, 2);
            SegmentoU += Util.PreencheCampoDecimal(DadTitAcrescimos, 13);
            SegmentoU += Util.PreencheCampoDecimal(DadTitVlrDesconto, 13);
            SegmentoU += Util.PreencheCampoDecimal(DadTitVlrAbatimento, 13);
            SegmentoU += Util.PreencheCampoDecimal(DadTitVlrIOF, 13);
            SegmentoU += Util.PreencheCampoDecimal(DadTitVlrPago, 13);
            SegmentoU += Util.PreencheCampoDecimal(DadTitVlrLiquido, 13);
            SegmentoU += Util.PreencheCampoDecimal(OtrasDespensas, 13);
            SegmentoU += Util.PreencheCampoDecimal(OtrosCreditos, 13);
            SegmentoU += Util.PreencheCampoData(DataOcorrencia, 8);
            SegmentoU += Util.PreencheCampoData(DataCredito, 8);
            SegmentoU += Util.PreencheCampoString(OcorrPagCodigo, 4);
            SegmentoU += Util.PreencheCampoData(OcorrPagDataOcorrencia, 8);
            SegmentoU += Util.PreencheCampoDecimal(OcorrPagValorOcorrencia, 13);
            SegmentoU += Util.PreencheCampoString(OcorrPagComplOcorrencia, 30);
            SegmentoU += Util.PreencheCampoInt(CodBcoCorr, 3);
            SegmentoU += Util.PreencheCampoInt(NossoNumBcoCorr, 20);
            SegmentoU += Util.PreencheCampoString(CNAB, 7);

            return SegmentoU;
        }
        /// <summary>
        /// REGISTRO TRAILER DE LOTE
        /// </summary>
        /// <param name="ControleBanco">Código do Banco na Compensação</param>
        /// <param name="ControleLote">Lote de Serviço</param>
        /// <param name="ControleRegistro">Tipo de Registro</param>
        /// <param name="CNAB_1">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <param name="QtdeRegistros">Quantidade de Registros no Lote</param>
        /// <param name="TotCobrSimplesQtde">Quantidade de Títulos em Cobrança</param>
        /// <param name="TotCobrSimplesValor">Valor Total dosTítulos em Carteiras</param>
        /// <param name="TotCobrVinculadaQtde">Quantidade de Títulos em Cobrança</param>
        /// <param name="TotCobrVinculadaValor">Valor Total dosTítulos em Carteiras</param>
        /// <param name="TotCobrCaucionadaQtdeCobranca">Quantidade de Títulos em Cobrança</param>
        /// <param name="TotCobrCaucionadaQtdeCarteira">Quantidade de Títulos em Carteiras</param>
        /// <param name="TotCobrDescontadaQtde">Quantidade de Títulos em Cobrança</param>
        /// <param name="TotCobrDescontadaValor">Valor Total dosTítulos em Carteiras</param>
        /// <param name="NumeroAviso">Número do Aviso de Lançamento</param>
        /// <param name="CNAB_2">Uso Exclusivo FEBRABAN/CNAB</param>
        /// <returns></returns>
        public static string RegistroTrailerLote(int ControleBanco,
                                                int ControleLote,
                                                int ControleRegistro,
                                                string CNAB_1,
                                                int QtdeRegistros,
                                                int TotCobrSimplesQtde,
                                                decimal TotCobrSimplesValor,
                                                int TotCobrVinculadaQtde,
                                                decimal TotCobrVinculadaValor,
                                                int TotCobrCaucionadaQtdeCobranca,
                                                decimal TotCobrCaucionadaQtdeCarteira,
                                                int TotCobrDescontadaQtde,
                                                decimal TotCobrDescontadaValor,
                                                string NumeroAviso,
                                                string CNAB_2
                                                )
        {
            string TrailerLote = "";

            TrailerLote += Util.PreencheCampoInt(ControleBanco, 3);
            TrailerLote += Util.PreencheCampoInt(ControleLote, 4);
            TrailerLote += Util.PreencheCampoInt(ControleRegistro, 1);
            TrailerLote += Util.PreencheCampoString(CNAB_1, 9);
            TrailerLote += Util.PreencheCampoInt(QtdeRegistros, 6);
            TrailerLote += Util.PreencheCampoInt(TotCobrSimplesQtde, 6);
            TrailerLote += Util.PreencheCampoDecimal(TotCobrSimplesValor, 15);
            TrailerLote += Util.PreencheCampoInt(TotCobrVinculadaQtde, 6);
            TrailerLote += Util.PreencheCampoDecimal(TotCobrVinculadaValor, 15);
            TrailerLote += Util.PreencheCampoInt(TotCobrCaucionadaQtdeCobranca, 6);
            TrailerLote += Util.PreencheCampoDecimal(TotCobrCaucionadaQtdeCarteira, 15);
            TrailerLote += Util.PreencheCampoInt(TotCobrDescontadaQtde, 6);
            TrailerLote += Util.PreencheCampoDecimal(TotCobrDescontadaValor, 15);
            TrailerLote += Util.PreencheCampoString(NumeroAviso, 8);
            TrailerLote += Util.PreencheCampoString(CNAB_2, 117);

            return TrailerLote;
        }
    }
}