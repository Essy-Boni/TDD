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
            throw new NotImplementedException();
        }
    }
}
