# correiosTake
Projeto para avalia��o da take

## Descri��o do projeto
Cria��o de uma API que realizasse a leitura de um arquivo txt e retornasse outro txt com o menor caminho entre duas cidades. Por se tratar de um porjeto de pedido confidencial, o memso n�o ser� tratado com muitos detalhes de solicita��o.

## Estrtura
Projeto feito em linguagem C# .net Core 3.1 e banco de dados SQL Server

## Banco de dados
O banco de dados utilizado � o [SQL Server Express](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) que pode ser baixado gratuitamente;
Para iniciar o teste do projeto � necess�rio:
1. Realizar a insta��o do banco de dados (SQL Server) 
2. Alterar dentro de **appsettings.json** a string de conex�o no **DefaultConnection**

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

## Distribui��o
- [x] Entidades
- [X] Repositorios
- [X] Services
- [X] API de controle do estado
- [X] API de controle da cidade
- [ ] API do trexo (a mais importante, mas faltou n�o controlei bem as atividades do emprego atual)
- [X] DTO's'

## Considera��es finais
O projeto deveria ser entregue em 3 dias e mesmo tendo um fim de semana inteiro para produ��o do proejeto, atividades do meu atual emprego impossibilitaram de realizar o projeto completo.

Sei que o controle de tempo, assim como, de entrega � de resposnabilidade do candidato, mas espero que mesmo incompleto voc�s possam ter uma vis�o de como eu consigo realizar uma estrutura��o de projeto, segmenta��o de camadas e uma parte da solu��o.

Agrade�o a oportunidade