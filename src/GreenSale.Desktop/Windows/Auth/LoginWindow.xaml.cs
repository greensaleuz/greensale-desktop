using GreenSale.Desktop.Pages;
using GreenSale.Dtos.Dtos.Auth;
using GreenSale.Integrated.Interfaces.Auth;
using GreenSale.Integrated.Services.Auth;
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
                PhoneNumber = txtPhoneNumber.Text.ToString(),
                password  = txtParol.Text.ToString()
            };

            var res = await _authService.LoginAsync(dto);

            if (res.Result)
            {
                MessageBox.Show("Tizimga kirdingiz");
            }
            else
            {
                MessageBox.Show("Registerdan otib kelin");
            }


        }

        private void btnRoyxatdanOtish_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }
    }
}
