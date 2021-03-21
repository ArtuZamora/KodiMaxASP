$(document).ready(function () {
    $(".pdiv").click(function () {
        $(this).next().slideToggle("fast");
    });
    $(".MovieID").change(function () {
        $(".MovieID option:selected").each(function () {
            var id = $(this).val();
            $.ajax({
                type: "GET",
                url: "https://localhost:44387/api/MovieAPI/" + id,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $("#MovieName").val(response.Name);
                    $("#MovieDuration").val(response.Duration);
                    $("#MovieType").val($.trim(response.Type));
                    $("#MovieImage").val(response.Image);
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
    }).change();
    $(".CandyID").change(function () {
        $(".CandyID option:selected").each(function () {
            var id = $(this).val();
            $.ajax({
                type: "GET",
                url: "https://localhost:44387/api/CandyAPI/" + id,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $("#CandyName").val(response.Name);
                    $("#CandyPrice").val(response.Price);
                    $("#CandyType").val($.trim(response.Type));
                    $("#CandyImage").val(response.Image);
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
    }).change();
    $("#exportUsers").click(function () {
        $.ajax({
            type: "GET",
            url: "https://localhost:44387/api/UserAPI",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var json = JSON.stringify(response);
                json = [json];
                var blob1 = new Blob(json, { type: "text/plain;charset=utf-8" });
                var isIE = false || !!document.documentMode;
                if (isIE) {
                    window.navigator.msSaveBlob(blob1, "Users.txt");
                } else {
                    var url = window.URL || window.webkitURL;
                    link = url.createObjectURL(blob1);
                    var a = $("<a />");
                    a.attr("download", "Users.txt");
                    a.attr("href", link);
                    $("body").append(a);
                    a[0].click();
                    $("body").remove(a);
                }
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
    $("#exportMovies").click(function () {
        $.ajax({
            type: "GET",
            url: "https://localhost:44387/api/MovieAPI",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var json = JSON.stringify(response);
                json = [json];
                var blob1 = new Blob(json, { type: "text/plain;charset=utf-8" });
                var isIE = false || !!document.documentMode;
                if (isIE) {
                    window.navigator.msSaveBlob(blob1, "Movies.txt");
                } else {
                    var url = window.URL || window.webkitURL;
                    link = url.createObjectURL(blob1);
                    var a = $("<a />");
                    a.attr("download", "Movies.txt");
                    a.attr("href", link);
                    $("body").append(a);
                    a[0].click();
                    $("body").remove(a);
                }
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
    $("#exportCandies").click(function () {
        $.ajax({
            type: "GET",
            url: "https://localhost:44387/api/CandyAPI",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var json = JSON.stringify(response);
                json = [json];
                var blob1 = new Blob(json, { type: "text/plain;charset=utf-8" });
                var isIE = false || !!document.documentMode;
                if (isIE) {
                    window.navigator.msSaveBlob(blob1, "Candies.txt");
                } else {
                    var url = window.URL || window.webkitURL;
                    link = url.createObjectURL(blob1);
                    var a = $("<a />");
                    a.attr("download", "Candies.txt");
                    a.attr("href", link);
                    $("body").append(a);
                    a[0].click();
                    $("body").remove(a);
                }
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
});