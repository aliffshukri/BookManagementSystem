using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Web.Services.Description;
using System.Globalization;
using System.Text.RegularExpressions;
using static Azure.Core.HttpHeader;
using System.Web.Configuration;

namespace dotnet_project.MPage
{
    public partial class info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Type = DropDownList1.Text;
            string Title = TextBox1.Text;
            string Author = TextBox2.Text;
            string Publisher = TextBox3.Text;
            string Year = TextBox4.Text;
            string ISBN = TextBox5.Text;
            string Qty = TextBox6.Text;

            // Check if any field is empty
            if (string.IsNullOrWhiteSpace(Type) ||
                string.IsNullOrWhiteSpace(Title) ||
                string.IsNullOrWhiteSpace(Author) ||
                string.IsNullOrWhiteSpace(Publisher) ||
                string.IsNullOrWhiteSpace(Year) ||
                string.IsNullOrWhiteSpace(ISBN) ||
                string.IsNullOrWhiteSpace(Qty))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please fill in all fields.');", true);
                return; // Stop further processing if any field is empty
            }

            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=ProjectDB; Integrated Security=True; Pooling=False");

            try
            {
                con.Open();

                // Validate Year Published and Quantity
                if (!IsValidNumber(Year) || !IsValidNumber(Qty))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please enter valid numbers for Year Published and Quantity.');", true);
                    return; // Stop further processing if validation fails
                }

                if (!IsValidYear(Year))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please enter a valid four-digit year for Year Published and valid numbers for Quantity.');", true);
                    return; // Stop further processing if validation fails
                }

                // Validate ISBN
                if (!IsValidISBN(ISBN))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please enter a valid ISBN.');", true);
                    return; // Stop further processing if ISBN validation fails
                }

                if (IsISBNAlreadyExists(ISBN))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('ISBN already exists in the database. Please enter a unique ISBN.');", true);
                    return; // Stop further processing if ISBN already exists
                }

                SqlCommand insertCommand = new SqlCommand("INSERT INTO Book (Type, Title, Author, Publisher, Year, ISBN, Qty) VALUES (@Type, @Title, @Author, @Publisher, @Year, @ISBN, @Qty)", con);
                insertCommand.Parameters.AddWithValue("@Type", Type);
                insertCommand.Parameters.AddWithValue("@Title", Title);
                insertCommand.Parameters.AddWithValue("@Author", Author);
                insertCommand.Parameters.AddWithValue("@Publisher", Publisher);
                insertCommand.Parameters.AddWithValue("@Year", Year);
                insertCommand.Parameters.AddWithValue("@ISBN", ISBN);
                insertCommand.Parameters.AddWithValue("@Qty", Qty);

                // Execute the insert command
                insertCommand.ExecuteNonQuery();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Book Details Successfully Inserted');", true);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private bool IsValidNumber(string input)
        {
            int number;
            return int.TryParse(input, out number);
        }
        private bool IsValidISBN(string isbn)
        {
            // The regular expression for the ISBN format "XXX-XXX-XXXXX-X"
            string pattern = @"^\d{3}-\d{3}-\d{5}-\d{1}$";
            return Regex.IsMatch(isbn, pattern);
        }
        private bool IsValidYear(string year)
        {
            int yearValue;
            return int.TryParse(year, out yearValue) && yearValue >= 1900 && yearValue <= 2024;
        }
        private bool IsISBNAlreadyExists(string isbn)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=ProjectDB; Integrated Security=True; Pooling=False");
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Book WHERE ISBN = @ISBN", con);
                command.Parameters.AddWithValue("@ISBN", isbn);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
            finally
            {
                con.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Clear text fields
            TextBox1.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox5.Text = string.Empty;
            TextBox6.Text = string.Empty;

            // Reset drop-down list to default
            DropDownList1.SelectedIndex = 0;
        }
    }
}

