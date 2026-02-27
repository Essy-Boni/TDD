using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BowlingApp
{
    public class Frame 
    {
        private int score ;
        private bool _lastFrame;
        private IGenerateur _generateur;
        private List<Roll> rolls = new();

        public int Score => score;

        public Frame(IGenerateur generateur, bool lastFrame)
        {
            _lastFrame = lastFrame;
            _generateur = generateur;
        }

        public bool MakeRoll()
        {
            // Série standard
            if (!_lastFrame)
            {
                // Maximum 2 lancers
                if (rolls.Count >= 2)
                    return false;

                // En cas de strike, 1 seul lancé autorisé
                if (rolls.Count == 1 && rolls[0].Pins == 10)
                    return false;
            }

            // Serie finale
            if (_lastFrame)
            {
                // 3 lancers maximum
                if (rolls.Count >= 3)
                    return false;

              
                if (rolls.Count == 2) //Implémentation règles lancer bonus après strike et spare
                {
                    bool strike = rolls[0].Pins == 10; 
                    bool spare = (rolls[0].Pins + rolls[1].Pins) == 10;

                    if (!strike && !spare)
                        return false;
                }
            }

            
            int pins = _generateur.RandomPin(10);

            rolls.Add(new Roll(pins));
            score += pins;

            return true;
        }
    }
}
