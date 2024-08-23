using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public  partial class frmShowErrorMessage : Form
    {
        string msg = "";
        public frmShowErrorMessage(Exception e)
        {

            InitializeComponent();
            msg += "Error Message: \r\n";
            msg += e.Message + "";
            msg += "\r\n";
            msg += "****************************************************************************************************************************************************************\r\n";
            msg += "\r\n";
            msg += "Inner Exception: \r\n";
            msg += e.InnerException + "";
            msg += "\r\n";
            msg += "****************************************************************************************************************************************************************\r\n";
            msg += "\r\n";
            msg += "Target: \r\n";
            msg += e.TargetSite.Name;
            msg += "\r\n";
            msg += "****************************************************************************************************************************************************************\r\n";
            msg += "\r\n";
            msg += "StackTrace \r\n";
            msg += e.StackTrace + "\r\n";
            lbError.Text = e.Message;
            txtDetails.Text = msg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbError_Click(object sender, EventArgs e)
        {

        }
    }
}
