using System.ComponentModel.DataAnnotations;

namespace DrogueriaWeb1.Models
{
    public class EmpleadosModel
    { 
        [Required (ErrorMessage ="El ID del empleado es obligatorio")]
        public string? Id_empleado { get; set; }
        [Required(ErrorMessage = "El Nombre del empleado es obligatorio")]
        public string? Nombre { get; set; }
        public string? Telefono { get;set; }
        


    }
}
