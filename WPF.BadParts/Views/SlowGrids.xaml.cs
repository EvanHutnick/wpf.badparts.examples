using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using WPF.BadParts.CustomControls;

namespace WPF.BadParts.Views
{
    /// <summary>
    /// Interaction logic for SlowGrids.xaml
    /// </summary>
    public partial class SlowGrids : UserControl, INotifyPropertyChanged
    {
        private int scrollValueChanges;
        public int ScrollValueChanges
        {
            get { return scrollValueChanges; }
            set
            {
                if (scrollValueChanges != value)
                {
                    scrollValueChanges = value;
                    OnPropertyChanged("ScrollValueChanges");
                }
            }
        }

        private int visualTreeLookups;
        public int VisualTreeLookups
        {
            get { return visualTreeLookups; }
            set
            {
                if (visualTreeLookups != value)
                {
                    visualTreeLookups = value;
                    OnPropertyChanged("VisualTreeLookups");
                }
            }
        }

        public SlowGrids()
        {
            this.DataContext = this;

            InitializeComponent();

            scrollValueChanges = 0;
            visualTreeLookups = 0;
        }

        private void LoadGridButton_Click(object sender, RoutedEventArgs e)
        {
            GridStackPanel.Children.Add(new SelfContainedGrid());
        }

        private void GroupScroller_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ScrollValueChanges++;
            scrollGrids(e.NewValue);
        }

        private void scrollGrids(double scrollTo)
        {
            // Visual Tree Lookup!
            var radGrids = GridStackPanel.ChildrenOfType<RadGridView>();
            VisualTreeLookups++;
            double tempMax = 0.0d;

            foreach (RadGridView rgv in radGrids)
            {
                // Visual Tree Lookup!
                var scrollViewer = rgv.ChildrenOfType<GridViewScrollViewer>().FirstOrDefault();
                VisualTreeLookups++;

                if (scrollViewer != null) // control is fully built if we pass null check
                {
                    // Visual Tree Lookup!
                    ScrollBar sb = scrollViewer.ChildrenOfType<ScrollBar>().FirstOrDefault(x => x.Orientation == Orientation.Vertical);
                    VisualTreeLookups++;

                    // making sure this one hasn't been added already by checking the important part, whether vertical scroller is still visible
                    if (sb != null)
                    {
                        if (sb.Maximum > tempMax)
                        {
                            tempMax = sb.Maximum;
                        }

                        sb.Visibility = Visibility.Collapsed;
                    }

                    scrollViewer.ScrollToVerticalOffset(getModValue(scrollTo, tempMax));
                }
            }
        }

        private double getModValue(double newVal, double max)
        {
            return (newVal / 100) * max;
        }

        #region INPC

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion
    }
}
