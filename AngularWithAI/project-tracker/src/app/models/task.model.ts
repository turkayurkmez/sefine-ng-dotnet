export interface Task {
  id: number;
  title: string;
  description: string;
  isCompleted: boolean;
  projectId: number;
  createdDate: Date;
  completedDate?: Date;
}
