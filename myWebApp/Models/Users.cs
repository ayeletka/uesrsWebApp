using System.Collections.Generic;

namespace myWebApp.Models
{
    public class Users
    {
        private List<string> listOfUsers;
        public string input;
        public void setUsersList(string user)
        {
            listOfUsers.Add(user);
        }
        public List<string> getUsersList()
        {
            return this.listOfUsers;
        }

        public void handleInputChange()
        {
            listOfUsers.Add(this.input);
        }
    }
}