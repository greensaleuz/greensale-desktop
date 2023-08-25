using GreenSale.Dtos.Dtos.Auth;
using GreenSale.Integrated.Interfaces.Auth;
using GreenSale.Integrated.Security;
using GreenSale.Integrated.Services.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GreenSale.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IAuthService _authService;

        public LoginWindow()
        {
            InitializeComponent();
            this._authService = new AuthService();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            UserLoginDto dto = new UserLoginDto()
            {
                PhoneNumber =("+998"+ txtPhoneNumber.Text.ToString()),
                password  = txtParol.Text.ToString(),
            };

            var res = await _authService.LoginAsync(dto);

            if (res.Result)
            {
                IdentitySingelton.GetInstance().Token = res.Token;
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }
            else
            {

            }


        }

        private void btnRoyxatdanOtish_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private void txtPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;
            string filteredText = Regex.Replace(text, "[^0-9]+", "");

            if (text != filteredText)
            {
                int caretIndex = textBox.CaretIndex;
                textBox.Text = filteredText;
                textBox.CaretIndex = caretIndex > 0 ? caretIndex - 1 : 0;
            }
        }
    }
}
