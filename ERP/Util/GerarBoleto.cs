using BoletoNet;
using ERP.Auxiliares;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ERP.Util
{
    public class GerarBoleto
    {
        private string _arquivo = string.Empty;
        private DateTime _dtVencimento;
        private short _codigoBanco = 0;
        private string _agencia = "";
        private string _digitoAgencia = "";
        private string _conta = "";
        private string _digitoConta = "";
        private string _codigoCedente = "";
        private string _carteira = "";
        private string _nossoNumero = "";
        private string _numeroDocumento = "";
        private decimal _valorBoleto = 0;
        private Cedente _cedente = new Cedente();
        private Sacado _sacado = new Sacado();
        private Endereco _endereco = new Endereco();

        private frmImpressaoBoleto _impressaoBoleto = new frmImpressaoBoleto();

        public DateTime DtVencimento
        {
            get { return _dtVencimento; }
            set { _dtVencimento = value; }
        }

        public short CodigoBanco
        {
            get { return _codigoBanco; }
            set { _codigoBanco = value; }
        }

        public string Agencia
        {
            get { return _agencia; }
            set { _agencia = value; }
        }

        public string DigitoAgencia
        {
            get { return _digitoAgencia; }
            set { _digitoAgencia = value; }
        }

        public string Conta
        {
            get { return _conta; }
            set { _conta = value; }
        }

        public string DigitoConta
        {
            get { return _digitoConta; }
            set { _digitoConta = value; }
        }

        public string CodigoCedente
        {
            get { return _codigoCedente; }
            set { _codigoCedente = value; }
        }

        public string Carteira
        {
            get { return _carteira; }
            set { _carteira = value; }
        }

        public string NossoNumero
        {
            get { return _nossoNumero; }
            set { _nossoNumero = value; }
        }

        public string NumeroDocumento
        {
            get { return _numeroDocumento; }
            set { _numeroDocumento = value; }
        }

        public decimal ValorBoleto
        {
            get { return _valorBoleto; }
            set { _valorBoleto = value; }
        }

        public Cedente Cedente
        {
            get { return _cedente; }
            set { _cedente = value; }
        }

        public Sacado Sacado
        {
            get { return _sacado; }
            set { _sacado = value; }
        }

        public Endereco Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }

        #region GERAR LAYOUT DO BOLETO
        private void GeraLayout(List<BoletoBancario> boletos)
        {
            StringBuilder html = new StringBuilder();
            foreach (BoletoBancario o in boletos)
            {
                html.Append(o.MontaHtml());
                html.Append("</br></br></br></br></br></br></br></br></br></br>");
            }

            _arquivo = System.IO.Path.GetTempFileName();

            using (FileStream f = new FileStream(_arquivo, FileMode.Create))
            {
                StreamWriter w = new StreamWriter(f, System.Text.Encoding.UTF8);
                w.Write(html.ToString());
                w.Close();
                f.Close();
            }
        }
        #endregion

        #region BOLETO ITAÚ
        private void GeraBoletoItau(int qtde)
        {
            // Cria o boleto, e passa os parâmetros usuais
            BoletoBancario bb;

            List<BoletoBancario> boletos = new List<BoletoBancario>();
            for (int i = 0; i < qtde; i++)
            {

                bb = new BoletoBancario();
                bb.CodigoBanco = _codigoBanco;

                Cedente c = new Cedente(_cedente.CPFCNPJ, _cedente.Nome, _agencia, _conta);

                //Na carteira 198 o código do Cedente é a conta bancária
                c.Codigo = _conta;

                Boleto b = new Boleto(_dtVencimento, _valorBoleto, _carteira, _nossoNumero, c, new EspecieDocumento(_codigoBanco, "1"));
                b.NumeroDocumento = _numeroDocumento;

                // Dados do Sacado
                b.Sacado = new Sacado(_sacado.CPFCNPJ, _sacado.Nome);
                b.Sacado.Endereco = _endereco;

                Instrucao_Itau item1 = new Instrucao_Itau(9, 5);
                Instrucao_Itau item2 = new Instrucao_Itau(81, 10);
                item2.Descricao += " " + item2.QuantidadeDias.ToString() + " dias corridos do vencimento.";
                b.Instrucoes.Add(item1);
                b.Instrucoes.Add(item2);

                // juros/descontos
                if (b.ValorDesconto == 0)
                {
                    Instrucao_Itau item3 = new Instrucao_Itau(999, 1);
                    item3.Descricao += ("1,00 por dia de antecipação.");
                    b.Instrucoes.Add(item3);
                }

                bb.Boleto = b;
                bb.Boleto.Valida();

                boletos.Add(bb);
            }

            GeraLayout(boletos);
        }
        #endregion

        #region BOLETO BRADESCO
        public void GeraBoletoBradesco(int qtde)
        {

            // Cria o boleto, e passa os parâmetros usuais
            BoletoBancario bb;

            List<BoletoBancario> boletos = new List<BoletoBancario>();
            for (int i = 0; i < qtde; i++)
            {

                bb = new BoletoBancario();
                bb.CodigoBanco = _codigoBanco;

                Cedente c = new Cedente(_cedente.CPFCNPJ, _cedente.Nome, _agencia, _digitoAgencia, _conta, _digitoConta);
                c.Codigo = _codigoCedente;

                Boleto b = new Boleto(_dtVencimento, _valorBoleto, _nossoNumero, _nossoNumero, c);
                b.NumeroDocumento = _numeroDocumento;

                // Dados do Sacado
                b.Sacado = new Sacado(_sacado.CPFCNPJ, _sacado.Nome);
                b.Sacado.Endereco = _endereco;

                Instrucao_Bradesco item = new Instrucao_Bradesco(9, 5);
                item.Descricao += " após " + item.QuantidadeDias.ToString() + " dias corridos do vencimento.";
                b.Instrucoes.Add(item); //"Não Receber após o vencimento");

                bb.Boleto = b;
                bb.Boleto.Valida();

                boletos.Add(bb);
            }

            GeraLayout(boletos);
        }
        #endregion

        #region Eventos do BackgroundWorker

        public void CriarEventoBackgroundWorker()
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            switch (CodigoBanco)
            {
                case 341: // Itau
                    GeraBoletoItau(1);
                    break;

                case 237: // Bradesco
                    GeraBoletoBradesco(1);
                    break;
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Cria um formulário com um componente WebBrowser dentro
            _impressaoBoleto.webBrowser.Navigate(_arquivo);
            _impressaoBoleto.ShowDialog();

        }
        #endregion Eventos do BackgroundWorkerground
    }
}
