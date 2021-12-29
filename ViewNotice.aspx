<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewNotice.aspx.cs" Inherits="CollegeForum.ViewNotice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
   
    <style>
      .box{
        box-shadow: 0 0 10px gray;
        padding:20px 20px 20px 20px;
        border-radius: 5px;
        margin-top:20px;
        width:1000px;
      }
      .heading{
        display:inline;
        
      }
      .description{
        padding-top: 30px;
      }
      .heading1{
          color:aqua;
          background-color:black;
      }
      .head{
         text-align:center;
         background-color:aqua;
         color:black;
      }
      .box{
           background-color:black;
           color:aqua;
       }
    </style>

        <div class="head">
            <h1 class="heading1"><center>Notice Board</center></h1>
            <asp:DropDownList ID="DropDownListCategory" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="OnSelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Selected="True" Text="" Value="">Select Category</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="View All" />
            <hr />
            <asp:DataList ID="DataList1" runat="server"  OnItemCommand="DataList1_ItemCommand" >
                <ItemTemplate>
                    <div class="container">
      <div class="row">
        <div class="col-md-2" ></div>
        <div class="col-md-10">
          <div class="box">
            <div class="row">
            <div class="col-md-2">
            <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-card-text" viewBox="0 0 16 16">
              <path d="M14.5 3a.5.5 0 0 1 .5.5v9a.5.5 0 0 1-.5.5h-13a.5.5 0 0 1-.5-.5v-9a.5.5 0 0 1 .5-.5h13zm-13-1A1.5 1.5 0 0 0 0 3.5v9A1.5 1.5 0 0 0 1.5 14h13a1.5 1.5 0 0 0 1.5-1.5v-9A1.5 1.5 0 0 0 14.5 2h-13z"/>
              <path d="M3 5.5a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5zM3 8a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9A.5.5 0 0 1 3 8zm0 2.5a.5.5 0 0 1 .5-.5h6a.5.5 0 0 1 0 1h-6a.5.5 0 0 1-.5-.5z"/>
            </svg>
          </div>
          <div class="col-md-6">
            <h3 class="heading"><%#Eval("heading") %></h3>
          </div>
                <hr />
        </div>
        <div class="row description" >
          <div class="col-md-1"></div>
          <div class="col">
            <h5><%#Eval("description_notice")!=null?Eval("description_notice"):""%></h5>
          </div>
        </div>
        <div class="row">
          <div class="col-md-1"></div>
          <div class="col">
              <asp:LinkButton ID="lbtnDownload" CommandName="Download" CommandArgument=<%#Eval("id") %> runat="server"><%#Eval("notice_file_name")%></asp:LinkButton>             
          </div>
        </div>
        <div class="row">
          <div class="col">
            <p>UploadedOn: <%# Eval("uploadedOn", "{0:dd/MM/yyyy}")%></p>
          </div>
        </div>
          </div>
        </div>
      </div>
    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
 
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

</asp:Content>
