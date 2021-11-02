//OWL CAROUSEL
$(document).ready(function(){
  $('.owl-carousel').owlCarousel({
        navText: [
            "<i class='fas fa-arrow-left'></i>",
            "<i class='fas fa-arrow-right'></i>"
        ],
        slideSpeed : 300,
        paginationSpeed : 700,
        singleItem: true,
        dots:false,
        margin:20,
        stagePadding: 50,
        slideTransition: 0,
        responsiveClass: true,
        responsive:{
            1400: {
              items: 5,
              nav : true
            },
            992: {
              items: 4,
              nav : true
            },
            400: {
              items: 2,
              nav : false
            },
            300: {
              items: 1,
              nav : false
            }
        }

});
})

//RANGE SLIDER
$(document).ready(function() {
  $('#food-quality').rangeslider({
    polyfill: false,
    slideTransition: 0,
    onInit: function () {
        this.output = $(".food-quality-val").html(this.$element.val());
    },
    onSlide: function (
        position, value) {
        this.output.html(value);
    }
});

$('#service').rangeslider({
  polyfill: false,
  onInit: function () {
      this.output = $(".service-val").html(this.$element.val());
  },
  onSlide: function (
      position, value) {
      this.output.html(value);
  }
});

$('#punctuality').rangeslider({
  polyfill: false,
  onInit: function () {
      this.output = $(".punctuality-val").html(this.$element.val());
  },
  onSlide: function (
      position, value) {
      this.output.html(value);
  }
});

$('#price').rangeslider({
  polyfill: false,
  onInit: function () {
      this.output = $(".price-val").html(this.$element.val());
  },
  onSlide: function (
      position, value) {
      this.output.html(value);
  }
});
});


//FILTER RESTAURANTS
  $('.checked').on('click', function () {
      $(this).prev().prop('checked', !$(this).prev().prop('checked'));
  });

//SHOW MOBILE MENU ON RESTAURANT PAGE
$('.adjust-icon').on('click', function(){
  $('.filter-section').css('transform', 'translateX(0)');
});

$('.close-mobile-menu').on('click', function(){
  $('.filter-section').css('transform', 'translateX(-100%)');
});

//SHOW MOBILE BASKET ON RESTAURANT DETAIL PAGE
$('.mobile-basket-btn').on('click', function(){
  $('.sidebar').css('display', 'block');
  $('.sidebar').addClass('mobile-fixed');
});

$('.close-mobile-menu').on('click', function(){
  $('.sidebar').css('display', 'none');
  $('.sidebar').removeClass('mobile-fixed');
});

//RESTAURANT MENU TOGGLE
$('.sort-header').click(function(){
  $('.sort-list').slideToggle();
  $('.sort-icon').toggleClass('rotated');
});

$('.category-header').click(function(){
  $('.category-list').slideToggle();
  $('.category-icon').toggleClass('rotated');
});

$('.rating-header').click(function(){
  $('.rating-list').slideToggle();
  $('.rating-icon').toggleClass('rotated');
});

//CHOOSE DELIVERY DAY
$('.chosen-day').on('click', function(){
  $(this).prev().prop('checked', !$(this).prev().prop('checked'));
  $('.selected-day').html($(this).prev().val());
  $('.choose-day').toggle();
});

$('.delivery-day').on('click', function(){
  $('.choose-day').toggle();
  $('.calendar').toggleClass('rotate-icon');
});

//CHOOSE DELIVERY TIME
$('.chosen-time').on('click', function(){
  $(this).prev().prop('checked', !$(this).prev().prop('checked'));
  $('.selected-time').html($(this).prev().val());
  $('.choose-time').toggle();
});

$('.delivery-time').on('click', function(){
  $('.choose-time').toggle();
  $('.clock').toggleClass('rotate-icon');
});

//STICKY HEADER
const header = document.querySelector('.transparent-header');
if(header){
  let sticky = header.offsetTop;
  window.onscroll = function () {
    if (window.pageYOffset > sticky) {
      header.classList.add('white-header');
    } else {
      header.classList.remove('white-header');
    }
};
}

//HEADER MOBILE MENU
$('.burger-menu').on('click', function(){
  $('.mobile-menu').css('transform', 'translateX(0)');
});

$('.close-mobile-menu').on('click', function(){
  $('.mobile-menu').css('transform', 'translateX(-100%)');
});


//FAQ SECTION
$('.faq-header').on('click', function(e){
  e.preventDefault();
  $('.faq-body').not($(this).next('.faq-body')).slideUp();
  $('.fa-plus').not($(this).children('.fa-plus')).show();
  $('.fa-minus').not($(this).children('.fa-minus')).hide();
  $(this).next('.faq-body').slideToggle();
  $(this).children('i').toggle();
});


//APPLY JOB
$('.select-loc-input').on('click', function(){
  $('.select-loc-list').toggle();
  $('.category-icon').toggleClass('rotated');
  $(this).toggleClass('focus');
});

$('.option').on('click', function(){
  $('.current').html($(this).attr('data-value'));
  $('.select-loc-list').toggle();
  $('.option').removeClass('selected');
  $(this).addClass('selected');
  $('.category-icon').toggleClass('rotated');
  $('option').val($(this).attr('data-value')).prop('selected', true);
});

//TERMS AND CONDITIONS MODAL
$('.modal-btn').on('click', function(){
  $('.terms-modal').fadeIn('slow');
  $('#terms-modal-overlay').addClass('d-block');
});


$(document).click(function(event) {
  if ($(event.target).closest('.modal-close-btn').length || !$(event.target).closest('.terms-modal,.modal-btn').length) {
    $('.terms-modal').fadeOut('slow');
    $('#terms-modal-overlay').removeClass('d-block');
  }
});

//VIEW RESTAURANT PHOTOS
$('.show-photos').on('click', function(){
  $('.vrp-wrapper').addClass('visible');
  $('.vrp-image').css('transform', 'scale(1.2)');
  $('.vrp-image').css('transition', 'all .7s ease-in-out');
});

$(document).click(function(event) {
  if (!$(event.target).closest('.vrp-image,.show-photos,.right-arrow,.left-arrow').length) {
    $('.vrp-wrapper').removeClass('visible');
    $('.vrp-image').css('transform', 'scale(0)');
    $('.vrp-image').css('transition', 'all .7s ease-in-out');
  }
});

let images = Array.from(document.getElementsByClassName('restaurant-img'));
let imgSources = []
images.forEach(image=>{
  imgSources.push(image.getAttribute('src'));
})
let firstImg = $('.restaurant-img').first();
function changeImg (num){
    firstImg.attr('src', imgSources[imgSources.indexOf(firstImg.attr('src')) + (num || 1)] || imgSources[num ? imgSources.length-1 : 0])
};

$('.left-arrow').on('click', function(){
  changeImg(-1);
})

$('.right-arrow').on('click', function(){
  changeImg();
})

//SHOW ADD TO CART MODAL
$('.show-food-modal').on('click', function(){
  $('.food-modal').fadeIn('slow');
  $('#food-modal-overlay').addClass('d-block');
});

$(document).click(function(event) {
  if ($(event.target).closest('.modal-cancel-btn,.modal-close-btn,.add-to-cart-btn').length || !$(event.target).closest('.food-modal,.show-food-modal').length) {
    $('.food-modal').fadeOut('slow');
    $('#food-modal-overlay').removeClass('d-block');
  }
});


//INCREASE AND DECREASE FOOD QUANTITY
$('.quantity-minus').on('click', function(){
  if($('.quantity-input').val()>0){
    $('.quantity-input').val(+ $('.quantity-input').val() - 1);
  }
});

$('.quantity-plus').on('click', function(){
  $('.quantity-input').val(+ $('.quantity-input').val() + 1);
});

//CLICK TO SCROLL ON RESTAURANT MENU
$('a[href^="#"]').click(function(event) {
  event.preventDefault();
  $('html, body').animate({
    scrollTop: $($(this).attr('href')).offset().top - 100}, 700);
});

// OBSERVE ITEMS ON RESTAURANT MENU
const observeItems = Array.from(document.getElementsByClassName('observe-item'));

function intersectionHandler(entry){
  if(entry.isIntersecting) {
      $('.nav-link').removeClass('active');
      $('a[href="#'+entry.target.id+'"]').toggleClass('active');
      $('a[href="#'+entry.target.id+'"]').children('i').toggleClass('active');
  } else {
      $('.nav-link').removeClass('active');
  }
};

const menuObserver = new IntersectionObserver((entries) => {
  entries.forEach(entry => {
      intersectionHandler(entry);
  });
}, {root: null, rootMargin: '0px 0px -50% 0px', threshold: .5});

const reviewObserver = new IntersectionObserver((entries) => {
  entries.forEach(entry => {
      intersectionHandler(entry);
  });
}, {root: null, rootMargin: '0px 0px -40% 0px', threshold: .4});

observeItems.forEach((item) => {
  menuObserver.observe(item);
});

if(document.getElementById('reviews')){
  reviewObserver.observe(document.getElementById('reviews'));
}



