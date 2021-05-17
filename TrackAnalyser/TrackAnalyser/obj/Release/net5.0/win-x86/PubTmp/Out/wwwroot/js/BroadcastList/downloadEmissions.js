$(document).ready(function () {
    $("#download").on('click', function () {
        $.ajax({
            type: "GET",
            url: '/BroadcastList/GetEmissionList',
            data: {
                sortNumber: $("#sortBy").prop('selectedIndex'),
                sortType: $("#sortType").prop('selectedIndex'),
                text: $("#search").val()
            },
            success: function () {
                    window.location = '/BroadcastList/DownloadEmissionList'

            }
        })
        return false;
    });
});