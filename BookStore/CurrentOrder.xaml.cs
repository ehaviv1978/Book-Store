using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DLL;
using Server;

namespace GUI
{
    /// <summary>
    /// Interaction logic for CurrentOrder.xaml
    /// </summary>
    public partial class CurrentOrder : Page
    {
        public CurrentOrder()
        {
            InitializeComponent();
            listViewItems.ItemsSource = DB.DBCurentOrder;
        }
    }
}
