using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;


namespace SimpleCoreApp.Controllers
{
	public class SSLController : Controller
	{
		public SSLController(IHostingEnvironment env)
		{
			_env = env;
		}
		private readonly IHostingEnvironment _env;

		//.well-known/acme-challenge
		[HttpGet]
		[Route(".well-known/acme-challenge/{fileName}")]
		public IActionResult Index(string fileName)
		{
			string data = GetFileString(fileName);
			if (!string.IsNullOrEmpty(data))
			{
				return Ok(data);
			}
			return NotFound();
		}


		private string GetFileString(string fileName)
		{
			string file = null;

			string path = System.IO.Path.Combine(_env.WebRootPath, "acme-challenge", fileName);
			if (System.IO.File.Exists(path))
			{
				file = System.IO.File.ReadAllText(path);
			}
			return file;
		}
	}
}