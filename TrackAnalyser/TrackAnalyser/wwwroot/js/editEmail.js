function createModal(elementId) {
    console.log(elementId.textContent);
$(document).ready(function () 
{
    $("#filter").on('click', function () {
        $.ajax({
            type: "GET",
            url: '/UserManagementController/EditUser',
            data: {
                email: elementId.textContent,
                newEmail: 
            },
            success: function (result) {
                $("#showTrack").html(result)
            }
        })
        return false;
    });
});

}