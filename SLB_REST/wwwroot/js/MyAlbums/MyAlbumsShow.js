function GetMyAlbums(paginationData, pag = 0) {

    $.ajax({
        url: "/Home/MyAlbums",
        data: paginationData
    }).done(function (myAlbumsJson) {

        var container = document.getElementById("container");
        container.innerHTML = "";

        var divRow = document.createElement("div");
        divRow.classList.add("row");
        divRow.setAttribute("id", "content");
        container.appendChild(divRow);

        ShowCards(myAlbumsJson.albums, container);


        AddPagination(myAlbumsJson.pages, pag)

    }).fail(function (error) {
        console.log("Błąd pobieranie albumu")
    });

}

function ShowCards(album) {

    var divCol = document.createElement("div");
    divCol.classList.add("col-sm-12");
    divCol.classList.add("col-md-11");
    divCol.classList.add("col-lg-11");

    var divRow = document.getElementById("content");

    var divRowAlbums = document.createElement("div");
    divRowAlbums.classList.add("row");

    for (let i = 0; i < album.length; i++) {

        var divCard = document.createElement("div");
        divCard.classList.add("card");
        divCard.classList.add("col-sm-6");
        divCard.classList.add("col-md-4");
        divCard.classList.add("text-center");
        divCard.classList.add("my-album-card");
        divCard.setAttribute("id", `album-${i}`);                    //model

        var linkMyAlbum = document.createElement("a");
        linkMyAlbum.classList.add("my-album");
        linkMyAlbum.setAttribute("href", `#album-${i}`);              //model

        linkMyAlbum.addEventListener("click", function () {

            $.ajax({
                url: "/Home/GetMyAlbum",
                data: { id: album[i].id }

            }).done(function (album) {

                console.log(album);
                ShowDiscogsAlbum("", album)
               
            }).fail(function (error) {
                console.log("Błąd pobieranie albumu")
            });
        });

        var imgMyAlbum = document.createElement("img");
        imgMyAlbum.classList.add("rounded-circle");
        imgMyAlbum.classList.add("center");
        imgMyAlbum.setAttribute("src", album[i].imageThumbSrc);                //model
        imgMyAlbum.setAttribute("alt", "image");
        imgMyAlbum.setAttribute("width", "140");
        imgMyAlbum.setAttribute("height", "140");

        var divBody = document.createElement("div");
        divBody.classList.add("card-body");
        divBody.classList.add("my-album");

        var titleH = document.createElement("h5");
        titleH.classList.add("card-title");
        titleH.innerText = album[i].title;                              //model

        var cardP = document.createElement("p");
        cardP.classList.add("card-text");

        var cardArtistP = document.createElement("p");
        cardArtistP.classList.add("text");
        cardArtistP.innerText = album[i].artistName;                          //model

        var cardStyleP = document.createElement("p");
        cardStyleP.classList.add("text");
        cardStyleP.innerText = album[i].style;                         //model

        var cardGenreP = document.createElement("p");
        cardGenreP.classList.add("text");
        cardGenreP.innerText = album[i].genres;                        //model

        cardP.appendChild(cardArtistP);
        cardP.appendChild(cardStyleP);
        cardP.appendChild(cardGenreP);

        divBody.appendChild(titleH);
        divBody.appendChild(cardP);

        linkMyAlbum.appendChild(imgMyAlbum);

        divCard.appendChild(linkMyAlbum);
        divCard.appendChild(divBody);

        divRowAlbums.appendChild(divCard);


    }
    divCol.appendChild(divRowAlbums);

    divRow.appendChild(divCol);

}

function AddPagination(pages, pag) {

    var divRow = document.getElementById("content");

    var divCol = document.createElement("div");
    divCol.classList.add("col-sm-12");
    divCol.classList.add("col-md-1");
    divCol.classList.add("col-lg-1");

    var nav = document.createElement("nav");

    var ul = document.createElement("ul");
    ul.classList.add("pagination");
    ul.classList.add("pagination-lg");
    ul.classList.add("flex-column");

    for (let i = 0; i < pages; i++) {

        var li = document.createElement("li");
        li.classList.add("page-item");
        li.setAttribute("old", pag)
        li.setAttribute("b", i)

        if (i == pag) li.classList.add("active");
        li.classList.add("paginatin-albums");

        li.addEventListener("click", function (event) {

            GetMyAlbums({page: i}, i)

            var pagButtons = document.querySelector("ul.pagination").children;

            var old = pagButtons[0].getAttribute("old");

            pagButtons[old].classList.remove("active");
            event.path[1].classList.add("active");

            pagButtons[0].setAttribute("old", event.path[1].getAttribute("b"));


        });

        var a = document.createElement("a");
        a.classList.add("page-link");
        a.classList.add("text-center");
        a.setAttribute("href", "#");
        a.innerText = i + 1;

        li.appendChild(a);
        ul.appendChild(li);
    }
    nav.appendChild(ul);
    divCol.appendChild(nav);

    divRow.appendChild(divCol);
}
