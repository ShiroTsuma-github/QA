
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

IWebDriver driver = new ChromeDriver();
driver.Navigate().GoToUrl("https://www.saucedemo.com/");
driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
driver.FindElement(By.CssSelector("#login-button")).Click();
driver.FindElement(By.ClassName("inventory_item_name")).Click();
driver.FindElement(By.Name("add-to-cart-sauce-labs-backpack")).Click();
driver.FindElement(By.ClassName("shopping_cart_link")).Click();

var qnt = driver.FindElement(By.ClassName("cart_quantity")).Text;
Console.WriteLine($"Quantity: {qnt}");
Assert.IsTrue(qnt == "1");
Assert.AreEqual("1", qnt);


var name = driver.FindElement(By.ClassName("inventory_item_name")).Text;
Console.WriteLine($"Product name: {name}");
Assert.IsTrue(name == "Sauce Labs Backpack");
Assert.AreEqual("Sauce Labs Backpack", name);

var price = driver.FindElement(By.ClassName("inventory_item_price")).Text;
Console.WriteLine($"Price: {price}");
Assert.IsTrue(price == "$29.99");
Assert.IsNotNull(price);
Console.ReadLine();
driver.Quit();