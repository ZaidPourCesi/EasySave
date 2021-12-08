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

namespace easySaveV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary dico = new Dictionary();

        SavePage savePage = new SavePage();
        LoadPage loadPage = new LoadPage();
        SettingPage settingPage = new SettingPage();

        

        public MainWindow()
        {
            InitializeComponent();
            ChangePageText(dico.SelectedLang());
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            savePage.Show();
            this.Close();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            
            loadPage.Show();
            this.Close();
        }

        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            
            settingPage.Show();
            this.Close();
        }

        private void mainbouttontest_Click(object sender, RoutedEventArgs e)
        {
           
        }



        void ChangePageText(int lang)
        {
            TitleMain.Text = dico.pV2_Main_1[lang];
            SaveButton.Content = dico.pV2_Main_2[lang];
            LoadButton.Content = dico.pV2_Main_3[lang];
            SettingButton.Content = dico.pV2_Main_4[lang];
        }

    }
}
