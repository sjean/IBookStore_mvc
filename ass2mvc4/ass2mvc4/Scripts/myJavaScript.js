$(document).ready(function () {

    $('#user_table').DataTable();
    $('#user_table thead tr').css('background-color', '#66b3ff')

    $('#user_table tbody tr:even').addClass('skyblue');

    $('#user_table tbody tr').mouseover(function () {

        $(this).addClass('dataHover');

    });

    $('#user_table  tbody tr').mouseout(function () {
       
        $(this).removeClass('dataHover');
        
    });

});