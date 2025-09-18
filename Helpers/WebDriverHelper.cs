using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.IO;

public class WebDriverHelper
{
    public static IWebDriver InitializeDriver()
    {
        string userDataDir = Path.Combine(Path.GetTempPath(), "chrome_data", Guid.NewGuid().ToString());

        ChromeOptions options = new ChromeOptions();
        options.AddArgument($"--user-data-dir={userDataDir}");  // Diretório único para cada execução
        options.AddArgument("--headless"); // Execute o navegador sem a interface gráfica (opcional)

        // Inicia o WebDriver com as opções configuradas
        IWebDriver driver = new ChromeDriver(options);
        return driver;
    }
}
