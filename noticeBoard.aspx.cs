using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace CollegeForum
{
    public partial class noticeBoard : System.Web.UI.Page
    {
        string connstring = "workstation id=dbforum.mssql.somee.com;packet size=4096;user id=tania007_SQLLogin_1;pwd=ssh5eso31z;data source=dbforum.mssql.somee.com;persist security info=False;initial catalog=dbforum";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gvBind();
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
            }
        }
        void clear()
        {
            TextNoticeHeading.Text = "";
            TextDescription.Text = "";
            DropDownListCategory.SelectedValue = "";
        }
        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            LabelFileUpload.Visible = true;
            string noticeHeading = TextNoticeHeading.Text;
            string description = TextDescription.Text;
            string filePath = FileUpload.PostedFile.FileName;
            string filename1 = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename1);
            string type = String.Empty;
            if (!FileUpload.HasFile)
            {
                SqlConnection sqlConn = new SqlConnection(connstring);
                sqlConn.Open();
                string query = "insert into dbo.notice (heading,description_notice,uploadedBy,category)" +
                    " values (@heading,@description_notice, @uploadedBy, @category)";
                SqlCommand com = new SqlCommand(query, sqlConn);
                String category;
                if (DropDownListCategory.SelectedItem.Value == "")
                {
                    category = "";
                }
                else
                {
                    category = DropDownListCategory.SelectedItem.Value;
                }
                com.Parameters.AddWithValue("@heading", noticeHeading);
                com.Parameters.AddWithValue("@description_notice", description);
                com.Parameters.AddWithValue("@uploadedBy", "admin");
                com.Parameters.AddWithValue("@category", Convert.ToInt32(DropDownListCategory.SelectedItem.Value));

                com.ExecuteNonQuery();
                LabelFileUpload.ForeColor = System.Drawing.Color.Green;
                LabelFileUpload.Text = "Uploaded Successfully";
                clear();
                gvBind();
            }
            else
            if (FileUpload.HasFile)
            {
                switch (ext)
                {
                    case ".pdf":
                        type = "application/pdf";
                        break;
                }
                if (type != String.Empty)
                {
                    SqlConnection sqlConn = new SqlConnection(connstring);
                    sqlConn.Open();
                    Stream fs = FileUpload.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string query = "insert into dbo.notice (heading,description_notice,uploadedBy,category,noticeUpload,notice_file_name)" +
                        " values (@heading,@description_notice, @uploadedBy, @category,@dataUpload,@fileName)"; //insert query  
                    SqlCommand com = new SqlCommand(query, sqlConn);
                    com.Parameters.Add("@fileName", SqlDbType.VarChar).Value = filename1;
                    String category;
                    if (DropDownListCategory.SelectedItem.Value == "")
                    {
                        category = "";
                    }
                    else
                    {
                        category = DropDownListCategory.SelectedItem.Value;
                    }
                    com.Parameters.AddWithValue("@heading", noticeHeading);
                    com.Parameters.Add("@dataUpload", SqlDbType.Binary).Value = bytes;
                    com.Parameters.AddWithValue("@description_notice", description);
                    com.Parameters.AddWithValue("@uploadedBy", "admin");
                    com.Parameters.AddWithValue("@category", Convert.ToInt32(DropDownListCategory.SelectedItem.Value));

                    com.ExecuteNonQuery();
                    LabelFileUpload.ForeColor = System.Drawing.Color.Green;
                    LabelFileUpload.Text = "File Uploaded Successfully";
                    gvBind();
                    clear();
                }
                else
                {
                    LabelFileUpload.ForeColor = System.Drawing.Color.Red;
                    LabelFileUpload.Text = "Select Only PDF Files ";
                }
            }
        }
        protected void gvBind()
        {
            using (SqlConnection con = new SqlConnection(connstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT dbo.notice.id,heading,description_notice, uploadedOn, notice_file_name, dbo.noticeCategory.category FROM dbo.notice LEFT JOIN dbo.noticeCategory ON dbo.notice.category=dbo.noticeCategory.id", con); //AddedControl join here
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                }
            }
        }
        protected void ButtonCategorySave_Click(object sender, EventArgs e)
        {
            string category = TextcategoryName.Text;
            if (category.Length == 0)
            {
                categoryError.ForeColor = System.Drawing.Color.Red;
                categoryError.Text = "Enter A value";
            }
            else
            {
                SqlConnection sqlConn = new SqlConnection(connstring);
                sqlConn.Open();
                string query = "insert into dbo.noticeCategory (category)" + " values (@category)"; //insert query  
                SqlCommand com = new SqlCommand(query, sqlConn);
                com.Parameters.AddWithValue("@category", category);
                com.ExecuteNonQuery();
                categoryError.ForeColor = System.Drawing.Color.Green;
                categoryError.Text = "Added";
                Response.Redirect(Request.Url.ToString());
            }

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            using (SqlConnection con = new SqlConnection(connstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from dbo.notice where id='" + id + "'", con);
                int t = cmd.ExecuteNonQuery();
                GridView1.EditIndex = -1;
                gvBind();
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand com = new SqlCommand("select notice_file_name,noticeUpload from dbo.notice where id=@id", con);
            com.Parameters.AddWithValue("id", GridView1.SelectedRow.Cells[0].Text);
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