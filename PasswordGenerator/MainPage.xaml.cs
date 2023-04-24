using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace PasswordGenerator
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Text = String.Empty;
            try
            {

                double Length = lenghtSlider.Value;
                List<char> password = new System.Collections.Generic.List<char>();
                for (int i = 0; i <= Length; i++)
                {
                    password.Add(RandomChar());
                }
                foreach (char c in password)
                {
                    passwordTextBox.Text += c;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        private char RandomChar()
        {
            try
            {
                String final = PrepareString();
                Random random = new Random();
                return (char)final[random.Next(0, final.Length - 1)];
            }
            catch (Exception)
            {
                return ' ';
            }

        }
        public String PrepareString()
        {
            String AZ = "ABCDEFGHIJKLMNOPRSTUVWXYZ";
            String az = "abcdefghijklmnoprstuvwxyz";
            String numbers = "0123456789";
            String special = "!@#$%^&*";
            String final = String.Empty;

            if (!ValiadateOptions())
            {
                passwordTextBox.Text = "Zaznacz jedną z opcji aby wygenerować";
                return String.Empty;
            }

            _ = (bool)bigLettersChB.IsChecked ? final += AZ : final += String.Empty;
            _ = (bool)smallLettersChB.IsChecked ? final += az : final += String.Empty;
            _ = (bool)numbersChB.IsChecked ? final += numbers : final += String.Empty;
            _ = (bool)specialChB.IsChecked ? final += special : final += String.Empty;
            return ShuffleString(final);
        }
        private bool ValiadateOptions()
        {
            if (!(bool)bigLettersChB.IsChecked && !(bool)smallLettersChB.IsChecked && !(bool)numbersChB.IsChecked && !(bool)specialChB.IsChecked)
            {
                return false;
            }
            return true;
        }
        private String ShuffleString(String oldone)
        {
            Random r = new Random();
            return new string(oldone.ToCharArray().OrderBy(s => (r.Next(2) % 2) == 0).ToArray());
        }
    }

}
