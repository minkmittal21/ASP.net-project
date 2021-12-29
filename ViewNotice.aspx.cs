using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace CollegeForum
{
    public partial class ViewNotice : System.Web.UI.Page
    {
        string connstring = "workstation id=dbforum.mssql.somee.com;packet size=4096;user id=tania007_SQLLogin_1;pwd=ssh5eso31z;data source=dbforum.mssql.somee.com;persist security info=False;initial catalog=dbforum";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection sqlConn = new SqlConnection(connstring);
                sqlConn.Open();
                string querycategory = "select * from dbo.noticeCategory";
                SqlCommand com1 = new SqlCommand(querycategory, sqlConn);
                SqlDataAdapter da1 = new SqlDataAdapter(com1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                DropDownListCategory.DataTextField = ds1.Tables[0].Columns["category"].ToString();
                DropDownListCategory.DataValueField = ds1.Tables[0].Columns["id"].ToString();
                DropDownListCategory.DataSource = ds1.Tables[0];
                DropDownListCategory.DataBind();
                viewAll();

            }
        }
        protected void viewAll()
        {
            using (SqlConnection con = new SqlConnection(connstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT dbo.notice.id as id,heading,description_notice, uploadedOn, notice_file_name, dbo.noticeCategory.category FROM dbo.notice LEFT JOIN dbo.noticeCategory ON dbo.notice.category=dbo.noticeCategory.id order by uploadedOn desc ", con);
                DataList1.DataSource = cmd.ExecuteReader();
                DataList1.DataBind();
            }
        }
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListCategory.SelectedItem.Value != "")
            {
                int category = Convert.ToInt32(DropDownListCategory.SelectedItem.Value);
                using (SqlConnection con = new SqlConnection(connstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT dbo.notice.id,heading,description_notice, uploadedOn, notice_file_name, dbo.noticeCategory.category FROM dbo.notice LEFT JOIN dbo.noticeCategory ON dbo.notice.category=dbo.noticeCategory.id where dbo.notice.category=@category order by uploadedOn desc ", con);
                    cmd.Parameters.AddWithValue("@category", category);
                    DataList1.DataSource = cmd.ExecuteReader();
                    DataList1.DataBind();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            viewAll();
        }
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                int fileID = Convert.ToInt32(e.CommandArgument);
                SqlConnection con = new SqlConnection(connstring);
                con.Open();
                SqlCommand com = new SqlCommand("select notice_file_name,noticeUpload from dbo.notice where id=@id", con);
                com.Parameters.AddWithValue("id", fileID);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=" + dr["notice_file_name"].ToString());
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite((byte[])dr["noticeUpload"]);
                    Response.End();
                }
            }
        }
    }
}