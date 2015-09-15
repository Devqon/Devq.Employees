var ChatApp;
(function (ChatApp) {
    angular.module("chatApp", [
        "SignalR",
        "ngSanitize"
    ]).factory("chatFactory", ChatApp.Services.ChatFactory.factory).controller("chatCtrl", ChatApp.Controllers.ChatController);
})(ChatApp || (ChatApp = {}));
//# sourceMappingURL=ChatApp.js.map