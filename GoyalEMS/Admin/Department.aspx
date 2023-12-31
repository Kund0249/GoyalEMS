﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="GoyalEMS.Admin.Department" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EMS-Department</title>
    <link href="../Content/CSS/bootstrap.css" rel="stylesheet" />

    <link href="../ClientLib/toastr.css" rel="stylesheet" />

    <script src="../ClientLib/jquery.js"></script>
    <script src="../ClientLib/toastr.min.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row bg-primary">
                <div class="wells">
                    <h2 class="text-center text-white">Goyal InfoTech Departmetn</h2>
                </div>
            </div>


            <div class="row">
               <%-- <asp:Label runat="server" ID="lblDepartmentId"></asp:Label>--%>
                <asp:HiddenField runat="server" ID="HdfDepartmentId" />
                <div class="col-md-6 offset-3">
                    <table class="table">
                        <tr>
                            <th>Department Name</th>
                            <td>
                                <asp:TextBox runat="server" ID="txtDepartmentName"
                                    CssClass="form-control">

                                </asp:TextBox>
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
                                    CssClass="btn btn-danger" 
                                    OnClick="btnCancel_Click"/>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <hr />
            <div class="row">
                <div class="col-md-6 offset-3">

                    <asp:GridView runat="server" 
                        ID="DeptGrid" AutoGenerateColumns="false"
                        CssClass="table"
                        OnSelectedIndexChanged="DeptGrid_SelectedIndexChanged"
                        DataKeyNames="DeptId">
                        <Columns>
                            <asp:BoundField HeaderText="Department Code" DataField="DeptId" />
                            <asp:BoundField HeaderText="Department Name" DataField="DepartmentName" />
                            <asp:CommandField HeaderText="Action" ShowSelectButton="true"
                                SelectText="Edit" ButtonType="Button"
                                ControlStyle-CssClass="btn btn-primary"/>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
