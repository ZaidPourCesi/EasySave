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

        ConfigHelper ConfH = new ConfigHelper();
        Dictionary dico = new Dictionary();


        public SettingPage()
        {
            InitializeComponent();
            ChangePageText(dico.SelectedLang());
            
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
            LangBoutton.Content = dico.pV2_Setting_7[lang];
        }


        private void Open_blacklist(object sender, RoutedEventArgs e)//Function that allows the button to open the file of blacklisted software
        {
            //System.Diagnostics.Process.Start("notepad.exe", @"Blacklist.json");
            BlackListePage blackListPage = new BlackListePage();
            this.Close();
            blackListPage.Show();
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

        private void Window_Activated(object sender, EventArgs e)
        {
            txtFileSize.Text = ConfH.GetParticularKeyValue("MaxFileSizeLimit");
        }

        private void btnSaveLimit_Click(object sender, RoutedEventArgs e)
        {
            int limit;
            if (Int32.TryParse(txtFileSize.Text, out limit))
            {
                ConfH.AddUpdateAppSettings("MaxFileSizeLimit", limit.ToString());
                MessageBox.Show("Saved File Size Limit.");
            }
            else
            {
                MessageBox.Show("Value is not valid.");
            }
        }
    }
}
