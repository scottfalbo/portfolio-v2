'use strict'

function preventParentLink(event) {
  event.stopPropagation();
}

$(document).ready(function(){
  $('.close-gallery').on('click', function(){
      $('.echo-viewer-data-gallery').addClass('hide-me');
  });
});

$(document).ready(function(){
  $('.open-gallery').on('click', function(){
      $('.echo-viewer-data-gallery').removeClass('hide-me');
  });
});

$(document).ready(function(){
  $('.open-nexa-pulse').on('click', function(){
      $('.nexa-pulse').removeClass('hide-me');
  });
});