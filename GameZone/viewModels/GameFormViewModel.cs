namespace GameZone.viewModels
{
    public class GameFormViewModel
    {
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "category")]
        public int categoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "Supported Devices")]
        public List<int> SelectedDevices { get; set; } = default!;
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
    }
}
