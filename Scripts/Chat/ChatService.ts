/// <reference path="../typings/angular-signalr-hub/angular-signalr-hub.d.ts" />

module ChatApp.Services {
    
    export interface IChatFactory {
        on: (listener: string, func) => any;
        send: (message: string) => void;
        join: () => void;
        hub: ngSignalr.Hub;
    }

    export class ChatFactory implements IChatFactory {
        
        public hub: ngSignalr.Hub;

        $inject = ["$rootScope", "Hub"];

        static factory($rootScope: angular.IRootScopeService, Hub: ngSignalr.HubFactory) {
            return new ChatFactory($rootScope, Hub);
        }

        constructor($rootScope: angular.IRootScopeService, Hub: ngSignalr.HubFactory) {

            var options: ngSignalr.HubOptions = {
                listeners: {
                    'addMessage': message => {

                    },

                    'newConnection': name => {
                        return <Models.Message> {
                            text: name + " joined",
                            type: "notification"
                        }
                    },
                    'removeConnection': name => {
                        return <Models.Message> {
                            text: name + " left",
                            type: "notification"
                        }
                    }
                },

                methods: [
                    "send",
                    "join"
                ],

                errorHandler: (error) => {
                    console.error(error);
                },

                logging: true,

                stateChanged: (state) => {
                    console.log(state);
                    switch (state.newState) {
                        case $.signalR.connectionState.connecting:
                            //your code here
                            break;
                        case $.signalR.connectionState.connected:
                            //your code here
                            this.join();
                            break;
                        case $.signalR.connectionState.reconnecting:
                            //your code here
                            break;
                        case $.signalR.connectionState.disconnected:
                            //your code here
                            break;
                    }
                }
            };
            this.hub = new Hub("chat", options);
        }

        public on() {
            return this.hub.on;
        }

        public send(message) {
            this.hub.invoke("send", message);
        }

        public join() {
            this.hub.invoke("join");
        }

    }
} 