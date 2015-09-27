using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;
using System.Diagnostics;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
       
        }

    

        private static string GetProcessorID()
        {

            ManagementClass mgt = new ManagementClass("Win32_Processor");
            ManagementObjectCollection procs = mgt.GetInstances();
            foreach (ManagementObject item in procs)
                return item.Properties["Name"].Value.ToString();

            return "Unknown";
        }


        private static string GetCPUClockSpeed()
        {

            ManagementClass mgt = new ManagementClass("Win32_Processor");
            ManagementObjectCollection procs = mgt.GetInstances();
            foreach (ManagementObject item in procs)
                return item.Properties["MaxClockSpeed"].Value.ToString()+ " Mhz";


            return "Unknown";
        }


        private static string GetCPUSocket()
        {

            ManagementClass mgt = new ManagementClass("Win32_Processor");
            ManagementObjectCollection procs = mgt.GetInstances();
            foreach (ManagementObject item in procs)
                return item.Properties["SocketDesignation"].Value.ToString();


            return "Unknown";
        }




        private static string GetCPUTotalCores()
        {

            ManagementClass mgt = new ManagementClass("Win32_Processor");
            ManagementObjectCollection procs = mgt.GetInstances();
            foreach (ManagementObject item in procs)
                return item.Properties["NumberOfCores"].Value.ToString();


            return "Unknown";
        }


        private static string GetGPUName()
        {
            ManagementClass mgt = new ManagementClass("Win32_VideoController");
            ManagementObjectCollection procs = mgt.GetInstances();
            foreach (ManagementObject item in procs)
                return item.Properties["Name"].Value.ToString();

            return "Unknown";
        }

        private static string GetGPUDriver()
        {
            ManagementClass mgt = new ManagementClass("Win32_VideoController");
            ManagementObjectCollection procs = mgt.GetInstances();
            foreach (ManagementObject item in procs)
                return item.Properties["DriverVersion"].Value.ToString();
            
            return "Unknown";
        }



        private static string GetGPURefreshRate()
        {
            ManagementClass mgt = new ManagementClass("Win32_VideoController");
            ManagementObjectCollection procs = mgt.GetInstances();
            foreach (ManagementObject item in procs)
                return item.Properties["MaxRefreshRate"].Value.ToString() + " HZ";
           
            return "Unknown";
        }


     

        private static string GetHardDriveName()
        {
            ManagementClass mgt = new ManagementClass("Win32_BaseBoard");
            ManagementObjectCollection procs = mgt.GetInstances();
            foreach (ManagementObject item in procs)
                return item.Properties["Product"].Value.ToString();

            return "Unknown";
        }

        private static string GetHardDriveHotSwap()
        {
            ManagementClass mgt = new ManagementClass("Win32_BaseBoard");
            ManagementObjectCollection procs = mgt.GetInstances();
            foreach (ManagementObject item in procs)
                return item.Properties["HotSwappable"].Value.ToString();

            return "Unknown";
        }


        private static string GetRamSize()
        {
            ManagementClass mgt = new ManagementClass("Win32_PhysicalMemory");
            ManagementObjectCollection procs = mgt.GetInstances();
            foreach (ManagementObject obj in procs)
            {
                long MemorySize = 0;
                long mCap = 0;
                mCap = Convert.ToInt64(obj["Capacity"]);
                MemorySize += mCap;
                MemorySize = (MemorySize / 1024) / 1024;
                return MemorySize.ToString() + "MB";


            }

            return "Unknown";
        }




        public static string GetRamSlots()
        {

            int MemSlots = 0;
            ManagementScope oMs = new ManagementScope();
            ObjectQuery oQuery2 = new ObjectQuery("SELECT MemoryDevices FROM Win32_PhysicalMemoryArray");
            ManagementObjectSearcher oSearcher2 = new ManagementObjectSearcher(oMs, oQuery2);
            ManagementObjectCollection oCollection2 = oSearcher2.Get();
            foreach (ManagementObject obj in oCollection2)
            {
                MemSlots = Convert.ToInt32(obj["MemoryDevices"]);

            }
            return MemSlots.ToString();
        }



        public static string GetCPUBit()
        {
            ManagementClass mgt = new ManagementClass("Win32_Processor");
            ManagementObjectCollection procs = mgt.GetInstances();
            foreach (ManagementObject obj in procs)
            {
                long CPUBit = 0;
                long mCap = 0;
                mCap = Convert.ToInt64(obj["AddressWidth"]);
                CPUBit += mCap;

                return CPUBit.ToString() + " bit";


            }

            return "Unknown";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
           

            // ... Get control that raised this event.
            var textBox = sender as TextBox;
            // ... Change Window Title.
            this.Title = textBox.Text = (GetProcessorID());

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            this.Title = textBox.Text = (GetGPUName());
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            this.Title = textBox.Text = (GetCPUClockSpeed());
        }

        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            this.Title = textBox.Text = (GetCPUSocket());
        }



        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            this.Title = textBox.Text = (GetCPUTotalCores());
        }

        private void TextBox_TextChanged_5(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            this.Title = textBox.Text = (GetGPUDriver());
        }


        public void TextBox_TextChanged_6(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            this.Title = textBox.Text = (GetGPURefreshRate());
        }

        private void TextBox_TextChanged_7(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            this.Title = textBox.Text = (GetHardDriveHotSwap());
        }

        private void TextBox_TextChanged_8(object sender, TextChangedEventArgs e)
        {

            var textBox = sender as TextBox;

            this.Title = textBox.Text = (GetHardDriveName());
        }

        private void TextBox_TextChanged_9(object sender, TextChangedEventArgs e)
        {

            var textBox = sender as TextBox;

            this.Title = textBox.Text = (GetRamSize());
        }

        private void TextBox_TextChanged_10(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            this.Title = textBox.Text = (GetRamSlots());
        }

        private void TextBox_TextChanged_11(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            this.Title = textBox.Text = (GetCPUBit());
        }

     


    }

}
