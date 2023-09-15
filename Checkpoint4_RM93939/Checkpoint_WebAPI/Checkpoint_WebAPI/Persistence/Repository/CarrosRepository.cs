
using Checkpoint_WebAPI.Models;
using Checkpoint_WebAPI.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarrosFIAP_Oracle.Persistence.Repository
{
    public class CarrosRepository
    {
        private readonly OracleDbContext _dbContext;

        public CarrosRepository(OracleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Carros GetById(int id)
        {
            return _dbContext.Carros.Find(id);
        }

        public IEnumerable<Carros> GetAll()
        {
            return _dbContext.Carros.ToList();
        }

        public void Add(Carros entity)
        {
            _dbContext.Carros.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Carros entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(Carros entity)
        {
            _dbContext.Carros.Remove(entity);
            _dbContext.SaveChanges();
        }

        internal void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
