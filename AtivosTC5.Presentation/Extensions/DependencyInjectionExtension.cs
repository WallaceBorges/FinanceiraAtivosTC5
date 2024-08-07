using AtivosTC5.Application.Interfaces;
using AtivosTC5.Application.Services;
using AtivosTC5.Domain.Interfaces;
using AtivosTC5.Domain.Interfaces.Repositories;
using AtivosTC5.Domain.Interfaces.Services;
using AtivosTC5.Domain.Services;
using AtivosTC5.Infra.Data.Repositories;

namespace AtivosTC5.Services.Extensions
{
    /// <summary>
    /// Classe de extensão para configurarmos as injeções
    /// de dependência feitas no projeto
    /// </summary>
    public static class DependencyInjectionExtension
    {
        /// <summary>
        /// Método para configurarmos as injeções de dependência
        /// que serão adicionadas no projeto AspNet
        /// </summary>
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {

            #region Configurando as injeção de dependência do projeto

            services.AddTransient<IAtivoRepository, AtivoRepository>();
            services.AddTransient<IAtivoTipoRepository, AtivoTipoRepository>();
            services.AddTransient<IPortifolioRepository, PortfolioRepository>();
            services.AddTransient<ITransacaoRepository, TransacaoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddTransient<IAtivoDomainService, AtivoDomainService>();
            services.AddTransient<IAtivoTipoDomainService, AtivoTipoDomainService>();
            services.AddTransient<IPortifolioDomainService, PortifolioDomainService>();
            services.AddTransient<ITransacaoDomainService, TransacaoDomainService>();
            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();

            #endregion

            return services;
        }
    }
}
