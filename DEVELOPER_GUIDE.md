# DEVELOPER GUIDE

## WarehouseManagementSystem

## Опис для розробників

Цей документ описує структуру проєкту, архітектуру та правила роботи для розробників WarehouseManagementSystem.

## Архітектура проєкту

Проєкт побудований за принципами багатошарової архітектури.

### Основні шари

```plaintext id="q2md8v"
Domain
Application
Infrastructure
Console
Tests
```

## Структура папок

### src/

Містить основний код системи.

### Domain

Містить:

* entities;
* exceptions;
* interfaces;
* business models.

### Application

Містить:

* services;
* DTO;
* policies;
* strategies.

### Infrastructure

Містить:

* repositories;
* persistence;
* JSON data store.

### Console

Консольний інтерфейс користувача.

## tests/

Містить усі тести.

## Unit Tests

* services;
* repositories;
* strategies;
* exceptions.

## Integration Tests

* persistence;
* repositories;
* services.

## docs/

Документація проєкту.

## Основні патерни

### Repository Pattern

Використовується для абстракції роботи з даними.

Приклади:

```plaintext id="x7n3la"
InMemoryProductRepository
InMemoryOrderRepository
```

### Strategy Pattern

Використовується для реалізації різних стратегій знижок.

Приклади:

```plaintext id="o9k1pb"
DiscountStrategy
```

## JSON Persistence

Система використовує JSON файл:

```plaintext id="f3j2rs"
data/products.json
```

Для збереження продуктів.

## Робота з Git

### Створення нової гілки

```bash id="m2z9kw"
git checkout -b branch-name
```

## Workflow

### 1. Створення нової гілки

Для кожної лабораторної:

```plaintext id="e6r4nj"
lab36-testing-and-refactoring
lab37-finalization-and-patterns
```

### 2. Робота над функціоналом

Після кожного логічного етапу:

```bash id="u4t9vl"
git add .
git commit -m "message"
git push
```

### 3. Pull Request

Після завершення роботи:

* створити Pull Request;
* пройти code review;
* merge у main.

## Тестування

### Запуск усіх тестів

```bash id="j8q3pw"
dotnet test
```

---

### Збірка проєкту

```bash id="v6n1yx"
dotnet build
```

## Code Style

### Основні правила

* зрозумілі назви класів;
* окремі responsibility;
* мінімум логіки у Console layer;
* використання services;
* використання interfaces.

### CI/CD

GitHub Actions автоматично:

* запускає build;
* запускає tests;
* перевіряє pull requests.

## Рекомендації

### Не зберігати бізнес-логіку у Console layer

Console повинен лише викликати services.

## Використовувати services

Уся бізнес-логіка має бути у services.

## Писати тести

Для кожного нового функціоналу бажано:

* unit test;
* integration test.

## Висновок

WarehouseManagementSystem побудований як навчальний приклад сучасної .NET системи з використанням repository pattern, strategy pattern, testing layer та CI/CD.
