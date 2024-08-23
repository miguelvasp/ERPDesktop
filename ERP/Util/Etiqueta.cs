using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Util
{
    public class Etiqueta
    {
        public string CodigoBarras { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int Qtde { get; set; }
        string parte = "";

        public void ImprimirEtiquetas(List<Etiqueta> Etiquetas)
        {
            int contador = 0;
            StringBuilder texto = new StringBuilder("");
            foreach (var e in Etiquetas)
            {
                string a = Util.MudaLetra(e.Descricao.ToUpper()); 
                string b = "";
                string c = "";
                if (a.Length > 20)
                {
                    b = a.Substring(0, 20);
                    a = a.Remove(0, 20).Trim();
                    if (a.Length > 20)
                    {
                        c = a.Substring(0, 20);
                    }
                    else
                    {
                        c = a;
                    }
                }
                else
                {
                    b = a;
                }
                int i = 1;
                while(i < e.Qtde + 1)
                {
                    //Adiciona o header da etiqueta
                    contador++;
                    if (contador == 1)
                    {
                        parte = "header";
                        texto.Append("N\n");//  (limpa o buffer de impressão, para ser iniciado um novo arquivo BPLB)
                        texto.Append("D13\n");  //(configura a Densidade ou aquecimento da cabeça de impressão para o valor 9)
                        texto.Append("S1\n");  //(configura a Velocidade de impressão para 3 pol./seg)
                        texto.Append("JF\n");  //(habilita o “backfeed” para que ao final da impressão, o espaço entre etiquetas pare na serrilha)
                        texto.Append("ZT\n");  //(indica que a impressão deve inciar a partir do topo, ou seja, de cabeça para baixo)
                        texto.Append("A42,5,0,2,1,1,N," + '"' + e.Codigo + '"' + "\n");
                        texto.Append("A42,22,0,1,1,1,N," + '"' + b + '"' + "\n");
                        texto.Append("A42,38,0,1,1,1,N," + '"' + c + '"' + "\n");
                        
                        texto.Append("B42,54,0,1,2,2,80,B,\"" + e.CodigoBarras + "\"\n");
                    }
                    else if (contador == 2)
                    {
                        parte = "medio";
                        texto.Append("A324,5,0,2,1,1,N," + '"' + e.Codigo + '"' + "\n");
                        texto.Append("A324,22,0,1,1,1,N," + '"' + b + '"' + "\n");
                        texto.Append("A324,38,0,1,1,1,N," + '"' + c + '"' + "\n");
                        texto.Append("B324,54,0,1,2,2,80,B,\"" + e.CodigoBarras + "\"\n");
                    }
                    else
                    {
                        parte = "completo";
                        texto.Append("A604,5,0,2,1,1,N," + '"' + e.Codigo + '"' + "\n");
                        texto.Append("A604,22,0,1,1,1,N," + '"' + b + '"' + "\n");
                        texto.Append("A604,38,0,1,1,1,N," + '"' + c + '"' + "\n");
                        texto.Append("B604,54,0,1,2,2,80,B,\"" + e.CodigoBarras + "\"\n");
                        texto.Append("P1\n");
                        contador = 0;
                    }
                    i++;
                }
                
            }
            
            if(parte != "completo")
            {
                texto.Append("P1\n");
            }
            
            
            
            
            ////inicia a impressão.
            try
            {
                System.IO.File.Delete("impTemp.txt");
            }
            catch { }

            try
            {
                TextWriter tw = new StreamWriter("impTemp.txt");
                tw.Write(texto.ToString());
                tw.Close();
                System.IO.File.Copy("impTemp.txt", @"\\SERVIDOR\elgin");
            }
            catch (Exception ex)
            {
                MessageBox.Show("POR FAVOR VERIFIQUE A CONEXÃO COM A IMPRESSORA.");
            }

        }
    }
}
