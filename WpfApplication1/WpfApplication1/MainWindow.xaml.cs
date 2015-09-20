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
                return item.Properties["CurrentClockSpeed"].Value.ToString();

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
     
              private static void GetTemp(string s)
        {
            ManagementObjectSearcher searcher =
    new ManagementObjectSearcher("root\\WMI",
                                 "SELECT * FROM MSAcpi_ThermalZoneTemperature");

            ManagementObjectCollection.ManagementObjectEnumerator enumerator =
                searcher.Get().GetEnumerator();

            while (enumerator.MoveNext())
            {
                ManagementBaseObject tempObject = enumerator.Current;
                Console.WriteLine(tempObject["CurrentTemperature"].ToString());

            }
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

        

     


    }

}
