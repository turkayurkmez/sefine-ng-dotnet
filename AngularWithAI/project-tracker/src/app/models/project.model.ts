import { Task } from './task.model';

export interface Project {
  id: number;
  name: string;
  description: string;
  departmentId: number;
  tasks: Task[];
  startDate: Date;
  endDate?: Date;
}

export interface ProjectStats {
  totalTasks: number;
  completedTasks: number;
  remainingTasks: number;
  completionPercentage: number;
}
