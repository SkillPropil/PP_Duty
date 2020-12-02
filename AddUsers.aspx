<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUsers.aspx.cs" Inherits="DutyBot.AddUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
     <style type="text/css">
         .bt_Style {
         }
         .auto-style1 {
             width: 74px;
             height: 55px;
         }
         .gvAddUser {}
    </style>
</head>
<body>
      <form id="Warehouse" runat="server" style="background-color:white">
      <asp:SqlDataSource ID="sdsSpecialist" runat="server"></asp:SqlDataSource>
        <center>
            <asp:Label ID ="lblTitle" runat ="server" Text= "Добавление данных о сотруднике" 
                Font-Size ="20" Font-Names ="Arial"></asp:Label>
        </center>
        <div style="overflow: unset">
            <div style="float: left">
                
                <asp:SqlDataSource ID="sdsDepartment" runat="server"
                    SelectCommand="SELECT ID_Department , NameDepartment FROM Department"></asp:SqlDataSource>

                
                <br />

              

                
            

                <asp:DropDownList ID="lstDepartment" runat="server" DataSourceID="sdsDepartment" DataTextField="NameDepartment" DataValueField="ID_Department">
                </asp:DropDownList>

              

                
            

                <br />

                
                <asp:Label ID="lblQuantity" runat="server"
                    Text="Должность" CssClass="font_style"></asp:Label>

                <br />

                
                <asp:TextBox ID="tbSpecialist" CssClass="text-center" runat ="server" style="margin-left: 0px"></asp:TextBox>
                <br />


                
                <asp:Label ID="lblUnit" runat="server"
                    CssClass="font_style" Text="Номер телефона"></asp:Label>
                <br />


                
                <asp:TextBox ID="tbPhone" runat ="server" CssClass="text-center" style="margin-left: 0px"></asp:TextBox>
                <br />


                
                <asp:Label ID="lblUnit1" runat="server"
                    CssClass="font_style" Text="Фамилия"></asp:Label>
                <br />

                <asp:TextBox ID="tbSurname" runat ="server" style="margin-left: 0px"></asp:TextBox>
                <br />


                
                <asp:Label ID="lblUnit0" runat="server"
                    CssClass="font_style" Text="Имя"></asp:Label>
                <br />


                
                <asp:TextBox ID="tbName" runat ="server" style="margin-left: 0px"></asp:TextBox>
                <br />


                
                <asp:Label ID="lblUnit2" runat="server"
                    CssClass="font_style" Text="Отчество"></asp:Label>
                <br />


                
                <asp:TextBox ID="tbMiddleName" runat ="server" style="margin-left: 0px"></asp:TextBox>
                <br />
                <br />
               
                <asp:Button ID="btDelete" runat="server" CssClass="btn-primary"
                    Text="Удалить" OnClick="btDelete_Click"/>

                <asp:Button ID="btInsert" runat="server" CssClass="btn-primary"
                    Text="Добавить" OnClick="btInsert_Click" Width="100px" />
               
                <br />
                


                <br />
                <asp:Button ID="btBack" runat="server" CssClass="btn-warning"
                    Text="Назад" OnClick="btBack_Click" Width="89px" />

                <asp:Button ID="btUpdate" runat="server" CssClass="btn-primary"
                    Text="Изменить" OnClick="btUpdate_Click" Width="100px" />
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
                        CssClass ="text-center"></asp:TextBox>
                    <br>
                    <asp:Button ID ="btSearch" runat ="server" 
                        CssClass ="btn-primary" Text ="Поиск" OnClick="btSearch_Click"/>
                    <asp:Button ID ="btFilter" runat ="server" 
                        CssClass ="btn-primary" Text ="Фильтр" OnClick="btFilter_Click"/>
                    <asp:Button ID ="btCancel" runat ="server" 
                        CssClass ="btn-primary" Text ="Отмена" OnClick="btCancel_Click"/>
                <asp:GridView ID ="gvAddUser" runat ="server" 
                    AllowSorting ="true" 
                    CurrentSortField =""
                    CurrentSortDirection ="ASC"
                    OnRowDataBound="gvAddUser_RowDataBound"
                    OnSelectedIndexChanged="gvAddUser_SelectedIndexChanged"
                    OnSorting="gvAddUser_Sorting"
                    CssClass=" table table-hover table-bordered table-primary"  style =" border-color:black; background-color:white; "
                    Height="154px">
                    <Columns>
                       
                        <asp:CommandField ShowSelectButton ="true" />
                    </Columns>
                     <HeaderStyle   CssClass="table table-primary" 
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

