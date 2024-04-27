using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Security.Policy;

namespace dotnet_project.MPage
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=ProjectDB; Integrated Security=True; Pooling=False");

            try
            {
                con.Open();
                SqlCommand insertCommand = new SqlCommand("SELECT * FROM Book", con);
                SqlDataReader reader = insertCommand.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", dt));
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("ReportLibrary.rdlc");
                ReportViewer1.LocalReport.EnableHyperlinks = true;

                reader.Close();
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
    }
}