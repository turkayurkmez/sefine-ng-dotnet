import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Project, ProjectStats } from '../../models/project.model';
import { Task } from '../../models/task.model';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
  project: Project | undefined;
  tasks: Task[] = [];
  projectStats: ProjectStats | undefined;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dataService: DataService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const projectId = +params['projectId'];
      this.loadProject(projectId);
    });
  }

  private loadProject(projectId: number): void {
    this.project = this.dataService.getProjectById(projectId);
    if (this.project) {
      this.tasks = this.project.tasks;
      this.projectStats = this.dataService.getProjectStats(projectId);
    }
  }

  toggleTask(taskId: number): void {
    this.dataService.toggleTaskCompletion(taskId);
    if (this.project) {
      this.loadProject(this.project.id);
    }
  }

  goBack(): void {
    if (this.project) {
      const dept = this.dataService.getDepartments();
      dept.subscribe(departments => {
        const department = departments.find(d => 
          d.projects.some(p => p.id === this.project!.id)
        );
        if (department) {
          this.router.navigate(['/departments', department.id, 'projects']);
        }
      });
    }
  }

  getTaskStatusClass(task: Task): string {
    return task.isCompleted ? 'completed' : 'pending';
  }
}
