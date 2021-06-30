using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCAuthAndAuthoWithDotNetFramework.DbContext.Models
{
    [Table("Users")]
    public class UserDBModel 
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}