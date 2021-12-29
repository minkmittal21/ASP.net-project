using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace CollegeForum
{

    public partial class uploadSyllabus : System.Web.UI.Page
    {
        string connstring = "workstation id=dbforum.mssql.somee.com;packet size=4096;user id=tania007_SQLLogin_1;pwd=ssh5eso31z;data source=dbforum.mssql.somee.com;persist security info=False;initial catalog=dbforum";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gvBind();
                //string connstring = "Data Source=DESKTOP-808B1S5;Initial Catalog=db_schoolforum;User ID=sa;Password=tania";
                SqlConnection sqlConn = new SqlConnection(connstring);
                sqlConn.Open();
                string querystream = "select * from dbo.stream";
                string querysemester = "select * from dbo.semester";
                SqlCommand com1 = new SqlCommand(querystream, sqlConn);
                SqlCommand com2 = new SqlCommand(querysemester, sqlConn);
                SqlDataAdapter da1 = new SqlDataAdapter(com1);
                SqlDataAdapter da2 = new SqlDataAdapter(com2);
                DataSet ds1 = new DataSet();
                DataSet ds2 = new DataSet();
                da1.Fill(ds1);
                da2.Fill(ds2);
                DropDownListStream.DataTextField = ds1.Tables[0].Columns["streamDisplayName"].ToString();
                DropDownListStream.DataValueField = ds1.Tables[0].Columns["id"].ToString();
                DropDownListStream.DataSource = ds1.Tables[0];
                DropDownListStream.DataBind();
                DropDownListSemester.DataTextField = ds2.Tables[0].Columns["semesterDisplayName"].ToString();
                DropDownListSemester.DataValueField = ds2.Tables[0].Columns["semesterDisplayName"].ToString();
                DropDownListSemester.DataSource = ds2.Tables[0];
                DropDownListSemester.DataBind();
            }
        }
        protected void ButtonStreamSave_Click(object sender, EventArgs e)
        {
            string stream = TextstreamName.Text;
            if (stream.Length == 0)
            {
                streamError.ForeColor = System.Drawing.Color.Red;
                streamError.Text = "Enter A value";
            }
            else
            {
                //string connstring = "Data Source=DESKTOP-808B1S5;Initial Catalog=db_schoolforum;User ID=sa;Password=tania";
                SqlConnection sqlConn = new SqlConnection(connstring);
                sqlConn.Open();
                string query = "insert into dbo.stream (streamDisplayName)" + " values (@stream)"; //insert query  
                SqlCommand com = new SqlCommand(query, sqlConn);
                com.Parameters.AddWithValue("@stream", stream);
                com.ExecuteNonQuery();
                streamError.ForeColor = System.Drawing.Color.Green;
                streamError.Text = "Added";
                Response.Redirect(Request.Url.ToString());
            }

        }
        void clear()
        {
            TextSyllabusName.Text = "";
            DropDownListStream.SelectedValue = "";
            DropDownListSemester.SelectedValue = "";
        }
        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            LabelFileUpload.Visible = true;
            string syllabusName = TextSyllabusName.Text;
            string filePath = FileUpload1.PostedFile.FileName; // getting the file path of uploaded file  
            string filename1 = Path.GetFileName(filePath); // getting the file name of uploaded file  
            string ext = Path.GetExtension(filename1); // getting the file extension of uploaded file  
            string type = String.Empty;
            if (!FileUpload1.HasFile)
            {
                LabelFileUpload.Text = "Please Select File"; //if file uploader has no file selected  
            }
            else
            if (FileUpload1.HasFile)
            {
                try
                {
                    switch (ext) // this switch code validate the files which allow to upload only PDF file   
                    {
                        case ".pdf":
                            type = "application/pdf";
                            break;
                    }
                    if (type != String.Empty)
                    {
                        //string connstring = "Data Source=DESKTOP-808B1S5;Initial Catalog=db_schoolforum;User ID=sa;Password=tania";
                        SqlConnection sqlConn = new SqlConnection(connstring);
                        sqlConn.Open();
                        Stream fs = FileUpload1.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs); //reads the binary files  
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length); //counting the file length into bytes  
                        string query = "insert into dbo.syllabus_new (semester,dataUpload,syllabusName,streamId,fileName)" + " values (@semester,@dataUpload, @syllabusName, @streamId,@fileName)"; //insert query  
                        SqlCommand com = new SqlCommand(query, sqlConn);
                        System.Diagnostics.Debug.WriteLine("bytes");
                        System.Diagnostics.Debug.WriteLine(bytes);
                        System.Diagnostics.Debug.WriteLine(filePath);
                        com.Parameters.Add("@fileName", SqlDbType.VarChar).Value = filename1;
                        //com.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
                        String semester;
                        if (DropDownListSemester.SelectedItem.Value == "")
                        {
                            semester = "";
                        }
                        else
                        {
                            semester = DropDownListSemester.SelectedItem.Value;
                        }
                        com.Parameters.AddWithValue("@semester", DropDownListSemester.SelectedItem.Value);
                        com.Parameters.Add("@dataUpload", SqlDbType.Binary).Value = bytes;
                        com.Parameters.AddWithValue("@syllabusName", syllabusName);
                        com.Parameters.AddWithValue("@streamId", Convert.ToInt32(DropDownListStream.SelectedItem.Value));

                        com.ExecuteNonQuery();
                        clear();
                        LabelFileUpload.ForeColor = System.Drawing.Color.Green;
                        LabelFileUpload.Text = "File Uploaded Successfully";
                        gvBind();
                    }
                    else
                    {
                        LabelFileUpload.ForeColor = System.Drawing.Color.Red;
                        LabelFileUpload.Text = "Select Only PDF Files "; // if file is other than speified extension   
                    }
                }
                catch (Exception ex)
                {
                    LabelFileUpload.Text = "Error: " + ex.Message.ToString();
                }
            }
        }

        protected void gvBind()
        {
            using (SqlConnection con = new SqlConnection(connstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT id_syllabus,semester, dataUpload, syllabusName, dbo.stream.streamDisplayName as streamId, fileName FROM dbo.syllabus_new LEFT JOIN dbo.stream ON dbo.syllabus_new.streamId=dbo.stream.ID", con); //AddedControl join here
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            using (SqlConnection con = new SqlConnection(connstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from dbo.syllabus_new where id_syllabus='" + id + "'", con);
                int t = cmd.ExecuteNonQuery();
                GridView1.EditIndex = -1;
                gvBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand com = new SqlCommand("select fileName,dataUpload from dbo.syllabus_new where id_syllabus=@id", con);
            com.Parameters.AddWithValue("id", GridView1.SelectedRow.Cells[0].Text);
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