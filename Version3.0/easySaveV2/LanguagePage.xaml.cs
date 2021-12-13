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
    /// Interaction logic for LanguagePage.xaml
    /// </summary>
    public partial class LanguagePage : Window
    {

        Dictionary dico = new Dictionary();

        public LanguagePage()
        {
            InitializeComponent();
            ChangePageText(dico.SelectedLang());
            ListBoxListing();
        }

        private void ListBoxListing()
        {
            LanguageListBox.Items.Clear();

            List<string> namesOfBackupSave = dico.ListLanguages();
            foreach (string nameOBS in namesOfBackupSave)
            {
                LanguageListBox.Items.Add(nameOBS);
            }

        }

        private void Language_ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            SettingPage settingPage = new SettingPage();
            settingPage.Show();
            this.Close();
        }


        private void LanguageListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dico.DicoChangeLang(LanguageListBox.SelectedIndex.ToString());
            ChangePageText(Int32.Parse(LanguageListBox.SelectedIndex.ToString()));
            RefreshPage();
        }


        private void RefreshPage()
        {
            this.Close();
            LanguagePage languagePage = new LanguagePage();
            languagePage.Show();
        }

        void ChangePageText(int lang)
        {
            LanguageLabel.Text = dico.pV3_Language_1[lang];
            Language_ReturnButton.Content = dico.pV2_0[lang];
        }

        
    }
}
