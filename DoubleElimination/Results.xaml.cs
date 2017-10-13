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

namespace DoubleElimination
{
    /// <summary>
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : Window
    {
     
        public Results(String p1, String p2)
        {
            InitializeComponent();
            this.p1 = p1;
            this.p2 = p2;
            PlayerResults(p1, p2);
        }

        public String p1;
        public String p2;
        public int winner;
        public int s1;
        public int s2;
        private int WinnerOfMatch()
        {
            if (winner1.IsChecked == true)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        private void PlayerResults(String p1, String p2)
        {
            player1.Text = p1;
            player2.Text = p2;
        }

        private void SubmitResults_Click(object sender, RoutedEventArgs e)
        {
            if (winner1.IsChecked == false && winner2.IsChecked == false)
            {
                return;
            }

            if (score1.Text == "" || score2.Text == "")
            {
                return;
            }

            winner = WinnerOfMatch();
            s1 = Int32.Parse(score1.Text);
            s2 = Int32.Parse(score2.Text);
            this.Close();
        }
    }
}
