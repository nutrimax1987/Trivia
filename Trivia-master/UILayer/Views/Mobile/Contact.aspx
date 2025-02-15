﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TriviaGame.Views.Mobile.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <div data-role="page" id="contactPage">
        <div data-role="header" class="page-header logo">
            <h3>
                <img class="displayed" src="/Content/img/SmartTrivia.png" style="border-radius: 50px" alt="SmartTriviaS" />
            </h3>
        </div>
        <div data-role="header" class="page-header logo">
            <div data-role="navbar" id="mobile-navbar" class="mobile-navbar">
                <ul>
                    <li><a href="/Views/Mobile/Games.aspx" data-icon="grid" data-transition="pop">Games</a></li>
                    <li><a href="/Views/Mobile/About.aspx" data-icon="info" data-transition="pop">About</a></li>
                    <li><a href="/Views/Mobile/Profile.aspx" data-icon="user" data-transition="pop">Profile</a></li>
                    <li><a href="/Views/Mobile/Home.aspx" data-icon="lock" data-transition="pop" id="logout">Logout</a></li>

                </ul>
            </div>
        </div>
          </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
