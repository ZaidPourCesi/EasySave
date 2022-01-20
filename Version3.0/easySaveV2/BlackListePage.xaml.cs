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
    /// Interaction logic for BlackListePage.xaml
    /// </summary>
    public partial class BlackListePage : Window
    {

        Dictionary dico = new Dictionary();
        ConfigHelper ConfH = new ConfigHelper();



        public BlackListePage()
        {
            InitializeComponent();
            ChangePageText(dico.SelectedLang());
            ListBoxListing();
        }

        private void BlackList_ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            SettingPage settingPage = new SettingPage();
            settingPage.Show();
            this.Close();
        }





        

        private void addBLPrio_Click(object sender, RoutedEventArgs e)
        {
            if (KeyBlPrio.Text == "")
            {
                MessageBox.Show(dico.pV3_BlackList_alert_1[dico.SelectedLang()]);
            }
            else
            {
                if (ConfH.AddToSettings(KeyBlPrio.Text, KeyBlPrio.Text, "ProcessusBlackList") == false)
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

        private void SuprBLPrio_Click(object sender, RoutedEventArgs e)
        {
            if (KeyBlPrio.Text == "")
            {
                MessageBox.Show(dico.pV3_BlackList_alert_1[dico.SelectedLang()]);
            }
            else
            {


                ConfH.RemoveExtensionSettings(KeyBlPrio.Text, "ProcessusBlackList");
                RefreshPage();
            }
        }

        private void BLList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            KeyBlPrio.Text = BLList.SelectedItem.ToString();
            
        }

        private void RefreshBlakListButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            BlackListePage blackListePage = new BlackListePage();
            blackListePage.Show();
        }

        private void ListBoxListing()
        {
            BLList.Items.Clear();

            List<string> namesOfBackupSave = ConfH.UpdateListSetting("ProcessusBlackList");
            foreach (string nameOBS in namesOfBackupSave)
            {
                int found = 0;

                found = nameOBS.ToString().IndexOf(" : ");


                BLList.Items.Add(nameOBS.ToString().Substring(0, found));
            }

        }

        private void RefreshPage()
        {
            this.Close();
            BlackListePage blackListePage = new BlackListePage();
            blackListePage.Show();
        }
        void ChangePageText(int lang)
        {
            BlackListLabel.Text = dico.pV3_BlackList_1[lang];
            addBlPrio.Content = dico.pV3_BlackList_2[lang];
            SuprBlPrio.Content = dico.pV3_BlackList_3[lang];
            titleBL.Content = dico.pV3_BlackList_4[lang];
            BlackList_ReturnButton.Content = dico.pV2_0[lang];
            nameBLLabel.Content = dico.pV3_BlackList_5[lang];

            RefreshBlakListButton.Content = dico.pV3_BlackList_6[lang];
        }

        
    }
}
