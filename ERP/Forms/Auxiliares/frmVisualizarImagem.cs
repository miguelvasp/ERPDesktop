using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Auxiliares
{
    public partial class frmVisualizarImagem : Form
    {
        public frmVisualizarImagem(string fileName)
        {
            InitializeComponent();

            pctBoleto.Image = Image.FromFile(fileName);
        }
    }
}
