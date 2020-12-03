using BrunoTragl.TesteGrupoBoticario.Tests.WebApi.ProductModelState.Base;
using BrunoTragl.TesteGrupoBoticario.Web.WebApi.Models;
using System.Collections.Generic;

namespace BrunoTragl.TesteGrupoBoticario.Tests.WebApi.ProductModelState
{
    public class WithoutQuantityProduct : ProductBase
    {
        protected override void CreateProduct()
        {
            Product = new ProductModel
            {
                Sku = 3215,
                Name = "Ralph Lauren Polo Blue Perfume Masculino Travel - Eau de Toilette 30ml",
                Inventory = new InventoryModel
                {
                    Warehouses = new List<WarehouseModel>()
                    {
                        new WarehouseModel
                        {
                            Locality = "MG",
                            Quantity = 0,
                            Type = "ECOMMERCE"
                        },
                        new WarehouseModel
                        {
                            Locality = "Grande ABC",
                            Quantity = 0,
                            Type = "PHYSICAL_STORE"
                        }
                    }
                }
            };
        }
    }
}
