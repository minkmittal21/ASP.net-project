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

    public partial class uploadNotes : System.Web.UI.Page
    {
        string connstring = "workstation id=dbforum.mssql.somee.com;packet size=4096;user id=tania007_SQLLogin_1;pwd=ssh5eso31z;data source=dbforum.mssql.somee.com;persist security info=False;initial catalog=dbforum";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                //string connstring = "Data Source=DESKTOP-808B1S5;Initial Catalog=db_schoolforum;User ID=sa;Password=tania";
                SqlConnection sqlConn = new SqlConnection(connstring);
                sqlConn.Open();
                string querystream = "select * from dbo.stream";
                string querysemester = "select * from dbo.semester";
                string queryStream = "select * from dbo.sessionYear";
                SqlCommand com1 = new SqlCommand(querystream, sqlConn);
                SqlCommand com2 = new SqlCommand(querysemester, sqlConn);
                SqlCommand com3 = new SqlCommand(queryStream, sqlConn);
                SqlDataAdapter da1 = new SqlDataAdapter(com1);
                SqlDataAdapter da2 = new SqlDataAdapter(com2);
                SqlDataAdapter da3 = new SqlDataAdapter(com3);
                DataSet ds1 = new DataSet();
                DataSet ds2 = new DataSet();
                DataSet ds3 = new DataSet();
                da1.Fill(ds1);
                da2.Fill(ds2);
                da3.Fill(ds3);
                DropDownListStream.DataTextField = ds1.Tables[0].Columns["streamDisplayName"].ToString();
                DropDownListStream.DataValueField = ds1.Tables[0].Columns["id"].ToString();
                DropDownListStream.DataSource = ds1.Tables[0];
                DropDownListStream.DataBind();
                DropDownListSemester.DataTextField = ds2.Tables[0].Columns["semesterDisplayName"].ToString();
                DropDownListSemester.DataValueField = ds2.Tables[0].Columns["semesterDisplayName"].ToString();
                DropDownListSemester.DataSource = ds2.Tables[0];
                DropDownListSemester.DataBind();
                DropDownListSession.DataTextField = ds3.Tables[0].Columns["sessionDisplayName"].ToString();
                DropDownListSession.DataValueField = ds3.Tables[0].Columns["sessionDisplayName"].ToString();
                DropDownListSession.DataSource = ds3.Tables[0];
                DropDownListSession.DataBind();
            }
        }

        protected void ButtonUpload_Click(object sender, EventArgs e)
        {

            LabelFileUpload.Visible = true;
            string NotesHeading = TextNotesName.Text;
            string uploadedBy = TextUploadByName.Text;
            string subjectName = TextSubject.Text;
            string filePath = FileUpload.PostedFile.FileName; // getting the file path of uploaded file  
            string filename1 = Path.GetFileName(filePath); // getting the file name of uploaded file  
            string ext = Path.GetExtension(filename1); // getting the file extension of uploaded file  
            string type = String.Empty;
            if (!FileUpload.HasFile)
            {
                LabelFileUpload.Text = "Please Select File"; //if file uploader has no file selected  
            }
            else
            if (FileUpload.HasFile)
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
                        Stream fs = FileUpload.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs); //reads the binary files  
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length); //counting the file length into bytes  
                        string query = "insert into dbo.notes (semester,subjectName,uploadedBy,sessionYear,notesUpload,notesName,streamId)" +
                            " values (@semester,@subjectName,@uploadedBy,@session,@dataUpload, @NotesHeading, @streamId)"; //insert query  
                                                                                                                           //DOTO date ,add column filename
                        SqlCommand com = new SqlCommand(query, sqlConn);
                        System.Diagnostics.Debug.WriteLine("bytes");
                        //com.Parameters.Add("@fileName", SqlDbType.VarChar).Value = filename1;
                        com.Parameters.AddWithValue("@semester", DropDownListSemester.SelectedItem.Value);
                        com.Parameters.Add("@dataUpload", SqlDbType.Binary).Value = bytes;
                        com.Parameters.AddWithValue("@NotesHeading", NotesHeading);
                        com.Parameters.AddWithValue("@subjectName", subjectName);
                        com.Parameters.AddWithValue("@uploadedBy", uploadedBy);
                        com.Parameters.AddWithValue("@streamId", Convert.ToInt32(DropDownListStream.SelectedItem.Value));
                        com.Parameters.AddWithValue("@session", DropDownListSession.SelectedItem.Value);
                        com.ExecuteNonQuery();
                        LabelFileUpload.ForeColor = System.Drawing.Color.Green;
                        LabelFileUpload.Text = "File Uploaded Successfully";
                        gvBind();
                    }
                    else
                    {
                        LabelFileUpload.ForeColor = System.Drawing.Color.Red;
                        LabelFileUpload.Text = "Select Only PDF Files "; // if file is other than speified extension   
                        gvBind();
                    }
                }
                catch (Exception ex)
                {
                    LabelFileUpload.Text = "Error: " + ex.Message.ToString();
                }
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
        protected void gvBind()
        {
            using (SqlConnection con = new SqlConnection(connstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT dbo.notes.id,semester,subjectName,uploadedBy,notesName,uploadedOn,sessionYear,dbo.stream.streamDisplayName as stream FROM dbo.notes LEFT JOIN dbo.stream ON dbo.notes.streamId=dbo.stream.ID", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand com = new SqlCommand("select notesName,notesUpload from dbo.notes where id=@id", con);
            com.Parameters.AddWithValue("id", GridView1.SelectedRow.Cells[0].Text);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + dr["notesName"].ToString());
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite((byte[])dr["notesUpload"]);
                Response.End();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            using (SqlConnection con = new SqlConnection(connstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from dbo.notes where id='" + id + "'", con);
                int t = cmd.ExecuteNonQuery();
                GridView1.EditIndex = -1;
                gvBind();
            }
        }
    }
}