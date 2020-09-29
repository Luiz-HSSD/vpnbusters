using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using Microsoft.VisualBasic;
using System.Windows.Forms;
namespace vpnbusters
{
    class Program
    {
        static void Main(string[] args)
        {
             new VpnBusters().Fix();
            MessageBox.Show("arrumado", "Vpn Busters");

        }
    }
}
