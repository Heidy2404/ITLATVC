
using System.ComponentModel.DataAnnotations;


namespace Application.ViewModels
{
    public class GuardarGenerosViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El genero es requerido")]
        public string Nombre { get; set; }
    }
}
