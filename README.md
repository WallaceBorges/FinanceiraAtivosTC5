<h1 align="center"> Sistemas de Investimentos - AtivosTC5  </h1>

<p align="center">
  <img src="http://img.shields.io/static/v1?label=TESTES&message=%3E100&color=GREEN&style=for-the-badge"/>
   <img src="http://img.shields.io/static/v1?label=STATUS&message=CONCLUIDO&color=GREEN&style=for-the-badge"/>
</p>

### Tópicos 

:small_blue_diamond: [Descrição do projeto](#descrição-do-projeto)

:small_blue_diamond: [Funcionalidades](#funcionalidades)

:small_blue_diamond: [Como clonar o projeto](#como-clonar-o-projeto)

:small_blue_diamond: [Como rodar o projeto](#como-rodar-o-projeto)

:small_blue_diamond: [Documentação](#documentação)

:small_blue_diamond: [Tecnologias](#tecnologias)

## Descrição do projeto 

<p align="justify">
  O sistema é uma plataforma de investimentos, onde o usuário poderá criar e acessar seus portfólio, ver os ativos disponíveis e realizar transações de compra e venda.
</p>

## Funcionalidades

:heavy_check_mark: O usuário poderá cadastrar/gerenciar seus portfólios.

:heavy_check_mark: O usuário poderá ver os ativos disponíveis.

:heavy_check_mark: O usuário poderá realizar transações de compra e venda de ativos.

:heavy_check_mark: O usuário poderá acessar as transações realizadas.

## Como clonar o projeto

No terminal, clone o projeto: 
```
git clone https://github.com/WallaceBorges/FinanceiraAtivosTC5.git
```

## Como rodar o projeto

No terminal, entre no diretório de Infra:
```
cd localDoProjeto\FinanceiraAtivosTC5\AtivosTC5.Infra
```

Dentro de Infra, executa o comando abaixo para atualizar o banco de dados:
```
dotnet ef database update
```

Show, agora com o banco atualizado, vamos rodar nossa aplicação.
Primeiro entre na pasta da api:
```
cd localDoProjeto\FinanceiraAtivosTC5\AtivosTC5.Presentation
```

Agora execute o comando abaixo para rodar aplicação:
```
dotnet run
```

Pronto, agora a aplicação esta rodando. Segue o link do swagger:
```
http://localhost:5012/swagger/index.html
```

## Documentação

Na documentação possui os critérios de aceite, os atores e os casos de uso do sistema.

Segue abaixo o link.

https://miro.com/app/board/uXjVKqBpXO8=/

Obs: Caso não consiga visualizar, favor solicitar acesso ao administrador

## Tecnologias

O projeto foi desenvolvido na versão .Net 8.0, com banco de dados SQL Server.

## Desenvolvedores/Contribuintes :arrow_forward:

| [<img src="https://avatars.githubusercontent.com/u/31574481?s=400&u=c256fa50a65feb93d2b537776c538304f1ba6efe&v=4" width=115><br><sub>Thiago Pereira</sub>](https://github.com/TSP17) |  [<img src="https://avatars.githubusercontent.com/u/17633740?v=4" width=115><br><sub>Gabriel Seles</sub>](https://github.com/SelesGabriel) |  [<img src="https://avatars.githubusercontent.com/u/46162170?v=4" width=115><br><sub>Wallace Borges</sub>](https://github.com/WallaceBorges) |[<img src="https://avatars.githubusercontent.com/u/77901483?v=4" width=115><br><sub>Simon Mendes</sub>](https://github.com/simpmendes) |
| :---: | :---: | :---: | :---: 
