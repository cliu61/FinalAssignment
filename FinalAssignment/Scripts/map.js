let clinics;

let xmlHttp = new XMLHttpRequest();
xmlHttp.open("GET", "Clinics/GetClinics", false);
xmlHttp.send(null);
stores = JSON.parse(xmlHttp.responseText);
console.log(clinics);


let map;

function initMap() {
    map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: -34.397, lng: 150.644 },
        zoom: 11,
    });

    //get current location
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(
            position => {
                const pos = {
                    lat: position.coords.latitude,
                    lng: position.coords.longitude
                };
                map.setCenter(pos);
            },
            () => {
                handleLocationError(false, infoWindow, map.getCenter());
            }
        );
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, infoWindow, map.getCenter());
    }

    // mark clinics
    for (var i = 0; i < clinics.length; i++) {
        console.log(clinics[i]);
        // geocode and mark
        geodoceAddress(map, clinics[i]);
    }
}





function geodoceAddress(map, clinic) {
    var geocoder = new google.maps.Geocoder();
    var content = "<h3>" + clinic.Name + "</h3>";
    const infowindow = new google.maps.InfoWindow({
        content: content,
    });
    geocoder.geocode({ address: clinic.Address }, function (result, status) {
        if (status === "OK") {
            var marker = new google.maps.Marker({
                map: map,
                icon: image,
                animation: google.maps.Animation.DROP,
                position: result[0].geometry.location
            });
        }
        marker.addListener("click", function () { infowindow.open(map, marker) });
    });
}

function handleLocationError(browserHasGeolocation,infoWindow,pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(
        browserHasGeolocation
            ? "Error: The Geolocation service failed."
            : "Error: Your browser doesn't support geolocation."
    );
    infoWindow.open(map);
}