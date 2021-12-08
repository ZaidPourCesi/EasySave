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
//using System.Windows.Forms;

namespace easySaveV2
{
    /// <summary>
    /// Interaction logic for SavePage.xaml
    /// </summary>
    
    public partial class SavePage : Window
    {
        
        Dictionary dico = new Dictionary();
  

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
            OpenFileDialog ofd = new OpenFileDialog();
            var test = ofd.ShowDialog();
            TextBoxSourcePath.Text = ofd.FileName;
        }

        private void TargetPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            var test = ofd.ShowDialog();
            TextBoxTargetPath.Text = ofd.FileName;
        }

        private void MirrorPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            var test = ofd.ShowDialog();
            TextBoxMirrorPath.Text = ofd.FileName;
        }


        private void SaveBoutton_Click(object sender, RoutedEventArgs e)
        {

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

        
    }
}
