// Navigation overlay top down
const openOverlay = () => {
  document.getElementById("overlay-menu").style.height = "100%"
}

const closeOverlay = () => {
  document.getElementById("overlay-menu").style.height = "0%"
}

// Slider
$(document).ready(function () {
  $('.slider-container').each(function () {
    var $this = $(this)
    var $group = $this.find('.slider-group')
    var $slides = $this.find('.slide')
    var buttonArr = []
    var currentIndex = 0
    var timeout

    function move(newIndex) {
      var animateLeft, slideLeft

      advance()

      if ($group.is(':animated') || currentIndex === newIndex) {
        return
      }

      buttonArr[currentIndex].removeClass('active')
      buttonArr[newIndex].addClass('active')

      if (newIndex > currentIndex) {
        slideLeft = '100%'
        animateLeft = '-100%'
      } else {
        slideLeft = '-100%'
        animateLeft = '100%'
      }

      $slides.eq(newIndex).css({ left: slideLeft, display: 'flex' })
      $group.animate({ left: animateLeft }, function () {
        $slides.eq(currentIndex).css({ display: 'none' })
        $slides.eq(newIndex).css({ left: 0 })
        $group.css({ left: 0 })
        currentIndex = newIndex
      })
    }

    function advance() {
      clearTimeout(timeout)

      timeout = setTimeout(function () {
        if (currentIndex < ($slides.length - 1)) {
          move(currentIndex + 1)
        } else {
          move(0)
        }
      }, 5000)
    }

    $.each($slides, function (index) {
      var $button = $("<button type='button' class='slide-btn'></button>")
      if (index === currentIndex) {
        $button.addClass('active')
      }

      $button.on('click', function () {
        move(index)
      }).appendTo($this.find(".slide-buttons"))

      buttonArr.push($button)
    })

    advance()
  })
})