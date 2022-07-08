using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Biosite.Analysis.Gateway.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Biosite Gateway API",
                    Description = "API de análise biológica da Plataforma Biosite <br/> <strong>Base do ambiente de teste</strong>",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Biosite Health",
                        Email = "api@Biosite.com",
                        Url = new Uri("http://Biosite.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Biosite License",
                        Url = new Uri("http://Biosite.com")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

                #region Settings Authentication Use

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }});
                
                #endregion

            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            }
            else
            {
                app.UseSwaggerUI(options =>
                {
                    options.RoutePrefix = string.Empty;
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            }

            return app;
        }

    }
}
