<%@ Page Title="" Language="C#" MasterPageFile="~/AppLayout/AdminLayout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GoyalEMS.Account.Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="childpages" runat="server">
    <div class="row mt-5">
        <div class="col-6 offset-3">
            <table class="table">
                <tr>
                    <th>User ADID</th>
                    <td>
                        <asp:TextBox runat="server" CssClass="form-control"
                            ID="txtADID"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>Password</th>
                    <td>
                        <asp:TextBox runat="server" CssClass="form-control"
                            ID="txtPassword"
                            TextMode="Password"
                            >
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th colspan="2">
                        <asp:Button runat="server" ID="btnLogin" Text="Login"
                            CssClass="btn btn-primary" 
                            OnClick="btnLogin_Click"/>
                    </th>
                </tr>
            </table>
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
    </div>
</asp:Content>
