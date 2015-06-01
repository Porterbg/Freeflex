using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Management.Instrumentation;
using System.Collections.Specialized;
using System.Threading;
using System.Windows.Forms;

namespace waiolib
{
    public class System
    {
        /// <summary>
        /// Will retrieve the chosen information from the specified WMI class.
        /// </summary>
        /// <param name="WMIClass">The WMI class to access.</param>
        /// <param name="instance">The information to pull from the Class.</param>
        /// <returns></returns>
        public string getSystemInfo(string WMIClass, string instance)
        {
            
            string info = "";

            ManagementClass systemManagementClass = new ManagementClass(WMIClass);
            ManagementObjectCollection systemManagementClassCollection = systemManagementClass.GetInstances();

            foreach (ManagementObject obj in systemManagementClassCollection)
            {
                try
                {
                    info = (string)obj[instance];
                }
                catch(InstanceNotFoundException o)
                {
                    MessageBox.Show("Error: Instance '" + instance + "' not found in class '" + WMIClass + "'. \n\n Code:" + o);
                    return "Error InstanceNotFound";
                }
            }

            return info;
        }

        /// <summary>
        /// Will retrieve the name of the Computer that the program is running on, by accessing a pre-defined WMI class.
        /// </summary>
        /// <returns></returns>
        public string getComputerName()
        {
            string name = "";

            ManagementClass computerName = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection computerNameClassCollection = computerName.GetInstances();

            foreach (ManagementObject obj in computerNameClassCollection)
            {
                name = (string)obj["Name"];
            }

            return name;
        }

    }
}
