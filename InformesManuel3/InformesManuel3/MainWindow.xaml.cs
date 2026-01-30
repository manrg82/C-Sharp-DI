using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
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

namespace InformesManuel3
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable table1;
        private static readonly Random r = new Random();
        private static readonly object SyncLock = new object();

        public MainWindow()
        {
            InitializeComponent();
            table1=new DataTable("Datatable1");
            table1.Columns.Add("Name");
            table1.Columns.Add("Age");
            table1.Columns.Add("Address");
            table1.Columns.Add("Phone");
            for(int i=1;i<=100;i++)
            {
                Random rnd=new Random(i);
                DataRow row=table1.NewRow();
                row["Name"]="Rosa";
                row["Age"]=rnd.Next(10,100).ToString();
                row["Address"] = "Dirección";
                row["Phone"] = "666666666";
                table1.Rows.Add(row);
            }
            CrystalReport1 report=new CrystalReport1();
            report.Database.Tables["Datatable1"].SetDataSource(table1);
            visor.ViewerCore.ReportSource=report;
        }
    }
}
