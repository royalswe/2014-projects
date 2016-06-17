using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using guessTheNumber.Model;

namespace guessTheNumber
{
    public partial class Default : System.Web.UI.Page
    {
        private SecretNumber secretNumber
        {
            get {

                    var number = Session["number"] as SecretNumber;

                    if (number == null)
                    {
                        return secretNumber = new SecretNumber();
                    }
                    else
                    {
                        return number;
                    }
                }

            set {
                    
                    Session["number"] = value; 
                }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Submit_Click(object sender, EventArgs e)
        {

                TextBox.Focus();
                TextBox.Attributes.Add("onfocusin", " select();");
         
            if (IsValid)
            {
                int guess = int.Parse(TextBox.Text);
                var outcome = secretNumber.MakeGuess(guess);
                

                if (!secretNumber.CanMakeGuess)
                {
                    TextBox.Enabled = false;
                    Submit.Enabled = false;
                    RestartButton.Visible = true;
                    Session.Abandon();
                }
                if (outcome == Outcome.NoMoreGuesse)
                {
                    Answer.Text = string.Format("Du har inga gissningar kvar, det hemliga talet var {0}", secretNumber.Number);
                }
                else if (outcome == Outcome.Correct)
                {
                    TextLabel.Text = string.Format("Grattis du klarade det på {0} försök", secretNumber.Count);
                }
                else if (outcome == Outcome.PreviousGuess)
                {
                    TextLabel.Text = "Du har redan gissat på talet";
                }
                else if (outcome == Outcome.High)
                {
                    TextLabel.Text = "För högt";
                }
                else if (outcome == Outcome.Low)
                {
                    TextLabel.Text = "För lågt";
                }

               
                GuessLabel.Text = string.Join("<p> ", secretNumber.PreviousGuesses);
                
            }
        }
    }
}