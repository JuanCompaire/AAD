using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPages.Modelos
{
	public class Alumno
	{
        public  int Id { get; set; }

		[Required(ErrorMessage ="Obligatorio completar el nombre")]
		[MinLength(3,ErrorMessage ="El nombre tiene que tener un mínimo de 3 caracteres")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "Obligatorio completar el email")]
		[RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Email no valido")]
		[Display(Name = "Email de casa" +
			"")]
		public string Email { get; set;}
		public string Foto { get; set;}
        public Curso? CursoId { get; set; }
    }
}
