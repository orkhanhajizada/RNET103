(function ($) {

    'use strict';  // Start of use strict 

    let connection = new signalR
        .HubConnectionBuilder()
        .withUrl("/signalRServer")
        .build();

    connection.start();
 
    connection.on('refreshTags', function(){
        loadTags();
    }) 

    async function loadTags() {
        const response = await fetch('http://localhost:5248/api/tags');
        const data = await response.json();

        const templates = data.map(tag => `<a href="#">${tag.name}<span>0</span></a>`);
        $('.tagcloud').html(templates);
    }

    loadTags();
})(jQuery); // End of use strict