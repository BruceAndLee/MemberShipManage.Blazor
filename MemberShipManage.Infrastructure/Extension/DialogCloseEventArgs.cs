using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Infrastructure.Extension
{
    public class DialogCloseEventArgs : EventArgs
    {
        public bool DialogResult { get; set; }

        public string ReturnMessage { get; set; }
    }
}
