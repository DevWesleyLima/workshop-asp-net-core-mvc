using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Error: The field {0} is required!")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Error: The Name size in the Field {0} should be between {2} and {1} characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Error: The field {0} is required!")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Error: The field {0} is required!")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Error: The field {0} is required!")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "£ {0:0,0.00}")]
        [Range(100.00, 50000.00, ErrorMessage = "{0} must be from £ {1:0,0.00} to £ {2:0,0.00}")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId {get; set; }
        public ICollection<SalesRecord> Sales { get; set; }

        public Seller()
        {
            Id = 0;
            Name = String.Empty;
            Email = String.Empty;
            BirthDate = new DateTime(1999, 1, 1, 1, 0, 0);
            BaseSalary = 0.00;
            Department = null;
            DepartmentId = 0;
            Sales = new List<SalesRecord>();
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        public void Remove(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }

    }
}
