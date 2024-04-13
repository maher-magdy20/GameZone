
namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGemesServise _gemesServise;
        public GamesController(ICategoriesService categoriesService,IDevicesService devicesService,IGemesServise gemesServise)
        {
            _categoriesService = categoriesService;
            _devicesService = devicesService;
            _gemesServise = gemesServise;
        }
        public IActionResult Index()
        {
            var games = _gemesServise.GetAll();
            return View(games);
        }
        public IActionResult Details(int id)
        {
            var game = _gemesServise.GetById(id);
            if (game is null)
                return NotFound();
            return View(game);
        }

        [HttpGet]
        public IActionResult create()
        {
            CreateGameFormViewModel viewModel = new()
            {
                Categories = _categoriesService.GetSelectList(),
                Devices = _devicesService.GetSelectList(),
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> create(CreateGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetSelectList();
                model.Devices = _devicesService.GetSelectList();
                return View(model);
            }
            await _gemesServise.Create(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var game = _gemesServise.GetById(id);
            if (game is null)
                return NotFound();
            EditGameFormViewModel viewModel = new()
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                categoryId = game.categoryId,
                SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
                Categories = _categoriesService.GetSelectList(),
                Devices = _devicesService.GetSelectList(),
                CurrentCover=game.Cover
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetSelectList();
                model.Devices = _devicesService.GetSelectList();
                return View(model);
            }

            var game = await _gemesServise.update(model);
            if (game is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted =_gemesServise.Delete(id);
            return isDeleted ? Ok() : BadRequest();
        }
    }
}
