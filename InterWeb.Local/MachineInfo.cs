using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace InterWeb.Local
{
    class MachineInfo
    {

        public static void GetMachineData()
        {
            string cpuInfo = string.Empty;
            try
            {
                ManagementClass mc = new ManagementClass("win32_processor");
                ManagementObjectCollection moc = mc.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            catch
            {
                cpuInfo = "0000000000000000";
            }

            string volumeSerial = string.Empty;
            try
            {
                string drive = "C";
                ManagementObject dsk = new ManagementObject(
                    @"win32_logicaldisk.deviceid=""" + drive + @":""");
                dsk.Get();
                volumeSerial = dsk["VolumeSerialNumber"].ToString();
            }
            catch
            {
                volumeSerial = "00000000";
            }

            string sHostName = string.Empty;
            string macAnddresses = string.Empty;
            string localIP = string.Empty;
            try
            {
                sHostName = Dns.GetHostName();
                IPHostEntry ipE = Dns.GetHostByName(sHostName);
                IPAddress[] IpA = ipE.AddressList;

                localIP = IpA[0].ToString();

                try
                {
                    foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                    {
                        if (nic.NetworkInterfaceType != NetworkInterfaceType.Ethernet) continue;
                        if (nic.OperationalStatus == OperationalStatus.Up)
                        {
                            macAnddresses += nic.GetPhysicalAddress().ToString();
                            break;
                        }
                    }
                }
                catch
                {
                    macAnddresses = "00-00-00-00-00-00";
                    localIP = "0.0.0.0";
                }
            }
            catch
            {
                sHostName = "ERRO";
                macAnddresses = "00-00-00-00-00-00";
                localIP = "0.0.0.0";
            }

            ConfigurationManager.AppSettings["Machine.CPUID"] = cpuInfo;
            ConfigurationManager.AppSettings["Machine.DiskID"] = volumeSerial;
            ConfigurationManager.AppSettings["Machine.MACID"] = macAnddresses;
            ConfigurationManager.AppSettings["Machine.IP"] = localIP;
            ConfigurationManager.AppSettings["Machine.HostName"] = sHostName;
        }

    }
}
