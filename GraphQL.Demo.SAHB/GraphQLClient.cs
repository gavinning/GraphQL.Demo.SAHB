using System;
using System.Threading.Tasks;
using SAHB.GraphQLClient;
using SAHB.GraphQLClient.Exceptions;
using SAHB.GraphQLClient.Extentions;
using SAHB.GraphQLClient.QueryGenerator;

namespace GraphQL.Demo.SAHB
{
    public class GraphQLClient {

        readonly string baseURL = "http://localhost:9902/graphql";
        readonly IGraphQLHttpClient client = GraphQLHttpClient.Default();

        public static GraphQLClient Default() {
            return new GraphQLClient();
        }

        public async Task<T> Query<T> () where T : class {
            return await client.Query<T>(baseURL);
        }

        public async Task<T> Query<T>(GraphQLQueryArgument args) where T : class {
            return await client.Query<T>(baseURL, arguments: args);
        }
    }

}