using Contato.Excluir;
using Contato.Excluir.Aplicacao;
using Contato.Excluir.Repositorios.ContatosRepositorios;
using Contato.Excluir.Repositorios.Context;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddSingleton<IDbConection, DbConection>();
builder.Services.AddSingleton<IContatosComandosRepositorio, ContatosComandosRepositorio>();
builder.Services.AddSingleton<IContatoComandos, ContatoComandos>();

var host = builder.Build();
host.Run();
