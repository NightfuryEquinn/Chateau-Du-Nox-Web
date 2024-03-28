<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SingleWine.aspx.cs" Inherits="ChateauDuNoxWebsite.App_Start.SingleWine" %>

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
  <link rel="stylesheet" href="../App_Styles/SingleWine.css" />
  <link rel="stylesheet" href="../App_Styles/Shared.css" />

  <!--Link to Javascript-->
  <script src="../Scripts/jquery-3.4.1.min.js"></script>
  <script src="../App_Scripts/script.js"></script>

  <!--Title-->
  <title>Chateau Du Nox - Discover</title>
</head>
<body>
  <form id="form1" runat="server">
    <nav>
      <img src="../App_Assets/header-logo.png" />

      <div class="nav-bar">
        <a href="#">About Us</a>
        <a href="#">Wines</a>
        <a href="#">Partners</a>
        <a href="#">Contact Us</a>
      </div>

      <div class="nav-buttons">
        <a href="#" class="profile-btn">
          <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" color="#242C34" viewBox="0 0 24 24">
            <path fill="currentColor" d="M5 21V5q0-.825.588-1.412T7 3h10q.825 0 1.413.588T19 5v16l-7-3z"/>
          </svg>
        </a>
        <a href="#" class="profile-btn">
          <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" color="#242C34" viewBox="0 0 24 24">
            <g fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="1.5">
              <path d="M3 21h18v-9a9 9 0 1 0-18 0zm0-4h18"/>
              <path d="M9 17v-4h12m-8 0V9h7"/>
            </g>
          </svg>
        </a>
        <a href="#" class="profile-btn">
          <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" color="#242C34" viewBox="0 0 24 24">
            <path fill="currentColor" d="M5.85 17.1q1.275-.975 2.85-1.537T12 15q1.725 0 3.3.563t2.85 1.537q.875-1.025 1.363-2.325T20 12q0-3.325-2.337-5.663T12 4Q8.675 4 6.337 6.338T4 12q0 1.475.488 2.775T5.85 17.1M12 13q-1.475 0-2.488-1.012T8.5 9.5q0-1.475 1.013-2.488T12 6q1.475 0 2.488 1.013T15.5 9.5q0 1.475-1.012 2.488T12 13m0 9q-2.075 0-3.9-.788t-3.175-2.137q-1.35-1.35-2.137-3.175T2 12q0-2.075.788-3.9t2.137-3.175q1.35-1.35 3.175-2.137T12 2q2.075 0 3.9.788t3.175 2.137q1.35 1.35 2.138 3.175T22 12q0 2.075-.788 3.9t-2.137 3.175q-1.35 1.35-3.175 2.138T12 22"/>
          </svg>
        </a>
      </div>

      <a class="nav-menu" onclick="openOverlay()">
        <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" color="#242C34" viewBox="0 0 24 24">
          <path fill="none" stroke="currentColor" stroke-linecap="round" stroke-width="1.5" d="M20 7H4m16 5H4m16 5H4"/>
        </svg>
      </a>

      <div id="overlay-menu" class="overlay">
        <div class="overlay-content">
          <img src="../App_Assets/header-logo.png" />

          <div class="overlay-link">
            <a href="#">About Us</a>
            <a href="#">Wines</a>
            <a href="#">Partners</a>
            <a href="#">Contact Us</a>
          </div>

          <div class="overlay-profile">
            <a href="#" class="profile-btn">
              <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" color="#242C34" viewBox="0 0 24 24">
                <path fill="currentColor" d="M5 21V5q0-.825.588-1.412T7 3h10q.825 0 1.413.588T19 5v16l-7-3z"/>
              </svg>
            </a>
            <a href="#" class="profile-btn">
              <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" color="#242C34" viewBox="0 0 24 24">
                <g fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="1.5">
                  <path d="M3 21h18v-9a9 9 0 1 0-18 0zm0-4h18"/>
                  <path d="M9 17v-4h12m-8 0V9h7"/>
                </g>
              </svg>
            </a>
            <a href="#" class="profile-btn">
              <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" color="#242C34" viewBox="0 0 24 24">
                <path fill="currentColor" d="M5.85 17.1q1.275-.975 2.85-1.537T12 15q1.725 0 3.3.563t2.85 1.537q.875-1.025 1.363-2.325T20 12q0-3.325-2.337-5.663T12 4Q8.675 4 6.337 6.338T4 12q0 1.475.488 2.775T5.85 17.1M12 13q-1.475 0-2.488-1.012T8.5 9.5q0-1.475 1.013-2.488T12 6q1.475 0 2.488 1.013T15.5 9.5q0 1.475-1.012 2.488T12 13m0 9q-2.075 0-3.9-.788t-3.175-2.137q-1.35-1.35-2.137-3.175T2 12q0-2.075.788-3.9t2.137-3.175q1.35-1.35 3.175-2.137T12 2q2.075 0 3.9.788t3.175 2.137q1.35 1.35 2.138 3.175T22 12q0 2.075-.788 3.9t-2.137 3.175q-1.35 1.35-3.175 2.138T12 22"/>
              </svg>
            </a>
          </div>

          <a href="javascript:void(0)" class="close-btn" onclick="closeOverlay()">
            <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" color="#242C34" viewBox="0 0 24 24">
              <path fill="currentColor" d="m12 13.4l-4.9 4.9q-.275.275-.7.275t-.7-.275q-.275-.275-.275-.7t.275-.7l4.9-4.9l-4.9-4.9q-.275-.275-.275-.7t.275-.7q.275-.275.7-.275t.7.275l4.9 4.9l4.9-4.9q.275-.275.7-.275t.7.275q.275.275.275.7t-.275.7L13.4 12l4.9 4.9q.275.275.275.7t-.275.7q-.275.275-.7.275t-.7-.275z"/>
            </svg>
          </a>
        </div>
      </div>
    </nav>

    <div class="single-container">
      <div class="back-wrapper">
        <a href="#" class="back-section">
          <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" viewBox="0 0 24 24">
            <path fill="currentColor" d="m7.825 13l4.9 4.9q.3.3.288.7t-.313.7q-.3.275-.7.288t-.7-.288l-6.6-6.6q-.15-.15-.213-.325T4.426 12q0-.2.063-.375T4.7 11.3l6.6-6.6q.275-.275.688-.275t.712.275q.3.3.3.713t-.3.712L7.825 11H19q.425 0 .713.288T20 12q0 .425-.288.713T19 13z"/>
          </svg>
          <h5>Back to Catalog</h5>
        </a>
      </div>

      <div class="single-wine-content">
        <div class="wine-image">
          <img src="../App_Assets/langhe.jpeg" />
        </div>
        <div class="wine-content">
          <h1>Bouchard Père & Fils 2018 Nuits Saint Georges Burgundy France</h1>
          <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
        
          <div class="wine-detail">
            <div class="detail">
              <asp:Label runat="server" CssClass="input-label" Text="Vintage Year"></asp:Label>
              <asp:Label runat="server" CssClass="input-label" ID="vintage" Text="2018"></asp:Label>
            </div>
            <div class="detail">
              <asp:Label runat="server" CssClass="input-label" Text="Body"></asp:Label>
              <asp:Label runat="server" CssClass="input-label" ID="body" Text="Full-bodied"></asp:Label>
            </div>
            <div class="detail">
              <asp:Label runat="server" CssClass="input-label" Text="Type"></asp:Label>
              <asp:Label runat="server" CssClass="input-label" ID="type" Text="Red wine"></asp:Label>
            </div>
            <div class="detail">
              <asp:Label runat="server" CssClass="input-label" Text="Tannin"></asp:Label>
              <asp:Label runat="server" CssClass="input-label" ID="tannin" Text="Ripe tannins"></asp:Label>
            </div>
            <div class="detail">
              <asp:Label runat="server" CssClass="input-label" Text="Acidity"></asp:Label>
              <asp:Label runat="server" CssClass="input-label" ID="acidity" Text="Medium to medium high"></asp:Label>
            </div>
            <div class="detail">
              <asp:Label runat="server" CssClass="input-label" Text="Varietal"></asp:Label>
              <asp:Label runat="server" CssClass="input-label" ID="varietal" Text="Pinot Noir"></asp:Label>
            </div>
            <div class="detail">
              <asp:Label runat="server" CssClass="input-label" Text="Volume (ml)"></asp:Label>
              <asp:Label runat="server" CssClass="input-label" ID="volume" Text="750"></asp:Label>
            </div>
            <div class="detail">
              <asp:Label runat="server" CssClass="input-label" Text="Alcohol by Volume (ABV)"></asp:Label>
              <asp:Label runat="server" CssClass="input-label" ID="abv" Text="12.5% - 14.5%"></asp:Label>
            </div>
            <div class="detail">
              <asp:Label runat="server" CssClass="input-label" Text="Origin"></asp:Label>
              <asp:Label runat="server" CssClass="input-label" ID="origin" Text="Nuits-Saint-Georges, Côte de Nuits, Burgundy, France"></asp:Label>
            </div>
            <div class="detail">
              <asp:Label runat="server" CssClass="input-label" Text="In Stock"></asp:Label>
              <asp:Label runat="server" CssClass="input-label" ID="stock" Text="144"></asp:Label>
            </div>
          </div>

          <div class="price-section">
            <h3>RM <span data-price="400" id="total-price">400</span></h3>

            <div class="counter">
              <button class="input-submit" onclick="decrement(); return false;" type="button"> - </button>
              <p id="total-quantity">1</p>
              <button class="input-submit" onclick="increment(); return false;" type="button"> + </button>
            </div>

            <asp:Button runat="server" CssClass="input-submit" Text="Add to Wishlist" />
            <asp:Button runat="server" CssClass="input-submit" Text="Add to Cart" />
          </div>
        </div>
      </div>

      <div class="wine-review-section">
        <h2>Wine Reviews (<span id="total-reviews">23</span>)</h2>
        <div class="review-container">
          <div class="review">
            <div class="review-content">
              <div class="user-image">
                <img src="../App_Assets/profile.jpg" />
              </div>
              <div class="review-inner-content">
                <h3>John Doe</h3>
                <p>19 March 2024</p>
              </div>
            </div>

            <div class="review-content">
              <h3><span>5</span> / 5</h3>
              <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. </p>
            </div>
          </div>

          <div class="review">
            <div class="review-content">
              <div class="user-image">
                <img src="../App_Assets/profile.jpg" />
              </div>
              <div class="review-inner-content">
                <h3>John Doe</h3>
                <p>19 March 2024</p>
              </div>
            </div>

            <div class="review-content">
              <h3><span>5</span> / 5</h3>
              <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. </p>
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
          <a href="#">
            <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" color="#242C34" viewBox="0 0 24 24">
              <path fill="currentColor" d="M7.8 2h8.4C19.4 2 22 4.6 22 7.8v8.4a5.8 5.8 0 0 1-5.8 5.8H7.8C4.6 22 2 19.4 2 16.2V7.8A5.8 5.8 0 0 1 7.8 2m-.2 2A3.6 3.6 0 0 0 4 7.6v8.8C4 18.39 5.61 20 7.6 20h8.8a3.6 3.6 0 0 0 3.6-3.6V7.6C20 5.61 18.39 4 16.4 4zm9.65 1.5a1.25 1.25 0 0 1 1.25 1.25A1.25 1.25 0 0 1 17.25 8A1.25 1.25 0 0 1 16 6.75a1.25 1.25 0 0 1 1.25-1.25M12 7a5 5 0 0 1 5 5a5 5 0 0 1-5 5a5 5 0 0 1-5-5a5 5 0 0 1 5-5m0 2a3 3 0 0 0-3 3a3 3 0 0 0 3 3a3 3 0 0 0 3-3a3 3 0 0 0-3-3"/>
            </svg>
          </a>
          <a href="#">
            <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" color="#242C34" viewBox="0 0 24 24">
              <path fill="currentColor" d="M12 2.04c-5.5 0-10 4.49-10 10.02c0 5 3.66 9.15 8.44 9.9v-7H7.9v-2.9h2.54V9.85c0-2.51 1.49-3.89 3.78-3.89c1.09 0 2.23.19 2.23.19v2.47h-1.26c-1.24 0-1.63.77-1.63 1.56v1.88h2.78l-.45 2.9h-2.33v7a10 10 0 0 0 8.44-9.9c0-5.53-4.5-10.02-10-10.02"/>
            </svg>
          </a> 
          <a href="#">
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
                <a href="#">
                  <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" color="#242C34" viewBox="0 0 24 24">
                    <path fill="currentColor" d="M7.8 2h8.4C19.4 2 22 4.6 22 7.8v8.4a5.8 5.8 0 0 1-5.8 5.8H7.8C4.6 22 2 19.4 2 16.2V7.8A5.8 5.8 0 0 1 7.8 2m-.2 2A3.6 3.6 0 0 0 4 7.6v8.8C4 18.39 5.61 20 7.6 20h8.8a3.6 3.6 0 0 0 3.6-3.6V7.6C20 5.61 18.39 4 16.4 4zm9.65 1.5a1.25 1.25 0 0 1 1.25 1.25A1.25 1.25 0 0 1 17.25 8A1.25 1.25 0 0 1 16 6.75a1.25 1.25 0 0 1 1.25-1.25M12 7a5 5 0 0 1 5 5a5 5 0 0 1-5 5a5 5 0 0 1-5-5a5 5 0 0 1 5-5m0 2a3 3 0 0 0-3 3a3 3 0 0 0 3 3a3 3 0 0 0 3-3a3 3 0 0 0-3-3"/>
                  </svg>
                </a>
                <a href="#">
                  <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" color="#242C34" viewBox="0 0 24 24">
                    <path fill="currentColor" d="M12 2.04c-5.5 0-10 4.49-10 10.02c0 5 3.66 9.15 8.44 9.9v-7H7.9v-2.9h2.54V9.85c0-2.51 1.49-3.89 3.78-3.89c1.09 0 2.23.19 2.23.19v2.47h-1.26c-1.24 0-1.63.77-1.63 1.56v1.88h2.78l-.45 2.9h-2.33v7a10 10 0 0 0 8.44-9.9c0-5.53-4.5-10.02-10-10.02"/>
                  </svg>
                </a> 
                <a href="#">
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
            <a href="#"><p>About Us</p></a>
            <a href="#"><p>Our Wines</p></a>
            <a href="#"><p>Our Partners</p></a>
            <a href="#"><p>My Wishlist</p></a>
            <a href="#"><p>My Cart</p></a>
          </div>
        </div>
      </div>
      <p>Copyright 2024 @ Chateau Du Nox</p>
    </footer>
  </form>
</body>
</html>
