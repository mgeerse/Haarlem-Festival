$("#restaurants").change(function () {
    var processMessage = "<option value='0'> Please wait...</option>";
    $("#dining-timeslots").html(processMessage).show();
    var url = "/Checkout/GetTimeslotsForRestaurant";

    $.ajax({
        url: url,
        cache: false,
        dataType: "json",
        type: "POST",
        success: function (data) {
            alert(JSON.stringify(data));
            var markup = "<option value='0'>Select a timeslot</option>";
            for (var x = 0; x < data.length; x++) {
                markup += "<option value=" + data[x].Id + ">" + data[x].StartTime + " - " + data[x].EndTime + "</option>";
            }
            $("#dining-timeslots").html(markup).show();
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
});