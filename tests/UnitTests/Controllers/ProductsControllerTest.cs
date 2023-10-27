using AutoBogus;
using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using WebApplication2.Controllers;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;
using Xunit;
namespace UnitTests.Controllers
{
    public class ProductsControllerTest
    {
        public readonly ProductsController _productsController;
        public readonly Mock<IProductsRepository> _productsRepository;
        public ProductsControllerTest()
        {
            _productsRepository = new Mock<IProductsRepository>();
            _productsController = new ProductsController(_productsRepository.Object);
        }
            
        [Fact(DisplayName = "ProductsController >> ShouldSuccess >> When Calling GetProductsAsync")]
        public async Task ProductsController_ShouldSuccess_WhenCallingGetProductsAsync()
        {
            //arrange
            var products = new AutoFaker<Products>().Generate(3).AsEnumerable();
            _productsRepository.Setup(s => s.GetProductsAsync()).ReturnsAsync(products);

            //act
            var response = await _productsController.GetProducts();
            var productsResponse = (response.Result as OkObjectResult)!.Value as IEnumerable<Products>;

            //assert
            products.Should().BeEquivalentTo(products);
        }

        [Fact(DisplayName = "ProductsController >> ShoudFail >> When Calling GetProductsAsync By Id")]
        public async Task ProductsController_ShouldFail_WhenCallingGetProductsAsyncById()
        {
            //arrange
            int productId = new Faker().Random.Int(-1000000, 0);

            //act
            var response = await Assert.ThrowsAsync<Exception>(async () => await _productsController.GetProducts(productId));

            //assert
            response.Message.Should().Be("Não é permitido id menor que zero");
        }

        [Fact(DisplayName = "ProductsController >> Should Success >> When Calling PutProducts")]
        public async Task ProductsController_ShouldSuccess_WhenCallingPutProducts()
        {
            //arrange
            int productId = new Faker().Random.Int(1);
            var products = new AutoFaker<Products>().Generate();

            //act
            var response = await _productsController.PutProducts(productId, products);
            var okObjectResult = response.Result as OkObjectResult;

            //assert
            okObjectResult!.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact(DisplayName = "ProductsController >> Should Success >> When Calling PostProducts")]
        public async Task ProductsController_ShouldSuccess_WhenCallingPostProducts()
        {
            //arrange
            var products = new AutoFaker<Products>().Generate();

            //act
            var response = await _productsController.PostProducts(products);
            var okObjectResult = response.Result as OkObjectResult;

            //assert
            okObjectResult!.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact(DisplayName = "ProductsController >> Should Success >> When Calling DeleteProducts")]
        public async Task ProductsController_ShouldSuccess_WhenCallingDeleteProducts()
        {
            //arrange
            int productId = new Faker().Random.Int(1);

            //act
            var response = await _productsController.DeleteProducts(productId);
            var okObjectResult = response as OkObjectResult;

            //assert
            okObjectResult!.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}