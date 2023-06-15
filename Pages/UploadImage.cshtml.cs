using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HamzilahFoods.Pages
{
    public class UploadImageModel : PageModel
    {
        private readonly ILogger<UploadImageModel> _logger;
        private readonly IHostEnvironment _environment;

        [BindProperty]

        public IFormFile UploadedFile { get; set; }

        public UploadImageModel(ILogger<UploadImageModel> logger, IHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }
        public void OnGet()
        {
        }
        public async Task OnPostAsync()
        {
            if (UploadedFile == null || UploadedFile.Length == 0)
            {
                return;
            }
            _logger.LogInformation($"Uploading {UploadedFile.FileName}.");
            var id = Request.Query["id"];
            string extension = Path.GetExtension(UploadedFile.FileName);
            string newfilename = id + extension;
            string targetFileName = $"{_environment.ContentRootPath}/wwwroot/img/{newfilename}";

            using (var stream = new FileStream(targetFileName, FileMode.Create))
            {
                await UploadedFile.CopyToAsync(stream);
            }
        }
    }
}
