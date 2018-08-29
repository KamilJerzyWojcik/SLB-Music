$(function () {

    var searchButton = document.getElementById("search-button");

    searchButton.addEventListener("click", function () {
        var input = document.getElementById("search-input");

        url = "/Home/Albums";
        var data = { queryUser: input.value };
        getAlbums(url, data, albumOnPage);
    });

    var myAlbumsButton = document.getElementById("my-albums");

    GetMyAlbums();

    myAlbumsButton.addEventListener("click", function () {
        GetMyAlbums({page: 0});
    });

    var albumOnPage = null;
    var url = "/Home/Albums";
    var data = { queryUser: "" };
    getAlbums(url, data, albumOnPage);
 
});