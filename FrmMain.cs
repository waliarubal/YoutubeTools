using AngleSharp.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace YoutubeTools;

public partial class FrmMain : Form
{
    const string BASE_URL = "https://www.youtube.com/watch";
    const string XPATH_PLAY = "//button[contains(@class, 'ytp-play-button ytp-button') and @data-title-no-tooltip='Play']";
    const string XPATH_MUTE = "//button[contains(@class, 'ytp-mute-button ytp-button')]";
    const string XPATH_TIME = "//span[@class = 'ytp-time-duration']";

    readonly Random _random;
    bool _isRunning;
    TimeSpan _duration;
    IWebDriver _driver;

    public FrmMain()
    {
        _duration = TimeSpan.Zero;
        _random = new Random();

        InitializeComponent();

#if DEBUG
        txtVideoKey.Text = "wfGKe09h09o";
        updnInstances.Value = 5;
#endif
    }

    void OpenVideo(string key, bool isMuted)
    {
        //if (dgvWindows.RowCount > 0)
        _driver
            .SwitchTo()
            .NewWindow(WindowType.Window);

        var handle = _driver.CurrentWindowHandle;

        _driver
            .Navigate()
            .GoToUrl($"{BASE_URL}?v={key}");

        var videoControls = new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
            .Until(driver => driver.FindElement(By.ClassName("ytp-chrome-controls")));

        var action = new Actions(_driver);
        action
            .MoveToElement(videoControls)
            .Perform();

        var state = "Unknown";
        try
        {
            var btnPlay = GetElement(XPATH_PLAY);
            btnPlay?.Click();

            if (_duration == TimeSpan.Zero)
            {
                var timeString = GetElement(XPATH_TIME)?
                    .GetAttribute("textContent")?
                    .SplitWithTrimming(':');
                switch (timeString?.Length)
                {
                    case 3:
                        _duration = new TimeSpan(int.Parse(timeString[0]), int.Parse(timeString[1]), int.Parse(timeString[2]));
                        break;

                    case 2:
                        _duration = new TimeSpan(0, int.Parse(timeString[0]), int.Parse(timeString[1]));
                        break;

                    case 1:
                        _duration = new TimeSpan(0, 0, int.Parse(timeString[0]));
                        break;
                }
            }

            if (isMuted)
            {
                var btnMute = GetElement(XPATH_MUTE);
                btnMute?.Click();
            }

            state = "Playing";
        }
        catch
        {

        }

        dgvWindows.BeginInvoke(() =>
        {
            var row = dgvWindows.Rows[dgvWindows.Rows.Add()];
            row.Cells[0].Value = handle;
            row.Cells[1].Value = _driver == null ? string.Empty : _driver.Title;
            row.Cells[2].Value = state;
            row.Cells[3].Value = $"{_duration.Hours:00}:{_duration.Minutes:00}:{_duration.Seconds:00}";
            row.HeaderCell.Value = row.Index + 1;

            BeginInvoke(() => Text = $"YouTube Tools - {row.Index + 1}");
        });
    }

    IWebElement GetElement(string xPath, int waitSeconds = 20)
    {
        var waitTime = TimeSpan.FromSeconds(waitSeconds);
        try
        {
            return new WebDriverWait(_driver, waitTime)
                .Until(driver => driver.FindElement(By.XPath(xPath)));
        }
        catch (Exception ex) when (
            ex is NoSuchElementException ||
            ex is WebDriverTimeoutException ||
            ex is ObjectDisposedException)
        {
            return null;
        }
    }

    void Stop()
    {
        if (!_isRunning)
            return;

        _duration = TimeSpan.Zero;
        _isRunning = false;
        btnStop.Enabled = _isRunning;
        btnRun.Enabled = !_isRunning;

        _driver.Quit();
        _driver.Dispose();

        dgvWindows.Rows.Clear();
    }

    async Task Start()
    {
        _isRunning = true;
        btnStop.Enabled = _isRunning;
        btnRun.Enabled = !_isRunning;

        var config = new ChromeConfig();

        var manager = new DriverManager();
        manager.SetUpDriver(config);

        var options = new ChromeOptions();

        if (chkHeadless.Checked)
            options.AddArgument("--headless=new");

        if (chkMuteAudio.Checked)
            options.AddArgument("--mute-audio");

        if (chkPreventDetection.Checked)
        {
            options.AddArgument("--incognito");
            options.AddArgument("disable-infobars");
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalChromeOption("useAutomationExtension", false);
        }

        var service = ChromeDriverService.CreateDefaultService();
        service.HideCommandPromptWindow = true;

        _driver = new ChromeDriver(service, options);
        _driver
            .Manage()
            .Window
            .Size = new Size(1024, 768);

        var isMuted = chkMuteAudio.Checked;
        var randomDelay = chkDelay.Checked;
        var videoKey = txtVideoKey.Text;
        var instances = updnInstances.Value;
        for (var count = 1; count <= instances; count++)
        {
            if (!_isRunning)
                return;

            await Task.Run(async () =>
            {
                OpenVideo(videoKey, isMuted);

                if (randomDelay)
                    await Task.Delay(_random.Next(5, 10) * 1000);
            });
        }

        var replayCheckInSeconds = (int)updnReplay.Value * 1000 * 60;
        if (replayCheckInSeconds == 0)
            return;

        // video status update task
        await Task.Run(() =>
        {
            if (!_isRunning)
                return;

            dgvWindows.BeginInvoke(() =>
            {
                foreach (DataGridViewRow row in dgvWindows.Rows)
                {
                    var handle = row.Cells[0].Value.ToString();

                    _driver
                        .SwitchTo()
                        .Window(handle);

                    var btnPlay = GetElement(XPATH_PLAY);
                    btnPlay?.Click();

                    row.Cells[2].Value = "Playing";
                }
            });

            Task.Delay(replayCheckInSeconds);
        });
    }

    private void FrmMain_FormClosing(object sender, FormClosingEventArgs e) => Stop();

    private async void btnRun_Click(object sender, EventArgs e) => await Start();

    private void btnStop_Click(object sender, EventArgs e) => Stop();
}
