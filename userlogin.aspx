<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="CollegeForum.userlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     
    <style>
        .top
        {
            background-color:bisque;
            margin-bottom:0;
            margin-top:0;
            margin-right:0;
        }
        
        .color
        {
            color:red;
        }
    </style>

      <link href="css/customstylesheet.css" rel="stylesheet" />
    <div class="top">
       <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                   <div class="card-body">
                      <div class="row">
                        <div class="col">
                           <center>
                               <img width="100" src="imgs/generaluser.png"/>
                           </center>
                         </div>
                      </div>

                   <div class="row">
                      <div class="col">
                         <center>
                            <h3> Member Login</h3>
                          </center>
                       </div>
                    </div>
                     
               
                    </div>
                      <div class="row">
                        <div class="col">
                           <hr />
                        </div>
                     </div>

                    <div class="row">
                        <div class="col">
                            <label> Email</label>
                               <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" 
                                  placeholder="Member ID">
                                 </asp:TextBox>
                                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" CssClass="color" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="TextBox1" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="color" ControlToValidate="TextBox1" ErrorMessage="Please Enter email"></asp:RequiredFieldValidator>
                               </div>

                          <label> Password</label>
                             <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" 
                                  placeholder="Password" TextMode="Password"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="color" ControlToValidate="TextBox2" ErrorMessage="Please Enter password"></asp:RequiredFieldValidator>
                              </div><br />
                             <div class="form-group">
                                 <asp:Button class="btn btn-primary btn-block btn-lg btn-success" ID="Button1" runat="server"
                                     Text="Login" OnClick="Button1_Click" /><br />
                              </div><br />
                            <div class="form-group">
                                <a href="usersignup.aspx">
                                <input class="btn btn-info btn-block btn-lg" id="Button2" type="button" 
                                    value="sign Up" /></a>
                              </div>
                            </div>
                        </div>
                    </div>
                <a href="homepage.aspx"> <-Back to Home</a><br /><br />
            </div>
            
        </div>

    </div>
</div>
</asp:Content>