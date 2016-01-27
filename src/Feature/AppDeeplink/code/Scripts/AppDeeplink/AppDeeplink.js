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
    OpenApp: function (deeplinkData) {

        document.location.href = deeplinkData.deviceUrl;
        console.log("Opening URL: " + deeplinkData.deviceUrl);

        Habitat.AppDeeplink.OpenStoreTimeOut(deeplinkData);

    },
    OpenStoreTimeOut: function (deeplinkData) {

        setTimeout(function () {
            Habitat.AppDeeplink.OpenStore(deeplinkData);
        }, 400);
    },
    OpenStore: function (deeplinkData) {

        console.log("Timeout. Open fallback url: " + deeplinkData.storeUrl);
        document.location.href = deeplinkData.storeUrl;

    },
    GetDeeplinkData: function (className) {

        var deeplinkData = {};
        deeplinkData.storeUrl = jQuery("." + className).data("storeurl");
        deeplinkData.deviceUrl = jQuery("." + className).data("deviceurl");

        return deeplinkData;

    },
    IsNullOrEmpty: function (value) {
        return value == null || value === "";
    }




}





