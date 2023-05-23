// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.setTimeout(function () {
    $(".alert").fadeTo(800, 0).slideUp(600, function () {
        $(this).remove();
    })
}, 3000);
