using BrunoTragl.TesteGrupoBoticario.Domain.Model;

namespace BrunoTragl.TesteGrupoBoticario.Infra.Repository.Interfaces
{
    public interface IProductRepository
    {
        Product Get(long sku);
        void Add(Product produto);
        void Update(Product produto);
        void Remove(long sku);
        bool Any(long sku);
    }
}
