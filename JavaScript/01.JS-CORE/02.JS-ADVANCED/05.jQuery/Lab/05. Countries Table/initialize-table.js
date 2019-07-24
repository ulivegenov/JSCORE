function initializeTable() {
    $('#createLink').on('click', create)

    addCountryToTable('Bulgaria', 'Sofia');
    addCountryToTable('Germany', 'Berlin');
    addCountryToTable('Russia', 'Moscow');
    fixRwoLinks();

    function addCountryToTable(country, capital){
        let row = $('<tr>');
        row
            .append($('<td>').text(country))
            .append($('<td>').text(capital))
            .append($('<td>')
                .append($("<a href='#'>[Up]</a>").on('click', moveRowUp))
                .append($("<a href='#'>[Down]</a>").on('click', moveRowDown))
                .append($("<a href='#'>[Delete]</a>").on('click', deleteRow)));
        
        row.css('display', 'none');
        $('#countriesTable').append(row);
        row.fadeIn();
    }

    function moveRowUp(){
        let row = $(this).parent().parent();
        row.fadeOut(function(){
            row.insertBefore(row.prev());
            row.fadeIn();
            fixRwoLinks();
        });
    }

    function moveRowDown(){
        let row = $(this).parent().parent();
        row.fadeOut(function(){
            row.insertAfter(row.next());
            row.fadeIn();
            fixRwoLinks();
        });
    }

    function deleteRow(){
        let row = $(this).parent().parent();
        row.fadeOut(function(){
            row.remove();
            fixRwoLinks();
        })
    }

    function fixRwoLinks(){
        $('#countriesTable a').css('display', 'inline');

        let tableRows = $('#countriesTable tr');
        $(tableRows[2]).find("a:contains('Up')").css('display','none');
        $(tableRows[tableRows.length - 1]).find("a:contains('Down')").css('display','none');
    }


    function create(){
        let country = $('#newCountryText').val();
        let capital = $('#newCapitalText').val();
        addCountryToTable(country, capital);
        $('#newCountryText').val('');
        $('#newCapitalText').val('');
        fixRwoLinks();
    }
}