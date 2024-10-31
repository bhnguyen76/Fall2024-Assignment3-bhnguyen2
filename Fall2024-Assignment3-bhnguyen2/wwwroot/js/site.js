// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {
    // Initialize DataTables for all tables with the class 'datatable'
    $('.datatable').DataTable({
        "paging": true,
        "searching": true,
        "ordering": true,
        "lengthChange": true,
        "info": true,
        "autoWidth": false,
        "responsive": true,
    });
});

// Write your JavaScript code.
