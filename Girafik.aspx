<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Girafik.aspx.cs" Inherits="DutyBot.Girafik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        
    </style>
</head>
<body>
    <asp:SqlDataSource ID="sdsWork" runat="server"></asp:SqlDataSource>
    <form id="form1" runat="server" aria-orientation="horizontal" aria-sort="none" style="background-color:darkgrey">
       
     <asp:Button ID="btBack" runat="server" CssClass="btn-warning"
                    Text="Назад" OnClick="btBack_Click" Height="52px" Width="181px" />
       
        
        <div class="container-fluid">
        <div class="table" style="border:1px #0094ff;box-shadow: 0px 2px 5px #808080">
           
                   <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Введите значение для поиска</h1>
               <%-- <asp:Label ID ="lblTitle" runat ="server" Text= "Формирование графика" 
                Font-Size ="20" Font-Names ="Arial"></asp:Label>--%>
            <center> 
         
                     <asp:TextBox ID="tbSearch" runat ="server" 
                        CssClass="text-center" Height="24px" Width="392px"></asp:TextBox>
                
                    
                     
                    <br>
                    <asp:Button ID ="btSearch" runat ="server" 
                        CssClass="btn-primary" Text ="Поиск" OnClick="btSearch_Click" BorderColor="#0066FF" />
                    <asp:Button ID ="btFilter" runat ="server" 
                        CssClass ="btn-primary" Text ="Фильтр" OnClick="btFilter_Click"  />
                    <asp:Button ID ="btCancel" runat ="server" 
                        CssClass ="btn-primary" Text ="Отмена" OnClick="btCancel_Click" />
                    <asp:ImageButton   alt="" class="auto-style1" ID="ImageButton1" runat="server" Height="30px" Width="79px" ImageUrl="~/file-excel-fill.png" OnClick="ImageButton1_Click"  />
              
                
             <asp:GridView ID ="gvGirafik" runat ="server" 
                    AllowSorting ="true"
                    CssClass ="table table-striped table-responsive table-hover table-bordered"  style =" border-color:black; background-color:white; "
                    CurrentSortField =""
                    CurrentSortDirection ="ASC" 
                    OnRowDataBound="gvGirafik_RowDataBound" 
                    OnSorting="gvGirafik_Sorting" 
                    ForeColor="Black" 
                    BackColor="White" 
                    BorderStyle="Dashed" 
                    HorizontalAlign="Center">
                    <Columns>
                        <asp:CommandField ShowSelectButton ="false" />
                    </Columns>
                <HeaderStyle  CssClass="table table-primary" 
                    BackColor="Black" 
                    HorizontalAlign="Center" 
                    Width="33%" />

                </asp:GridView>
                
               
        </div>
      
    </form>
</body>
</html>
