<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Partners.aspx.cs" Inherits="ChateauDuNoxWebsite.App_Start.Partners" %>

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
  <link rel="stylesheet" href="../App_Styles/Partners.css" />
  <link rel="stylesheet" href="../App_Styles/Shared.css" />

  <!--Link to Javascript-->
  <script src="../Scripts/jquery-3.4.1.min.js"></script>
  <script src="../App_Scripts/script.js"></script>

  <!--Title-->
  <title>Chateau Du Nox - Partners</title>
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

    <div class="partners-container">
      <div class="partners-section">
        <h1>Our Partners</h1>

        <p>We cultivate strong, collaborative relationships that are essential to sharing our passion for wine with the world. Our partners, including distributors, restaurants, retailers, sommeliers, and industry influencers, form an invaluable network that extends our reach and brings our handcrafted wines to your table. We are committed to fostering a spirit of partnership by providing exceptional service, ongoing support, and educational programs. These efforts ensure our partners have the knowledge and resources they need to confidently share our story and the unique characteristics of our wines with their customers. Together, we create memorable wine experiences, promote responsible enjoyment, and build a vibrant wine community that celebrates quality and craftsmanship. We believe that by working together, we can elevate the world's appreciation for fine wine, one sip at a time.</p>
      </div>

      <div id="thumbnails" class="thumbnails-container">
        <div class="thumbnails-scroll">
          <a 
            href="../App_Assets/opus.jpg" 
            class="thumb active"
            data-title="Opus One Since 2001"
            data-body="In 1970, Baron Philippe de Rothschild, owner of the First Growth estate Chateau Mouton Rothschild on Bordeaux’s Left Bank, met Robert Mondavi, a Californian winemaking pioneer, for the first time at a hotel in Hawaii. The former suggested the idea of a joint venture between the two wineries; a merging of Old World and New World wine styles. The partnership was announced in 1978, with the aim of making a top-quality Bordeaux-style (Cabernet Sauvignon-dominant blend) wine in California. Mondavi decided to use grapes from his reputable To Kalon vineyard in Napa Valley to make the wine, which was eventually named Opus One. The Franco-American project was considered bold at the time: A world-renowned Bordeaux brand linking arms with a New World producer, albeit one who was on the cusp of leading a wine revolution in California."
           >
            <img src="../App_Assets/opus-logo.png" />
          </a>
          <a 
            href="../App_Assets/almaviva.jpg" 
            class="thumb"
            data-title="Almaviva Since 2005"
            data-body="Established in 1997, Almaviva is a joint venture between Mouton Rothschild and Chilean winemaking powerhouse Concha y Toro. Almaviva is a Bordeaux-style blend made in Chile, a marriage between Chilean terroir and French winemaking expertise. The Almaviva estate is located in Puente Alto, the highest part of Chile’s Maipo Valley, a region known for its top cabernet sauvignon. What sets Almaviva apart from other Bordeaux-style blends is the presence of carmenere — a grape that flourishes in Chile — in its blend: It makes up the second largest amount after Cabernet Sauvignon, replacing what would have been Merlot in a Left Bank-inspired Bordeaux-style wine. Carmenere lends a subtle meaty and herbaceous note to the wine."
           >
            <img src="../App_Assets/almaviva-logo.jpg" />
          </a>
          <a 
            href="../App_Assets/caro.jpg" 
            class="thumb"
            data-title="Bodegas Caro Since 2008"
            data-body="In 1999, the Domaines Barons de Rothschild Lafite (DBR Lafite) group — a part of the Rothschild family empire and the owner of First Growth estate Chateau Lafite Rothschild — teamed up with Argentina’s Catena winemaking family (of the renowned Catena Zapata winery) to create Bodegas Caro, a winery in Argentina’s Mendoza region. The winery’s eponymous wine is DBR Lafite’s way of revisiting the old Bordeaux tradition of blending cabernet sauvignon with malbec, the latter a red grape that used to be popular in Bordeaux but today has become synonymous with Argentinian wine, especially in Mendoza. According to Grand Vin, the wine’s importer, Caro is a marked departure in style for Catena. “[Catena’s] Malbecs often undergo extended maceration to produce richer flavours. In contrast, Caro is given a much shorter maceration, resulting in a more elegant style,” said Linda Chan, Grand Vin’s assistant manager."
           >
            <img src="../App_Assets/caro-logo.jpeg" />
          </a>
          <a 
            href="../App_Assets/cheval.jpg" 
            class="thumb"
            data-title="Cheval Des Andes Since 2011"
            data-body="Established in 1999, Cheval des Andes is the brainchild of Bordeaux’s Chateau Cheval Blanc and Argentina’s Mendoza-based Terrazas de los Andes. Like Bodegas Caro above, Cheval des Andes represents Cheval Blanc’s ambition of reintroducing malbec to a Bordeaux-style blend. Cheval des Andes, however, puts the spotlight on malbec in its blend by making it the dominant component. Winemakers Pierre-Olivier Clouet of Chateau Cheval Blanc and Gerald Gabillet of Cheval des Andes — both armed with extensive experience in Bordeaux — oversee the winemaking at the Argentinian winery."
           >
            <img src="../App_Assets/cheval-logo.png" />
          </a>
          <a 
            href="../App_Assets/evremond.jpg" 
            class="thumb"
            data-title="Domaine Evremond Since 2017"
            data-body="It says a lot about the potential of English sparkling wine when a top champagne house decides to hop across the Channel to plant vineyards there. In 2015, Champagne Taittinger announced a joint venture with UK-based Hatch Mansfield — not a winery in this case but Taittinger’s long-time agent and wine distributor — to make sparkling wines in Kent, a county in south-eastern England. Named Domaine Evremond, the estate will have a total of 40 hectares planted to the classic Champagne varieties of chardonnay, pinot noir and pinot meunier. The first 20 hectares of vines were planted in 2017. Kent and Champagne share the same kind of chalky soil, one of the factors that encouraged the maison to set their sights on the English county. Pierre-Emmanuel Taittinger, honorary chairman of Champagne Taittinger, said they aim to make “something of real excellence in the UK’s increasingly temperate climate, and not compare it with champagne or any other sparkling wine”."
           >
            <img src="../App_Assets/evremond-logo.jpg" />
          </a>
        </div>
      </div>

      <div class="photo-viewer-content">
        <div id="photo-viewer" class="photo-viewer-container"></div>
        <div class="photo-viewer-wrapper">
          <h2 class="viewer-title"></h2>
          <p class="viewer-body"></p>
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
