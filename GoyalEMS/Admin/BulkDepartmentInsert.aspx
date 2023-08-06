<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="BulkDepartmentInsert.aspx.cs" Inherits="GoyalEMS.Admin.BulkDepartmentInsert"
    MasterPageFile="~/AppLayout/AdminLayout.Master" %>

<asp:Content runat="server" ID="BulkDepartmentPage" ContentPlaceHolderID="childpages">

    <div class="row bg-primary">
        <div class="wells">
            <h2 class="text-center text-white">Goyal InfoTech Departmetn</h2>
        </div>
    </div>


    <div class="row">
        <div class="col-md-6">
            <table class="table">
                <tr>
                    <th>Department Name</th>
                    <td>

                        <asp:TextBox runat="server" ID="txtDepartmentName"
                            CssClass="form-control">
                        </asp:TextBox>



                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnAdd"
                            Text="Add"
                            CssClass="btn btn-primary"
                            OnClick="btnAdd_Click" />
                    </td>
                </tr>

            </table>
        </div>

        <div class="col-md-6">
            <table class="table">
                <tr>
                    <th>
                        <asp:FileUpload runat="server" ID="deptFile" 
                            CssClass="form-control"/>
                    </th>
                    <td>
                        <asp:Button runat="server" ID="btnUpload"
                            Text="Upload"
                            CssClass="btn btn-warning"
                            OnClick="btnUpload_Click"/>

                    </td>
                </tr>

            </table>
        </div>

    </div>
    <div class="row">
        <div class="col-6 offset-3">
            <div class="row">
                <div class="col-6">
                    <asp:Button runat="server" ID="btnSubmit"
                        Text="Submit"
                        CssClass="btn btn-primary"
                        OnClick="btnSubmit_Click" />
                </div>
                <div class="col-6">
                    <asp:Button runat="server" ID="btnreset"
                        Text="Rset"
                        CssClass="btn btn-danger" />
                </div>
            </div>

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


</asp:Content>



