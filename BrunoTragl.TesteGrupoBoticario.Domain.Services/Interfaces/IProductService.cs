using BrunoTragl.TesteGrupoBoticario.Domain.Model;

namespace BrunoTragl.TesteGrupoBoticario.Domain.Services.Interfaces
{
    public interface IProductService
    {
        Product Get(long sku);
        void Add(Product produto);
        void Update(Product produto);
        void Remove(long sku);
        bool Any(long sku);
    }
}
