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


        private void LightButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DarkButton_Click(object sender, RoutedEventArgs e)
        {
            /*Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x1B, 0x1B, 0x1B));
            Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x55, 0x77, 0xD3));
            BlBoutton.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x80, 0x80, 0x80));
            BlBoutton.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x71, 0x71, 0xC5));

            foreach (var child in ExtensionPage.Children.OfType<System.Windows.Controls.Label>())
            {
            }*/
            
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
            BlBoutton.Content = dico.pV2_Setting_2[lang];
            ExBoutton.Content = dico.pV2_Setting_3[lang];
            Setting_ReturnButton.Content = dico.pV2_0[lang];
            CryptBoutton.Content = dico.pV2_Setting_4[lang];
            DarkButton.Content = dico.pV2_Setting_5[0];
            LightButton.Content = dico.pV2_Setting_6[1];
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

        private void CryptBoutton_click(object sender, RoutedEventArgs e)
        {
            CryptoSoftwarePage cryptoSoftwarePage = new CryptoSoftwarePage();
            this.Close();
            cryptoSoftwarePage.Show();
        }

        private void LangBoutton_click(object sender, RoutedEventArgs e)
        {
            LanguagePage languagePage = new LanguagePage();
            this.Close();
            languagePage.Show();
        }
    }
}
