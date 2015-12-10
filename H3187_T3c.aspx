<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="H3187_T3c.aspx.cs" Inherits="H3187_T3c" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Button ID="btnGetAllStudents" Text="Hae oppilaat" runat="server" OnClick="btnGetAllStudents_Click" />
        <asp:Button ID="btnGetStudentsByABC" Text="Hae oppilaat aakkosjärjestyksessä" runat="server" OnClick="btnGetStudentsByABC_Click" />
        <asp:Button ID="btnGetStudentsByCourse" Text="Hae valitun opintojakson oppilaat" runat="server" OnClick="btnGetStudentsByCourse_Click"/>
        
        <asp:SqlDataSource
            ID="srcCourses"
            ConnectionString="<%$ ConnectionStrings:Demox %>"
            SelectCommand="select distinct course from lasnaolot"
            runat="server">
        </asp:SqlDataSource>
        <asp:DropDownList ID="ddlCourses" runat="server"></asp:DropDownList>
    </div>

    <div>
        <asp:SqlDataSource
            ID="srcStudents"
            ConnectionString="<%$ ConnectionStrings:Demox %>"
            SelectCommand="select distinct asioid from lasnaolot"
            runat="server">
        </asp:SqlDataSource>
        <asp:GridView ID="gvStudents" runat="server"></asp:GridView>
    </div>
</asp:Content>
