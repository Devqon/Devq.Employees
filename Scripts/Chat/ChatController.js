var ChatApp;
(function (ChatApp) {
    var Controllers;
    (function (Controllers) {
        var ChatController = (function () {
            function ChatController(chatFactory) {
                this.messages = [];
                this.rooms = [];
                this.$inject = ["chatFactory"];
                this.chatFactory = chatFactory;
                //this.chatFactory.on("addMessage", this.addMessage);
                //this.chatFactory.on("newConnection", this.addMessage);
                //this.chatFactory.on("removeConnection", this.addMessage);
                this.addMessage({ text: "Welcome" });
            }
            ChatController.prototype.addMessage = function (message) {
                this.messages.push(message);
            };
            ChatController.prototype.sendMessage = function () {
                this.chatFactory.send(this.newMessage);
            };
            return ChatController;
        })();
        Controllers.ChatController = ChatController;
    })(Controllers = ChatApp.Controllers || (ChatApp.Controllers = {}));
})(ChatApp || (ChatApp = {}));
//# sourceMappingURL=ChatController.js.map