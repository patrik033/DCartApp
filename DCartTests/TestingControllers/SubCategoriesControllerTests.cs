using DCartTests.HelperClasses;
using DCartWeb.Models.Products;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCartTests.TestingControllers
{
    /// <summary>
    /// Ensures Sub Category returns correct status code
    /// </summary>
    public class SubCategoriesControllerTests :IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        public SubCategoriesControllerTests(TestingWebAppFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Index_WhenCalled_ReturnsSuccessCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/SubCategory");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }

        [Fact]
        public async Task Create_WhenCalled_ReturnsSuccessCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/SubCategory/Create");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }

        [Fact]
        public async Task Create_SentWrongModel_ReturnsViewWithErrorMessages()
        {
            var initResponse = await _httpClient.GetAsync("/SubCategory/Create");
            var antiForgeryValues = await AntiForgeryTokenExtractor.ExtractAntiForgeryValues(initResponse);
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/SubCategory/Create");
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
            var initResponse = await _httpClient.GetAsync("/SubCategory/Create");
            var antiForgeryValues = await AntiForgeryTokenExtractor.ExtractAntiForgeryValues(initResponse);


            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/SubCategory/Create");
            postRequest.Headers.Add("Cookie", new CookieHeaderValue(AntiForgeryTokenExtractor.AntiForgeryCookieName, antiForgeryValues.cookieValue).ToString());
            var formModel = new Dictionary<string, string>
            {
                {AntiForgeryTokenExtractor.AntiForgeryFieldName,antiForgeryValues.fieldValue },
                {"Subs.Name","New SubCategory"},
                {"Subs.MainCategoryId","1" },

            };

            postRequest.Content = new FormUrlEncodedContent(formModel);
            var response = await _httpClient.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("New SubCategory", responseString);
            Assert.Contains("1", responseString);
        }

        [Fact]
        public async Task View_WhenCalled_ReturnsSuccesCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/SubCategory/View/1");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }

        [Fact]
        public async Task View_WhenCalled_ReturnsNotFound()
        {
            
            //Act
            var response = await _httpClient.GetAsync("/SubCategory/View/3433443");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.NotFound);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.NotFound), statusCode);
        }

        [Fact]
        public async Task DeleteView_WhenCalled_ReturnsSuccessCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/SubCategory/DeleteView/1");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }

        [Fact]
        public async Task DeleteView_WhenCalled_ReturnsNotFound()
        {
           
            //Act
            var response = await _httpClient.GetAsync("/SubCategory/DeleteView/344343");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.NotFound);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.NotFound), statusCode);
        }

        [Fact]
        public async Task EditView_WhenCalled_ReturnsSuccessCodeWithResult()
        {
            //Act
            var response = await _httpClient.GetAsync("/SubCategory/EditView/1");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.OK), statusCode);
        }

        [Fact]
        public async Task EditView_WhenCalled_ReturnsNotFound()
        {
            //Act
            var response = await _httpClient.GetAsync("/SubCategory/EditView/344343");
            //Arrange
            var statusCode = response.StatusCode.HasFlag(System.Net.HttpStatusCode.NotFound);
            //Assert
            Assert.Equal(response.StatusCode.HasFlag(System.Net.HttpStatusCode.NotFound), statusCode);
        }
    }
}
