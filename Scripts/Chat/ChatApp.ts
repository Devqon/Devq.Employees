module ChatApp {

    angular.module("chatApp", [
        "SignalR",
        "ngSanitize"
    ])
        .factory("chatFactory", Services.ChatFactory.factory)
        .controller("chatCtrl", Controllers.ChatController);

} 