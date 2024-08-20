using ChartsServer.Hubs;
using ChartsServer.Models;
using ChartsServer.Subscription;
using ChartsServer.Subscription.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowCredentials().
                                                                              AllowAnyHeader().
                                                                              AllowAnyMethod().
                                                                              SetIsOriginAllowed(x => true)));
builder.Services.AddSignalR();
builder.Services.AddSingleton<DatabaseSubscription<Satislar>>();
builder.Services.AddSingleton<DatabaseSubscription<Personeller>>();

var app = builder.Build();

app.UseCors();
app.UseDatabaseSubscription<DatabaseSubscription<Satislar>>("Satislar");
app.UseDatabaseSubscription<DatabaseSubscription<Personeller>>("Personeller");

app.MapHub<SatisHub>("/satishub");

app.Run();

