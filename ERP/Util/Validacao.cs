using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Util
{
    public static class Validacao
    {
        /// <summary>
        /// Realiza a validação do CNPJ
        /// </summary>
        public static class ValidaCNPJ
        {
            public static bool IsCnpj(string cnpj)
            {
                int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma;
                int resto;
                string digito;
                string tempCnpj;
                cnpj = cnpj.Trim();
                cnpj = cnpj.Replace(",", "").Replace(".", "").Replace("-", "").Replace("/", "");
                if (cnpj.Length != 14)
                    return false;
                tempCnpj = cnpj.Substring(0, 12);
                soma = 0;
                for (int i = 0; i < 12; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCnpj = tempCnpj + digito;
                soma = 0;
                for (int i = 0; i < 13; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return cnpj.EndsWith(digito);
            }
        }

        /// <summary>
        /// Realiza a validação do CPF
        /// </summary>
        public static class ValidaCPF
        {
            public static bool IsCpf(string cpf)
            {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;
                cpf = cpf.Trim();
                cpf = cpf.Replace(",", "").Replace(".", "").Replace("-", "");
                if (cpf.Length != 11)
                    return false;
                tempCpf = cpf.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return cpf.EndsWith(digito);
            }
        }

        /// <summary>
        /// Realiza a validação do número PIS
        /// </summary>
        public static class ValidaPis
        {
            public static bool IsPis(string pis)
            {
                int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma;
                int resto;
                if (pis.Trim().Length != 11)
                    return false;
                pis = pis.Trim();
                pis = pis.Replace(",", "").Replace("-", "").Replace(".", "").PadLeft(11, '0');

                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(pis[i].ToString()) * multiplicador[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                return pis.EndsWith(resto.ToString());
            }
        }

        public static bool IsNumber(string Valor)
        {
            try
            {
                decimal x = Convert.ToDecimal(Valor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidaEmail(string Valor)
        {
            if (string.IsNullOrEmpty(Valor))
            {
                return true;
            }
            bool Valido = false;
            Regex regEx = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$", RegexOptions.IgnoreCase);
            Valido = regEx.IsMatch(Valor);
            return Valido;
        }

        //public static bool ValidaCampos(RibbonForm frm)
        //{
        //    bool semErro = true;
        //    //limpa as marcações
        //    for (int i = 0; i < frm.Controls.Count; i++)
        //    {
        //        if (frm.Controls[i] is TextBox || frm.Controls[i] is ComboBox || frm.Controls[i] is MaskedTextBox)
        //        {
        //            frm.Controls[i].BackColor = Color.White;
        //        }
        //    }


        //    //Tag = 1 Campos Obrigatorios
        //    for (int i = 0; i < frm.Controls.Count; i++)
        //    {
        //        if (frm.Controls[i] is TextBox || frm.Controls[i] is ComboBox || frm.Controls[i] is MaskedTextBox || frm.Controls[i] is ListBox || frm.Controls[i] is DateTimePicker)
        //        {
        //            if (frm.Controls[i].Tag != null)
        //            {
        //                if (frm.Controls[i].Tag.ToString() == "1")
        //                {
        //                    if(frm.Controls[i] is ListBox)
        //                    {
        //                        if((frm.Controls[i] as ListBox).Items.Count == 0)
        //                        {
        //                            semErro = false;
        //                            frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (String.IsNullOrEmpty(frm.Controls[i].Text) || frm.Controls[i].Text.Trim() == "" || frm.Controls[i].Text == "  /  /")
        //                        {
        //                            semErro = false;
        //                            frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                        }
        //                    }
        //                }
        //                //valida tempo obrigatorio
        //                if(frm.Controls[i].Tag.ToString() == "6")
        //                {
        //                    if(IsHour(frm.Controls[i].Text.Trim()) == null)
        //                    {
        //                        semErro = false;
        //                        frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                    }

        //                }
        //            }
        //        }

        //        //valida o tabcontrol
        //        if (frm.Controls[i] is TabControl)
        //        {
        //            foreach(TabPage t in (frm.Controls[i] as TabControl).TabPages)
        //            {
        //                for (int j = 0; j < t.Controls.Count; j++)
        //                {
        //                    if (t.Controls[j] is TextBox || t.Controls[j] is ComboBox || t.Controls[j] is MaskedTextBox || t.Controls[j] is ListBox)
        //                    {
        //                        if (t.Controls[j].Tag != null)
        //                        {
        //                            if (t.Controls[j].Tag.ToString() == "1")
        //                            {
        //                                if (t.Controls[j] is ListBox)
        //                                {
        //                                    if ((t.Controls[j] as ListBox).Items.Count == 0)
        //                                    {
        //                                        semErro = false;
        //                                        t.Controls[j].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    if (String.IsNullOrEmpty(t.Controls[j].Text) || t.Controls[j].Text == "  /  /")
        //                                    {
        //                                        semErro = false;
        //                                        t.Controls[j].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }


        //    //Tag = 2 Campos de data obrigatorios
        //    for (int i = 0; i < frm.Controls.Count; i++)
        //    {
        //        if ( frm.Controls[i] is MaskedTextBox)
        //        {
        //            if (frm.Controls[i].Tag != null)
        //            {
        //                if (frm.Controls[i].Tag.ToString() == "2")
        //                {
        //                    if (String.IsNullOrEmpty(frm.Controls[i].Text) || frm.Controls[i].Text == "  /  /")
        //                    {
        //                        semErro = false;
        //                        frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                    }
        //                    else
        //                    {
        //                        try
        //                        {
        //                            DateTime dt = DateTime.Parse(frm.Controls[i].Text);
        //                        }
        //                        catch(Exception ex)
        //                        {
        //                            semErro = false;
        //                            frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }


        //    //Tag = 3 Campos de numero obrigatorios
        //    for (int i = 0; i < frm.Controls.Count; i++)
        //    {
        //        if (frm.Controls[i] is TextBox)
        //        {
        //            if (frm.Controls[i].Tag != null)
        //            {
        //                if (frm.Controls[i].Tag.ToString() == "3")
        //                {
        //                    if (String.IsNullOrEmpty(frm.Controls[i].Text))
        //                    {
        //                        semErro = false;
        //                        frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                    }
        //                    else
        //                    {
        //                        try
        //                        {
        //                            if(frm.Controls[i].Text.Contains('.'))
        //                            {
        //                                semErro = false;
        //                                frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                            }
        //                            else
        //                            {
        //                                decimal num = Convert.ToDecimal(frm.Controls[i].Text);
        //                            }                                    
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            semErro = false;
        //                            frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        if(frm.Controls[i] is TabControl)
        //        {
        //            foreach(TabPage t in (frm.Controls[i] as TabControl).TabPages)
        //            {
        //                for (int j = 0; j < t.Controls.Count; j++)
        //                {
        //                    if (t.Controls[j] is TextBox)
        //                    {
        //                        if (t.Controls[j].Tag != null)
        //                        {
        //                            if (t.Controls[j].Tag.ToString() == "3")
        //                            {
        //                                if (String.IsNullOrEmpty(t.Controls[j].Text))
        //                                {
        //                                    semErro = false;
        //                                    t.Controls[j].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                                }
        //                                else
        //                                {
        //                                    try
        //                                    {
        //                                        if (t.Controls[j].Text.Contains('.'))
        //                                        {
        //                                            semErro = false;
        //                                            t.Controls[j].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                                        }
        //                                        else
        //                                        {
        //                                            decimal num = Convert.ToDecimal(t.Controls[j].Text);
        //                                        }
        //                                    }
        //                                    catch (Exception ex)
        //                                    {
        //                                        semErro = false;
        //                                        t.Controls[j].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }


        //    //Tag = 4 Campos de numero não obrigatorios
        //    for (int i = 0; i < frm.Controls.Count; i++)
        //    {
        //        if (frm.Controls[i] is TextBox)
        //        {
        //            if (frm.Controls[i].Tag != null)
        //            {
        //                if (frm.Controls[i].Tag.ToString() == "4")
        //                {
        //                    if (!String.IsNullOrEmpty(frm.Controls[i].Text))
        //                    {
        //                        try
        //                        {
        //                            if (frm.Controls[i].Text.Contains('.'))
        //                            {
        //                                semErro = false;
        //                                frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                            }
        //                            else
        //                            {
        //                                decimal num = Convert.ToDecimal(frm.Controls[i].Text);
        //                            }
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            semErro = false;
        //                            frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        if(frm.Controls[i] is TabControl)
        //        {
        //            foreach(TabPage t in (frm.Controls[i] as TabControl).TabPages)
        //            {
        //                for (int j = 0; j < t.Controls.Count; j++)
        //                {
        //                    if (t.Controls[j] is TextBox)
        //                    {
        //                        if (t.Controls[j].Tag != null)
        //                        {
        //                            if (t.Controls[j].Tag.ToString() == "4")
        //                            {
        //                                if (!String.IsNullOrEmpty(t.Controls[j].Text))
        //                                {
        //                                    try
        //                                    {
        //                                        if (t.Controls[j].Text.Contains('.'))
        //                                        {
        //                                            semErro = false;
        //                                            t.Controls[j].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                                        }
        //                                        else
        //                                        {
        //                                            decimal num = Convert.ToDecimal(t.Controls[j].Text);
        //                                        }
        //                                    }
        //                                    catch (Exception ex)
        //                                    {
        //                                        semErro = false;
        //                                        t.Controls[j].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    //Tag = 5 CNPJ/CPF quando preenchido
        //    for (int i = 0; i < frm.Controls.Count; i++)
        //    {
        //        if (frm.Controls[i] is TextBox || frm.Controls[i] is MaskedTextBox)
        //        {
        //            if (frm.Controls[i].Tag != null)
        //            {
        //                if (frm.Controls[i].Tag.ToString() == "5")
        //                {
        //                    if (!String.IsNullOrEmpty(frm.Controls[i].Text))
        //                    {
        //                        try
        //                        {
        //                            string doc = frm.Controls[i].Text.Replace(".", "").Replace("-", "").Replace("/", "");
        //                            if(doc.Length == 11)
        //                            {
        //                                if(!ValidaCPF.IsCpf(doc))
        //                                {
        //                                    semErro = false;
        //                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                                }
        //                            }
        //                            else
        //                            {
        //                                if(!ValidaCNPJ.IsCnpj(doc))
        //                                {
        //                                    semErro = false;
        //                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                                }
        //                            }
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            semErro = false;
        //                            frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    //Tag = 5 CNPJ/CPF quando preenchido
        //    for (int i = 0; i < frm.Controls.Count; i++)
        //    {
        //        if (frm.Controls[i] is MaskedTextBox)
        //        {
        //            if (frm.Controls[i].Tag != null)
        //            {
        //                if (frm.Controls[i].Tag.ToString() == "6")
        //                {
        //                    if (!String.IsNullOrEmpty(frm.Controls[i].Text))
        //                    {
        //                        if(IsHour(frm.Controls[i].Text) == null)
        //                        {
        //                            semErro = false;
        //                            frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }


        //    return semErro;
        //}


        public static bool ValidaCampos(RibbonForm frm)
        {
            bool semErro = true;
            //limpa as marcações
            for (int i = 0; i < frm.Controls.Count; i++)
            {
                if (frm.Controls[i] is TextBox || frm.Controls[i] is ComboBox || frm.Controls[i] is MaskedTextBox)
                {
                    frm.Controls[i].BackColor = Color.White;
                }
            }
            //limpa os tabs
            //valida as componentes nos tabs
            try
            {
                for (int i = 0; i < frm.Controls.Count; i++)
                {
                    if (frm.Controls[i] is TabControl)
                    {
                        foreach (TabPage tp in (frm.Controls[i] as TabControl).TabPages)
                        {
                            for (int z = 0; z < tp.Controls.Count; z++)
                            {
                                if (tp.Controls[i] is TextBox || tp.Controls[i] is ComboBox || tp.Controls[i] is MaskedTextBox || tp.Controls[i] is ListBox || tp.Controls[i] is DateTimePicker)
                                {
                                    tp.Controls[z].BackColor = Color.White;
                                }
                            }
                        }
                    }
                }
            }
            catch  
            { 
            }
            



            //Valida os campos de um formulario normal sem tabpages
            //Tag = 1 Campos Obrigatorios
            for (int i = 0; i < frm.Controls.Count; i++)
            {
                if (frm.Controls[i] is TextBox || frm.Controls[i] is ComboBox || frm.Controls[i] is MaskedTextBox || frm.Controls[i] is ListBox || frm.Controls[i] is DateTimePicker)
                {
                    if (frm.Controls[i].Tag != null)
                    {
                        if (frm.Controls[i].Tag.ToString() == "1")
                        {
                            if (frm.Controls[i] is ListBox)
                            {
                                if ((frm.Controls[i] as ListBox).Items.Count == 0)
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                            else
                            {
                                if (String.IsNullOrEmpty(frm.Controls[i].Text) || frm.Controls[i].Text.Trim() == "" || frm.Controls[i].Text == "  /  /")
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                        }
                        //TAG 2 - Campos data obrigatorios
                        else if (frm.Controls[i].Tag.ToString() == "2")
                        {
                            try
                            { DateTime d = Convert.ToDateTime(frm.Controls[i].Text); }
                            catch (Exception ex)
                            {
                                semErro = false;
                                frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                            }
                        }
                        //TAG 3 - Campos número obrigatorios
                        else if (frm.Controls[i].Tag.ToString() == "3")
                        {
                            try
                            { 
                                Decimal d = Convert.ToDecimal(frm.Controls[i].Text); }
                            catch (Exception ex)
                            {
                                semErro = false;
                                frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                            }
                        }
                        //TAG 4 - Campos número Não obrigatorios
                        else if (frm.Controls[i].Tag.ToString() == "4")
                        {
                            try
                            {
                                if(!String.IsNullOrEmpty(frm.Controls[i].Text))
                                {
                                    Decimal d = Convert.ToDecimal(frm.Controls[i].Text);
                                }
                            }
                            catch (Exception ex)
                            {
                                semErro = false;
                                frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                            }
                        }
                        //TAG 5 - CNPJ/CPF quando preenchidos
                        else if (frm.Controls[i].Tag.ToString() == "5")
                        {
                            string valor = frm.Controls[i].Text.Replace(".", "").Replace("-", "").Replace("/", "");
                            if(valor.Length == 11)
                            {
                                if(!ValidaCPF.IsCpf(valor))
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                            else
                            {
                                if(!ValidaCNPJ.IsCnpj(valor))
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                        }

                        //TAG 6 - tempo obrigatorio
                        else if (frm.Controls[i].Tag.ToString() == "6")
                        {
                            if(IsHour(frm.Controls[i].Text) == null)
                            {
                                semErro = false;
                                frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                            }
                        }
                        //TAG 7 - tempo nao obrigatorio
                        else if (frm.Controls[i].Tag.ToString() == "7")
                        {
                            string hora = frm.Controls[i].Text.Replace(":", "");
                            if(!String.IsNullOrEmpty(hora.Trim()))
                            {
                                if (IsHour(frm.Controls[i].Text) == null)
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                        }
                        //------

                    }
                }
            }



            //valida as componentes nos tabs
            try
            {
                for (int i = 0; i < frm.Controls.Count; i++)
                {
                    if (frm.Controls[i] is TabControl)
                    {
                        foreach (TabPage tp in (frm.Controls[i] as TabControl).TabPages)
                        {
                            if (!ValidaTabPage(tp))
                            {
                                semErro = false;
                            }
                        }
                    }
                }
            }
            catch  
            {
                 
            }

            //valida as componentes nos panels
            try
            {
                for (int i = 0; i < frm.Controls.Count; i++)
                {
                    if (frm.Controls[i] is Panel)
                    {
                        if (!ValidaPanel((frm.Controls[i] as Panel)))
                        {
                            semErro = false;
                        }
                    }
                }
            }
            catch
            {

            }


            return semErro;
        }

        public static bool ValidaPanel(Panel frm)
        {
            bool semErro = true;
            //Tag = 1 Campos Obrigatorios
            for (int i = 0; i < frm.Controls.Count; i++)
            {
                if (frm.Controls[i] is TextBox || frm.Controls[i] is ComboBox || frm.Controls[i] is MaskedTextBox || frm.Controls[i] is ListBox || frm.Controls[i] is DateTimePicker)
                {
                    if (frm.Controls[i].Tag != null)
                    {
                        if (frm.Controls[i].Tag.ToString() == "1")
                        {
                            if (frm.Controls[i] is ListBox)
                            {
                                if ((frm.Controls[i] as ListBox).Items.Count == 0)
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                            else
                            {
                                if (String.IsNullOrEmpty(frm.Controls[i].Text) || frm.Controls[i].Text.Trim() == "" || frm.Controls[i].Text == "  /  /")
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                        }
                        //TAG 2 - Campos data obrigatorios
                        else if (frm.Controls[i].Tag.ToString() == "2")
                        {
                            try
                            { DateTime d = Convert.ToDateTime(frm.Controls[i].Text); }
                            catch (Exception ex)
                            {
                                semErro = false;
                                frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                            }
                        }
                        //TAG 3 - Campos número obrigatorios
                        else if (frm.Controls[i].Tag.ToString() == "3")
                        {
                            try
                            {
                                Decimal d = Convert.ToDecimal(frm.Controls[i].Text);
                            }
                            catch (Exception ex)
                            {
                                semErro = false;
                                frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                            }
                        }
                        //TAG 4 - Campos número Não obrigatorios
                        else if (frm.Controls[i].Tag.ToString() == "4")
                        {
                            try
                            {
                                if (!String.IsNullOrEmpty(frm.Controls[i].Text))
                                {
                                    Decimal d = Convert.ToDecimal(frm.Controls[i].Text);
                                }
                            }
                            catch (Exception ex)
                            {
                                semErro = false;
                                frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                            }
                        }
                        //TAG 5 - CNPJ/CPF quando preenchidos
                        else if (frm.Controls[i].Tag.ToString() == "5")
                        {
                            string valor = frm.Controls[i].Text.Replace(".", "").Replace("-", "").Replace("/", "");
                            if (valor.Length == 11)
                            {
                                if (!ValidaCPF.IsCpf(valor))
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                            else
                            {
                                if (!ValidaCNPJ.IsCnpj(valor))
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                        }

                        //TAG 6 - tempo obrigatorio
                        else if (frm.Controls[i].Tag.ToString() == "6")
                        {
                            if (IsHour(frm.Controls[i].Text) == null)
                            {
                                semErro = false;
                                frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                            }
                        }
                        //TAG 7 - tempo nao obrigatorio
                        else if (frm.Controls[i].Tag.ToString() == "7")
                        {
                            string hora = frm.Controls[i].Text.Replace(":", "");
                            if (!String.IsNullOrEmpty(hora.Trim()))
                            {
                                if (IsHour(frm.Controls[i].Text) == null)
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                        }
                    }
                }
            }
            return semErro;
        }

        public static bool ValidaTabPage(TabPage frm)
        {
            bool semErro = true;
            //Tag = 1 Campos Obrigatorios
            for (int i = 0; i < frm.Controls.Count; i++)
            {
                if (frm.Controls[i] is TextBox || frm.Controls[i] is ComboBox || frm.Controls[i] is MaskedTextBox || frm.Controls[i] is ListBox || frm.Controls[i] is DateTimePicker)
                {
                    if (frm.Controls[i].Tag != null)
                    {
                        if (frm.Controls[i].Tag.ToString() == "1")
                        {
                            if (frm.Controls[i] is ListBox)
                            {
                                if ((frm.Controls[i] as ListBox).Items.Count == 0)
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                            else
                            {
                                if (String.IsNullOrEmpty(frm.Controls[i].Text) || frm.Controls[i].Text.Trim() == "" || frm.Controls[i].Text == "  /  /")
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                        }
                        //TAG 2 - Campos data obrigatorios
                        else if (frm.Controls[i].Tag.ToString() == "2")
                        {
                            try
                            { DateTime d = Convert.ToDateTime(frm.Controls[i].Text); }
                            catch (Exception ex)
                            {
                                semErro = false;
                                frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                            }
                        }
                        //TAG 3 - Campos número obrigatorios
                        else if (frm.Controls[i].Tag.ToString() == "3")
                        {
                            try
                            {
                                Decimal d = Convert.ToDecimal(frm.Controls[i].Text);
                            }
                            catch (Exception ex)
                            {
                                semErro = false;
                                frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                            }
                        }
                        //TAG 4 - Campos número Não obrigatorios
                        else if (frm.Controls[i].Tag.ToString() == "4")
                        {
                            try
                            {
                                if (!String.IsNullOrEmpty(frm.Controls[i].Text))
                                {
                                    Decimal d = Convert.ToDecimal(frm.Controls[i].Text);
                                }
                            }
                            catch (Exception ex)
                            {
                                semErro = false;
                                frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                            }
                        }
                        //TAG 5 - CNPJ/CPF quando preenchidos
                        else if (frm.Controls[i].Tag.ToString() == "5")
                        {
                            string valor = frm.Controls[i].Text.Replace(".", "").Replace("-", "").Replace("/", "");
                            if (valor.Length == 11)
                            {
                                if (!ValidaCPF.IsCpf(valor))
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                            else
                            {
                                if (!ValidaCNPJ.IsCnpj(valor))
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                        }

                        //TAG 6 - tempo obrigatorio
                        else if (frm.Controls[i].Tag.ToString() == "6")
                        {
                            if (IsHour(frm.Controls[i].Text) == null)
                            {
                                semErro = false;
                                frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                            }
                        }
                        //TAG 7 - tempo nao obrigatorio
                        else if (frm.Controls[i].Tag.ToString() == "7")
                        {
                            string hora = frm.Controls[i].Text.Replace(":", "");
                            if (!String.IsNullOrEmpty(hora.Trim()))
                            {
                                if (IsHour(frm.Controls[i].Text) == null)
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                        }
                    }
                }
            }
            return semErro;
        }

        public static bool ValidaCampos(Form frm)
        {
            bool semErro = true;
            //limpa as marcações
            for (int i = 0; i < frm.Controls.Count; i++)
            {
                if (frm.Controls[i] is TextBox || frm.Controls[i] is ComboBox || frm.Controls[i] is MaskedTextBox)
                {
                    frm.Controls[i].BackColor = Color.White;
                }
            }


            //Tag = 1 Campos Obrigatorios
            for (int i = 0; i < frm.Controls.Count; i++)
            {
                if (frm.Controls[i] is TextBox || frm.Controls[i] is ComboBox || frm.Controls[i] is MaskedTextBox || frm.Controls[i] is ListBox || frm.Controls[i] is DateTimePicker)
                {
                    if (frm.Controls[i].Tag != null)
                    {
                        if (frm.Controls[i].Tag.ToString() == "1")
                        {
                            if (frm.Controls[i] is ListBox)
                            {
                                if ((frm.Controls[i] as ListBox).Items.Count == 0)
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                            else
                            {
                                if (String.IsNullOrEmpty(frm.Controls[i].Text) || frm.Controls[i].Text == "  /  /")
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                        }
                    }
                }

                //valida o tabcontrol
                if (frm.Controls[i] is TabControl)
                {
                    foreach (TabPage t in (frm.Controls[i] as TabControl).TabPages)
                    {
                        for (int j = 0; j < t.Controls.Count; j++)
                        {
                            if (t.Controls[j] is TextBox || t.Controls[j] is ComboBox || t.Controls[j] is MaskedTextBox || t.Controls[j] is ListBox)
                            {
                                if (t.Controls[j].Tag != null)
                                {
                                    if (t.Controls[j].Tag.ToString() == "1")
                                    {
                                        if (t.Controls[j] is ListBox)
                                        {
                                            if ((t.Controls[j] as ListBox).Items.Count == 0)
                                            {
                                                semErro = false;
                                                t.Controls[j].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                            }
                                        }
                                        else
                                        {
                                            if (String.IsNullOrEmpty(t.Controls[j].Text) || t.Controls[j].Text == "  /  /")
                                            {
                                                semErro = false;
                                                t.Controls[j].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }


            //Tag = 2 Campos de data obrigatorios
            for (int i = 0; i < frm.Controls.Count; i++)
            {
                if (frm.Controls[i] is MaskedTextBox)
                {
                    if (frm.Controls[i].Tag != null)
                    {
                        if (frm.Controls[i].Tag.ToString() == "2")
                        {
                            if (String.IsNullOrEmpty(frm.Controls[i].Text) || frm.Controls[i].Text == "  /  /")
                            {
                                semErro = false;
                                frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                            }
                            else
                            {
                                try
                                {
                                    DateTime dt = DateTime.Parse(frm.Controls[i].Text);
                                }
                                catch (Exception ex)
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                        }
                    }
                }
            }


            //Tag = 3 Campos de numero obrigatorios
            for (int i = 0; i < frm.Controls.Count; i++)
            {
                if (frm.Controls[i] is TextBox)
                {
                    if (frm.Controls[i].Tag != null)
                    {
                        if (frm.Controls[i].Tag.ToString() == "3")
                        {
                            if (String.IsNullOrEmpty(frm.Controls[i].Text))
                            {
                                semErro = false;
                                frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                            }
                            else
                            {
                                try
                                {
                                    if (frm.Controls[i].Text.Contains('.'))
                                    {
                                        semErro = false;
                                        frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                    }
                                    else
                                    {
                                        decimal num = Convert.ToDecimal(frm.Controls[i].Text);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                        }
                    }
                }

                if (frm.Controls[i] is TabControl)
                {
                    foreach (TabPage t in (frm.Controls[i] as TabControl).TabPages)
                    {
                        for (int j = 0; j < t.Controls.Count; j++)
                        {
                            if (t.Controls[j] is TextBox)
                            {
                                if (t.Controls[j].Tag != null)
                                {
                                    if (t.Controls[j].Tag.ToString() == "3")
                                    {
                                        if (String.IsNullOrEmpty(t.Controls[j].Text))
                                        {
                                            semErro = false;
                                            t.Controls[j].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                        }
                                        else
                                        {
                                            try
                                            {
                                                if (t.Controls[j].Text.Contains('.'))
                                                {
                                                    semErro = false;
                                                    t.Controls[j].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                                }
                                                else
                                                {
                                                    decimal num = Convert.ToDecimal(t.Controls[j].Text);
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                semErro = false;
                                                t.Controls[j].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }


            //Tag = 4 Campos de numero não obrigatorios
            for (int i = 0; i < frm.Controls.Count; i++)
            {
                if (frm.Controls[i] is TextBox)
                {
                    if (frm.Controls[i].Tag != null)
                    {
                        if (frm.Controls[i].Tag.ToString() == "4")
                        {
                            if (!String.IsNullOrEmpty(frm.Controls[i].Text))
                            {
                                try
                                {
                                    if (frm.Controls[i].Text.Contains('.'))
                                    {
                                        semErro = false;
                                        frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                    }
                                    else
                                    {
                                        decimal num = Convert.ToDecimal(frm.Controls[i].Text);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                        }
                    }
                }

                if (frm.Controls[i] is TabControl)
                {
                    foreach (TabPage t in (frm.Controls[i] as TabControl).TabPages)
                    {
                        for (int j = 0; j < t.Controls.Count; j++)
                        {
                            if (t.Controls[j] is TextBox)
                            {
                                if (t.Controls[j].Tag != null)
                                {
                                    if (t.Controls[j].Tag.ToString() == "4")
                                    {
                                        if (!String.IsNullOrEmpty(t.Controls[j].Text))
                                        {
                                            try
                                            {
                                                if (t.Controls[j].Text.Contains('.'))
                                                {
                                                    semErro = false;
                                                    t.Controls[j].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                                }
                                                else
                                                {
                                                    decimal num = Convert.ToDecimal(t.Controls[j].Text);
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                semErro = false;
                                                t.Controls[j].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //Tag = 5 CNPJ/CPF quando preenchido
            for (int i = 0; i < frm.Controls.Count; i++)
            {
                if (frm.Controls[i] is TextBox || frm.Controls[i] is MaskedTextBox)
                {
                    if (frm.Controls[i].Tag != null)
                    {
                        if (frm.Controls[i].Tag.ToString() == "5")
                        {
                            if (!String.IsNullOrEmpty(frm.Controls[i].Text))
                            {
                                try
                                {
                                    string doc = frm.Controls[i].Text.Replace(".", "").Replace("-", "").Replace("/", "");
                                    if (doc.Length == 11)
                                    {
                                        if (!ValidaCPF.IsCpf(doc))
                                        {
                                            semErro = false;
                                            frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                        }
                                    }
                                    else
                                    {
                                        if (!ValidaCNPJ.IsCnpj(doc))
                                        {
                                            semErro = false;
                                            frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    semErro = false;
                                    frm.Controls[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                                }
                            }
                        }
                    }
                }
            }

            return semErro;
        }


        public static DateTime? IsDateTime(string pData)
        {
            DateTime value;
            if (DateTime.TryParse(pData, out value))
            {
                return value;
            }
            return null;
        }

        public static TimeSpan? IsHour(string Valor)
        {
            TimeSpan t;
            var ta1 = Valor.Split(':');
            t = new TimeSpan(Convert.ToInt32(ta1[0]), Convert.ToInt32(ta1[1]), 0);
            return t;
        }
    }
}
