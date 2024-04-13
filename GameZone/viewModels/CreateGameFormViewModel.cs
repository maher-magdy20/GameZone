using GameZone.Attributes;

namespace GameZone.viewModels
{
    public class CreateGameFormViewModel :GameFormViewModel
    {

        [AllowedExtensions(FileSettings.AllowedExtensions),MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;

    }
}
