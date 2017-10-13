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
    /// Interaction logic for Bracket.xaml
    /// </summary>
    public partial class Bracket : Window
    {
        public Bracket()
        {
            InitializeComponent();
        }

        public Bracket(List<string> teams)
        {
            InitializeComponent();
            players = teams;
            winBracket = new WinnerBracket(teams);
            //loseBracket = new LoserBracket(teams, winBracket.btnMargins[1]);
            BuildBracket();
            //TextBox testBox = new TextBox();
            //testBox.Text = "Look at me!";
            //testBox.Margin = new Thickness(20, 1000, 0, 0);
            //BracketGrid.Children.Add(testBox);
        }

        private List<string> players = new List<string>();
        private AbstractBracket winBracket;
        //private AbstractBracket loseBracket; 

        private void BuildBracket()
        {
            foreach (var item in winBracket.textBoxPlacement)
            {
                BracketGrid.Children.Add(item);
            }

            foreach (var item in winBracket.btnMatches)
            {
                BracketGrid.Children.Add(item);
            }

            //foreach (var item in loseBracket.textBoxPlacement)
            //{
            //    BracketGrid.Children.Add(item);
            //}
            //
            //foreach (var item in loseBracket.btnMatches)
            //{
            //    BracketGrid.Children.Add(item);
            //}
        }
    }
}
