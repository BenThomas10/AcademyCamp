﻿$(document).ready(function () {
    var tmpEvent = $("#Event option:selected").text()
    $("#Event option:selected").val(tmpEvent)
    $("#Event").change(function () {
        $.get("/Registrants/FillWorkshops", { Event: $("#Event").val() }, function (data) {
            $("#Workshop").empty()
            $("#Workshop").append("<option value =''>-- Select Workshop --</option>")
            var tmpEvent = $("#Event option:selected").text()
            $("#Event option:selected").val(tmpEvent)
            $.each(data, function (index, row) {
                $("#Workshop").append("<option value='" + row.WorkshopName + "'>" + row.WorkshopName + "</option>")
            });
        });
    })
});