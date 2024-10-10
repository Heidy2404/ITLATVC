using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Productora
    {
        public int ProductoraId { get; set; }
        public string Nombre { get; set; }

        public ICollection<Series> SerieProducturaLista { get; set; } = null!;
    }
}
