<%@ Page Title="Добавление записи" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Task1.WebForm1" %>

<%@ Register Src="~/Components/AddEditControl.ascx" TagPrefix="uc1" TagName="AddEditControl" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="addBox" style="padding-top: 30px;">
        <p><b>Добавление записи</b></p>        
        <uc1:AddEditControl runat="server" id="addEditControl" />
    </div>

</asp:Content>
