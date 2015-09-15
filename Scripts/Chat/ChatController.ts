module ChatApp.Controllers {
    
    export class ChatController {
        
        private chatFactory: ChatApp.Services.IChatFactory;

        private messages: ChatApp.Models.Message[] = [];
        private rooms: ChatApp.Models.Room[] = [];

        private newMessage: string;

        $inject = ["chatFactory"];

        constructor(chatFactory: ChatApp.Services.IChatFactory) {
            this.chatFactory = chatFactory;

            //this.chatFactory.on("addMessage", this.addMessage);
            //this.chatFactory.on("newConnection", this.addMessage);
            //this.chatFactory.on("removeConnection", this.addMessage);
            this.addMessage(<Models.Message>{ text: "Welcome" });
        }

        public addMessage(message: ChatApp.Models.Message) {
            this.messages.push(message);
        }

        public sendMessage() {
            this.chatFactory.send(this.newMessage);
        }

    }

} 