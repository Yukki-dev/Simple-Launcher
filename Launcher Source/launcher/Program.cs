using Launcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace launcher
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MainValues varPath = new MainValues();          // пути
            AppDomain.CurrentDomain.AppendPrivatePath(varPath.Launcherfolder + @"SevenZipSharp.dll");
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve); // попытка вшить длл-ку в лаунчер

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            MainValues varPath = new MainValues();          // пути
            //This handler is called only when the common language runtime tries to bind to the assembly and fails.

            //Retrieve the list of referenced assemblies in an array of AssemblyName.
            Assembly myAssembly, objExecutingAssemblies;

            //string strTempAssmbPath = Environment.CurrentDirectory + "\\launcher\\SevenZipSharp.dll";
            string strTempAssmbPath = null;

            objExecutingAssemblies = Assembly.GetExecutingAssembly();
            AssemblyName[] arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies();

            //Loop through the array of referenced assembly names.
            foreach (AssemblyName strAssmbName in arrReferencedAssmbNames)
            {
                //Check for the assembly names that have raised the "AssemblyResolve" event.
                if (strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(",")) == args.Name.Substring(0, args.Name.IndexOf(",")))
                {
                    //Build the path of the assembly from where it has to be loaded.				
                    strTempAssmbPath = varPath.Launcherfolder + @"SevenZipSharp.dll";
                    break;
                }

            }
            //Load the assembly from the specified path. 
            //MessageBox.Show(strTempAssmbPath);		
            myAssembly = Assembly.LoadFrom(strTempAssmbPath);

            //Return the loaded assembly.
            return myAssembly;
        }
    }
}
