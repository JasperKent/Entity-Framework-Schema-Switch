function setCookie(cname, cvalue, exdays) {
    if (exdays === undefined)
        exdays = 365;

    let d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    let expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
    let name = cname + "=";
    let ca = document.cookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) === ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) === 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

(function () {
    let language = getCookie("language") || "english";

    $(`a.lang-butt img[title=${language}]`).addClass("selected-language");

    $("a.lang-butt").click(function () {
        setCookie("language", $(this).find("img").attr("title"));
        location.reload();
    })
})();