function search() {
   let searchText = $('#searchText').val();

   let mactchedElements = $(`#towns li:contains(${searchText})`);
   $('#towns li').css('font-weight', '');
   mactchedElements.css('font-weight', 'bold');

   $('#result').text(`${mactchedElements.length} matches found`);
}