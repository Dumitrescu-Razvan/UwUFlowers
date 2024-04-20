﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Profile_page;
using ProfessionalProfile.Repo;
using ProfessionalProfile.SectionViews;
using ProfessionalProfile.Service.SignUp;
using ProfessionalProfile.Service.WebBrowser;
using static System.Formats.Asn1.AsnWriter;

namespace ProfessionalProfile.Service.Login
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        private UserRepo usersRepo;
        private string clientIdLinkedin;
        private string redirectUrlLinkedin;
        private string clientSecretLinkedin;
        private string clientIdFacebook;
        private string redirectUrlFacebook;
        private string clientSecretFacebook;

        public LoginPage()
        {
            InitializeComponent();
            this.usersRepo = new UserRepo();
            clientIdLinkedin = "77gmhbc7jwhfuu";
            redirectUrlLinkedin = "http://localhost:8000/lab2";
            clientSecretLinkedin = "3acj7wfj3kQDiHoB";
            clientIdFacebook = "968501770998125";
            redirectUrlFacebook = "http://localhost:8000/lab3";
            clientSecretFacebook = "9e46f4bab93249c84fa750eb6284c784";
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Enter your email" || textBox.Text == string.Empty)
            {
                textBox.Text = string.Empty;
                textBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }
        private void GoToSignup(object sender, RoutedEventArgs e)
        {
            SignUpPage signUpPage = new SignUpPage();
            // this.Hide();
            signUpPage.Show();
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Enter your email";
                textBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = (PasswordBox)sender;
            if (passwordBox.Password.Length > 0)
            {
                passwordPlaceholder.Visibility = Visibility.Collapsed;
            }
            else
            {
                passwordPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void PasswordPlaceholder_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordPlaceholder.Visibility = Visibility.Collapsed;
            passwordBox.Focus();
        }

        private static string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashedBytes = sha256.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2")); // Convert byte to hexadecimal string
                }
                return builder.ToString();
            }
        }

        private void HandleLogin(object sender, RoutedEventArgs e)
        {
            if (this.emailBox.Text.Length == 0 || this.passwordBox.Password.Length == 0)
            {
                this.errorLabel.Content = "Please fill out every field!";
            }
            else
            {
                this.errorLabel.Content = string.Empty;
                this.errorLabel.Visibility = Visibility.Collapsed;

                // this.titleBox.Text = this.emailBox.Text + " " + ComputeSHA256Hash(this.passwordBox.Password);
                string email, password;
                email = this.emailBox.Text;
                password = ComputeSHA256Hash(this.passwordBox.Password);

                // ask for function to get user by password and email
                User loggedInUser = null;
                List<User> allUsers = this.usersRepo.GetAll();
                foreach (var user in allUsers)
                {
                    if (user.Email == email && user.Password == password)
                    {
                        loggedInUser = (User)user;
                        break;
                    }
                }

                if (loggedInUser == null)
                {
                    this.errorLabel.Visibility = Visibility.Visible;
                    this.errorLabel.Content = "No user found with that user and password!";
                }
                else
                {
                    // this.titleBox.Text = "Welcome back " + loggedInUser.FirstName;
                    // CertificateWindow window = new CertificateWindow(loggedInUser.UserId);
                    ProfilePage window = new ProfilePage(loggedInUser.UserId, loggedInUser.UserId);
                    this.Hide();
                    window.Show();
                }
            }
        }

        private void FacebookLogin(object sender, RoutedEventArgs e)
        {
            string scope = "email public_profile";
            HttpClient httpClient = new HttpClient();

            string authorizationUrl = $"https://www.facebook.com/v12.0/dialog/oauth?client_id={clientIdFacebook}&redirect_uri={redirectUrlFacebook}&scope={scope}";

            BrowserPage browserPage = new BrowserPage(true);
            // this.Hide();
            browserPage.Show();
            browserPage.WebBrowser.Navigate("about:blank");
            browserPage.WebBrowser.Navigate(authorizationUrl);
            // browserPage.Show();
        }
        private void LinkedInLogin(object sender, RoutedEventArgs e)
        {
            // Construct the OAuth authorization URL for LinkedIn
            string authorizationUrl = "https://www.linkedin.com/oauth/v2/authorization";
            string scope = "profile openid email"; // Add any additional LinkedIn scopes as needed

            // Construct the full authorization URL with parameters
            string fullAuthorizationUrl = $"{authorizationUrl}?response_type=code&client_id={this.clientIdLinkedin}&redirect_uri={this.redirectUrlLinkedin}&scope={scope}";

            // Navigate to the authorization URL in the embedded Web browser control
            BrowserPage browserPage = new BrowserPage(true);

            browserPage.Show();
            browserPage.WebBrowser.Navigate("about:blank");
            browserPage.WebBrowser.Navigate(fullAuthorizationUrl);
            // browserPage.Show();
        }
    }
}
