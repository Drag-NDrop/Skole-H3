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
using BaggageSortering.Classes;

namespace Lufthavns_tråde
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Check_inConveyorBelt check_InConveyorBelt = new Check_inConveyorBelt(1, "Copenhagen", true, "ConveyorBelt",100000);
            Skranke skranke = new Skranke(1, "Copenhagen", check_InConveyorBelt, 0, 10, new Random());

            skranke.StartProduce();


        }
    }
}
