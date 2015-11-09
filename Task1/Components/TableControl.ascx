<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TableControl.ascx.cs" Inherits="Task1.Components.TableControl" %>

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

<asp:DataGrid ID="grid" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped" UseAccessibleHeader="true"
    OnDeleteCommand="gridDeleteCommand" OnEditCommand="gridEditCommand" OnUpdateCommand="gridUpdateCommand" DataKeyField="ID"
    AllowPaging="true" PageSize="5" OnPageIndexChanged="grid_PageIndexChanged" OnSortCommand="grid_SortCommand" AllowSorting="true"
    HeaderStyle-CssClass="gridHeader">
    <Columns>
    </Columns>
    <PagerStyle Mode="NumericPages" HorizontalAlign="Center" />
</asp:DataGrid>
