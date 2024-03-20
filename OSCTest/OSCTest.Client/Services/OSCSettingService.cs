using OSCTest.Client.Models;
using System.Diagnostics;
using System.Text.Json;

namespace OSCTest.Client.Services
{
    public class OSCSettingService : IOSCSettingService
    {
        private Models.PageSettings? _pageSettings = null;
        private HttpClient _httpClient;

        public OSCSettingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Models.PageSettings> GetSettings()
        {
            if (_pageSettings is null)
            {
                var oscData = await _httpClient.GetStringAsync("osc_settings.json");

                if (oscData is null)
                    throw new Exception("cant find settings");

                _pageSettings = JsonSerializer.Deserialize<Models.PageSettings>(oscData);

                if (_pageSettings is null || _pageSettings.Name is null || _pageSettings.Controls is null)
                    throw new Exception("cant load settings");
            }

            return _pageSettings;
        }


    }
}
