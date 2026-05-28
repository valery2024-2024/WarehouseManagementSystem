# Архітектура WarehouseManagementSystem

## Огляд системи

WarehouseManagementSystem — це консольна система управління складом, створена на платформі .NET.

Проєкт побудований за принципами багатошарової архітектури, що дозволяє легко підтримувати, тестувати та розширювати систему.

# Архітектурні шари

## 1. Domain Layer

Містить основну бізнес-логіку та сутності системи.

### Основні сутності

* Product
* Order
* Warehouse
* Supplier
* StockItem

### Exceptions

* InvalidOrderException
* InvalidQuantityException
* InsufficientStockException

## 2. Application Layer

Відповідає за бізнес-операції та сервіси.

### Services

* ProductService
* OrderService

### DTO

* ProductDto
* OrderDto

### Policies

* validation policies
* business rules

### Strategies

* discount strategies
* pricing strategies

## 3. Infrastructure Layer

Відповідає за збереження та доступ до даних.

### Repositories

* InMemoryProductRepository
* InMemoryOrderRepository

### Persistence

* JsonProductDataStore

### Data Storage

Дані зберігаються у:

```plaintext
data/products.json
```

## 4. Console Layer

Консольний інтерфейс користувача.

### Основні можливості

* додавання продуктів;
* створення замовлень;
* перегляд складу;
* тестування бізнес-логіки.

# Testing Architecture

Проєкт містить декілька рівнів тестування.

## Unit Tests

Перевірка окремих компонентів:

* services;
* repositories;
* strategies;
* exceptions.

## Integration Tests

Перевірка взаємодії між компонентами:

* persistence;
* repositories;
* services;
* JSON storage.

## CI/CD

GitHub Actions автоматично:

* збирає проєкт;
* запускає тести;
* перевіряє pull requests.

# Основні патерни

## Repository Pattern

Використовується для роботи з даними.

## Strategy Pattern

Використовується для реалізації різних стратегій знижок.

## Layered Architecture

Система поділена на окремі логічні шари.

# Переваги архітектури

* простота підтримки;
* масштабованість;
* легке тестування;
* розділення відповідальностей;
* зручність розширення функціоналу.

# Висновок

Архітектура WarehouseManagementSystem побудована з використанням сучасних підходів до розробки .NET застосунків та забезпечує стабільну основу для подальшого розвитку системи.
