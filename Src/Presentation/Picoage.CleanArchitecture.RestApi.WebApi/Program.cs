using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Picoage.CleanArchitecture.RestApi.Application.AppSettings;
using Picoage.CleanArchitecture.RestApi.WebApi.ServiceCollections;
using Picoage.CleanArchitecture.RestApi.Application.Extensions;
using Picoage.CleanArchitecture.RestApi.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {


        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.RegisterApplicationInstances();

        builder.Services.RegisterPersistenceInstances(builder.Configuration);

        builder.Services.AddHealthChecks();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        builder.Services.AddControllers();

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

        // Register the Swagger generator, defining 1 or more Swagger documents
        BuildSwaggerDocumentation(builder);

        // configure jwt authentication
        BuildTokenAuthentication(builder);


        var app = builder.Build();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseSwagger();

        app.MapHealthChecks("/healthz");

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

        });

        app.MapControllers();
        app.Run();
    }

    private static void BuildTokenAuthentication(WebApplicationBuilder builder)
    {
        AuthenticationSettings authenticationSettings = builder.Services.GetAuthenticationSettings(builder.Configuration);


        var key = Encoding.ASCII.GetBytes(authenticationSettings.Key);
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }

    private static void BuildSwaggerDocumentation(WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });


            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                Scheme = "bearer",
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                        {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "bearer",
                            Name = "Bearer",
                        },
                        new List<string>()
                    }
                         });

            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
    }
}

