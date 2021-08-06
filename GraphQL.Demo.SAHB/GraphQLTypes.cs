using SAHB.GraphQLClient.FieldBuilder.Attributes;

namespace GL {

    public class User {
        public int id { get; set; }
        public string username { get; set; }
        public Role role { get; set; }
    }

    public class Users {
        public User[] users { get; set; }
    }

    public class Role {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class AutoLoginPayload {
        public string jwt { get; set; }
        public User user { get; set; }
    }

    public class AutoLoginInput {
        public string clientId { get; set; }

        public AutoLoginInput(string clientId) {
            this.clientId = clientId;
        }
    }

    public class AutoLogin {
        [GraphQLArgumentsAttribute("input", "autoLoginInput!", "input")]
        public AutoLoginPayload autoLogin { get; set; }
    }
}
