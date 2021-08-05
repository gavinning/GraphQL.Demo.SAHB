﻿using System;
using System.Threading.Tasks;

namespace GraphQL.Demo.SAHB {
    class MainClass {
        public async static Task Main(string[] args) {
            Console.WriteLine("Hello World!");

            GraphQLClient cc = GraphQLClient.Default();

            var data = await cc.Query<UsersType>();

            Console.WriteLine(data.users[0].username);
        }
    }
}
