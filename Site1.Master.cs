using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollegeForum
{
    public partial class Site1 : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"]==null)
            {
                LinkButton1.Visible = true;   //login link button
                LinkButton2.Visible = true;   //sign up link button

                LinkButton3.Visible = false;   //logout link button
                LinkButton4.Visible = false;   //Hello user link button
                LinkButton11.Visible = false;
                LinkButton12.Visible = false;
                LinkButton13.Visible = false;
                LinkButton14.Visible = false;
                LinkButton15.Visible = false;
                LinkButton16.Visible = false;

            }
            else if(Session["role"].Equals("user"))
            {
                LinkButton9.Visible = true;   //view syllabus link
                LinkButton8.Visible = true;   //view notice link
                LinkButton10.Visible = true;  //view notes link
                LinkButton1.Visible = false;   //login link button
                LinkButton2.Visible = false;   //sign up link button

                LinkButton3.Visible = true;   //logout link button
                LinkButton4.Visible = true;   //Hello user link button
                LinkButton11.Visible = false;
                LinkButton12.Visible = false;
                LinkButton13.Visible = false; 
                LinkButton14.Visible = true;
                LinkButton15.Visible = true;
                LinkButton16.Visible = true;
                LinkButton4.Text = "Hello, " + Session["full_name"].ToString();

            }
            else if(Session["role"].Equals("admin"))
            {
                LinkButton1.Visible = false;   //login link button
                LinkButton2.Visible = false;   //sign up link button

                LinkButton3.Visible = true;   //logout link button
                LinkButton4.Visible = true;   //Hello user link button
                LinkButton5.Visible = true; //Notice Board link button
                LinkButton6.Visible = true;   //notes linkbutton
                LinkButton7.Visible = true;   //syllabus linkbutton
                LinkButton11.Visible = true;
                LinkButton12.Visible = true;
                LinkButton13.Visible = true;
                LinkButton14.Visible = false;
                LinkButton15.Visible = false;
                LinkButton16.Visible = false;

                LinkButton4.Text = "Hello, Admin";

            }


            //catch(Exception ex)
            // {
            //    Response.Write("<script>alert(' " + ex.Message + " ');</script>");
            // }


        }

        //login linkbutton
        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            Response.Redirect("userlogin.aspx");

        }

        //signup link button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");

        }

        //logout linkbutton
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
          // Session["username"] = "";
            Session["full_name"] = "";
            Session["role"] = "";
            LinkButton1.Visible = true;   //login link button
            LinkButton2.Visible = true;   //sign up link button

            LinkButton3.Visible = false;   //logout link button
            LinkButton4.Visible = false;   //Hello user link button
            LinkButton5.Visible = false;
            LinkButton6.Visible = false;
            LinkButton7.Visible = false;  //syllabus link button
            LinkButton8.Visible = false;   //view notice link
            LinkButton9.Visible = false;  //view syllabus link
            LinkButton10.Visible = false;  //view notes link
            LinkButton11.Visible = false;
            LinkButton12.Visible = false;
            LinkButton13.Visible = false;
            LinkButton14.Visible = false;
            LinkButton15.Visible = false;
            LinkButton16.Visible = false;
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {

        }
        //noticeboard linkbutton
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("noticeBoard.aspx");

        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("uploadNotes.aspx");
        }
        //syllabus link button
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("uploadSyllabus.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewNotice.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewSyllabus.aspx");

        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewNotes.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("uploadSyllabus.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("uploadNotes.aspx");
        }

        protected void LinkButton13_Click(object sender, EventArgs e)
        {
            Response.Redirect("noticeBoard.aspx");
        }

        protected void LinkButton14_Click(object sender, EventArgs e)
        {

            Response.Redirect("ViewNotes.aspx");

        }

        protected void LinkButton15_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewSyllabus.aspx");
        }

        protected void LinkButton16_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewNotice.aspx");
        }
    }
}