using System;
using System.Collections.Generic;
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

namespace SimpleChat.Client.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Client _client;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_OnClick(object sender, RoutedEventArgs e)
        {
            UserNameTb.IsEnabled = false;
            LoginBtn.IsEnabled = false;
            //LoadHistoryBtn.IsEnabled = true;
            MessagesTb.IsEnabled = true;
            InputTb.IsEnabled = true;
            SendBtn.IsEnabled = true;

            _client = new Client(UserNameTb.Text);
        }

        private void Send_OnClick(object sender, RoutedEventArgs e)
        {
            _client.SendMessage(InputTb.Text);
            InputTb.Clear();

            MessagesTb.Text = string.Empty;
            MessagesTb.Text = _client.GetMessages();
        }

        /*private void LoadHistory_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }*/
    }
}
