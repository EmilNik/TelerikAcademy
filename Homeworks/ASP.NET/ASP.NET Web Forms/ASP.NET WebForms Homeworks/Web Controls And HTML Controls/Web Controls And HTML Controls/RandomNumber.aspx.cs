using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Controls_And_HTML_Controls
{
    public partial class RandomNumber : System.Web.UI.Page
    {
        protected void generateRandomNumber(object sender, EventArgs e)
        {
            int minValue;
            if (!int.TryParse(this.randomNumberMin.Value, out minValue))
            {
                this.randomNumberOutput.Text = $"\"{this.randomNumberMin.Value}\" could not be parsed to a number! Please enter a valid number!";
                return;
            }

            int maxValue;
            if (!int.TryParse(this.randomNumberMax.Value, out maxValue))
            {
                this.randomNumberOutput.Text = $"\"{this.randomNumberMax.Value}\" could not be parsed to a number! Please enter a valid number!";
                return;
            }

            if (minValue > maxValue)
            {
                this.randomNumberOutput.Text = $"\"{this.randomNumberMin.Value}\" is larger number than \"{this.randomNumberMax.Value}\"! Please enter valid input!";
                return;
            }

            var random = new Random();
            var number = random.Next(minValue, maxValue + 1);
            this.randomNumberOutput.Text = $"Random number: {number}";
        }
    }
}