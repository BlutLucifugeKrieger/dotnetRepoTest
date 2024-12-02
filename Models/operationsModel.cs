

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace azure_test.Models
{
    [Table("OPERATIONS")]
    public class operationsModel
    {
        [Key]
        public int? ID { get; set; }
        public decimal FIRSTNUMBER { get; set; }
        public decimal SECONDNUMBER { get; set; }

        public string OPERATION { get; set; }

        public decimal? RESULT { get; set; }

    }
}
