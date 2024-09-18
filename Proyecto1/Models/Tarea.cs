
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Tarea 
    {
        [PrimaryKey] [AutoIncrement] 
        public int Id { get; set; }

        [NotNull]
        public string Descripcion { get; set; }

        [NotNull]
        public string Estado {  get; set; }
    }
}
