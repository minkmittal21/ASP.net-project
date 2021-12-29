<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="uploadNotes.aspx.cs" Inherits="CollegeForum.uploadNotes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <style>
        
         #form1 {
            background-color: lightpink;
            scroll-behavior: initial;
        }
         .col {
            font-family: Book Antiqua;
            color: blue;
            background-color:lightblue;
            
        }
         .table1 {
            background: lightblue;
            margin-left: auto;
            margin-right: auto;
            font-size: 20px;
            border: 3px solid blue;
            font-family: 'Franklin Gothic Medium','Arial Narrow', Arial, sans-serif;
        }
          
        .table1 td {
            padding: 7px;
            border-radius: 16px;
        }
    </style>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>

   
    <div id="form1">
        
            <div class="col">
            <center>
                <h1>
           Enter Notes Description, Upload Notes Files</h1>
            </center>
        </div>

        <br /><br /><br /><br /><br />
       


             <table class="table1">  
            <tr>
                <td><asp:Label ID="LabelNotesName" runat="server" Text="Enter Heading"></asp:Label></td>
                <td>
                    <asp:TextBox ID="TextNotesName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextNotesName" ErrorMessage="Please Enter Heading."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="LabelUploadByName" runat="server" Text="Uploaded By"></asp:Label></td>
                <td>
                    <asp:TextBox ID="TextUploadByName" runat="server" placeholder="Enter Your Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextUploadByName" ErrorMessage="Please Enter Your Name."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="streamName" runat="server" Text="Choose Stream*"></asp:Label></td>
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
               <td><asp:Label ID="semester" runat="server" Text="Choose Semester"></asp:Label></td>
                <td><asp:DropDownList ID="DropDownListSemester" runat="server" AppendDataBoundItems="true">
                    <asp:ListItem Selected="True" Text="" Value="">Select Semester</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
               <td><asp:Label ID="LabelSession" runat="server" Text="Choose Session Year"></asp:Label></td>
                <td><asp:DropDownList ID="DropDownListSession" runat="server" AppendDataBoundItems="true">
                    <asp:ListItem Selected="True" Text="" Value="">Select Session</asp:ListItem>
                    <asp:ListItem  Text="" Value="2020-21">2020-21</asp:ListItem>
                    <asp:ListItem  Text="" Value="2021-22">2021-22</asp:ListItem>
                    <asp:ListItem  Text="" Value="2022-23">2022-23</asp:ListItem>
                    <asp:ListItem  Text="" Value="2023-24">2023-24</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:Label ID="LabelSubject" runat="server" Text="Subject"></asp:Label></td>
                <td>
                    <asp:TextBox ID="TextSubject" runat="server" placeholder="Enter Subject Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextSubject" ErrorMessage="Please Enter Subject Name."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Upload pdf file*"></asp:Label></td>
                <td><asp:FileUpload ID="FileUpload" runat="server" ToolTip="Select Only Pdf File"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FileUpload" ErrorMessage="Please select a file"></asp:RequiredFieldValidator>
                </td>
                
            </tr>
            <tr>
                <td><asp:Button ID="ButtonUpload" runat="server" Text="Submit" onclick="ButtonUpload_Click" /></td>
            </tr>
            </table>
            <table>  
            <tr>  
                <td>  
                    <p>  
                       <asp:Label ID="LabelFileUpload" runat="server" Text=""></asp:Label>  
                    </p>  
                </td>  
            </tr>  
        </table>
        
                <%--<asp:button id="viewNotes" runat="server" text="View Notes" onclick="viewbutton_click" />--%>

            
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" ForeColor="#333333" GridLines="None" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Id" />
                <asp:BoundField DataField="notesName" HeaderText="Notes Name" />
                <asp:BoundField DataField="semester" HeaderText="Semester" />
                <asp:BoundField DataField="stream" HeaderText="Stream" />
                <asp:BoundField DataField="sessionYear" HeaderText="Session" />
                <asp:BoundField DataField="subjectName" HeaderText="Subject" />
                <asp:BoundField DataField="uploadedOn" HeaderText="Uploaded On" />
                <asp:BoundField DataField="uploadedBy" HeaderText="Uploaded By" />
                <asp:CommandField SelectText="Download" ShowSelectButton="True">
                <ControlStyle ForeColor="#6699FF" />
                </asp:CommandField>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True">
                <ControlStyle BackColor="#CC3300" ForeColor="White" />
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
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</asp:Content>
