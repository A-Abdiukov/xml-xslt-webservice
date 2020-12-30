<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MovieWebsite._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
    </script>
    <div class="jumbotron">
        <h1>Movies Data</h1>
        <asp:Xml ID="MoviesXML" runat="server"></asp:Xml>
    </div>

</asp:Content>
