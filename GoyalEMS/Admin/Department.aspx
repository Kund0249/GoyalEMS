<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Department.aspx.cs" Inherits="GoyalEMS.Admin.Department"
    MasterPageFile="~/AppLayout/AdminLayout.Master" %>


<asp:Content runat="server" ContentPlaceHolderID="childpages">
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
                            OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <hr />

    <div class="row">
        <div class="col-4">
        </div>
        <div class="col-4">
            <div class="row">
                <div class="col-8">
                    <asp:TextBox runat="server" 
                        ID="txtSearch" placeholder ="Search by Name"
                        CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-4">
                    <asp:Button Text="Search" runat="server" ID="btnSearch" 
                        CssClass="btn btn-primary"/>
                </div>
            </div>
        </div>
        <div class="col-4">
          
            <nav aria-label="Page navigation example">
                <ul class="pagination">
                    <li class="page-item">
                         <asp:LinkButton runat="server" Text="First" ID="btnlkFirst"
                           CssClass="page-link"
                           OnClick="btnlkFirst_Click">

                       </asp:LinkButton>
                    </li>
                    <li class="page-item">
                       <asp:LinkButton runat="server" Text="Prev" ID="btnlinkPrev"
                           CssClass="page-link"
                           OnClick="btnlinkPrev_Click">

                       </asp:LinkButton>
                    </li>
                    <asp:Repeater ID="rptPageNumber" runat="server">
                        <ItemTemplate>
                             
                            <li class="page-item">
                                <a class="page-link" href='Department.aspx?pno=<%# string.Format("{0}", Eval("PageNumber")) %>'>
                                   <asp:Literal runat="server" Text='<%# Eval("PageNumber") %>'></asp:Literal>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <li class="page-item">
                        <asp:LinkButton runat="server" Text="Next"
                            ID="btnlkNext" OnClick="btnlkNext_Click" 
                            CssClass="page-link"
                            />
                    </li>
                    <li class="page-item">
                       <asp:LinkButton runat="server" Text="Last"
                            ID="btnlkLast" OnClick="btnlkLast_Click" 
                            CssClass="page-link"
                            />
                    </li>
                </ul>
            </nav>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6 offset-3">

            <asp:GridView runat="server"
                ID="DeptGrid" AutoGenerateColumns="false"
                CssClass="table"
                OnSelectedIndexChanged="DeptGrid_SelectedIndexChanged"
                OnRowDeleting="DeptGrid_RowDeleting"
                DataKeyNames="DeptId">
                <Columns>
                    <asp:BoundField HeaderText="Department Code" DataField="DeptId" />
                    <asp:BoundField HeaderText="Department Name" DataField="DepartmentName" />
                    <asp:CommandField HeaderText="Action"
                        ShowSelectButton="true"
                        SelectText="Edit"
                        ButtonType="Button"
                        ControlStyle-CssClass="btn btn-primary" />

                    <asp:CommandField
                        ShowDeleteButton="true"
                        DeleteText="Remove"
                        ButtonType="Button"
                        ControlStyle-CssClass="btn btn-danger" />

                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>


