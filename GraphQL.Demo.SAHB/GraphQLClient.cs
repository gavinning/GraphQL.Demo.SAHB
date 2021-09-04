using System.Threading.Tasks;
using SAHB.GraphQLClient;
using SAHB.GraphQLClient.QueryGenerator;
using Newtonsoft.Json.Linq;

namespace GraphQL.Demo.SAHB {
    public class GraphQLClient {

        //readonly string baseURL = "http://localhost:9902/graphql";
        readonly string baseURL = "https://draw.dayuxinyong.com/graphql";
        readonly IGraphQLHttpClient client = GraphQLHttpClient.Default();

        public static GraphQLClient Default() {
            return new GraphQLClient();
        }

        // 通用Query请求
        public Task<T> Query<T>(string? token = null, params GraphQLQueryArgument[] args) where T : class {
            return client.CreateQuery<T>(baseURL, authorizationToken: token, arguments: args).Execute();
        }

        // 通用Mutation请求
        public Task<T> Mutate<T>(string? token = null, params GraphQLQueryArgument[] args) where T : class {
            return client.CreateMutation<T>(baseURL, authorizationToken: token, arguments: args).Execute();
        }

        // 请求集合数组 多个参数
        public Task<T> Lists<T>(string token, int start = 0, int limit = 10, string sort = "id:desc", JObject? where = null) where T : class {
            return Query<T>(
                token,
                new GraphQLQueryArgument("sort", sort),
                new GraphQLQueryArgument("start", start),
                new GraphQLQueryArgument("limit", limit),
                new GraphQLQueryArgument("where", where ?? new JObject())
            );
        }

        // 请求集合数组demo
        // 请求文章列表demo
        public Task<GL.QPosts> Posts(string token, int start = 0, int limit = 10, string sort = "id:desc", JObject? where = null) {
            return Lists<GL.QPosts>(token, start, limit, sort, where);
        }

        // 不带参数demo
        public Task<GL.QMy> My(string token) {
            return Query<GL.QMy>(token);
        }

        // 携带参数demo
        public Task<GL.AutoLogin> AutoLogin(string clientId) {
            var input = new GL.AutoLoginInput(clientId);
            return Mutate<GL.AutoLogin>(args: new GraphQLQueryArgument("input", input));
        }
    }
}
