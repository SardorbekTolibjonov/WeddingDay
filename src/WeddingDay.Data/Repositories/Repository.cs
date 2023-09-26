using Newtonsoft.Json;
using WeddingDay.Domain.Commons;
using WeddingDay.Domain.Entities;
using WeddingDay.Data.IRepositories;
using WeddingDay.Domain.Configurations;

namespace WeddingDay.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
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

        public async Task<bool> DeleteAsync(long id)
        {
            var entities = await SelectAllAsync();
            var data = await SelectByIdAsync(id);
            entities.Remove(data);
            var result = JsonConvert.SerializeObject(entities, Newtonsoft.Json.Formatting.Indented);
            await File.WriteAllTextAsync(Path, result);

            return true;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var entities = await SelectAllAsync();
            entities.Add(entity);
            var result = JsonConvert.SerializeObject(entities, Newtonsoft.Json.Formatting.Indented);
            await File.WriteAllTextAsync(Path, result);

            return entity;
        }

        public async Task<List<TEntity>> SelectAllAsync()
        {
            var str = await File.ReadAllTextAsync(Path);
            var entities = JsonConvert.DeserializeObject<List<TEntity>>(str);
            return entities;
        }

        public async Task<TEntity> SelectByIdAsync(long id)
        {
            return (await SelectAllAsync()).FirstOrDefault(e => e.Id == id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entities = await SelectAllAsync();
            await File.WriteAllTextAsync(Path, "[]");

            foreach (var data in entities)
            {
                if (data.Id == entity.Id)
                {
                    await InsertAsync(entity);
                    continue;
                }
                await InsertAsync(data);
            }
            return entity;
        }
    }
}
