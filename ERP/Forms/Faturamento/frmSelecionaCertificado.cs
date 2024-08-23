using ERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Faturamento
{
    public partial class frmSelecionaCertificado : Form
    {
        public string NomeCertificado { get; set; }
        public frmSelecionaCertificado()
        {
            InitializeComponent();
        }

        private void frmSelecionaCertificado_Load(object sender, EventArgs e)
        {
            X509Store stores = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            try
            {
                // Abre o Store
                stores.Open(OpenFlags.ReadOnly);

                // Obtém a coleção dos certificados da Store
                X509Certificate2Collection certificados = stores.Certificates;

                // percorre a coleção de certificados
                List<ComboItem> itens = new List<ComboItem>();
                foreach (X509Certificate2 certificado in certificados)
                {
                    itens.Add(new ComboItem() { Value = certificado.Subject, Text = certificado.FriendlyName });
                }

                comboBox1.DataSource = itens;
                comboBox1.DisplayMember = "Text";
                comboBox1.ValueMember = "Value";
                comboBox1.SelectedIndex = -1;
            }
            finally
            {
                stores.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(comboBox1.Text))
            {
                Util.Aplicacao.ShowMessage("Selecione um certificado!");
                return;
            }

            NomeCertificado = comboBox1.SelectedValue.ToString();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NomeCertificado = "";
            this.Close();
        }
    }
}
