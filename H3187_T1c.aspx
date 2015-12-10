<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="H3187_T1c.aspx.cs" Inherits="H3187_T1c" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtInput" runat="server"></asp:TextBox>
    <asp:Button ID="btnCheck" Text="Tarkista" runat="server" OnClick="btnCheck_Click"/>

    <asp:RequiredFieldValidator
        ID="InputValidator"
        runat="server"
        ControlToValidate="txtInput"
        ErrorMessage="Syöte puuttuu."
        ForeColor="red">
    </asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbResult" runat="server"></asp:Label>
</asp:Content>

