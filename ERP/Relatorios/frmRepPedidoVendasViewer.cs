using ERP.DAL;
using ERP.Datasets;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using ERP.Models;

namespace ERP.Relatorios
{
    public partial class frmRepPedidoVendasViewer : Form
    {
        int IdPedidoVendas;
        bool SoFaturar;
        Configuracao confEmpresa = new ConfiguracaoDAL().GetByEmpresa(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
        public frmRepPedidoVendasViewer(int pPedidoVendas, bool pSoFaturar = false)
        {
            SoFaturar = pSoFaturar;
            this.IdPedidoVendas = pPedidoVendas;
            InitializeComponent();
        }

        private void frmRepPedidoVendasViewer_Load(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //ERP.Datasets.dsRepPedidoVendasTableAdapters.vwPedidoVendasRelTableAdapter ta = new Datasets.dsRepPedidoVendasTableAdapters.vwPedidoVendasRelTableAdapter();
            //ERP.Datasets.dsRepPedidoVendas ds = new dsRepPedidoVendas();
            try
            {
                //ta.FillBy(ds.vwPedidoVendasRel, IdPedidoVendas);
            }
            catch (Exception)
            {
            }
            finally
            {
                //dt = ds.vwPedidoVendasRel;

                var Dados = new PedidoVendaDAL().GetvwPedidoVendaImpressao(IdPedidoVendas, SoFaturar);

                if(SoFaturar)
                {
                    Dados = Dados.Where(x => x.QuantidadePorFaturar != null && x.QuantidadePorFaturar > 0).ToList();
                }

                PedidoVendaDAL objPed = new PedidoVendaDAL();
                var objtotal = objPed.getTotaisPedido(IdPedidoVendas, SoFaturar);
                string ImagePath = "file:///" + AppDomain.CurrentDomain.BaseDirectory + "logo.jpg";
                ReportParameter[] parameters = new ReportParameter[2];
                string Texto = "";
                if(!SoFaturar)
                {
                    if(Convert.ToBoolean(confEmpresa.VendasRelValorTotal))
                    {
                        if(!Convert.ToBoolean(confEmpresa.VendasRelDescontoVarejista))
                        {
                            Texto += "Valor total do pedido: R$" + objtotal.TotalValorReal.ToString("N2") + "\n\r";
                        }
                        else
                        {
                            Texto += "Valor total do pedido: R$" + (objtotal.TotalValorReal - objtotal.TotalDescontoVarejista).ToString("N2") + "\n\r";
                        }
                    }
                         

                    if (Convert.ToBoolean(confEmpresa.VendasRelDescontoVarejista))
                        Texto += "Valor total sem desconto varejista: R$" + objtotal.TotalValorReal.ToString("N2") + "\n\r";

                    if (Convert.ToBoolean(confEmpresa.VendasRelTotalProdutos))
                    {
                        if (!Convert.ToBoolean(confEmpresa.VendasRelDescontoVarejista))
                        {
                            Texto += "Valor total dos produtos: R$" + objtotal.TotalValorReal.ToString("N2") + "\n\r";
                        }
                        else
                        {
                            Texto += "Valor total dos produtos: R$" + (objtotal.TotalValorReal - objtotal.TotalDescontoVarejista).ToString("N2") + "\n\r";
                        }
                    }
                }
                else
                {
                    decimal Total = 0;
                    foreach(var a in Dados)
                    {
                        Total += (Convert.ToDecimal(a.PrecoUnitario) * Convert.ToDecimal(a.Quantidade));
                    }
                    if (Convert.ToBoolean(confEmpresa.VendasRelTotalProdutos))
                        Texto += "Total dos produtos: R$ " + objtotal.TotalValorReal.ToString("N2") + "\n\r";
                }

                
                decimal Peso = 0;
                foreach(var i in Dados)
                {
                    if(i.PesoUnitario != null)
                    {
                        Peso += ((decimal)i.PesoUnitario);
                    } 
                }

                if (Convert.ToBoolean(confEmpresa.VendasRelPeso))
                    Texto += "Peso: " + Peso.ToString("N2") + "\n\r";
                if(Dados.Count > 0)
                {
                    if (Convert.ToBoolean(confEmpresa.VendasRelVendedor))
                        if (!String.IsNullOrEmpty(Dados.First().Vendedor)) Texto += "Vendedor: " + Dados.First().Vendedor + "\n\r";

                    if (Convert.ToBoolean(confEmpresa.VendasRelTelevendas))
                        if (!String.IsNullOrEmpty(Dados.First().TeleVendas)) Texto += "Televendas: " + Dados.First().TeleVendas + "\n\r";
                    if (!String.IsNullOrEmpty(Dados.First().Observacao)) Texto += "Observações: " + Dados.First().Observacao;
                }
                parameters[0] = new ReportParameter("TotalSemDescontaVarejista", Texto);
                parameters[1] = new ReportParameter("ImagePath", ImagePath);
                
                ReportDataSource rds = new ReportDataSource("dsRepPedidoVendas", Dados);
                this.rpt.SetDisplayMode(DisplayMode.PrintLayout); 
                rpt.LocalReport.DataSources.Clear();
                rpt.LocalReport.DataSources.Add(rds);
                this.rpt.LocalReport.EnableExternalImages = true;
                this.rpt.LocalReport.SetParameters(parameters);
                this.rpt.LocalReport.Refresh();
                this.rpt.RefreshReport(); 
            }
        }
    }
}
