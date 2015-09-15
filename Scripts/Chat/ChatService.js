/// <reference path="../typings/angular-signalr-hub/angular-signalr-hub.d.ts" />
var ChatApp;
(function (ChatApp) {
    var Services;
    (function (Services) {
        var ChatFactory = (function () {
            function ChatFactory($rootScope, Hub) {
                var _this = this;
                this.$inject = ["$rootScope", "Hub"];
                var options = {
                    listeners: {
                        'addMessage': function (message) {
                        },
                        'newConnection': function (name) {
                            return {
                                text: name + " joined",
                                type: "notification"
                            };
                        },
                        'removeConnection': function (name) {
                            return {
                                text: name + " left",
                                type: "notification"
                            };
                        }
                    },
                    methods: [
                        "send",
                        "join"
                    ],
                    errorHandler: function (error) {
                        console.error(error);
                    },
                    logging: true,
                    stateChanged: function (state) {
                        console.log(state);
                        switch (state.newState) {
                            case $.signalR.connectionState.connecting:
                                break;
                            case $.signalR.connectionState.connected:
                                //your code here
                                _this.join();
                                break;
                            case $.signalR.connectionState.reconnecting:
                                break;
                            case $.signalR.connectionState.disconnected:
                                break;
                        }
                    }
                };
                this.hub = new Hub("chat", options);
            }
            ChatFactory.factory = function ($rootScope, Hub) {
                return new ChatFactory($rootScope, Hub);
            };
            ChatFactory.prototype.on = function () {
                return this.hub.on;
            };
            ChatFactory.prototype.send = function (message) {
                this.hub.invoke("send", message);
            };
            ChatFactory.prototype.join = function () {
                this.hub.invoke("join");
            };
            return ChatFactory;
        })();
        Services.ChatFactory = ChatFactory;
    })(Services = ChatApp.Services || (ChatApp.Services = {}));
})(ChatApp || (ChatApp = {}));
//# sourceMappingURL=ChatService.js.map