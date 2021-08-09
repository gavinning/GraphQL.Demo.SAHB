using SAHB.GraphQLClient.FieldBuilder.Attributes;


// Model
namespace GL {

    public class User: Base {
        public string username { get; set; }
        public string clientId { get; set; }
        public bool isPermanentVip { get; set; } = false;
        public string? tel { get; set; }
        public string? vipExpiredAt { get; set; }

        public Role? role { get; set; }
        public Upload? avatar { get; set; }

        public User(string username, string clientId) {
            this.username = username;
            this.clientId = clientId;
        }
    }

    public class Users {
        public User[]? users { get; set; }
    }

    public class Role: Base {
        public string name { get; set; }
        public string type { get; set; }
        public string description { get; set; }

        public Role(string name, string type, string description) {
            this.name = name;
            this.type = type;
            this.description = description;
        }
    }

    public class Upload: Base {
        public string name { get; set; }
        public string? ext { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public float size { get; set; }
        public string url { get; set; }
        public object? formats { get; set; }

        public Upload(string name, string url) {
            this.name = name;
            this.url = url;
        }
    }

    public class Goods : Base {
        public string name { get; set; }
        public string type { get; set; }
        public float price { get; set; }
        public float originalPrice { get; set; }
        public bool owned { get; set; } = false;
        public int effectiveDay { get; set; }
        public int status { get; set; }
        public string? description { get; set; }

        public Goods(string name, string type) {
            this.name = name;
            this.type = type;
        }
    }

    public class Trade : Base {
        public string tradeid { get; set; }
        public User? user { get; set; }
        public Goods? goods { get; set; }
        public int status { get; set; }
        public string? paidAt { get; set; }
        public string? created_at { get; set; }
        public string? updated_at { get; set; }

        public Trade(string tradeid) {
            this.tradeid = tradeid;
        }
    }

    public class Post : Base {
        public string? title { get; set; }
        public string? content { get; set; }
        public string permission { get; set; } = "public";
        public User? user { get; set; }
        public Goods? goods { get; set; }
        public Upload? image { get; set; }
        public string? created_at { get; set; }
        public string? updated_at { get; set; }

        public Post(User user, Goods goods, Upload image) {
            this.user = user;
            this.goods = goods;
            this.image = image;
        }
    }

    public class Like : Base {
        public User user { get; set; }
        public Post post { get; set; }

        public Like(User user, Post post) {
            this.user = user;
            this.post = post;
        }
    }

    public class Event: Base {
        public string? sid { get; set; }
        public string? name { get; set; }
        public string? type { get; set; }
        public string action { get; set; }
        public string? message { get; set; }
        public string? key { get; set; }
        public string? value { get; set; }
        public string? from { get; set; }
        public string? source { get; set; }
        public string? client { get; set; }
        public string? ip { get; set; }
        public string? status { get; set; }
        public string? content { get; set; }
        public string? statck { get; set; }
        public string? created_at { get; set; }
        public string? updated_at { get; set; }

        public Event(string action) {
            this.action = action;
        }
    }
}

// Query
namespace GL {

    public class QMy {
        public User my { get; set; }

        public QMy(User my) {
            this.my = my;
        }
    }

    public class QPost {
        [GraphQLArgumentsAttribute("id", "ID!", "id")]
        public Post post { get; set; }

        public QPost(Post post) {
            this.post = post;
        }
    }

    public class QPosts {
        [GraphQLArgumentsAttribute("start", "Int", "start")]
        [GraphQLArgumentsAttribute("limit", "Int", "limit")]
        [GraphQLArgumentsAttribute("sort", "String", "sort")]
        [GraphQLArgumentsAttribute("where", "JSON", "where")]
        public Post[] posts { get; set; }

        public QPosts(Post[] posts) {
            this.posts = posts;
        }
    }
}

// Mutation
namespace GL {

    public class AutoLogin {
        [GraphQLArgumentsAttribute("input", "autoLoginInput!", "input")]
        public AutoLoginPayload autoLogin { get; set; }

        public AutoLogin(AutoLoginPayload autoLogin) {
            this.autoLogin = autoLogin;
        }
    }
}

// Public
namespace GL {

    public class Base {
        public int id { get; set; }
    }

    public class AutoLoginPayload {
        public string jwt { get; set; }
        public User user { get; set; }

        public AutoLoginPayload(string jwt, User user) {
            this.jwt = jwt;
            this.user = user;
        }
    }

    public class AutoLoginInput {
        public string clientId { get; set; }

        public AutoLoginInput(string clientId) {
            this.clientId = clientId;
        }
    }
}
