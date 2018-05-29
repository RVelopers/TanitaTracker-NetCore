// Reusable helper methods

$.showLoadingModal = function () {
    $('body').loadingModal({ animation: 'threeBounce' });
};

$.hideLoadingModal = function () {
    var $body = $('body');
    $body.loadingModal('hide');
    $body.loadingModal('destroy');
};

$.removeHash = function () {
    history.pushState("", document.title, window.location.pathname
        + window.location.search);
};

$.showLoadingModal = function () {
    $('body').loadingModal({ animation: 'threeBounce' });
};

$.hideLoadingModal = function () {
    var $body = $('body');
    $body.loadingModal('hide');
    $body.loadingModal('destroy');
};

// ============= Modal ======================

$.getModalWithLoader = function (url, container) {
    $.showLoadingModal();
    $.get(url, function (data) {
        $(container).html(data);
        $(container).modal({ backdrop: 'static', keyboard: false });
        $.hideLoadingModal();
        $(container).modal('show');
    });
};

$.getModalWithLoaderAndCallback = function (url, container, callback) {
    $.showLoadingModal();
    $.get(url, function (data) {
        $(container).html(data);
        $(container).modal({ backdrop: 'static', keyboard: false });
        $.hideLoadingModal();
        $(container).modal('show');
        callback();
    });
};

$.getModalWithViewModel = function(url, viewModel, container) {
    $.showLoadingModal();
    $.get(url, viewModel)
        .done(function (data) {
            $(container).html(data);
            $(container).modal({ backdrop: 'static', keyboard: false });
            $.hideLoadingModal();
            $(container).modal('show');
        });
};

// ============= GET ======================

$.getWithAjaxNotification = function (url) {
    $.showLoadingModal();
    $.ajax({
        type: 'GET',
        url: url, // the url where we want to GET
        dataType: 'json' // what type of data do we expect back from the server
    })
        .always(function () {
            $.hideLoadingModal();
        })
        // using the done promise callback
        .done(function (json) {
            if (json.hasOwnProperty("isRedirect") && json.isRedirect) {
                window.location.assign(json.redirectUrl);
            } else {
                window.location.reload();
            }
        })
        .fail(function (failData) {
            console.log(failData);
        });
};

$.getWithAjaxNotificationAndCallback = function (url, callback) {
    $.showLoadingModal();
    $.ajax({
        type: 'GET',
        url: url, // the url where we want to GET
        dataType: 'json' // what type of data do we expect back from the server
    })
        .always(function () {
            $.hideLoadingModal();
        })
        // using the done promise callback
        .done(function (json) {
            if (json.hasOwnProperty("isRedirect") && json.isRedirect) {
                window.location.href = json.redirectUrl;
            } else {
                callback(json);
            }
        })
        .fail(function (failData) {
            console.log(failData);
        });
};


// ============= POST ======================

$.postWithAjaxNotification = function (url, payload) {
    $.showLoadingModal();
    $.ajax({
        type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
        url: url, // the url where we want to POST
        data: payload, // our data object
        dataType: 'json' // what type of data do we expect back from the server
    })
        .always(function () {
            $.hideLoadingModal();
        })
        // using the done promise callback
        .done(function (json) {
            if (json.hasOwnProperty("isRedirect") && json.isRedirect) {
                window.location.assign(json.redirectUrl);
            } else {
                window.location.reload();
            }
        })
        .fail(function (failData) {
            console.log(failData);
        });
};

$.postWithAjaxNotificationAndCallback = function (url, payload, callback) {
    $.showLoadingModal();
    $.ajax({
        type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
        url: url, // the url where we want to POST
        data: payload, // our data object
        dataType: 'json' // what type of data do we expect back from the server
    })
        .always(function () {
            $.hideLoadingModal();
        })
        // using the done promise callback
        .done(function (json) {
            if (json.hasOwnProperty("isRedirect") && json.isRedirect) {
                window.location.href = json.redirectUrl;
            } else {
                callback(json);
            }
        })
        .fail(function (failData) {
            console.log(failData);
        });
};


// ============= SUBMIT ======================
$.submitFormModal = function (formElement) {
    if ($(formElement).valid()) {
        var viewModel = $(formElement).serialize();
        var url = $(formElement).attr("action"); // the url where we want to POST
        $.postWithAjaxNotification(url, viewModel);
    }
};


$.submitFormModalWithCallback = function(url, callback) {
    var form = $("form");
    if (form.valid()) {
        var viewModel = form.serialize();
        $.postWithAjaxNotificationAndCallback(url, viewModel,callback);
    }
};
