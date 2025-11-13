//   {
//     "userId": 1,
//     "id": 13,
//     "title": "et doloremque nulla",
//     "completed": false
//   },
export class TodoItem {
    constructor(
        public userId: number,
        public id: number,
        public title?: string,
        public completed?: boolean
    ) {}

}