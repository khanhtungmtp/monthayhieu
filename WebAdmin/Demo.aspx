<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="WebAdmin.Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Demo Web</title>
</head>
<body>
    <form id="form1" runat="server">
        <ul>
            <asp:Repeater runat="server" ID="Repeater_Main">
                <ItemTemplate>
                    <li>
                        <a href="#"><%# Eval("Title") %></a>
                        <b>abcbcbcb</b>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </form>
</body>
</html>
