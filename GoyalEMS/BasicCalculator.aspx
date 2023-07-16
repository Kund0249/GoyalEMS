<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BasicCalculator.aspx.cs" Inherits="GoyalEMS.BasicCalculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/CSS/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-6">
                    <table class="table">
                        <tr>
                            <td>N1 : </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtNum1"
                                    CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>N2 : </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtNum2"
                                    CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Button runat="server" Text="Sum" ID="btnSum"
                                    CssClass="btn btn-primary"
                                    OnClick="btnSum_Click" />
                            </td>
                            <td>
                                <asp:Button runat="server" Text="Clear" ID="btnClear"
                                    CssClass="btn btn-danger" />
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" class="text-center bg-dark">
                                <asp:Label
                                    runat="server" ID="lblResult"
                                    CssClass="text-white"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-6 bg-danger">
                    jbd
                </div>
            </div>
        </div>
    </form>
</body>
</html>
