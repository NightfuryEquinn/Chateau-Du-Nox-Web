<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forget.aspx.cs" Inherits="ChateauDuNoxWebsite.App_Start.Forget" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <!--How code being decoded-->
  <meta charset="utf-8" />

  <!--How page being display based on viewport-->
  <meta name="viewport" content="width=device-width, initial-scale=1 shrink-to-fit=no" />

  <!--Link to Google Font-->
  <link rel="preconnect" href="https://fonts.googleapis.com" />
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
  <link href="https://fonts.googleapis.com/css2?family=Josefin+Slab:ital@0;1&family=Vollkorn:ital,wght@0,700;1,700&display=swap" rel="stylesheet" />

  <!--Link to Pictures file-->
  <link rel="icon" type="image/png" href="../App_Assets/header-logo.png" />

  <!--Link to CSS-->
  <link rel="stylesheet" href="../App_Styles/Forget.css" />
  <link rel="stylesheet" href="../App_Styles/Shared.css" />

  <!--Link to Javascript-->
  <script src="../Scripts/jquery-3.4.1.min.js"></script>
  <script src="../App_Scripts/script.js"></script>

  <!--Title-->
  <title>Chateau Du Nox - Forget Password</title>
</head>
<body>
  <form id="form1" runat="server">
    <div class="login-container">
      <div class="login-content">
        <a href="Home.aspx">
          <img src="../App_Assets/header-logo.png" />
        </a>

        <h1>Reset to Chateau Du Nox</h1>

        <p>Among the Top 10 wineries in Napa Valley</p>
      </div>
      <div class="login-content">
        <a href="Home.aspx">
          <img src="../App_Assets/header-logo.png" />
        </a>

        <div class="input-wrapper">
          <div class="input-container">
            <h3>Email Address</h3>
            <asp:TextBox CssClass="input-box" ID="EmailInput" runat="server"></asp:TextBox>
          </div>
          <div class="input-container">
            <h3>Password</h3>
            <asp:TextBox CssClass="input-box" ID="PasswordInput" TextMode="Password" runat="server"></asp:TextBox>
          </div>
          <div class="input-container">
            <h3>Confirm Password</h3>
            <asp:TextBox CssClass="input-box" ID="ConfirmInput" TextMode="Password" runat="server"></asp:TextBox>
          </div>
        </div>

        <asp:Button CssClass="input-submit" ID="ResetButton" runat="server" Text="Reset" OnClick="ResetButton_Click" />

        <a href="Login.aspx">
          <p>Back to Login</p>
        </a>
      </div>
    </div>
  </form>
</body>
</html>
