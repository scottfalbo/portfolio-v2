'use strict'

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
