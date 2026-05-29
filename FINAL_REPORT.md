# FINAL REPORT

## WarehouseManagementSystem

## Загальна інформація

### Назва проєкту

WarehouseManagementSystem

### Технології

* C#
* .NET 10
* xUnit
* GitHub
* GitHub Actions

## Мета проєкту

Метою проєкту було створення системи управління складом з використанням сучасних підходів розробки .NET застосунків.

## Реалізований функціонал

### Робота з товарами

Система дозволяє:

* створювати товари;
* змінювати кількість;
* переглядати список товарів;
* зберігати товари у JSON.

### Робота із замовленнями

Реалізовано:

* створення замовлень;
* перевірку кількості товарів;
* бізнес-правила;
* exception handling.

### Persistence Layer

Реалізовано:

* JSON persistence;
* repositories;
* data storage.

## Архітектура

Проєкт побудований за принципами:

* layered architecture;
* repository pattern;
* strategy pattern;
* separation of concerns.

## Testing

## Реалізовані типи тестів

### Unit Tests

* services;
* repositories;
* strategies;
* exceptions.

### Integration Tests

* repositories;
* persistence;
* services.

### Exception Tests

* InvalidOrderException;
* InvalidQuantityException;
* InsufficientStockException.

## Документація

Створено:

* README;
* architecture;
* user guide;
* developer guide;
* changelog;
* release plan;
* test strategy;
* test matrix;
* iteration reports.

## Git Workflow

Для кожної лабораторної роботи використовувались окремі git-гілки.

Приклади:

```plaintext id="u3r7lz"
lab35-business-and-persistence
lab36-testing-and-refactoring
lab37-finalization-and-patterns
```

## CI/CD

GitHub Actions автоматично:

* запускає build;
* запускає tests;
* перевіряє pull requests.

## Результати роботи

У результаті було створено повноцінний навчальний .NET проєкт з:

* багатошаровою архітектурою;
* persistence layer;
* testing layer;
* документацією;
* CI/CD.

## Висновок

Під час виконання лабораторних робіт було отримано практичні навички роботи з:

* .NET;
* Git та GitHub;
* testing;
* repository pattern;
* strategy pattern;
* CI/CD;
* багатошаровою архітектурою.

Проєкт став хорошим прикладом організації сучасного .NET застосунку.
