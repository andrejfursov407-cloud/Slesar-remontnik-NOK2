\
using Microsoft.Web.WebView2.WinForms;
using System.Diagnostics;

namespace SlesarRemontnik;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}

internal sealed class MainForm : Form
{
    private readonly WebView2 browser = new();

    public MainForm()
    {
        Text = "Тренажёр «Слесарь-ремонтник НОК»";
        Width = 1280;
        Height = 850;
        MinimumSize = new Size(900, 600);
        StartPosition = FormStartPosition.CenterScreen;

        browser.Dock = DockStyle.Fill;
        Controls.Add(browser);

        Shown += async (_, _) => await OpenSiteAsync();
        FormClosing += (_, _) => browser.Dispose();
    }

    private async Task OpenSiteAsync()
    {
        try
        {
            var htmlFile = Path.Combine(AppContext.BaseDirectory, "Слесарь ремонтник НОК.html");
            if (!File.Exists(htmlFile))
            {
                MessageBox.Show(
                    "Не найден файл сайта:\n" + htmlFile +
                    "\n\nПоложите HTML-файл рядом с EXE.",
                    "Ошибка запуска", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            await browser.EnsureCoreWebView2Async();
            browser.CoreWebView2.Settings.AreDefaultContextMenusEnabled = true;
            browser.CoreWebView2.Settings.IsStatusBarEnabled = false;
            browser.CoreWebView2.Settings.AreDevToolsEnabled = false;
            browser.Source = new Uri(htmlFile);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Не удалось запустить тренажёр.\n\n" + ex.Message +
                "\n\nУстановите Microsoft Edge WebView2 Runtime и запустите программу снова.",
                "Ошибка запуска", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
