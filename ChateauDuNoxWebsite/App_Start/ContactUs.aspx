<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="ChateauDuNoxWebsite.App_Start.ContactUs" %>

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
  <link rel="stylesheet" href="../App_Styles/ContactUs.css" />
  <link rel="stylesheet" href="../App_Styles/Shared.css" />

  <!--Link to Javascript-->
  <script src="../Scripts/jquery-3.4.1.min.js"></script>
  <script src="../App_Scripts/script.js"></script>

  <!--Title-->
  <title>Chateau Du Nox - Contact Us</title>
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

    <div class="contact-container">
      <div class="enquiry-section">
        <h1>Enquiry in Service</h1>

        <p>The rolling vineyards and historic charm of Chateau du Nox beckon, and we know you might have questions swirling in your mind like the exquisite vintages we produce. Perhaps you're a curious wine enthusiast seeking details about a specific Chateau du Nox favorite, or maybe you dream of hosting a momentous event amidst our picturesque scenery. Whether you're yearning for a guided tasting experience to tantalize your palate, or simply seeking information about our latest offerings, our dedicated team is here to assist you. Consider this your personal portal to unlocking the magic of Chateau du Nox. Feel free to reach out with any inquiries, big or small – no question about our wines, tours, or events is ever too insignificant. Let us turn your curiosities into a cherished Chateau du Nox experience.</p>
      </div>
      <div class="contact-visit-wrapper">
        <div class="contact-section">
          <h2>Contact Us</h2>

          <a href="#" class="contact-content">
            <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" color="#242C34" viewBox="0 0 24 24">
              <path fill="currentColor" d="M4 20q-.825 0-1.412-.587T2 18V6q0-.825.588-1.412T4 4h16q.825 0 1.413.588T22 6v12q0 .825-.587 1.413T20 20zM20 8l-7.475 4.675q-.125.075-.262.113t-.263.037q-.125 0-.262-.037t-.263-.113L4 8v10h16zm-8 3l8-5H4zM4 8v.25v-1.475v.025V6v.8v-.012V8.25zv10z"/>
            </svg>
            <p>service@chateaudunox.com</p>
          </a>
          <a href="#" class="contact-content">
            <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" color="#242C34" viewBox="0 0 24 24">
              <path fill="currentColor" d="M4.05 21q-.45 0-.75-.3t-.3-.75V15.9q0-.325.225-.587t.575-.363l3.45-.7q.35-.05.713.063t.587.337L10.9 17q.95-.55 1.8-1.213t1.625-1.437q.825-.8 1.513-1.662t1.187-1.788L14.6 8.45q-.2-.2-.275-.475T14.3 7.3l.65-3.5q.05-.325.325-.562T15.9 3h4.05q.45 0 .75.3t.3.75q0 3.125-1.362 6.175t-3.863 5.55q-2.5 2.5-5.55 3.863T4.05 21"/>
            </svg>
            <p>1 (800) 279 0114</p>
          </a>
          <a href="#" class="contact-content">
            <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" color="#242C34" viewBox="0 0 24 24">
              <path fill="currentColor" d="M7.8 2h8.4C19.4 2 22 4.6 22 7.8v8.4a5.8 5.8 0 0 1-5.8 5.8H7.8C4.6 22 2 19.4 2 16.2V7.8A5.8 5.8 0 0 1 7.8 2m-.2 2A3.6 3.6 0 0 0 4 7.6v8.8C4 18.39 5.61 20 7.6 20h8.8a3.6 3.6 0 0 0 3.6-3.6V7.6C20 5.61 18.39 4 16.4 4zm9.65 1.5a1.25 1.25 0 0 1 1.25 1.25A1.25 1.25 0 0 1 17.25 8A1.25 1.25 0 0 1 16 6.75a1.25 1.25 0 0 1 1.25-1.25M12 7a5 5 0 0 1 5 5a5 5 0 0 1-5 5a5 5 0 0 1-5-5a5 5 0 0 1 5-5m0 2a3 3 0 0 0-3 3a3 3 0 0 0 3 3a3 3 0 0 0 3-3a3 3 0 0 0-3-3"/>
            </svg>
            <p>Chateau Du Nox</p>
          </a>
          <a href="#" class="contact-content">
            <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" color="#242C34" viewBox="0 0 24 24">
              <path fill="currentColor" d="M12 2.04c-5.5 0-10 4.49-10 10.02c0 5 3.66 9.15 8.44 9.9v-7H7.9v-2.9h2.54V9.85c0-2.51 1.49-3.89 3.78-3.89c1.09 0 2.23.19 2.23.19v2.47h-1.26c-1.24 0-1.63.77-1.63 1.56v1.88h2.78l-.45 2.9h-2.33v7a10 10 0 0 0 8.44-9.9c0-5.53-4.5-10.02-10-10.02"/>
            </svg>
            <p>chateau_du_nox</p>
          </a>
          <a href="#" class="contact-content">
            <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" color="#242C34" viewBox="0 0 24 24">
              <path fill="currentColor" d="M18.205 2.25h3.308l-7.227 8.26l8.502 11.24H16.13l-5.214-6.817L4.95 21.75H1.64l7.73-8.835L1.215 2.25H8.04l4.713 6.231zm-1.161 17.52h1.833L7.045 4.126H5.078z"/>
            </svg>
            <p>chateau_du_nox_napa</p>
          </a>
        </div>
        <div class="visit-section">
          <div class="image-wrapper">
            <img src="../App_Assets/nox-vineyard.jpg" />
          </div>
          <div class="visit-wrapper">
            <h2>Visit Us</h2>
            <h4>4102 St Cahill Quint, Napa Valley, CA 93212</h4>
            <p>Please call to make a reservation prior visitation. Walk-ins are prohibited and may be legally sued as unauthourized trepassing.</p>
          </div>
        </div>
      </div>
      <div class="newsletter-section">
        <div class="image-wrapper">
          <img src="../App_Assets/newsletter.jpg" />
        </div>
        <div class="newsletter-wrapper">
          <h2>Subscribe to our newsletter</h2>
          <p>Sign up for our newsletter for more information of our events and test drinks.</p>

          <div class="newsletter-inner-wrapper">
            <asp:TextBox CssClass="input-box" ID="SubscribeInput" runat="server"></asp:TextBox>

            <asp:Button CssClass="input-submit" ID="SubscribeButton" runat="server" Text="I am in!" />
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
