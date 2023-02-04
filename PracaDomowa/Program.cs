using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.AccessControl;
using System.Globalization;

IWebDriver driver = new ChromeDriver();
driver.Navigate().GoToUrl("https://www.saucedemo.com/");
driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
driver.FindElement(By.CssSelector("#login-button")).Click();
float total = 0;
int amount = 0;
foreach (var obj in driver.FindElements(By.ClassName("inventory_item_description")))
{
    amount++;
    if (amount> 3)
    {
        continue;
    }
    obj.FindElement(By.ClassName("btn_inventory")).Click();
    var temp = obj.FindElement(By.ClassName("inventory_item_price")).Text.Remove(0, 1);
    total += float.Parse(temp, CultureInfo.InvariantCulture.NumberFormat);
}
driver.FindElement(By.ClassName("shopping_cart_link")).Click();
driver.FindElement(By.Id("checkout")).Click();
driver.FindElement(By.Id("first-name")).SendKeys("John");
driver.FindElement(By.Id("last-name")).SendKeys("Smith");
driver.FindElement(By.Id("postal-code")).SendKeys("12-37");
driver.FindElement(By.Id("continue")).Click();
float sum = float.Parse(driver.FindElement(By.ClassName("summary_subtotal_label")).Text.Remove(0,13), CultureInfo.InvariantCulture.NumberFormat);
Assert.AreEqual(sum, total);
driver.FindElement(By.Id("finish")).Click();
var finish = driver.FindElement(By.ClassName("complete-header")).Text;
Assert.AreEqual(finish, "THANK YOU FOR YOUR ORDER");
Console.ReadLine();