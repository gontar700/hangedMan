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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppHangedMan
{
 
    public partial class MainWindow : Window
    {
        List<String> words = new List<String> { "רמת השרון", "נווה גן", "הרצליה", "רמת גן" };
        String word;
        int numOfErrors = 0;
        int numOfCorrect = 0;
        public MainWindow()
        {
            InitializeComponent();
            txtNumError.Text = numOfErrors.ToString();
            for (char c = 'א'; c <= 'ת'; c++)
            {
                Button btn = new Button();
                btn.Content = c;
                btn.Tag = c;
                btn.Margin = new Thickness(5);
                btn.MaxHeight = 40;
                btn.MaxWidth = 70;
                btn.Click += Button_Click_Press_Letter;
                ugrid2.Children.Add(btn);
            }
        }

        private void Button_Click_BringW(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int wordN = rnd.Next(words.Count);
            word = words[wordN];
            //foreach (UIElement ctrl in this.ugrid1.Children)
            //{
            //    ugrid1.Children.Remove(ctrl);
            //}
            foreach (UIElement ctrl in this.ugrid2.Children)
            {
                   ctrl.IsEnabled = true;
            }


            for (int i = 0; i < word.Length; i++)
            {
                TextBox txtBx = new TextBox();
                txtBx.Margin = new Thickness(2);
                txtBx.BorderBrush = Brushes.Black;
                txtBx.Width = 80;
                txtBx.Height = 80;
                txtBx.FontSize = 26;
                txtBx.HorizontalContentAlignment = HorizontalAlignment.Center;
                txtBx.VerticalContentAlignment = VerticalAlignment.Center;
                if (word[i]==' ')
                {
                    txtBx.BorderThickness = new Thickness(0);
                }
                else
                {
                    txtBx.BorderThickness = new Thickness(3);
                }
                ugrid1.Children.Add(txtBx);
            }
        }
        private void Button_Click_Press_Letter(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            String s = btn.Content.ToString();
            char c = s.ToCharArray()[0];
            Boolean correctLetter = false;
            for (int i = 0; i < word.Length; i++)
            {
                char ci = word[i];
                if (c == ci)
                {
                    TextBox textBox = ugrid1.Children[i] as TextBox;
                    textBox.Text = s;
                    if(!correctLetter)
                        correctLetter = true;
                    numOfCorrect++;
                }
                if (numOfCorrect == word.Length)
                {
                    MessageBox.Show("You Win!");
                    foreach (UIElement ctrl in this.ugrid2.Children)
                    {
                        ctrl.IsEnabled = false;
                    }
                }
                    
            }
            if (!correctLetter) {
                numOfErrors++;
                switch (numOfErrors)
                {
                    case 1:
                        this.man7.Visibility = Visibility.Collapsed;
                        break;
                    case 2:
                        this.man6.Visibility = Visibility.Collapsed;
                        break;
                    case 3:
                        this.man5.Visibility = Visibility.Collapsed;
                        break;
                    case 4:
                        this.man4.Visibility = Visibility.Collapsed;
                        break;
                    case 5:
                        this.man3.Visibility = Visibility.Collapsed;
                        break;
                    case 6:
                        this.man2.Visibility = Visibility.Collapsed;
                        break;
                    case 7:
                        this.man1.Visibility = Visibility.Collapsed;
                        MessageBox.Show("Game Over!");
                        break;
                    default:
                        MessageBox.Show("Game Over!");
                        break;
                }
                txtNumError.Text = numOfErrors.ToString();
                
            }
            btn.IsEnabled = false;
        }
    }
}
