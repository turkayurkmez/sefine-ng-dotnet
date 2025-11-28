import { Component, OnInit, OnDestroy } from '@angular/core';
import { Project } from '../models/project.model';
import { ActivatedRoute } from '@angular/router';
import { ProjectService } from '../services/project.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css'],
})
export class ProjectListComponent implements OnInit, OnDestroy {
  private subscriptions: Subscription = new Subscription();

  constructor(
    private route: ActivatedRoute,
    private projectService: ProjectService
  ) {}

  ngOnInit(): void {
    // 1. Önce tüm projeleri yükle
    this.subscriptions.add(
      this.projectService.getProjects().subscribe((data) => {
        this.allProjects = data;
        
        // Veriler yüklendikten sonra routing durumunu kontrol et
        this.checkRouteAndApplyFilter();
      })
    );

    // 2. Route değişikliklerini dinle
    this.subscriptions.add(
      this.route.url.subscribe(() => {
        this.checkRouteAndApplyFilter();
      })
    );

    // 3. Route parametrelerini dinle
    this.subscriptions.add(
      this.route.params.subscribe(() => {
        this.checkRouteAndApplyFilter();
      })
    );
  }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  private checkRouteAndApplyFilter(): void {
    if (!this.allProjects || this.allProjects.length === 0) {
      return; // Veriler henüz yüklenmemişse bekle
    }

    // Mevcut URL segmentlerini al
    const segments = this.route.snapshot.url;
    const path = segments.map((s) => s.path).join('/');
    console.log('Current path:', path);

    // Mevcut route parametrelerini al
    const params = this.route.snapshot.params;
    const departmentId = params['departmentId'];

    if (path === 'tumProjeler' || path === '') {
      // tumProjeler veya ana sayfa ise tüm projeleri göster
      this.filteredProjects = [...this.allProjects];
      console.log('Tüm projeler gösteriliyor, filtre uygulanmadı.');
    } else if (departmentId) {
      // Departman ID varsa filtrele
      this.filteredProjects = this.allProjects.filter(
        (project) => project.departmentId === +departmentId
      );
      console.log(`Departman ID ${departmentId} için filtre uygulandı. Bulunan proje sayısı: ${this.filteredProjects.length}`);
    } else {
      // Diğer durumlarda tüm projeleri göster
      this.filteredProjects = [...this.allProjects];
      console.log('Parametre bulunamadı, tüm projeler gösteriliyor.');
    }
  }
  allProjects: Project[] = [];

  filteredProjects: Project[] = this.allProjects;

  key: string = '';
}
