using System;
using System.ComponentModel.DataAnnotations;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [DisplayFormat(DataFormatString = "£ {0:0,0.00}")]
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }


        public SalesRecord()
        {
            Id = 0;
            Date = new DateTime(1999, 1, 1);
            Amount = 0.00;
            Status = 0;
            Seller = null;
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }

    }
}
