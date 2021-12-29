<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="noticeBoard.aspx.cs" Inherits="CollegeForum.noticeBoard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
  
   
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    
    <style>
        #form1 {
            background-color: lightgrey;
        }
        table {
            background: grey;
            margin-left: auto;
            margin-right: auto;
            font-size: 20px;
            border: 3px solid blue;
            font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
        }
        .col {
            font-family: Book Antiqua;
            color: blue;
            background-color: grey;
            border: 3px solid blue;
        }
        .table1 td {
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


    <div id="form1">


        <div class="col">
            <center>
                <h1>Add Notice</h1>
            </center>
        </div>

        <br />



        <table class="table1">

            <tr>
                <td>
                    <asp:Label ID="LabelNoticeHeading" runat="server" Text="Enter Heading*"></asp:Label></td>
                <td>
                    <asp:TextBox ID="TextNoticeHeading" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextNoticeHeading" ErrorMessage="Please Enter Heading."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <br />
            <tr>
                <td>
                    <asp:Label ID="LabelDescription" runat="server" Text="Description"></asp:Label></td>
                <td>
                    <asp:TextBox ID="TextDescription" runat="server" placeholder="Enter Description, if any"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelCategory" runat="server" Text="Choose Category*"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownListCategory" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Selected="True" Text="" Value="">Select Category</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Button3" runat="server" Text="Add Category" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownListCategory" ErrorMessage="Please Choose a Category"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <asp:Panel runat="server" class="modal fade" ID="exampleModal" TabIndex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <asp:Panel runat="server" class="modal-dialog">
                    <asp:Panel runat="server" class="modal-content">
                        <asp:Panel runat="server" class="modal-header">
                            <h5 runat="server" class="modal-title" id="exampleModalLabel">Add Category</h5>
                            <asp:Button runat="server" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></asp:Button>
                        </asp:Panel>
                        <asp:Panel runat="server" class="modal-body">
                            <asp:Label runat="server" Text="Enter Category Name"></asp:Label>
                            <asp:TextBox ID="TextcategoryName" runat="server"></asp:TextBox>
                        </asp:Panel>
                        <asp:Label ID="categoryError" runat="server" Text=""></asp:Label>
                        <asp:Panel runat="server" class="modal-footer">
                            <asp:Button ID="Button1" runat="server" Text="Close" class="btn btn-secondary" data-bs-dismiss="modal" />
                            <asp:Button ID="Button4" runat="server" Text="Save Category" class="btn btn-primary" CausesValidation="False" OnClick="ButtonCategorySave_Click" />
                        </asp:Panel>
                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Upload pdf file"></asp:Label></td>
                <td>
                    <asp:FileUpload ID="FileUpload" runat="server" ToolTip="Select Only Pdf File" />
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonUpload" runat="server" Text="Submit" OnClick="ButtonUpload_Click" /></td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <table class="table2">
            <tr>
                <td>
                    <p>
                        <asp:Label ID="LabelFileUpload" runat="server" Text=""></asp:Label>
                    </p>
                </td>
            </tr>
        </table>

        <asp:GridView ID="GridView1" runat="server" DataKeyNames="id" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Id" />
                <asp:BoundField DataField="heading" HeaderText="Notice Heading" />
                <asp:BoundField DataField="description_notice" HeaderText="Description" />
                <asp:BoundField DataField="category" HeaderText="Category" />
                <asp:BoundField DataField="notice_file_name" HeaderText="File Name" />
                <asp:BoundField DataField="uploadedOn" HeaderText="Uploaded On" />
                <asp:CommandField SelectText="Download" ShowSelectButton="True">
                    <ControlStyle ForeColor="#3399FF" />
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