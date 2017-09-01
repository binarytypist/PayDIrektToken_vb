<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="indexpage.aspx.vb" Inherits="Paydirekt_vb.indexpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 253px;
        }
        .auto-style2 {
            width: 1351px;
        }
        .auto-style3 {
            margin-left: 0px;
        }
        .auto-style5 {
            width: 177px;
        }
    </style>
 

</head>
<body>
    <form method="post" runat="server">
        <div>
            <h2> Paydirekt API (VB)</h2>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style5">
                        Please click to get Token :</td>
                    <td class="auto-style1">
                         <asp:Button ID="btnAccesstoken" runat="server" Text="Generate Token" Width="114px" CssClass="auto-style3" Height="24px" />
                    </td>
                    <td class="auto-style1">
                         &nbsp;</td>
                    <td class="auto-style1">
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="5">
                        <strong>Output Message:</strong></td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:Label ID="lblresult" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
            </table>
          </div>
    </form>
</body>
</html>
