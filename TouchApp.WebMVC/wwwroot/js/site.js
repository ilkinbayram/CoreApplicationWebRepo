// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



/*--------------------------
    Custom JS START
---------------------------- */

$(".vbox-close").click(function (e) {
    console.log("VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV");
});

$('body').click(function (e) {
    if (e.target.className=='stop-media-redirect-link') {
        e.preventDefault();
    }

    if (e.target.className == 'vbox-close') {
        var removableElement = document.getElementsByClassName('vbox-overlay')[0];
        removableElement.parentNode.removeChild(removableElement);
    }
});

///////////////////////////////
// FUNCTION  DECLARATION  START

function ajaxMailSend(propComponentIdContainer, mailAction, successCallBack = null, errorCallBack = null) {

    var loaderSpinner = $("#loaderSpinner");

    loaderSpinner.removeClass("displayNoneSpinner-loader");
    loaderSpinner.gSpinner();

    var phone = '';
    var fromEmail = '';
    var toEmail = '';
    var message = '';
    var subject = '';
    var nameSurname = '';
    var mailType = 0;

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
        url: "/Global/Home/"+mailAction,
        method: "POST",
        data: { mailRequest: emailContainer }
    }).done(function (data) {
        if (successCallBack != null && successCallBack != undefined) {
            successCallBack(data);
        } else {
            $("#notification-container").html(data);
            $("#notification-container").animate({
                opacity: 1
            }, 1500, function () {
                setTimeout(function (e) {
                    $("#notification-container").animate({
                        opacity: 0
                    }, 1500);
                }, 4500);
            });
        }

        // phoneId, fromEmailId, toEmailId, subjectId, mailTypeId, nameSurnameId, messageId

        if (propComponentIdContainer.phoneId != '' && propComponentIdContainer.phoneId != undefined && propComponentIdContainer.phoneId != null) {
            $("#" + propComponentIdContainer.phoneId).val('');
        }
        if (propComponentIdContainer.fromEmailId != '' && propComponentIdContainer.fromEmailId != undefined && propComponentIdContainer.fromEmailId != null) {
            $("#" + propComponentIdContainer.fromEmailId).val('');
        }
        if (propComponentIdContainer.toEmailId != '' && propComponentIdContainer.toEmailId != undefined && propComponentIdContainer.toEmailId != null) {
            $("#" + propComponentIdContainer.toEmailId).val('');
        }
        if (propComponentIdContainer.subjectId != '' && propComponentIdContainer.subjectId != undefined && propComponentIdContainer.subjectId != null) {
            $("#" + propComponentIdContainer.subjectId).val('');
        }
        if (propComponentIdContainer.mailTypeId != '' && propComponentIdContainer.mailTypeId != undefined && propComponentIdContainer.mailTypeId != null) {
            $("#" + propComponentIdContainer.mailTypeId).val('');
        }
        if (propComponentIdContainer.nameSurnameId != '' && propComponentIdContainer.nameSurnameId != undefined && propComponentIdContainer.nameSurnameId != null) {
            $("#" + propComponentIdContainer.nameSurnameId).val('');
        }
        if (propComponentIdContainer.messageId != '' && propComponentIdContainer.messageId != undefined && propComponentIdContainer.messageId != null) {
            $("#" + propComponentIdContainer.messageId).val('');
        }

        loaderSpinner.gSpinner('hide');
        loaderSpinner.addClass("displayNoneSpinner-loader");

    }).fail(function (data) {
        if (errorCallBack != null && errorCallBack != undefined) {
            errorCallBack(data);
        } else {
            $("#notification-container").html(data);
            $("#notification-container").animate({
                opacity: 1
            }, 1500, function () {
                setTimeout(function (e) {
                    $("#notification-container").animate({
                        opacity: 0
                    }, 1500);
                }, 4500);
            });
        }

        loaderSpinner.gSpinner('hide');
        loaderSpinner.addClass("displayNoneSpinner-loader");
        
    });
}

// FUNCTION  DECLARATION  END
/////////////////////////////


$("#registerPartial_EmailSubmitButton").click(function (e) {

    var element = $("#registerPartial_EmailSubmitButton");

    var buttonMailType = $(element).data("mailtype");

    // phoneId, fromEmailId, toEmailId, subjectId, mailTypeId, nameSurnameId, messageId, mailType

    var propComponentIdContainer = {
        phoneId: 'layoutRegisterPartial_EmailPhone',
        fromEmailId: 'layoutRegisterPartial_EmailEmail',
        nameSurnameId: 'layoutRegisterPartial_EmailName',
        mailType: buttonMailType
    }
    ajaxMailSend(propComponentIdContainer, "SendMailAsync");
});

$("#quickRegisterFieldBtn").click(function (e) {

    var element = $("#quickRegisterFieldBtn");

    var buttonMailType = $(element).data("mailtype");

    // phoneId, fromEmailId, toEmailId, subjectId, mailTypeId, nameSurnameId, messageId, mailType

    var propComponentIdContainer = {
        fromEmailId: 'quickRegisterFieldEmail',
        mailType: buttonMailType
    }

    ajaxMailSend(propComponentIdContainer, "SendMailAsync");
});

$("#layoutInformaionMailPartial_SendBtn").click(function (e) {

    var element = $("#layoutInformaionMailPartial_SendBtn");

    var buttonMailType = $(element).data("mailtype");

    // phoneId, fromEmailId, toEmailId, subjectId, mailTypeId, nameSurnameId, messageId, mailType

    var propComponentIdContainer = {
        subjectId: 'layoutInformaionMailPartial_Subject',
        fromEmailId: 'layoutInformaionMailPartial_Email',
        nameSurnameId: 'layoutInformaionMailPartial_Name',
        messageId: 'layoutInformaionMailPartial_Message',

        mailType: buttonMailType
    }

    ajaxMailSend(propComponentIdContainer, "SendMailAsync");
});

$("#contactInformaionMailPartial_SendBtn").click(function (e) {

    var element = $("#contactInformaionMailPartial_SendBtn");

    var buttonMailType = $(element).data("mailtype");

    // phoneId, fromEmailId, toEmailId, subjectId, mailTypeId, nameSurnameId, messageId, mailType

    var propComponentIdContainer = {
        subjectId: 'contactInformaionMailPartial_Subject',
        fromEmailId: 'contactInformaionMailPartial_Email',
        nameSurnameId: 'contactInformaionMailPartial_Name',
        messageId: 'contactInformaionMailPartial_Message',
        mailType: buttonMailType
    }

    ajaxMailSend(propComponentIdContainer, "SendMailAsync");
});

$(".languagesNavBtn").click(function (e) {
    e.preventDefault();
});

$(".allPagesNavBtn").click(function (e) {
    e.preventDefault();
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

