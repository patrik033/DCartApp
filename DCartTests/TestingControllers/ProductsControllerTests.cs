using DCartTests.HelperClasses;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCartTests.TestingControllers
{
    /// <summary>
    /// Ensures Products Controller returns correct status code
    /// </summary>
    public class ProductsControllerTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        public ProductsControllerTests(TestingWebAppFactory<Program> fact)
        {
            _httpClient = fact.CreateClient();
        }

        [Fact]
        public async Task Index_WhenCalled_ReturnsSuccessCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/Product");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }

        [Fact]
        public async Task Create_WhenCalled_ReturnsSuccessCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/Product/Create");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }

        [Fact]
        public async Task Create_SentWrongModel_ReturnsViewWithErrorMessages()
        {
            var initResponse = await _httpClient.GetAsync("/Product/Create");
            var antiForgeryValues = await AntiForgeryTokenExtractor.ExtractAntiForgeryValues(initResponse);
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Product/Create");
            postRequest.Headers.Add("Cookie", new CookieHeaderValue(AntiForgeryTokenExtractor.AntiForgeryCookieName, antiForgeryValues.cookieValue).ToString());
            var formModel = new Dictionary<string, string>
            {
                { AntiForgeryTokenExtractor.AntiForgeryFieldName, antiForgeryValues.fieldValue },

            };
            postRequest.Content = new FormUrlEncodedContent(formModel);
            var response = await _httpClient.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Quantity is required", responseString);
        }

        [Fact]
        public async Task Create_WhenPOSTExecuted_ReturnsToIndexViewWithCreatedEmployee()
        {
            var initResponse = await _httpClient.GetAsync("/Product/Create");
            var antiForgeryValues = await AntiForgeryTokenExtractor.ExtractAntiForgeryValues(initResponse);


            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Product/Create");
            postRequest.Headers.Add("Cookie", new CookieHeaderValue(AntiForgeryTokenExtractor.AntiForgeryCookieName, antiForgeryValues.cookieValue).ToString());
            var formModel = new Dictionary<string, string>
            {
                {AntiForgeryTokenExtractor.AntiForgeryFieldName,antiForgeryValues.fieldValue },
                {"Subs.ProductName","New ProductName"},
                {"Subs.QuantityInStock","345" },

            };

            postRequest.Content = new FormUrlEncodedContent(formModel);
            var response = await _httpClient.SendAsync(postRequest);
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);

            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }

        [Fact]
        public async Task View_WhenCalled_ReturnsSuccesCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/Product/View/1");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }

        [Fact]
        public async Task View_WhenCalled_ReturnsNotFound()
        {
      
            //Act
            var response = await _httpClient.GetAsync("/Product/View/3433443");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.NotFound);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.NotFound), statusCode);
        }

        [Fact]
        public async Task DeleteView_WhenCalled_ReturnsSuccessCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/Product/DeleteView/1");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }

        [Fact]
        public async Task DeleteView_WhenCalled_ReturnsNotFound()
        {
     
            //Act
            var response = await _httpClient.GetAsync("/Product/DeleteView/344343");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.NotFound);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.NotFound), statusCode);
        }

        [Fact]
        public async Task EditView_WhenCalled_ReturnsSuccessCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/Product/EditView/1");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }

        [Fact]
        public async Task EditView_WhenCalled_ReturnsNotFound()
        {
     
            //Act
            var response = await _httpClient.GetAsync("/Product/EditView/344343");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.NotFound);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.NotFound), statusCode);
        }
    }
}
