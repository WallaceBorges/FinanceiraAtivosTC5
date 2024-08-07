using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ApiUsuarios.Services.Extensions
{
    /// <summary>
    /// Classe de extensão para adicionarmos no projeto as configurações
    /// de geraçao da documentação do Swagger (OpenAPI)
    /// </summary>
    public static class SwaggerDocExtension
    {
        /// <summary>
        /// Personalizando o conteudo da documentação gerada pelo Swagger
        /// </summary>
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API para controle de ativos financeiros",
                    Description = "API REST desenvolvida em AspNet 8 com EntityFramework para o Tech Challenge 5",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "FIAP Pós Tech - Tech Challenge 5",
                        Email = "wallace.c.borges@hotmail.com",
                        Url = new Uri("https://www.fiap.com.br/")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        /// <summary>
        /// Configurando a execução da página de documentação
        /// </summary>
        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger(); //abrindo a página da documentação
            //gerando o link utilizado para importar a documentação api no POSTMAN (api-docs)
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiAtivosTC5.Presentation");
            });

            return app;
        }
    }
}
