var Habitat = Habitat || {};


jQuery(document).ready(function () {
    Habitat.AppDeeplink.DomReady();
});


Habitat.AppDeeplink = {
    DomReady: function () {
        Habitat.AppDeeplink.Init();
    },
    Init: function () {

        if (jQuery("body").hasClass("pagemode-edit"))
            return;

        var deeplinkData = Habitat.AppDeeplink.GetDeeplinkData("AppDeeplink");

        if (deeplinkData == null ||
            Habitat.AppDeeplink.IsNullOrEmpty(deeplinkData.storeUrl) ||
            Habitat.AppDeeplink.IsNullOrEmpty(deeplinkData.deviceUrl))
            return;

        Habitat.AppDeeplink.OpenApp(deeplinkData);

    },
    OpenApp: function (deepLinkData) {

        document.location.href = deepLinkData.deviceUrl;
        console.log("Opening URL: " + deepLinkData.deviceUrl);

        Habitat.AppDeeplink.OpenStoreTimeOut(deeplinkData);

    },
    OpenStoreTimeOut: function (deeplinkData) {

        setTimeout(function () {
            Habitat.AppDeeplink.OpenStore(deeplinkData);
        }, 400);
    },
    OpenStore: function (deepLinkData) {

        console.log("Timeout. Open fallback url: " + deepLinkData.storeUrl);
        document.location.href = deepLinkData.storeUrl;

    },
    GetDeeplinkData: function (className) {

        var deeplinkData = {};
        deeplinkData.storeUrl = jQuery("." + className).data("storeurl");
        deeplinkData.deviceUrl = jQuery("." + className).data("deviceurl");

        return deeplinkData;

    },
    IsNullOrEmpty: function(value) {
        return value == null || value === "";
    }




}





