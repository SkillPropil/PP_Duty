<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="DutyBot.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
     <style type="text/css">
        .bt_Style {
            height: 29px;
        }
         .gvAddUser {}
    </style>
</head>
<body>
      <form id="Registration" runat="server">
      <asp:SqlDataSource ID="sdsAuthorization" runat="server"></asp:SqlDataSource>
        <center>
            <asp:Label ID ="lblTitle" runat ="server" Text= "Добавление учеток" 
                Font-Size ="20" Font-Names ="Arial"></asp:Label>
        </center>
        <div style="overflow: unset">
            <div style="float: left">
                
                <asp:SqlDataSource ID="sdsRole" runat="server"
                    SelectCommand="SELECT ID_Role , RoleName FROM Role"></asp:SqlDataSource>

                
                <br />

              

                
            

                <asp:DropDownList ID="lstRole" runat="server" DataSourceID="sdsRole" DataTextField="RoleName" DataValueField="ID_Role">
                </asp:DropDownList>

              

                
            

                <br />

                
                <asp:Label ID="lblLogin" runat="server"
                    Text="Логин" CssClass="font_style"></asp:Label>

                <br />

                
                <asp:TextBox ID="tbLogin" runat ="server" style="margin-left: 0px"></asp:TextBox>
                <br />


                
                <asp:Label ID="lblPassword" runat="server"
                    CssClass="font_style" Text="Пароль"></asp:Label>
                <br />


                
                <asp:TextBox ID="tbPassword" runat ="server" style="margin-left: 0px"></asp:TextBox>
                <br />


                
                <br />
                <asp:Button ID="btDelete" runat="server" CssClass="btn-primary"
                    Text="Удалить" OnClick="btDelete_Click" />

                <asp:Button ID="btUpdate" runat="server" CssClass="btn-primary"
                    Text="Изменить" OnClick="btUpdate_Click"  />
                <br />
               
                <asp:Button ID="btBack" runat="server" CssClass="btn-warning"
                    Text="Назад" OnClick="btBack_Click"  />

                <asp:Button ID="btInsert" runat="server" CssClass="btn-primary"
                    Text="Добавить" OnClick="btInsert_Click"  />
               
                <br />
                


                <br />
                <br />

                <br />

                <br />
                <br />
                <br />
            </div>
            <div>
                <center>
                    <asp:Label ID ="lblSearch" runat ="server" 
                        Text ="Введите значение для поиска" CssClass="font_style"></asp:Label>
                    <asp:TextBox ID="tbSearch" runat ="server" 
                        CssClass ="tb_Style"></asp:TextBox>
                    <br>
                    <asp:Button ID ="btSearch" runat ="server" 
                        CssClass ="btn-primary" Text ="Поиск" OnClick="btSearch_Click" />
                    <asp:Button ID ="btFilter" runat ="server" 
                        CssClass ="btn-primary" Text ="Фильтр" OnClick="btFilter_Click" />
                    <asp:Button ID ="btCancel" runat ="server" 
                        CssClass ="btn-primary" Text ="Отмена" OnClick="btCancel_Click" />
                <asp:GridView ID ="gvAddUser" runat ="server" 
                    AllowSorting ="true"
                    CssClass ="gvAddUser" 
                    CurrentSortField ="" CurrentSortDirection ="ASC"  Height="154px" OnRowDataBound="gvAddUser_RowDataBound" OnSelectedIndexChanged="gvAddUser_SelectedIndexChanged" OnSorting="gvAddUser_Sorting">
                    <Columns>
                        <asp:CommandField ShowSelectButton ="true" />
                    </Columns>
                    <HeaderStyle  CssClass="table table-primary" 
                    BackColor="Black" 
                    HorizontalAlign="Center" 
                    Width="33%" />
                </asp:GridView>
            </center>
            </div>
        </div>
    </form>
</body>
</html>
