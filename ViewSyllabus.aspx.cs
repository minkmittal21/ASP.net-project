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
    public partial class ViewSyllabus : System.Web.UI.Page
    {
        string connstring = "workstation id=dbforum.mssql.somee.com;packet size=4096;user id=tania007_SQLLogin_1;pwd=ssh5eso31z;data source=dbforum.mssql.somee.com;persist security info=False;initial catalog=dbforum";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection sqlConn = new SqlConnection(connstring);
                sqlConn.Open();
                string querystream = "select * from dbo.stream"; ;
                SqlCommand com1 = new SqlCommand(querystream, sqlConn);
                SqlDataAdapter da1 = new SqlDataAdapter(com1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                DropDownListStream.DataTextField = ds1.Tables[0].Columns["streamDisplayName"].ToString();
                DropDownListStream.DataValueField = ds1.Tables[0].Columns["id"].ToString();
                DropDownListStream.DataSource = ds1.Tables[0];
                DropDownListStream.DataBind();
                viewAll();

            }
        }
        protected void viewAll()
        {
            using (SqlConnection con = new SqlConnection(connstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT id_syllabus,semester, dataUpload, syllabusName,uploadedOn, dbo.stream.streamDisplayName as streamId, fileName FROM dbo.syllabus_new LEFT JOIN dbo.stream ON dbo.syllabus_new.streamId=dbo.stream.ID", con);
                DataList1.DataSource = cmd.ExecuteReader();
                DataList1.DataBind();
            }
        }
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListStream.SelectedItem.Value != "")
            {
                int stream = Convert.ToInt32(DropDownListStream.SelectedItem.Value);
                using (SqlConnection con = new SqlConnection(connstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT id_syllabus,semester, dataUpload, syllabusName,uploadedOn, dbo.stream.streamDisplayName as streamId, fileName FROM dbo.syllabus_new LEFT JOIN dbo.stream ON dbo.syllabus_new.streamId=dbo.stream.ID where dbo.syllabus_new.streamId=@stream", con);
                    cmd.Parameters.AddWithValue("@stream", stream);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataList1.DataSource = dr;
                    if (dr.HasRows == false)
                    {
                        LabelData.Text = "No Data Found";
                    }
                    else
                    {
                        LabelData.Text = "";
                    }
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
                SqlCommand com = new SqlCommand("select fileName,dataUpload from dbo.syllabus_new where id_syllabus=@id", con);
                com.Parameters.AddWithValue("id", fileID);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=" + dr["fileName"].ToString());
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite((byte[])dr["dataUpload"]);
                    Response.End();
                }
            }
        }
    }
}