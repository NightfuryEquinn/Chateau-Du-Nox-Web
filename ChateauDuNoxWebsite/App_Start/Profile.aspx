<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ChateauDuNoxWebsite.App_Start.Profile" %>

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
  <link rel="stylesheet" href="../App_Styles/Profile.css" />
  <link rel="stylesheet" href="../App_Styles/Shared.css" />

  <!--Link to Javascript-->
  <script src="../Scripts/jquery-3.4.1.min.js"></script>
  <script src="../App_Scripts/script.js"></script>

  <!--Title-->
  <title>Chateau Du Nox - Profile</title>
</head>
<body>
  <form id="form1" runat="server">
    <nav>
      <a href="Home.aspx">
        <img src="../App_Assets/header-logo.png" />
      </a>

      <div class="nav-bar">
        <a href="AboutUs.aspx">About Us</a>
        <a href="Wines.aspx">Wines</a>
        <a href="Partners.aspx">Partners</a>
        <a href="ContactUs.aspx">Contact Us</a>
      </div>

      <div class="nav-buttons">
        <% if (Session["Name"] != null) { %>
        <a href="Profile.aspx#shipping" class="profile-btn">
          <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" color="#242C34" viewBox="0 0 24 24">
            <path fill="currentColor" d="M5 21V5q0-.825.588-1.412T7 3h10q.825 0 1.413.588T19 5v16l-7-3z"/>
          </svg>
        </a>
        <a href="Profile.aspx#shipping" class="profile-btn">
          <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" color="#242C34" viewBox="0 0 24 24">
            <g fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="1.5">
              <path d="M3 21h18v-9a9 9 0 1 0-18 0zm0-4h18"/>
              <path d="M9 17v-4h12m-8 0V9h7"/>
            </g>
          </svg>
        </a>
        <% } %>
        <% if (Session["Name"] == null) { %>
        <a href="Login.aspx" class="profile-btn">
          <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" color="#242C34" viewBox="0 0 24 24">
            <path fill="currentColor" d="M5.85 17.1q1.275-.975 2.85-1.537T12 15q1.725 0 3.3.563t2.85 1.537q.875-1.025 1.363-2.325T20 12q0-3.325-2.337-5.663T12 4Q8.675 4 6.337 6.338T4 12q0 1.475.488 2.775T5.85 17.1M12 13q-1.475 0-2.488-1.012T8.5 9.5q0-1.475 1.013-2.488T12 6q1.475 0 2.488 1.013T15.5 9.5q0 1.475-1.012 2.488T12 13m0 9q-2.075 0-3.9-.788t-3.175-2.137q-1.35-1.35-2.137-3.175T2 12q0-2.075.788-3.9t2.137-3.175q1.35-1.35 3.175-2.137T12 2q2.075 0 3.9.788t3.175 2.137q1.35 1.35 2.138 3.175T22 12q0 2.075-.788 3.9t-2.137 3.175q-1.35 1.35-3.175 2.138T12 22"/>
          </svg>
        </a>
        <% } else { %>
        <a href="Profile.aspx" class="profile-btn">
          <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" color="#242C34" viewBox="0 0 24 24">
            <path fill="currentColor" d="M5.85 17.1q1.275-.975 2.85-1.537T12 15q1.725 0 3.3.563t2.85 1.537q.875-1.025 1.363-2.325T20 12q0-3.325-2.337-5.663T12 4Q8.675 4 6.337 6.338T4 12q0 1.475.488 2.775T5.85 17.1M12 13q-1.475 0-2.488-1.012T8.5 9.5q0-1.475 1.013-2.488T12 6q1.475 0 2.488 1.013T15.5 9.5q0 1.475-1.012 2.488T12 13m0 9q-2.075 0-3.9-.788t-3.175-2.137q-1.35-1.35-2.137-3.175T2 12q0-2.075.788-3.9t2.137-3.175q1.35-1.35 3.175-2.137T12 2q2.075 0 3.9.788t3.175 2.137q1.35 1.35 2.138 3.175T22 12q0 2.075-.788 3.9t-2.137 3.175q-1.35 1.35-3.175 2.138T12 22"/>
          </svg>
        </a>
        <% } %>
      </div>

      <a class="nav-menu" onclick="openOverlay()">
        <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" color="#242C34" viewBox="0 0 24 24">
          <path fill="none" stroke="currentColor" stroke-linecap="round" stroke-width="1.5" d="M20 7H4m16 5H4m16 5H4"/>
        </svg>
      </a>

      <div id="overlay-menu" class="overlay">
        <div class="overlay-content">
          <a href="Home.aspx">
            <img src="../App_Assets/header-logo.png" />
          </a>

          <div class="overlay-link">
            <a href="AboutUs.aspx">About Us</a>
            <a href="Wines.aspx">Wines</a>
            <a href="Partners.aspx">Partners</a>
            <a href="ContactUs.aspx">Contact Us</a>
          </div>

          <div class="overlay-profile">
            <% if (Session["Name"] != null) { %>
            <a href="Profile.aspx#shipping" class="profile-btn">
              <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" color="#242C34" viewBox="0 0 24 24">
                <path fill="currentColor" d="M5 21V5q0-.825.588-1.412T7 3h10q.825 0 1.413.588T19 5v16l-7-3z"/>
              </svg>
            </a>
            <a href="Profile.aspx#shipping" class="profile-btn">
              <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" color="#242C34" viewBox="0 0 24 24">
                <g fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="1.5">
                  <path d="M3 21h18v-9a9 9 0 1 0-18 0zm0-4h18"/>
                  <path d="M9 17v-4h12m-8 0V9h7"/>
                </g>
              </svg>
            </a>
            <% } %>
            <% if (Session["Name"] == null) { %>
            <a href="Login.aspx" class="profile-btn">
              <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" color="#242C34" viewBox="0 0 24 24">
                <path fill="currentColor" d="M5.85 17.1q1.275-.975 2.85-1.537T12 15q1.725 0 3.3.563t2.85 1.537q.875-1.025 1.363-2.325T20 12q0-3.325-2.337-5.663T12 4Q8.675 4 6.337 6.338T4 12q0 1.475.488 2.775T5.85 17.1M12 13q-1.475 0-2.488-1.012T8.5 9.5q0-1.475 1.013-2.488T12 6q1.475 0 2.488 1.013T15.5 9.5q0 1.475-1.012 2.488T12 13m0 9q-2.075 0-3.9-.788t-3.175-2.137q-1.35-1.35-2.137-3.175T2 12q0-2.075.788-3.9t2.137-3.175q1.35-1.35 3.175-2.137T12 2q2.075 0 3.9.788t3.175 2.137q1.35 1.35 2.138 3.175T22 12q0 2.075-.788 3.9t-2.137 3.175q-1.35 1.35-3.175 2.138T12 22"/>
              </svg>
            </a>
            <% } else { %>
            <a href="Profile.aspx" class="profile-btn">
              <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" color="#242C34" viewBox="0 0 24 24">
                <path fill="currentColor" d="M5.85 17.1q1.275-.975 2.85-1.537T12 15q1.725 0 3.3.563t2.85 1.537q.875-1.025 1.363-2.325T20 12q0-3.325-2.337-5.663T12 4Q8.675 4 6.337 6.338T4 12q0 1.475.488 2.775T5.85 17.1M12 13q-1.475 0-2.488-1.012T8.5 9.5q0-1.475 1.013-2.488T12 6q1.475 0 2.488 1.013T15.5 9.5q0 1.475-1.012 2.488T12 13m0 9q-2.075 0-3.9-.788t-3.175-2.137q-1.35-1.35-2.137-3.175T2 12q0-2.075.788-3.9t2.137-3.175q1.35-1.35 3.175-2.137T12 2q2.075 0 3.9.788t3.175 2.137q1.35 1.35 2.138 3.175T22 12q0 2.075-.788 3.9t-2.137 3.175q-1.35 1.35-3.175 2.138T12 22"/>
              </svg>
            </a>
            <% } %>
          </div>

          <a href="javascript:void(0)" class="close-btn" onclick="closeOverlay()">
            <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" color="#242C34" viewBox="0 0 24 24">
              <path fill="currentColor" d="m12 13.4l-4.9 4.9q-.275.275-.7.275t-.7-.275q-.275-.275-.275-.7t.275-.7l4.9-4.9l-4.9-4.9q-.275-.275-.275-.7t.275-.7q.275-.275.7-.275t.7.275l4.9 4.9l4.9-4.9q.275-.275.7-.275t.7.275q.275.275.275.7t-.275.7L13.4 12l4.9 4.9q.275.275.275.7t-.275.7q-.275.275-.7.275t-.7-.275z"/>
            </svg>
          </a>
        </div>
      </div>
    </nav>

    <div class="profile-container">
      <asp:Repeater runat="server" ID="ProfileRepeater">
        <ItemTemplate>
          <div class="avatar-section">
            <div class="avatar-wrapper">
              <img src='data:image/jpeg;base64,<%# Convert.ToBase64String((byte[])Eval("Avatar")) %>' />
            </div>
            <div class="avatar-detail">
              <p>Joined since <%# Eval("RegisteredDate") %></p>
              <h1><%# Eval("Name") %></h1>
            </div>
            <div class="avatar-cover">
              <img src="../App_Assets/profile-cover.jpg" />
            </div>
          </div>

          <div class="profile-detail-section">
            <div class="detail">
              <asp:Label runat="server" CssClass="input-label" Text="Email Address"></asp:Label>
              <asp:Label runat="server" CssClass="input-label" ID="email" Text='<%# Eval("EmailAddress") %>'></asp:Label>
            </div>
            <div class="detail">
              <asp:Label runat="server" CssClass="input-label" Text="Phone Number"></asp:Label>
              <asp:Label runat="server" CssClass="input-label" ID="phone" Text='<%# Eval("PhoneNumber") %>'></asp:Label>
            </div>
            <div class="detail">
              <asp:Label runat="server" CssClass="input-label" Text="Shipping Address"></asp:Label>
              <asp:Label runat="server" CssClass="input-label" ID="shipping" Text='<%# Eval("ShippingAddress") %>'></asp:Label>
            </div>
            <div class="detail">
              <asp:Label runat="server" CssClass="input-label" Text="Billing Address"></asp:Label>
              <asp:Label runat="server" CssClass="input-label" ID="billing" Text='<%# Eval("BillingAddress") %>'></asp:Label>
            </div>
            <div class="detail">
              <asp:Label runat="server" CssClass="input-label" Text="Role"></asp:Label>
              <asp:Label runat="server" CssClass="input-label" ID="role" Text='<%# Eval("Role") %>'></asp:Label>
            </div>

            <asp:Button runat="server" CommandArgument='<%# Eval("Name") %>' OnClientClick="return checkQueryString()" OnClick="EditProfile_Click" CssClass="input-submit" ID="EditProfile" Text="Edit Profile" />
            <asp:Button runat="server" OnClick="ChangePass_Click" CssClass="input-submit" ID="ChangePass" Text="Change Password" />
          </div>
        </ItemTemplate>
      </asp:Repeater>

      <div class="function-section">
        <div class="function-content short">
          <h2 id="wishlist">On Wishlist</h2>

          <div class="scroll-container">
            <div class="scroll-wrapper">
              <asp:Repeater runat="server" ID="WishlistRepeater">
                <ItemTemplate>
                  <div class="wishlist-wrapper">
                    <a href='SingleWine.aspx?WineId=<%# Eval("WineId") %>' class="wine-wish">
                      <h4><%# Eval("WineName") %></h4>
                      <p>Amount: <%# Eval("Amount") %></p>
                    </a>

                    <asp:Button runat="server" CommandArgument='<%# Eval("WishlistId") %>' CssClass="input-submit" Text="Remove" ID="WishlistRemove" OnClick="WishlistRemove_Click" />
                  </div>
              
                  <hr />
                </ItemTemplate>
              </asp:Repeater>
            </div>
          </div>
        </div>

        <div class="function-content long">
          <h2 id="cart">On Cart</h2>

          <div class="scroll-container">
            <div class="scroll-wrapper">
              <asp:Repeater runat="server" ID="CartRepeater">
                <ItemTemplate>
                  <div class="wine-wrapper">
                    <div class="wine-cart">
                      <h4><%# Eval("WineName") %></h4>
                      <p>Amount: <%# Eval("Amount") %></p>
                      <p>Total Price: RM <%# Eval("WineTotal") %></p>
                    </div>
              
                    <asp:Button runat="server" CommandArgument='<%# Eval("CartId") %>' CssClass="input-submit" Text="Remove" ID="CartRemove" OnClick="CartRemove_Click" />
                  </div>

                  <hr />
                </ItemTemplate>
              </asp:Repeater>
            </div>
          </div>

          <div class="cart-content">
            <h3>Checkout Price: RM <asp:Label runat="server" ID="CartTotal" Text=""></asp:Label></h3>
            <asp:Button runat="server" CssClass="input-submit" Text="Checkout" ID="CartCheckout" OnClick="CartCheckout_Click" />
          </div>
        </div>

        <div class="function-content long">
          <h2>Order History</h2>

          <div class="scroll-container">
            <div class="scroll-wrapper">
              <asp:Repeater runat="server" ID="ShippingRepeater">
                <ItemTemplate>
                  <div class="order-wrapper">
                    <div class="order-history">
                      <h4><%# Eval("WineName") %></h4>
                      <p>Status: <b><%# Eval("Status") %></b></p>
                      <p>Ordered Date: <%# Eval("OrderedDate") %></p>
                      <p>Total Payable: RM <%# Eval("TotalPayable") %></p>
                    </div>

                    <asp:Button runat="server" CommandArgument='<%# Eval("OrderId") %>' CssClass="input-submit" Text="Cancel" ID="OrderCancel" OnClick="OrderCancel_Click" />
                  </div>

                  <hr />
                </ItemTemplate>
              </asp:Repeater>

              <asp:Repeater runat="server" ID="DeliveredRepeater">
                <ItemTemplate>
                  <div class="order-wrapper">
                    <div class="order-history">
                      <h4><%# Eval("WineName") %></h4>
                      <p>Status: <b><%# Eval("Status") %></b></p>
                      <p>Ordered Date: <%# Eval("OrderedDate") %></p>
                      <p>Delivered Date: <%# Eval("DeliveredDate") %></p>
                      <p>Total Payable: RM <%# Eval("TotalPayable") %></p>
                    </div>

                    <asp:Button runat="server" CommandArgument='<%# Eval("OrderId") %>' CssClass="input-submit" Text="Confirm" ID="OrderConfirm" OnClick="OrderConfirm_Click" />
                  </div>

                  <hr />
                </ItemTemplate>
              </asp:Repeater>

              <asp:Repeater runat="server" ID="CompletedRepeater" OnItemDataBound="CompletedRepeater_ItemDataBound">
                <ItemTemplate>
                  <div class="order-wrapper">
                    <div class="order-history">
                      <h4><%# Eval("WineName") %></h4>
                      <p>Status: <b><%# Eval("Status") %></b></p>
                      <p>Ordered Date: <%# Eval("OrderedDate") %></p>
                      <p>Delivered Date: <%# Eval("DeliveredDate") %></p>
                      <p>Total Payable: RM <%# Eval("TotalPayable") %></p>
                    </div>

                    <asp:Button runat="server" CommandArgument='<%# Eval("OrderId") %>' CssClass="input-submit" Text="Rate" ID="OrderRate" OnClick="OrderRate_Click" />
                  </div>

                  <hr />
                </ItemTemplate>
              </asp:Repeater>

              <asp:Repeater runat="server" ID="CancelledRepeater">
                <ItemTemplate>
                  <div class="order-wrapper">
                    <div class="order-history">
                      <h4><%# Eval("WineName") %></h4>
                      <p>Status: <b><%# Eval("Status") %></b></p>
                      <p>Ordered Date: <%# Eval("OrderedDate") %></p>
                      <p>Total Payable: RM <%# Eval("TotalPayable") %></p>
                    </div>
                  </div>

                  <hr />
                </ItemTemplate>
              </asp:Repeater>
            </div>
          </div>
        </div>

        <div class="function-content short">
          <h2>Past Reviews</h2>

          <div class="scroll-container">
            <div class="scroll-wrapper">
              <asp:Repeater runat="server" ID="ReviewRepeater">
                <ItemTemplate>
                  <div class="review-wrapper">
                    <div class="review">
                      <h4><%# Eval("WineName") %></h4>
                      <p>Rating: <%# Eval("Rating") %></p>
                      <p>Written Date: <span><%# Eval("WrittenDate") %></span></p>

                      <hr />

                      <p><%# Eval("Content") %></p>
                    </div>

                    <asp:Button runat="server" CommandArgument='<%# Eval("WineId") %>' CssClass="input-submit" Text="View" ID="ReviewView" OnClick="ReviewView_Click" />
                  </div>

                  <hr />
                </ItemTemplate>
              </asp:Repeater>
            </div>
          </div>
        </div>
      </div>
    </div>

    <footer class="mobile-footer">
      <img src="../App_Assets/header-logo.png" />
      <div class="footer-wrapper">
        <div class="footer-content">
          <h3>Visit Us</h3>
          <p>4102 St Cahill Quint, Napa Valley, CA 93212</p>
        </div>
        <div class="footer-content">
          <h3>Contact Us</h3>
          <p>service@chateaudunox.com</p>
          <p>1 (800) 279 0114</p>
        </div>
        <div class="footer-btn">
          <a href="https://www.instagram.com/accounts/login/">
            <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" color="#242C34" viewBox="0 0 24 24">
              <path fill="currentColor" d="M7.8 2h8.4C19.4 2 22 4.6 22 7.8v8.4a5.8 5.8 0 0 1-5.8 5.8H7.8C4.6 22 2 19.4 2 16.2V7.8A5.8 5.8 0 0 1 7.8 2m-.2 2A3.6 3.6 0 0 0 4 7.6v8.8C4 18.39 5.61 20 7.6 20h8.8a3.6 3.6 0 0 0 3.6-3.6V7.6C20 5.61 18.39 4 16.4 4zm9.65 1.5a1.25 1.25 0 0 1 1.25 1.25A1.25 1.25 0 0 1 17.25 8A1.25 1.25 0 0 1 16 6.75a1.25 1.25 0 0 1 1.25-1.25M12 7a5 5 0 0 1 5 5a5 5 0 0 1-5 5a5 5 0 0 1-5-5a5 5 0 0 1 5-5m0 2a3 3 0 0 0-3 3a3 3 0 0 0 3 3a3 3 0 0 0 3-3a3 3 0 0 0-3-3"/>
            </svg>
          </a>
          <a href="https://www.facebook.com/ ">
            <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" color="#242C34" viewBox="0 0 24 24">
              <path fill="currentColor" d="M12 2.04c-5.5 0-10 4.49-10 10.02c0 5 3.66 9.15 8.44 9.9v-7H7.9v-2.9h2.54V9.85c0-2.51 1.49-3.89 3.78-3.89c1.09 0 2.23.19 2.23.19v2.47h-1.26c-1.24 0-1.63.77-1.63 1.56v1.88h2.78l-.45 2.9h-2.33v7a10 10 0 0 0 8.44-9.9c0-5.53-4.5-10.02-10-10.02"/>
            </svg>
          </a> 
          <a href="https://twitter.com/login">
            <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" color="#242C34" viewBox="0 0 24 24">
              <path fill="currentColor" d="M18.205 2.25h3.308l-7.227 8.26l8.502 11.24H16.13l-5.214-6.817L4.95 21.75H1.64l7.73-8.835L1.215 2.25H8.04l4.713 6.231zm-1.161 17.52h1.833L7.045 4.126H5.078z"/>
            </svg>
          </a>
        </div>
      </div>
      <p>Copyright 2024 @ Chateau Du Nox</p>
    </footer>

    <footer class="desktop-footer">
      <div class="footer-row">
        <img src="../App_Assets/header-logo.png" />
        <div class="footer-content">
          <div class="footer-content">
            <h3>Visit Us</h3>
            <p>4102 St Cahill Quint, Napa Valley, CA 93212</p>
          </div>
          <div class="contact-us">
            <div class="footer-content">
              <h3>Contact Us</h3>
              <p>service@chateaudunox.com</p>
              <p>1 (800) 279 0114</p>
              <div class="footer-row-content">
                <a href="https://www.instagram.com/accounts/login/">
                  <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" color="#242C34" viewBox="0 0 24 24">
                    <path fill="currentColor" d="M7.8 2h8.4C19.4 2 22 4.6 22 7.8v8.4a5.8 5.8 0 0 1-5.8 5.8H7.8C4.6 22 2 19.4 2 16.2V7.8A5.8 5.8 0 0 1 7.8 2m-.2 2A3.6 3.6 0 0 0 4 7.6v8.8C4 18.39 5.61 20 7.6 20h8.8a3.6 3.6 0 0 0 3.6-3.6V7.6C20 5.61 18.39 4 16.4 4zm9.65 1.5a1.25 1.25 0 0 1 1.25 1.25A1.25 1.25 0 0 1 17.25 8A1.25 1.25 0 0 1 16 6.75a1.25 1.25 0 0 1 1.25-1.25M12 7a5 5 0 0 1 5 5a5 5 0 0 1-5 5a5 5 0 0 1-5-5a5 5 0 0 1 5-5m0 2a3 3 0 0 0-3 3a3 3 0 0 0 3 3a3 3 0 0 0 3-3a3 3 0 0 0-3-3"/>
                  </svg>
                </a>
                <a href="https://www.facebook.com/">
                  <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" color="#242C34" viewBox="0 0 24 24">
                    <path fill="currentColor" d="M12 2.04c-5.5 0-10 4.49-10 10.02c0 5 3.66 9.15 8.44 9.9v-7H7.9v-2.9h2.54V9.85c0-2.51 1.49-3.89 3.78-3.89c1.09 0 2.23.19 2.23.19v2.47h-1.26c-1.24 0-1.63.77-1.63 1.56v1.88h2.78l-.45 2.9h-2.33v7a10 10 0 0 0 8.44-9.9c0-5.53-4.5-10.02-10-10.02"/>
                  </svg>
                </a> 
                <a href="https://twitter.com/login">
                  <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" color="#242C34" viewBox="0 0 24 24">
                    <path fill="currentColor" d="M18.205 2.25h3.308l-7.227 8.26l8.502 11.24H16.13l-5.214-6.817L4.95 21.75H1.64l7.73-8.835L1.215 2.25H8.04l4.713 6.231zm-1.161 17.52h1.833L7.045 4.126H5.078z"/>
                  </svg>
                </a>
              </div>
            </div>
          </div>
        </div>
        <div class="footer-content">
          <h3>Discover Us</h3>
          <div class="discover-us">
            <a href="AboutUs.aspx"><p>About Us</p></a>
            <a href="Wines.aspx"><p>Our Wines</p></a>
            <a href="Partners.aspx"><p>Our Partners</p></a>
            <% if (Session["Name"] != null) { %>
            <a href="Profile.aspx#shipping"><p>My Wishlist</p></a>
            <a href="Profile.aspx#shipping"><p>My Cart</p></a>
            <% } %>
          </div>
        </div>
      </div>
      <p>Copyright 2024 @ Chateau Du Nox</p>
    </footer>

    <% if (Session["Role"] as string == "Admin") { %>
    <div class="admin-function-container">
      <div class="admin-function">
        <asp:Button runat="server" CssClass="input-submit" Text="Manage Order" ID="ManageOrder" OnClientClick="document.location.href='./App_Admin/ManageOrder.aspx'; return false;" />
        <asp:Button runat="server" CssClass="input-submit" Text="Manage Review" ID="ManageReview" OnClientClick="document.location.href='./App_Admin/ManageReview.aspx'; return false;" />
        <asp:Button runat="server" CssClass="input-submit" Text="Manage Type" ID="ManageType" OnClientClick="document.location.href='./App_Admin/ManageType.aspx'; return false;" />
        <asp:Button runat="server" CssClass="input-submit" Text="Manage User" ID="ManageUser" OnClientClick="document.location.href='./App_Admin/ManageUser.aspx'; return false;" />
        <asp:Button runat="server" CssClass="input-submit" Text="Manage Wine" ID="ManageWine" OnClientClick="document.location.href='./App_Admin/ManageWine.aspx'; return false;" />
      </div>

      <a href="#">
        <svg xmlns="http://www.w3.org/2000/svg" color="#EEEBD1" width="40" height="40" viewBox="0 0 24 24">
          <path fill="currentColor" d="M5 11h4c1.1 0 2-.9 2-2V5c0-1.1-.9-2-2-2H5c-1.1 0-2 .9-2 2v4c0 1.1.9 2 2 2m0 10h4c1.1 0 2-.9 2-2v-4c0-1.1-.9-2-2-2H5c-1.1 0-2 .9-2 2v4c0 1.1.9 2 2 2m8-16v4c0 1.1.9 2 2 2h4c1.1 0 2-.9 2-2V5c0-1.1-.9-2-2-2h-4c-1.1 0-2 .9-2 2m2 16h4c1.1 0 2-.9 2-2v-4c0-1.1-.9-2-2-2h-4c-1.1 0-2 .9-2 2v4c0 1.1.9 2 2 2"/>
        </svg>
      </a>
    </div>
     <% } %>

    <div id="edit-modal" class="modal">
      <div class="modal-content">
        <h2>Edit Profile Detail</h2>

        <div class="modal-wrapper">
          <div class="input-container">
            <div class="input-detail">
              <asp:Label runat="server" CssClass="input-label" Text="Name"></asp:Label>
              <asp:TextBox runat="server" CssClass="input-box" ID="EditName"></asp:TextBox>
            </div>
            <div class="input-detail">
              <asp:Label runat="server" CssClass="input-label" Text="Avatar"></asp:Label>
              <asp:FileUpload ID="EditAvatarUpload" CssClass="input-file" runat="server" />
            </div>
            <div class="input-detail">
              <asp:Label runat="server" CssClass="input-label" Text="Email Address"></asp:Label>
              <asp:TextBox runat="server" CssClass="input-box" TextMode="Email" ID="EditEmailAddress"></asp:TextBox>
            </div>
            <div class="input-detail">
              <asp:Label runat="server" CssClass="input-label" Text="Phone Number"></asp:Label>
              <asp:TextBox runat="server" CssClass="input-box" TextMode="Phone" ID="EditPhone"></asp:TextBox>
            </div>
            <div class="input-detail">
              <asp:Label runat="server" CssClass="input-label" Text="Shipping Address"></asp:Label>
              <asp:TextBox runat="server" CssClass="input-textarea" TextMode="MultiLine" Height="50" ID="EditShipping"></asp:TextBox>
            </div>
            <div class="input-detail">
              <asp:Label runat="server" CssClass="input-label" Text="Billing Address"></asp:Label>
              <asp:TextBox runat="server" CssClass="input-textarea" TextMode="MultiLine" Height="50" ID="EditBilling"></asp:TextBox>
            </div>
          </div>
        </div>

        <asp:Button runat="server" CssClass="input-submit" ID="SaveButton" Text="Save Changes" OnClick="SaveButton_Click" />
      </div>
    </div>
  </form>
</body>
</html>
