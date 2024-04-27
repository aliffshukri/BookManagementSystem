using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dotnet_project.MPage
{
    public partial class TestLagi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TextBox1.Text, out int numOfElements))
            {
                // Validate that the input is a positive integer

                if (numOfElements >= 0)
                {
                    // Call the function to generate and display the Fibonacci sequence
                    string fibonacciSequence = GenerateFibonacci(numOfElements);
                    Response.Write($"Fibonacci Sequence: {fibonacciSequence}");
                }
                else
                {
                    Response.Write("Please enter a non-negative integer for the number of elements.");
                }
            }
            else
            {
                Response.Write("Invalid input. Please enter a valid number.");
            }
        }

        // Recursive function to generate Fibonacci sequence
        private string GenerateFibonacci(int n)
        {
            if (n == 0)
            {
                return "0";
            }
            else if (n == 1)
            {
                return "0, 1";
            }
            else
            {
                string sequence = "0, 1";
                GenerateFibonacci(n, 2, 0, 1, ref sequence);
                return sequence;
            }
        }

        private void GenerateFibonacci(int n, int currentElement, int prev, int current, ref string sequence)
        {
            if (currentElement < n)
            {
                int next = prev + current;
                sequence += $", {next}";
                GenerateFibonacci(n, currentElement + 1, current, next, ref sequence);
            }
        }
    }
    }
