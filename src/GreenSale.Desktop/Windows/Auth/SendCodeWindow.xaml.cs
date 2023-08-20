using System;
using System.Windows;
using System.Windows.Threading;

namespace GreenSale.Desktop.Windows.Auth
{
    /// <summary>
    /// Interaction logic for SendCodeWindow.xaml
    /// </summary>
    /// 
    public partial class SendCodeWindow : Window
    {
        public int secoundsCount = 10;
        DispatcherTimer _timer;
        TimeSpan _time;

        public SendCodeWindow()
        {
            InitializeComponent();
            _time = TimeSpan.FromSeconds(8);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                txtSecond.Text = _time.ToString(@"ss");

                if (_time == TimeSpan.Zero)
                {
                    _timer.Stop();

                    txtSecond.Visibility = Visibility.Hidden;
                    txb1.Visibility = Visibility.Hidden;
                    txb2.Visibility=Visibility.Hidden;
                    txb3.Visibility=Visibility.Hidden;
                    btnUpdate.Visibility = Visibility.Visible;
                    txb4.Visibility = Visibility.Visible;
                }
                else
                {
                    btnUpdate.Visibility = Visibility.Hidden;
                    txb4.Visibility=Visibility.Hidden;

                }

                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private void txtCode_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (txtCode.Text.Length > 0)
            {
                txtCode2.Focus();
            }
        }

        private void txtCode2_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (txtCode2.Text.Length > 0) txtCode3.Focus();
            else txtCode.Focus();
        }


        private void txtCode5_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (txtCode5.Text.Length == 0) txtCode4.Focus();
        }

        private void txtCode4_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (txtCode4.Text.Length > 0) txtCode5.Focus();
            else txtCode3.Focus();
        }

        private void txtCode3_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (txtCode3.Text.Length > 0) txtCode4.Focus();
            else txtCode2.Focus();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
