using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Generos
    {
        public int GeneroId { get; set; }
        public string Nombre { get; set; }



        public ICollection<SeriesGeneros> SeriesGenerosLista { get; set; } = null!;
    }
}
