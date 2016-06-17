using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

namespace guessTheNumber.Model
{
    public class SecretNumber
    {
        int _number;
        List<int> _previousGuesses;
        const int MaxNumberOfGuesses = 6;


        public bool CanMakeGuess //ger ett värde som indikerar om en gissning kan göras eller inte.
        {
            get { 
                    if(Outcome == Outcome.NoMoreGuesse || Outcome == Outcome.Correct)
                    {
                        return false;
                    }
                        return true;
                                                 
                }
        }

        public int Count //lagrar samtliga gissningar gjorda sedan aktuellt hemligt tal slumpades fram.
        {
            get { return _previousGuesses.Count; } 
        }

        public int? Number  //ger eller sätter det hemliga talet
        {
            get {
                if (CanMakeGuess)
                {
                    return null;
                }
                return _number; 

                } 
        }

        public Outcome Outcome { get; private set; } //ger resultatet av den senast utförda gissningen.

        public IEnumerable<int> PreviousGuesses 
        {
            get { return new ReadOnlyCollection<int>(_previousGuesses);}
        }

        public SecretNumber()
        {
            //objekt instansieras av klassen har ett giltigt slumptal
            //skapar en instans av List-objektet med plats för sju element som ska innehålla gjorda gissningar sedan det hemliga talet slumpats fram.
            _previousGuesses = new List<int>(MaxNumberOfGuesses);
            Initialize();
        }

        public void Initialize()
        {
            // _number tilldelas ett slumptal i det slutna intervallet mellan 1 och 100.
            _number = new Random().Next(1, 101);
            // Eventuella element i _previousGuesses tas bort genom anrop av metoden Clear.
            _previousGuesses.Clear();
            // Egenskapen Outcome tilldelas värdet Indefinite.
            Outcome = Outcome.Indefinite;     
        }
        public Outcome MakeGuess(int guess)
        {
            // Är inte gissningen i det slutna intervallet mellan 1 och 100 kastas undantaget ArgumentOutOfRangeException.
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException("gissningen måste vara mellan 1 och 100.");
            }
            if (_number == guess)
            {
                Outcome = Outcome.Correct;
            }
            else if (_previousGuesses.Contains(guess))
            {
                return Outcome = Outcome.PreviousGuess;
            }
            else if (Count == MaxNumberOfGuesses)
            {
                Outcome = Outcome.NoMoreGuesse;
            }
            else if (_number > guess)
            {
                Outcome = Outcome.Low;
            }
            else if (_number < guess)
            {
                Outcome = Outcome.High;
            }


            _previousGuesses.Add(guess);

            
            return Outcome;
        }

    }
    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesse,
        PreviousGuess
    }
}