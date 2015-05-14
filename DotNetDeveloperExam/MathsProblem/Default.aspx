<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span>Input 1:</span><asp:TextBox ID="txtInput1" runat="server"></asp:TextBox>
            <span>Input 2:</span><asp:TextBox ID="txtInput2" runat="server"></asp:TextBox>
            <asp:Button ID="btnGo" runat="server" Text="Get Answer" OnClick="btnGo_Click" />
            <br />
            <br />
            <br />
            <br />
            <span>Output :</span><br />
            <asp:Label ID="lblSum" runat="server"></asp:Label><br />
            <asp:Label ID="lblDiff" runat="server"></asp:Label><br />
            <asp:Label ID="lblProduct" runat="server"></asp:Label><br />
            <asp:Label ID="lblQuotient" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
