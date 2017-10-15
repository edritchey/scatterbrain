using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scatterbrain
{
    public partial class Form1 : Form
    {
        public static string sysDir = Convert.ToString(Environment.SystemDirectory);
        public static string system = Convert.ToString(Environment.SpecialFolder.System);
        public static string startup = Convert.ToString(Environment.SpecialFolder.Startup);
        public static string appStartupPath = Application.StartupPath;
        public static string myDocuments = Convert.ToString(Environment.SpecialFolder.MyDocuments);
        public static string myDesktop = Convert.ToString(Environment.SpecialFolder.Desktop);
        public static string progFiles64 = Convert.ToString(Environment.SpecialFolder.ProgramFiles);
        public static string progFiles86 = Convert.ToString(Environment.SpecialFolder.ProgramFilesX86);
        public static string currentDir = Convert.ToString(Environment.CurrentDirectory);
        public static string sysRoot = Directory.GetDirectoryRoot(system);
        public static string currentDirRoot = Directory.GetDirectoryRoot(currentDir);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sourceDll = currentDir + "\\AutoHotkey.dll";
            string destDll = sysDir + "\\AutoHotkey.dll";

            

            if (!File.Exists(destDll))
            {
                

                MessageBox.Show("the dll is not in the system directory");
                try
                {
                    Assembly assembly = Assembly.LoadFrom(sourceDll);
                    AppDomain.CurrentDomain.Load(assembly.GetName());
                    Type t = assembly.GetType("typeName");
                    File.Copy(sourceDll, destDll);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }





            //if (File.Exists(sysDir + "\\AutoHotKey.dll"))
            //{
            //    MessageBox.Show(sysDir + "\\AutoHotKey.dll");
            //}




            string[] files = Directory.GetFileSystemEntries(currentDir);

            foreach (string d in files)
            {
                listBox1.Items.Add(d);
            }
        }
    }
}
