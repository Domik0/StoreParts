﻿using System;
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

namespace StoreParts
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            /// <summary>
            /// #ff561c Основа 1
            /// #ffca3e Основа 2
            /// #ff850a выделение текста
            /// </summary>
            InitializeComponent();
        }

        private void SignUpClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateAccount());
        }

        private void ShowOnPassword(object sender, MouseButtonEventArgs e)
        {
            PrevPasswordBoxText.Visibility = Visibility.Visible;
            PasswordBoxText.Visibility = Visibility.Visible;
            ShowPasswordBoxText.Visibility = Visibility.Hidden;
            PasswordIcon.Fill = (Brush)new BrushConverter().ConvertFrom("#208C7F");
        }

        private void ShowOffPassword(object sender, MouseButtonEventArgs e)
        {
            PrevPasswordBoxText.Visibility = Visibility.Hidden;
            PasswordBoxText.Visibility = Visibility.Hidden;
            ShowPasswordBoxText.Visibility = Visibility.Visible;
            PasswordIcon.Fill = (Brush)new BrushConverter().ConvertFrom("#000000");
            ShowPasswordBoxText.Text = PasswordBoxText.Password;
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

        private void PasswordBoxTextFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxText.Password != "" || PasswordBoxText.IsKeyboardFocused == true)
            {
                PasswordBoxText.Opacity = 1;
            }
            else
            {
                PasswordBoxText.Opacity = 0;
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

        private void LogInClick(object sender, MouseButtonEventArgs e)
        {
            //var creators = App.db.Creators.Where(c => c.PhoneNumber == UserNameText.Text).ToList();
            //var clients = App.db.Clients.Where(c => c.PhoneNumber == UserNameText.Text).ToList();
            //if (creators.Count() != 0 && creators.First().Password == PasswordBoxText.Password)
            //{
            //    NavigationService.Navigate(new CreatorListFlow(creators.First()));
            //}
            //else if (clients.Count() != 0 && clients.First().Password == PasswordBoxText.Password)
            //{
            //    NavigationService.Navigate(new ClientListFlow(clients.First()));
            //}
            //else
            //{
            //    ErrorLogIn.Visibility = Visibility.Visible;
            //}
        }
    }
}
