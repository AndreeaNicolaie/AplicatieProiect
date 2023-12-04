document.addEventListener("DOMContentLoaded", function () {
    var navbarLinks = document.querySelectorAll('.navbar a');

    navbarLinks.forEach(function (link) {
        link.addEventListener('mouseover', function () {
            this.style.transform = 'scale(1.2)';
        });

        link.addEventListener('mouseout', function () {
            this.style.transform = 'scale(1)';
        });
    });
});
