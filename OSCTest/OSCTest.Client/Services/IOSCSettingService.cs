using OSCTest.Client.Models;

namespace OSCTest.Client.Services
{
    public interface IOSCSettingService
    {
        Task<PageSettings> GetSettings();
    }
}