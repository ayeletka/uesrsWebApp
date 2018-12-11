namespace myWebApp.Models
{
    using myWebApp.Controllers;
    using Microsoft.ApplicationInsights;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using System.Threading.Tasks;

    public class LocalFileSystemUsersRepository : IUsersRepository
    {
        private readonly string _userDataFilePath;
        private readonly TelemetryClient _telemetryClient;

        public LocalFileSystemUsersRepository(TelemetryClient telemetryClient)
        {
            _userDataFilePath = $@"{System.IO.Path.GetTempPath()}\usersData.json";
            _telemetryClient = telemetryClient;
        }

        public async Task AddUser(User user)
        {
            // Read from file
            _telemetryClient.TrackTrace("Loading date from json");
            List<string> users = await GetUsers();

            // Add
            users.Add(user.Name);

            // Save to file
            var jsonStr = JsonConvert.SerializeObject(users);
            File.WriteAllText(_userDataFilePath, jsonStr);
        }

        public async Task<List<string>> GetUsers()
        {
            if (File.Exists(_userDataFilePath))
            {
                _telemetryClient.TrackTrace("Json file already exist");
                var jsonFile = File.ReadAllText(_userDataFilePath);
                return JsonConvert.DeserializeObject<List<string>>(jsonFile);
            }
            
            _telemetryClient.TrackTrace("Json file wasn't exist and will be created");
            return new List<string>();
        }
    }
}