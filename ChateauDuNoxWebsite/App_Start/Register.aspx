<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ChateauDuNoxWebsite.App_Start.Register" %>

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
  <link rel="stylesheet" href="../App_Styles/Register.css" />
  <link rel="stylesheet" href="../App_Styles/Shared.css" />

  <!--Link to Javascript-->
  <script src="../Scripts/jquery-3.4.1.min.js"></script>
  <script src="../App_Scripts/script.js"></script>

  <!--Title-->
  <title>Chateau Du Nox - Register</title>
</head>
<body>
  <form id="form1" runat="server">
    <div class="login-container">
      <div class="login-content">
        <a href="Home.aspx">
          <img src="../App_Assets/header-logo.png" />
        </a>

        <h1>Register to Chateau Du Nox</h1>

        <p>Among the Top 10 wineries in Napa Valley</p>
      </div>
      <div class="login-content">
        <a href="Home.aspx">
          <img src="../App_Assets/header-logo.png" />
        </a>

        <div class="input-wrapper">
          <div class="input-container">
            <h3>Username</h3>
            <asp:TextBox CssClass="input-box" ID="UsernameInput" runat="server"></asp:TextBox>
          </div>
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

        <asp:Button CssClass="input-submit" ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" />
      
        <p>Already have an account?
          <a href="Login.aspx">Login here.</a>
        </p>
        
        <a href="Home.aspx">
          <p>Continue as Guest</p>
        </a>
      </div>
    </div>

    <asp:SqlDataSource ID="RegisterSDS" runat="server" ConnectionString="<%$ ConnectionStrings:ChateauString %>" DeleteCommand="DELETE FROM [User] WHERE [UserId] = @UserId" InsertCommand="INSERT INTO [User] ([Name], [Avatar], [Role], [EmailAddress], [Password], [PhoneNumber], [ShippingAddress], [BillingAddress], [RegisteredDate], [Active]) VALUES (@Name, 0x, @Role, @EmailAddress, @Password, @PhoneNumber, @ShippingAddress, @BillingAddress, @RegisteredDate, @Active)" SelectCommand="SELECT * FROM [User]" UpdateCommand="UPDATE [User] SET [Name] = @Name, [Avatar] = @Avatar, [Role] = @Role, [EmailAddress] = @EmailAddress, [Password] = @Password, [PhoneNumber] = @PhoneNumber, [ShippingAddress] = @ShippingAddress, [BillingAddress] = @BillingAddress, [RegisteredDate] = @RegisteredDate, [Active] = @Active WHERE [UserId] = @UserId">
      <DeleteParameters>
        <asp:Parameter Name="UserId" Type="Int32" />
      </DeleteParameters>
      <InsertParameters>
        <asp:ControlParameter ControlID="UsernameInput" Name="Name" PropertyName="Text" Type="String" />
        <asp:Parameter Name="Avatar" Type="Object" />
        <asp:Parameter Name="Role" Type="String" />
        <asp:ControlParameter ControlID="EmailInput" Name="EmailAddress" PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="PasswordInput" Name="Password" PropertyName="Text" Type="String" />
        <asp:Parameter Name="PhoneNumber" Type="String" />
        <asp:Parameter Name="ShippingAddress" Type="String" />
        <asp:Parameter Name="BillingAddress" Type="String" />
        <asp:Parameter Name="RegisteredDate" Type="DateTime" />
        <asp:Parameter Name="Active" Type="Int32" />
      </InsertParameters>
      <UpdateParameters>
        <asp:Parameter Name="Name" Type="String" />
        <asp:Parameter Name="Avatar" Type="Object" />
        <asp:Parameter Name="Role" Type="String" />
        <asp:Parameter Name="EmailAddress" Type="String" />
        <asp:Parameter Name="Password" Type="String" />
        <asp:Parameter Name="PhoneNumber" Type="String" />
        <asp:Parameter Name="ShippingAddress" Type="String" />
        <asp:Parameter Name="BillingAddress" Type="String" />
        <asp:Parameter Name="RegisteredDate" Type="DateTime" />
        <asp:Parameter Name="Active" Type="Int32" />
        <asp:Parameter Name="UserId" Type="Int32" />
      </UpdateParameters>
    </asp:SqlDataSource>
  </form>
</body>
</html>
