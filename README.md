# 🛒 Sistema de Controle de Pedidos de E-commerce com Design Patterns

## 📌 Introdução

Este projeto foi desenvolvido com o objetivo de treinar o conhecimento em **Design Patterns**. O sistema em questão é um **e-commerce** que controla os pedidos realizados, considerando seus status e os métodos de envio disponíveis.

### ✅ Funcionalidades principais:

1. **Controle de Status do Pedido**: O pedido passa por diferentes status, como "Aguardando Pagamento", "Pago", "Enviado" e "Cancelado".
2. **Métodos de Envio**: O sistema possui métodos de envio por **via terrestre (caminhão)** e **via aérea (avião)**, com o cálculo do valor do frete baseado no valor do pedido (5% para terrestre e 10% para aérea).
3. **Impossibilidade de mudanças de status após cancelamento**: Uma vez que um pedido é cancelado, não pode mais ser alterado.
4. **Extensibilidade**: O sistema permite a adição de novos métodos de envio no futuro sem alterar a estrutura existente.

## 🧠 Padrões de Design Utilizados

### 🔄 **State**

O **State** foi utilizado para controlar o fluxo de estados do pedido, como "Aguardando Pagamento", "Pago", "Enviado" e "Cancelado". Cada status é representado por uma classe específica que define as ações permitidas em cada etapa.

### 🧮 **Strategy**

O **Strategy** foi aplicado para implementar os diferentes métodos de cálculo do valor do frete. O cálculo do frete varia conforme o tipo de envio escolhido (terrestre ou aéreo). Cada tipo de cálculo foi encapsulado em uma estratégia específica, permitindo que o sistema seja facilmente expandido com novos métodos de envio no futuro.

## 🏗️ Estrutura do Projeto

O projeto é uma **Web API** construída utilizando **ASP.NET Core** e um banco de dados **PostgreSQL**. A API expõe endpoints para gerenciar pedidos e realizar transições de status.

A estrutura do projeto é dividida nas seguintes camadas:

### 🗂️ 1. **Repository**

A camada **Repository** é responsável pela comunicação com o banco de dados, servindo como uma abstração entre a aplicação e a fonte de dados. Seu principal objetivo é isolar a lógica de acesso a dados do restante da aplicação, facilitando a manutenção, testes e segurança.

#### 📄 Classes modelo

![image](https://github.com/user-attachments/assets/923e1cc3-09a4-4634-ba5a-1c21a37a5485)

### 🧰 2. **Service**

![image](https://github.com/user-attachments/assets/aa57c603-f305-4a1f-ae4d-2091b1edda02)

A camada **Service** contém a lógica de negócios. Aqui, implementamos as transições de status do pedido e os cálculos de frete de acordo com os tipos de envio disponíveis. Além disso, é onde os **Design Patterns** foram aplicados:

* **State**: Implementação de diferentes estados do pedido em classes separadas e as ações permitidas em cada um.
* **Strategy**: Implementação das estratégias de cálculo de frete, permitindo a adição de novos métodos de envio sem a necessidade de alterar o código existente.

#### 📄 Classes principais:

* **PedidoService**: Responsável por gerenciar os pedidos e realizar as conversões necessárias.

### 🧭 3. **Controller**

A camada **Controller** é responsável por lidar com as requisições recebidas e direcioná-las para os serviços apropriados. Ela atua como intermediária entre a entrada do usuário e a lógica de negócio da aplicação, realizando as validações necessárias para o funcionamento correto das operações.
