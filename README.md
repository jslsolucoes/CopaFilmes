# CopaFilmes


Com o Docker instalado baixe e execute o container com o comando a seguir:

```docker run -p 5000:80 jslsolucoes/webapplication:latest```

Quando o container estive pronto acesse:

```http://localhost:5000```


Rodar os testes:

```git clone https://github.com/jslsolucoes/CopaFilmes.git```

Para executar os testes de backend:

```cd CopaFilmes```

```dotnet test```

Para executar os testes de frontend:

```cd CopaFilmes/WebApplication/ClientApp```

```npm run test```
