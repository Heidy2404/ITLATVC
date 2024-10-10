using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Series
    {
        public int SerieId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Portada { get; set; } = null!;
        public string Enlaces { get; set; } = null!;

        public int ProductoraId { get; set; }
        public Productora Productora { get; set; }



        public ICollection<SeriesGeneros> SeriesGeneroLista { get; set; } = null!;
    }
}
