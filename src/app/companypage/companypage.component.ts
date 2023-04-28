import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-companypage',
  templateUrl: './companypage.component.html',
  styleUrls: ['./companypage.component.css']
})
export class CompanypageComponent {
  CompanyArray : any[] = [];
  isResultLoaded = false;
  isUpdateFormActive = false;

  ComapnyName: string ="";
  CompType: string ="";
  CompanyReview: string="";
  companyAvgSalary="";
  currentCompanyID = "";

  constructor(private http: HttpClient )
  {
  }
  ngOnInit(): void {
    this.getAllCompany();
  }
  getAllCompany()
  {
    this.http.get("https://localhost:7271/api/Company/GetCompany")
    .subscribe((resultData: any)=>
    {
        this.isResultLoaded = true;
        console.log(resultData);
        this.CompanyArray = resultData;
    });
  }
    register()
  {
    let bodyData = {
      "ComapnyName" : this.ComapnyName,
      "CompType" : this.CompType,
      "CompanyReview":this.CompanyReview,
      "companyAvgSalary":this.companyAvgSalary,
    
    };

  this.http.post("https://localhost:7271/api/Company/AddCompany",bodyData).subscribe((resultData: any)=>
    {
        console.log(resultData);
        alert("Company Added Successfully")
        this.getAllCompany();
    });
  }
  setUpdate(data: any)
  {
   this.ComapnyName = data.ComapnyName;
   this.CompType = data.CompType;
   this.CompanyReview=data.CompanyReview;
   this.companyAvgSalary=data.companyAvgSalary;
 
   this.currentCompanyID = data.id;
  }
  UpdateRecords()
  {
    let bodyData =
    {
      "ComapnyName" : this.ComapnyName,
      "CompType" : this.CompType,
      "CompanyReview":this.CompanyReview,
      "companyAvgSalary":this.companyAvgSalary,
    };
    
    this.http.patch("https://localhost:7271/api/Company/UpdateCompany"+ "/"+ this.currentCompanyID,bodyData).subscribe((resultData: any)=>
    {
        console.log(resultData);
        alert("Company details Updateddd")
        this.getAllCompany();
      
    });
  }
  save()
  {
    if(this.currentCompanyID == '')
    {
        this.register();
    }
      else
      {
       this.UpdateRecords();
      }      
 
  }
  setDelete(data: any)
  {
    this.http.delete("https://localhost:7271/api/Company/DeleteCompany"+ "/"+ data.id).subscribe((resultData: any)=>
    {
        console.log(resultData);
        alert("Company Deletedddd")
        this.getAllCompany();
    });
  }


}
