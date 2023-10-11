using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Alumnos


{
    public class IndexModel : PageModel

        
    {
		public string mensaje { get; set; }

        public void OnGet()
        {
			mensaje = "Hola a todos los alumnos";
 
		}
	}
}
