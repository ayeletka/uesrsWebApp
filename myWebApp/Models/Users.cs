using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace myWebApp.Models
{
    public class Users
    {
        private List<UserData> listOfUsers;
        public string input;
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
                listOfUsers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserData>>(jsonFile);
            }
            else
            {
                listOfUsers = new List<UserData>();
            }
        }

        public void setUsersList(string user)
        {
            //TODO: support multi save lock
            //UserSer.Instance.Add(user);

            listOfUsers.Add(new UserData { Name = user });
            var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(listOfUsers);
            File.WriteAllText(_userDataFilePath, jsonStr);

        }
        public List<UserData> getUsersList()
        {
            return listOfUsers;
        }

    }
}