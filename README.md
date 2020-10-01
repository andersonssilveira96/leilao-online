# Leilao Online

Sistema de leilão online.

## Executar o projeto do back-end
Basta abrir a solution em um visual studio que tem suporte para o ASP Net Core 3 ( Visual Studio 2019 no meu caso ) e executar o projeto.

Para criar o banco de dados através do Migration do Entity, seguir os seguintes passos:

Configurar a connection string que se encontra no appSettings, depois abrir o  "Console do Gerenciador de pacotes", selecionar o projeto "LeilaoOnline.Infra.Data", e executar:

1 - ) add-migration "nome"
2 - ) update-database

O banco vai ser criado e já deixei configurado para quando criar popular a base com alguns dados.

Email de login: "teste@teste.com.br" e senha "123";

## Informações

Desenvolvido com ASP Net Core e EF Core, autenticação via JWT, filtros para tratar retornos, DDD, aplicando os principios de SOLID, testes unitários com XUnit e Pattern Unit of Work.

Swagger implementado como documentação da API, na rota /swagger

## Executar o projeto do front end
Para executar o projeto como as dependencias estão no gitignore, é necessário rodar o comando:

1 - ) npm install

E após isso já pode rodar o projeto:

2 - ) ng serve

## Informações

Desenvolvido em angular 10, utilizando angular material, intefaces, interceptor, toastr, bootstrap, loader, services, hash md5.

