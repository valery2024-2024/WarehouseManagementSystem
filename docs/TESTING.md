# TESTING

## Опис

У проєкті реалізовано:

- unit tests;
- integration tests;
- fault handling tests;
- перевірка persistence layer;
- перевірка business logic.

Тестування реалізоване за допомогою:

- xUnit;
- .NET Test SDK.

## Структура тестів

### Unit Tests

Unit tests перевіряють:

- domain entities;
- business rules;
- services;
- strategy pattern;
- exception handling.

### Реалізовані unit tests

- ProductTests
- OrderTests
- DiscountStrategyTests
- OrderServiceTests
- ProductServiceTests
- ExceptionTests

## Integration Tests

Integration tests перевіряють:

- persistence layer;
- repository interaction;
- service interaction;
- save/load cycle;
- повний workflow системи.

### Реалізовані integration tests

- ProductIntegrationTests
- OrderIntegrationTests
- PersistenceIntegrationTests
- SupplierIntegrationTests
- WarehouseIntegrationTests
- StockItemIntegrationTests

## Fault Handling

Система перевіряє:

- invalid quantity;
- invalid order;
- insufficient stock;
- missing JSON file;
- corrupted JSON.

## Запуск тестів

### Запуск усіх тестів

```bash
dotnet test
```
