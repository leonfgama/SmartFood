using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centerhum.SmartFood.Model
{
    public class ModelBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedDate
        {
            get
            {
                return DateTime.Now;
            }
            set
            {
                value = DateTime.Now;
            }
        }
    }

}
