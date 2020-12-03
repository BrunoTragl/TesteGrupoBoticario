using BrunoTragl.TesteGrupoBoticario.Domain.Model;
using BrunoTragl.TesteGrupoBoticario.Infra.Data.Interfaces;
using BrunoTragl.TesteGrupoBoticario.Infra.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrunoTragl.TesteGrupoBoticario.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private IContext _context;
        public ProductRepository(IContext context)
        {
            _context = context;
        }
        public Product Get(long sku)
        {
            try
            {
                return _context.Products.FirstOrDefault(_ => _.Sku == sku);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Add(Product produto)
        {
            try
            {
                _context.Products.Add(produto);
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
                Product updateProduto = _context.Products.FirstOrDefault(_ => _.Sku == produto.Sku);
                if (updateProduto == null)
                    return;

                updateProduto.Name = produto.Name;
                updateProduto.Inventory = produto.Inventory;
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
                Product removeProduto = _context.Products.FirstOrDefault(_ => _.Sku == sku);
                _context.Products.Remove(removeProduto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Any(long sku)
        {
            return _context.Products.Any(p => p.Sku == sku);
        }
    }
}
