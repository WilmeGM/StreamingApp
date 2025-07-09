// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", function () {
    const titles = document.querySelectorAll('.serie-title');

    titles.forEach(title => {
        if (title.textContent.length > 15) {
            title.textContent = title.textContent.substring(0, 17) + '...';
        }
    });
});