# correiosTake
Projeto para avaliação da take

## Descrição do projeto
Criação de uma API que realizasse a leitura de um arquivo txt e retornasse outro txt com o menor caminho entre duas cidades. Por se tratar de um porjeto de pedido confidencial, o memso não será tratado com muitos detalhes de solicitação.

## Estrtura
Projeto feito em linguagem C# .net Core 3.1 e banco de dados SQL Server

## Banco de dados
O banco de dados utilizado é o [SQL Server Express](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) que pode ser baixado gratuitamente;
Para iniciar o teste do projeto é necessário:
1. Realizar a instação do banco de dados (SQL Server) 
2. Alterar dentro de **appsettings.json** a string de conexão no **DefaultConnection**

## Testes (Do que terminei)
1. **GET** https://localhost:44328/api/estados
2. **POST** https://localhost:44328/api/estados

> ```
	Content-Type application/json

	Raw
	{
		"NomeEstado": "San Andreas",
		"Sigla": "SA"
	}
```

3. **GET** https://localhost:44328/api/estados/sa/cidades
4. **POST** https://localhost:44328/api/estados/sa/cidades

```
	Raw
	{
		"nomeCidade": "Teste 3",
		"sigla": "T3",
		"IdEstado": 1
	}
```

5. **DELETE** https://localhost:44328/api/estados/sa/cidades/{idCidade}

## Distribuição
- [x] Entidades
- [X] Repositorios
- [X] Services
- [X] API de controle do estado
- [X] API de controle da cidade
- [ ] API do trexo (a mais importante, mas faltou não controlei bem as atividades do emprego atual)
- [X] DTO's'

## Considerações finais
O projeto deveria ser entregue em 3 dias e mesmo tendo um fim de semana inteiro para produção do proejeto, atividades do meu atual emprego impossibilitaram de realizar o projeto completo.

Sei que o controle de tempo, assim como, de entrega é de resposnabilidade do candidato, mas espero que mesmo incompleto vocês possam ter uma visão de como eu consigo realizar uma estruturação de projeto, segmentação de camadas e uma parte da solução.

Agradeço a oportunidade