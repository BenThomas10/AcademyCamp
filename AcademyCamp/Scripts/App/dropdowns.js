function FillUnit() {
    var EventId = $('#Event').val();
    $.ajax({
        url: '/Registrants/FillUnit',
        type: "GET",
        dataType: "JSON",
        data: { Event: EventId },
        success: function (units) {
            $("#Unit").html(""); // clear before appending new list 
            $.each(units, function (i, unit) {
                $("#Unit").append(
                    $('<option></option>').val(unit.UnitId).html(unit.Name));
            });
        }
    });
}