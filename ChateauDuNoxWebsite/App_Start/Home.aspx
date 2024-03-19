<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ChateauDuNoxWebsite.App_Start.Home" %>

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
  <link rel="icon" type="image/png" href="../App_Assets/header-logo-no-bg.png" />

  <!--Link to CSS-->
  <link rel="stylesheet" href="../App_Styles/Home.css" />
  <link rel="stylesheet" href="../App_Styles/Shared.css" />

  <!--Link to Javascript-->
  <script src="../App_Scripts/script.js" defer></script>

  <!--Title-->
  <title>Chateau Du Nox - Home</title>
</head>
<body>
  <form id="form1" runat="server">
    <nav>
      <img src="../App_Assets/header-logo.png" />

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

    <div>

    </div>
  </form>
</body>
</html>
