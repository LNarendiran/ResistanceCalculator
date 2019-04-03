$(document).ready(function () {
    $("select").change(function () {
        var strBackgroundColor = $('option:selected', this).text();
        if (strBackgroundColor.trim().toLowerCase() == "select") strBackgroundColor = "white"; 
        $(this).css('background-color', strBackgroundColor);
        $("#lblFirstBand").text($('#ddlFirstBand').val());
        $("#lblSecondBand").text($('#ddlSecondBand').val());
        $("#lblThirdBand").text($('#ddlThirdBand').val());
        $("#lblFourthBand").text($('#ddlFourthBand').val());
    });

    $("#btnSubmit").click(function () {     
    
        ResetErrorandResult();

        //Gets all four band colors
        var strbandAColor = $('#ddlFirstBand option:selected').text();
        var strbandBColor = $('#ddlSecondBand option:selected').text();
        var strbandCColor = $('#ddlThirdBand option:selected').text();
        var strbandDColor = $('#ddlFourthBand option:selected').text();  

        //Gets all four band values
        var strbandAValue = $('#ddlFirstBand').val();
        var strbandBValue = $('#ddlSecondBand').val();
        var strbandCValue = $('#ddlThirdBand').val();
        var strbandDValue = $('#ddlFourthBand').val();

        //Construct Resistor Object
        var objResistor = JSON.stringify({
            Firstband: { Color: strbandAColor, Value: strbandAValue },
            Secondband: { Color: strbandBColor, Value: strbandBValue },
            Thirdband: { Color: strbandCColor, Exponent: strbandCValue },
            Fourthband: { Color: strbandDColor, Value: strbandDValue },
            Value: null
        });      

        // ajax call returns the resistance values as ajax JSON response.
        $.ajax({
            type: "POST",
            url: "/Resistor/CalculateOhmValue",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: objResistor,
            success: function (result) {
                //if error
                if (result.error != undefined) {
                    $("#divError").html(result.error);
                }
                else {
                    $("#divError").empty();
                    $("#txtMinimumResistance").val(result.min);
                    $("#txtNormalResistance").val(result.normal);
                    $("#txtMaximumResistance").val(result.max);
                }
            }
        });

    });

    $("#btnReset").click(function () {
        $('select').val("");
        $('select').css('background-color', "white");
        ResetErrorandResult();
    });

    function ResetErrorandResult(){       
        $("#divError").empty();
        $(':text').val("");
    }
})