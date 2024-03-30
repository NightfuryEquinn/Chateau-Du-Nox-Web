// Variables
const counters = document.querySelectorAll(".counters span")
const container = document.querySelector(".counters")
let activated = false

// Price counter
const increment = () => {
  let quantity = parseInt(document.getElementById("total-quantity").innerText)
  quantity++
  document.getElementById("total-quantity").innerText = quantity

  updatePrice()
}

const decrement = () => {
  let quantity = parseInt(document.getElementById("total-quantity").innerText)
  if (quantity > 1) {
    quantity--
  }
  document.getElementById("total-quantity").innerText = quantity

  updatePrice()
}

const updatePrice = () => {
  let quantity = parseInt(document.getElementById("total-quantity").innerText)
  let total = quantity * $("#total-price").attr("data-price")
  document.getElementById("total-price").innerText = total
}

// Tab Panel
const openWine = (evt, wine) => {
  evt.preventDefault()

  var tabContent, tabs

  tabContent = document.getElementsByClassName("wine-wrapper")
  for (let i = 0; i < tabContent.length; i++) {
    tabContent[i].style.display = "none"
  }

  tabs = document.getElementsByClassName("tab")
  for (let i = 0; i < tabs.length; i++) {
    tabs[i].className = tabs[i].className.replace(" active", "")
  }

  document.getElementById(wine).style.display = "flex"
  evt.target.className += " active"
}

// Overlay functions
const openOverlay = () => {
  document.getElementById("overlay-menu").style.height = "100%"
}

const closeOverlay = () => {
  document.getElementById("overlay-menu").style.height = "0%"
}

// Wait for DOM loaded
$(document).ready(function () {
  if (document.getElementsByClassName("tab")[0]) {
    document.getElementsByClassName("tab")[0].click()
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
  if (container && counters) {
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
  }
  
  // Photo Viewer
  var request
  var $current
  var cache = {}
  var $frame = $("#photo-viewer")
  var $thumbs = $(".thumb")

  const crossfade = ($img) => {
    if ($current) {
      $current.stop().fadeOut('slow')
    }

    $img.stop().fadeTo('slow', 1)

    $current = $img
  }

  $(document).on('click', '.thumb', function (e) {
    var $img
    var src = this.href
    request = src

    e.preventDefault()

    $thumbs.removeClass('active')
    $(this).addClass('active')

    if (cache.hasOwnProperty(src)) {
      if (cache[src].isLoading === false) {
        crossfade(cache[src].$img)
      }
    } else {
      $img = $('<img />')

      cache[src] = {
        $img: $img,
        isLoading: true
      }

      $img.on('load', function () {
        $img.hide()
        $frame.removeClass('is-loading').append($img)
        cache[src].isLoading = false

        if (request === src) {
          crossfade($img)
        }
      })

      $frame.addClass('is-loading')

      $img.attr({
        'src': src
      })
    }

    $(".viewer-title").text($(this).attr('data-title'))
    $(".viewer-body").text($(this).attr('data-body'))
  })

  $('.thumb').eq(0).click()

  // Modal
  var editModal = document.getElementById("edit-modal")
  var editProfile = document.getElementById("EditProfile")
  var editWine = document.getElementById("EditWine")
  var editType = document.getElementById("EditType")

  var addModal = document.getElementById("add-modal")
  var addType = document.getElementById("AddType")
  var addWine = document.getElementById("AddWine")

  if (editProfile) {
    editProfile.onclick = (event) => {
      event.preventDefault()

      editModal.style.display = "flex"
    }
  }

  if (editWine) {
    editWine.onclick = (event) => {
      event.preventDefault()

      editModal.style.display = "flex"
    }
  }

  if (editType) {
    editType.onclick = (event) => {
      event.preventDefault()

      editModal.style.display = "flex"
    }
  }

  if (addType) {
    addType.onclick = (event) => {
      event.preventDefault()

      addModal.style.display = "flex"
    }
  }

  if (addWine) {
    addWine.onclick = (event) => {
      event.preventDefault()

      addModal.style.display = "flex"
    }
  }

  if (addModal || editModal) {
    window.onclick = (event) => {
      if (event.target == addModal) {
        addModal.style.display = "none"
      }

      if (event.target == editModal) {
        editModal.style.display = "none"
      }
    }
  }

  // Accordian
  if (document.getElementsByClassName('user-container')) {
    $('.user-accordian').on('click', '.accordian-control', function (e) {
      e.preventDefault()

      $(this).next('.accordian-panel').not(':animated').slideToggle()
      $(this).next('.accordian-panel').css('display', 'flex')
    })

    $('.accordian-control').eq(0).click()
  }
})

