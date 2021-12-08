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
using System.Windows.Shapes;

namespace easySaveV2
{
    /// <summary>
    /// Interaction logic for LoadPage.xaml
    /// </summary>
    public partial class LoadPage : Window
    {

        Dictionary dico = new Dictionary();

        public LoadPage()
        {
            InitializeComponent();
            ChangePageText(dico.SelectedLang());
        }

        private void Load_ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        void ChangePageText(int lang)
        {
            LoadLabel.Text = dico.pV2_Load_1[lang];
        }
    }
}
