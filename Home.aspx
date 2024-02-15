<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PreventiviAuto.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        Crea il tuo Preventivo:<br />
        <br />
        <br />
        <br />
        Seleziona il modello dell&#39;auto:
        <asp:DropDownList ID="DropDownList1" runat="server" Height="32px">
        </asp:DropDownList>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Conferma Modello" />
        <br />
        <br />
        <br />
        <br />
        <br />
        Seleziona gli optional:<asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Aggiungi Optional" />
        <br />
        <br />
        <br />
        Modello Auto Scelto:<asp:Label ID="lblModello" runat="server"></asp:Label>
        <br />
        <br />
        Marca:<asp:Label ID="lblMarca" runat="server"></asp:Label>
        <br />
        <br />
        Optionals:<asp:BulletedList ID="BulletedList1" runat="server">
        </asp:BulletedList>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Anni di Garanzia"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem Value="1">1 anno</asp:ListItem>
            <asp:ListItem Value="2">2 anni</asp:ListItem>
            <asp:ListItem Value="3">3 anni</asp:ListItem>
            <asp:ListItem Value="4">4 anni</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Conferma Anni Garanzia" />
        <br />
        <br />
        <br />
        <br />
        <br />
        Totale Preventivo:
        <asp:Label ID="lblTotale" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Finalizza Preventivo" />
        <br />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Stampa Lista Preventivi" />
    </form>
</body>
</html>
