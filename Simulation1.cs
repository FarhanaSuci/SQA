﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
class loginTest
{
    static void Main()
    {
        IWebDriver driver = new ChromeDriver();
        ExtentReports extent = new ExtentReports();

        ExtentSparkReporter htmlreporter = new ExtentSparkReporter(@"D:\SQA\ReportResult\ReportWithClass.html");


        extent.AttachReporter(htmlreporter);

        ExtentTest test = extent.CreateTest("Test case 1", "Positive LogIn test");

        driver.Navigate().GoToUrl("https://dev.ontrak.onsite.com.au/dashboard");

        //test.Log(Status.Info);

        test.Log(Status.Info, "Open url");

        Console.WriteLine("Open url");

        driver.Manage().Window.Maximize();

        Thread.Sleep(10000);
        driver.FindElement(By.CssSelector("#Username")).SendKeys("ju");
        Console.WriteLine("Type username  into Username field");
        test.Log(Status.Info, "Farhana Akter Suci");

        driver.FindElement(By.CssSelector("#btn-login")).Click();

        test.Log(Status.Info, "Push Submit button");
        Console.WriteLine("Push Submit button");

        Thread.Sleep(10000);

        driver.FindElement(By.CssSelector("#Password")).SendKeys("ju");

        test.Log(Status.Info, "Type password ju into Password field");

        Console.WriteLine("Type password ju into Password field");

        driver.FindElement(By.CssSelector("#btn-login")).Click();

        test.Log(Status.Info, "Push Submit button");
        Console.WriteLine("Push Submit button");

        try
        {
            Thread.Sleep(10000);
            driver.FindElement(By.CssSelector("#rent-activity"));
            test.Log(Status.Pass, "Login successfully");
        }

        catch
        {

            test.Log(Status.Fail, "Login failed");
        }

        extent.Flush();

        driver.Quit();
    }
}