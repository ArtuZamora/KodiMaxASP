var candyID, movieID;
var candyPrice, candyPEn, candyTotPrice, candyName;
var exhibitionRoom, moviePrice, numTickets, movieTotPrice, moviePriceE, movieName;
var regularSeats = 64, premiumSeats = 40, vipSeats = 30;

$(document).ready(function () {
    $("#activeMovies").click(function () {
        $("#activeMovies").parent().addClass("active");
        $("#activeCandies").parent().removeClass("active");
        $("#activeBuyTicket").parent().removeClass("active");
        $("#activeBuyCandy").parent().removeClass("active");
        $("#CandyDetails").hide();
        $("#BuyMovieTicketDetail").hide();
        $("#BuyCandyDetail").hide();
        $("#MovieDetails").show();
    });
    $("#activeCandies").click(function () {
        $("#activeCandies").parent().addClass("active");
        $("#activeBuyTicket").parent().removeClass("active");
        $("#activeBuyCandy").parent().removeClass("active");
        $("#activeMovies").parent().removeClass("active");
        $("#MovieDetails").hide();
        $("#BuyMovieTicketDetail").hide();
        $("#BuyCandyDetail").hide();
        $("#CandyDetails").show();
    });
    $("#activeBuyTicket").click(function () {
        $("#activeBuyTicket").parent().addClass("active");
        $("#activeBuyCandy").parent().removeClass("active");
        $("#activeMovies").parent().removeClass("active");
        $("#activeCandies").parent().removeClass("active");
        $("#MovieDetails").hide();
        $("#CandyDetails").hide();
        $("#BuyCandyDetail").hide();
        $("#BuyMovieTicketDetail").show();
    });
    $("#activeBuyCandy").click(function () {
        $("#activeBuyCandy").parent().addClass("active");
        $("#activeMovies").parent().removeClass("active");
        $("#activeCandies").parent().removeClass("active");
        $("#activeBuyTicket").parent().removeClass("active");
        $("#MovieDetails").hide();
        $("#CandyDetails").hide();
        $("#BuyMovieTicketDetail").hide();
        $("#BuyCandyDetail").show();
    });
    $(".movie").click(function (event) {
        movieID = event.target.id;
        $("#activeBuyTicket").show("slow");

    });
    $(".candy").click(function (event) {
        candyID = event.target.id;
        $("#activeBuyCandy").show("slow");
        $.ajax({
            type: "GET",
            url: "https://localhost:44387/api/CandyAPI/" + candyID,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                candyName = response.Name;
                $("#SelectedCandyTitle").text(response.Name);
                $("#SelectedCandyPrice").text("$" + response.Price);
                $("#SelectedCandyType").text($.trim(response.Type));
                $("#SelectedCandyPicture").css("background-image", 'url(' + response.Image + ')');
                candyPrice = response.Price;
            },
            failure: function (response) {
                alert(response.responseText);
                alert("Failure");
            },
            error: function (response) {
                alert(response);
                alert("Error");
            }
        });
    });
    $(".movie").click(function (event) {
        movieID = event.target.id;
        $("#activeBuyTicket").show("slow");
        $.ajax({
            type: "GET",
            url: "https://localhost:44387/api/MovieAPI/" + movieID,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                movieName = response.Name;
                $("#SelectedMovieTitle").text(response.Name);
                $("#SelectedMovieDuration").text(response.Duration);
                $("#SelectedMovieType").text($.trim(response.Type));
                $("#SelectedMoviePicture").css("background-image", 'url(' + response.Image + ')');
            },
            failure: function (response) {
                alert(response.responseText);
                alert("Failure");
            },
            error: function (response) {
                alert(response);
                alert("Error");
            }
        });
    });

    $("#numCandy").bind('keyup mouseup', function () {
        candyTotPrice = candyPrice * $("#numCandy").val() * 1.0453;
        $("#candyTotalPrice").text("Precio total (con impuesto 4.53%):  $" + Math.round(candyTotPrice * 100) / 100);
    });
    $("#candyPriceEnter").bind('keyup mouseup', function () {
        candyPEn = $(this).val();
        if (candyPEn >= candyTotPrice) {
            $("#NotMoney").hide();
        }
        else {
            $("#NotMoney").show();
            $("#NotMoney").text("No hay dinero suficiente");
        }
    });
    $("#btnBuyCandy").click(function () {
        if (candyPEn == candyTotPrice) {
            var d = new Date();
            alert("Cobro exacto, gracias por comprar en KODIMAX.\n \
                ++Ticket++ \n \
                Cine: KodiMax\n \
                Fecha y Hora: "+ d.toDateString() + "\n \
                Nombre del producto comprado: "+ candyName + "\n \
                Cantidad: "+ $("#numCandy").val() + "\n \
                Subtotal: $"+ Math.round((candyTotPrice / 1.0453) * 100) / 100 + "\n \
                Impuesto: 4.53% \n \
                Total: $"+ Math.round(candyTotPrice * 100) / 100);
            location.reload();
        }
        else if (candyPEn > candyTotPrice) {
            var d = new Date();
            alert("Su cambio es $" + (candyPEn - candyTotPrice) + ", gracias por comprar en KODIMAX\n \
                ++Ticket++ \n \
                Cine: KodiMax\n \
                Fecha y Hora: "+ d.toDateString() + "\n \
                Nombre del producto comprado: "+ candyName + "\n \
                Cantidad: "+ $("#numCandy").val() + "\n \
                Subtotal: $"+ candyTotPrice / 1.453 + "\n \
                Impuesto: 4.53% \n \
                Total: $"+ candyTotPrice);
            location.reload();
        }
        else {
            alert("Pago insuficiente");
        }
    });
    $("#mType").change(function () {
        $("#mType option:selected").each(function () {
            exhibitionRoom = $(this).val();
            if (exhibitionRoom === "Estandar") moviePrice = 3.55;
            else if (exhibitionRoom === "Premium") moviePrice = 4.75;
            else if (exhibitionRoom === "VIP") moviePrice = 6.50;
        });
    }).change();
    $("#numTickets").bind('keyup mouseup', function () {
        movieTotPrice = $("#numTickets").val() * moviePrice * 1.3533;
        $("#movietotPrice").text("Precio total (con impuesto 13.3533%):  $" + Math.round(movieTotPrice * 100) / 100);
        if (exhibitionRoom === "Estandar") {
            if (regularSeats < $("#numTickets").val()) $("#validateSeats").show();
            else $("#validateSeats").hide();
        }
        else if (exhibitionRoom === "Premium") {
            if (premiumSeats < $("#numTickets").val()) $("#validateSeats").show();
            else $("#validateSeats").hide();
        }
        else if (exhibitionRoom === "VIP") {
            if (vipSeats < $("#numTickets").val()) $("#validateSeats").show();
            else $("#validateSeats").hide();
        }
    });
    $("#moviePriceEnter").bind('keyup mouseup', function () {
        moviePriceE = $(this).val();
        if (moviePriceE >= movieTotPrice) $("#NotMoneyMovie").hide();
        else $("#NotMoneyMovie").show();
    });
    $("#btnBuyMovie").click(function () {
        if (moviePriceE == movieTotPrice) {
            var d = new Date();
            alert("Cobro exacto, gracias por comprar en KODIMAX.\n \
                ++Ticket++ \n \
                Cine: KodiMax\n \
                Fecha y Hora: "+ d.toDateString() + "\n \
                Nombre de la pelicula a ver comprado: "+ movieName + "\n \
                Sala de exhibicion: "+ exhibitionRoom + "\n \
                Cantidad de tickets: "+ $("#numTickets").val() + "\n \
                Subtotal: $"+ Math.round((movieTotPrice / 1.3533) * 100) / 100 + "\n \
                Impuesto: 35.33% \n \
                Total: $"+ Math.round(movieTotPrice * 100) / 100);
            location.reload();
        }
        else if (moviePriceE > movieTotPrice) {
            var d = new Date();
            alert("Su cambio es $" + (moviePriceE - movieTotPrice) + ", gracias por comprar en KODIMAX\n \
                ++Ticket++ \n \
                Cine: KodiMax\n \
                Fecha y Hora: "+ d.toDateString() + "\n \
                Nombre de la pelicula a ver comprado: "+ movieName + "\n \
                Sala de exhibicion: "+ exhibitionRoom + "\n \
                Cantidad de tickets: "+ $("#numTickets").val() + "\n \
                Subtotal: $"+ Math.round((movieTotPrice / 1.3533) * 100) / 100  + "\n \
                Impuesto: 35.33% \n \
                Total: $"+ Math.round(movieTotPrice * 100) / 100);
            location.reload();
        }
        else {
            alert("Pago insuficiente");
        }
    });
});