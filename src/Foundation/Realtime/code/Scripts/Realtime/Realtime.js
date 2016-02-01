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

        var connection = $.hubConnection();

        //connection.hub.disconnected(function () {
        //    setTimeout(function () {
        //        $.connection.hub.start();
        //    }, 5000); // Restart connection after 5 seconds.
        //});

        var realTimeConnector = connection.createHubProxy("RealtimeConnector");

        realTimeConnector.on("onSetClientData", function (text) {
            $("#hitCount").text(text);
        });

        realTimeConnector.on("onWhoIs", function () {

            var jsonObject = Habitat.Realtime.GetUserMetaData();

            realTimeConnector.invoke("SendClientMetaData", jsonObject).done();
            //.done(function (result) {

            //    if (!result) {
            //        window.RealTimeConnector.invoke("SendClientBaseData", jsonObject).done();
            //    }

            //    window.RealTimeConnector.invoke("SendClientMetaData", jsonObject).done();


            //});
        });

        realTimeConnector.on("onWhereIs", function () {
            Habitat.ClientTracker.TrackPerRequest(function (position) {

                if (!position.coords)
                    return;

                var locationUserObject = {};
                locationUserObject["Coordinates"] = Habitat.ClientTracker.StringFormat("{0},{1}", position.coords.latitude, position.coords.longitude, "1");

                var jsonObject = {};
                jsonObject["Container"] = locationUserObject;

                realTimeConnector.invoke("sendClientLocationData", jsonObject).done();

            });
        });

        connection.start().done();

        //connection.start().done(function () {
        //    window.RealTimeConnector.invoke("subscribeToVisitors");
        //    window.RealTimeConnector.invoke("getClientDataFromVisitors");
        //});



        //How to continuously reconnect
        //In some applications you might want to automatically re-establish a connection after it has been lost and the 
        //attempt to reconnect has timed out. To do that, you can call the Start method from your Closed event handler 
        //(disconnected event handler on JavaScript clients). You might want to wait a period of time before calling Start in order to 
        //avoid doing this too frequently when the server or the physical connection are unavailable. The following code sample is for 
        //a JavaScript client using the generated proxy.



    },
    GetUserMetaData: function () {

        var baseUserObject = {};
        baseUserObject["Language"] = jQuery("body").data("currentlanguage");
        baseUserObject["SiteName"] = jQuery("body").data("currentsite");
        baseUserObject["IpAddress"] = jQuery("body").data("currentipaddress");
        baseUserObject["PageUrl"] = window.location.pathname;
        //baseUserObject["LastUpdate"] = new Date().toJSON().slice(0, 10);
        var jsonObject = {};
        jsonObject["Container"] = baseUserObject;

        return jsonObject;
    }


}


