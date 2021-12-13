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
    /// Interaction logic for ExtensionPage.xaml
    /// </summary>
    public partial class ExtensionPage : Window
    {

        Dictionary dico = new Dictionary();
        Model model = new Model();
        ConfigHelper ConfH = new ConfigHelper();

        public ExtensionPage()
        {
            InitializeComponent();
            ChangePageText(dico.SelectedLang());
            ListBoxListing();
        }

        private void addExtPrio_Click(object sender, RoutedEventArgs e)
        {
            if (KeyExtPrio.Text == "")
            {
                MessageBox.Show(dico.pV3_Extension_alert_1[dico.SelectedLang()]);
            }
            else if (ValueExtPrio.Text == "")
            {
                MessageBox.Show(dico.pV3_Extension_alert_2[dico.SelectedLang()]);
            }
            else
            {
                if (ConfH.AddExtension(KeyExtPrio.Text, ValueExtPrio.Text, 0) == false)
                {
                    MessageBox.Show("pas ok");
                }
                else
                {
                    MessageBox.Show("ok");
                    ListBoxListing();
                }
                
                
            }
        }

        private void SuprExtPrio_Click(object sender, RoutedEventArgs e)
        {
            if (KeyExtPrio.Text == "")
            {
                MessageBox.Show(dico.pV3_Extension_alert_1[dico.SelectedLang()]);
            }
            else if (ValueExtPrio.Text == "")
            {
                MessageBox.Show(dico.pV3_Extension_alert_2[dico.SelectedLang()]);
            }
            else
            {
                
                ConfH.RemoveExtension(KeyExtPrio.Text,0);
                RefreshPage();
            }
        }

        private void AddExtBan_Click(object sender, RoutedEventArgs e)
        {
            if (KeyExtBan.Text == "")
            {
                MessageBox.Show(dico.pV3_Extension_alert_1[dico.SelectedLang()]);
            }
            else if (ValueExtBan.Text == "")
            {
                MessageBox.Show(dico.pV3_Extension_alert_2[dico.SelectedLang()]);
            }
            else
            {
                if (ConfH.AddExtension(KeyExtBan.Text, ValueExtBan.Text, 1) == false)
                {
                    MessageBox.Show("pas ok");
                }
                else
                {
                    MessageBox.Show("ok");
                    ListBoxListing();
                }
            }
        }

        private void SuprExtBan_Click(object sender, RoutedEventArgs e)
        {
            if (KeyExtBan.Text == "")
            {
                MessageBox.Show(dico.pV3_Extension_alert_1[dico.SelectedLang()]);
            }
            else if (ValueExtBan.Text == "")
            {
                MessageBox.Show(dico.pV3_Extension_alert_2[dico.SelectedLang()]);
            }
            else
            {
                ConfH.RemoveExtension(KeyExtBan.Text, 1);
                RefreshPage();
            }
        }






        private void ListBoxListing()
        {
            extPrioList.Items.Clear();
            extBanList.Items.Clear();

            List<string> namesOfBackupSave = ConfH.ListExtension(0);
            foreach (string nameOBS in namesOfBackupSave)
            {
                extPrioList.Items.Add(nameOBS);
            }

            namesOfBackupSave = ConfH.ListExtension(1);
            foreach (string nameOBS in namesOfBackupSave)
            {
                extBanList.Items.Add(nameOBS);
            }


        }

        private void Extension_ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            SettingPage settingPage = new SettingPage();
            settingPage.Show();
            this.Close();
        }

        private void extPrioList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int found = 0;

            found = extPrioList.SelectedItem.ToString().IndexOf(" : ");
            KeyExtPrio.Text = extPrioList.SelectedItem.ToString().Substring(0, found);
            ValueExtPrio.Text = extPrioList.SelectedItem.ToString().Substring(found + 3);
   
        }

        private void extBanList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int found = 0;

            found = extBanList.SelectedItem.ToString().IndexOf(" : ");
            KeyExtBan.Text = extBanList.SelectedItem.ToString().Substring(0, found);
            ValueExtBan.Text = extBanList.SelectedItem.ToString().Substring(found + 3);
        }

        


        private void RefreshExtensionButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshPage();
        }

        private void RefreshPage()
        {
            this.Close();
            ExtensionPage extensionPage = new ExtensionPage();
            extensionPage.Show();
        }

        void ChangePageText(int lang)
        {
            ExtensionLabel.Text = dico.pV3_Etension_1[lang];
            RefreshExtensionButton.Content = dico.pV3_Etension_2[lang];
            addExtPrio.Content = dico.pV3_Etension_3[lang];
            SuprExtPrio.Content = dico.pV3_Etension_4[lang];
            AddExtBan.Content = dico.pV3_Etension_3[lang];
            SuprExtBan.Content = dico.pV3_Etension_4[lang];
            titleExtPrio.Content = dico.pV3_Etension_5[lang];
            titleExtBan.Content = dico.pV3_Etension_6[lang];
            Etension_ReturnButton.Content = dico.pV2_0[lang];
            nameExtBanLabel.Content = dico.pV3_Etension_7[lang];
            ValueExtBanLabel.Content = dico.pV3_Etension_8[lang];
            nameExtPrioLabel.Content = dico.pV3_Etension_7[lang];
            ValueExtPrioLabel.Content = dico.pV3_Etension_8[lang];


        }

        
    }
}
