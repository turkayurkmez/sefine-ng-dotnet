import { Project } from './project.model';

export interface Department {
  id: number;
  name: string;
  description: string;
  projects: Project[];
}
