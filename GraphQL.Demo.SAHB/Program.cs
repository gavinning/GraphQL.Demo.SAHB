using System;
using System.Threading.Tasks;
using SAHB.GraphQLClient.Exceptions;
using SAHB.GraphQLClient.QueryGenerator;

namespace GraphQL.Demo.SAHB {

    class MainClass {

        static GraphQLClient client = GraphQLClient.Default();

        public async static Task Main(string[] args) {
            Console.WriteLine("Hello World!");

            await MutateDemo();
        }

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

        async static Task MutateDemo() {
            var data = await client.AutoLogin(clientId: "1");
            Console.WriteLine("user.id: " +  data.autoLogin.user.id);
            Console.WriteLine("user.username: " + data.autoLogin.user.username);
            Console.WriteLine("user.token: " + data.autoLogin.jwt);
        }
    }
}
