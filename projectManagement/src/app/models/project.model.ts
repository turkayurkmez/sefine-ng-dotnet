import {Task} from './task.model';

export class Project{
    constructor(
        public id?:number,
        public name?:string,
        public description?: string,
        public startDate?: Date,
        public completedPercent?: number,
        public departmentId?:number,
        public tasks?: Task[]

    ){

    }
}