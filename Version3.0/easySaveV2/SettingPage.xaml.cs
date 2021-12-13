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

namespace easySaveV3
{
    /// <summary>
    /// Interaction logic for SettingPage.xaml
    /// </summary>
    public partial class SettingPage : Window
    {


        Dictionary dico = new Dictionary();


        public SettingPage()
        {
            InitializeComponent();
            ChangePageText(dico.SelectedLang());
        }


        private void FrButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            dico.DicoChangeLang("1");
            ChangePageText(1);
        }

        private void EnButton_Click(object sender, RoutedEventArgs e)
        {
            dico.DicoChangeLang("0");
            ChangePageText(0);
        }

        private void Setting_ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();           
        }
        void ChangePageText(int lang)
        {
            SettingLabel.Text = dico.pV2_Setting_1[lang];
            EnButton.Content = dico.langtot[0];
            FrButton.Content = dico.langtot[1];
            BlBoutton.Content = dico.pV2_Setting_2[lang];
            ExBoutton.Content = dico.pV2_Setting_3[lang];
            Setting_ReturnButton.Content = dico.pV2_0[lang];
        }


        private void Open_blacklist(object sender, RoutedEventArgs e)//Function that allows the button to open the file of blacklisted software
        {
            System.Diagnostics.Process.Start("notepad.exe", @"Blacklist.json");
        }

        private void ExBoutton_Click(object sender, RoutedEventArgs e)
        {
            ExtensionPage extensionPage = new ExtensionPage();
            this.Close();
            extensionPage.Show();
        }
    }
}
