namespace GameZone.Services

{
    public interface IGemesServise
    {
        IEnumerable<Game> GetAll();
        Game? GetById(int id);
        Task Create(CreateGameFormViewModel game);
        Task<Game?> update(EditGameFormViewModel game);
        bool Delete(int id);
    }
}
