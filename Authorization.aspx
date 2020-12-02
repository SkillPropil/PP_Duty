<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authorization.aspx.cs" Inherits="DutyBot.Authorization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/bootstrap-grid.css" rel="stylesheet" />
    <style type="text/css">
        .tb_Style {}
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
         <br>
         <center>
        <div>
            <asp:Label ID ="lblTitle" runat ="server" CssClass ="font_style"
                Text ="Авторизация"></asp:Label> 
            <br>
            <br>
            <br>
            <asp:Label ID ="lblLogin" runat ="server" Text ="Логин пользователя"
                CssClass ="font_style"></asp:Label>
            <br>
            <asp:TextBox id="tbLogin" runat ="server"
                CssClass ="tb_Style" Width="271px" Height="31px"></asp:TextBox>
            <br>
            <asp:Label ID ="lblPassword" runat ="server" Text ="Пароль пользователя"
                CssClass ="font_style"></asp:Label>
            <br>
            <asp:TextBox id="tbPassword" runat ="server" TextMode ="Password"
                CssClass ="tb_Style" Width="265px" Height="30px"></asp:TextBox>
            <br>
            <br>
            <asp:Button ID ="btEnter" runat ="server" Text ="Войти" 
                CssClass ="btn-primary" BackColor="#0066ff" Width="117px" Height="44px" ToolTip="Авторизоваться" OnClick="btEnter_Click"/>
        
        </div>
        </center>
    </form>
</body>
</html>
