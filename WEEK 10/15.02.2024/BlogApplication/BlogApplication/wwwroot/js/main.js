(function ($) {

    'use strict';  // Start of use strict 

    let connection = new signalR
        .HubConnectionBuilder()
        .withUrl("/signalRServer")
        .build();
    connection.start();

    function loadTags() {
        let template = [];

        fetch('http://localhost:5248/api/tags')
            .then(response => response.json())
            .then(data => {
                data.forEach(tag => {
                    template.push(`<a href="#">${tag.name}<span>(${tag.count})</span></a>`);
                });
            })
            .catch(error => console.error('Unable to load tags', error));

        console.log(template);
        $('.tagCloud').html(template.join(''));
        
        
        console.log(document.getElementsByClassName('tagCloud'))
    }


    loadTags();
})