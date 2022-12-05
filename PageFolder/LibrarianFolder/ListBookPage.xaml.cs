using BiblioBalobanovOros.ClassFolder;
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

namespace BiblioBalobanovOros.PageFolder.LibrarianFolder
{
    /// <summary>
    /// Логика взаимодействия для ListBookPage.xaml
    /// </summary>
    public partial class ListBookPage : Page
    {
        DGClass dGClass;
        public ListBookPage()
        {
            InitializeComponent();
            dGClass = new DGClass(ListBookDG);
        }

       

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDG("SELECT * From dbo.[View]");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDG("SELECT * From dbo.[View] " +
                $"WHERE IdBook LIKE '%{SearchTB.Text}%' " +
                $"OR BookName LIKE '%{SearchTB.Text}%' " +
                $"OR FIOAuthor LIKE '%{SearchTB.Text}%' ");
            
        }
    }
}
