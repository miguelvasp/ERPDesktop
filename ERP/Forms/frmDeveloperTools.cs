using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmDeveloperTools : Form
    {
        public frmDeveloperTools()
        {
            InitializeComponent();
        }

        private void frmDeveloperTools_Load(object sender, EventArgs e)
        {
            //carrega os forms no combo
            List<ComboForm> Lista = new List<ComboForm>();
            //Type formType = typeof(RibbonForm);
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                Lista.Add(new ComboForm() { Form = type, Nome = type.Name });
            }

            cboForms.DataSource = Lista.Where(x => x.Nome.Contains("frm")).OrderBy(x => x.Nome).ToList();
            cboForms.ValueMember = "Form";
            cboForms.DisplayMember = "Nome";
            cboForms.SelectedIndex = -1;
        }

        private void btnGerarLista_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(cboForms.Text))
            {
                Type t = (Type)cboForms.SelectedValue;
                var obj = (Form)Activator.CreateInstance(t);
                Form f = (Form)obj;
                List<string> GetValueList = new List<string>();
                List<string> SetValueList = new List<string>();
                List<string> Combos = new List<string>();
                //escreve o carregamento dos textos
                foreach(Control c in f.Controls)
                {
                    string command = "";
                    if(c is TextBox || c is MaskedTextBox)
                    {
                        command = c.Name + ".Text = " + txtC.Text + "." + c.Name.Replace("txt", "") + " == null?\"\": " + txtC.Text + "." + c.Name.Replace("txt", "") + ".ToString();\r\n"; 
                    }
                    if (c is ComboBox)
                    {
                        command = c.Name + ".SelectedValue = " + txtC.Text + ".Id" + c.Name.Replace("cbo", "") + " == null ? 0: " + txtC.Text + ".Id" + c.Name.Replace("cbo", "") + ";\r\n";
                    }
                    if (c is CheckBox)
                    {
                        command = c.Name + ".Checked = Convert.ToBoolean(" + txtC.Text + "." + c.Name.Replace("chk", "") + ");\r\n";
                    }
                    if(c is DateTimePicker)
                    {
                        command = c.Name + ".Text = " + txtC.Text + "." + c.Name.Replace("txt", "") + " == null?\"\": " + txtC.Text + "." + c.Name.Replace("txt", "") + ".ToShortDateString();\r\n"; 
                    }

                    if(c is TabControl)
                    {
                        foreach (TabPage tp in (c as TabControl).TabPages)
                        {
                            foreach(Control tb in tp.Controls)
                            {
                                if (tb is TextBox || tb is MaskedTextBox)
                                {
                                    command = tb.Name + ".Text = " + txtC.Text + "." + tb.Name.Replace("txt", "") + " == null?\"\": " + txtC.Text + "." + tb.Name.Replace("txt", "") + ".ToString();\r\n";
                                }
                                if (tb is ComboBox)
                                {
                                    command = tb.Name + ".SelectedValue = " + txtC.Text + ".Id" + tb.Name.Replace("cbo", "") + " == null? 0 : " + txtC.Text + ".Id" + tb.Name.Replace("cbo", "") + ";\r\n";
                                }
                                if (tb is CheckBox)
                                {
                                    command = tb.Name + ".Checked = Convert.ToBoolean(" + txtC.Text + "." + tb.Name.Replace("chk", "") + ");\r\n";
                                }
                                if (tb is DateTimePicker)
                                {
                                    command = tb.Name + ".Text = " + txtC.Text + "." + tb.Name.Replace("txt", "") + " == null?\"\": " + txtC.Text + "." + tb.Name.Replace("txt", "") + ".ToShortDateString();\r\n";
                                }

                                GetValueList.Add(command);
                                command = "";
                            }
                            
                        }
                    }




                    GetValueList.Add(command);
                }


                
                //escreve o carregamento dos valores
                foreach (Control c in f.Controls)
                {
                    string command = "";
                    if (c is TextBox || c is MaskedTextBox)
                    {
                        string tAux = txtC.Text + "." + c.Name.Replace("txt", "") + " = null;\r\n";
                        SetValueList.Add(tAux);
                        command = "if (!String.IsNullOrEmpty(" + c.Name + ".Text)) " + txtC.Text + "." + c.Name.Replace("txt", "") + " = " + c.Name + ".Text;\r\n";
                    }
                    if (c is ComboBox)
                    {
                        string aux = txtC.Text + ".Id" + c.Name.Replace("cbo", "") + " = null;\r\n";
                        SetValueList.Add(aux);
                        command = "if (!String.IsNullOrEmpty(" + c.Name + ".Text)) " + txtC.Text + ".Id" + c.Name.Replace("txt", "") + " = Convert.ToInt32(" + c.Name + ".SelectedValue);\r\n";
                    }
                    if (c is CheckBox)
                    {
                        command =  txtC.Text + "." + c.Name.Replace("chk", "") + " = " + c.Name + ".Ckeched;\r\n";
                    }
                    if (c is DateTimePicker)
                    {
                        command = "if (!String.IsNullOrEmpty(" + c.Name + ".Text)) " + txtC.Text + "." + c.Name.Replace("txt", "") + " = Convert.ToDateTime(" + c.Name + ".Text);\r\n";
                    }

                    if (c is TabControl)
                    {
                        foreach (TabPage tp in (c as TabControl).TabPages)
                        {
                            foreach (Control tb in tp.Controls)
                            {
                                if (tb is TextBox || tb is MaskedTextBox)
                                {
                                    string tAux = txtC.Text + "." + tb.Name.Replace("txt", "") + " = null;\r\n";
                                    SetValueList.Add(tAux);
                                    command = "if (!String.IsNullOrEmpty(" + tb.Name + ".Text)) " + txtC.Text + "." + tb.Name.Replace("txt", "") + " = " + tb.Name + ".Text;\r\n";
                                }
                                if (tb is ComboBox)
                                {
                                    string aux = txtC.Text + ".Id" + tb.Name.Replace("cbo", "") + " = null;\r\n";
                                    SetValueList.Add(aux);
                                    command = "if (!String.IsNullOrEmpty(" + tb.Name + ".Text)) " + txtC.Text + ".Id" + tb.Name.Replace("cbo", "") + " = Convert.ToInt32(" + tb.Name + ".SelectedValue);\r\n";
                                }
                                if (tb is CheckBox)
                                {
                                    command =   txtC.Text + "."  + tb.Name.Replace("chk", "") + " = " + tb.Name + ".Ckeched;\r\n";
                                }
                                if (tb is DateTimePicker)
                                {
                                    command = "if (!String.IsNullOrEmpty(" + tb.Name + ".Text)) " + txtC.Text + "." + tb.Name.Replace("txt", "") + " = Convert.ToDateTime(" + tb.Name + ".Text);\r\n";
                                }

                                SetValueList.Add(command);
                                command = "";
                            }

                        }
                    }

                    SetValueList.Add(command);
                }


                txtLista.Text += "//Get Values//\r\n";
                //escreve os textos
                foreach(string s in GetValueList.OrderBy(x => x).ToList())
                {
                    txtLista.Text += s;
                }

                txtLista.Text += "\r\n";
                txtLista.Text += "\r\n";
                txtLista.Text += "\r\n";
                txtLista.Text += "//Set Values//\r\n";
                foreach (string s in SetValueList.OrderBy(x => x).ToList())
                {
                    txtLista.Text += s;
                }

                txtLista.Text += "\r\n";
                txtLista.Text += "\r\n";
                txtLista.Text += "\r\n";
                txtLista.Text += "//Load Combo Item//\r\n";
                foreach (Control c in f.Controls)
                {
                    string combo = "";
                    if(c is ComboBox)
                    {
                        combo = c.Name + ".DataSource = new " + c.Name.Replace("cbo", "") + "DAL().GetCombo();\r\n";
                        combo += c.Name + ".DisplayMember = \"Text\";\r\n";
                        combo += c.Name + ".ValueMember = \"iValue\";\r\n";
                        combo += c.Name + ".SelectedIndex = -1;\r\n";
                        Combos.Add(combo);
                    }

                    if (c is TabControl)
                    {
                        foreach (TabPage tp in (c as TabControl).TabPages)
                        {
                            foreach (Control tb in tp.Controls)
                            {
                                if (tb is ComboBox)
                                {
                                    combo = tb.Name + ".DataSource = new " + tb.Name.Replace("cbo", "") + "DAL().GetCombo();\r\n";
                                    combo += tb.Name + ".DisplayMember = \"Text\";\r\n";
                                    combo += tb.Name + ".ValueMember = \"iValue\";\r\n";
                                    combo += tb.Name + ".SelectedIndex = -1;\r\n";
                                    Combos.Add(combo);
                                    combo = "";
                                } 
                            }

                        }
                    }


                }


                //escreve os combos
                foreach (string s in Combos.OrderBy(x => x).ToList())
                {
                    txtLista.Text += s;
                }



            }
            
        }

        private T GetInstance<T>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
}
