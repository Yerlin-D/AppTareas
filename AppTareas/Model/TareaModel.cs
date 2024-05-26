using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTareas.Model
{
   public class TareaModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String NombreTarea { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
    }

}
