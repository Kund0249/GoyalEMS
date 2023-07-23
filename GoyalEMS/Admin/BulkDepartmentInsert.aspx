<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulkDepartmentInsert.aspx.cs" Inherits="GoyalEMS.Admin.BulkDepartmentInsert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EMS-Department</title>
    <link href="../Content/CSS/bootstrap.css" rel="stylesheet" />

    <link href="../Content/toastr/toastr.css" rel="stylesheet" />

    <script src="../Content/Jquery/jquery.js"></script>
    <script src="../Content/toastr/toastr.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <<div class="container-fluid">
            <div class="row bg-primary">
                <div class="wells">
                    <h2 class="text-center text-white">Goyal InfoTech Departmetn</h2>
                </div>
            </div>


            <div class="row">
                <div class="col-md-6 offset-3">
                    <table class="table">
                        <tr>
                            <th>Department Name</th>
                            <td>
                                <span>
                                    <asp:TextBox runat="server" ID="txtDepartmentName"
                                        CssClass="form-control">
                                    </asp:TextBox>
                                </span>
                                 <asp:Button runat="server" ID="btnAdd"
                                        Text="Add"
                                        CssClass="btn btn-primary"
                                        OnClick="btnAdd_Click" />

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button runat="server" ID="btnSubmit"
                                    Text="Submit"
                                    CssClass="btn btn-primary"
                                    OnClick="btnSubmit_Click" />
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnCancel"
                                    Text="Reset"
                                    CssClass="btn btn-danger" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <hr />

            <div class="row">
                <div class="col-md-6 offset-3">
                    <asp:GridView runat="server" ID="DeptGrid"
                        CssClass="table">
                    </asp:GridView>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
