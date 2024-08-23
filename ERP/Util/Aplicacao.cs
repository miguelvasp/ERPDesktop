using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;
using ERP.DAL;
using System.Data;
using System.Reflection;
using System.Drawing;
using ERP.ModelView;

namespace ERP.Util
{
    public static class Aplicacao
    {

        public static void DataGridViewAutosizeColumns(DataGridView dgv)
        {
            //auto size das colunas
            for (int i = 0; i < dgv.Columns.Count - 1; i++)
            {
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgv.Columns[dgv.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                int colw = dgv.Columns[i].Width;
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgv.Columns[i].Width = colw;
            }
        }

        public static void DesbloqueiaControles(RibbonForm frm, RibbonButton Adiciona, RibbonButton Altera, RibbonButton Grava, RibbonButton Cancelar, RibbonButton Excluir)
        {
            Adiciona.Enabled = false;
            Altera.Enabled = false;
            Grava.Enabled = true;
            Cancelar.Enabled = true;
            Excluir.Enabled = false;

            for (int i = 0; i < frm.Controls.Count; i++)
            {
                //if (frm.Controls[i].Tag.ToString() != "-1")
                //{
                if (frm.Controls[i] is TextBox) { (frm.Controls[i] as TextBox).Enabled = true; }
                if (frm.Controls[i] is ComboBox) { (frm.Controls[i] as ComboBox).Enabled = true; }
                if (frm.Controls[i] is CheckBox) { (frm.Controls[i] as CheckBox).Enabled = true; }
                if (frm.Controls[i] is DateTimePicker) { (frm.Controls[i] as DateTimePicker).Enabled = true; }
                if (frm.Controls[i] is RadioButton) { (frm.Controls[i] as RadioButton).Enabled = true; }
                if (frm.Controls[i] is MaskedTextBox) { (frm.Controls[i] as MaskedTextBox).Enabled = true; }
                if (frm.Controls[i] is ListBox) { (frm.Controls[i] as ListBox).Enabled = true; }
                if (frm.Controls[i] is TabControl)
                {
                    foreach (TabPage t in (frm.Controls[i] as TabControl).TabPages)
                    {
                        for (int j = 0; j < t.Controls.Count; j++)
                        {
                            if (t.Controls[j] is TextBox) { (t.Controls[j] as TextBox).Enabled = true; }
                            if (t.Controls[j] is ComboBox) { (t.Controls[j] as ComboBox).Enabled = true; }
                            if (t.Controls[j] is CheckBox) { (t.Controls[j] as CheckBox).Enabled = true; }
                            if (t.Controls[j] is RadioButton) { (t.Controls[j] as RadioButton).Enabled = true; }
                            if (t.Controls[j] is MaskedTextBox) { (t.Controls[j] as MaskedTextBox).Enabled = true; }
                            if (t.Controls[j] is ListBox) { (t.Controls[j] as ListBox).Enabled = true; }
                            if (t.Controls[j] is Button) { (t.Controls[j] as Button).Enabled = true; }
                            if (t.Controls[j] is DataGridView) { (t.Controls[j] as DataGridView).Enabled = true; }
                            if (t.Controls[j] is DateTimePicker) { (t.Controls[j] as DateTimePicker).Enabled = true; }

                            //componentes com tag 0 nunca são liberados

                            if (t.Controls[j].Tag != null && t.Controls[j].Tag.ToString() == "0")
                            {
                                t.Controls[j].Enabled = false;
                            }

                        }
                    }
                }
                //}
            }
        }


        /// <summary>
        /// Corrige o erro de alinhamento dos labes causado pela mudança no RibbonForm
        /// </summary>
        /// <param name="frm"></param>
        public static void CorrigeLabels(RibbonForm frm)
        {
            for (int i = 0; i < frm.Controls.Count; i++)
            {
                if (frm.Controls[i] is Label)
                {
                    (frm.Controls[i] as Label).Top = (frm.Controls[i] as Label).Top - 5;
                    (frm.Controls[i] as Label).Left = (frm.Controls[i] as Label).Left - 8;
                }
                if (frm.Controls[i] is CheckBox)
                {
                    (frm.Controls[i] as CheckBox).Top = (frm.Controls[i] as CheckBox).Top - 5;
                    (frm.Controls[i] as CheckBox).Left = (frm.Controls[i] as CheckBox).Left - 8;
                }
            }

            //aumenta o campo de visualização dos itens do combobox
            //for(int i = 0; i < frm.Controls.Count; i++)
            //{
            //    if (frm.Controls[i] is ComboBox)
            //    {
            //        if((frm.Controls[i] as ComboBox).DropDownWidth < 250)
            //        {
            //            (frm.Controls[i] as ComboBox).DropDownWidth = 250;
            //        }
            //    }
            //}


        }

        public static void BloqueiaControles (Form frm)
        {
            for (int i = 0; i < frm.Controls.Count; i++)
            {
                if (frm.Controls[i] is TextBox) { (frm.Controls[i] as TextBox).Enabled = false; }
                if (frm.Controls[i] is ComboBox) { (frm.Controls[i] as ComboBox).Enabled = false; }
                if (frm.Controls[i] is CheckBox) { (frm.Controls[i] as CheckBox).Enabled = false; }
                if (frm.Controls[i] is DateTimePicker) { (frm.Controls[i] as DateTimePicker).Enabled = false; }
                if (frm.Controls[i] is RadioButton) { (frm.Controls[i] as RadioButton).Enabled = false; }
                if (frm.Controls[i] is MaskedTextBox) { (frm.Controls[i] as MaskedTextBox).Enabled = false; }
                if (frm.Controls[i] is ListBox) { (frm.Controls[i] as ListBox).Enabled = false; }
                if (frm.Controls[i] is TabControl) { (frm.Controls[i] as TabControl).Enabled = false; }
            }
        }

        public static void BloqueiaControles(string NomeFormualario, ToolStripButton Adiciona)
        {
            Adiciona.Enabled = true;

            int IdUsuario = Convert.ToInt32(Util.GetAppSettings("IdUsuario"));

            PermissaoDAL pDal = new PermissaoDAL();
            Permissao permissao = pDal.PURepository.Get(w => w.IdUsuario.Equals(IdUsuario) && w.Programa.Formulario.ToLower() == NomeFormualario.ToLower()).FirstOrDefault();
            if (permissao != null)
            {
                if (!permissao.Incluir)
                {
                    Adiciona.Enabled = false;
                }
            }
            else
            {
                Adiciona.Enabled = false;
            }
        }

        public static void BloqueiaControles(RibbonForm frm, RibbonButton Grava)
        {
            Grava.Enabled = true;

            int IdUsuario = Convert.ToInt32(Util.GetAppSettings("IdUsuario"));

            PermissaoDAL pDal = new PermissaoDAL();
            Permissao permissao = pDal.PURepository.Get(w => w.IdUsuario.Equals(IdUsuario) && w.Programa.Formulario.ToLower() == frm.Name.ToLower()).FirstOrDefault();
            if (permissao != null)
            {
                if (!permissao.Incluir && !permissao.Alterar)
                {
                    Grava.Enabled = false;
                }
            }
            else
            {
                Grava.Enabled = false;
            }

            for (int i = 0; i < frm.Controls.Count; i++)
            {
                if (frm.Controls[i] is TextBox) { (frm.Controls[i] as TextBox).Enabled = false; }
                if (frm.Controls[i] is ComboBox) { (frm.Controls[i] as ComboBox).Enabled = false; }
                if (frm.Controls[i] is CheckBox) { (frm.Controls[i] as CheckBox).Enabled = false; }
                if (frm.Controls[i] is DateTimePicker) { (frm.Controls[i] as DateTimePicker).Enabled = false; }
                if (frm.Controls[i] is RadioButton) { (frm.Controls[i] as RadioButton).Enabled = false; }
                if (frm.Controls[i] is MaskedTextBox) { (frm.Controls[i] as MaskedTextBox).Enabled = false; }
                if (frm.Controls[i] is ListBox) { (frm.Controls[i] as ListBox).Enabled = false; }
                if (frm.Controls[i] is TabControl) { (frm.Controls[i] as TabControl).Enabled = false; }
            }
        }

        public static void BloqueiaControles(RibbonForm frm, RibbonButton Adiciona, RibbonButton Altera, RibbonButton Grava, RibbonButton Cancelar, RibbonButton Excluir)
        {
            Adiciona.Enabled = true;
            Altera.Enabled = true;
            Grava.Enabled = false;
            Cancelar.Enabled = false;
            Excluir.Enabled = true;

            int IdUsuario = Convert.ToInt32(Util.GetAppSettings("IdUsuario"));

            PermissaoDAL pDal = new PermissaoDAL();
            Permissao permissao = pDal.PURepository.Get(w => w.IdUsuario.Equals(IdUsuario) && w.Programa.Formulario.ToLower() == frm.Name.ToLower()).FirstOrDefault();
            if (permissao != null)
            {
                if (!permissao.Incluir)
                {
                    Adiciona.Enabled = false;
                }

                if (!permissao.Alterar)
                {
                    Altera.Enabled = false;
                }

                if (!permissao.Excluir)
                {
                    Excluir.Enabled = false;
                }
            }
            else
            {
                Adiciona.Enabled = false;
                Altera.Enabled = false;
                Excluir.Enabled = false;
            }

            for (int i = 0; i < frm.Controls.Count; i++)
            {
                if (frm.Controls[i] is Label)
                {
                    if ((frm.Controls[i] as Label).Name.ToLower() == "lbcodigo")
                    {
                        if ((frm.Controls[i] as Label).Text == "0")
                        {
                           // Altera.Enabled = false;
                           // Excluir.Enabled = false;
                        }
                    }
                }

                if (frm.Controls[i] is TextBox) { (frm.Controls[i] as TextBox).Enabled = false; }
                if (frm.Controls[i] is ComboBox) { (frm.Controls[i] as ComboBox).Enabled = false; }
                if (frm.Controls[i] is CheckBox) { (frm.Controls[i] as CheckBox).Enabled = false; }
                if (frm.Controls[i] is DateTimePicker) { (frm.Controls[i] as DateTimePicker).Enabled = false; }
                if (frm.Controls[i] is RadioButton) { (frm.Controls[i] as RadioButton).Enabled = false; }
                if (frm.Controls[i] is MaskedTextBox) { (frm.Controls[i] as MaskedTextBox).Enabled = false; }
                if (frm.Controls[i] is ListBox) { (frm.Controls[i] as ListBox).Enabled = false; }
                if (frm.Controls[i] is TabControl)
                {
                    foreach (TabPage t in (frm.Controls[i] as TabControl).TabPages)
                    {
                        for (int j = 0; j < t.Controls.Count; j++)
                        {
                            if (t.Controls[j] is TextBox) { (t.Controls[j] as TextBox).Enabled = false; }
                            if (t.Controls[j] is ComboBox) { (t.Controls[j] as ComboBox).Enabled = false; }
                            if (t.Controls[j] is CheckBox) { (t.Controls[j] as CheckBox).Enabled = false; }
                            if (t.Controls[j] is DateTimePicker) { (t.Controls[j] as DateTimePicker).Enabled = false; }
                            if (t.Controls[j] is RadioButton) { (t.Controls[j] as RadioButton).Enabled = false; }
                            if (t.Controls[j] is MaskedTextBox) { (t.Controls[j] as MaskedTextBox).Enabled = false; }
                            if (t.Controls[j] is ListBox) { (t.Controls[j] as ListBox).Enabled = false; }
                            if (t.Controls[j] is Button) { (t.Controls[j] as Button).Enabled = false; }
                            if (t.Controls[j] is DataGridView) { (t.Controls[j] as DataGridView).Enabled = false; }
                            //tira a cor amarela dos dados obrigatorios
                            t.Controls[j].BackColor = Color.White;
                        }
                    }
                }
                //tira a cor amarela dos dados obrigatorios
                frm.Controls[i].BackColor = Color.White;
            }
        }

        public static void LimpaControles(RibbonForm frm)
        {
            for (int i = 0; i < frm.Controls.Count; i++)
            {
                if (frm.Controls[i] is TextBox) { (frm.Controls[i] as TextBox).Text = ""; }
                if (frm.Controls[i] is ComboBox) { (frm.Controls[i] as ComboBox).Text = ""; }
                if (frm.Controls[i] is CheckBox) { (frm.Controls[i] as CheckBox).Checked = false; }
                if (frm.Controls[i] is DateTimePicker) { (frm.Controls[i] as DateTimePicker).Text = ""; }
                if (frm.Controls[i] is RadioButton) { (frm.Controls[i] as RadioButton).Checked = false; }
                if (frm.Controls[i] is MaskedTextBox) { (frm.Controls[i] as MaskedTextBox).Text = ""; }
                if (frm.Controls[i] is TabControl)
                {
                    foreach (TabPage t in (frm.Controls[i] as TabControl).TabPages)
                    {
                        for (int j = 0; j < t.Controls.Count; j++)
                        {
                            if (t.Controls[j] is TextBox) { (t.Controls[j] as TextBox).Text = ""; }
                            if (t.Controls[j] is ComboBox) { (t.Controls[j] as ComboBox).Text = ""; }
                            if (t.Controls[j] is CheckBox) { (t.Controls[j] as CheckBox).Checked = false; }
                            if (frm.Controls[i] is DateTimePicker) { (frm.Controls[i] as DateTimePicker).Text = ""; }
                            if (t.Controls[j] is MaskedTextBox) { (t.Controls[j] as MaskedTextBox).Text = ""; }
                            if (t.Controls[j] is ListBox) { (t.Controls[j] as ListBox).Items.Clear(); }
                        }
                    }
                }
            }
        }

        private static void VerificaControles(Control.ControlCollection controles, List<Permissao> permissao)
        {
            for (int i = 0; i < controles.Count; i++)
            {
                if (controles[i] is LinkLabel)
                {
                    if (controles[i].Tag != null)
                    {
                        bool visualizar = false;

                        foreach (var item in permissao)
                        {
                            if (controles[i].Tag.ToString().ToLower() == item.Programa.Formulario.ToLower())
                            {
                                visualizar = item.Visualizar;
                                break;
                            }
                        }

                        if (visualizar)
                        {
                            controles[i].Visible = true;
                        }
                        else
                        {
                            controles[i].Visible = false;
                        }
                    }
                }
                else if (controles[i] is Ribbon)
                {

                }
                else
                {
                    if (controles[i].Controls.Count > 0)
                    {
                        VerificaControles(controles[i].Controls, permissao);
                    }
                }
            }
        }

        public static IEnumerable<Control> GetAllControls(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControls(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        public static void Permissao(frmMenu frm, int idUsuario)
        {
            PermissaoDAL pDal = new PermissaoDAL();
            var permissao = pDal.PURepository.Get(w => w.IdUsuario.Equals(idUsuario)).ToList();

            var links = GetAllControls(frm, typeof(LinkLabel));

            foreach (RibbonTab tab in frm.ribbon1.Tabs)
            {
                foreach (RibbonPanel Panel in tab.Panels)
                {
                    foreach (RibbonButton button in Panel.Items)
                    {
                        bool visualizar = false;

                        foreach (var item in permissao)
                        {
                            if (button.Tag != null)
                            {
                                if (button.Tag.ToString().ToLower() == item.Programa.Formulario.ToLower())
                                {
                                    visualizar = item.Visualizar;
                                    break;
                                }
                            }
                        }

                        if (visualizar)
                        {
                            button.Visible = true;
                        }
                        else
                        {
                            button.Visible = false;
                        }

                        if (button.DropDownItems.Count > 0)
                        {
                            foreach (var ddItem in button.DropDownItems)
                            {
                                bool visualizarDDItem = false;

                                foreach (var item in permissao)
                                {
                                    if (ddItem.Tag != null)
                                    {
                                        if (ddItem.Tag.ToString().ToLower() == item.Programa.Formulario.ToLower())
                                        {
                                            visualizarDDItem = item.Visualizar;
                                            break;
                                        }
                                    }
                                }

                                if (visualizarDDItem)
                                {
                                    ddItem.Visible = true;
                                }
                                else
                                {
                                    ddItem.Visible = false;
                                }

                            }

                        }
                    }
                }
            }

            foreach (var controle in links)
            {
                if (controle.Tag != null)
                {
                    bool visualizar = false;

                    foreach (var item in permissao)
                    {
                        if (controle.Tag.ToString().ToLower() == item.Programa.Formulario.ToLower())
                        {
                            visualizar = item.Visualizar;
                            break;
                        }
                    }

                    if (visualizar)
                    {
                        controle.Visible = true;
                    }
                    else
                    {
                        controle.Visible = false;
                    }
                }
            }
        }

        public static DataTable GenericReportDataTable(List<GenericReport> lista)
        {
            EmpresaDAL empDal = new EmpresaDAL();
            int idEmpresa = Convert.ToInt32(Util.GetAppSettings("IdEmpresa"));
            Empresa emp = empDal.getByIdEmpresa(idEmpresa);
            
            DataTable dt = new DataTable();
            dt.Columns.Add("Texto1");
            dt.Columns.Add("Texto2");
            dt.Columns.Add("Texto3");
            dt.Columns.Add("Texto4");
            dt.Columns.Add("Logo",  typeof(byte[]));
            foreach(GenericReport r in lista)
            {
                DataRow dr = dt.NewRow();
                dr["Texto1"] = r.Text1;
                dr["Texto2"] = r.Text2;
                dr["Texto3"] = r.Text3;
                dr["Texto4"] = r.Text4;
                dr["Logo"] = emp.Logo;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        
        public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();


            // column names
            PropertyInfo[] oProps = null;


            if (varlist == null) return dtReturn;


            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if (!colType.FullName.ToUpper().Contains("ICOLLECTION"))
                        {
                            if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                            {
                                colType = colType.GetGenericArguments()[0];
                            }

                            string colName = pi.Name;
                            foreach (var item in ((System.Reflection.MemberInfo)(pi)).CustomAttributes)
                            {
                                if (item.AttributeType.FullName == "System.ComponentModel.DisplayNameAttribute")
                                {
                                    foreach (var item2 in item.ConstructorArguments)
                                    {
                                        colName = item2.Value.ToString().Replace(" ", "_");
                                    }
                                }
                            }

                            dtReturn.Columns.Add(new DataColumn(colName, colType));
                        }
                    }
                }


                DataRow dr = dtReturn.NewRow();


                foreach (PropertyInfo pi in oProps)
                {
                    Type colType = pi.PropertyType;

                    if (!colType.FullName.ToUpper().Contains("ICOLLECTION"))
                    {
                        string colName = pi.Name;
                        foreach (var item in ((System.Reflection.MemberInfo)(pi)).CustomAttributes)
                        {
                            if (item.AttributeType.FullName == "System.ComponentModel.DisplayNameAttribute")
                            {
                                foreach (var item2 in item.ConstructorArguments)
                                {
                                    colName = item2.Value.ToString().Replace(" ", "_");
                                }
                            }
                        }

                        dr[colName] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                    }
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        public static DialogResult ShowQuestionMessage(string message)
        {
            ERP.frmShowYesNoMessage frm = new frmShowYesNoMessage(message);
            return frm.ShowDialog();
        }

        public static void ShowMessage(string message)
        {
            ERP.frmShowMessage frm = new frmShowMessage(message);
            frm.ShowDialog();
        }


        public static void ShowErrorMessage(Exception e)
        {
            ERP.frmShowErrorMessage frm = new frmShowErrorMessage(e);
            frm.ShowDialog();
            //var dialogTypeName = "System.Windows.Forms.PropertyGridInternal.GridErrorDlg";
            //var dialogType = typeof(Form).Assembly.GetType(dialogTypeName);

            //// Create dialog instance.
            //var dialog = (Form)Activator.CreateInstance(dialogType, new PropertyGrid());

            //// Populate relevant properties on the dialog instance.
            //dialog.Text = "Mensagem";
            //dialog.Width = 400;
            //dialogType.GetProperty("Details").SetValue(dialog, e.ToString(), null);
            //dialogType.GetProperty("Message").SetValue(dialog, e.Message, null);

            //// Display dialog.
            //var result = dialog.ShowDialog();
        }

    }
}
