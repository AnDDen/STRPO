<%@ Page Title="Редактирование записи" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Task1.WebForm2" %>

<%@ Register Src="~/Components/AddEditControl.ascx" TagPrefix="uc1" TagName="AddEditControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="addBox" style="padding-top: 30px;">
        <p><b>Редактирование записи</b></p>
        <uc1:AddEditControl runat="server" ID="addEditControl"/>
    </div>

</asp:Content>
