using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
namespace vpnbusters
{
    public class VpnBusters
    {
        public shellcmd cmd { get; set; }

        public VpnBusters()
        {
            cmd = new shellcmd();

        }
        private static string pathnamevpn = "./vpn.txt";
        public void Fix()
        {
            new registro(this.cmd).ConsertaRegistro();
            int InstallPath = (int)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\PolicyAgent", "AssumeUDPEncapsulationContextOnSendRule", null);
            cmd.execute("ipconfig /flushdns");
            cmd.execute("rasdial /DISCONNECT");
            if (!File.Exists(pathnamevpn))
            {
                File.Create(pathnamevpn);
            }
            string vpn = File.ReadAllText(pathnamevpn);
            if (string.IsNullOrEmpty(vpn))
            {
                vpn = Interaction.InputBox("Informe o nome da vpn", "Procurar por vpn");
                File.WriteAllText(pathnamevpn, vpn);
            }
            cmd.execute("rasdial \""+vpn+"\"");
        }
    }
}
