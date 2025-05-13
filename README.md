# Sistema de Controle de Pedidos de E-commerce com Design Patterns

## Introdução

Este projeto foi desenvolvido com o objetivo de treinar o conhecimento em **Design Patterns**, mais especificamente com os padrões **State** e **Strategy**. O sistema em questão é um **e-commerce** que controla os pedidos realizados, considerando seus status e os métodos de envio disponíveis.

### Funcionalidades principais:

1. **Controle de Status do Pedido**: O pedido passa por diferentes status, como "Aguardando Pagamento", "Pago", "Enviado" e "Cancelado".
2. **Métodos de Envio**: O sistema possui métodos de envio por **via terrestre (caminhão)** e **via aérea (avião)**, com o cálculo do valor do frete baseado no valor do pedido (5% para terrestre e 10% para aérea).
3. **Impossibilidade de mudanças de status após cancelamento**: Uma vez que um pedido é cancelado, não pode mais ser alterado.
4. **Extensibilidade**: O sistema permite a adição de novos métodos de envio no futuro sem alterar a estrutura existente.

## Padrões de Design Utilizados

### **State Pattern**

O **State Pattern** foi utilizado para controlar o fluxo de estados do pedido, como "Aguardando Pagamento", "Pago", "Enviado" e "Cancelado". Cada status é representado por uma classe específica que define as ações permitidas em cada etapa.

### **Strategy Pattern**

O **Strategy Pattern** foi aplicado para implementar os diferentes métodos de cálculo do valor do frete. O cálculo do frete varia conforme o tipo de envio escolhido (terrestre ou aéreo). Cada tipo de cálculo foi encapsulado em uma estratégia específica, permitindo que o sistema seja facilmente expandido com novos métodos de envio no futuro.

## Estrutura do Projeto

O projeto é uma **Web API** construída utilizando **ASP.NET Core** e um banco de dados **PostgreSQL**. A API expõe endpoints para gerenciar pedidos, realizar transições de status e calcular o valor do frete.

A estrutura do projeto é dividida nas seguintes camadas:

### 1. **Camada de Apresentação (API)**

A camada de apresentação é responsável por expor os endpoints da Web API para que o cliente (front-end ou outro serviço) interaja com o sistema. Nessa camada, utilizamos os controladores do ASP.NET Core para manipular requisições HTTP e realizar operações nos pedidos.

#### Exemplos de Endpoints:

* `POST /api/pedidos`: Criar um novo pedido.
* `GET /api/pedidos/{id}`: Obter o status e detalhes do pedido.
* `PUT /api/pedidos/{id}/pagar`: Efetuar o pagamento de um pedido.
* `PUT /api/pedidos/{id}/enviar`: Enviar o pedido após o pagamento.
* `PUT /api/pedidos/{id}/cancelar`: Cancelar o pedido.

### 2. **Camada de Aplicação**

A camada de aplicação contém a lógica de negócios. Aqui, implementamos as transições de status do pedido e os cálculos de frete de acordo com os tipos de envio disponíveis. Além disso, é onde os **Design Patterns** foram aplicados:

* **State Pattern**: Implementação de diferentes estados (Status) do pedido e as ações permitidas em cada um.
* **Strategy Pattern**: Implementação das estratégias de cálculo de frete, permitindo a adição de novos métodos de envio sem a necessidade de alterar o código existente.

#### Classes principais:

* **PedidoService**: Responsável por orquestrar as operações sobre os pedidos, como pagamento, envio e cancelamento.
* **FreteService**: Calcula o valor do frete com base no tipo de envio.

### 3. **Camada de Persistência (Banco de Dados)**

A camada de persistência é responsável pela interação com o banco de dados **PostgreSQL**. Utiliza **Entity Framework Core** para mapear as entidades do sistema, como **Pedido**, **Status**, e **Frete**.

#### Modelos principais:

* **Pedido**: Contém as informações do pedido, como ID, valor total, status, etc.
* **Status**: Representa o status atual do pedido (Aguardando Pagamento, Pago, Enviado, Cancelado).
* **Frete**: Armazena os detalhes do cálculo de frete para o pedido.

### 4. **Camada de Infraestrutura**

A camada de infraestrutura gerencia as dependências externas, como o acesso ao banco de dados, e provê suporte a serviços comuns, como logging, validação, etc. Aqui, também são definidas as interfaces e classes para os **repositories** e **services**.

#### Exemplos de classes:

* **PedidoRepository**: Responsável por acessar e manipular os dados de pedidos no banco de dados.
* **FreteRepository**: Responsável por armazenar e recuperar informações sobre os cálculos de frete.

## Explicação por Camada

### 1. **Camada de Apresentação (API)**

* **Objetivo**: Expor endpoints para que o front-end ou outros serviços possam interagir com o sistema.
* **Tecnologia**: ASP.NET Core.
* **Função**: Receber requisições e chamar os serviços da camada de aplicação para realizar as ações necessárias (criar pedido, realizar pagamento, alterar status, etc.).

### 2. **Camada de Aplicação**

* **Objetivo**: Implementar a lógica de negócios.
* **Tecnologia**: C# com uso de Design Patterns (State e Strategy).
* **Função**:

  * **State Pattern**: Controlar o status do pedido (Aguardando Pagamento, Pago, Enviado, Cancelado).
  * **Strategy Pattern**: Permitir a escolha de diferentes métodos de cálculo do frete e a futura adição de novos métodos de envio.

### 3. **Camada de Persistência**

* **Objetivo**: Interagir com o banco de dados PostgreSQL para armazenar e recuperar dados.
* **Tecnologia**: Entity Framework Core.
* **Função**: Mapear entidades como **Pedido**, **Status** e **Frete** para o banco de dados e realizar operações CRUD.

### 4. **Camada de Infraestrutura**

* **Objetivo**: Gerenciar a interação com sistemas externos (banco de dados, logs, etc.).
* **Tecnologia**: C# e bibliotecas auxiliares como **NLog** ou **Serilog** para logging, por exemplo.
* **Função**: Fornecer serviços e repositórios necessários para a operação do sistema, como o acesso ao banco de dados e o gerenciamento de dependências.
