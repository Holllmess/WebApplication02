using WebApplication02.Models;

namespace WebApplication02.Services
{
    public interface IPetRepository : IRepository<Pet, int>
    {
    }
}
