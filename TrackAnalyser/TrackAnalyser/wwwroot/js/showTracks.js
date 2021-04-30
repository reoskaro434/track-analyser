$(document).ready(function () {
    $("#duration").click(function () {
        $.ajax({
            type: "GET",
            url: '/BroadcastList/SortByDuration',       
            success: function (result) {
                $("#showTrack").html(result)
            }
        })
        return false;
    });
});