<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkPlan.aspx.cs" Inherits="DutyBot.WorkPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>

    </title>
    <link href="css/bootstrap.css" rel="stylesheet" />
     <style type="text/css">
         .bt_Style {
         }
         .gvAddUser {}
         .gvWork {
             margin-top: 1px;
         }
    </style>
</head>
<body>
    <form id="form1" runat="server">

              

         <asp:SqlDataSource ID="sdsSpecialist" runat="server"
                    SelectCommand="SELECT ID_Specialist , Surname FROM Specialist"></asp:SqlDataSource>
        
               
    <asp:SqlDataSource ID="sdsWork" runat="server"></asp:SqlDataSource>
        <center>
            <asp:Label ID ="lblTitle" runat ="server" Text= "Формирование графика" 
                Font-Size ="20" Font-Names ="Arial"></asp:Label>
        </center>
         <div style="overflow: unset">
            <div style="float: left; height: 440px; width: 252px;">

              

                <asp:DropDownList ID="lstSpecialist" runat="server" DataSourceID="sdsSpecialist" DataTextField="Surname" DataValueField="ID_Specialist">
                </asp:DropDownList>

              

                <br />
          <br />
         

        <asp:Label ID="Label1" runat="server"
                    Text="Начало смены" CssClass="font_style"></asp:Label>

          <br />

                
                <asp:TextBox ID="tbStart" runat ="server" style="margin-left: 0px"></asp:TextBox>

          <br />
              
                <asp:Calendar id="calendar1" runat="server" OnSelectionChanged="calendar1_SelectionChanged">

           <OtherMonthDayStyle ForeColor="LightGray">
           </OtherMonthDayStyle>

           <TitleStyle BackColor="LightBlue"
                       ForeColor="White">
           </TitleStyle>

           <DayStyle BackColor="gray">
           </DayStyle>

           <SelectedDayStyle BackColor="LightGray"
                             Font-Bold="True">
           </SelectedDayStyle>

      </asp:Calendar>
                  


        <asp:Label ID="Label2" runat="server"
                    Text="Конец смены" CssClass="font_style"></asp:Label>

          <br />

                
                <asp:TextBox ID="tbStop" runat ="server" style="margin-left: 0px"></asp:TextBox>

                   <asp:Calendar id="calendar2" runat="server" OnSelectionChanged="calendar2_SelectionChanged" CssClass ="cale">

           <OtherMonthDayStyle ForeColor="LightGray">
           </OtherMonthDayStyle>

           <TitleStyle BackColor="LightBlue"
                       ForeColor="White">
           </TitleStyle>

           <DayStyle BackColor="gray">
           </DayStyle>

           <SelectedDayStyle BackColor="LightGray"
                             Font-Bold="True">
           </SelectedDayStyle>

      </asp:Calendar>
                <br />

                
                <br />

                
                 <asp:Button ID="btDelete" runat="server" CssClass="btn-primary"
                    Text="Удалить" OnClick="btDelete_Click"   />

                <asp:Button ID="btUpdate" runat="server" CssClass="btn-primary"
                    Text="Изменить" OnClick="btUpdate_Click"  />

                <br />

                
                <asp:Button ID="Button1" runat="server" CssClass="btn-warning"
                    Text="Назад" OnClick="Button1_Click"   />

                <asp:Button ID="btInsert" runat="server" CssClass="btn-primary"
                    Text="Добавить" OnClick="btInsert_Click" />

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
                        CssClass ="btn-primary" Text ="Отмена" OnClick="btCancel_Click"/>
             <asp:GridView ID ="gvWork" runat ="server" 
                    AllowSorting ="true"
                    CssClass ="gvWork" 
                    CurrentSortField ="" CurrentSortDirection ="ASC" OnSelectedIndexChanged="gvWork_SelectedIndexChanged" OnRowDataBound="gvWork_RowDataBound" OnSorting="gvWork_Sorting"  >
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
            <div>
    </form>
</body>
</html>
