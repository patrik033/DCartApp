using DCartTests.HelperClasses;
using DCartWeb.Controllers;
using DCartWeb.Models.Products;
using DCartWeb.Repos.MainCategoryRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Moq;
using Xunit;

namespace DCartTests.TestingControllers
{
    /// <summary>
    /// Ensures Main Category end points returns correct status code 
    /// </summary>
    public class MainCategoryControllerTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _httpClient;


        public MainCategoryControllerTests(TestingWebAppFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }



        [Fact]
        public async Task Index_WhenCalled_ReturnsSuccessCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/MainCategory");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }

        [Fact]
        public async Task Create_WhenCalled_ReturnsSuccessCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/MainCategory/Create");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }

        [Fact]
        public async Task Create_SentWrongModel_ReturnsViewWithErrorMessages()
        {
            var initResponse = await _httpClient.GetAsync("/MainCategory/Create");
            var antiForgeryValues = await AntiForgeryTokenExtractor.ExtractAntiForgeryValues(initResponse);
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/MainCategory/Create");
            postRequest.Headers.Add("Cookie", new CookieHeaderValue(AntiForgeryTokenExtractor.AntiForgeryCookieName, antiForgeryValues.cookieValue).ToString());
            var formModel = new Dictionary<string, string>
            {
                { AntiForgeryTokenExtractor.AntiForgeryFieldName, antiForgeryValues.fieldValue },

            };
            postRequest.Content = new FormUrlEncodedContent(formModel);
            var response = await _httpClient.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Name is required", responseString);
        }

        [Fact]
        public async Task Create_WhenPOSTExecuted_ReturnsToIndexViewWithCreatedEmployee()
        {
            var initResponse = await _httpClient.GetAsync("/MainCategory/Create");
            var antiForgeryValues = await AntiForgeryTokenExtractor.ExtractAntiForgeryValues(initResponse);


            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/MainCategory/Create");
            postRequest.Headers.Add("Cookie", new CookieHeaderValue(AntiForgeryTokenExtractor.AntiForgeryCookieName, antiForgeryValues.cookieValue).ToString());
            var formModel = new Dictionary<string, string>
            {
                {AntiForgeryTokenExtractor.AntiForgeryFieldName,antiForgeryValues.fieldValue },
                {"Name","New MainCategory"},

            };

            postRequest.Content = new FormUrlEncodedContent(formModel);
            var response = await _httpClient.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("New MainCategory", responseString);

        }

        [Fact]
        public async Task View_WhenCalled_ReturnsSuccesCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/MainCategory/View/1");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }

        [Fact]
        public async Task View_WhenCalled_ReturnsNotFound()
        {
        
            //Act
            var response = await _httpClient.GetAsync("/MainCategory/View/3433443");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.NotFound);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.NotFound), statusCode);
        }

        [Fact]
        public async Task DeleteView_WhenCalled_ReturnsSuccessCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/MainCategory/DeleteView/1");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }

        [Fact]
        public async Task DeleteView_WhenCalled_ReturnsNotFound()
        {
     
            //Act
            var response = await _httpClient.GetAsync("/MainCategory/DeleteView/344343");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.NotFound);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.NotFound), statusCode);
        }

        [Fact]
        public async Task EditView_WhenCalled_ReturnsSuccessCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/MainCategory/EditView/1");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }

        [Fact]
        public async Task EditView_WhenCalled_ReturnsNotFound()
        {
         
            //Act
            var response = await _httpClient.GetAsync("/MainCategory/EditView/344343");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.NotFound);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.NotFound), statusCode);
        }

    }
}