using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace dotnet_project.MPage
{
    public partial class InfoStationary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ISBN = TextBox5.Text;

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=ProjectDB; Integrated Security=True; Pooling=False"))
                {
                    con.Open();

                    // Check if the ISBN exists in the database
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM Book WHERE ISBN = @ISBN", con);
                    checkCommand.Parameters.AddWithValue("@ISBN", ISBN);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        // ISBN exists, fetch details
                        SqlCommand selectCommand = new SqlCommand("SELECT * FROM Book WHERE ISBN = @ISBN", con);
                        selectCommand.Parameters.AddWithValue("@ISBN", ISBN);

                        SqlDataReader reader = selectCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            DropDownList1.SelectedValue = reader.GetValue(1).ToString();
                            TextBox1.Text = reader.GetValue(2).ToString();
                            TextBox3.Text = reader.GetValue(3).ToString();
                            TextBox2.Text = reader.GetValue(4).ToString();
                            TextBox4.Text = reader.GetValue(5).ToString();
                            TextBox6.Text = reader.GetValue(7).ToString();
                        }
                    }
                    else
                    {
                        // ISBN does not exist, show error message
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('ISBN not found in the database');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Validate that all required fields are filled in and have correct formats
            if (IsValidInput())
            {
                string Type = DropDownList1.Text;
                string Title = TextBox1.Text;
                string Author = TextBox2.Text;
                string Publisher = TextBox3.Text;
                string Year = TextBox4.Text;
                string ISBN = TextBox5.Text;
                string Qty = TextBox6.Text;

                try
                {
                    using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=ProjectDB; Integrated Security=True; Pooling=False"))
                    {
                        con.Open();

                        SqlCommand updateCommand = new SqlCommand("UPDATE Book SET Type = @Type, Title = @Title, Author = @Author, Publisher = @Publisher, Year = @Year, Qty = @Qty WHERE ISBN = @ISBN", con);
                        updateCommand.Parameters.AddWithValue("@Type", Type);
                        updateCommand.Parameters.AddWithValue("@Title", Title);
                        updateCommand.Parameters.AddWithValue("@Author", Author);
                        updateCommand.Parameters.AddWithValue("@Publisher", Publisher);
                        updateCommand.Parameters.AddWithValue("@Year", Year);
                        updateCommand.Parameters.AddWithValue("@ISBN", ISBN);
                        updateCommand.Parameters.AddWithValue("@Qty", Qty);

                        updateCommand.ExecuteNonQuery();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Book Details Successfully Updated');", true);
                    }
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
            }
        }
        private bool IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(DropDownList1.Text) ||
                string.IsNullOrWhiteSpace(TextBox1.Text) ||
                string.IsNullOrWhiteSpace(TextBox2.Text) ||
                string.IsNullOrWhiteSpace(TextBox3.Text) ||
                string.IsNullOrWhiteSpace(TextBox4.Text) ||
                string.IsNullOrWhiteSpace(TextBox5.Text) ||
                string.IsNullOrWhiteSpace(TextBox6.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please fill in all required fields.');", true);
                return false;
            }

            if (!IsValidYearFormat(TextBox4.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Year Published must be in 4-digit year format (e.g., 2024).');", true);
                return false;
            }

            if (!IsValidQuantity(TextBox6.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Quantity must be a numeric value.');", true);
                return false;
            }

            return true;
        }

        // Validate that the year is in 4-digit format
        private bool IsValidYearFormat(string year)
        {
            int parsedYear;
            return int.TryParse(year, out parsedYear) && year.Length == 4;
        }

        // Validate that the quantity is a numeric value
        private bool IsValidQuantity(string quantity)
        {
            int parsedQuantity;
            return int.TryParse(quantity, out parsedQuantity);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string ISBN = TextBox5.Text;

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=ProjectDB; Integrated Security=True; Pooling=False"))
                {
                    con.Open();

                    SqlCommand deleteCommand = new SqlCommand("DELETE FROM Book WHERE ISBN = @ISBN", con);
                    deleteCommand.Parameters.AddWithValue("@ISBN", ISBN);

                    deleteCommand.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Book Details Successfully Deleted');", true);
                }

                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            string ISBN = TextBox5.Text;

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=ProjectDB; Integrated Security=True; Pooling=False"))
                {
                    con.Open();

                    SqlCommand selectCommand = new SqlCommand("SELECT * FROM Book WHERE ISBN = @ISBN", con);
                    selectCommand.Parameters.AddWithValue("@ISBN", ISBN);

                    // Use a SqlDataAdapter to fill a DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Bind the DataTable to the GridView using DataSourceID
                        GridView1.DataSourceID = null; // Remove any existing DataSourceID
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        // ISBN not found, show error message
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Book with ISBN searched not found');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
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