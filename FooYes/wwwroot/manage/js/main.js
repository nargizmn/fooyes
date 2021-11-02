$('.add-meal-type').on('click', function (e) {
    e.preventDefault();
    $('.meal-type-form').toggle();
    $('.select-meal').toggle();
});

$('.choose-meal-type').on('click', function (e) {
    e.preventDefault();
    $('.meal-type-form').toggle();
    $('.select-meal').toggle();
});

$('.add-meal-size').on('click', function (e) {
    e.preventDefault();
    let htmlStr = `<div class="form-row">
                <div class="form-group col-6">
                    <label asp-for="MealSizeName">Size</label>
                    <input type="text" asp-for="MealSizeName" name="MealSizeName" class="form-control" placeholder="Meal size">
                    <span class="text-danger" asp-validation-for="MealSizeName"></span>
                </div>
                <div class="form-group col-6">
                    <label asp-for="MealSizeExtraCharge">Extra Charge</label>
                    <input type="text" asp-for="MealSizeExtraCharge" name="MealSizeExtraCharge" class="form-control" placeholder="Extra Charge for meal size">
                    <span class="text-danger" asp-validation-for="MealSizeExtraCharge"></span>
                </div>
             </div>`
    $('.size-wrapper').append(htmlStr);
})

$(document).on('click', '.delete-item', function (e) {
    e.preventDefault();
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            const url = $(this).attr('href');
            fetch(url).then(response => response.json()).then(data => {
                if (data.status == 200) {
                    location.reload(true);
                }
                else {
                    Swal.fire(
                        'Item not found!',
                        'Please, try again!'
                    );
                }
            });
        }
    })
})

$(document).on('click', '.comment-reject-button', function (e) {
    e.preventDefault();
    var note = $(".admin-note").val();
    if (note == "") {
        $('.admin-note-validation').html("İstifadəçinin şərhi silindiyi halda, qeyd hissəsi boş buraxıla bilməz");
    }
    else {
        var url = $(this).attr("href") + "&note=" + note;
        fetch(url)
            .then(response => response.json())
            .then(data => {
                if (data.status == 400) {
                    $(".admin-note-validation").text("İstifadəçinin şərhi silindiyi halda, qeyd hissəsi boş buraxıla bilməz")
                }
                else {
                    window.location.href = "/manage/restaurant";
                }
            });
    }
});

$(document).on("click", ".comment-accept-button", function (e) {
    e.preventDefault();
    var note = $(".admin-note").val();
    var url = $(this).attr("href") + "&note=" + note;
    fetch(url)
        .then(response => response.json())
        .then(data => {
            window.location.href = "/manage/restaurant";
        });
})

$(function () {
    $('[data-toggle="tooltip"]').tooltip()
});

$(document).on('click', '.rider-reject-button', function (e) {
    e.preventDefault();
    var note = $(".admin-note").val();
    if (note == "") {
        $('.admin-note-validation').html("İşə qəbul istəyindən imtina edildiyi halda, qeyd hissəsi boş buraxıla bilməz");
    }
    else {
        var url = $(this).attr("href") + "&note=" + note;
        fetch(url)
            .then(response => response.json())
            .then(data => {
                if (data.status == 400) {
                    $(".admin-note-validation").text("İşə qəbul istəyindən imtina edildiyi halda, qeyd hissəsi boş buraxıla bilməz")
                }
                else {
                    window.location.href = "/manage/rider/requests";
                }
            });
    }
});

$(document).on("click", ".rider-accept-button", function (e) {
    e.preventDefault();
    var note = $(".admin-note").val();
    var url = $(this).attr("href") + "&note=" + note;
    fetch(url)
        .then(response => response.json())
        .then(data => {
            window.location.href = "/manage/rider/requests";
        });
})

$(document).on('click', '.order-reject-button', function (e) {
    e.preventDefault();
    var note = $(".admin-note").val();
    if (note == "") {
        $('.admin-note-validation').html("Sifarişdən imtina edildiyi halda, qeyd hissəsi boş buraxıla bilməz");
    }
    else {
        var url = $(this).attr("href") + "&note=" + note;
        fetch(url)
            .then(response => response.json())
            .then(data => {
                if (data.status == 400) {
                    $(".admin-note-validation").text("Sifarişdən imtina edildiyi halda, qeyd hissəsi boş buraxıla bilməz")
                }
                else {
                    window.location.href = "/manage/order";
                }
            });
    }
});

$(document).on("click", ".order-accept-button", function (e) {
    e.preventDefault();
    var note = $(".admin-note").val();
    var riderId = $('.select-form').find(':selected').attr('value');
    console.log(riderId);
    var url = $(this).attr("href") + "&note=" + note + "&riderId=" + riderId;
    fetch(url)
        .then(response => response.json())
        .then(data => {
            if (data.status == 400) {
                $(".rider-validation").text("Sifarişin çatdırılması üçün kuryer təyin etməlisiniz!")
            }
            else {
                window.location.href = "/manage/order";
            }

        });
})