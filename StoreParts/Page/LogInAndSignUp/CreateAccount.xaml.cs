using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace StoreParts
{
    /// <summary>
    /// Логика взаимодействия для CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : System.Windows.Controls.Page
    {
        bool CustomCheckBoxArgBool = false;
        private User user;

        public CreateAccount()
        {
            user = new User();
            InitializeComponent();
            DataContext = user;
        }

        private void ProceedClick(object sender, RoutedEventArgs e)
        {
            if (UserPhoneNumberText.Text == "")
            {
                phoneBorder.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF0000");
            }
            if (EmailText.Text == "")
            {
                emailBorder.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF0000");
            }
            if (UserNameText.Text == "")
            {
                nameBorder.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF0000");
            }
            if (ShowPasswordBoxText.Text == "")
            {
                passwordBorder.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF0000");
            }
            if (!CustomCheckBoxArgBool)
            {
                RadioButtonAgrOff.Visibility = Visibility.Hidden;
                MessageBox.Show("Необходимо согласится с условиями использования", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Validation.GetHasError(UserPhoneNumberText) && !Validation.GetHasError(UserNameText) 
            && !Validation.GetHasError(ShowPasswordBoxText) && !Validation.GetHasError(EmailText))
            {
                if (App.db.Users.Where(u => u.Phone == UserPhoneNumberText.Text).Count() == 0)
                {
                    user.Name = UserNameText.Text;
                    user.Email = EmailText.Text;
                    user.Phone = UserPhoneNumberText.Text;
                    user.Password = ShowPasswordBoxText.Text;
                    App.db.Users.Add(user);
                    App.db.SaveChanges();
                    NavigationService.GoBack();
                }
                else
                {
                    phoneBorder.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF0000");
                    errorPhoneText.Text = "Аккаунт с таким номером телефона существует";
                }
            }
            Keyboard.ClearFocus();
        }

        private void UserNameTextFocus(object sender, RoutedEventArgs e)
        {
            if (UserNameText.Text != "" || UserNameText.IsKeyboardFocused == true)
            {
                UserNameText.Opacity = 1;
            }
            else
            {
                UserNameText.Opacity = 0;
            }
        }

        private void EmailTextFocus(object sender, RoutedEventArgs e)
        {
            if (EmailText.Text != "" || EmailText.IsKeyboardFocused == true)
            {
                EmailText.Opacity = 1;
            }
            else
            {
                EmailText.Opacity = 0;
            }
        }

        private void PasswordBoxTextFocus(object sender, RoutedEventArgs e)
        {
            if (ShowPasswordBoxText.Text != "" || ShowPasswordBoxText.IsKeyboardFocused == true)
            {
                ShowPasswordBoxText.Opacity = 1;
            }
            else
            {
                ShowPasswordBoxText.Opacity = 0;
            }
        }

        private void UserPhoneNumberTextFocus(object sender, RoutedEventArgs e)
        {
            if (UserPhoneNumberText.Text != "" || UserPhoneNumberText.IsKeyboardFocused == true)
            {
                UserPhoneNumberText.Opacity = 1;
            }
            else
            {
                UserPhoneNumberText.Opacity = 0;
            }
        }

        private void CustomCheckBoxAgreement(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Controls.Image selectImage = sender as System.Windows.Controls.Image;
            switch (selectImage.Name)
            {
                case "RadioButtonAgrOff":
                case "RadioButtonAgrError":
                    RadioButtonAgrOn.Visibility = Visibility.Visible;
                    CustomCheckBoxArgBool = true;
                    break;
                case "RadioButtonAgrOn":
                    RadioButtonAgrOff.Visibility = Visibility.Visible;
                    RadioButtonAgrOn.Visibility = Visibility.Hidden;
                    CustomCheckBoxArgBool = false;
                    break;
            }
        }

        private void CustomCheckBoxPasswordGeneration(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Controls.Image selectImage = sender as System.Windows.Controls.Image;
            switch (selectImage.Name)
            {
                case "RadioButtonPassGenOff":
                    RadioButtonPassGenOff.Visibility = Visibility.Hidden;
                    RadioButtonPassGenOn.Visibility = Visibility.Visible;
                    ShowPasswordBoxText.Text = GetPass();
                    ShowPasswordBoxText.Opacity = 1;
                    break;
                case "RadioButtonPassGenOn":
                    RadioButtonPassGenOff.Visibility = Visibility.Visible;
                    RadioButtonPassGenOn.Visibility = Visibility.Hidden;
                    ShowPasswordBoxText.Text = "";
                    ShowPasswordBoxText.Opacity = 0;
                    break;
            }
        }

        string GetPass()
        {
            Random rnd = new Random();
            int length = rnd.Next(8, 12);
            const string ValidChar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@$!%*?&.";
            StringBuilder result = new StringBuilder();
            Random randomChar = new Random();
            while (!Regex.IsMatch(result.ToString(), @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&.]{8,}"))
            {
                result.Append(ValidChar[randomChar.Next(ValidChar.Length)]);
            }
            return result.ToString();

            {
                //bool en = false;
                //bool symbol = false;
                //bool number = false;

                //string s0, s1, st;
                //s0 = "";
                //Random rnd = new Random();
                //int n;
                //st = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@$!%*?&.";

                //while (!en || !symbol || !number)
                //{
                //    for (int j = 0; j < 10; j++)
                //    {
                //        n = rnd.Next(0, st.Length);
                //        s1 = st.Substring(n, 1);
                //        s0 += s1;
                //    }
                //    for (int i = 0; i < s0.Length; i++)
                //    {
                //        if (s0[i] >= 'A' & s0[i] <= 'Z') en = true;
                //        if (s0[i] >= '0' & s0[i] <= '9') number = true;
                //        if (s0[i] == '_' || s0[i] == '-' || s0[i] == '!') symbol = true;
                //    }
                //    if (en && number && symbol)
                //    {
                //        return s0;
                //    }
                //    s0 = "";
                //}
                //return "";
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.google.ru/");
        }

        private void UserPhoneNumberText_Error(object sender, ValidationErrorEventArgs e)
        {
            if (Validation.GetHasError(sender as TextBox))
            {
                errorPhoneText.Text = e.Error.ErrorContent.ToString();
                errorPasswordText.Visibility = Visibility.Visible;
                phoneBorder.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF0000");
            }
            else
            {
                errorPhoneText.Visibility = Visibility.Hidden;
                phoneBorder.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#DADADA");
            }
        }

        private void UserNameText_Error(object sender, ValidationErrorEventArgs e)
        {
            if (Validation.GetHasError(sender as TextBox))
            {
                errorNameText.Text = e.Error.ErrorContent.ToString();
                errorNameText.Visibility = Visibility.Visible;
                nameBorder.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF0000");
            }
            else
            {
                errorNameText.Visibility = Visibility.Hidden;
                nameBorder.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#DADADA");
            }
        }

        private void EmailText_Error(object sender, ValidationErrorEventArgs e)
        {
            if (Validation.GetHasError(sender as TextBox))
            {
                errorEmailText.Text = e.Error.ErrorContent.ToString();
                errorEmailText.Visibility = Visibility.Visible;
                emailBorder.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF0000");
            }
            else
            {
                errorEmailText.Visibility = Visibility.Hidden;
                emailBorder.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#DADADA");
            }
        }

        private void PasswordBoxText_Error(object sender, ValidationErrorEventArgs e)
        {
            if (Validation.GetHasError(sender as TextBox))
            {
                errorPasswordText.Text = e.Error.ErrorContent.ToString();
                errorPasswordText.Visibility = Visibility.Visible;
                passwordBorder.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF0000");
            }
            else
            {
                errorPasswordText.Visibility = Visibility.Hidden;
                passwordBorder.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#DADADA");
            }
        }
    }
}
