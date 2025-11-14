import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Department } from '../models/department.model';
import { Project, ProjectStats } from '../models/project.model';
import { Task } from '../models/task.model';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private departments: Department[] = [];
  private departmentsSubject = new BehaviorSubject<Department[]>([]);
  public departments$ = this.departmentsSubject.asObservable();

  constructor() {
    this.initializeMockData();
  }

  private initializeMockData(): void {
    this.departments = [
      {
        id: 1,
        name: 'Yazılım Geliştirme',
        description: 'Yazılım projeleri departmanı',
        projects: [
          {
            id: 101,
            name: 'E-Ticaret Platformu',
            description: 'Online satış platformu geliştirme',
            departmentId: 1,
            startDate: new Date('2025-01-01'),
            tasks: [
              { id: 1001, title: 'Veritabanı tasarımı', description: 'PostgreSQL veritabanı şeması', isCompleted: true, projectId: 101, createdDate: new Date('2025-01-01'), completedDate: new Date('2025-01-15') },
              { id: 1002, title: 'API geliştirme', description: 'RESTful API endpoint\'leri', isCompleted: true, projectId: 101, createdDate: new Date('2025-01-15'), completedDate: new Date('2025-02-01') },
              { id: 1003, title: 'Frontend geliştirme', description: 'Angular ile kullanıcı arayüzü', isCompleted: false, projectId: 101, createdDate: new Date('2025-02-01') },
              { id: 1004, title: 'Test ve deployment', description: 'Unit ve integration testleri', isCompleted: false, projectId: 101, createdDate: new Date('2025-02-15') }
            ]
          },
          {
            id: 102,
            name: 'Mobil Uygulama',
            description: 'iOS ve Android mobil uygulama',
            departmentId: 1,
            startDate: new Date('2025-02-01'),
            tasks: [
              { id: 1005, title: 'UI/UX tasarım', description: 'Kullanıcı deneyimi tasarımı', isCompleted: true, projectId: 102, createdDate: new Date('2025-02-01'), completedDate: new Date('2025-02-20') },
              { id: 1006, title: 'React Native kurulum', description: 'Proje altyapısı', isCompleted: false, projectId: 102, createdDate: new Date('2025-02-20') },
              { id: 1007, title: 'API entegrasyonu', description: 'Backend bağlantısı', isCompleted: false, projectId: 102, createdDate: new Date('2025-03-01') }
            ]
          }
        ]
      },
      {
        id: 2,
        name: 'Pazarlama',
        description: 'Pazarlama ve reklam projeleri',
        projects: [
          {
            id: 201,
            name: 'Sosyal Medya Kampanyası',
            description: 'Q1 sosyal medya stratejisi',
            departmentId: 2,
            startDate: new Date('2025-01-10'),
            tasks: [
              { id: 2001, title: 'İçerik planlaması', description: 'Aylık içerik takvimi', isCompleted: true, projectId: 201, createdDate: new Date('2025-01-10'), completedDate: new Date('2025-01-20') },
              { id: 2002, title: 'Görsel tasarım', description: 'Post görselleri hazırlama', isCompleted: true, projectId: 201, createdDate: new Date('2025-01-20'), completedDate: new Date('2025-02-01') },
              { id: 2003, title: 'Kampanya yayını', description: 'Planlı yayınlar', isCompleted: false, projectId: 201, createdDate: new Date('2025-02-01') },
              { id: 2004, title: 'Analiz ve raporlama', description: 'Performans metrikleri', isCompleted: false, projectId: 201, createdDate: new Date('2025-02-15') },
              { id: 2005, title: 'Optimizasyon', description: 'Sonuçlara göre iyileştirme', isCompleted: false, projectId: 201, createdDate: new Date('2025-03-01') }
            ]
          }
        ]
      },
      {
        id: 3,
        name: 'İnsan Kaynakları',
        description: 'İK projeleri ve süreçleri',
        projects: [
          {
            id: 301,
            name: 'Yetenek Yönetim Sistemi',
            description: 'HR management portal',
            departmentId: 3,
            startDate: new Date('2025-01-05'),
            tasks: [
              { id: 3001, title: 'İhtiyaç analizi', description: 'Kullanıcı gereksinimleri', isCompleted: true, projectId: 301, createdDate: new Date('2025-01-05'), completedDate: new Date('2025-01-25') },
              { id: 3002, title: 'Sistem seçimi', description: 'Vendor değerlendirme', isCompleted: false, projectId: 301, createdDate: new Date('2025-01-25') },
              { id: 3003, title: 'Implementasyon', description: 'Sistem kurulumu', isCompleted: false, projectId: 301, createdDate: new Date('2025-02-10') }
            ]
          }
        ]
      }
    ];

    this.departmentsSubject.next(this.departments);
  }

  getDepartments(): Observable<Department[]> {
    return this.departments$;
  }

  getDepartmentById(id: number): Department | undefined {
    return this.departments.find(d => d.id === id);
  }

  getProjectById(projectId: number): Project | undefined {
    for (const dept of this.departments) {
      const project = dept.projects.find(p => p.id === projectId);
      if (project) return project;
    }
    return undefined;
  }

  getProjectStats(projectId: number): ProjectStats | undefined {
    const project = this.getProjectById(projectId);
    if (!project) return undefined;

    const totalTasks = project.tasks.length;
    const completedTasks = project.tasks.filter(t => t.isCompleted).length;
    const remainingTasks = totalTasks - completedTasks;
    const completionPercentage = totalTasks > 0 ? Math.round((completedTasks / totalTasks) * 100) : 0;

    return {
      totalTasks,
      completedTasks,
      remainingTasks,
      completionPercentage
    };
  }

  toggleTaskCompletion(taskId: number): void {
    for (const dept of this.departments) {
      for (const project of dept.projects) {
        const task = project.tasks.find(t => t.id === taskId);
        if (task) {
          task.isCompleted = !task.isCompleted;
          task.completedDate = task.isCompleted ? new Date() : undefined;
          this.departmentsSubject.next([...this.departments]);
          return;
        }
      }
    }
  }

  addTask(projectId: number, task: Omit<Task, 'id'>): void {
    const project = this.getProjectById(projectId);
    if (project) {
      const newTask: Task = {
        ...task,
        id: Date.now()
      };
      project.tasks.push(newTask);
      this.departmentsSubject.next([...this.departments]);
    }
  }

  deleteTask(taskId: number): void {
    for (const dept of this.departments) {
      for (const project of dept.projects) {
        const taskIndex = project.tasks.findIndex(t => t.id === taskId);
        if (taskIndex !== -1) {
          project.tasks.splice(taskIndex, 1);
          this.departmentsSubject.next([...this.departments]);
          return;
        }
      }
    }
  }
}
