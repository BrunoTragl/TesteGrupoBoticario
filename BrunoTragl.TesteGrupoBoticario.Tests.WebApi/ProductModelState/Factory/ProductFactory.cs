using BrunoTragl.TesteGrupoBoticario.Tests.WebApi.ProductModelState.Base;
using BrunoTragl.TesteGrupoBoticario.Tests.WebApi.ProductModelState.Enumerable;
using BrunoTragl.TesteGrupoBoticario.Web.WebApi.Models;

namespace BrunoTragl.TesteGrupoBoticario.Tests.WebApi.ProductModelState.Factory
{
    public static class ProductFactory
    {
        public static ProductModel Create(StateProduct state)
        {
            switch(state)
            {
                case StateProduct.Bad:
                    return new BadProduct().Get();
                case StateProduct.WithoutQuantity:
                    return new WithoutQuantityProduct().Get();
                case StateProduct.WithQuantity:
                    return new WithQuantityProduct().Get();
                default:
                    return null;
            }
        }
    }
}
