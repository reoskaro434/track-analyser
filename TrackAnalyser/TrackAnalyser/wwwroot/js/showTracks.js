$(document).ready(function () {
    $("#sort").on('change',function () {
        $.ajax({
            type: "GET",
            url: '/BroadcastList/SortByDuration',
            data: {
                sortNumber: $("#sortBy").prop('selectedIndex'),
                sortType: $("#sortType").prop('selectedIndex')
            },
            success: function (result) {
                $("#showTrack").html(result)
            }
        })
        return false;
    });
});