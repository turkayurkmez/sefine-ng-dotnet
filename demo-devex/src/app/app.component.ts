import { Component } from '@angular/core';
import { Employee, EmployeesService} from './services/employee.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'demo-devex';

  tikla(){
    alert("Butona tıklandı!");
  }

  employee: Employee[] = [];

  constructor(private employeeService: EmployeesService) {

    this.employee = this.employeeService.getEmployees();
  }

  
}
