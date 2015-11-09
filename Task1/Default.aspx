<%@ Page Title="Главная" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Task1._Default" %>

<%@ Register Src="~/Components/TableControl.ascx" TagPrefix="uc1" TagName="TableControl" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Студенты и их успеваемость</h1>
        <p class="lead"></p>
    </div>
 <!-- 
    <style>
    .gridHeader A { 
        padding-right: 30px; 
        padding-left: 3px; 
        padding-bottom: 0px; 
        padding-top: 0px; 
        text-decoration: none; 
    }
    .gridHeader A :hover { color: black; }
    .gridHeaderASC A { 
        background: url(images/down.png) no-repeat 100% 50%; 
    }
    .gridHeaderDESC A { 
        background: url(images/up.png) no-repeat 100% 50%; 
    }
</style>

  <asp:DataGrid ID="studGrid" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped" UseAccessibleHeader="true"
        OnDeleteCommand="studGridDeleteCommand" OnEditCommand="studGridEditCommand" OnUpdateCommand="studGridUpdateCommand" DataKeyField="ID"
        AllowPaging="true" PageSize="5" OnPageIndexChanged="studGrid_PageIndexChanged" OnSortCommand="studGrid_SortCommand" AllowSorting="true"
        HeaderStyle-CssClass="gridHeader">
        <Columns>
            <asp:BoundColumn HeaderText="Фамилия" DataField="Surname" SortExpression="Surname"></asp:BoundColumn>
            <asp:BoundColumn HeaderText="Имя" DataField="Name" SortExpression="Name"></asp:BoundColumn>
            <asp:BoundColumn HeaderText="Отчество" DataField="ThirdName" SortExpression="ThirdName"></asp:BoundColumn>
            <asp:BoundColumn HeaderText="Дисциплина" DataField="DisciplineName" SortExpression="DisciplineName"></asp:BoundColumn>
            <asp:BoundColumn HeaderText="Оценка" DataField="Mark" SortExpression="Mark"></asp:BoundColumn>
            <asp:EditCommandColumn EditText="Редактировать" HeaderText="Редактирование"></asp:EditCommandColumn>
            <asp:ButtonColumn CommandName="Delete" HeaderText="Удаление" Text="Удалить"></asp:ButtonColumn>
        </Columns>
        <PagerStyle Mode="NumericPages" HorizontalAlign="Center" />
    </asp:DataGrid> -->
    
    <uc1:TableControl runat="server" id="TableControl" />
    <br>
    <a href="Add.aspx" class="btn btn-primary">Добавить запись</a>
    <a href="DisciplinePage.aspx" class="btn btn-default" style="margin-left: 10px;">Редактирование дисциплин</a>

    

</asp:Content>
