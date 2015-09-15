module ChatApp.Models {
    
    export interface Message {
        private: boolean;
        text: string;
        type: string;
        user?: User;
    }

    export class User {
        id: string;
        name: string;
    }

    export class Room {
        users: User[];
        name: string;
    }

}