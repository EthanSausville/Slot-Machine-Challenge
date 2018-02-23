using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Slot_Machine_Challenge
{
    public partial class Default : System.Web.UI.Page
    {
        string[] imageArray = { "Bar", "Bell", "Cherry", "Clover", "Diamond", "HorseShoe",
        "Lemon", "Orange", "Plum", "Seven", "Strawberry", "Watermelon" };

        Random random = new Random();
        double betAmount = 0;
        string[] randomImageArray;
        double multiplier = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                randomizeImages();
                ViewState.Add("PlayerMoney", 100);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double test;
            bool isNumber = double.TryParse(betBox.Text, out test);

            if (betBox.Text == "")
                resultLabel.Text = "You must bet something.";
            else if (!isNumber)
                resultLabel.Text = "We only accept money, not strings.";
            else if (double.Parse(betBox.Text) % 1 != 0)
                resultLabel.Text = "Sorry, we don't accept change.";
            else
            {
                randomizeImages();
                betAmount = double.Parse(betBox.Text);
                printResult();
                moneyLabel.Text = string.Format("Player's Money: {0:C}", trackPlayerMoney());
            }
        }

        private void randomizeImages()
        {
            randomImageArray = new string[] { imageArray[random.Next(11)], imageArray[random.Next(11)], imageArray[random.Next(11)] };

            Image1.ImageUrl = string.Format("~/Images/{0}.png", randomImageArray[0]);
            Image2.ImageUrl = string.Format("~/Images/{0}.png", randomImageArray[1]);
            Image3.ImageUrl = string.Format("~/Images/{0}.png", randomImageArray[2]);
        }

        private void printResult()
        {
            if (winOrLoss())
                resultLabel.Text = string.Format("You bet {0:C} and won {1:C}", betAmount, winnings());
            else
                resultLabel.Text = string.Format("You bet {0:C} and lost your bet.", betAmount);
        }

        private bool winOrLoss()
        {
            if (randomImageArray[0] == "Bar" || randomImageArray[1] == "Bar" || randomImageArray[2] == "Bar")
                return false;
            else if (randomImageArray[0] == "Cherry" || randomImageArray[1] == "Cherry" || randomImageArray[2] == "Cherry")
                return true;
            else if (randomImageArray[0] == "Seven" && randomImageArray[1] == "Seven" && randomImageArray[2] == "Seven")
                return true;
            else
                return false;
        }

        private double winnings()
        {
            multiplier = 1;
            for (int i = 0; i < randomImageArray.Length; i++)
            {
                if (randomImageArray[i] == "Cherry")
                    multiplier++;
            }
            if (randomImageArray[0] == "Seven" && randomImageArray[1] == "Seven" && randomImageArray[2] == "Seven")
            {
                multiplier = 100;
            }
            if (randomImageArray[0] == "Bar" || randomImageArray[1] == "Bar" || randomImageArray[2] == "Bar")
                multiplier = 0;
            return multiplier * betAmount;
        }

        private double trackPlayerMoney()
        {
            int playerMoney = (int)ViewState["PlayerMoney"];
            if (winOrLoss())
                playerMoney += (int)winnings();
            else
                playerMoney -= (int)betAmount;
            ViewState["PlayerMoney"] = playerMoney;
            return playerMoney;
        }
     }
}