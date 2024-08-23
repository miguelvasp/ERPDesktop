using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ConfiguracaoEMailModelView
    {
        public string EMailUserName { get; set; }
        public string EMailPassword { get; set; }
        public string EMailSMTP { get; set; }
        public string EMailPort { get; set; }
        public bool EMailSSL { get; set; }
    }
}
