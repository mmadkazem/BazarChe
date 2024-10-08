# BazarChe

## Project Overview:

In this project, I plan to develop a microservice using ASP.NET Core with the goal of gaining a comprehensive understanding of microservices architecture. By mastering these concepts, I aim to effectively apply this knowledge to future projects.

This is an e-commerce system built on microservice architecture using:

- .NET 8
- Entity Framework Core
- MediatR
- FastEndpoints
- Carter
- Ocelot
- JWT Tokens
- MasTransit(Rabbitmq and Kafka)
- Polly
- NEST (ElasticSearch client)
- Dapper
- SignalR
- Clean Architecture
- DDD (Domain Driven Design)
- Vertical Slice Architecture
- Distributed Cache(Redis)
- Distributed Transaction (Saga Pattern)
- MongoDb
- Postgresql

# Ecommerce System for Wholesale Sales
=====================================

## Business Case
============================

Our ecommerce system is designed for wholesale sales of various products. The system is tailored for business representatives who will log in to access a range of products available for wholesale.

## Key Features
---------------

### Product Browsing and Selection

* Agents can view products and find suitable items for their customers
* Create unique discount codes for products

### Bulk Sales and Purchases

* Agents can buy and sell in bulk using a virtual wallet (volt)
* Withdraw or charge funds from the volt as needed
* Efficient bulk transactions

### Search Service

* Instantly discover and purchase other agents' products
* Customers can access products in a fraction of a second

### Chat System

* Agents can chat with customers and meet their needs
* Real-time communication for a better customer experience

### Notification System

* Agents can inform customers about product status updates
* Multiple notification channels for convenience

#### Affiliate Marketing System

* Businesses can enable affiliate features for their products
* Other users can assist in promoting and selling products
* Enhances productivity and supports business growth

## How it Works
---------------

1. Business representatives log in to the system.
2. The system provides access to a list of products available for wholesale.
3. Agents browse and select products suitable for their customers.
4. Agents generate unique discount codes for their chosen products.
5. Agents purchase products in bulk using their virtual wallet.
6. Agents can search and buy other agents' products instantly.
7. Agents can chat with customers and notify them about product status.

## Installation

1. Clone the repository:

```bash
git clone https://github.com/mmadkazem/BazarChe.git
```

2. Build and Run Docker Compose file:

```bash
docker-compose -f .\docker-compose.override.yml -f .\docker-compose.yml up --build
```
## Give a Star! ⭐
If you find this project useful or interesting, a star on GitHub would be greatly appreciated. It helps support the project and acknowledges the efforts of its contributors.

## License

This project is licensed under the MIT License: [MIT License](https://opensource.org/licenses/MIT).
