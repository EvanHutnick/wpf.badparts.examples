using System;
using System.Linq;
using System.Windows.Controls;

namespace WPF.BadParts.CustomControls
{
    /// <summary>
    /// Interaction logic for SelfContainedGrid.xaml
    /// </summary>
    public partial class SelfContainedGrid : UserControl
    {
        public SelfContainedGrid()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            PeopleGrid.ItemsSource = Telerik.UI.Net.DemoLibrary.Generators.LargeObjectGenerator.GetBigObjects(200);
        }
    }
}
