using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Levantamento.Infrastructure.Context
{
    public interface ILevantamentoContext : IDisposable
    {
        Task AddCommand(Func<Task> func);
        int SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
