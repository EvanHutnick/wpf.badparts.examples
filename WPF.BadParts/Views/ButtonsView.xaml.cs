using System;
using System.Linq;
using System.Windows.Controls;

namespace WPF.BadParts.Views
{
    /// <summary>
    /// Interaction logic for ButtonsView.xaml
    /// </summary>
    public partial class ButtonsView : UserControl
    {
        public ButtonsView()
        {
            InitializeComponent();

            StartButtons();
        }

        void StartButtons()
        {
            int rows = 10;
            int cols = 10;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button button = new Button();
                    button.Content = "Button " + i.ToString() + "/" + j.ToString();

                    Grid.SetColumn(button, j);
                    Grid.SetRow(button, i);

                    LayoutRoot.Children.Add(button);
                }
            }
        }
    }
}
