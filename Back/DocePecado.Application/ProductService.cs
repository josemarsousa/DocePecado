using DocePecado.Application.Contracts;
using DocePecado.Domain;
using DocePecado.Persistence.Contracts;
using System;
using System.Threading.Tasks;

namespace DocePecado.Application
{
    public class ProductService : IProductService
    {
        private readonly IGeneralPersist generalPersist;
        private readonly IProductPersist productPersist;

        public ProductService(IGeneralPersist generalPersist, IProductPersist productPersist)
        {
            this.generalPersist = generalPersist;
            this.productPersist = productPersist;
        }
        public async Task<Product> AddProduct(Product model)
        {
            try
            {
                this.generalPersist.Add<Product>(model);
                if (await this.generalPersist.SaveChangesAsync())
                {
                    return await this.productPersist.GetProductByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> UpdateProduct(long productId, Product model)
        {
            try
            {
                var product = await this.productPersist.GetProductByIdAsync(productId, false);
                if (product == null) return null;

                model.Id = product.Id;

                this.generalPersist.Update(model);
                if (await this.generalPersist.SaveChangesAsync())
                {
                    return await this.productPersist.GetProductByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteProduct(long productId)
        {
            try
            {
                var product = await this.productPersist.GetProductByIdAsync(productId, false);
                if (product == null) throw new Exception("Produto não encontrado");

                this.generalPersist.Delete<Product>(product);
                return await this.generalPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product[]> GetAllProductsAsync(bool includeOrders = false)
        {
            try
            {
                var product = await this.productPersist.GetAllProductsAsync(includeOrders);
                if (product == null) return null;

                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product[]> GetAllProductsByNameAsync(string name, bool includeOrders = false)
        {
            try
            {
                var product = await this.productPersist.GetAllProductsByNameAsync(name, includeOrders);
                if (product == null) return null;

                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> GetProductByIdAsync(long productId, bool includeOrders = false)
        {
            try
            {
                var product = await this.productPersist.GetProductByIdAsync(productId, includeOrders);
                if (product == null) return null;

                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
