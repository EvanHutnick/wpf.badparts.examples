using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Threading;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Gauge;

namespace WPF.BadParts.Views
{
    /// <summary>
    /// Interaction logic for GaugesPlusView.xaml
    /// </summary>
    public partial class GaugesPlusView : UserControl
    {
        public DispatcherTimer timer;

        private int rowMax = 10;
        private int colMax = 10;

        private int currentRow = 0;
        private int currentCol = 0;

        public GaugesPlusView()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            MakeGauge();
        }

        void MakeGauge()
        {
            RadRadialGauge g = new RadRadialGauge();

            // I'm different!  If we don't have to calculate size on every render pass, things go quicker!  
            g.Width = 80;
            g.Height = 80;

            RadialScale scale = new RadialScale();
            scale.Min = 0;
            scale.Max = 1;
            scale.Indicators.Add(new Needle() { Value = currentRow * currentCol });
            g.Items.Add(scale);

            Grid.SetColumn(g, currentCol);
            Grid.SetRow(g, currentRow);

            LayoutRoot.Children.Add(g);

            currentCol++;

            if (currentCol == 10)
            {
                currentRow++;

                if (currentRow == 10)
                {
                    timer.Stop();
                    return;
                }

                currentCol = 0;
            }
        }
    }
}
