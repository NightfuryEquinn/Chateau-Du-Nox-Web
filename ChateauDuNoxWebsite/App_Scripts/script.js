// Wait for DOM loaded
$(document).ready(function () {
  // Navigation overlay top down
  const openOverlay = () => {
    document.getElementById("overlay-menu").style.height = "100%"
  }

  const closeOverlay = () => {
    document.getElementById("overlay-menu").style.height = "0%"
  }

  // Slider
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

  // Number counter
  const counters = document.querySelectorAll(".counters span")
  const container = document.querySelector(".counters")

  let activated = false

  window.addEventListener('scroll', () => {
    if (pageYOffset > container.offsetTop - container.offsetHeight - 200 && activated === false) {
      counters.forEach(counter => {
        counter.innerText = 0

        let count = 0

        const updateCount = () => {
          const target = parseInt(counter.dataset.count)
          if (count < target) {
            count++
            counter.innerText = count
            setTimeout(updateCount, 20)
          } else {
            counter.innerText = target
          }
        }

        updateCount()

        activated = true
      })
    } else if (pageYOffset < container.offsetTop - container.offsetHeight - 500 || pageYOffset === 0 && activated === true) {
      counters.forEach(counter => {
        counter.innerText = 0
      })

      activated = false
    }
  })
})

