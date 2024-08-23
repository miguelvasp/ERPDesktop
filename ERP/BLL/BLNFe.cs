using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFe_Util_2G;
using ERP.Models;
using ERP.DAL;
using ERP.Util;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.IO;
using System.Xml.Linq;
using ERP.ModelView;
using GenCode128;
using System.Drawing;

namespace ERP.BLL
{
    public class BLNFe : IDisposable
    {
        #region Variveis
        DB_ERPContext db = new DB_ERPContext();
        private string versao = "3.10";
        private string NomeCertificado = "";
        private Empresa empresa = new EmpresaDAL().ERepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
        NFe_Util_2G.Util objUtil = new NFe_Util_2G.Util();
        NotaFiscal NF;
        public NotaFiscalDAL nfDal;
        public string MsgErro = "";
        public string strChaveNotaFiscal = "";
        double TotalPIS = 0;
        double TotalCOFINS = 0;
        List<vwDanfe> Danfe;
        Configuracao confEmpresa = new ConfiguracaoDAL().GetByEmpresa(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));


        #endregion


        #region VariaveisDanfe
        private int IdNotaFiscal;
        private int ide_cUF;
        private string ide_natOp;
        private int ide_indPag;
        private int ide_mode;
        private int ide_serie;
        private int ide_nNF;
        private DateTime ide_dEmi;
        private DateTime ide_dSaiEnt;
        private int ide_tpNF;
        private int ide_cMunFG;
        private int ide_tpImp;
        private int ide_finNFe;
        private int ide_tpEmis;
        private int ide_procEmi;
        private string ide_verProc;
        private string ide_NFref;
        private string ide_CondPagDesc;
        private string TP_PESSOA;
        private string dest_CNPJ;
        private string dest_CPF = "";
        private string dest_xNome;
        private string dest_xFant;
        private string dest_xlgr;
        private string dest_nro;
        private string dest_xCpl;
        private string dest_xBairro;
        private int dest_cMun;
        private string dest_xMun;
        private string dest_UF;
        private string dest_CEP;
        private string dest_cPais;
        private string dest_xPais;
        private string dest_fone;
        private string dest_IE;
        private string dest_IESUF;
        private string dest_email;
        private int indIEDest;
        private int INF_ITEM;
        private string Prod_cProd;
        private string Prod_cEAN;
        private string Prod_xProd;
        private string Prod_NCM;
        private string Prod_ExTIPI;
        private string Prod_genero;
        private string Prod_CFOP;
        private string Prod_uCOM;
        private decimal Prod_qCom;
        private decimal Prod_vUnCom;
        private decimal Prod_vProd;
        private string Prod_cEANTrib;
        private string Prod_uTrib;
        private decimal Prod_qTrib;
        private decimal Prod_vUnTrib;
        private decimal Prod_vFrete;
        private int Prod_vSeguro;
        private decimal prod_Vdesc;
        private string Prod_DI;
        private string Prod_DetEspecifico;
        private string Prod_infAdProd;
        private string icms_orig;
        private string icms_CST;
        private int icms_modBC;
        private int icms_pRedBC;
        private decimal icms_vBC;
        private decimal icms_pICMS;
        private decimal icms_vICMS;
        private int icms_modBCST;
        private int icms_pmVAST;
        private int icms_pRedBCST;
        private decimal icms_BCST;
        private decimal icms_vICMSST;
        private decimal icms_pICMSST;
        private string ipi_clEnq;
        private string ipi_CNPJProd;
        private string ipi_cSelo;
        private int ipi_qSelo;
        private string ipi_cEnq;
        private string ipi_CST;
        private decimal ipi_vBC;
        private decimal ipi_pIPI;
        private decimal ipi_vIPI;
        private int ipi_qUnid;
        private int ipi_vUnid;
        private string pis_CST;
        private int pis_vBC;
        private decimal pis_pPIS;
        private int pis_vPIS;
        private int pis_qBCProd;
        private int pis_vAliqProd;
        private string cofins_CST;
        private int cofins_vBC;
        private decimal cofins_pCOFINS;
        private int cofins_vCOFINS;
        private int cofins_qBCProd;
        private int cofins_vAliqProd;
        private decimal tot_vBC;
        private decimal tot_vICMS;
        private decimal tot_vBCST;
        private decimal tot_vST;
        private decimal tot_vProd;
        private decimal tot_vFrete;
        private decimal tot_vSeg;
        private decimal tot_vDesc;
        private int tot_vII;
        private decimal tot_vIPI;
        private decimal tot_vPIS;
        private decimal tot_vCOFINS;
        private decimal tot_vOutro;
        private decimal tot_vNF;
        private int CodigoNF;
        private int tra_modFrete;
        private string tra_transportadora;
        private string tra_retTransp;
        private string tra_veicTransp;
        private string tra_reboque;
        private string tra_vol;
        private string tra_CNPJ;
        private string tra_CPF;
        private string tra_xNome;
        private string tra_IE;
        private string tra_xEnder;
        private string tra_xMun;
        private string tra_UF;
        private string veic_Placa;
        private string veic_UF;
        private string veic_RNTC;
        private decimal vol_qVol;
        private string vol_esp;
        private string vol_Marca;
        private string vol_nVol;
        private decimal vol_pesoL;
        private decimal vol_pesoB;
        private string vol_lacres;
        private string nroRecibo;
        private string Protocolo;
        private string ChaveAut;
        private int Ambiente;
        private string emi_CNPJ;
        private string emi_xNome;
        private string emi_xFant;
        private string emi_xLgr;
        private string emi_IE;
        private string emi_nro;
        private string emi_xCpl;
        private string emi_xBairro;
        private int emi_cMun;
        private string emi_xMun;
        private string emi_UF;
        private string emi_CEP;
        private string emi_cPais;
        private string emi_xPais;
        private string emi_Fone;
        private string emi_IEST;
        private string emi_IM;
        private string emi_CNAE;
        private byte[] Logo;
        private string emi_CRT;
        private string infAdic;
        #endregion





        #region Construtor
        public BLNFe()
        {
        }


        public BLNFe(string pNomeCertificado, NotaFiscal pNotaFiscal, NotaFiscalDAL pnfDal)
        {
            NomeCertificado = pNomeCertificado;
            NF = pNotaFiscal;
            nfDal = pnfDal;
            BLNotaFiscal bl = new BLNotaFiscal();
            bl.dal = nfDal;
            bl.iDal = new NotaFiscalItemDAL();
            NF = bl.CalculaNota(NF.IdNotaFiscal);
            nfDal.Update(NF);
            nfDal.Save();
        }
        #endregion

        #region Utilitarios

        public string SalvarXML(string XMLPath)
        {
            try
            {
                NotaFiscalNFeDAL nfeDal = new NotaFiscalNFeDAL();
                NotaFiscalNFe nfe = nfeDal.GetNFeById(NF.IdNotaFiscal);

                if (NF.DataAutorizacao == null)
                {
                    nfe = null;
                }

                string XML = "";
                if (nfe == null)
                {
                    XML = GeraXML();
                }
                else
                {
                    XML = nfe.NFeXML;
                }
                //Adiciona o numero da chave 
                XMLPath += $"\\{NF.ChaveNFe}-nfe.xml";

                if (File.Exists(XMLPath))
                {
                    File.Delete(XMLPath);
                }


                using (StreamWriter outfile = new StreamWriter(XMLPath, true))
                {
                    outfile.Write(XML);
                    outfile.Close();
                    return $"NFe {NF.Numero} salvo em {XMLPath}";
                }
            }
            catch (Exception ex)
            {
                return $"NFe {NF.Numero} Não pode ser salva. {MsgErro} - {ex.Message}";
            }
        }

        public bool ValidarXML(out string msgResultado)
        {
            bool arquivoOk = true;
            string XML = GeraXML();
            string msg = "";
            int qtdeErros = 0;
            int CodResult = objUtil.ValidaXML(XML, 68, out msgResultado, out qtdeErros, out msg);
            msgResultado = msg;
            if (CodResult != 5501)
            {
                arquivoOk = false;
                msgResultado = "Nota Fiscal Válida!";
            }
            return arquivoOk;
        }

        public string TransmitirNFe()
        {
            string siglaWS = confEmpresa.NFeSiglaWS;
            string NFe = GeraXML();
            string msgDados = "";
            string msgRetWS = "";
            int cStat = 0;
            string msgResultado = "";
            string nroRecibo = "";
            string dhRecbto = "";
            string tMed = "";
            string proxy = "";
            string usuario = "";
            string senha = "";
            string licenca = confEmpresa.NFeLicenca;

            //Consulta a Nota Fiscal
            if (!string.IsNullOrEmpty(NF.NFeRecibo))
            {
                string consultaRetorno = this.ConsultarProcessamento();
                if (!string.IsNullOrEmpty(NF.Protocolo))
                    return consultaRetorno;
            }

            //Envia a Nota Fiscal para a SEFAZ
            string NFeAssinada = objUtil.EnviaNFe2G(siglaWS, ref NFe, NomeCertificado, "4.00", out msgDados, out msgRetWS, out cStat, out msgResultado, out nroRecibo, out dhRecbto, out tMed, proxy, usuario, senha, licenca);

            NotaFiscalNFeDAL nfeDal = new NotaFiscalNFeDAL();
            NotaFiscalNFe nfe = nfeDal.GetNFeById(NF.IdNotaFiscal);
            if (nfe == null)
            {
                nfe = new NotaFiscalNFe();
                nfe.IdNotaFiscal = NF.IdNotaFiscal;
                nfe.NFeXML = NFeAssinada;
                nfeDal.Insert(nfe);
            }
            else
            {
                nfe.NFeXML = NFeAssinada;
                nfeDal.Update(nfe);
            }

            nfeDal.Save();

            NF.NFeRecibo = nroRecibo;
            NF.NFeResultado = msgResultado;
            nfDal.Update(NF);
            nfDal.Save();

            System.Threading.Thread.Sleep(500);

            string consultaRetorno2 = this.ConsultarProcessamento();
            if (!string.IsNullOrEmpty(NF.Protocolo))
                return consultaRetorno2;

            return msgResultado;
        }

        public string ConsultarProcessamento()
        {
            if (!string.IsNullOrEmpty(NF.Protocolo))
            {
                return "Autorizado o uso da NF-e";
            }



            try
            {
                NotaFiscalNFeDAL nfeDal = new NotaFiscalNFeDAL();
                NotaFiscalNFe nfe = nfeDal.GetNFeById(NF.IdNotaFiscal);

                if (nfe == null)
                {
                    MsgErro += "Erro Consulta Processamento: XML Assinado não encontrado. \n";
                    return MsgErro;
                }

                string siglaWS = confEmpresa.NFeSiglaWS;
                int tipoAmbiente = (int)confEmpresa.AmbienteNFe;
                string NFeAssinada = nfe.NFeXML;
                string nroRecibo = NF.NFeRecibo;
                string msgDados = "";
                int cStat = 0;
                string msgResultado = "";
                string nroProtocolo = "";
                string cMsg = "";
                string xMsg = "";
                string msgRetWS = "";
                string licenca = confEmpresa.NFeLicenca;
                string dhProtocolo = "";

                string XMLNFeProc = objUtil.BuscaNFe2G(siglaWS, tipoAmbiente, ref NFeAssinada, nroRecibo, NomeCertificado, "4.00", out msgDados, out msgRetWS, out cStat, out msgResultado, out nroProtocolo, out dhProtocolo, out cMsg, out xMsg, "", "", "", licenca);



                if (cStat == 100) //nota autorizada
                {
                    //atualiza o xml da nota
                    nfe.NFeXML = XMLNFeProc;
                    nfeDal.Update(nfe);
                    nfeDal.Save();
                    //atualiza os dados da autorizaçao da nota
                    NF.Protocolo = nroProtocolo;
                    NF.DataAutorizacao = DateTime.Now;// DataAutorizacao(XMLNFeProc);
                    NF.NFeResultado = msgResultado;
                    nfDal.Update(NF);
                    nfDal.Save();
                }
                else
                {
                    NF.NFeResultado = msgResultado;
                    nfDal.Update(NF);
                    nfDal.Save();
                }
                return msgResultado;
            }
            catch (Exception ex)
            {
                return "Erro Consulta do processamento: " + ex.Message;
            }
        }

        public void CancelaNotaFiscal(string Justificativa)
        {
            string siglaWS = confEmpresa.NFeSiglaWS;
            int tipoAmbiente = (int)confEmpresa.AmbienteNFe;
            string msgDados = "";
            string msgRetWS = "";
            int cStat = 0;
            string msgResultado = "";
            string chaveNFe = NF.ChaveNFe;
            string nProtocolo = NF.Protocolo;
            string dhEvento = DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss");
            string nProtocoloCanc = "";
            string dProtocoloCanc = "";
            string proxy = "";
            string usuario = "";
            string senha = "";
            string licenca = confEmpresa.NFeLicenca;

            string CancelaNFe = objUtil.CancelaNFEvento(siglaWS, tipoAmbiente, NomeCertificado, versao, out msgDados, out msgRetWS, out cStat, out msgResultado, chaveNFe, nProtocolo, Justificativa, dhEvento, out nProtocoloCanc, out dProtocoloCanc, proxy, usuario, senha, licenca);

            if (cStat == 135 || cStat == 155)
            {
                NF.NFeProtocoloCancelamento = nProtocoloCanc;
                NF.DataCancelamento = DateTime.Now;
                NF.JustificativaCancelamento = Justificativa;
                nfDal.Update(NF);
                nfDal.Save();
            }
            else
            {
                MsgErro += $"Erro: Cancelamento de nota fiscal { msgResultado }";
            }
        }

        public string GetXMLAutorizado()
        {
            string XML = "";
            NotaFiscalNFe nfe = new NotaFiscalNFeDAL().GetByID(NF.IdNotaFiscal);
            if (nfe != null)
            {
                XML = nfe.NFeXML;
            }
            return XML;
        }

        public List<vwDanfe> GetDanfeData(bool SalvaTemporario = false)
        {
            //Chama todos os metodos para gerar o XML para preencher as variaveis
            string xml = File.ReadAllText("C:\\TEMP\\37198.xml"); //GeraXML(); //GetXMLAutorizado();
            List<vwDanfe> lista = MontaCamposDanfe(xml);

            if (lista.Count > 0)
            {
                if (SalvaTemporario)
                {
                    string FilePath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ERP MGA\\Temp\\" + lista[0].ChaveAut + ".xml";
                    System.IO.File.WriteAllText(FilePath, xml);
                    strChaveNotaFiscal = lista[0].ChaveAut;
                }
            }

            return lista;
        }

        public List<string> GetNotaFiscalEmails()
        {
            var lista = (from n in db.NotaFiscal
                         join c in db.Cliente on n.IdDestinatario equals c.IdCliente
                         join cc in db.ClienteContato on c.IdCliente equals cc.IdCliente
                         join co in db.Contato on cc.IdContato equals co.IdContato
                         where n.IdNotaFiscal == NF.IdNotaFiscal
                         & co.EMail != ""
                         select co.EMail).ToList();
            return lista;

        }


        public List<vwDanfe> MontaCamposDanfe(string xml)
        {
            List<vwDanfe> Lista = new List<vwDanfe>();
            XNamespace ns = "http://www.portalfiscal.inf.br/nfe";
            XDocument arquivo = XDocument.Load(xml);

            /* Elementos Principais */
            var nfeProc = arquivo.Element(ns + "nfeProc");
            var NFe = nfeProc.Element(ns + "NFe");
            var protNFe = nfeProc.Element(ns + "protNFe");
            var infProt = protNFe.Element(ns + "infProt");
            var infNFe = NFe.Element(ns + "infNFe");
            var versao = infNFe.Attribute("versao").Value;
            var ide = infNFe.Element(ns + "ide");
            var emit = infNFe.Element(ns + "emit");
            var enderEmit = emit.Element(ns + "enderEmit");
            var dest = infNFe.Element(ns + "dest");
            var enderDest = dest.Element(ns + "enderDest");
            var total = infNFe.Element(ns + "total");
            var ICMSTot = total.Element(ns + "ICMSTot");
            var transp = infNFe.Element(ns + "transp");
            var transporta = transp.Element(ns + "transporta");
            var vol = transp.Element(ns + "vol");
            var dets = infNFe.Elements(ns + "det");
            int Contador = 0;


            //Monta a listagem comforme a quantidade de itens que tem na nota fiscal
            foreach (var det in dets)
            {
                Contador++;
                var item = det.Element(ns + "prod");
                var imposto = det.Element(ns + "imposto");
                var icms = imposto.Elements(ns + "ICMS");
                var ipi = imposto.Element(ns + "IPI");

                var pis = imposto.Element(ns + "PIS");
                var pisNT = pis.Element(ns + "PISNT");
                var cofins = imposto.Element(ns + "COFINS");
                var cofinsNT = cofins.Element(ns + "COFINSNT");

                vwDanfe nota = new vwDanfe();
                nota.ide_nNF = Convert.ToInt32(ide.Element(ns + "nNF").Value);
                nota.ide_serie = Convert.ToInt32(ide.Element(ns + "serie").Value);
                nota.ide_tpNF = Convert.ToInt32(ide.Element(ns + "tpNF").Value);
                nota.ChaveAut = infProt.Element(ns + "chNFe").Value;
                nota.Protocolo = infProt.Element(ns + "nProt").Value;
                nota.dtRecebimento = Convert.ToDateTime(infProt.Element(ns + "dhRecbto").Value).ToString();



                if (versao == "3.10")
                {
                    nota.ide_dEmi = Convert.ToDateTime(ide.Element(ns + "dhEmi").Value);
                    //if (Util.Util.ExisteElemento(emit, ns, "CNPJ")) nota.ide_dSaiEnt = Convert.ToDateTime(ide.Element(ns + "dhSaiEnt").Value);

                    var infAdic = infNFe.Element(ns + "infAdic");
                    if (infAdic != null)
                    {
                        if (Util.Util.ExisteElemento(infAdic, ns, "infCpl")) nota.infAdic = infAdic.Element(ns + "infCpl").Value;
                    }
                }
                else if (versao == "2.00")
                {
                    nota.ide_dEmi = Convert.ToDateTime(ide.Element(ns + "dEmi").Value);
                }

                if (emit != null)
                {
                    if (Util.Util.ExisteElemento(emit, ns, "CNPJ")) nota.emi_CNPJ = emit.Element(ns + "CNPJ").Value;
                    if (Util.Util.ExisteElemento(emit, ns, "xNome")) nota.emi_xNome = emit.Element(ns + "xNome").Value;
                    if (Util.Util.ExisteElemento(emit, ns, "xFant")) nota.emi_xFant = emit.Element(ns + "xFant").Value;
                    if (Util.Util.ExisteElemento(enderEmit, ns, "xLgr")) nota.emi_xLgr = enderEmit.Element(ns + "xLgr").Value;
                    if (Util.Util.ExisteElemento(enderEmit, ns, "nro")) nota.emi_nro = enderEmit.Element(ns + "nro").Value;
                    if (Util.Util.ExisteElemento(enderEmit, ns, "xBairro")) nota.emi_xBairro = enderEmit.Element(ns + "xBairro").Value;
                    if (Util.Util.ExisteElemento(enderEmit, ns, "cMun")) nota.emi_cMun = Convert.ToInt32(enderEmit.Element(ns + "cMun").Value);
                    if (Util.Util.ExisteElemento(enderEmit, ns, "xMun")) nota.emi_xMun = enderEmit.Element(ns + "xMun").Value;
                    if (Util.Util.ExisteElemento(enderEmit, ns, "UF")) nota.emi_UF = enderEmit.Element(ns + "UF").Value;
                    if (Util.Util.ExisteElemento(enderEmit, ns, "CEP")) nota.emi_CEP = Util.Util.FormatString(enderEmit.Element(ns + "CEP").Value, Util.Util.TypeString.CEP);
                    if (Util.Util.ExisteElemento(enderEmit, ns, "fone")) Util.Util.FormatString(nota.emi_Fone = enderEmit.Element(ns + "fone").Value, Util.Util.TypeString.Telephone);
                    if (Util.Util.ExisteElemento(emit, ns, "IE")) nota.emi_IE = emit.Element(ns + "IE").Value;
                    if (Util.Util.ExisteElemento(emit, ns, "CRT")) nota.emi_CRT = emit.Element(ns + "CRT").Value;
                }

                if (dest != null)
                {
                    if (Util.Util.ExisteElemento(dest, ns, "CNPJ"))
                    {
                        nota.dest_CNPJ = dest.Element(ns + "CNPJ").Value;
                    }
                    else
                    {
                        nota.dest_CNPJ = dest.Element(ns + "CPF").Value;
                    }
                    if (Util.Util.ExisteElemento(dest, ns, "xNome")) nota.dest_xNome = dest.Element(ns + "xNome").Value;
                    if (Util.Util.ExisteElemento(enderDest, ns, "xLgr")) nota.dest_xlgr = enderDest.Element(ns + "xLgr").Value;
                    if (Util.Util.ExisteElemento(enderDest, ns, "nro")) nota.dest_nro = enderDest.Element(ns + "nro").Value;
                    if (Util.Util.ExisteElemento(enderDest, ns, "xCpl")) nota.dest_xCpl = enderDest.Element(ns + "xCpl").Value;
                    if (Util.Util.ExisteElemento(enderDest, ns, "cMun")) nota.dest_cMun = Convert.ToInt32(enderDest.Element(ns + "cMun").Value);
                    if (Util.Util.ExisteElemento(enderDest, ns, "xMun")) nota.dest_xMun = enderDest.Element(ns + "xMun").Value;
                    if (Util.Util.ExisteElemento(enderDest, ns, "UF")) nota.dest_UF = enderDest.Element(ns + "UF").Value;
                    if (Util.Util.ExisteElemento(enderDest, ns, "fone")) Util.Util.FormatString(nota.dest_fone = enderDest.Element(ns + "fone").Value, Util.Util.TypeString.Telephone);
                    if (Util.Util.ExisteElemento(enderDest, ns, "CEP")) nota.dest_CEP = Util.Util.FormatString(enderDest.Element(ns + "CEP").Value, Util.Util.TypeString.CEP);
                    if (Util.Util.ExisteElemento(dest, ns, "IE")) nota.dest_IE = dest.Element(ns + "IE").Value;
                    if (Util.Util.ExisteElemento(dest, ns, "email")) nota.dest_email = dest.Element(ns + "email").Value;
                }

                if (total != null)
                {
                    if (Util.Util.ExisteElemento(ICMSTot, ns, "vBC")) nota.tot_vBC = Convert.ToDecimal(ICMSTot.Element(ns + "vBC").Value.Replace(".", ","));
                    if (Util.Util.ExisteElemento(ICMSTot, ns, "vICMS")) nota.tot_vICMS = Convert.ToDecimal(ICMSTot.Element(ns + "vICMS").Value.Replace(".", ","));
                    if (Util.Util.ExisteElemento(ICMSTot, ns, "vBCST")) nota.tot_vBCST = Convert.ToDecimal(ICMSTot.Element(ns + "vBCST").Value.Replace(".", ","));
                    if (Util.Util.ExisteElemento(ICMSTot, ns, "vST")) nota.tot_vST = Convert.ToDecimal(ICMSTot.Element(ns + "vST").Value.Replace(".", ","));
                    if (Util.Util.ExisteElemento(ICMSTot, ns, "vProd")) nota.tot_vProd = Convert.ToDecimal(ICMSTot.Element(ns + "vProd").Value.Replace(".", ","));
                    if (Util.Util.ExisteElemento(ICMSTot, ns, "vFrete")) nota.tot_vFrete = Convert.ToDecimal(ICMSTot.Element(ns + "vFrete").Value.Replace(".", ","));
                    if (Util.Util.ExisteElemento(ICMSTot, ns, "vSeg")) nota.tot_vSeg = Convert.ToDecimal(ICMSTot.Element(ns + "vSeg").Value.Replace(".", ","));
                    if (Util.Util.ExisteElemento(ICMSTot, ns, "vDesc")) nota.tot_vDesc = Convert.ToDecimal(ICMSTot.Element(ns + "vDesc").Value.Replace(".", ","));
                    if (Util.Util.ExisteElemento(ICMSTot, ns, "vII")) nota.tot_vII = Convert.ToDecimal(ICMSTot.Element(ns + "vII").Value.Replace(".", ","));
                    if (Util.Util.ExisteElemento(ICMSTot, ns, "vIPI")) nota.tot_vIPI = Convert.ToDecimal(ICMSTot.Element(ns + "vIPI").Value.Replace(".", ","));
                    if (Util.Util.ExisteElemento(ICMSTot, ns, "vPIS")) nota.tot_vPIS = Convert.ToDecimal(ICMSTot.Element(ns + "vPIS").Value.Replace(".", ","));
                    if (Util.Util.ExisteElemento(ICMSTot, ns, "vCOFINS")) nota.tot_vCOFINS = Convert.ToDecimal(ICMSTot.Element(ns + "vCOFINS").Value.Replace(".", ","));
                    if (Util.Util.ExisteElemento(ICMSTot, ns, "vOutro")) nota.tot_vOutro = Convert.ToDecimal(ICMSTot.Element(ns + "vOutro").Value.Replace(".", ","));
                    if (Util.Util.ExisteElemento(ICMSTot, ns, "vNF")) nota.tot_vNF = Convert.ToDecimal(ICMSTot.Element(ns + "vNF").Value.Replace(".", ","));
                }

                if (transp != null)
                {
                    if (Util.Util.ExisteElemento(transp, ns, "modFrete")) nota.tra_modFrete = Convert.ToInt32(transp.Element(ns + "modFrete").Value);
                    if (Util.Util.ExisteElemento(transporta, ns, "CNPJ")) nota.tra_CNPJ = transporta.Element(ns + "CNPJ").Value;
                    if (Util.Util.ExisteElemento(transporta, ns, "xNome")) nota.tra_xNome = transporta.Element(ns + "xNome").Value;
                    if (Util.Util.ExisteElemento(transporta, ns, "IE")) nota.tra_IE = transporta.Element(ns + "IE").Value;
                    if (Util.Util.ExisteElemento(transporta, ns, "xEnder")) nota.tra_xEnder = transporta.Element(ns + "xEnder").Value;
                    if (Util.Util.ExisteElemento(transporta, ns, "xMun")) nota.tra_xMun = transporta.Element(ns + "xMun").Value;
                    if (Util.Util.ExisteElemento(transporta, ns, "UF")) nota.tra_UF = transporta.Element(ns + "UF").Value;
                    if (Util.Util.ExisteElemento(vol, ns, "qVol")) nota.tra_vol = vol.Element(ns + "qVol").Value;
                    if (Util.Util.ExisteElemento(vol, ns, "esp")) nota.vol_esp = vol.Element(ns + "esp").Value;
                    if (Util.Util.ExisteElemento(vol, ns, "pesoB")) nota.vol_pesoB = Convert.ToDecimal(vol.Element(ns + "pesoB").Value.Replace(".", ","));
                    if (Util.Util.ExisteElemento(vol, ns, "pesoL")) nota.vol_pesoL = Convert.ToDecimal(vol.Element(ns + "pesoL").Value.Replace(".", ","));
                }


                if (Util.Util.ExisteElemento(item, ns, "cProd")) nota.Prod_cProd = item.Element(ns + "cProd").Value.TrimStart('0');
                if (Util.Util.ExisteElemento(item, ns, "cEAN")) nota.Prod_cEAN = item.Element(ns + "cEAN").Value;
                if (Util.Util.ExisteElemento(item, ns, "xProd")) nota.Prod_xProd = item.Element(ns + "xProd").Value;
                if (Util.Util.ExisteElemento(item, ns, "NCM")) nota.Prod_NCM = item.Element(ns + "NCM").Value;
                if (Util.Util.ExisteElemento(item, ns, "CFOP")) nota.Prod_CFOP = item.Element(ns + "CFOP").Value;
                if (Util.Util.ExisteElemento(item, ns, "CEST")) nota.Prod_CEST = item.Element(ns + "CEST").Value;
                nota.Conversao = 1;
                nota.INF_ITEM = Contador;

                if (Util.Util.ExisteElemento(item, ns, "uCom")) nota.Prod_uCOM = item.Element(ns + "uCom").Value;
                if (Util.Util.ExisteElemento(item, ns, "qCom")) nota.Prod_qCom = Convert.ToDecimal(item.Element(ns + "qCom").Value.Replace(".", ","));
                if (Util.Util.ExisteElemento(item, ns, "vUnCom")) nota.Prod_vUnCom = Convert.ToDecimal(item.Element(ns + "vUnCom").Value.Replace(".", ","));
                if (Util.Util.ExisteElemento(item, ns, "vProd")) nota.Prod_vProd = Convert.ToDecimal(item.Element(ns + "vProd").Value.Replace(".", ","));

                foreach (var itemICMS in icms)
                {
                    XElement xicms = null;
                    var icms00 = itemICMS.Element(ns + "ICMS00");
                    var icms10 = itemICMS.Element(ns + "ICMS10");
                    var icms20 = itemICMS.Element(ns + "ICMS20");
                    var icms30 = itemICMS.Element(ns + "ICMS30");
                    var icms40 = itemICMS.Element(ns + "ICMS40");
                    var icms50 = itemICMS.Element(ns + "ICMS50");
                    var icms51 = itemICMS.Element(ns + "ICMS51");
                    var icms60 = itemICMS.Element(ns + "ICMS60");
                    var icms70 = itemICMS.Element(ns + "ICMS70");
                    var icms90 = itemICMS.Element(ns + "ICMS90");

                    if (icms00 != null) xicms = icms00;
                    if (icms10 != null) xicms = icms10;
                    if (icms20 != null) xicms = icms20;
                    if (icms30 != null) xicms = icms30;
                    if (icms40 != null) xicms = icms40;
                    if (icms50 != null) xicms = icms50;
                    if (icms51 != null) xicms = icms51;
                    if (icms60 != null) xicms = icms60;
                    if (icms70 != null) xicms = icms70;
                    if (icms90 != null) xicms = icms90;

                    if (xicms != null)
                    {
                        if (Util.Util.ExisteElemento(xicms, ns, "orig")) nota.icms_orig = xicms.Element(ns + "orig").Value;
                        if (Util.Util.ExisteElemento(xicms, ns, "CST")) nota.icms_CST = xicms.Element(ns + "CST").Value;
                        if (Util.Util.ExisteElemento(xicms, ns, "vBC")) nota.icms_vBC = Convert.ToDecimal(xicms.Element(ns + "vBC").Value.Replace(".", ","));
                        if (Util.Util.ExisteElemento(xicms, ns, "pICMS")) nota.icms_pICMS = Convert.ToDecimal(xicms.Element(ns + "pICMS").Value.Replace(".", ","));
                        if (Util.Util.ExisteElemento(xicms, ns, "vICMS")) nota.icms_vICMS = Convert.ToDecimal(xicms.Element(ns + "vICMS").Value.Replace(".", ","));

                        break;
                    }
                }

                if (ipi != null)
                {
                    var IPITrib = ipi.Element(ns + "IPITrib");
                    if (Util.Util.ExisteElemento(ipi, ns, "cEnq")) nota.ipi_cEnq = ipi.Element(ns + "cEnq").Value;
                    // if (Util.Util.ExisteElemento(ipint, ns, "CST")) nota.ipi_CST = ipint.Element(ns + "CST").Value;
                    if (IPITrib != null)
                    {
                        if (Util.Util.ExisteElemento(IPITrib, ns, "vIPI")) nota.ipi_vIPI = Convert.ToDecimal(IPITrib.Element(ns + "vIPI").Value.Replace(".", ","));
                        if (Util.Util.ExisteElemento(IPITrib, ns, "pIPI")) nota.ipi_pIPI = Convert.ToDecimal(IPITrib.Element(ns + "pIPI").Value.Replace(".", ","));
                    }
                }
                if (nota.ipi_vIPI == null) nota.ipi_vIPI = 0;
                if (nota.icms_vICMS == null) nota.icms_vICMS = 0;
                Lista.Add(nota);
            }
            return Lista;
        }

        public string GeraDanfe()
        {
            NotaFiscalNFeDAL nfeDal = new NotaFiscalNFeDAL();
            NotaFiscalNFe nfe = nfeDal.GetNFeById(NF.IdNotaFiscal);
            //Busca o xml
            string XML = nfe.NFeXML;

            //Monta as pastas
            string Folder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string ChaveAut = NF.ChaveNFe;
            string FileName = Folder + "\\Temp\\NFe" + ChaveAut + ".pdf";


            if (!Directory.Exists(Folder + "\\Temp"))
            {
                Directory.CreateDirectory(Folder + "\\Temp");
            }

            if (!File.Exists(FileName))
            {
                string msg = "";
                //Gera o pdf
                CreateDanfe(XML, FileName, out msg);
                //MessageBox.Show(msg);
                System.Threading.Thread.Sleep(500);
                return FileName;
            }
            else
            {
                return FileName;
            }
        }


        private void CreateDanfe(string XML, string FilePath, out string msg)
        {
            string Message = "";
            try
            {

                NFe_Util_2G.Util objUtil = new NFe_Util_2G.Util();
                string DirectoryName = System.IO.Path.GetDirectoryName(FilePath);
                string FileName = System.IO.Path.GetFileName(FilePath);

                if (!FileName.ToLower().Contains(".pdf"))
                {
                    FileName += ".pdf";
                }
                objUtil.geraPdfDANFE(XML, "", "S", "N", "N", "", "L", "[ARQUIVO=" + FileName + "][PASTA=" + DirectoryName + "]", out Message);

                msg = Message;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

        }



        #endregion

        #region GeraXML

        private string GeraChaveNFe()
        {
            string cs_codigoseguranca = "MGASOLUCOES";
            string msgResultado = "";
            string cNF = "";
            string cDV = "";
            string Chave = "";
            var emp = new EmpresaDAL().getByIdEmpresa(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
            var cidade = new CidadeDAL().GetByID((int)emp.IdCidade);
            string CNPJEmitente = emp.CNPJ.Replace(".", "").Replace("/", "").Replace("-", "");
            int resultado = objUtil.CriaChaveNFe2G(cidade.IBGE.ToString().Substring(0, 2), NF.DataEmissao.Year.ToString().Substring(2, 2), NF.DataEmissao.Month.ToString(), CNPJEmitente, NF.NFeModelo.ToString(), NF.Serie, NF.Numero, NF.NFetpEmiss.ToString(), cs_codigoseguranca, out msgResultado, out cNF, out cDV, out Chave);

            //codigo 5601 chave ok
            if (resultado == 5601)
            {
                NF.ChaveNFe = Chave;
                NF.NFecDV = Convert.ToInt32(cDV);
                NF.NFecNF = Convert.ToInt32(cNF);
                nfDal.Update(NF);
                nfDal.Save();
            }
            else
            {
                MsgErro += $"Erro ChaveNFe: { msgResultado } \n";
            }
            return Chave;

        }

        private string Identificador()
        {
            TotalPIS = 0;
            TotalCOFINS = 0;
            try
            {
                string InfXML = "";
                Cidade cidade = new CidadeDAL().GetByID((int)empresa.IdCidade);
                UnidadeFederacao uf = new UnidadeFederacaoDAL(new DB_ERPContext()).GetByID(cidade.IdUF);
                //CFOP cfop = new CFOPDAL().GetByID((int)NF.IdCFOP);
                string NFReferenciadas = "";
                string idDest = uf.UF == NF.UF ? "1" : "2";
                if (NF.UF.ToUpper() == "EX") idDest = "3";
                ide_cUF = uf.IBGE;
                ide_natOp = Util.Util.MudaLetra(NF.NomeOperacao);
                ide_indPag = (int)NF.NFeIndPag;
                ide_mode = (int)NF.NFeModelo;
                ide_serie = Convert.ToInt32(NF.Serie);
                ide_nNF = Convert.ToInt32(NF.Numero);
                ide_dEmi = NF.DataEmissao;
                ide_tpNF = (int)NF.NFetpNF;
                ide_cMunFG = cidade.IBGE;
                ide_tpImp = 1;
                ide_finNFe = (int)NF.FinalidadeEmissao;
                ide_tpEmis = (int)NF.NFetpEmiss;

                if (!string.IsNullOrEmpty(NF.NFeReferencia))
                {
                    NFReferenciadas = objUtil.NFeRef(NF.NFeReferencia);
                }

                InfXML = objUtil.identificador400(ide_cUF,
                                                 (int)NF.NFecNF,
                                                 ide_natOp,
                                                 ide_mode,
                                                 ide_serie,
                                                 ide_nNF,
                                                 ide_dEmi.ToString("yyyy-MM-ddT00:00:00-03:00"),
                                                 "",
                                                 ide_tpNF,
                                                 Convert.ToInt32(idDest),
                                                 ide_cMunFG.ToString(),
                                                 NFReferenciadas,
                                                 ide_tpImp,
                                                 ide_tpEmis,
                                                 (int)NF.NFecDV,
                                                 (int)confEmpresa.AmbienteNFe,
                                                 ide_finNFe,
                                                 1,
                                                 (int)NF.NFeIndPres,
                                                 0,
                                                 "000",
                                                 "",
                                                 "");
                return InfXML;
            }
            catch (Exception ex)
            {
                MsgErro += $"Erro Identificador { ex.Message } \n";
                return "";
            }
        }

        private string Emitente()
        {
            string EmitXML = "";
            Cidade cidade = new CidadeDAL().GetByID((int)empresa.IdCidade);
            UnidadeFederacao uf = new UnidadeFederacaoDAL(new DB_ERPContext()).GetByID(cidade.IdUF);
            emi_CNPJ = empresa.CNPJ;
            emi_xNome = Util.Util.MudaLetra(empresa.RazaoSocial);
            emi_xFant = Util.Util.MudaLetra(empresa.Fantasia);
            emi_xLgr = Util.Util.MudaLetra(empresa.Endereco);
            emi_IE = Util.Util.MudaLetra(empresa.IE);
            emi_nro = empresa.Numero;
            emi_xCpl = Util.Util.MudaLetra(empresa.Complemento);
            emi_xBairro = Util.Util.MudaLetra(empresa.Bairro);
            emi_cMun = cidade.IBGE;
            emi_xMun = Util.Util.MudaLetra(cidade.Nome);
            emi_UF = uf.UF;
            emi_CEP = empresa.CEP.Replace("-", "");
            emi_cPais = "1058";
            emi_xPais = "BRASIL";
            emi_Fone = Util.Util.MudaLetra(empresa.Telefone);
            emi_IEST = "";
            emi_IM = "";
            emi_CNAE = "";
            Logo = empresa.Logo;
            emi_CRT = empresa.CRT.ToString();
            try
            {

                EmitXML = objUtil.emitente2G(emi_CNPJ,
                                             "",
                                             emi_xNome,
                                             emi_xFant,
                                             emi_xLgr,
                                             emi_nro,
                                             emi_xCpl,
                                             emi_xBairro,
                                             emi_cMun.ToString(),
                                             emi_xMun,
                                             emi_UF,
                                             emi_CEP,
                                             emi_cPais,
                                             emi_xPais,
                                             emi_Fone,
                                             emi_IE,
                                             "",
                                             "",
                                             "",
                                             emi_CRT);
                return EmitXML;
            }
            catch (Exception ex)
            {
                MsgErro += $"Erro Emitente { ex.Message } \n";
                return "";
            }
        }

        private string responsavelTecnico()
        {
            emi_CNPJ = empresa.CNPJ;
            string respXml = "";
            respXml = objUtil.infRespTec(emi_CNPJ,
                                         "Miguel Armando Villacorta Parra",
                                         "miguelv.asp@gmail.com",
                                         "11984347551",
                                         "",
                                         "",
                                         "");

            return respXml;
        }

        private string Destinatario()
        {

            if (NF.IdDocumento == 6) //pedido de vendas o destinatário é o clietne
            {
                ClienteDAL clDal = new ClienteDAL();
                Cliente cl = clDal.CRepository.GetByID(NF.IdDestinatario);
                Cidade cid = new CidadeDAL().GetByID((int)cl.IdCidade);
                UnidadeFederacao uf = new UnidadeFederacaoDAL(new DB_ERPContext()).GetByID(cid.IdUF);
                Pais pais = new PaisDAL().GetByID(cid.IdPais);
                TP_PESSOA = cl.Tipo.ToString();
                if (TP_PESSOA == "1") { dest_CPF = NF.CNPJ; } else { dest_CNPJ = NF.CNPJ; }
                if (confEmpresa.AmbienteNFe == 1)
                {
                    dest_xNome = Util.Util.MudaLetra(cl.RazaoSocial);
                }
                else
                {
                    dest_xNome = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
                }
                dest_xFant = Util.Util.MudaLetra(NF.RazaoSocial);
                dest_xlgr = Util.Util.MudaLetra(NF.Endereco);
                dest_nro = NF.EnderecoNumero;
                dest_xCpl = Util.Util.MudaLetra(NF.Complemento == null ? "" : NF.Complemento);
                dest_xBairro = Util.Util.MudaLetra(NF.Bairro);
                dest_cMun = cid.IBGE;
                dest_xMun = Util.Util.MudaLetra(cid.Nome);
                dest_UF = uf.UF;
                dest_CEP = NF.CEP.Replace("-", "");
                dest_cPais = pais.CodigoIBGE;
                dest_xPais = Util.Util.MudaLetra(pais.NomePais);
                dest_fone = clDal.GetTelefoneNFe(cl.IdCliente);
                dest_IE = Util.Util.MudaLetra(NF.IE == null ? "" : NF.IE);
                dest_IESUF = "";
                dest_email = cl.Email;
                string IE = NF.IE == null ? "" : NF.IE;
                if (TP_PESSOA == "2" && !string.IsNullOrEmpty(IE))
                {
                    indIEDest = 1;
                }
                else if (TP_PESSOA == "2" && (IE.ToUpper() == "ISENTO" || string.IsNullOrEmpty(IE)))
                {
                    indIEDest = 2;
                }
                else if (TP_PESSOA == "1")
                {
                    indIEDest = 9;
                    dest_IE = "";
                }

                if (indIEDest == 0)
                {
                    indIEDest = 9;
                    dest_IE = "";
                }

            }



            try
            {
                string DestXML = "";
                DestXML = objUtil.destinatario310(dest_CNPJ,
                                                  dest_CPF,
                                                  "",
                                                  dest_xNome,
                                                  dest_xlgr,
                                                  dest_nro,
                                                  dest_xCpl,
                                                  dest_xBairro,
                                                  dest_cMun.ToString(),
                                                  dest_xMun,
                                                  dest_UF,
                                                  dest_CEP,
                                                  dest_cPais,
                                                  dest_xPais,
                                                  dest_fone,
                                                  indIEDest.ToString(),
                                                  dest_IE,
                                                  dest_IESUF,
                                                  "",
                                                  dest_email);
                return DestXML;
            }
            catch (Exception ex)
            {
                MsgErro += $"Erro Destinatário { ex.Message } \n";
                return "";
            }
        }

        private string Detalhe()
        {
            int Contador = 0;
            try
            {
                string teste = "";
                string DetalheXML = "";
                List<NotaFiscalItem> itens = new NotaFiscalItemDAL().GetByNF(NF.IdNotaFiscal);

                //Monta a listagem dos itens para a Danfe
                Danfe = new List<vwDanfe>();


                foreach (NotaFiscalItem i in itens)
                {
                    string cProd = Util.Util.MudaLetra(i.Codigo);
                    string cEAN = "SEM GTIN";
                    string xProd = Util.Util.MudaLetra(i.Descricao);
                    string NCM = new ClassificacaoFiscalDAL().GetByID((int)i.IdNCM).NCM.Replace(".", "");
                    string NVE_Opc = "";
                    string EXTIPI = "";
                    int CFOP = Convert.ToInt32(new CFOPDAL().GetByID((int)i.IdCFOP).CFOPCOD.Replace(".", ""));
                    string uCom = new UnidadeDAL().GetByID((int)i.IdUnidade).UnidadeMedida;
                    double qCom = (double)i.Quantidade;
                    double vUnCom = (double)i.ValorUnitario;
                    double vProd = Convert.ToDouble(i.Quantidade * i.ValorUnitario);
                    string cEANTrib = "SEM GTIN";
                    string uTrib = uCom;
                    double qTrib = qCom;
                    double vUnTrib = vUnCom;
                    double vFrete = (double)i.Frete;
                    double vSeg = (double)i.Seguro;
                    double vDesc = Convert.ToDouble(i.Desconto == null ? 0 : i.Desconto);
                    double vOutro = 0;
                    int indTot = 1;
                    string DI = "";
                    string detExport_Opc = "";
                    string DetEspecifico = "";
                    string xPed = "";
                    string nItemPed = "";
                    string nFCI_Opc = "";
                    string Cest = i.IdCest == null ? "" : i.Cest.Cest.Replace(".", "");
                    string indEscala_Opc = "";
                    string CNPJFab_Opc = "";
                    string cBenef_Opc = "";
                    string rastro = "";


                    if (string.IsNullOrEmpty(NCM))
                    {
                        MsgErro += $"Informe o NCM para o produto {cProd} \r\n";
                    }

                    var icmsGrupo = this.GetICMSItem(i);

                    //verifica o grupo

                    string ProdutoXML = objUtil.produto400(cProd,
                                                           cEAN,
                                                           xProd,
                                                           NCM,
                                                           NVE_Opc,
                                                           Cest,
                                                           indEscala_Opc,
                                                           CNPJFab_Opc,
                                                           cBenef_Opc,
                                                           EXTIPI,
                                                           CFOP,
                                                           uCom,
                                                           qCom.ToString(),
                                                           vUnCom.ToString(),
                                                           vProd,
                                                           cEANTrib,
                                                           uTrib,
                                                           qTrib.ToString(),
                                                           vUnTrib.ToString(),
                                                           vFrete,
                                                           vSeg,
                                                           vDesc,
                                                           vOutro,
                                                           indTot,
                                                           DI,
                                                           detExport_Opc,
                                                           DetEspecifico,
                                                           xPed,
                                                           nItemPed,
                                                           nFCI_Opc,
                                                           rastro);



                    string IPIXML = "";

                    if (!String.IsNullOrEmpty(i.SituacaoTribIPI))
                    {
                        try
                        {
                            IPIXML = objUtil.IPI400("",
                                                    "",
                                                    0,
                                                    i.EnquadramentoIPI == null ? "999" : i.EnquadramentoIPI.ToString(),
                                                    i.SituacaoTribIPI,
                                                    0,
                                                    0,
                                                    0,
                                                    0,
                                                    0);
                        }
                        catch
                        {

                        }
                    }




                    string PISXML = "";

                    try
                    {
                        TotalPIS += (double)i.ValorPIS;
                        PISXML = objUtil.PIS(i.SituacaoTribPIS, (double)i.BasePIS, (double)i.AliquotaPIS, (double)i.ValorPIS, 0, 0);
                    }
                    catch
                    {
                    }


                    string COFINSXML = "";
                    try
                    {
                        TotalCOFINS += (double)i.ValorCOFINS;
                        COFINSXML = objUtil.COFINS(i.SituacaoTribCOFINS, (double)i.BaseCOFINS, (double)i.AliquotaCOFINS, (double)i.ValorCOFINS, 0, 0);
                    }
                    catch
                    {
                    }


                    Produto pr = new ProdutoDAL().ProdutoRepository.GetByID(i.IdProduto);
                    string ICMSXML = "";
                    try
                    {
                        if (pr.FiscalOrigem == null)
                        {
                            MsgErro += $"Produto {cProd} precisa a informações de origem da mercadoria, verifique o cadastro!\r\n";
                        }

                        ICMSXML = objUtil.icms400(pr.FiscalOrigem == null ? "0" : pr.FiscalOrigem.ToString(),
                                            icmsGrupo.CST,
                                            Convert.ToInt32(icmsGrupo.modBC),
                                            Convert.ToDouble(0),
                                            Convert.ToDouble(icmsGrupo.vBC),
                                            Convert.ToDouble(icmsGrupo.pICMS),
                                            Convert.ToDouble(icmsGrupo.vICMS),
                                            Convert.ToInt32(icmsGrupo.modBCST),
                                            Convert.ToDouble(icmsGrupo.pMVAST),
                                            Convert.ToDouble(0),
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0,
                                            0.00,
                                            "",
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00);

                    }
                    catch
                    {
                    }

                    double ValorTotalImpostos = (i.ValorICMS == null ? 0 : (double)i.ValorICMS) + (i.ValorCOFINS == null ? 0 : (double)i.ValorCOFINS) + (i.ValorIPI == null ? 0 : (double)i.ValorIPI) + (i.ValorPIS == null ? 0 : (double)i.ValorPIS);

                    string ImpostosXML = objUtil.imposto310(ValorTotalImpostos, ICMSXML, IPIXML, "", PISXML, "", COFINSXML, "", "");


                    //Adiciona o detalhe na Danfe
                    vwDanfe d = new vwDanfe();
                    d.Prod_cProd = cProd;
                    d.Prod_xProd = xProd;
                    d.Prod_NCM = NCM;
                    d.icms_CST = pr.FiscalOrigem.ToString() + i.SituacaoTribICMS;
                    d.Prod_CFOP = CFOP.ToString();
                    d.Prod_uCOM = uCom;
                    d.Prod_qCom = (decimal)qCom;
                    d.Prod_vUnCom = (decimal)vUnCom;
                    d.Prod_vProd = (decimal)vProd;
                    d.icms_vBC = 0;
                    d.icms_vICMS = 0;
                    d.ipi_vIPI = 0;
                    d.icms_pICMS = 0;
                    d.ipi_pIPI = 0;
                    Danfe.Add(d);


                    Contador++;
                    DetalheXML += objUtil.detalhe310(Contador, ProdutoXML, ImpostosXML, "", 0, 0);
                    teste = DetalheXML;
                }

                return DetalheXML;
            }
            catch (Exception ex)
            {
                MsgErro += $"Erro Detalhe { ex.Message } contador {Contador.ToString()} \n";
                return "";
            }

        }

        private GrupoICMSFlexDocs GetICMSItem(NotaFiscalItem i)
        {
            var listaImpostos = new NotaFiscalItemApuracaoImpostoDAL().GetImpostosByNFItem(i.IdNotaFiscalItem);
            var icms3 = listaImpostos.Where(x => x.TipoImposto == 3).FirstOrDefault();
            var icms11 = listaImpostos.Where(x => x.TipoImposto == 11).FirstOrDefault();
            GrupoICMSFlexDocs imp = new GrupoICMSFlexDocs();

            if (icms3 != null)
            {
                imp.CST = i.SituacaoTribICMS;
                imp.vBC = (double)icms3.BaseValor;
                imp.pICMS = (double)icms3.Aliquota;
                imp.vICMS = (double)icms3.ValorImposto;
                imp.modBC = 3;
            }
            else if (icms11 != null)
            {
                //procura o valor pMVAST nos valores d impostos campo markup
                var valores = new ValoresImpostoDAL().GetByCodigoImposto(Convert.ToInt32(icms11.IdCodigoImposto));
                var codigo = new CodigoImpostoDAL().GetByID(Convert.ToInt32(icms11.IdCodigoImposto));
                imp.CST = "10";
                imp.vBCST = (double)icms11.BaseValor;
                imp.pICMSST = (double)icms11.Aliquota;
                imp.vICMSST = (double)icms11.ValorImposto;
                imp.modBCST = Convert.ToInt32(codigo.MetodoSubstituicaoTributaria);
                imp.pMVAST = Convert.ToDouble(valores != null ? valores[0].Markup : 0);
            }
            else
            {
                //Simples Nacional Balcao
                if (i.SituacaoTribICMS == "101")
                {
                    imp.CST = "101";
                    imp.pCredSN = 1.25;
                    imp.vCredICMSSN = 12.96;
                    imp.modBC = 0;
                }
                else if (i.SituacaoTribICMS == "102")
                {
                    imp.CST = "102";
                }
                else if (i.SituacaoTribICMS == "500")
                {
                    imp.CST = "500";
                    imp.vBCSTRet = 0;
                    imp.vICMSSTRet = 0;
                }
            }



            return imp;
        }

        private string pag()
        {
            //SE FOR DEVOLUÇÃO O CAMPO VAI EM BRANCO
            if (NF.FinalidadeEmissao == 4)
            {
                string detPagDev = objUtil.detPag("", "90", Convert.ToDouble(0), "", "", "", "");
                return objUtil.pagamento400(detPagDev, 0);
            } 

            string detPag = objUtil.detPag("", "01", Convert.ToDouble(NF.TotalNF), "", "", "", "");
            return objUtil.pagamento400(detPag, 0);
        }

        private string Totais()
        {
            try
            {
                tot_vBC = (decimal)NF.BaseICMS;
                tot_vICMS = (decimal)NF.ValorICMS;
                tot_vBCST = (decimal)NF.BaseICMSSubs;
                tot_vST = (decimal)NF.ValorICMSSubs;
                tot_vProd = (decimal)NF.ValorMercadoria;
                tot_vFrete = (decimal)NF.ValorFrete;
                tot_vSeg = (decimal)NF.ValorSeguro;
                tot_vDesc = (decimal)NF.ValorDesconto;
                tot_vII = 0;
                tot_vIPI = (decimal)NF.ValorIPI;
                //tot_vPIS = (decimal)TotalPIS;
                //tot_vCOFINS = (decimal)TotalCOFINS;
                tot_vOutro = 0;
                tot_vNF = (decimal)NF.TotalNF;
                double tot_trib = (double)tot_vICMS + (double)tot_vIPI + TotalPIS + TotalCOFINS;
                string totalICMS = objUtil.totalICMS400((double)tot_vBC,
                                              (double)tot_vICMS,
                                              (double)tot_vBCST,
                                              (double)tot_vST,
                                              (double)tot_vProd,
                                              (double)tot_vFrete,
                                              (double)tot_vSeg,
                                              (double)tot_vDesc,
                                              tot_vII,
                                              (double)tot_vIPI,
                                              TotalPIS,
                                              TotalCOFINS,
                                              (double)tot_vOutro,
                                              (double)tot_vNF,
                                              tot_trib,
                                              0.00,
                                              0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00);
                return "<total>" + totalICMS + "</total>";
            }
            catch (Exception ex)
            {
                MsgErro += $"Erro Totais { ex.Message } \n";
                return "";
            }
        }

        private string Transportadora()
        {
            try
            {
                tra_modFrete = 0;// (int)NF.TipoFrete;
                tra_retTransp = "";
                tra_veicTransp = "";
                tra_reboque = "";
                tra_CNPJ = "";
                tra_CPF = "";
                tra_xNome = "";
                tra_IE = "";
                tra_xEnder = "";
                tra_xMun = "";
                tra_UF = "";
                veic_Placa = "";
                veic_UF = "";
                veic_RNTC = "";
                vol_qVol = 0;
                vol_esp = "";
                vol_Marca = "";
                vol_nVol = "";
                vol_pesoL = 0;
                vol_pesoB = 0;
                vol_lacres = "";



                string tra_transportadora = objUtil.transporta(Util.Util.MudaLetra(tra_CNPJ),
                                                                  Util.Util.MudaLetra(tra_CPF),
                                                                  Util.Util.MudaLetra(tra_xNome),
                                                                  Util.Util.MudaLetra(tra_IE),
                                                                  Util.Util.MudaLetra(tra_xEnder),
                                                                  Util.Util.MudaLetra(tra_xMun),
                                                                  tra_UF);


                string tra_vol = objUtil.vol((double)vol_qVol,
                                                Util.Util.MudaLetra(vol_esp),
                                                Util.Util.MudaLetra(vol_Marca),
                                                Util.Util.MudaLetra(vol_nVol),
                                                (double)vol_pesoL,
                                                (double)vol_pesoB,
                                                Util.Util.MudaLetra(vol_lacres));

                //se os volumes estao igual a zero nem colocar
                if ((double)vol_qVol == 0.00)
                {
                    tra_vol = "";
                }


                string Transportador = objUtil.transportador2G(tra_modFrete.ToString(),
                                                                tra_transportadora,
                                                                tra_retTransp,
                                                                tra_veicTransp,
                                                                tra_reboque,
                                                                "",
                                                                "",
                                                                tra_vol);

                return Transportador;
            }
            catch (Exception ex)
            {
                MsgErro += $"Erro Transportador { ex.Message } \n";
                return "";
            }

        }

        private string InfAdicional()
        {
            try
            {
                infAdic = "";
                var Obs = new NotaFiscalDAL().GetObsByNF(NF.IdNotaFiscal);
                foreach (NotaFiscalObs o in Obs)
                {
                    infAdic += o.Observacao + " \n";
                }
                return objUtil.infAdic("", infAdic, "", "", "");
            }
            catch (Exception ex)
            {
                MsgErro += $"Erro Transportador { ex.Message } \n";
                return "";
            }
        }

        private string GeraXML()
        {
            try
            {
                string NFeXML = "";
                if (String.IsNullOrEmpty(NF.ChaveNFe))
                {
                    GeraChaveNFe();
                }

                string sIdentificador = Identificador();
                string sEmitente = Emitente();
                string sDestinatario = Destinatario();
                string sLocalRetirada = "";// = LocalRetirada(); //Implementar
                string sLocalEntrega = "";//= LocalEntrega(); //Implementar
                string sDetalhe = Detalhe();
                string sTotais = Totais();
                string sTransportadora = Transportadora();
                string sInfAdicional = InfAdicional();
                string vencimentos = "";
                string sPagamento = pag();
                string exportar = "";
                string responsavel_tecnico = responsavelTecnico();
                NFeXML = objUtil.NFe201805("4.00",
                                            NF.ChaveNFe,
                                            sIdentificador,
                                            sEmitente,
                                            "",
                                            sDestinatario,
                                            sLocalRetirada,
                                            sLocalEntrega,
                                            sDetalhe,
                                            sTotais,
                                            sTransportadora,
                                            vencimentos,
                                            sPagamento,
                                            sInfAdicional,
                                            exportar,
                                            "",
                                            "",
                                            "",
                                            responsavel_tecnico);

                int CodReturn = 0;
                string msg = "";
                string resultado = "";
                NFeXML = objUtil.EliminaIdentacaoXML(NFeXML, out CodReturn, out msg);

                if (CodReturn != 7320)
                {
                    MsgErro += $"Erro Elimar Identação: {msg}";
                }

                //Assina o XML
                CodReturn = 0;
                msg = "";
                NFeXML = objUtil.Assinar(NFeXML, "infNFe", NomeCertificado, out CodReturn, out msg);

                if (CodReturn != 5300)
                {
                    MsgErro += $"Erro ao efetuar a assinatura do XML: {msg}";
                }

                return NFeXML;
            }
            catch (Exception ex)
            {
                throw new Exception(MsgErro);
            }

        }

        private string GeraXMLAssinada()
        {
            try
            {
                string NFeXML = GeraXML();

                //Assina o XML
                int CodReturn = 0;
                string msg = "";
                NFeXML = objUtil.Assinar(NFeXML, "infNFe", NomeCertificado, out CodReturn, out msg);

                if (CodReturn != 5300)
                {
                    MsgErro += $"Erro Assinatura: {msg}";
                }

                //Remove a identação do arquivo XML
                CodReturn = 0;
                msg = "";
                NFeXML = objUtil.EliminaIdentacaoXML(NFeXML, out CodReturn, out msg);

                if (CodReturn != 7320)
                {
                    MsgErro += $"Erro Elimar Identação: {msg}";
                }

                return NFeXML;
            }
            catch (Exception ex)
            {
                throw new Exception(MsgErro);
            }

        }

        #endregion

        #region Auxiliares
        private DateTime DataAutorizacao(string XML)
        {
            XNamespace ns = "http://www.portalfiscal.inf.br/nfe";
            TextReader tr = new StringReader(XML);
            XDocument arquivo = XDocument.Load(tr);
            var nfeProc = arquivo.Element(ns + "nfeProc");
            var protNFe = nfeProc.Element(ns + "protNFe");
            var infProt = protNFe.Element(ns + "infProt");
            string dhRecbto = infProt.Element(ns + "dhRecbto").Value;
            string ano = dhRecbto.Substring(0, 4);
            string mes = dhRecbto.Substring(5, 2);
            string dia = dhRecbto.Substring(8, 2);
            string hora = dhRecbto.Substring(11, 8);
            dhRecbto = dia + "/" + mes + "/" + ano + " " + hora;
            DateTime dhReceb = Convert.ToDateTime(dhRecbto);
            return dhReceb;
        }






        #endregion

        #region Dispose
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
        #endregion
    }
}
