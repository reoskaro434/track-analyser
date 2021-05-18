$(document).ready(function () {
    $("#download").on('click', function () {
        $.ajax({
            type: "GET",
            url: '/BroadcastList/DownloadExcel',
            success: function () {
                window.location = '/BroadcastList/DownloadExcel?sortNumber=' + $("#sortBy").prop('selectedIndex') +
                    '&sortType=' + $("#sortType").prop('selectedIndex')+'&text=' +$("#search").val()

            }
        })
      
    });
});