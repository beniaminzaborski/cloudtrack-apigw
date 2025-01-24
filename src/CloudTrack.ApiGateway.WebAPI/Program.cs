using CloudTrack.ApiGateway.WebAPI;

const string serviceName = "CloudTrack-ApiGateway";
const string serviceVersion = "1.0.0";

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

services
    .AddControllers();

services
    .AddObservability(config, serviceName, serviceVersion)
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

// Register the reverse proxy routes
app.MapReverseProxy();

app.Run();
