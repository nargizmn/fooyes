$(document).ready(function () {
    $('.show-food-modal').on('click', function (e) {
        e.preventDefault();
        var url = $(this).attr("href");
        fetch(url).then(response => response.text()).then(data => {
            $('.food-modal').html(data);
        });
    });
});


toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": false,
    "progressBar": false,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "1000",
    "hideDuration": "500",
    "timeOut": "5000",
    "extendedTimeOut": "2000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}

if ($("#toast-message").length) {
    if ($("#toast-message").attr("data-succeded") == "true") {
        toastr["success"]($("#toast-message").attr("data-text"))
    }
    else {
        toastr["error"]($("#toast-message").attr("data-text"))
    }
};


$(document).ready(function () {
    $(document).on('keyup', '#search-input', function (e) {
        $('#result').html('');
        let count = 1;
        var searchvalue = $(this).val();
        let url = "/restaurant/search";
        fetch(url).then(response => response.json()).then(data => {
            data.map(item => {
                if (item.name.toUpperCase().search(searchvalue.toUpperCase()) != -1) {
                    if (count <= 3) {
                        $('#result').append('<div class="wrapper" style="z-index:1000;"><div><a href="restaurant/detail/' + item.id + ' "class="list-group-item" style="display:flex; align-items:center; justify-content:space-between; border-bottom-radius:10px; padding:12px 40px;"><div style="display:flex;"><div><img src = "uploads/restaurants/' + item.restaurantImages.find(x => x.isMainImage).image + '" style="height: 70px; width: 120px"/></div><p style = "font-size:16px; align-self:center; margin-left:50px; color: #222; font-weight: bold;" > ' + item.name + '</p></div></a></div></div>');
                    }
                    count++;
                }
            })
        });

        $(document).click(function (event) {
            if (!$(event.target).closest('#result').length) {
                $('#result').html('');
            }
        });
    })
});


$('.dropdown').on('click', function () {
    $('.dropdown-menu').toggle();
});



$('.useful').on('click', function (e) {
    e.preventDefault();
    let url = $(this).attr('href');
    fetch(url).then(response => response.json()).then(data => {
        $(this).children('.useful-count').html(data[0]);
        $(this).next().children('.notuseful-count').html(data[1]);
    });
    if ($(this).hasClass('clicked')) {
        $(this).removeClass('clicked');
    }
    else {
        $(this).addClass('clicked');
    }
    $(this).next().removeClass('clicked');
});

$('.notuseful').on('click', function (e) {
    e.preventDefault();
    let url = $(this).attr('href');
    fetch(url).then(response => response.json()).then(data => {
        $(this).children('.notuseful-count').html(data[1]);
        $(this).prev().children('.useful-count').html(data[0]);
    });
    if ($(this).hasClass('clicked')) {
        $(this).removeClass('clicked');
    }
    else {
        $(this).addClass('clicked');
    }
    $(this).prev().removeClass('clicked');
});

