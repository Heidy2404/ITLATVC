using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class GuardarSerieViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "La portada es requerida")]
        public string Portada { get; set; } = null!;

        [Required(ErrorMessage = "El enlace del video es requerido")]
        public string Enlace { get; set; } = null!;

        [Required(ErrorMessage = "La productora es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La productora es requerida")]
        public int ProductoraId { get; set; }

        [MinLength(1, ErrorMessage = "El genero primario es requerido")]
        public List<int> Generos { get; set; } = new List<int>();

        public List<int> GenerosSecundario { get; set; } = new List<int>();
    }
}
