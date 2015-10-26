<%@ Page Title="Дисциплины" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisciplinePage.aspx.cs" Inherits="Task1.DisciplinePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2 style="padding-left: 20px;">Дисциплины</h2>

    <div style="padding-top: 10px;">
        <asp:DataGrid ID="discGrid" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped" UseAccessibleHeader="true"
        OnDeleteCommand="discGrid_DeleteCommand" OnEditCommand="discGrid_EditCommand" OnUpdateCommand="discGrid_UpdateCommand" DataKeyField="DisciplineId" OnCancelCommand="discGrid_CancelCommand">
        <Columns>
            <asp:BoundColumn HeaderText="Название дисциплины" DataField="DisciplineName"></asp:BoundColumn>
            <asp:EditCommandColumn EditText="Редактировать" HeaderText="Редактирование" CancelText="Отмена" UpdateText="Обновить"></asp:EditCommandColumn>
            <asp:ButtonColumn CommandName="Delete" HeaderText="Удаление" Text="Удалить"></asp:ButtonColumn>
        </Columns>
        </asp:DataGrid>

        <p><b>Добавление дисциплины</b></p>        
        <div class="form-group">
            <asp:Label ID="labelDiscipline" runat="server" Text="Название дисциплины" style="position:relative; float:left; padding: 6px 0px;"></asp:Label>
            <asp:TextBox ID="textBoxDiscipline" runat="server" Width="200px" CssClass="form-control" style="position:relative; float:left; padding: 6px 0px; margin-left: 15px;"></asp:TextBox>
            <asp:Button ID="buttonSubmit" runat="server" Text="ОК" OnClick="buttonSubmit_Click" CssClass="btn btn-default" style="margin-left: 15px;"/>
        </div>
        
    </div>
</asp:Content>
