# Leilao Online

Sistema de leilão online.

## Executar o projeto do back-end
Basta abrir a solution em um visual studio que tem suporte para o ASP Net Core 3 e executar o projeto.

## Informações

Desenvolvido com ASP Net Core e EF Core, autenticação via JWT, filtros para tratar retornos, DDD, aplicando os principios de SOLID, testes unitários com XUnit e Pattern Unit of Work.

Utilizado migration para criar a base, connection string se encontra no appSettings, para criar basta trocar a connectionString e rodar o comando do migration, já deixei configurado o seed para a base já ser criada com dados.

Swagger implementado como documentação da API, na rota /swagger

## Executar o projeto do front end
Para executar o projeto como as dependencias estão no gitignore, é necessário rodar o comando:

1 - ) npm install

E após isso já pode rodar o projeto:

2 - ) ng serve

## Informações

Desenvolvido em angular 10, utilizando angular material, intefaces, interceptor, toastr, bootstrap, loader, services.

