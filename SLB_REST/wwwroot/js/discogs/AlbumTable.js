function getAlbums(url, data, albumOnPage) {

    var JsonExist = false;

    if (albumOnPage != null) {
        for (let i = 0; i < albumOnPage.length; i++) {

            if (typeof albumOnPage[i] != 'undefined') {
                var num;
                for (let j = 0; j < 10; j++) {
                    if (data.link[data.link.length - 1 - j] == "=") {
                        num = data.link.substring(data.link.length - j, data.link.length)
                        break;
                    }
                }

                if (num == albumOnPage[i].pagination.page) {

                    var albumsJson = albumOnPage[i];
                    var container = document.getElementById("container");
                    container.innerHTML = "";
                    getPagination(albumsJson.pagination, albumOnPage);
                    getTable(albumsJson, albumOnPage);
                    JsonExist = true;
                }


            }
        }
    }

    if (!JsonExist) {
        $.ajax({
            url: url,
            data: data

        }).done(function (albums) {


            if (albums != "" && albums != null) {

                var albumsJson = JSON.parse(albums);
                if (albumOnPage == null) albumOnPage = Array(albumsJson.pagination.pages);

                if (typeof albumOnPage[albumsJson.pagination.page - 1] == "undefined")
                    albumOnPage[albumsJson.pagination.page - 1] = albumsJson;

                var container = document.getElementById("container");
                container.innerHTML = "";
                getPagination(albumsJson.pagination, albumOnPage);
                getTable(albumsJson, albumOnPage);

            }

            

        }).fail(function (error) {
            console.log("Błąd pobieranie tabeli")
        });
    }
}

function AddPaginationButton(text, pagUrl, albumOnPage) {

    if (pagUrl !== "" && pagUrl != null) {
        var li = document.createElement("li");
        li.classList.add("page-item");
        li.classList.add("center");
        var a = document.createElement("a");
        a.classList.add("page-link");
        a.setAttribute("href", "#");
        a.innerText = text;

        a.addEventListener("click", function () {

            var url = "/Home/Links";
            var data = { link: pagUrl };
            getAlbums(url, data, albumOnPage);

        });
        li.appendChild(a);

        return li;
    }

    return null;
}

function getPagination(pagination, albumOnPage) {

    var liFirst = AddPaginationButton("First", pagination.urls.first, albumOnPage);
    var liNext = AddPaginationButton("Next", pagination.urls.next, albumOnPage);
    var liPrev = AddPaginationButton("Prev", pagination.urls.prev, albumOnPage);
    var liLast = AddPaginationButton("Last", pagination.urls.last, albumOnPage);

    var ul = document.createElement("ul");
    ul.classList.add("pagination");

    if (liFirst != null) ul.appendChild(liFirst);
    if (liPrev != null) ul.appendChild(liPrev);
    if (liNext != null) ul.appendChild(liNext);
    if (liLast != null) ul.appendChild(liLast);


    var nav = document.createElement("nav");
    nav.innerText = "Page: " + pagination.page + " from " + pagination.pages;
    nav.appendChild(ul);

    var main = document.getElementById("container");
    main.appendChild(nav);
}

function AddButton(text, classButton) {
    var b = document.createElement("a");
    b.classList.add("btn");
    b.classList.add(`btn-${classButton}`);
    b.setAttribute("href", "#");
    b.innerText = text;

    return b;
}

function elementTable(type, classBootstrap = "", scopeAttr = "") {
    var elem = document.createElement(type);
    if (classBootstrap != "") {
        elem.classList.add(classBootstrap);
    }

    if (scopeAttr != "") {
        elem.setAttribute("scope", scopeAttr);
    }
    elem.setAttribute("id", `content-${type}`);

    return elem;
}

function AddHead(tr, headTable) {

    for (let i = 0; i < headTable.length; i++) {
        var th = elementTable("th", "", "col");
        th.classList.add("th-content")
        th.innerText = headTable[i];
        tr.appendChild(th);
    }

    return tr;
}

function GetTableWithHead(headTable) {
    var table = elementTable("table", "table");
    table.classList.add("table-content-all")
    var thead = elementTable("thead", "thead-dark");
    var tr = elementTable("tr");

    tr = AddHead(tr, headTable);
    thead.appendChild(tr);
    table.appendChild(thead);

    return table;
}

function AddRowToTable(typeTable, valueTable, resource_url, albumOnPage) {
    var tr = elementTable("tr");

    for (let i = 0; i < typeTable.length; i++) {

        var td = document.createElement("td");
        td.classList.add("td-content")
        if (typeTable[i] == "img") {

            var img = document.createElement("img");
            img.setAttribute("src", valueTable[i]);
            img.setAttribute("alt", "image");
            img.classList.add("thumb");
            img.classList.add("img-content");
            td.appendChild(img);
            tr.appendChild(td);
            continue;
        }

        if (typeTable[i] == "a") {
            var a = AddButton(valueTable[i], "success")

            a.addEventListener("click", function () {
                ShowDiscogsAlbum(resource_url, albumOnPage);
            });

            td.appendChild(a);
            tr.appendChild(td);
            continue;
        }

        if (typeTable[i] == "txt") {

            td.innerText = valueTable[i];
            tr.appendChild(td);
            continue;
        }

    }

    return tr;
}

function getTable(albums, albumOnPage) {

    var headTable = ["thumb", "resource_url", "title", "country", "genre", "year", "style", "type"];
    var table = GetTableWithHead(headTable);
    var tbody = elementTable("tbody");
    var typeTable = ["img", "a", "txt", "txt", "txt", "txt", "txt", "txt"]

    for (let i = 0; i < albums.results.length; i++) {

        var valueTable = [
            albums.results[i].thumb,
            "Show album",
            albums.results[i].title,
            albums.results[i].country,
            albums.results[i].genre,
            albums.results[i].year,
            albums.results[i].style,
            albums.results[i].type
        ]
        var tr = AddRowToTable(typeTable, valueTable, albums.results[i].resource_url, albumOnPage);

        tbody.appendChild(tr);
    }
    table.appendChild(tbody);

    var container = document.getElementById("container");

    container.appendChild(table);
}

function GetNext(pagination) {

    var NextButton = document.querySelector("a.next");

    NextButton.addEventListener("click", function () {

        var url = "/Home/Links";
        var data = { link: pagination.urls.next };
        var tbody = document.getElementById("info");

        var children = tbody.children;
        var child = tbody.firstChild;
        while (child) {
            tbody.removeChild(child);
            child = tbody.firstChild;
        }

        getAlbums(url, data);
    });
}
