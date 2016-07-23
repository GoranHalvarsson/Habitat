var Habitat = Habitat || {};


jQuery(document).ready(function () {
    Habitat.Realtime.DomReady();
});

Habitat.Realtime = {
    DomReady: function () {
        Habitat.Realtime.Init();
    },
    Init: function () {

        if (jQuery("body").hasClass("pagemode-edit"))
            return;

        var connection = jQuery.hubConnection();

        var realTimeConnector = connection.createHubProxy("RealtimeConnector");

        realTimeConnector.on("onSetClientData", function (text) {
           alert(text);
        });

        realTimeConnector.on("onWhoIs", function () {

            var jsonObject = Habitat.Realtime.GetUserMetaData();

            realTimeConnector.invoke("SendClientMetaData", jsonObject).done();
        });

        realTimeConnector.on("onWhereIs", function () {
            Habitat.ClientTracker.TrackPerRequest(function (position) {

                if (!position.coords)
                    return;

                var locationUserObject = {};
                locationUserObject["Coordinates"] = Habitat.ClientTracker.StringFormat("{0},{1}", position.coords.latitude, position.coords.longitude);

                var jsonObject = {};
                jsonObject["Container"] = locationUserObject;

                realTimeConnector.invoke("sendClientLocationData", jsonObject).done();

            });
        });

        connection.start().done();

    },
    GetUserMetaData: function () {

        var baseUserObject = {};
        baseUserObject["Language"] = document.documentElement.lang;
        baseUserObject["SiteName"] = window.location.host;
        baseUserObject["IpAddress"] = jQuery("body").data("currentipaddress");
        baseUserObject["PageUrl"] = window.location.pathname;

        var jsonObject = {};
        jsonObject["Container"] = baseUserObject;

        return jsonObject;
    }


}


