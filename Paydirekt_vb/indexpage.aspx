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
 
<%--<script src="http://code.jquery.com/jquery-1.8.3.js"></script>
   <script>
        $(document).ready(function () {
            $(document).on("click", "#btnAccesstoken", function (e) {
                    $.ajax({
                    type: 'POST',
                    url: 'https://api.sandbox.paydirekt.de/api/merchantintegration/v1/token/obtain',
                    //url: 'http://localhost:52441/indexpage.aspx',
                        beforeSend: function (xhr) {
                        xhr.setRequestHeader("X-Request-ID:", "8269f186-304e-463e-8fca-2601870b8aa7");
                        xhr.setRequestHeader("Content-Type:", "application/json;charset=utf-8");
                        xhr.setRequestHeader("X-Auth-Key:", "5957e0a49-375f-4293-90d6-3ec584f9255c");
                        xhr.setRequestHeader("Accept", "application/hal+json");
                        xhr.setRequestHeader("X-Auth-Code", "51u2m3uB4uPffIdBz5ri00lGH5-AzfChAUGcPseIELw=");
                        xhr.setRequestHeader("X-Date", "Mon, 23 Jan 2017 12:06:20 GMT");
                        alert(xhr.status);
                        xhr.onreadystatechange = function () {
                            if (this.readyState == this.HEADERS_RECEIVED) {
                                print(this.getAllResponseHeaders());
                            }
                             //Call a function when the state changes.
                            if (xhr.readyState == XMLHttpRequest.DONE && xhr.status == 200) {
                                // Request finished. Do processing here.
                                alert("let do something");
                            }
                        }
                    },
                   success: function () {
                        alert("success");
                    },
                    error: function () {
                        alert("we have Network error");
                    }
                }).read();
            })
        })
    </script>--%>
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
