# MiniTMS.API

Fiz uma pequena simulação de um TMS, um sistema de logística, nesse caso, terceirizado.

Para rodar o projeto são necessários alguns passos:

1. Alterar a string de conexão, fiz tudo em um banco de dados local, então será necessário ir até appsettings.Development.json no projeto MiniTMS.API e alterar o parâmetro "Data Source" para o servidor que será utilizado na avaliação.
2. Abrir o Console do Gerenciador de pacotes através de Ferramentas -> Gerenciador de pacotes do NuGet -> Console do Gerenciador de Pacotes
3. No gerenciador de pacotes, altere o projeto padrão para MiniTMS.Dados e certifique-se de que o projeto inicializador é o MiniTMS.API (botão direito no projeto -> Definir como projeto de inicialização)
4. Rodar o comando update-database para que as migrations rodem e o banco de dados seja criado.


Obs: O fluxo de teste é Clientes -> Destinatarios -> Entregadores -> Status -> Produtos -> Pedidos
