using Castle.Components.DictionaryAdapter;
using DCartTests.HelperClasses;
using DCartWeb.Models.Carts;
using DCartWeb.Models.Orders;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DCartTests.UiTesting
{
    public class UiTestCartController : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly IWebDriver _driver;


        public UiTestCartController()
        {
            _driver = new ChromeDriver();
        }

        /// <summary>
        /// Testing if the order equals the cart items
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task AutomatedTestCheck_ForCheckOutOrder()
        {

            var cartItemsList = new List<CartItem>();
            var orderItemsList = new List<OrderItem>();
            var cartTotalPrice = 0M;
            var orderTotalPrice = 0M;
            var totalPriceForCart = 0M;
            var totalPriceForOrder = 0M;
            

            //Loging in an admin
            LoginUser("admin.dcartapp@gmail.com", "Admin123#");

            //Check amount of orders 
            _driver.Navigate().GoToUrl("https://localhost:7177/Admin/Orders");
            var ordersInCart = _driver.FindElements(By.Id("orders"));
            var ordersNumber = ordersInCart.Count();

            //navigate to an order and add one to the cart
            _driver.Navigate().GoToUrl("https://localhost:7177/Home/Details/5");
            var addToCartButton = _driver.FindElement(By.Id("add"));
            addToCartButton.Click();

            //navigate to the cart and create cartitems for all the products in the order
            cartTotalPrice = CreateCartItems(cartItemsList, cartTotalPrice);

            //find the total cost for the order
            totalPriceForCart = GetTotalPrice();

            //navigate to stripe and await for all contents to load
            var submitButton = _driver.FindElement(By.Id("checkout-button"));
            submitButton.Click();
            await Task.Delay(2000);

            //populate all the fields
            var shippingName = _driver.FindElement(By.Id("shippingName"));
            shippingName.SendKeys("Admin");

            var shippingAddressLine1 = _driver.FindElement(By.Id("shippingAddressLine1"));
            shippingAddressLine1.SendKeys("Some Address That's not important :)");

            var cardNumber = _driver.FindElement(By.Id("cardNumber"));
            cardNumber.SendKeys("4242 4242 4242 4242");

            var cardExpiry = _driver.FindElement(By.Id("cardExpiry"));
            cardExpiry.SendKeys("12/34");

            var cardCvc = _driver.FindElement(By.Id("cardCvc"));
            cardCvc.SendKeys("123");

            var shippingPostalCode = _driver.FindElement(By.Id("shippingPostalCode"));
            shippingPostalCode.SendKeys("63654");

            var shippingLocality = _driver.FindElement(By.Id("shippingLocality"));
            shippingLocality.SendKeys("Eskilstuna");

            var SubmitButton = _driver.FindElement(By.ClassName("SubmitButton"));
            SubmitButton.Click();

            //get the fields from the success page
            await Task.Delay(5000);
            //create orderitems
            orderTotalPrice = CreateOrderItems(orderItemsList, orderTotalPrice);

            //get the total price from the success page, should be the same as from the cart
            totalPriceForOrder = GetTotalPrice();

            //test
            Assert.Equal(totalPriceForCart, totalPriceForOrder);
            Assert.Equal(cartTotalPrice, orderTotalPrice);
            Assert.Equal(orderItemsList.Count(), cartItemsList.Count());

            //navigate to the orders page and check if cart and orders amount are the same
            _driver.Navigate().GoToUrl("https://localhost:7177/Admin/Orders");
            var ordersInCartFinal = _driver.FindElements(By.Id("orders"));
            var ordersNumberFinal = ordersInCartFinal.Count();

            Assert.Equal(ordersNumber + 1, ordersNumberFinal);
        }

        /// <summary>
        /// Check to see if a customer has access to product page
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task AutomatedTestCustomerRestrictionsForProduct()
        {
            //Loging in as a customer
            LoginUser("test.dcartapp@gmail.com", "Test123#");
            _driver.Navigate().GoToUrl("https://localhost:7177/Product/Index");
            var danger = _driver.FindElement(By.Id("danger")).Text;
            Assert.Equal("Access denied", danger);
        }

        /// <summary>
        /// Check that an admin has access to the admin section
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task AutomatedTestAdminNoRestrictionForProduct()
        {
            LoginUser("admin.dcartapp@gmail.com", "Admin123#");
            _driver.Navigate().GoToUrl("https://localhost:7177/Admin/Index");
            var dashboard = _driver.FindElement(By.Id("dashboard")).Text;
            Assert.Equal("Dashboard", dashboard);
        }


        [Fact]
        public async Task AutomatedTest_ChangingOrderQuantity_OneType()
        {
            LoginUser("test.dcartapp@gmail.com", "Test123#");
            _driver.Navigate().GoToUrl("https://localhost:7177/Home/Details/5");
            var addToCartButton = _driver.FindElement(By.Id("add"));
            var firstProductPrice = _driver.FindElement(By.Id("product-price")).Text;
            var firstProductIndex = firstProductPrice.IndexOf('k');
            var firstProductSubsting = firstProductPrice.Substring(0, firstProductIndex - 1);
            var firstProductDecimal = decimal.Parse(firstProductSubsting);
            addToCartButton.Click();
            _driver.Navigate().GoToUrl("https://localhost:7177/Cart");
            var firstTotalPrice = GetTotalPrice();
            Assert.Equal(firstProductDecimal, firstTotalPrice);
            _driver.Navigate().GoToUrl("https://localhost:7177/Home/Details/5");
            var addToCartButtonSecond = _driver.FindElement(By.Id("add"));
            addToCartButtonSecond.Click();
            _driver.Navigate().GoToUrl("https://localhost:7177/Cart");
            var secondTotalPrice = GetTotalPrice();
            Assert.Equal((firstProductDecimal * 2), secondTotalPrice);
            var deleteButton = _driver.FindElement(By.Id("buttonDelete"));
            deleteButton.Click();
           
       
        }

        [Fact]
        public void AutomatedTest_ChangingOrderQuantity_ForTwoTypes()
        {
            LoginUser("test.dcartapp@gmail.com", "Test123#");
            //get first product Price
            _driver.Navigate().GoToUrl("https://localhost:7177/Home/Details/5");
            var addToCartFirstProductFirstTime = _driver.FindElement(By.Id("add"));
            var firstProductDecimal = GetProductPrice();
            addToCartFirstProductFirstTime.Click();
            //check the contents in cart are correct
            _driver.Navigate().GoToUrl("https://localhost:7177/Cart");
            var firstTotalPrice = GetTotalPrice();
            Assert.Equal((firstProductDecimal * 1), firstTotalPrice);
            //get second product price
            _driver.Navigate().GoToUrl("https://localhost:7177/Home/Details/11");
            var addToCartSecondProductFirstTime = _driver.FindElement(By.Id("add"));
            decimal secondProductDecimal = GetProductPrice();
            addToCartSecondProductFirstTime.Click();
            //check the contents are correct
            _driver.Navigate().GoToUrl("https://localhost:7177/Cart");
            var secondTotalPrice = GetTotalPrice();
            Assert.Equal((firstProductDecimal + secondProductDecimal), secondTotalPrice);
            //increase the first products amount
            _driver.Navigate().GoToUrl("https://localhost:7177/Home/Details/5");
            var addToCartFirstProductSecondTime = _driver.FindElement(By.Id("add"));
            addToCartFirstProductSecondTime.Click();
            //check the contents are correct
            _driver.Navigate().GoToUrl("https://localhost:7177/Cart");
            var thirdTotalPrice = GetTotalPrice();
            Assert.Equal(((firstProductDecimal * 2) + secondProductDecimal), thirdTotalPrice);
            for (int i = 0; i <= 1; i++)
            {
                var buttons = _driver.FindElement(By.Id("buttonDelete"));
                buttons.Click();
                Thread.Sleep(1000);
            }
            _driver.Navigate().GoToUrl("https://localhost:7177/Index");
            _driver.Navigate().GoToUrl("https://localhost:7177/Cart");
            var buttonsExist = _driver.FindElements(By.Id("buttonDelete")).Count();
            Assert.Equal(0, buttonsExist);
        }

        [Fact]
        public async Task AutomatedTest_ChangingOrderQuantity_ForTreeTypes()
        {
            LoginUser("test.dcartapp@gmail.com", "Test123#");

            //get first product Price
            _driver.Navigate().GoToUrl("https://localhost:7177/Home/Details/5");
            var addToCartFirstProductFirstTime = _driver.FindElement(By.Id("add"));
            var firstProductDecimal = GetProductPrice();
            //add it to the cart
            addToCartFirstProductFirstTime.Click();
            //check the contents in cart are correct
            _driver.Navigate().GoToUrl("https://localhost:7177/Cart");
            var firstTotalPrice = GetTotalPrice();
            Assert.Equal((firstProductDecimal * 1), firstTotalPrice);



            //get second product price
            _driver.Navigate().GoToUrl("https://localhost:7177/Home/Details/11");
            var addToCartSecondProductFirstTime = _driver.FindElement(By.Id("add"));
            decimal secondProductDecimal = GetProductPrice();
            //add it to the cart
            addToCartSecondProductFirstTime.Click();
            //check the contents are correct
            _driver.Navigate().GoToUrl("https://localhost:7177/Cart");
            var secondTotalPrice = GetTotalPrice();
            Assert.Equal((firstProductDecimal + secondProductDecimal), secondTotalPrice);

            //increase the first products amount
            _driver.Navigate().GoToUrl("https://localhost:7177/Home/Details/5");
            var addToCartFirstProductSecondTime = _driver.FindElement(By.Id("add"));
            //add it to the cart
            addToCartFirstProductSecondTime.Click();
            //check the contents are correct
            _driver.Navigate().GoToUrl("https://localhost:7177/Cart");
            var thirdTotalPrice = GetTotalPrice();
            Assert.Equal(((firstProductDecimal * 2) + secondProductDecimal), thirdTotalPrice);

            //get the price for a third product
            _driver.Navigate().GoToUrl("https://localhost:7177/Home/Details/8");
            var addToCartThirdProductFirstTime = _driver.FindElement(By.Id("add"));
            decimal thirdProductDecimal = GetProductPrice();
            //add it to the cart
            addToCartThirdProductFirstTime.Click();

            //check the contents are correct
            _driver.Navigate().GoToUrl("https://localhost:7177/Cart");
            var forthTotalPrice = GetTotalPrice();
            Assert.Equal(((firstProductDecimal * 2) + (secondProductDecimal + thirdProductDecimal)), forthTotalPrice);

            //delete every product in the cart
            for (int i = 0; i <= 2; i++)
            {
                var buttons = _driver.FindElements(By.Id("buttonDelete"));
                buttons[0].Click();
                Thread.Sleep(1000);
            }
            //check that no product are left in the cart
            var buttonsExist = _driver.FindElements(By.Id("buttonDelete")).Count();
            Assert.Equal(0, buttonsExist);
        }




        /// <summary>
        /// Get price for the product
        /// </summary>
        /// <returns></returns>
        private decimal GetProductPrice()
        {
            var secondProductPrice = _driver.FindElement(By.Id("product-price")).Text;
            var secondProductIndex = secondProductPrice.IndexOf('k');
            var secondProductSubsting = secondProductPrice.Substring(0, secondProductIndex - 1);
            var secondProductDecimal = decimal.Parse(secondProductSubsting);
            return secondProductDecimal;
        }


        /// <summary>
        /// Loop through every item in the card-body and return the total sum
        /// </summary>
        /// <param name="cartItemsList"></param>
        /// <param name="cartTotalPrice"></param>
        /// <returns></returns>
        private decimal CreateCartItems(List<CartItem> cartItemsList, decimal cartTotalPrice)
        {
            _driver.Navigate().GoToUrl("https://localhost:7177/Cart");
            var post = _driver.FindElement(By.XPath("//form[@id='content-post']"));
            var listOfPosts = post.FindElements(By.XPath("//div[@class='card-body']"));
            foreach (var item in listOfPosts)
            {
                var names = item.FindElement(By.Id("content-name")).Text;
                var prices = item.FindElement(By.Id("content-price")).Text;
                var pricesIndex = prices.IndexOf('k');
                var pricesSubstring = prices.Substring(0, pricesIndex - 1);
                var toalPrices = item.FindElement(By.Id("content-totalPrice")).Text;
                var quantityInCarts = item.FindElement(By.Id("content-quantityInCart")).Text;


                var cartItem = new CartItem()
                {
                    Name = names,
                    Price = decimal.Parse(pricesSubstring),
                    QuantityInCart = int.Parse(quantityInCarts),

                };
                //Populate the list with every cartitem from the card-body items
                cartItemsList.Add(cartItem);
                cartTotalPrice += cartItem.QuantityInCart * cartItem.Price;
            }

            return cartTotalPrice;
        }
        /// <summary>
        /// Get the total price
        /// </summary>
        /// <returns></returns>
        private decimal GetTotalPrice()
        {
            decimal totalPriceForOrder;
            var secondTotalPrice = _driver.FindElement(By.Id("total-price")).Text;
            var totalSecondPriceIndex = secondTotalPrice.IndexOf('k');
            var totalSecondPriceSubstring = secondTotalPrice.Substring(0, totalSecondPriceIndex - 1);
            totalPriceForOrder = decimal.Parse(totalSecondPriceSubstring);
            return totalPriceForOrder;
        }
        /// <summary>
        /// Login in a User
        /// </summary>
        /// <param name="email"></param>
        /// <param name="login"></param>
        private void LoginUser(string email, string login)
        {
            _driver.Navigate().GoToUrl("https://localhost:7177/Identity/Account/Login");
            var emailTextBox = _driver.FindElement(By.Id("Input_Email"));
            emailTextBox.SendKeys(email);
            var passwordTextBox = _driver.FindElement(By.Id("pass"));
            passwordTextBox.SendKeys(login);
            var loginButton = _driver.FindElement(By.Id("login-submit"));
            loginButton.Click();
        }


        private decimal CreateOrderItems(List<OrderItem> orderItemsList, decimal orderTotalPrice)
        {
            //get all elements from 'card-body'
            var listOfPostsid = _driver.FindElement(By.XPath("//form[@id='content-post']"));
            var listOfPostsItems = listOfPostsid.FindElements(By.XPath("//div[@class='card-body']"));


            //loop through the list and saves them to the list
            foreach (var item in listOfPostsItems)
            {
                var names = item.FindElement(By.Id("content-name")).Text;
                var prices = item.FindElement(By.Id("content-price")).Text;
                var pricesIndex = prices.IndexOf('k');
                var pricesSubstring = prices.Substring(0, pricesIndex - 1);
                var toalPrices = item.FindElement(By.Id("content-totalPrice")).Text;
                var quantityInCarts = item.FindElement(By.Id("content-quantityInCart")).Text;

                var orderItem = new OrderItem()
                {
                    Name = names,
                    Price = decimal.Parse(pricesSubstring),
                    QuantityInCart = int.Parse(quantityInCarts),
                };

                var priceForOrder = orderItem.Price;
                orderItemsList.Add(orderItem);
                orderTotalPrice += orderItem.QuantityInCart * orderItem.Price;
            }
            return orderTotalPrice;
        }
    }
}
