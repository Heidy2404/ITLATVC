using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SeriesViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }= null!;
        public string Portada { get; set; }= null!;
        public string Enlace { get; set; }= null!;
        public string NombreProductora { get; set; } = null!;
        public List<string> Genero { get; set; } = null!;
        public List<string> GeneroSecundario {  get; set; } = null!;

       

    }
}
