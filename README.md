# Relatório de vendas
Projeto desenvolvido em C# que interage com a API do Google Sheets.

## Sobre a API do Google Sheets
A API Google Sheets é uma interface RESTful que permite ler e modificar os dados de uma planilha. Os usos mais comuns dessa API incluem as seguintes tarefas:

- Criar planilhas
- Ler e gravar valores de célula na planilha
- Atualizar a formatação da planilha
- Gerenciar páginas conectadas

## Visão geral
Esse projeto surgiu como uma alternativa para resolver o problema de gerar um relatório/ranking mensal de vendedores, considerando o comparativo entre o valor das vendas de cada vendedor e a média das vendas em cada estado. 

Para começar, foi necessário simular a situação do problema, criando um projeto de planilhas do Google com <strong><em>nomes e valores fictícios</em></strong>:
- https://docs.google.com/spreadsheets/d/1-pV09988ZCsoJamDv7_fdWYcBGR8iAiC3bTLYXqqZtg/edit?pli=1#gid=0

E seguindo a seguinte documentação da API, o projeto começou a ganhar forma:
- https://developers.google.com/api-client-library/dotnet/apis/sheets/v4?hl=pt-br

## Funcionalidades
Os usuários podem:

- Gerar um relatório/ranking mensal de vendedores, considerando o comparativo entre o valor das vendas de cada vendedor e a média das vendas em cada estado;
- Cadastrar novos vendedores;

## A interface do usuário
A interface do usuário deste projeto ficou relativamente simples, uma vez que o foco principal é a interação com a API do Google Sheets. Basicamente, é composta por três páginas principais: a página inicial, a página de busca de relatórios e a página de cadastro de vendedores. A seguir, estão algumas imagens:

  ![Tela de início](https://github.com/AllyssonAntonucci/relatorio-de-vendas/assets/125825975/8d6216c9-d48a-4ae3-a612-6672a108303a)
  <p align="center">
    <em>Figura 1: Tela de Início do Projeto</em>
  </p>

  ![Tela de relatório](https://github.com/AllyssonAntonucci/relatorio-de-vendas/assets/125825975/526cf00f-7e00-44a6-b003-757c89d19499)
  <p align="center">
    <em>Figura 2: Tela de Busca de Relatórios</em>
  </p>

  ![Relatório](https://github.com/AllyssonAntonucci/relatorio-de-vendas/assets/125825975/bbf92cd4-083b-4da2-a1da-1dddbc3a3fdb)
  <p align="center">
    <em>Figura 3: Relatório de Janeiro de 2024</em>
  </p>

  ![Tela de cadastro](https://github.com/AllyssonAntonucci/relatorio-de-vendas/assets/125825975/fd481444-bca3-411b-9f8f-3421f5960fa8)
  <p align="center">
    <em>Figura 4: Tela de Cadastro de Vendedores</em>
  </p>

## Tecnologias Utilizadas no Projeto

- C#;
- ASP.NET Core;
- Google.Apis.Sheets.v4
- HTML;
- CSS;
- Bootstrap;

---

Para mais informações ou dúvidas, sinta-se à vontade para entrar em contato comigo:
- Email: allysson.antonucci.dev@gmail.com

  





