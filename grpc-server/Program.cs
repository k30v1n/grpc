using grpc_server.Services;
using grpc_server.Services.v1;

var builder = WebApplication.CreateBuilder(args);

// Kestrel options https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-6.0
// builder.WebHost

builder.Services.AddControllers();
builder.Services.AddGrpc();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    endpoints.MapGrpcService<GreeterService>();
    endpoints.MapGrpcService<StreamerService>();
});

app.Run();