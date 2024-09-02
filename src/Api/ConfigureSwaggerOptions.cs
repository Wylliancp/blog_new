using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api
{
    public class ConfigureSwaggerOptions
        : IConfigureNamedOptions<SwaggerGenOptions>
        {

            public void Configure(SwaggerGenOptions options)
            {
            // add swagger document for every API version discovered

            options.SwaggerDoc(
                "v1",
                CreateVersionInfo());
                
            }

            public void Configure(string name, SwaggerGenOptions options)
            {
                Configure(options);
            }

            private OpenApiInfo CreateVersionInfo(
                    )
            {
                var info = new OpenApiInfo()
                {
                    Title = "API",
                };
                return info;
            }
        }
    }

