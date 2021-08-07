using System.Threading.Tasks;
using SAHB.GraphQLClient;
using SAHB.GraphQLClient.Extentions;
using SAHB.GraphQLClient.QueryGenerator;

namespace GraphQL.Demo.SAHB {
    public class GraphQLClient {

        readonly string baseURL = "http://localhost:9902/graphql";
        readonly IGraphQLHttpClient client = GraphQLHttpClient.Default();

        public static GraphQLClient Default() {
            return new GraphQLClient();
        }

        public Task<T> Query<T>() where T : class {
            return client.Query<T>(baseURL);
        }

        public Task<T> Query<T>(GraphQLQueryArgument args) where T : class {
            return client.Query<T>(baseURL, arguments: args);
        }

        public Task<T> Query<T>(string token) where T : class {
            return client.CreateQuery<T>(baseURL, authorizationToken: token).Execute();
        }

        public Task<T> Query<T>(string token, GraphQLQueryArgument args) where T : class {
            return client.CreateQuery<T>(baseURL, authorizationToken: token, arguments: args).Execute();
        }

        public Task<T> Mutate<T>() where T : class {
            return client.Mutate<T>(baseURL);
        }

        public Task<T> Mutate<T>(GraphQLQueryArgument args) where T : class {
            return client.Mutate<T>(baseURL, arguments: args);
        }

        public Task<T> Mutate<T>(string token) where T : class {
            return client.CreateMutation<T>(baseURL, authorizationToken: token).Execute();
        }

        public Task<T> Mutate<T>(string token, GraphQLQueryArgument args) where T : class {
            return client.CreateMutation<T>(baseURL, authorizationToken: token, arguments: args).Execute();
        }

        public Task<GL.QueryME> ME(string token) {
            return Query<GL.QueryME>(token);
        }

        public Task<GL.AutoLogin> AutoLogin(string clientId) {
            var input = new GL.AutoLoginInput(clientId);
            return Mutate<GL.AutoLogin>(new GraphQLQueryArgument("input", input));
        }
    }
}
