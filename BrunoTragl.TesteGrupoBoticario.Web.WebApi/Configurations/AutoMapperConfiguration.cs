using AutoMapper;
using BrunoTragl.TesteGrupoBoticario.Domain.Model;
using BrunoTragl.TesteGrupoBoticario.Web.WebApi.Models;

namespace BrunoTragl.TesteGrupoBoticario.Web.WebApi.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Inventory, InventoryModel>().ReverseMap();
            CreateMap<Warehouse, WarehouseModel>().ReverseMap();
        }
    }
}
