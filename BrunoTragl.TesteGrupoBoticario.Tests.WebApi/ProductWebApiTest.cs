using BrunoTragl.TesteGrupoBoticario.Tests.WebApi.Enumerable;
using BrunoTragl.TesteGrupoBoticario.Tests.WebApi.ProductModelState.Enumerable;
using BrunoTragl.TesteGrupoBoticario.Tests.WebApi.ProductModelState.Factory;
using BrunoTragl.TesteGrupoBoticario.Web.WebApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net;

namespace BrunoTragl.TesteGrupoBoticario.Tests.WebApi
{
    [TestClass]
    public class ProductWebApiTest : WebApiBase
    {
        private string ApiAddressProduct {
            get
            {
                return "/api/product/";
            }
        }

        [TestMethod]
        public void GetNotFoundTest()
        {
            TokenModel tokenModel = GetToken();

            var requestBuilder = CreateRequestBuilder(ApiAddressProduct, 
                                                      Method.GET.ToString(), 
                                                      tokenModel.Token);

            var response = requestBuilder.GetAsync().Result;

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void GetSuccessTest()
        {
            PostSuccessTest();

            TokenModel tokenModel = GetToken();

            var healthyProduct = ProductFactory.Create(StateProduct.WithQuantity);
            var requestBuilder = CreateRequestBuilder($"{ApiAddressProduct}{healthyProduct.Sku}",
                                                      Method.GET.ToString(), 
                                                      tokenModel.Token);

            var response = requestBuilder.GetAsync().Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void PostBadRequestTest()
        {
            TokenModel tokenModel = GetToken();

            var badProduct = ProductFactory.Create(StateProduct.Bad);
            var requestBuilder = CreateRequestBuilder(ApiAddressProduct,
                                                      Method.POST.ToString(), 
                                                      tokenModel.Token, 
                                                      CreateContent(badProduct));

            var response = requestBuilder.PostAsync().Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PostSuccessTest()
        {
            TokenModel tokenModel = GetToken();

            var healthyProduct = ProductFactory.Create(StateProduct.WithQuantity);
            var requestBuilder = CreateRequestBuilder(ApiAddressProduct,
                                                      Method.POST.ToString(),
                                                      tokenModel.Token, 
                                                      CreateContent(healthyProduct));

            var response = requestBuilder.PostAsync().Result;

            response.EnsureSuccessStatusCode();

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void PostWithQuantityProductsTest()
        {
            TokenModel tokenModel = GetToken();

            var withQuantityProduct = ProductFactory.Create(StateProduct.WithQuantity);
            var requestBuilder = CreateRequestBuilder(ApiAddressProduct,
                                                      Method.POST.ToString(),
                                                      tokenModel.Token,
                                                      CreateContent(withQuantityProduct));

            var response = requestBuilder.PostAsync().Result;

            response.EnsureSuccessStatusCode();

            var productString = response.Content.ReadAsStringAsync().Result;
            var product = JsonConvert.DeserializeObject<ProductModel>(productString);

            product.Inventory.CalculateQuantity();
            product.IsMarketableProduct();

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual(product.IsMarketable, true);
            Assert.IsTrue(product.Inventory.Quantity > 0);
        }

        [TestMethod]
        public void PostWithoutQuantityProductsTest()
        {
            TokenModel tokenModel = GetToken();

            var withoutQuantityProduct = ProductFactory.Create(StateProduct.WithoutQuantity);
            var requestBuilder = CreateRequestBuilder(ApiAddressProduct,
                                                      Method.POST.ToString(),
                                                      tokenModel.Token,
                                                      CreateContent(withoutQuantityProduct));

            var response = requestBuilder.PostAsync().Result;

            response.EnsureSuccessStatusCode();

            var productString = response.Content.ReadAsStringAsync().Result;
            var product = JsonConvert.DeserializeObject<ProductModel>(productString);

            product.Inventory.CalculateQuantity();
            product.IsMarketableProduct();

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual(product.IsMarketable, false);
            Assert.IsTrue(product.Inventory.Quantity == 0);
        }

        [TestMethod]
        public void PutSuccessTest()
        {
            TokenModel tokenModel = GetToken();

            var withQuantityPostProduct = ProductFactory.Create(StateProduct.WithQuantity);
            var postRequestBuilder = CreateRequestBuilder(ApiAddressProduct,
                                                      Method.POST.ToString(),
                                                      tokenModel.Token,
                                                      CreateContent(withQuantityPostProduct));

            var postResponse = postRequestBuilder.PostAsync().Result;

            postResponse.EnsureSuccessStatusCode();

            Assert.AreEqual(HttpStatusCode.Created, postResponse.StatusCode);

            

            var putProduct = ProductFactory.Create(StateProduct.WithoutQuantity);
            var putRequestBuilder = CreateRequestBuilder($"{ApiAddressProduct}{withQuantityPostProduct.Sku}",
                                                      Method.PUT.ToString(),
                                                      tokenModel.Token, 
                                                      CreateContent(putProduct));

            var putResponse = putRequestBuilder.SendAsync(Method.PUT.ToString()).Result;

            putResponse.EnsureSuccessStatusCode();

            putProduct.Inventory.CalculateQuantity();
            putProduct.IsMarketableProduct();
            
            Assert.AreEqual(HttpStatusCode.NoContent, putResponse.StatusCode);
            Assert.AreEqual(putProduct.IsMarketable, false);
            Assert.IsTrue(putProduct.Inventory.Quantity == 0);
        }
    }
}
