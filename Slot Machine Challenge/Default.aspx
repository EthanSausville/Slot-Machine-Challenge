<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Slot_Machine_Challenge.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Bar.png" />
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Bar.png" />
            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Bar.png" />
        </div>
        <div>Your Bet: <asp:TextBox ID="betBox" runat="server"></asp:TextBox>
        </div>
        <div><asp:Button ID="Button1" runat="server" Text="Pull the Lever" OnClick="Button1_Click" /></div>
    </form>
    <asp:Label ID="resultLabel" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="moneyLabel" runat="server">Player&#39;s Money: $100.00</asp:Label>
    <p>
        RULES:</p>
    <ul>
        <li>If you have 1 Cherry --&gt; x2 your Bet</li>
        <li>If you have 2 Cherries --&gt; x3 your Bet</li>
        <li>If you have 3 Cherries --&gt; x4 your Bet</li>
        <li>3 7&#39;s is JACKPOT --&gt; x100 your Bet</li>
        <li>BUT: If there is even 1 bar you win NOTHING</li>
    </ul>
</body>
</html>
