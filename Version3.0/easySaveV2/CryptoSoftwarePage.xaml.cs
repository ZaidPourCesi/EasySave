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
using Microsoft.Win32;

namespace easySaveV3
{
    /// <summary>
    /// Interaction logic for CryptoSoftwarePage.xaml
    /// </summary>
    public partial class CryptoSoftwarePage : Window
    {

        Dictionary dico = new Dictionary();
        ConfigHelper ConfH = new ConfigHelper();

        public CryptoSoftwarePage()
        {
            InitializeComponent();
            ChangePageText(dico.SelectedLang());
            ListBoxListing();
        }


        private void Crypto_ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            SettingPage settingPage = new SettingPage();
            this.Close();
            settingPage.Show();
        }

        private void CryptoSoftwareListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int found = 0;

            found = CryptoSoftwareListBox.SelectedItem.ToString().IndexOf(" : ");
            KeyTextBox.Text = CryptoSoftwareListBox.SelectedItem.ToString().Substring(0, found);
            ValueTextBox.Text = CryptoSoftwareListBox.SelectedItem.ToString().Substring(found + 3);
        }

        private void ListBoxListing()
        {
            CryptoSoftwareListBox.Items.Clear();

            List<string> namesOfBackupSave = ConfH.UpdateListSetting("CryptoSoftSettings");
            foreach (string nameOBS in namesOfBackupSave)
            {
                CryptoSoftwareListBox.Items.Add(nameOBS);
            }

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (KeyTextBox.Text == "")
            {
                MessageBox.Show(dico.pV3_Extension_alert_1[dico.SelectedLang()]);
            }
            else if (ValueTextBox.Text == "")
            {
                MessageBox.Show(dico.pV3_Extension_alert_2[dico.SelectedLang()]);
            }
            else
            {
                if (ConfH.AddToSettings(KeyTextBox.Text, ValueTextBox.Text, "CryptoSoftSettings") == false)
                {
                    MessageBox.Show("pas ok");
                }
                else
                {
                    MessageBox.Show("ok");
                    RefreshPage();
                }


            }
        }

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            if (KeyTextBox.Text == "")
            {
                MessageBox.Show(dico.pV3_Extension_alert_1[dico.SelectedLang()]);
            }
            else if (ValueTextBox.Text == "")
            {
                MessageBox.Show(dico.pV3_Extension_alert_2[dico.SelectedLang()]);
            }
            else
            {


                ConfH.RemoveExtensionSettings(KeyTextBox.Text, "CryptoSoftSettings");
                RefreshPage();
            }
        }

        private void RefreshPage()
        {
            this.Close();
            CryptoSoftwarePage cryptoSoftwarePage = new CryptoSoftwarePage();
            cryptoSoftwarePage.Show();
        }

        void ChangePageText(int lang)
        {
            CryptoSoftwareLabel.Text = dico.pV3_CryptoPage_1[lang];
            Crypto_ReturnButton.Content = dico.pV2_0[lang];

            pathTextBox.Text = ConfH.GetParticularKeyValue("cryptoSoftWarePath");
        }

        private void pathButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.ShowDialog();
            pathTextBox.Text = opd.FileName;
            ConfH.AddUpdateAppSettings("cryptoSoftWarePath", opd.FileName);      
        }
    }
}
