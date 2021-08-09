using System.Threading.Tasks;
using SAHB.GraphQLClient;
using SAHB.GraphQLClient.QueryGenerator;
using Newtonsoft.Json.Linq;

namespace GraphQL.Demo.SAHB {
    public class GraphQLClient {

        readonly string baseURL = "http://localhost:9902/graphql";
        readonly IGraphQLHttpClient client = GraphQLHttpClient.Default();

        public static GraphQLClient Default() {
            return new GraphQLClient();
        }

        public Task<T> Query<T>(string? token = null, params GraphQLQueryArgument[] args) where T : class {
            return client.CreateQuery<T>(baseURL, authorizationToken: token, arguments: args).Execute();
        }

        public Task<T> Mutate<T>(string? token = null, params GraphQLQueryArgument[] args) where T : class {
            return client.CreateMutation<T>(baseURL, authorizationToken: token, arguments: args).Execute();
        }

        public Task<GL.AutoLogin> AutoLogin(string clientId) {
            var input = new GL.AutoLoginInput(clientId);
            return Mutate<GL.AutoLogin>(args: new GraphQLQueryArgument("input", input));
        }

        public Task<GL.QMy> My(string token) {
            return Query<GL.QMy>(token);
        }

        public Task<GL.QPosts> Posts(string token, int start = 0, int limit = 10, string sort = "id:desc", JObject? where = null) {
            return Query<GL.QPosts>(
                token,
                new GraphQLQueryArgument("sort", sort),
                new GraphQLQueryArgument("start", start),
                new GraphQLQueryArgument("limit", limit),
                new GraphQLQueryArgument("where", where ?? new JObject())
            );
        }
    }
}
