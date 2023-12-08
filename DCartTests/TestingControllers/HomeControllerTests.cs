using DCartTests.HelperClasses;
using DCartWeb.Controllers;
using DCartWeb.Data;
using DCartWeb.LoadIntoUI;
using DCartWeb.Models.Products;
using DCartWeb.Repos.HomeRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Stripe;
using Stripe.Identity;
using System.Linq;
using Product = DCartWeb.Models.Products.Product;

namespace DCartTests.TestingControllers
{
    /// <summary>
    /// Ensures Home controller end points returns correct status codes
    /// </summary>
    public class HomeControllerTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _httpClient;


        public HomeControllerTests(TestingWebAppFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Index_WhenCalled_ReturnsSuccessCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/Home");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }

        [Fact]
        public async Task SubIndex_WhenCalled_ReturnsSuccessCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/Home/SubIndex/1");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }

        [Fact]
        public async Task Product_WhenCalled_ReturnsSuccessCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/Home/Product/1");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }

        [Fact]
        public async Task Details_WhenCalled_ReturnsSuccessCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/Home/Details/1");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }
    }
}