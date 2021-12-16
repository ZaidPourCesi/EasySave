using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace easySaveV3
{
    /// <summary>
    /// Interaction logic for LoadPage.xaml
    /// </summary>
    public partial class LoadPage : Window
    {

        Dictionary dico = new Dictionary();
        Model model = new Model();


        //delegate void delegateLoadSave(string delgString);

        public LoadPage()
        {
            InitializeComponent();
            ChangePageText(dico.SelectedLang());
            ListBoxListing();
        }

        private void Load_ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


        private void RefreshListButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxListing();
        }

        private void ListBoxListing()
        {

            SaveList.Items.Clear();

            List<string> namesOfBackupSave = model.ListBackup();
            foreach (string nameOBS in namesOfBackupSave)
            {
                SaveList.Items.Add(nameOBS);
            }
        }

        private void SaveListButton_Click(object sender, RoutedEventArgs e)
        {
            ProgressBars progressBars = new ProgressBars();
            progressBars.Show();
            model.LoadSave(SaveList.SelectedItem.ToString());

               
           
        }

        void ChangePageText(int lang)
        {
            LoadLabel.Text = dico.pV2_Load_1[lang];
            RefreshListButton.Content = dico.pV2_Load_2[lang];
            SaveListButton.Content = dico.pV2_Load_3[lang];
            Load_ReturnButton.Content = dico.pV2_0[lang];
        }

        private void SaveList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
