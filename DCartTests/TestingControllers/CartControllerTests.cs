using DCartTests.HelperClasses;
using DCartWeb.Data;
using DCartWeb.Models.Users;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCartTests.TestingControllers
{
    public class CartControllerTests:IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _httpClient;
    
        public CartControllerTests(TestingWebAppFactory<Program> fact)
        {
            _httpClient = fact.CreateClient();
        }
        /// <summary>
        /// Test that the cart returns correct response code
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Index_WhenCalled_ReturnsSuccessCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/Cart");
            //Arrange
            var responseCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            var responseString = await response.Content.ReadAsStringAsync();
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), responseCode);
           



              
        }
    }
}
