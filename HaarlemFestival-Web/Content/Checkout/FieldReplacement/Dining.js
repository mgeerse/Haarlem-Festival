function GetTimeslots(_restaurantId) {
    var processMessage = "<option value='0'> Please wait...</option>";
    $("#restaurant-timeslots").html(processMessage).show();
    var url = "/Checkout/GetTimeslotsForActivity";

    $.ajax({
        url: url,
        data: { restaurantId: _restaurantId },
        cache: false,
        type: "POST",
        success: function (data) {
            var markup = "<option value='0'>Select City</option>";
            for (var x = 0; x < data.length; x++) {
                markup += "<option value=" + data[x].Value + ">" + data[x].Text + "</option>";
            }
            $("#ddlcity").html(markup).show();
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
}