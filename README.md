# Warehouse Management System

## Опис

Warehouse Management System — це консольний застосунок для управління складом, товарами та замовленнями.

Проєкт реалізований у рамках лабораторних робіт №34-35 та демонструє:

- багатошарову архітектуру;
- бізнес-логіку;
- persistence layer;
- LINQ-аналітику;
- патерни проєктування;
- automated testing.

## Основні можливості

### Управління товарами

- додавання товарів;
- перегляд товарів;
- пошук товарів;
- сортування за ціною;
- фільтрація товарів з малою кількістю.

### Обробка замовлень

- створення замовлень;
- автоматичне списання товарів;
- перевірка залишків;
- застосування знижок;
- контроль бізнес-правил.

### Аналітика

- загальна вартість складу;
- статистика замовлень;
- LINQ-запити;
- analytics dashboard.

## Архітектура

Проєкт використовує багатошарову архітектуру:

- Domain
- Application
- Infrastructure
- Console
- Tests

## Використані технології

- C#
- .NET
- LINQ
- xUnit
- JSON Persistence
- GitHub Actions CI

## Реалізовані патерни проєктування

### Strategy Pattern

Використовується для системи знижок:

- RegularDiscountStrategy
- SilverDiscountStrategy
- GoldDiscountStrategy

### Factory Pattern

Використовується для створення discount strategies.

### Repository Pattern

Використовується для abstraction persistence layer.

## Persistence Layer

Реалізовано:

- JSON persistence;
- SaveAsync();
- LoadAsync();
- автоматичне відновлення стану програми.

## Бізнес-правила

Система перевіряє:

- ціна товару не може бути від’ємною;
- кількість товару не може бути від’ємною;
- не можна оформити замовлення без товару;
- не можна купити більше товару, ніж є на складі;
- знижки застосовуються залежно від типу клієнта.

## LINQ Функціонал

Реалізовано:

- сортування;
- фільтрацію;
- агрегацію;
- analytics queries;
- статистику продажів.

## Структура проєкту

```text
src/
 ├── WarehouseManagementSystem.Domain
 ├── WarehouseManagementSystem.Application
 ├── WarehouseManagementSystem.Infrastructure
 ├── WarehouseManagementSystem.Console

tests/
 ├── WarehouseManagementSystem.Tests

docs/
 ├── vision.md
 ├── backlog.md
 ├── iteration-1.md
 ├── iteration-2.md
 ├── iteration-2-plan.md
 
 ```
