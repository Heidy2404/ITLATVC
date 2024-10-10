using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class GuardarProductoraViewModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage="Nombre de la productora es requerido")]
        public string Nombre { get; set; }
    }
}
