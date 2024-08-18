using AtivosTC5.Application.Interfaces;
using AtivosTC5.Application.Services;
using AtivosTC5.Application.UseCases.Ativos;
using AtivosTC5.Application.UseCases.Usuarios;
using AtivosTC5.Domain.Interfaces;
using AtivosTC5.Domain.Interfaces.Repositories;
using AtivosTC5.Domain.Interfaces.Services;
using AtivosTC5.Domain.Interfaces.UseCases.Ativo;
using AtivosTC5.Domain.Interfaces.UseCases.Usuarios;
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
            services.AddTransient<IPortfolioRepository, PortfolioRepository>();
            services.AddTransient<ITransacaoRepository, TransacaoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IPortfolioAtivoRepository, PortfolioAtivoRepository>();

            services.AddTransient<IAtivoDomainService, AtivoDomainService>();
            services.AddTransient<IAtivoTipoDomainService, AtivoTipoDomainService>();
            services.AddTransient<IPortfolioDomainService, PortfolioDomainService>();
            services.AddTransient<ITransacaoDomainService, TransacaoDomainService>();
            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();

            services.AddTransient<IAtivoAppService, AtivoAppService>();
            services.AddTransient<IAtivoTipoAppService, AtivoTipoAppService>();
            services.AddTransient<IPortfolioAppService, PortfolioAppService>();
            services.AddTransient<ITransacaoAppService, TransacaoAppService>();
            services.AddTransient<IUsuarioAppService, UsuarioAppService>();

            services.AddTransient<IEfetuaTransacaoCompra, EfetuaTransacaoCompra>();
            services.AddTransient<IEfetuaTransacaoVenda, EfetuaTransacaoVenda>();
            services.AddTransient<IRetornaListaTransacao, RetornaListaTransacao>();
            services.AddTransient<IRetornaPortfolio, RetornaPortfolio>();
            services.AddTransient<IRetornaUsuario, RetornaUsuario>();

            #endregion

            return services;
        }
    }
}
