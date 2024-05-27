using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using ApiPeliculasAWS.Models;
using ApiPeliculasAWS.Repositories;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ApiPeliculasAWS;

public class Functions
{
    /// <summary>
    /// Default constructor that Lambda will invoke.
    /// </summary>
    /// 

    private PeliculasRepository repo;
    public Functions(PeliculasRepository repo)
    {
        this.repo = repo;
    }


    /// <summary>
    /// A Lambda function to respond to HTTP Get methods from API Gateway
    /// </summary>
    /// <remarks>
    /// This uses the <see href="https://github.com/aws/aws-lambda-dotnet/blob/master/Libraries/src/Amazon.Lambda.Annotations/README.md">Lambda Annotations</see> 
    /// programming model to bridge the gap between the Lambda programming model and a more idiomatic .NET model.
    /// 
    /// This automatically handles reading parameters from an APIGatewayProxyRequest
    /// as well as syncing the function definitions to serverless.template each time you build.
    /// 
    /// If you do not wish to use this model and need to manipulate the API Gateway 
    /// objects directly, see the accompanying Readme.md for instructions.
    /// </remarks>
    /// <param name="context">Information about the invocation, function, and execution environment</param>
    /// <returns>The response as an implicit <see cref="APIGatewayProxyResponse"/></returns>
    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/")]
    public async Task<IHttpResult> Get(ILambdaContext context)
    {
        context.Logger.LogInformation("Handling the 'Get' Request");

        List<Pelismysql> pelis = await this.repo.GetPeliculas();
        // string json= JsonConvert.SerializeObject(personajes);
        return HttpResults.Ok(pelis);
    }


    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/pelisactor/{actores}")]
    public async Task<IHttpResult> FindPelisActor(string actores, ILambdaContext context)
    {
        context.Logger.LogInformation("Handling the 'Get' Request");

        List<Pelismysql> pelis = await this.repo.GetPeliculasActores(actores);
        // string json= JsonConvert.SerializeObject(personajes);
        return HttpResults.Ok(pelis);
    }

}
