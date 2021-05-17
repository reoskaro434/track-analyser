$(document).ready(function () {
    $("#filter").on('change keyup', function () {
        $.ajax({
            type: "GET",
            url: '/BroadcastList/UpdateEmissionList',
            data: {
                sortNumber: $("#sortBy").prop('selectedIndex'),
                sortType: $("#sortType").prop('selectedIndex'),
                text: $("#search").val()
            },
            success: function (result) {
                $("#showTracks").html(result)
            }
        })
        return false;
    });
});