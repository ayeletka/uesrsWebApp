using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace myWebApp.Models
{
    public class Users
    {
        private List<UserData> _listOfUsers;
        private  readonly string _userDataFilePath = $@"{System.IO.Path.GetTempPath()}\usersData.json";
       
        public Users()
        {
            LoadUserDataFromJson();
        }

        private void LoadUserDataFromJson()
        {
            if (File.Exists(_userDataFilePath))
            {
                var jsonFile = File.ReadAllText(_userDataFilePath);
                _listOfUsers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserData>>(jsonFile);
            }
            else
            {
                _listOfUsers = new List<UserData>();
            }
        }

        public void AddUserName(string user)
        {
            //TODO: support multi save lock
            //UserSer.Instance.Add(user);
            _listOfUsers.Add(new UserData { Name = user });
            var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(_listOfUsers);
            File.WriteAllText(_userDataFilePath, jsonStr);
        }
        public List<UserData> getUsersList()
        {
            return _listOfUsers;
        }

    }
}