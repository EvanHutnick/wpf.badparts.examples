using System;
using System.Linq;
using System.Windows;

namespace WPF.BadParts
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

        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {
            ContentBorder.Child = new Views.ButtonsView();
        }

        private void GaugeTest_Click(object sender, RoutedEventArgs e)
        {
            ContentBorder.Child = new Views.GaugesView();
        }

        private void GaugePlusTest_Click(object sender, RoutedEventArgs e)
        {
            ContentBorder.Child = new Views.GaugesPlusView();
        }

        private void SlowScrolling_Click(object sender, RoutedEventArgs e)
        {
            ContentBorder.Child = new Views.SlowGrids();
        }

        private void SyncScrolling_Click(object sender, RoutedEventArgs e)
        {
            ContentBorder.Child = new Views.SyncGrids();
        }
    }
}
