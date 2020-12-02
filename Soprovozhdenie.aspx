﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Soprovozhdenie.aspx.cs" Inherits="DutyBot.Soprovozhdenie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btBack" runat="server" CssClass="btn-warning"
                    Text="Назад" Height="35px" Width="181px" OnClick="btBack_Click" />
            <center>
            <h2><%: Title %>Руководство по работе с программным продуктом "DutyBot"</h2>
            </center>

<p>Программный продукт "DutyBot" предназначен для облегчения работы дежурным системным администраторам и сотрудникам отдела кадров. При помощи данного программного
    продукта присутствует возможность составлять график работы дежурных системных администраторов и экспортировать его в MS Excel.
</p>
            <center>
                <h3>Итак, начнем. Руководство по работе с программным продуктом. Функция добавления.</h3>
            </center>
<p>В данном программном продукте основные функции везде практически одинаковые, поэтому руководство будет показано на примере двух страниц сайта.
    Для того, чтобы добавить данные в таблицу необходимо воспользоваться функцией добавления. Необходимо ввести данные в текстовые поля и
    выбрать в выпадающих списках, после чего нажать на кнопку "Добавить"
</p>
<p>

<img src="добавить.png"/>

</p>
            <center>
                <h3>Изменение данных</h3>
            </center>

<p> Далее рассмотрим функцию изменения данных. Для того, чтобы изменить данные в таблице нужно нажать на таблице кнопку "Выбрать",
    данные запишутся в текстовые поля и выпадающие списки, после этого нажимаем кнопку "Изменить" и наблюдаем результат. 
</p>
    <p>

<img src="изменить.png"/>

</p>

            <center>
                <h3>Удаление данных</h3>
            </center>
    
<p> Далее рассмотрим функцию удаления данных. Для того, чтобы удалить данные в таблице нужно нажать на таблице кнопку "Выбрать",
    данные запишутся в текстовые поля и выпадающие списки, после этого нажимаем кнопку "Удалить" и наблюдаем результат. 
</p>
    <p>

<img src="удалить.png"/>

</p>
            <center>
                <h3>Поиск/Фильтр/Отмена</h3>
            </center>
    <p> Чтобы найти нужные вам данные в таблице можно воспользоваться функцией поиска/фильтра вводим в текстовое поле значение и нажимаем на нужную кнопку.
        Далее данные отфильтруются или подсветятся зеленым, смотря что вы выбрали. Для того чтобы вернуть таблицу в исходное состояние и очистить текстовое поле нужно 
        нажать кнопку "Отмена"
</p>
            <center>
                <h3>Экспорт</h3>
            </center>

    <p> И последняя функция - функция экспорта, она есть на вкладке с таблицей графика. Для того, чтобы экспортировать данные в Excel нужно перейти на вкладку график,
        после чего нажать на иконку xls. Выскочит предложение открыть файл или сохранить, на ваш выбор.
</p>
    <p>

<img src="экспорт.png"/>

</p>
        </div>
    </form>
</body>
</html>
