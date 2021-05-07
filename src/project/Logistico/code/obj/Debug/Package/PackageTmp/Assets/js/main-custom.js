$(function () {
    $("#btnSearch").on("click", function () {
        var searchterm = $("#txtSearch").val();
        if (searchterm != "") {
            $.ajax({
                url: "api/search/SearchResult",
                type: "POST",
                data: { searchTerm: searchterm },
                context: this,
                success: function (data) {
                    window.location.href = "/en/search?searchterm=" + searchterm;
                    console.log("success", searchterm);
                },
                error: function (data) {
                    console.log("error", searchterm);
                }
            });
        }
        else {
            $("#txtSearch").text("");
        }
    });
});

$(function () {
    $("#btnSearchpage").on("click", function () {
        var searchterm = $("#txtSearchpage").val();
        if (searchterm != "") {
            $.ajax({
                url: "api/search/SearchResult",
                type: "POST",
                data: { searchTerm: searchterm },
                context: this,
                success: function (data) {
                    window.location.href = "/en/search?searchterm=" + searchterm;
                    console.log("success", searchterm);
                },
                error: function (data) {
                    console.log("error", searchterm);
                }
            });
        }
        else {
            $("#txtSearch").text("");
        }
    });
});