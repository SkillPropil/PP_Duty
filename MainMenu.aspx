<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="DutyBot.MainMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        .bt_Style {}
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-color:darkgrey">
 <div class="wrapper">
  <div class="logo"></div>
  <div class="blocks">
        
     <asp:Button ID="btBack" runat="server" CssClass="btn-warning"
                    Text="Назад" Height="52px" Width="181px" OnClick="btBack_Click" />
      <center>
    <div class="block"><asp:Button ID ="btGraphik" runat ="server" Text ="График" 
                CssClass ="btn-primary"  Width="277px" Height="44px" OnClick="btGraphik_Click"  /></div>
    <div class="block"><asp:Button ID ="Button1" runat ="server" Text ="Добавление пользователей" 
                CssClass ="btn-primary"  Width="277px" Height="44px" OnClick="Button1_Click" /></div>
    <div class="block"><asp:Button ID ="Button2" runat ="server" Text ="Редактирование смен" 
                CssClass ="btn-primary"  Width="276px" Height="44px" OnClick="Button2_Click" /></div>
    <div class="block"><asp:Button ID ="Button3" runat ="server" Text ="Добавление учетных записей" 
                CssClass ="btn-primary"  Width="276px" Height="44px" OnClick="Button3_Click" /></div>
          <center>
  </div>
</div>
    </form>
</body>
</html>
