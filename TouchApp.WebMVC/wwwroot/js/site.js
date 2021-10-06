// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



/*--------------------------
    Custom JS START
---------------------------- */

$("#locationModalTrigger").click(function (e) {
    e.preventDefault();
});

$(".setLangListItem").click(function (e) {
    e.preventDefault();

    var loaderSpinner = $("#loaderSpinner");

    loaderSpinner.removeClass("displayNoneSpinner-loader");
    loaderSpinner.gSpinner();

    var langOid = 1;

    if (e.target.tagName == 'A') {
        langOid = $(e.target.parentElement).data('langoid');
    } else {
        langOid = $(e.target).data('langoid');
    }

    var pathName = window.location.pathname;

    var controller = "";
    var action = "";
    var areaName = "";

    if (pathName == '/') {
        controller = "Home";
        action = "TouchIndex";
        areaName = "Global";
    }
    else if (pathName == '/General') {
        controller = "Home";
        action = "TouchIndex";
        areaName = "Global";
    }
    else {
        areaName = pathName.split('/')[1];
        controller = pathName.split('/')[2];
        action = pathName.split('/')[3];
    }

    $.ajax({
        method: "POST",
        url: "/Global/Language/SetLanguage?langOid=" + langOid + "&controllerName=" + controller + "&actionName=" + action + "&areaName=" + areaName
    }).done(function (d) {
        $(document).ajaxStop(function () {
            window.location.reload();
            loaderSpinner.gSpinner('hide');
            loaderSpinner.addClass("displayNoneSpinner-loader");
        });
    }).fail(function (d) {
        alert("Opps :( Something Get Wrong!");
    });
});

$(".teachers-navigator").click(function (e) {
    e.preventDefault();

    $('html, body').animate({
        scrollTop: $("#teachersAreaContainer").offset().top-110
    }, 700);
});

$(".blogs-navigator").click(function (e) {
    e.preventDefault();

    $('html, body').animate({
        scrollTop: $("#blogsAreaContainer").offset().top-50
    }, 700);
});

$(".courses-navigator").click(function (e) {
    e.preventDefault();

    $('html, body').animate({
        scrollTop: $("#coursesAreaContainer").offset().top-50
    }, 700);
});

/*--------------------------
    Custom JS END
---------------------------- */

