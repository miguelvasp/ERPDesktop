﻿using System;
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
    public partial class frmShowYesNoMessage : Form
    {
        public frmShowYesNoMessage(string message)
        {
            InitializeComponent();
            btnSim.DialogResult = System.Windows.Forms.DialogResult.Yes;
            btnNao.DialogResult = System.Windows.Forms.DialogResult.No;
            lbMgs.Text = message;
        }
    }
}
