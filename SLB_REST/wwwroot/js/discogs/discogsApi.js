$(function () {

    var searchButton = document.getElementById("search-button");
    searchButton.addEventListener("click", function () {

        var input = document.getElementById("search-input");

        url = "/Home/Albums";
        var data = { queryUser: input.value };
        getAlbums(url, data, albumOnPage);
    });

    var inputSearch = document.getElementById("search-input");
    inputSearch.addEventListener("keypress", function () {
        const keyName = event.key;
        if (keyName == "Enter" && event.path[0].value !== "") {
            url = "/Home/Albums";
            var data = { queryUser: event.path[0].value };
            getAlbums(url, data, albumOnPage);
        }
    });

    var myAlbumsButton = document.getElementById("my-albums");
    myAlbumsButton.addEventListener("click", function () {
        GetMyAlbums({page: 0});
    });

    GetMyAlbums();

    var albumOnPage = null;
    var url = "/Home/Albums";
    var data = { queryUser: "" };
    getAlbums(url, data, albumOnPage);
 
});