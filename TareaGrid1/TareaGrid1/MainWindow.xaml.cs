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

namespace TareaGrid1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            fillGrid();
        }
        public void fillGrid()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Label txt = new Label();
                    txt.Content = j+"|"+i;
                    txt.HorizontalAlignment = HorizontalAlignment.Stretch;
                    txt.VerticalAlignment = VerticalAlignment.Stretch;
                    Grid.SetRow(txt, i);
                    Grid.SetColumn(txt, j);
                    GridTable.Children.Add(txt);
                    if (j % 2 == 0&& i%2==0|| j % 2 != 0 && i%2!=0)
                    {
                        txt.Background = Brushes.Red;
                    }
                }
            }
        }
    }
}