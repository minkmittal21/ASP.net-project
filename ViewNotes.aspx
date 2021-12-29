<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewNotes.aspx.cs" Inherits="CollegeForum.ViewNotes" %>
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
      .head{
          text-align:center;
          background-color:grey;
          color:white;
      }
      .top1{
          background-color:grey;
          text-align:center;
      }
      .box{
          background-color:white;
          color:deeppink;
      }
      .row{
          text-align:center;
      }
    </style>
        <div class="top1">
            <h1 class="head">Download Notes</h1>
            <asp:DropDownList ID="DropDownListStream" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="OnSelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Selected="True" Text="" Value="">Select Stream</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="View All" />
            <hr />
            <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand" >
            <ItemTemplate>
            <div class="container">
      <div class="row">
        <div class="col-md-1" ></div>
        <div class="col-md-8">
          <div class="box">
            <div class="row">
            <div class="col-md-2">
              <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-book" viewBox="0 0 16 16">
                <path d="M1 2.828c.885-.37 2.154-.769 3.388-.893 1.33-.134 2.458.063 3.112.752v9.746c-.935-.53-2.12-.603-3.213-.493-1.18.12-2.37.461-3.287.811V2.828zm7.5-.141c.654-.689 1.782-.886 3.112-.752 1.234.124 2.503.523 3.388.893v9.923c-.918-.35-2.107-.692-3.287-.81-1.094-.111-2.278-.039-3.213.492V2.687zM8 1.783C7.015.936 5.587.81 4.287.94c-1.514.153-3.042.672-3.994 1.105A.5.5 0 0 0 0 2.5v11a.5.5 0 0 0 .707.455c.882-.4 2.303-.881 3.68-1.02 1.409-.142 2.59.087 3.223.877a.5.5 0 0 0 .78 0c.633-.79 1.814-1.019 3.222-.877 1.378.139 2.8.62 3.681 1.02A.5.5 0 0 0 16 13.5v-11a.5.5 0 0 0-.293-.455c-.952-.433-2.48-.952-3.994-1.105C10.413.809 8.985.936 8 1.783z"/>
              </svg>
          </div>
          <div class="col-md-6">
            <h3 class="heading"><%#Eval("notesName") %></h3>
          </div>
        </div>
        <div class="row description" >
          <div class="col-md-1"></div>
          <div class="col">
            <h6>Stream-<%#Eval("stream")%>  Session- <%#Eval("sessionYear")%></h6>
            <h6>Semester- <%#Eval("semester") %></h6>
            <h6>Subject- <%#Eval("subjectName") %></h6>
          </div>
        </div>
        <div class="row">
          <div class="col-md-1"></div>
          <div class="col">
              <asp:LinkButton ID="lbtnDownload" CommandName="Download" CommandArgument=<%#Eval("id") %> runat="server">Download</asp:LinkButton>
            
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
            <asp:Label ID="LabelData" runat="server" Text=""></asp:Label> 
        </div>
   
</asp:Content>
