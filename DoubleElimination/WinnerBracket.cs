using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DoubleElimination
{
    class WinnerBracket : AbstractBracket
    {
        public WinnerBracket()
        {
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

        public WinnerBracket(List<string> teams)
        {
            players = teams;
            powerOfTwo = isPowerOfTwo(players);
            matchCount = players.Count;
            setByes();
            setMatches();
            setRounds();
            createWinnersBracket();
            //fillTextBox();
        }

        private void createWinnersBracket()
        {
            int center = 0;
            int firstIndex = 0;
            int lastIndex = 0;
            int temp = 0;
            for (int round = 1; round < numberOfWinnerRounds; round++)
            {
                matchCount = matchCount / 2;
                if (matchCount > 1)
                {
                    for (int match = 1; match <= matchCount; match++)
                    {
                        createTextBox();
                        textMargins[1] += 30;
                        createTextBox();
                        textMargins[1] += 30;
                        createButton();
                        btnMargins[1] += 60;
                        lastIndex++;
                    }
                    center = (int)((btnMatches.ElementAt(firstIndex).Margin.Top + btnMatches.ElementAt(lastIndex - 1).Margin.Top - 60) / 2);
                    firstIndex = lastIndex;
                }
                else
                {
                    temp = textMargins[1];
                    createTextBox();
                    textMargins[1] += 30;
                    createTextBox();
                    textMargins[1] = temp;
                    createButton();
                }
                btnMargins[0] += 135;
                textMargins[0] += 135;
                btnMargins[1] = center;
                textMargins[1] = center;
            }
        }
    }
}
