using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class SeriesGeneros
    {
        public int SerieId { get; set; }
        public Series Series { get; set; } = null!;

        public int GeneroId { get; set; }

        public Generos Genero { get; set; } = null!;

        public bool primario { get; set; }
    }
}
