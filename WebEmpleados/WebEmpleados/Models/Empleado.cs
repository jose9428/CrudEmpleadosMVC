using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebEmpleados.Models
{
	public class Empleado
	{
		[Required(AllowEmptyStrings = true)]
		public int idEmp { get; set; }
		[Required]
		[Display(Name = "Nombres")]
		[MaxLength(30, ErrorMessage = "Longitud maxima de 30 caracteres")]
		public string nombres { get; set; }
		[Required]
		[Display(Name = "Apellidos")]
		[MaxLength(30, ErrorMessage = "Longitud maxima de 30 caracteres")]
		public string apellidos { get; set; }
		[Required]
		[Display(Name = "Correo")]
		[MaxLength(30, ErrorMessage = "Longitud maxima de 30 caracteres")]
		public string correo { get; set; }
		[Required]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Display(Name = "Fecha Nacimiento")]

		public DateTime fechaNac { get; set; }
		[Required]
		[Display(Name = "Sueldo")]
		public decimal sueldo { get; set; }

    }
}