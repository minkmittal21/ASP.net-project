using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollegeForum
{
    public partial class usersignup : System.Web.UI.Page
    {
        //strcon contains the connection string which is created in web.congfig file
        //string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        //string strcon = "Data Source=LAPTOP-PL3CQC7S;Initial Catalog=collegeForumsDb;User ID=mink;Pwd=mink21;";
        string strcon = "workstation id=dbforum.mssql.somee.com;packet size=4096;user id=tania007_SQLLogin_1;pwd=ssh5eso31z;data source=dbforum.mssql.somee.com;persist security info=False;initial catalog=dbforum";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //sign up button click event
        protected void Button1_Click(object sender, EventArgs e)
        {
           if(checkMemberExists())
            {
                Response.Write("<script>alert('Member already exists with this member ID. Try other Id.');</script>");
            }
           else
            {
                signUpNewMember();
            }
        }
        bool checkMemberExists()
        {
            try
            {
                //con object is created of sqlconnection type and strcon is the parameter we are passing
                SqlConnection con = new SqlConnection(strcon);
                //testing if connection is open or not
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //It takes two parameters 1st one is entire sql query and second parameter is connection object that we have created
                SqlCommand cmd = new SqlCommand("SELECT * FROM sign_up where member_id='"+TextBox8.Text.Trim()+"';", con);
                //This is again a database connectivity in a disconnected way. This means when the sql query is fired. The connection will automatically get disconnected.
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //Now we will use this adaptor to built the inbuilt table
                DataTable dt = new DataTable();
                //This table contains the rows if query gives more than 1 rows. This table is inside the program only.
                    da.Fill(dt);
                if (dt.Rows.Count >= 1)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");
                return false;
            }

           
        }
        void signUpNewMember()
        {
            try
            {
                //con object is created of sqlconnection type and strcon is the parameter we are passing
                SqlConnection con = new SqlConnection(strcon);
                //testing if connection is open or not
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //It takes two parameters 1st one is entire sql query and second parameter is connection object that we have created
                SqlCommand cmd = new SqlCommand("insert into sign_up(full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,roles) VALUES(@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@roles )", con);
                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@roles", "user");


                //firing the query
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Sign up successful. Go to login page to login. ');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");
            }
        }
    
    }
}