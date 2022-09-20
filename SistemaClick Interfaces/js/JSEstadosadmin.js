$(document).ready(function() {
    $('#example').DataTable( {
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'pdfHtml5',
                messageTop: 'PDF created by PDFMake with Buttons for DataTables.'
            }
        ]
    } );
} );