// Register Click handlers
$(document).ready(function ()
{
    // Approve
    $(".approve").click(SendApprove);
    // Flag

});


// Set errata status to "Confirmed"
function SendApprove(errataID)
{
    debugger;
    var errata_ID = parseInt($(errataID.target).attr("data-errata-id"));

    var request = $.ajax({
        url: '/errata/approve',
        type: 'POST',
        dataType: 'JSON',
        data: { id: errata_ID },
        cache: false,
        success: function (data) {
            alert("Message Sent - Now Update the UI..., Please check details");
            
        }
    });
}