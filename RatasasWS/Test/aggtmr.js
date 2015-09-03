

function ajaxito() {
    $.ajax({
        type: 'POST',
        url: '../WSRatasas.asmx/getEntidades',
        data: '{reg:"23"}',
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.responseText);
        },
        dataFilter: function (data) {

            var msg = eval('(' + data + ')');
            if (msg.hasOwnProperty('d'))
                return msg.d;
            else
                return msg;
        },
        success: function (msg) {
            var cities = msg.Table;
            $.each(cities, function (index, citie) {
                $('#jsonDiv').append('<p>IDBAN=' + citie.idban + '; NOMBAN=' + citie.nombreban + '</p>');
            });
        }
    });
}