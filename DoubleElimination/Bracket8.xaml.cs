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
    /// Interaction logic for Bracket8.xaml
    /// </summary>
    public partial class Bracket8 : Window
    {
        public Bracket8()
        {
            InitializeComponent();
        }

        List<string> players = new List<string>();

        public Bracket8(List<string> list)
        {
            InitializeComponent();
            players = list;
            firstRound();
        }

        private void firstRound()
        {
            r11.Text = players.ElementAt(0);
            r13.Text = players.ElementAt(1);
            r15.Text = players.ElementAt(2);
            r17.Text = players.ElementAt(3);
            r18.Text = players.ElementAt(4);
            r16.Text = players.ElementAt(5);
            r14.Text = players.ElementAt(6);
            r12.Text = players.ElementAt(7);
        }

        private void btn_r1_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (e.Source as Button);
            string[] str = btn.Name.Split('_');
            string p1 = "";
            string p2 = "";
            TextBox t1 = null;
            TextBox t2 = null;
            TextBox roundW = null;
            TextBox roundL = null;

            switch (str[0])
            {
                case "r11":
                    p1 = r11.Text;
                    t1 = r11;
                    roundW = r21;
                    roundL = l21;
                    break;
                case "r13":
                    p1 = r13.Text;
                    t1 = r13;
                    roundW = r22;
                    roundL = l22;
                    break;
                case "r15":
                    p1 = r15.Text;
                    t1 = r15;
                    roundW = r23;
                    roundL = l23;
                    break;
                case "r17":
                    p1 = r17.Text;
                    t1 = r17;
                    roundW = r24;
                    roundL = l24;
                    break;
                default:
                    break;
            }

            switch (str[1])
            {
                case "r12":
                    p2 = r12.Text;
                    t2 = r12;
                    roundW = r21;
                    roundL = l21;
                    break;
                case "r14":
                    p2 = r14.Text;
                    t2 = r14;
                    roundW = r22;
                    roundL = l22;
                    break;
                case "r16":
                    p2 = r16.Text;
                    t2 = r16;
                    roundW = r23;
                    roundL = l23;
                    break;
                case "r18":
                    p2 = r18.Text;
                    t2 = r18;
                    roundW = r24;
                    roundL = l24;
                    break;
                default:
                    break;
            }

            Results rlts = new Results(p1, p2);
            rlts.ShowDialog();

            if (rlts.winner == 1)
            {
                roundW.Text = p1;
                roundL.Text = p2;
                t1.Background = Brushes.OrangeRed;
            }
            else if (rlts.winner == 2)
            {
                roundW.Text = p2;
                roundL.Text = p1;
                t2.Background = Brushes.OrangeRed;
            }
            else
            {
                return;
            }
        }

        private void btn_r2_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (e.Source as Button);
            string[] str = btn.Name.Split('_');
            string p1 = "";
            string p2 = "";
            TextBox t1 = null;
            TextBox t2 = null;
            TextBox roundW = null;
            TextBox roundL = null;

            switch (str[0])
            {
                case "r21":
                    p1 = r21.Text;
                    t1 = r21;
                    roundW = r31;
                    roundL = l31;
                    break;
                case "r23":
                    p1 = r23.Text;
                    t1 = r23;
                    roundW = r32;
                    roundL = l31;
                    break;
                case "l21":
                    p2 = r24.Text;
                    t2 = r24;
                    roundW = l32;
                    //roundL = null;
                    break;
                case "l23":
                    p2 = r24.Text;
                    t2 = r24;
                    roundW = l32;
                    //roundL = null;
                    break;
                default:
                    break;
            }

            switch (str[1])
            {
                case "r22":
                    p2 = r22.Text;
                    t2 = r22;
                    roundW = r31;
                    roundL = l31;
                    break;
                case "r24":
                    p2 = r24.Text;
                    t2 = r24;
                    roundW = r32;
                    roundL = l31;
                    break;
                case "l22":
                    p2 = r24.Text;
                    t2 = r24;
                    roundW = l32;
                    //roundL = null;
                    break;
                case "l23":
                    p2 = r24.Text;
                    t2 = r24;
                    roundW = l32;
                    //roundL = null;
                    break;
                default:
                    break;
            }

            Results rlts = new Results(p1, p2);
            rlts.ShowDialog();

            if (rlts.winner == 1)
            {
                roundW.Text = p1;
                roundL.Text = p2;
                t1.Background = Brushes.OrangeRed;
            }
            else if (rlts.winner == 2)
            {
                roundW.Text = p2;
                roundL.Text = p1;
                t2.Background = Brushes.OrangeRed;
            }
            else
            {
                return;
            }
        }
    }
}
