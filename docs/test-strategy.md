# Test Strategy

## Мета тестування

Мета тестування — перевірити:

- коректність бізнес-логіки;
- стабільність persistence layer;
- роботу LINQ-аналітики;
- правильність обробки помилок;
- стабільність order processing engine.

## Критичні сценарії

### Product Management

- створення товару;
- перевірка негативних значень;
- зміна кількості товару;
- перевірка залишків.

### Order Processing

- створення замовлення;
- автоматичне списання товару;
- застосування знижок;
- перевірка недостатньої кількості товару.

### Persistence

- збереження JSON;
- завантаження JSON;
- відновлення стану після перезапуску.

## Найскладніші частини для тестування

### Persistence Layer

Причини:

- файлові операції;
- асинхронний I/O;
- пошкоджені JSON-файли;
- тимчасові файли.

### Order Processing/

Причини:

- взаємодія між services;
- repositories;
- Strategy Pattern;
- бізнес-правила.

### Де потрібні mocks

Mocks будуть використовуватись для:

- repository interfaces;
- isolated service testing;
- перевірки business rules.

## Де потрібні integration tests

Integration tests потрібні для:

- JSON persistence;
- save/load cycle;
- repository + service interaction;
- повного order workflow.

## Негативні сценарії

### Product

- негативна ціна;
- негативна кількість;
- недостатній stock.

### Order

- quantity <= 0;
- totalPrice <= 0;
- неіснуючий productId.

### Persistence/

- відсутній JSON файл;
- пошкоджений JSON;
- порожній JSON.

## Test Pyramid

### Unit Tests

Перевіряють:

- domain entities;
- business rules;
- strategies;
- services.

### Integration Tests

Перевіряють:

- persistence;
- repositories;
- повний цикл роботи системи.

## Quality Goals

Проєкт повинен:

- проходити всі unit tests;
- проходити integration tests;
- проходити CI pipeline;
- підтримувати стабільний persistence layer;
- коректно обробляти помилки.
