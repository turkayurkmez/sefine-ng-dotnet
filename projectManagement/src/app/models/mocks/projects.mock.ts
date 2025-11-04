import { Project } from "../project.model";
import { Task } from "../task.model";

export const projects: Project[] =[
    new Project(1, 'Project A', 'Project A açıklama', new Date(2025,10,4),0.15,1,[
        new Task(1,"Task A - Project A","Task a açıklama",new Date(2025,10,4),1,false),
        new Task(2,"Task B - Project A","Task b açıklama",new Date(2025,10,4),1,false),
        new Task(3,"Task C - Project A","Task x açıklama",new Date(2025,10,4),1,false)
    ]),

     new Project(2, 'Project B', 'Project B açıklama', new Date(2025,10,4),0.15,1,[
        new Task(4,"Task A - Project B","Task a açıklama",new Date(2025,10,4),1,false),
        new Task(5,"Task B - Project B","Task b açıklama",new Date(2025,10,4),1,false),
        new Task(6,"Task C - Project B","Task x açıklama",new Date(2025,10,4),1,false)


    ]),

     new Project(1, 'Project C', 'Project C açıklama', new Date(2025,10,4),0.15,1,[
        new Task(7,"Task A - Project C","Task a açıklama",new Date(2025,10,4),1,false),
        new Task(8,"Task B - Project C","Task b açıklama",new Date(2025,10,4),1,false),
        new Task(9,"Task C - Project C","Task x açıklama",new Date(2025,10,4),1,false)


    ])


]