using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Models
{
    public enum Categories { Sport, Elektronika, Dom, Transport, Jedzenie };
    public class ExpenseModel
    {
        public int ExpenseId { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Kwota [PLN]")]

        /*DataType(DataType.Currency)]*/

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }
        [DisplayName("Data")]
        public DateTime? Date { get; set; }
        [DisplayName("Kategoria")]
        public int Category { get; set; }


    }
}
