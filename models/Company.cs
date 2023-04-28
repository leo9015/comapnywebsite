using System.ComponentModel.DataAnnotations;

namespace Taskcomapny.models
{
    public class Company
    {
        [Key]
        public int Id { get; set; } 
        public string ComapnyName { get; set; }
        public string CompType { get; set; }

        public string CompanyReview { get; set; }
        public int companyAvgSalary { get; set; }
    }
}
