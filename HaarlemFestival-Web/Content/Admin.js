$(document).ready(function () {
    $('#myInput').keyup(function () {
        // Declare variables 
        var input, filter, table, tr, td, i;
        input = document.getElementById("myInput");
        filter = input.value.toUpperCase();
        table = document.getElementById("myTable");
        tr = table.getElementsByTagName("tr");

        // Loop through all table rows, and hide those who don't match the search query
        for (i = 0; i < tr.length; i++) {
            var foundCells = $(tr[i]).find("td:contains(" + filter + ")");
            if (foundCells.length == 0 && $(tr[i]).has(".filter-row")) {
                $(tr[i]).hide();
            } else {
                $(tr[i]).show();
            }
        }
    });
});