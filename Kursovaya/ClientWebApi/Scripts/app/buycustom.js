var ViewModel = {
    ListProducts: ko.observableArray(),
    Name: ko.observable(),
    f: ko.observable(""),
    i: ko.observable(""),
    o: ko.observable(""),
    Price: ko.observable(),
    actioncontroller: ko.observable(),
    MainVid: ko.observable(),
    priceRUB: ko.observable(0),
    priceUSD: ko.observable(0)
}

function Connect() {
    $('#changetable > tbody > tr').click(function () {
        if ($(this).hasClass('selected1')) {
            $('tbody tr').removeClass('selected1');
            IdProd = "0";
            Price = "0";
        } else {
            $('tbody tr').removeClass('selected1');
            $(this).addClass('selected1');
            IdProd = this.id;
            Price = this.innerHTML.match(/Price\"\S+</)[0].replace("Price\">", "").replace("<", "");
            ViewModel.priceRUB(0);
            ViewModel.priceUSD(0);
            $('.spinner input').val(0);
        }
    });
};
function GetTovarsById(id) {
    $.ajax({
        url: '/api/BuyProd/?id=' + id,
        contentType: 'application/json; charset=UTF-8',
        success: function (data) {
            ViewModel.ListProducts(data);
            Connect();
        },
        error: function (e) {
            alert(e.responseText);
        }
    });
}

function GetCurs() {
    $.ajax({
        url: '/api/BuyProd/',
        contentType: 'application/json; charset=UTF-8',
        success: function (data) {
            DollarCurs = data;
        },
        error: function (e) {
            alert(e.responseText);
        }
    });
}
$(function () {
    ko.applyBindings(ViewModel);

    window.IdProd = "0";
    window.Price = 0;
    var url = location.href;
    var array = url.split('/');

    window.DollarCurs;
    GetCurs();
    GetTovarsById(array[array.length - 1]);
    if (array[array.length - 1] == "1") {
        ViewModel.MainVid("Железобетон");
    }
    if (array[array.length - 1] == "2") {
        ViewModel.MainVid("Асфальтобетон");
    }
    if (array[array.length - 1] == "3") {
        ViewModel.MainVid("Керамзитобетон");
    }

    $('.spinner .btn:first-of-type').on('click', function () {
        if (IdProd !== "0") {
            $('.spinner input').val(parseInt($('.spinner input').val(), 10) + 1);
            ViewModel.priceRUB(Number($('.spinner input').val(), 10) * Number(Price.toString(), 10) + " руб");
            ViewModel.priceUSD(parseInt(parseInt($('.spinner input').val(), 10) * parseInt(Price, 10) / parseInt(DollarCurs, 10), 10) + " $");
        }
    });

    $('.spinner .btn:last-of-type').on('click', function () {
        if (IdProd !== "0") {
            if (parseInt($('.spinner input').val(), 10) - 1 > 0) {
                $('.spinner input').val(parseInt($('.spinner input').val(), 10) - 1);
                ViewModel.priceRUB(parseInt($('.spinner input').val(), 10) * parseInt(Price, 10) + " руб");
                ViewModel.priceUSD(parseInt(parseInt($('.spinner input').val(), 10) * parseInt(Price, 10) / parseInt(DollarCurs, 10), 10) + " $");
            }
        }
    });

    $("#cancele").click(function () {
        window.open("/Home/Index", "_self");
    });

    $("#buytovar").click(function () {
        if (IdProd !== "0" && $("#spinnercount").val() !== "0") {
            var pur = {
                Fio: ViewModel.f() + " " + ViewModel.i() + " " + ViewModel.o(),
                Price: parseInt(ViewModel.priceRUB()),
                Counttovar: $("#spinnercount").val(),
                Date: null,
                IdProduct: parseInt(IdProd, 10)
            }
            $.ajax({
                type: 'POST',
                url: '/api/BuyProd',
                data: JSON.stringify(pur),
                contentType: 'application/json; charset=UTF-8',
                success: function (data) {
                    ViewModel.actioncontroller(data);
                    $("#continuebuy").hide();
                    $("#Modal_Returner_Success").modal("show");
                },
                error: function (e) {
                    ViewModel.actioncontroller(e.responseText);
                    $("#Modal_Returner_Success").modal("show");
                }
            });
        } else {
            ViewModel.actioncontroller("Заполните все поля!");
            $("#Modal_Returner_Success").modal("show");
        }
    });
});