<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio154.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Número 1:
            <asp:TextBox ID="txtNum1" runat="server"></asp:TextBox>
            <br /><br />

            Número 2:
            <asp:TextBox ID="txtNum2" runat="server"></asp:TextBox>
            <br /><br />

            <asp:Button ID="btnSumar" runat="server" Text="Sumar" OnClick="btnSumar_Click" />
            <br /><br />

            Resultado:
            <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
