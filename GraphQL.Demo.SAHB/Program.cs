using System;
using System.Threading.Tasks;
using SAHB.GraphQLClient.Exceptions;
using Newtonsoft.Json;

namespace GraphQL.Demo.SAHB {

    class MainClass {

        static GraphQLClient client = GraphQLClient.Default();

        public async static Task Main(string[] args) {
            Console.WriteLine("Hello World!");

            //await MutateDemo();

            //await MyDemo();

            //await Posts();

            await Lists();
        }

        // demo query
        async static Task QueryDemo() {
            try {
                var data = await client.Query<GL.Users>();
                Console.WriteLine(data.users?[0].username);
            }
            catch(GraphQLErrorException err) {
                Console.WriteLine("GraphQLError:" + err.Message);
            }
            catch(Exception err) {
                Console.WriteLine("AppRequestError:" + err.Message);
            }
        }

        // demo mutation
        async static Task MutateDemo() {
            var data = await client.AutoLogin(clientId: "1");
            Console.WriteLine("user.id: " +  data.autoLogin.user.id);
            Console.WriteLine("user.username: " + data.autoLogin.user.username);
            Console.WriteLine("user.token: " + data.autoLogin.jwt);
        }

        // demo with token
        async static Task MyDemo() {
            var data1 = await client.AutoLogin(clientId: "1");
            var data2 = await client.My(data1.autoLogin.jwt);
            Console.WriteLine(data2.my.username);
        }

        // posts request demo
        async static Task Posts() {
            //var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MSwiaWF0IjoxNjI4NTEwNjE0LCJleHAiOjE2NjAxMzMwMTR9.ZpDe3M3jFkw2x9mqEwCsl1YTSD5AAUHlhTFDbYfIC6c";
            var data1 = await client.AutoLogin(clientId: "1");
            var data2 = await client.Posts(data1.autoLogin.jwt);
            Console.WriteLine(JsonConvert.SerializeObject(data2.posts, Formatting.Indented));
        }

        // lists request demo
        async static Task Lists() {
            //var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MSwiaWF0IjoxNjI4NTEwNjE0LCJleHAiOjE2NjAxMzMwMTR9.ZpDe3M3jFkw2x9mqEwCsl1YTSD5AAUHlhTFDbYfIC6c";
            var data1 = await client.AutoLogin(clientId: "1");
            var data2 = await client.Lists<GL.QEvents>(data1.autoLogin.jwt);
            Console.WriteLine(JsonConvert.SerializeObject(data2.events, Formatting.Indented));
        }
    }
}
