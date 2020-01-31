import {  Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent   {

  public students: Student[];
  baseUrl: String = 'http://localhost:49491/api/Student/';
  dtOptions: DataTables.Settings = {};
showForm = false;
student: Student = null;
  constructor(http: HttpClient) {

  http.get<Student[]>(this.baseUrl + 'getall').subscribe(result => {
      this.students = result;
      this.dtOptions = {
        pagingType: 'full_numbers',
        pageLength: 10,
        processing: true,
        columns: [{
          title: 'id',
          data: 'id'
        }, {
          title: 'Student name',
          data: 'studentName'
        }, {
          title: 'Date of Birth',
          data: 'dateOfBirth'
        },
        {
          title: 'Grade',
          data: 'grade'
        }, {
          title: 'Address',
          data: 'address'
        }],
        rowCallback: (row: Node, data: any[] | Object, index: number) => {
          const self = this;
          $('td', row).unbind('click');
          $('td', row).bind('click', () => {
            self.rowClickHandler(data);
          });
          return row;
        }

      };


    }, error => console.error(error));
  }

  rowClickHandler(student: any): void {

   this.student =  this.students.find(x => x.id == student.id);
   console.log( this.student);
    this.showForm = true;
  }

  CloseForm(): void {
    this.showForm = false;
  }

   humanFileSize(bytes, si) : string {
    var thresh = si ? 1000 : 1024;
    if(Math.abs(bytes) < thresh) {
        return bytes + ' B';
    }
    var units = si
        ? ['kB','MB','GB','TB','PB','EB','ZB','YB']
        : ['KiB','MiB','GiB','TiB','PiB','EiB','ZiB','YiB'];
    var u = -1;
    do {
        bytes /= thresh;
        ++u;
    } while(Math.abs(bytes) >= thresh && u < units.length - 1);
    return bytes.toFixed(1)+' '+units[u];
}
}

interface Student {

  id: number;
  studentName: string;
  grade: number;
  dateOfBirth: Date;
  address: string;
  files: Files[];
}
interface Files {
  id: number;
  fileName: string;
  fileSize: number;
  studentId: number;
}
