function ShowDiscogsAlbum(resource_url, albumOnPage) {

    if (resource_url != "") {

        $.ajax({
            url: "/Home/Links",
            data: { link: resource_url }

        }).done(function (album) {

            var albumJson = JSON.parse(album);

            var container = document.getElementById("container");
            container.innerHTML = "";

            ShowAlbum(albumJson, albumOnPage);
        }).fail(function (error) {
            console.log("Błąd pobieranie albumu")
        });
    }
    else {
        var container = document.getElementById("container");
        container.innerHTML = "";

        if (albumOnPage != "" && albumOnPage != null) {
            ShowAlbum(albumOnPage, "");
        }
    }

}

function ShowAlbum(album, albumOnPage) {

    var container = document.getElementById("container");

    if (albumOnPage != "") {
        var button = AddButton("Back", "warning");
        button.addEventListener("click", function () {
            getAlbums("", { link: "=1" }, albumOnPage)
        });
        container.appendChild(button);
    }

    if (typeof album.title != 'undefined') {
        var h3 = AddText("h3", album.title);
        container.appendChild(h3);
    }

    if (typeof album.artists != 'undefined') {
        var h3 = AddText("h5", album.artists[0].name);
        container.appendChild(h3);
    }


    if (typeof album.genres != 'undefined') {
        var h5 = AddText("h6", album.genres.join(", "));
        container.appendChild(h5);
    }

    AddCarousell(container, album);
    var hr = document.createElement("hr");
    container.appendChild(hr);

    AddTrackList(container, album);
    container.appendChild(hr);
    AddNavYt(album)

}

function AddNavYt(album) {

    var divYtNav = document.createElement("div");
    divYtNav.setAttribute("id", "player-nav");
    divYtNav.setAttribute("actual", "0");
    if (typeof album.videos != 'undefined') {
        divYtNav.setAttribute("max", `${album.videos.length - 1}`);
    }
    var bNext = AddButton("Next", "info");
    bNext.classList.add("btn-lg")
    var bPrev = AddButton("Prev", "secondary");
    bPrev.classList.add("btn-lg")

    divYtNav.appendChild(bPrev);
    divYtNav.appendChild(bNext);

    var text = document.createElement("p");
    text.classList.add("paragraph-content")
    text.setAttribute("id", "title-video")
    divYtNav.appendChild(text);

    container.appendChild(divYtNav);

    var divYt = document.createElement("div");
    divYt.setAttribute("id", "player");

    if (typeof album.videos != 'undefined') {
        for (let i = 0; i < album.videos.length; i++) {

            var a = document.createElement("a");
            a.setAttribute("href", album.videos[i].uri);

            var div = document.createElement("div");
            div.style.display = "none";

            div.appendChild(a);

            divYtNav.appendChild(div);
        }
    }

    container.appendChild(divYt);

    AddYoutubeFrame(0, album)

    bNext.addEventListener("click", function () {
        var div = document.getElementById("player-nav");
        var actual = parseInt(div.getAttribute("actual")) + 1;
        var max = div.getAttribute("max");

        if (actual > max) actual = 0;

        div.setAttribute("actual", actual);

        AddYoutubeFrame(actual, album);

    });

    bPrev.addEventListener("click", function () {
        var div = document.getElementById("player-nav");
        var actual = parseInt(div.getAttribute("actual")) - 1;
        var max = div.getAttribute("max");

        if (actual < 0) actual = max;

        div.setAttribute("actual", actual);

        AddYoutubeFrame(actual, album);

    });
}

function AddYoutubeFrame(actual, album) {

    var p = document.getElementById("title-video");
    if (typeof album.videos != 'undefined') {
        p.innerText = album.videos[actual].description


        var container = document.getElementById("container");

        $("#player").remove();

        var divYt = document.createElement("div");
        divYt.setAttribute("id", "player");

        container.appendChild(divYt);

        var id;
        var linkYt = album.videos[actual].uri;

        for (let j = 0; j < 100; j++) {
            if (linkYt[linkYt.length - 1 - j] == "=") {
                id = linkYt.substring(linkYt.length - j, linkYt.length)
                break;
            }
        }
    }
    var player;

    player = new YT.Player('player', {
        height: '180',
        width: '320',
        videoId: id,

    });
}


function AddTrackList(container, album) {
    var div = document.createElement("div");
    div.setAttribute("id", "track-list-collapse")
    var a = AddTrackListButton();
    div.appendChild(a);

    var divCard = document.createElement("div");
    divCard.classList.add("card");
    divCard.classList.add("card-body");

    if (typeof album.tracklist != 'undefined') {
        for (let i = 0; i < album.tracklist.length; i++) {
            var p = document.createElement("p");
            p.classList.add("paragraph-content");
            p.innerText = `${album.tracklist[i].position} ${album.tracklist[i].duration} ${album.tracklist[i].title}, \nextra artist: `;

            var div2 = document.createElement("div");

            if (typeof album.tracklist[i].extraartists != 'undefined') {

                for (let j = 0; j < album.tracklist[i].extraartists.length; j++) {

                    var aArtist = document.createElement("a");
                    aArtist.classList.add("btn");
                    aArtist.classList.add("btn-link");
                    aArtist.setAttribute("href", "#");
                    aArtist.innerText = album.tracklist[i].extraartists[j].name;

                    aArtist.addEventListener("click", function () {
                        console.log(album.tracklist[i].extraartists[j].name + "DODAJ IMPLEMENTACJE!!!!");
                        alert("DODAJ IMPLEMENTACJE!!!!");
                    });
                    p.classList.add("border");
                    p.classList.add("border-primary");
                    div2.appendChild(aArtist);


                }
                p.appendChild(div2);
            }

            divCard.appendChild(p);

        }
    }

    var divCollapse = document.createElement("div");
    divCollapse.classList.add("collapse");
    divCollapse.setAttribute("id", "tracklist");

    divCollapse.appendChild(divCard);

    div.appendChild(divCollapse);

    container.appendChild(div);
}

function AddTrackListButton() {
    var a = document.createElement("a");
    a.classList.add("btn");
    a.classList.add("btn-primary");
    a.style.color = "white";
    a.innerText = "Track list";

    a.addEventListener("click", function () {

        if ($("#tracklist").is(":hidden")) {
            $("#tracklist").show("slow");
        } else {
            $("#tracklist").slideUp();
        }
    });

    return a;
}

function AddText(type, text) {
    var at = document.createElement(type);
    at.innerText = text;
    return at;
}

function AddImg(src, i, length) {

    var img = document.createElement("img");
    img.setAttribute("src", src);
    img.setAttribute("alt", "image" + i);
    img.setAttribute("actual", i);
    img.setAttribute("max", length);


    img.classList.add("d-block");
    img.classList.add("w-100");


    img.setAttribute("id", "img-" + i);
    return img;
}

function AddDiv(divCLass = []) {

    var div = document.createElement("div");
    if (divCLass.length != 0) {
        for (let i = 0; i < divCLass.length; i++) {
            div.classList.add(divCLass[i]);
        }
    }

    return div;
}

function AddCarousell(container, album) {

    var divCarrousel = AddDiv(["carousel", "slide"]);
    divCarrousel.setAttribute("data-ride", "carousel");
    divCarrousel.setAttribute("id", "carouselExampleControls");
    var divInner = AddDiv(["carousel-inner"]);

    var imgTable = [];

    if (typeof album.images != 'undefined') {
        for (let i = 0; i < album.images.length; i++) {

            imgTable.push(album.images[i]);

            var div = AddDiv(["carousel-item"]);

            if (i == 0) div.classList.add("active");

            var img = AddImg(album.images[i].uri, i, album.images.length);
            div.appendChild(img);
            divInner.appendChild(div);
        }
    }

    divCarrousel.appendChild(divInner);

    var aPrev = addACarousell("prev", "Previous");

    divCarrousel.appendChild(aPrev);

    var aNext = addACarousell("next", "Next");
    divCarrousel.appendChild(aNext);

    container.appendChild(divCarrousel);


    aPrev.addEventListener("click", function () {

        var imgChange = document.querySelector("div.carousel-inner div.active img");
        imgChange.parentElement.classList.remove("active");
        var current = imgChange.getAttribute("actual") - 1;
        var max = imgChange.getAttribute("max");

        if (current < 0) current = max - 1;

        var newDivActive = imgChange.parentElement.parentElement.children;
        newDivActive.item(current).classList.add("active");
        console.log(newDivActive.item(current));

    });

    aNext.addEventListener("click", function () {

        var imgChange = document.querySelector("div.carousel-inner div.active img");
        imgChange.parentElement.classList.remove("active");
        var current = parseInt(imgChange.getAttribute("actual")) + 1;
        var max = imgChange.getAttribute("max");

        if (current > max - 1) current = 0;

        var newDivActive = imgChange.parentElement.parentElement.children;
        newDivActive.item(current).classList.add("active");

    });
}

function addACarousell(type, text) {

    var a = document.createElement("a");
    a.classList.add(`carousel-control-${type}`);
    a.setAttribute("role", "button");
    a.setAttribute("data-slide", type);


    var span1 = document.createElement("span");
    span1.classList.add(`carousel-control-${type}-icon`);
    span1.setAttribute("aria-hidden", "true");

    a.appendChild(span1);

    var span2 = document.createElement("span");
    span2.classList.add("sr-only");
    span2.innerText = text;

    a.appendChild(span2);

    return a;
}

function AddButton(text, classButton) {
    var b = document.createElement("a");
    b.classList.add("btn");
    b.classList.add(`btn-${classButton}`);
    b.style.color = "white";
    b.innerText = text;

    return b;
}