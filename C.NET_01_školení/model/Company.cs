using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Company
    {
        [Key]
        public int ComId { get; set; }

        public string Name { get; set; }

        //public  Address Address { get; set; }

        //public Contract Contract { get; set; }

        //[ForeignKey("ContractId")]
        //public int ContractId { get; set; }


    }
}
