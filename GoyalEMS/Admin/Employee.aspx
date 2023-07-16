<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="GoyalEMS.Admin.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EMS-Employee</title>
    <link href="../Content/CSS/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-6 offset-3">
                    <table class="table">
                        <tr>
                            <th>Name</th>
                            <td>
                                <asp:TextBox runat="server"
                                    ID="txtName"
                                    CssClass="form-control">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>Gender</th>
                            <td>
                                <span><b>Male</b>
                                    <asp:RadioButton runat="server" ID="rdbMale"
                                        GroupName="Gender" />
                                </span>
                                <span><b>Female</b>
                                    <asp:RadioButton runat="server" ID="rdbFemale"
                                        GroupName="Gender" />
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <th>Email</th>
                            <td>
                                <asp:TextBox runat="server"
                                    ID="txtEmail"
                                    CssClass="form-control">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>Salary</th>
                            <td>
                                <asp:TextBox runat="server"
                                    ID="txtSalary"
                                    CssClass="form-control">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>DOB</th>
                            <td>
                                <asp:TextBox runat="server"
                                    ID="txtDOB"
                                    TextMode="Date"
                                    CssClass="form-control">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>DOJ</th>
                            <td>
                                <asp:TextBox runat="server"
                                    ID="txtDOJ"
                                    TextMode="Date"
                                    CssClass="form-control">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>Department</th>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlDepartment"
                                    CssClass="form-control">
                                   <%-- <asp:ListItem Value="-1">Select Department</asp:ListItem>
                                    <asp:ListItem Value="1">IT</asp:ListItem>
                                    <asp:ListItem Value="2">Pay ROll</asp:ListItem>
                                    <asp:ListItem Value="3">Sales</asp:ListItem>
                                    <asp:ListItem Value="4">HR</asp:ListItem>--%>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button runat="server" ID="btnSubmit" Text="Submit" 
                                    Width="100" CssClass="btn btn-primary"
                                    OnClick="btnSubmit_Click"/>
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnReset" Text="Reset Form" 
                                    Width="100" CssClass="btn btn-danger"/>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
