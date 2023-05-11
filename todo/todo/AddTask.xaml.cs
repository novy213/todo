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
using System.Windows.Shapes;

namespace todo
{
    /// <summary>
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        public AddTask()
        {
            InitializeComponent();
        }

        private void Add_click(object sender, RoutedEventArgs e)
        {
            if(Description.Text == "")
            {
                MessageBox.Show("Description cannot be empty", "Error");
            }
            else DialogResult = true;
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
