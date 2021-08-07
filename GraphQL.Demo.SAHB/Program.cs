using System;
using System.Threading.Tasks;
using SAHB.GraphQLClient.Exceptions;

namespace GraphQL.Demo.SAHB {

    class MainClass {

        static GraphQLClient client = GraphQLClient.Default();

        public async static Task Main(string[] args) {
            Console.WriteLine("Hello World!");

            //await MutateDemo();

            await MEDemo();
        }

        // demo query
        async static Task QueryDemo() {
            try {
                var data = await client.Query<GL.Users>();
                Console.WriteLine(data.users[0].username);
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
        async static Task MEDemo() {
            var data1 = await client.AutoLogin(clientId: "1");
            var data2 = await client.ME(data1.autoLogin.jwt);
            Console.WriteLine(data2.me.username);
        }
    }
}
