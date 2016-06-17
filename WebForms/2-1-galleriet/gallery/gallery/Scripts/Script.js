window.onload = function () {
    var images = document.getElementsByTagName('a');
    for (var i = 0; i < images.length; i++) {
        if (images[i] == window.location.href) {
            images[i].parentNode.style.border="2px ridge #26E3F2";         
        }
    }
}