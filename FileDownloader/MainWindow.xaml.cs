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
using System.Net;
using System.IO;
namespace FileDownloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textboxdownload.Text = save_path;
            textboxfile.Text = name;
            textbox1.Text = url;
        }

        internal string url = "https://vscode.ru/filesForArticles/test.docx";
        internal string save_path = "C:\\test\\";
        internal string name = "Тестовый файл.docx";

        internal readonly string standart_save_path = "C:\\Users\\USERNAME\\Downloads\\";

        public void  FileDownloader(string l_url, string l_save_path, string l_name)
        {
            try
            {
                WebClient wc = new WebClient();

                string ll_url = l_url.Substring(0, 5);
                if (ll_url == "https")
                {
                    wc.DownloadFile(l_url, l_save_path + l_name);

                    progressivebar.Value = 100;
                }
                else
                {
                    wc.DownloadFile("https" + l_url, l_save_path + l_name);

                    progressivebar.Value = 100;
                }

            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Ошибка в написании пути загрузки или пути скачивания");
            }
            catch (WebException)
            {
                MessageBox.Show("Нет ответа со стороны сервера");
            }
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textboxdownload.Text = standart_save_path; 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FileDownloader(textbox1.Text, textboxdownload.Text, textboxfile.Text); 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            progressivebar.Value = 0; 
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Help help = new Help(); 
            help.Show();    
        }
    }

}
