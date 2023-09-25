using Newtonsoft.Json;
using WeddingDay.Domain.Configurations;
using WeddingDay.Domain.Entities;

namespace WeddingDay.Data.Repositories
{
    public class Repository<TEntity> : IRepositoriy<TEntity> where TEntity : Auditable
    {
        private readonly string Path;
        public Repository() 
        {
            if (typeof(TEntity) == typeof(Booking))
                this.Path = DatabasesPath.BookingDb;
            else if(typeof(TEntity) == typeof(Client))
                this.Path = DatabasesPath.ClientDb;
            else if(typeof(TEntity) == typeof(Payment))
                this.Path = DatabasesPath.PaymentDb;
            else if(typeof(TEntity) == typeof(Wedding))
                this.Path = DatabasesPath.WeddingDb;

            var str = File.ReadAllText(Path);

            if (string.IsNullOrEmpty(str))
                File.WriteAllText(Path, "[]");
        }
        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> SelectAllAsync()
        {
            var str = await File.ReadAllTextAsync(Path);
            var entities = JsonConvert.DeserializeObject<List<TEntity>>(str);
            return entities;
        }

        public async Task<TEntity> SelectByIdAsync(long id)
        {
            var data = (await SelectAllAsync()).FirstOrDefault(e => e.);

        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
