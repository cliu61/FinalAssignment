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

    for (var i = 0; i < clinics.longitude; i++) {
        console.log(clinics[i]);
        // geocode and mark
        geodoceAddress(map, clinics[i]);
    }
}





function geodoceAddress(map, clinic) {
    var geocoder = new google.maps.Geocoder();
    var content = "<h3>" + clinic.Name + "</h3><hr/><p>" + clinic.Address + "</p><p>" + clinic.ContactNumber + "</p>";
    const infowindow = new google.maps.InfoWindow({
        content: content,
    });
    geocoder.geocode({ address: clinic.Address }, function (result, status) {
        if (status === "OK") {

            const image = {
                url: "https://developers.google.com/maps/documentation/javascript/examples/full/images/beachflag.png",
                // This marker is 20 pixels wide by 32 pixels high.
                size: new google.maps.Size(20, 32),
                // The origin for this image is (0, 0).
                origin: new google.maps.Point(0, 0),
                // The anchor for this image is the base of the flagpole at (0, 32).
                anchor: new google.maps.Point(0, 32),
            };

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