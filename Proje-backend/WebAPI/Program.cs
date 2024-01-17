using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.IOC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Extensions;
using Core.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 

builder.Services.AddCors();





builder.Services.AddControllers();



var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
 builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//ServiceTool.Create(builder.Services);

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CORS policy

//builder.Services.AddCors(p=> p.AddPolicy("corspolicy",build=>
//{
//    build.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
//}));





//builder.Services.AddSingleton<IUrunService,UrunManager>();
//builder.Services.AddSingleton<IUrunDal,EfUrunDal>();


//
builder.Host.UseServiceProviderFactory(services => new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder => { builder.RegisterModule(new AutofacBusinessModule()); });

//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();
app.UseCors(builder=>builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

//app.UseCors("corspolicy");

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();
