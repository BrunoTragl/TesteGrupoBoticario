using BrunoTragl.TesteGrupoBoticario.Tests.WebApi.ProductModelState.Base;
using BrunoTragl.TesteGrupoBoticario.Web.WebApi.Models;

namespace BrunoTragl.TesteGrupoBoticario.Tests.WebApi.ProductModelState
{
    public class BadProduct : ProductBase
    {
        protected override void CreateProduct()
        {
            Product = new ProductModel
            {   
                Name = null,
                Inventory = null
            };
        }
    }
}
