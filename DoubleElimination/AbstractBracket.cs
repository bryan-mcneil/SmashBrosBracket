using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DoubleElimination
{
    public abstract class AbstractBracket
    {
        public AbstractBracket()
        {
            //players = null;
            //textBoxPlacement = null;
            //btnMatches = null;
            powerOfTwo = false;
            hasExtraRound = false;
            fillExtraRound = false;
            numberOfWinnerRounds = 0;
            numberOfLoserRounds = 0;
            numberOfMatches = 0;
            numberOfByes = 0;
            extraMatches = 0;
            winnerMatches = 0;
            loserMatches = 0;
            matchCount = 0;
    }

        //public AbstractBracket(List<string> teams)
        //{
        //    players = teams;
        //    powerOfTwo = isPowerOfTwo(players);
        //    matchCount = players.Count;
        //    setByes();
        //    setMatches();
        //    setRounds();
        //    fillTextBox();
        //}

        public List<string> players = new List<string>();
        public List<TextBox> textBoxPlacement = new List<TextBox>();
        public List<Button> btnMatches = new List<Button>();
        protected bool powerOfTwo;
        protected bool hasExtraRound;
        protected bool fillExtraRound;
        protected int[] powers = { 2, 4, 8, 16, 32, 64 };
        public int[] btnMargins = { 60, 60, 0, 0 };
        public int[] textMargins = { 60, 60, 0, 0 };
        protected int numberOfWinnerRounds;
        protected int numberOfLoserRounds;
        protected int numberOfMatches;
        protected int numberOfByes;
        protected int extraMatches;
        protected int winnerMatches;
        protected int loserMatches;      
        protected int matchCount;
        protected int matchNum = 1;
        protected int textNumber = 1;

        public void fillTextBox()
        {
            TextBox temp = null;
            int topSeed = 0;
            int bottomSeed = players.Count - 1;
            bool seedSwitch = true;
            int seedPlacement = players.Count;
            int seed2 = 0;
            for (int i = 0; i < players.Count; i++)
            {
                if (fillExtraRound)
                {
                    if (i < extraMatches * 2)
                    {
                        temp = textBoxPlacement.ElementAt(i);
                        temp.Text = players.ElementAt(bottomSeed);
                        bottomSeed--;
                        seed2 = i + 1;
                    }
                    else if (i % 2 == 0)
                    {
                        if (seedSwitch)
                        {
                            temp = textBoxPlacement.ElementAt(seed2);
                            temp.Text = players.ElementAt(topSeed);
                            topSeed++;
                            seed2++;
                            seedSwitch = false;
                        }
                        else
                        {
                            temp = textBoxPlacement.ElementAt(seedPlacement);
                            temp.Text = players.ElementAt(topSeed);
                            seedSwitch = true;
                            topSeed++;
                            seedPlacement--;
                        }
                    }
                    else
                    {
                        if (!seedSwitch)
                        {
                            temp = textBoxPlacement.ElementAt(seed2);
                            temp.Text = players.ElementAt(bottomSeed);
                            bottomSeed--;
                            seed2++;
                        }
                        else
                        {
                            temp = textBoxPlacement.ElementAt(seedPlacement);
                            temp.Text = players.ElementAt(bottomSeed);
                            bottomSeed--;
                            seedPlacement--;
                        }
                    }
                }
                else
                {
                    if (seedSwitch)
                    {
                        temp = textBoxPlacement.ElementAt(i);
                        temp.Text = players.ElementAt(topSeed);
                        topSeed++;
                        seed2++;
                        seedSwitch = false;
                    }
                    else
                    {
                        temp = textBoxPlacement.ElementAt(i);
                        temp.Text = players.ElementAt(bottomSeed);
                        bottomSeed--;
                        seedPlacement--;
                        seedSwitch = true;
                    }
                }
            }
        }

        public void createButton()
        {
            Button btn = new Button();
            btn.Name = "winners" + matchNum;
            btn.Opacity = 0.3;
            //btn.Click += btn_Click;
            btn.Background = Brushes.Tomato;
            btn.Foreground = Brushes.Tomato;
            btn.BorderBrush = Brushes.Tomato;
            btn.HorizontalAlignment = HorizontalAlignment.Left;
            btn.VerticalAlignment = VerticalAlignment.Top;
            btn.Width = 120;
            btn.Height = 50;
            btn.Margin = new Thickness(btnMargins[0], btnMargins[1], btnMargins[2], btnMargins[3]);

            btnMatches.Add(btn);
            matchNum++;
        }

        public void createTextBox()
        {
            TextBox t1 = new TextBox();

            t1.Name = "r" + textNumber;
            textNumber++;
            t1.HorizontalAlignment = HorizontalAlignment.Left;
            t1.VerticalAlignment = VerticalAlignment.Top;
            t1.Height = 22;
            t1.Width = 120;
            t1.IsReadOnly = true;
            t1.Margin = new Thickness(textMargins[0], textMargins[1], textMargins[2], textMargins[3]);

            textBoxPlacement.Add(t1);
        }

        public bool isPowerOfTwo(List<string> players)
        {
            return (players.Count != 0) && ((players.Count & (players.Count - 1)) == 0);
        }

        public void setMatches()
        {
            numberOfMatches = (players.Count - 1) * 2 + 1;
            winnerMatches = ((numberOfMatches - 1) / 2) + 2;
            loserMatches = winnerMatches - 1;
        }

        public void setRounds()
        {
            if (players.Count <= 4)
            {
                numberOfWinnerRounds = 4;
                numberOfLoserRounds = 2;
            }
            else if (players.Count <= 8)
            {
                numberOfWinnerRounds = 5;
                numberOfLoserRounds = 4;
            }
            else if (players.Count <= 16)
            {
                numberOfWinnerRounds = 6;
                numberOfLoserRounds = 6;
            }
            else if (players.Count <= 32)
            {
                numberOfWinnerRounds = 7;
                numberOfLoserRounds = 8;
            }
            else if (players.Count <= 64)
            {
                numberOfWinnerRounds = 8;
                numberOfLoserRounds = 10;
            }
        }

        public void setByes()
        {
            if (powerOfTwo)
            {
                numberOfByes = 0;
                extraMatches = 0;
                hasExtraRound = false;
                fillExtraRound = false;
            }
            else
            {
                bool highLow = false;
                int high = 0;
                int low = 0;
                int count = 0;
                while (!highLow)
                {
                    if (players.Count < powers[count])
                    {
                        high = powers[count];
                        low = powers[count - 1];
                        highLow = true;
                        numberOfByes = high - players.Count;
                        extraMatches = low - numberOfByes;
                        hasExtraRound = true;
                        fillExtraRound = true;
                        matchCount = (players.Count - extraMatches);
                    }
                    else
                    {
                        count++;
                    }
                }
            }
        }
    }
}
