import { Project } from "../project.model";
import { Task } from "../task.model";

export const projects: Project[] =[
    new Project(1, 'Project A', 'Project A açıklama', new Date(2025,10,4),0.15,1,[
        new Task(1,"Task A - Project A","Task a açıklama",new Date(2025,10,4),1,false),
        new Task(2,"Task B - Project A","Task b açıklama",new Date(2025,10,4),1,false),
        new Task(3,"Task C - Project A","Task x açıklama",new Date(2025,10,4),1,false)
    ]),

     new Project(2, 'Project B', 'Project B açıklama', new Date(2025,10,4),0.15,1,[
        new Task(4,"Task A1 - Project B","Task a açıklama",new Date(2025,10,4),1,false),
        new Task(5,"Task B1 - Project B","Task b açıklama",new Date(2025,10,4),1,false),
        new Task(6,"Task C1 - Project B","Task x açıklama",new Date(2025,10,4),1,false)


    ]),

     new Project(3, 'Project C', 'Project C açıklama', new Date(2025,10,4),0.15,1,[
        new Task(7,"Task A2 - Project C","Task a açıklama",new Date(2025,10,4),1,false),
        new Task(8,"Task B2 - Project C","Task b açıklama",new Date(2025,10,4),1,false),
        new Task(9,"Task C2- Project C","Task x açıklama",new Date(2025,10,4),1,false)


    ])


]