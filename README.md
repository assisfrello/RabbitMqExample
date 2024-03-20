**Aplicação de Envio e Consumo de Mensagens com RabbitMQ em C#**

Este repositório contém uma aplicação em C# que demonstra o envio e consumo de mensagens utilizando o RabbitMQ. A solução é dividida em dois projetos: um responsável pelo envio de mensagens e outro pelo consumo das mesmas.

**Pré-requisitos**

Visual Studio (ou qualquer IDE compatível com projetos .NET)

RabbitMQ instalado e em execução

**Configuração do RabbitMQ**

Certifique-se de que o RabbitMQ está instalado e em execução em sua máquina local ou em um servidor acessível. Você pode encontrar instruções sobre como instalar e configurar o RabbitMQ em rabbitmq.com.

**Detalhes de Implementação**

Envio de Mensagens: O projeto RabbitMqExample.Api utiliza a biblioteca RabbitMQ.Client para estabelecer uma conexão com o RabbitMQ e enviar mensagens para uma fila específica.

Consumo de Mensagens: O projeto RabbitMqExample.Service utiliza a mesma biblioteca para consumir mensagens da fila configurada. Ele então encaminha essas mensagens para os controllers apropriados com base em atributos definidos nos métodos.

**Observações**

Certifique-se de que o RabbitMQ está em execução antes de executar os projetos de envio e consumo de mensagens.

**Contribuições**

Contribuições são bem-vindas! Se você encontrar problemas ou tiver sugestões de melhorias, sinta-se à vontade para abrir uma issue ou enviar um pull request.
