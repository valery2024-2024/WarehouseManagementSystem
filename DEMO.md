# DEMO

## WarehouseManagementSystem Demo

## Опис проєкту

WarehouseManagementSystem — консольна система управління складом, створена на .NET.

Система демонструє:

* layered architecture;
* repository pattern;
* strategy pattern;
* persistence layer;
* testing layer;
* CI/CD.

## Демонстрація запуску

### Збірка проєкту

```bash id="x2q9dm"
dotnet build
```

## Запуск застосунку

```bash id="z4n7pw"
dotnet run --project src/WarehouseManagementSystem.Console
```

## Запуск тестів

```bash id="k8r1lv"
dotnet test
```

## Основні можливості системи

### 1. Робота з товарами

Система дозволяє:

* додавати товари;
* переглядати товари;
* змінювати кількість;
* зберігати товари у JSON.

### 2. Робота із замовленнями

Реалізовано:

* створення замовлень;
* перевірку кількості товарів;
* обробку помилок;
* business rules.

### 3. JSON Persistence

Товари зберігаються у:

```plaintext id="d2f7ms"
data/products.json
```

## Тестування

### Unit Tests

Перевірка:

* services;
* repositories;
* strategies;
* exceptions.

### Integration Tests

Перевірка:

* persistence;
* repositories;
* JSON storage.

## GitHub Workflow

### Branches

```plaintext id="g3v8kt"
main
lab35-business-and-persistence
lab36-testing-and-refactoring
lab37-finalization-and-patterns
```

## Pull Requests

Для кожної лабораторної створювався окремий Pull Request.

## CI/CD

GitHub Actions автоматично:

* запускає build;
* запускає tests;
* перевіряє pull requests.

## Архітектура

Проєкт побудований за принципами:

* layered architecture;
* separation of concerns;
* repository pattern;
* strategy pattern.

## Результати

Було реалізовано:

* persistence layer;
* testing layer;
* documentation layer;
* CI/CD integration.

## Висновок

WarehouseManagementSystem є прикладом сучасного .NET проєкту з правильною структурою, тестуванням, документацією та Git workflow.
