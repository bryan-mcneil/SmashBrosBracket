using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleElimination
{
    class LoserBracket : AbstractBracket
    {
        public LoserBracket()
        {
            players = null;
            textBoxPlacement = null;
            btnMatches = null;
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

        public LoserBracket(List<string> teams, int distance)
        {
            players = teams;
            powerOfTwo = isPowerOfTwo(players);
            matchCount = players.Count;
            setByes();
            setMatches();
            setRounds();
            btnMargins[1] += (distance * 2);
            textMargins[1] += (distance * 2);
            createLosersBracket();
        }

        private void createLosersBracket()
        {
            int startingPoint = btnMargins[1];
            int centerFinal = 0;
            bool duplicate = true;
            for (int round = 1; round < numberOfLoserRounds; round++)
            {
                matchCount = matchCount / 4;
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
                    }
                    if (duplicate)
                    {
                        btnMargins[1] = startingPoint;
                        textMargins[1] = startingPoint;
                        btnMargins[0] += 135;
                        textMargins[0] += 135;
                        duplicate = false;

                        for (int match = 1; match <= matchCount; match++)
                        {
                            createTextBox();
                            textMargins[1] += 30;
                            createTextBox();
                            textMargins[1] += 30;
                            createButton();
                            btnMargins[1] += 60;
                        }
                    }
                    centerFinal = btnMargins[1] + startingPoint;
                    btnMargins[1] = (btnMargins[1] / 2) - 30;
                    textMargins[1] = (textMargins[1] / 2) - 30;
                }
                else
                {
                    textMargins[1] = (centerFinal / 2);
                    int temp = textMargins[1];
                    btnMargins[1] = (centerFinal / 2);
                    createTextBox();
                    textMargins[1] += 30;
                    createTextBox();
                    textMargins[1] = temp;
                    createButton();
                    if (duplicate)
                    {
                        duplicate = false;
                        btnMargins[0] += 135;
                        textMargins[0] += 135;
                        textMargins[1] = (centerFinal / 2);
                        int temp2 = textMargins[1];
                        btnMargins[1] = (centerFinal / 2);
                        createTextBox();
                        textMargins[1] += 30;
                        createTextBox();
                        textMargins[1] = temp2;
                        createButton();
                    }
                }
                btnMargins[0] += 135;
                textMargins[0] += 135;
            }
        }
    }
}
