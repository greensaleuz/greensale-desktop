using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Interop;
using static GreenSale.Integrated.Services.UseWindowServices.BlurBehindDemo;

namespace GreenSale.Desktop.Windows.Auth
{



    /// <summary>
    /// Interaction logic for ForgotPasswordWindow.xaml
    /// </summary>
    public partial class ForgotPasswordWindow : Window
    {
        public ForgotPasswordWindow()
        {
            InitializeComponent();
        }

        private void NewPasswordSend(object sender, RoutedEventArgs e)
        {

        }

        private void btnCloseResetPassword_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBackResetPassword_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);
        internal void EnableBlur()
        {
            var windowHelper = new WindowInteropHelper(this);

            var accent = new AccentPolicy();
            accent.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND;

            var accentStructSize = Marshal.SizeOf(accent);

            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData();
            data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;

            SetWindowCompositionAttribute(windowHelper.Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EnableBlur();
        }

        private void NumberValidationTextBox(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

