var theme = window.localStorage.currentTheme;

$('body').addClass(theme);

if ($("body").hasClass("night")) {
    $('.dntoggle').addClass('fa-sun');
    $('.dntoggle').removeClass('fa-moon');
} else {
    $('.dntoggle').removeClass('fa-sun');
    $('.dntoggle').addClass('fa-moon');
}

function nightModeToggler() {

    $('.dntoggle').toggleClass('fa-sun');
    $('.dntoggle').toggleClass('fa-moon');

    if ($("body").hasClass("night")) {
        $('body').toggleClass('night');
        localStorage.removeItem('currentTheme');
        localStorage.currentTheme = "day";
    } else {
        $('body').toggleClass('night');
        localStorage.removeItem('currentTheme');
        localStorage.currentTheme = "night";
    }
}
