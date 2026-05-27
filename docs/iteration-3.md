# Iteration 3 — Testing and Refactoring

## Опис ітерації

У третій ітерації основна увага була приділена:

- тестуванню системи;
- integration tests;
- fault handling;
- стабільності persistence layer;
- покращенню якості коду.

## Основні зміни

### Unit Tests

Було реалізовано unit tests для:

- Product;
- Order;
- Discount strategies;
- ProductService;
- OrderService;
- custom exceptions.

### Реалізовані файли

- ProductTests.cs
- OrderTests.cs
- DiscountStrategyTests.cs
- ProductServiceTests.cs
- OrderServiceTests.cs
- ExceptionTests.cs

## Integration Tests

Було реалізовано integration tests для:

- JSON persistence;
- repositories;
- services;
- workflow системи.

### Реалізовані integration tests

- ProductIntegrationTests.cs
- OrderIntegrationTests.cs
- PersistenceIntegrationTests.cs
- SupplierIntegrationTests.cs
- WarehouseIntegrationTests.cs
- StockItemIntegrationTests.cs

## Fault Handling

Було додано перевірку:

- invalid quantity;
- invalid order;
- insufficient stock;
- missing JSON file;
- corrupted JSON.

## Persistence Improvements

Було покращено:

- save/load logic;
- async file operations;
- JSON error handling;
- stability of persistence layer.

## Refactoring

Було проведено refactoring:

- services;
- repositories;
- persistence layer;
- testing structure.

## CI/CD

Система проходить:

- build validation;
- unit tests;
- integration tests;
- GitHub Actions pipeline.

## Результати тестування

### Підсумок

- 33+ tests implemented;
- all tests passed;
- integration tests working;
- exception handling implemented.

## Висновок

У третій ітерації було реалізовано повноцінну систему тестування.

Було покращено:

- стабільність системи;
- fault handling;
- quality of persistence layer;
- integration between components.

Система успішно проходить unit та integration tests і готова до наступної ітерації.
