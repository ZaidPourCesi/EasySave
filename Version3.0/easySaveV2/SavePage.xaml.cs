using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

using SWF = System.Windows.Forms;

namespace easySaveV3
{
    /// <summary>
    /// Interaction logic for SavePage.xaml
    /// </summary>

    public partial class SavePage : Window
    {

        Dictionary dico = new Dictionary();
        Model model = new Model();
        SWF.FolderBrowserDialog ofd = new SWF.FolderBrowserDialog();
        //OpenFileDialog ofd = new OpenFileDialog();


        public SavePage()
        {
            InitializeComponent();
            ChangePageText(dico.SelectedLang());
        }

        private void Save_ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void test01_Click(object sender, RoutedEventArgs e)
        {
            var test = ofd.ShowDialog();
            TextBoxSourcePath.Text = ofd.SelectedPath;
        }

        private void TargetPath_Click(object sender, RoutedEventArgs e)
        {
            var test = ofd.ShowDialog();
            TextBoxTargetPath.Text = ofd.SelectedPath;
        }

        private void MirrorPath_Click(object sender, RoutedEventArgs e)
        {
            var test = ofd.ShowDialog();
            TextBoxMirrorPath.Text = ofd.SelectedPath;
        }


        private void SaveBoutton_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxSourcePath.Text == "")
            {
                MessageBox.Show(dico.pV2_Save_alert_1[dico.SelectedLang()]);
            }
            else if (TextBoxTargetPath.Text == "")
            {
                MessageBox.Show(dico.pV2_Save_alert_2[dico.SelectedLang()]);
            }
            else if (TextBoxMirrorPath.Text == "")
            {
                MessageBox.Show(dico.pV2_Save_alert_3[dico.SelectedLang()]);
            }
            else if (TextBoxNameOfTheSave.Text == "")
            {
                MessageBox.Show(dico.pV2_Save_alert_4[dico.SelectedLang()]);
            }
            else if (!(bool)(MirrorSaveRadio.IsChecked | DifferentialSaveRadio.IsChecked))
            {
                MessageBox.Show(dico.pV2_Save_alert_5[dico.SelectedLang()]);
            }
            else
            {
                //...

                try
                {
                    if (MirrorSaveRadio.IsChecked == true)
                    {

                        Backup backup = new Backup(TextBoxNameOfTheSave.Text, TextBoxSourcePath.Text, TextBoxTargetPath.Text, 1, TextBoxMirrorPath.Text);
                        model.AddSave(backup);


                    }
                    else
                    {
                        Backup backup = new Backup(TextBoxNameOfTheSave.Text, TextBoxSourcePath.Text, TextBoxTargetPath.Text, 0, TextBoxMirrorPath.Text);
                        model.AddSave(backup);

                    }

                    MessageBox.Show(dico.pV2_Save_alert_6[dico.SelectedLang()]);
                    ResetBacupParameters();
                }
                catch
                {
                    MessageBox.Show(dico.pV2_Save_alert_7[dico.SelectedLang()]);
                }

                //MessageBox.Show(dico.pV2_Save_alert_6[dico.SelectedLang()]);
            }

        }



        void ChangePageText(int lang)
        {
            SaveLabel.Text = dico.pV2_Save_1[lang];
            SourceLabel.Content = dico.pV2_Save_2[lang];
            TargetLabel.Content = dico.pV2_Save_3[lang];
            MirrorLabel.Content = dico.pV2_Save_4[lang];
            NameSaveLabel.Content = dico.pV2_Save_5[lang];
            Save_ReturnButton.Content = dico.pV2_0[lang];
            MirrorSaveRadio.Content = dico.pV2_Save_6[lang];
            DifferentialSaveRadio.Content = dico.pV2_Save_7[lang];
            SaveBoutton.Content = dico.pV2_Save_8[lang];
        }

        void ResetBacupParameters()
        {
            TextBoxSourcePath.Text = string.Empty;
            TextBoxTargetPath.Text = string.Empty;
            TextBoxMirrorPath.Text = string.Empty;
            TextBoxNameOfTheSave.Text = string.Empty;
            MirrorSaveRadio.IsChecked = false;
            DifferentialSaveRadio.IsChecked = false;
        }

    }
}
