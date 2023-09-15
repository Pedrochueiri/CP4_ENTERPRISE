using Checkpoint_WebAPI.Models;

namespace CarrosFIAP_Oracle.Persistence.Repository
{
    public interface ICarrosRepository
    {
        Carros GetById(int id);
        IEnumerable<Carros> GetAll();
        void Add(Carros entity);
        void Update(Carros entity);
        void Delete(Carros entity);
    }
}
