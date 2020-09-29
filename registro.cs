using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace vpnbusters
{
    public class registro
    {
        public shellcmd cmd { get; set; }
        public registro(shellcmd Cmd)
        {
            cmd = Cmd;
        }
        public void setaRegistro()
        {
            cmd.execute("reg query HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\services\\PolicyAgent /v AssumeUDPEncapsulationContextOnSendRule");
            cmd.execute("shutdown /r /t 0");
        }
        public void ConsertaRegistro()
        {
            var reg = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\PolicyAgent", "AssumeUDPEncapsulationContextOnSendRule", null);
            if (reg != null)
            {
                if (reg.GetType() == typeof(int))
                {
                    if (((int)reg) != 2)
                    {
                        setaRegistro();
                    }
                }
                else
                {
                    setaRegistro();
                }
            }
            else
            {
                setaRegistro();
            }
        }
    }
}
