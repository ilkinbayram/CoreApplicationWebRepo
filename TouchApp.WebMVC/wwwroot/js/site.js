// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



/*--------------------------
    Custom JS START
---------------------------- */

///////////////////////////////
// FUNCTION  DECLARATION  START

function mailSend(propComponentIdContainer, successCallBack=null, errorCallBack=null) {

    var phone = '';
    var fromEmail = '';
    var toEmail = '';
    var message = '';
    var subject = '';
    var nameSurname = '';
    var mailType = 0;

    console.log("registerMailSend(parameters[...]) FUNCTION TRIGGERED");
    console.log("phoneId => " + propComponentIdContainer.phoneId);
    console.log("fromEmailId => " + propComponentIdContainer.fromEmailId);
    console.log("toEmailId => " + propComponentIdContainer.toEmailId);
    console.log("subjectId => " + propComponentIdContainer.subjectId);
    console.log("nameSurnameId => " + propComponentIdContainer.nameSurnameId);
    console.log("messageId => " + propComponentIdContainer.messageId);
    console.log("successCallBack => " + propComponentIdContainer.successCallBack);
    console.log("errorCallBack => " + propComponentIdContainer.errorCallBack);
    console.log("mailType => " + propComponentIdContainer.mailType);

    if (propComponentIdContainer.phoneId != '' && propComponentIdContainer.phoneId != undefined && propComponentIdContainer.phoneId != null) {
        phone = $("#" + propComponentIdContainer.phoneId).val();
    }
    if (propComponentIdContainer.fromEmailId != '' && propComponentIdContainer.fromEmailId != undefined && propComponentIdContainer.fromEmailId != null) {
        fromEmail = $("#" + propComponentIdContainer.fromEmailId).val();
    }
    if (propComponentIdContainer.toEmailId != '' && propComponentIdContainer.toEmailId != undefined && propComponentIdContainer.toEmailId != null) {
        toEmail = $("#" + propComponentIdContainer.toEmailId).val();
    }
    if (propComponentIdContainer.subjectId != '' && propComponentIdContainer.subjectId != undefined && propComponentIdContainer.subjectId != null) {
        subject = $("#" + propComponentIdContainer.subjectId).val();
    }
    if (propComponentIdContainer.nameSurnameId != '' && propComponentIdContainer.nameSurnameId != undefined && propComponentIdContainer.nameSurnameId != null) {
        nameSurname = $("#" + propComponentIdContainer.nameSurnameId).val();
    }
    if (propComponentIdContainer.messageId != '' && propComponentIdContainer.messageId != undefined && propComponentIdContainer.messageId != null) {
        message = $("#" + propComponentIdContainer.messageId).val();
    }
    if (propComponentIdContainer.mailType != '' && propComponentIdContainer.mailType != undefined && propComponentIdContainer.mailType != null && propComponentIdContainer.mailType != 0 && propComponentIdContainer.mailType != NaN) {
        mailType = propComponentIdContainer.mailType;
    }

    var emailContainer = {
        ToEmail: toEmail,
        FromEmail: fromEmail,
        Subject: subject,
        Name: nameSurname,
        Message: message,
        Phone: phone,
        MailType: mailType
    }

    $.ajax({
        url: "/Global/Home/SendMailAsync",
        method: "POST",
        data: { mailRequest: emailContainer }
    }).done(function (data) {
        if (successCallBack != null && successCallBack != undefined) {
            successCallBack(data);
        } else {
            alert(data);
            // TODO : For Success Email Response
        }
    }).fail(function (data) {
        if (errorCallBack != null && errorCallBack != undefined) {
            errorCallBack(data);
        } else {
            alert("OPPS! Something Get Wrong!");
            // TODO : For Error Email Response
        }
    });
}

// FUNCTION  DECLARATION  END
/////////////////////////////


$("#registerPartial_EmailSubmitButton").click(function (e) {
    var buttonMailType = $(e.target).data('mailtype');

    // phoneId, fromEmailId, toEmailId, subjectId, mailTypeId, nameSurnameId, messageId, mailType

    var propComponentIdContainer = {
        phoneId: 'layoutRegisterPartial_EmailPhone',
        fromEmailId: 'layoutRegisterPartial_EmailEmail',
        nameSurnameId: 'layoutRegisterPartial_EmailName',
        mailType: buttonMailType
    }
    mailSend(propComponentIdContainer);
});



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
        scrollTop: $("#teachersAreaContainer").offset().top - 110
    }, 700);
});

$(".blogs-navigator").click(function (e) {
    e.preventDefault();

    $('html, body').animate({
        scrollTop: $("#blogsAreaContainer").offset().top - 50
    }, 700);
});

$(".courses-navigator").click(function (e) {
    e.preventDefault();

    $('html, body').animate({
        scrollTop: $("#coursesAreaContainer").offset().top - 50
    }, 700);
});

/*--------------------------
    Custom JS END
---------------------------- */

