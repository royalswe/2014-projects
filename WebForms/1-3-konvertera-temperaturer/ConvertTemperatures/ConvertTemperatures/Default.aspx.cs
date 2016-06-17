using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConvertTemperatures.Model;

namespace ConvertTemperatures
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxStart.Focus();
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                
                int start = int.Parse(TextBoxStart.Text);
                int end = int.Parse(TextBoxEnd.Text);
                int steps = int.Parse(TextBoxStep.Text);
                

                int difference = 0;

                TableHeaderRow headRow = new TableHeaderRow();
                TempTable.Rows.Add(headRow);

                TableHeaderCell cCell = new TableHeaderCell
                {
                    Text = "&deg;C"
                };

                TableHeaderCell fCell = new TableHeaderCell
                {
                    Text = "&deg;F"
                };

                if (RadioButtonList.SelectedValue == "C")
                {
                    headRow.Cells.Add(cCell);
                    headRow.Cells.Add(fCell);
                }
                else
                {
                    headRow.Cells.Add(fCell);
                    headRow.Cells.Add(cCell);
                }
              
                while (end >= start)
                {

                    if (RadioButtonList.SelectedValue == "C")
                    {
                        difference = TemperatureConverter.CelciusToFahrenheit(start);
                    }
                    else
                    {
                        difference = TemperatureConverter.FahrenheitToCelcius(start);
                    }
                   
                    TableRow tRow = new TableRow();
                    TempTable.Rows.Add(tRow);

                    TableCell Cell = new TableCell();
                    Cell.Text = Convert.ToString(start);
                    tRow.Cells.Add(Cell);

                    TableCell Cell2 = new TableCell();
                    Cell2.Text = Convert.ToString(difference);
                    tRow.Cells.Add(Cell2);

                    start += steps;
                }

                TempTable.Visible = true;
                
            }
            
        }
    }
}