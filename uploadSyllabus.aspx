<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="uploadSyllabus.aspx.cs" Inherits="CollegeForum.uploadSyllabus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   

     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
   
    <style type="text/css">
        .auto-style1 {
            width: 225px;
        }
        .auto-style2 {
            width: 225px;
            height: 31px;
        }
        .auto-style3 {
            height: 31px;
        }
        .auto-style4 {
            width: 225px;
            height: 27px;
        }
        .auto-style5 {
            height: 27px;
        }
         #form1 {
            background-color: lightgreen;
        }
          table {
            background: white;
            margin-left: auto;
            margin-right: auto;
            font-size: 20px;
            border: 3px solid black;
            font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
        }
          .body{
              background-color:lightgreen;
          }
           .col {
            font-family: Book Antiqua;
            color: lightgreen;
            background-color: black;
            
        }
           
        .table1 td {
            padding: 7px;
            border-radius: 12px;
        }
        .table2 td {
            padding: 7px;
            border-radius: 12px;
           
        }
         .table2
       {
           padding:0;
           border:0;
           margin:0;
           font-size:0px;
       }
    </style>


    <div id="form1" clas="body">
         
         <div class="col">
            <center>
                <h1>
                     Enter Syllabus Details and upload file 
          </h1>
            </center>
        </div>
                
           <br /><br />
             <table>  
            <tr>
                <td class="auto-style1"><asp:Label ID="Label2" runat="server" Text="Enter Syllabus Heading/Name"></asp:Label></td>
                <td>
                    <asp:TextBox ID="TextSyllabusName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextSyllabusName" ErrorMessage="Please Enter Heading for this Syllabus"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"><asp:Label ID="streamName" runat="server" Text="Choose Stream*"></asp:Label></td>
                <td><asp:DropDownList ID="DropDownListStream" runat="server" AppendDataBoundItems="true">
                    <asp:ListItem Selected="True" Text="" Value="">Select Stream</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Button3" runat="server" Text="Add Stream"  class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownListStream" ErrorMessage="Please Choose a Stream"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <asp:Panel runat="server" class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <asp:Panel runat="server"  class="modal-dialog">
    <asp:Panel runat="server" class="modal-content">
      <asp:Panel runat="server" class="modal-header">
        <h5 runat="server" class="modal-title" id="exampleModalLabel">Add Stream</h5>
        <asp:Button runat="server" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></asp:Button>
      </asp:Panel>
      <asp:Panel runat="server" class="modal-body">
        <asp:Label runat="server" Text="Enter Stream Name"></asp:Label>
          <asp:TextBox ID="TextstreamName" runat="server"></asp:TextBox>
      </asp:Panel>
        <asp:Label ID="streamError" runat="server" Text=""></asp:Label>
      <asp:Panel runat="server" class="modal-footer">
          <asp:Button ID="Button1" runat="server" Text="Close" class="btn btn-secondary" data-bs-dismiss="modal" />
          <asp:Button ID="Button4" runat="server" Text="Save Stream" class="btn btn-primary" CausesValidation="False" onclick="ButtonStreamSave_Click" />
      </asp:Panel>
    </asp:Panel>
  </asp:Panel>
</asp:Panel>
            <tr>
               <td class="auto-style4"><asp:Label ID="semester" runat="server" Text="Choose Semester"></asp:Label></td>
                <td class="auto-style5"><asp:DropDownList ID="DropDownListSemester" runat="server" AppendDataBoundItems="true">
                    <asp:ListItem Selected="True" Text="" Value="">Select Semester</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="auto-style2"><asp:Label ID="Label1" runat="server" Text="Upload pdf file*"></asp:Label></td>
                <td class="auto-style3"><asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Select Only Excel File"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Please select a file"></asp:RequiredFieldValidator>
                </td>
                
            </tr>
            <tr>
                <td class="auto-style1"><asp:Button ID="ButtonUpload" runat="server" Text="Submit" onclick="ButtonUpload_Click" /></td>
            </tr>
            </table>
        <br /><br />
            <table class="table2">  
            <tr>  
                <td>  
                    <p>  
                        <asp:Label ID="LabelFileUpload" runat="server" Text=""></asp:Label>  
                    </p>  
                </td>  
            </tr>  
        </table>

          
         
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"  ForeColor="#333333" GridLines="None" DataKeyNames="id_syllabus" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="id_syllabus" HeaderText="Id" />
                <asp:BoundField DataField="streamId" HeaderText="Stream" SortExpression="streamId" />
                <asp:BoundField DataField="semester" HeaderText="Semester" SortExpression="semester" />
                <asp:BoundField DataField="syllabusName" HeaderText="Syllabus Name" SortExpression="syllabusName" />
                <asp:BoundField DataField="fileName" HeaderText="File Name" SortExpression="fileName" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True">
                <ControlStyle BackColor="#CC3300" Font-Bold="True" ForeColor="White" />
                </asp:CommandField>
                <asp:CommandField SelectText="Download" ShowSelectButton="True">
                <ControlStyle ForeColor="#6699FF" />
                </asp:CommandField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <%--<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:db_schoolforumConnectionString %>" SelectCommand="SELECT [semester], [dataUpload], [syllabusName], [streamId], [fileName] FROM [syllabus_new]"></asp:SqlDataSource>--%>
    </div>
         
        
</asp:Content>
