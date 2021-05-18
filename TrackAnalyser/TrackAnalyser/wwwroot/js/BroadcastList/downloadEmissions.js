$(document).ready(function () {
    $("#download").on('click', function () {
        $.ajax({
            type: "GET",
            url: '/BroadcastList/InitializeDownload',
            success: function () {
                window.location.href = '/BroadcastList/DownloadExcel?sortNumber=' + $("#sortBy").prop('selectedIndex') +
                    '&sortType=' + $("#sortType").prop('selectedIndex')+'&text=' +$("#search").val()

            }
        })    
    });
});