using BrunoTragl.TesteGrupoBoticario.Tests.WebApi.ProductModelState.Interfaces;
using BrunoTragl.TesteGrupoBoticario.Web.WebApi.Models;

namespace BrunoTragl.TesteGrupoBoticario.Tests.WebApi.ProductModelState.Base
{
    public abstract class ProductBase : IProductModelState
    {
        protected ProductModel Product { get; set; }
        protected ProductBase()
        {
            Product = new ProductModel();
            CreateProduct();
        }
        protected abstract void CreateProduct();
        public ProductModel Get()
        {
            return Product;
        }
    }
}
