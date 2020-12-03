using BrunoTragl.TesteGrupoBoticario.Domain.Model;
using BrunoTragl.TesteGrupoBoticario.Domain.Services.Interfaces;
using BrunoTragl.TesteGrupoBoticario.Infra.Repository.Interfaces;
using System;

namespace BrunoTragl.TesteGrupoBoticario.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _produtoRepository;
        public ProductService(IProductRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public void Add(Product produto)
        {
            try
            {
                _produtoRepository.Add(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Product Get(long sku)
        {
            try
            {
                return _produtoRepository.Get(sku);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Any(long sku)
        {
            try
            {
                return _produtoRepository.Any(sku);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Remove(long sku)
        {
            try
            {
                _produtoRepository.Remove(sku);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(Product produto)
        {
            try
            {
                _produtoRepository.Update(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
