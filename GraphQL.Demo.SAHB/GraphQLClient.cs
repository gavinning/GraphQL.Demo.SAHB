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

        public Task<T> Mutate<T>() where T : class {
            return client.Mutate<T>(baseURL);
        }

        public Task<T> Mutate<T>(GraphQLQueryArgument args) where T : class {
            return client.Mutate<T>(baseURL, arguments: args);
        }

        public Task<GL.AutoLogin> AutoLogin(string clientId) {
            var input = new GL.AutoLoginInput(clientId);
            return Mutate<GL.AutoLogin>(new GraphQLQueryArgument("input", input));
        }
    }
}
