using parcial2.Models;
using Microsoft.EntityFrameworkCore;

namespace parcial2.Services;

public class FootwearService : IFootwearService
{
    private readonly EnterpriseContext _context;
    public FootwearService(EnterpriseContext context)
    {
        _context = context;
    } 

    public async Task Create(Footwear Footwear)
    {
         _context.Add(Footwear);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var Footwear = await _context.Footwear.FindAsync(id);
        if (Footwear != null)
        {
            _context.Footwear.Remove(Footwear);
        }
        
        await _context.SaveChangesAsync();
    }

    public async Task<List<Footwear>> GetAll(string filter)
    {
        var query = from Footwear in _context.Footwear select Footwear;
        // el include nos trae los elementos de las relaciones
        //query = query.Include(x=> x.Store);

        // si viene filtro del buscador de la vista filtramos los datos 
        if(!string.IsNullOrEmpty(filter))
        {
            query = query
                .Where(x => x.Name.ToLower().Contains(filter.ToLower()) || 
                            x.Company.ToLower().Contains(filter.ToLower()));
        }

        return await query.ToListAsync();
    }

    public async Task<List<Store>> GetAllStores()
    {
        return await _context.Store.ToListAsync();
    }

    public async Task<Footwear?> GetById(int? id)
    {
        if (id == null || _context.Footwear == null)
        {
            return null;
        }

        return await _context.Footwear
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task Update(Footwear Footwear)
    {
        _context.Update(Footwear);
        await _context.SaveChangesAsync();
    }

    public async Task<string> Purchase(Movement movement)
    {
        return await CreateMovement(movement);
    }

    public async Task<string> Sale(Movement movement)
    {
        return await CreateMovement(movement);
    }

    private async Task<string> CreateMovement(Movement movement)
    {
        var stock = movement.Quantity;
        var Footwear = await _context.Footwear.FirstOrDefaultAsync(m => m.Id == movement.FootwearId);
        if (movement.TypeM == Utils.MovementType.sale)
        {
            stock*= -1;
            if ((Footwear.Stock + stock) < 0){
                return "No hay stock disponible para " + Footwear.Name;
            }
        }

        if (Footwear is null)
        {
            return "El calzado no existe";
        }  

        Footwear.Stock += stock;
        _context.Update(Footwear);
        _context.Add(movement);
        await _context.SaveChangesAsync();

        return string.Empty;
    }
}