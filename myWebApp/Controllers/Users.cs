using Microsoft.ApplicationInsights;
using System.Collections.Generic;
using System.IO;

namespace myWebApp.Models
{
    public class Users
    {
        private List<User> _listOfUsers;
        private  readonly string _userDataFilePath = $@"{System.IO.Path.GetTempPath()}\usersData.json";
        private TelemetryClient _telemetry = new TelemetryClient();

        public Users()
        {
            _telemetry.TrackTrace("Loading date from json");
            LoadUserDataFromJson();
        }

        private void LoadUserDataFromJson()
        {
            if (File.Exists(_userDataFilePath))
            {
                _telemetry.TrackTrace("Json file already exist");
                var jsonFile = File.ReadAllText(_userDataFilePath);
                _listOfUsers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(jsonFile);
            }
            else
            {
                _telemetry.TrackTrace("Json file wasn't exist and will be created");
                _listOfUsers = new List<User>();
            }
        }

        public void AddUserName(string user)
        {
            //TODO: support multi save lock
            //UserSer.Instance.Add(user);
            _listOfUsers.Add(new User { Name = user });
            var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(_listOfUsers);
            File.WriteAllText(_userDataFilePath, jsonStr);
   
        }

        public List<User> GetUsersList()
        {
            return _listOfUsers;
        }

    }
}