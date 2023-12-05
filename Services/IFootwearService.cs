using parcial2.Models;

namespace parcial2.Services;

public interface IFootwearService
{
    Task<List<Footwear>> GetAll(string filter);
    Task Update(Footwear Footwear);
    Task Delete(int id);
    Task Create(Footwear Footwear);
    Task<Footwear> GetById(int? id);
    Task<List<Store>> GetAllStores();
    Task<string> Purchase(Movement movement);
    Task<string> Sale(Movement movement);
}