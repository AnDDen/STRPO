<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditControl.ascx.cs" Inherits="Task1.Components.AddEditControl" %>

<div class="form-group">
    <asp:Label ID="labelSurname" runat="server" Text="Фамилия" Width="100px" style="position:relative; float:left; padding: 6px 0px;"></asp:Label>
    <asp:TextBox ID="textBoxSurname" runat="server" Width="200px" CssClass="form-control"></asp:TextBox>
</div>

<div class="form-group">
    <asp:Label ID="labelName" runat="server" Text="Имя" Width="100px" style="position:relative; float:left; padding: 6px 0px;"></asp:Label>
    <asp:TextBox ID="textBoxName" runat="server" Width="200px" CssClass="form-control"></asp:TextBox>
</div>

<div class="form-group">
    <asp:Label ID="labelThirdName" runat="server" Text="Отчество" Width="100px" style="position:relative; float:left; padding: 6px 0px;"></asp:Label>
    <asp:TextBox ID="textBoxThirdName" runat="server" Width="200px" CssClass="form-control"></asp:TextBox>
</div>

<div class="form-group">
    <asp:Label ID="labelDiscipline" runat="server" Text="Дисциплина" Width="100px" style="position:relative; float:left; padding: 6px 0px;"></asp:Label>
    <asp:DropDownList ID="DropDownDiscipline" runat="server" CssClass="form-control" Width="200px">
    </asp:DropDownList>
</div>

<div class="form-group">
    <asp:Label ID="labelMark" runat="server" Text="Оценка" Width="100px" style="position:relative; float:left; padding: 6px 0px;"></asp:Label>
    <asp:TextBox ID="textBoxMark" runat="server" Width="200px" CssClass="form-control" style="position:relative; float:left;"></asp:TextBox>
    <asp:CustomValidator id="CustomValidatorMark" runat="server" CssClass="text-danger" style="font-weight:bold; display: inline-block; padding: 6px 18px;"
        OnServerValidate="MarkValidate" 
        EnableClientScript ="true"
        ControlToValidate="textBoxMark" 
        ErrorMessage="Оценка должна быть целым числом от 0 до 5">
    </asp:CustomValidator>
</div>
<br>
<asp:Button ID="buttonSubmit" runat="server" Text="ОК" OnClick="buttonSubmit_Click" CssClass="btn btn-default"/>
<asp:Button ID="buttonCancel" runat="server" Text="Отмена" OnClick="buttonCancel_Click" style="margin-left: 10px;" CssClass="btn btn-default"/>