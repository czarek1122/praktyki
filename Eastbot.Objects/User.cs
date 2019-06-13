namespace Eastbot.Objects
{
    public class User
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "login_id")]
        public string Login { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public User(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }

        public User() { }

        public User(string Login, string Id, string password)
        {
            this.Login = Login;
            this.Id = Id;
            this.Password = "";
        }
    }
}
