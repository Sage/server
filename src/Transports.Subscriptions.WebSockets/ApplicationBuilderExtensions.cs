using GraphQL.Server.Transports.WebSockets;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace GraphQL.Server
{
    public static class GraphQLWebSocketsExtensions
    {
        /// <summary>
        /// Add GraphQL web sockets middleware to the request pipeline
        /// </summary>
        /// <typeparam name="TSchema">The implementation of <see cref="ISchema"/> to use</typeparam>
        /// <param name="builder"></param>
        /// <param name="path">The path to the GraphQL web socket endpoint which defaults to '/graphql'</param>
        /// <returns></returns>
        public static IApplicationBuilder UseGraphQLWebSockets<TSchema>(
            this IApplicationBuilder builder,
            string path = "/graphql")
            where TSchema : ISchema
        {
            return builder.UseGraphQLWebSockets<TSchema>(new PathString(path));
        }

        /// <summary>
        /// Add GraphQL web sockets middleware to the request pipeline
        /// </summary>
        /// <typeparam name="TSchema">The implementation of <see cref="ISchema"/> to use</typeparam>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseGraphQLWebSockets<TSchema>(
            this IApplicationBuilder builder,
            PathString path)
            where TSchema : ISchema
        {
            return builder.UseMiddleware<GraphQLWebSocketsMiddleware<TSchema>>(path);
        }
    }
}