using GreenSale.Desktop.Windows.Auth;
using GreenSale.Dtos.Dtos.Auth;
using GreenSale.Integrated.Interfaces.Auth;
using GreenSale.Integrated.Services.Auth;
using System.Windows;

namespace GreenSale.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private IAuthService _service;
        public static string phoneNum { get; set; }
        public RegisterWindow()
        {
            InitializeComponent();
            this._service = new AuthService();

        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnShaxsiykabinet_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }
        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            UserRegisterDto dto = new UserRegisterDto()
            {
                FirstName = txtFirstName.Text.ToString(),
                LastName = txtLastName.Text.ToString(),
                PhoneNumber = txtPhoneNumber.Text.ToString(),
                Password = txtPassword.Text.ToString()
            };

            bool res = await _service.RegisterAsync(dto);
            if (res)
            {
                await _service.SendCodeForRegisterAsync(txtPhoneNumber.Text);
                phoneNum= txtPhoneNumber.Text;
                SendCodeWindow sendCodeWindow = new SendCodeWindow();
                sendCodeWindow.ShowDialog();
                this.Close();
            }
        }
    }
}
