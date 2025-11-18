<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio171._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="row">

            <asp:GridView ID="MyGridView" 
                DataSourceID="MyDataSource1"
                AllowSorting="True"
                AllowPaging="True"
                DataKeyNames="ProductID"
                AutoGenerateEditButton="True"
                runat="server" />

            <asp:SqlDataSource ID="MyDataSource1" runat="server"
                ConnectionString="Data Source=.\sqlexpress;Initial Catalog=Northwind;Persist Security Info=True;Integrated Security=SSPI;"
                ProviderName="System.Data.SqlClient"
                SelectCommand="SELECT ProductID, ProductName, UnitPrice, UnitsInStock FROM Products"
                UpdateCommand="UPDATE Products SET ProductName=@ProductName, UnitPrice=@UnitPrice, UnitsInStock=@UnitsInStock WHERE ProductID=@ProductID">
            </asp:SqlDataSource>

        </div>
    </main>

</asp:Content>
