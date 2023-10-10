using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
        public string mensaje { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
			mensaje = "Hola, lo primero de todo, como estan los máquinas, son las " + DateTime.Now.ToLongTimeString();
		}
	}
}