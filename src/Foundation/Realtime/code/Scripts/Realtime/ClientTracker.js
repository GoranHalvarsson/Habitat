var Habitat = Habitat || {};
var GPSTimeout = 10; //Move this

Habitat.ClientTracker = {

    Init: function (trackType) {


        //No tracking when in page editor
        if (!navigator || jQuery("body").hasClass("pagemode-edit"))
            return;

        if (trackType === Habitat.ClientTracker.TrackTypes.TrackPerRequest)
            navigator.geolocation.getCurrentPosition(Habitat.ClientTracker.GeoSuccess, Habitat.ClientTracker.GeoError);

        if (trackType === Habitat.ClientTracker.TrackTypes.TrackFrequent) {
            // see https://developer.mozilla.org/en-US/docs/Web/API/Geolocation.watchPosition
            var watchID = navigator.geolocation.watchPosition(Habitat.ClientTracker.GeoSuccess, Habitat.ClientTracker.GeoError, Habitat.ClientTracker.TrackFrequenzyOptions);
        }

    },
    TrackPerRequest: function (callback) {
        if (navigator.geolocation) {
            var clickedTime = (new Date()).getTime(); //get the current time
            GPSTimeout = 10; //reset the timeout just in case you call it more then once
            Habitat.ClientTracker.EnsurePosition(callback, clickedTime); //call recursive function to get position
        }
        return true;
    },
    EnsurePosition: function (callback, timestamp) {
        if (GPSTimeout < 6000)//set at what point you want to just give up
        {
            //call the geolocation function
            navigator.geolocation.getCurrentPosition(
                function (position) //on success
                {
                    //if the timestamp that is returned minus the time that was set when called is greater then 0 the position is up to date
                    if (position.timestamp - timestamp >= 0) {
                        GPSTimeout = 10; //reset timeout just in case
                        callback(position); //call the callback function you created
                    } else //the gps that was returned is not current and needs to be refreshed
                    {
                        GPSTimeout += GPSTimeout; //increase the timeout by itself n*2
                        Habitat.ClientTracker.EnsurePosition(callback, timestamp); //call itself to refresh
                    }
                },
                function () //error: gps failed so we will try again
                {
                    GPSTimeout += GPSTimeout; //increase the timeout by itself n*2
                    Habitat.ClientTracker.EnsurePosition(callback, timestamp); //call itself to try again
                },
                { maximumAge: 0, timeout: GPSTimeout }
            );
        }
    },
    GeoSuccess: function (geo) {

        Habitat.ClientTracker.TrackUserLocation(geo.coords);

    },
    GeoError: function (error) {
        var message = "";
        switch (error.code) {
            case error.PERMISSION_DENIED:
                message = "This website does not have permission to use " + "the Geolocation API";
                break;
            case error.POSITION_UNAVAILABLE:
                message = "The current position could not be determined.";
                break;
            case error.PERMISSION_DENIED_TIMEOUT:
                message = "The current position could not be determined " + "within the specified timeout period.";
                break;
        }

        if (message === "") {
            var strErrorCode = error.code.toString();
            message = "The position could not be determined due to " + "an unknown error (Code: " + strErrorCode + ").";
        }

        Habitat.ClientTracker.Logging(message);
    },
    TrackUserLocation: function (coords) {

        if (!coords)
            return;

        var locationUserObject = {};
        locationUserObject["Coordinates"] = Habitat.ClientTracker.StringFormat("{0},{1}", coords.latitude, coords.longitude, "1");

        var jsonObject = {};
        jsonObject["Container"] = locationUserObject;

        window.HabitatConnector.invoke("sendClientLocationData", jsonObject).done();

    },
    StringFormat: function () {
        var s = arguments[0];
        for (var i = 0; i < arguments.length - 1; i++) {
            var reg = new RegExp("\\{" + i + "\\}", "gm");
            s = s.replace(reg, arguments[i + 1]);
        }
        return s;
    },

    Logging: function (message) {
        if (typeof console == "object") {
            console.log(message);
        }
    },

    TrackTypes: {
        "NoTracking": 1,
        "TrackPerRequest": 2,
        "TrackFrequent": 3
    },

    TrackFrequenzyOptions: { //  see https://developer.mozilla.org/en-US/docs/Web/API/PositionOptions
        enableHighAccuracy: true,
        timeout: 30000, // Every 10 second 
        maximumAge: 0 //No caching
    }

};

