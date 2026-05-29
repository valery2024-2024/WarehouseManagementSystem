# Syllabus Coverage

## Покриття тем курсу у WarehouseManagementSystem

---

## 1. Основи ООП

## Використано

* класи;
* об’єкти;
* інкапсуляція;
* конструктори;
* властивості;
* методи.

## Приклади

* Product
* Order
* Warehouse
* Supplier
* StockItem

## 2. Абстракції, інтерфейси та поліморфізм

## Використано/

* interfaces;
* abstraction;
* dependency injection;
* polymorphism.

## Приклади/

* IProductRepository
* IOrderRepository
* IDataStore

## 3. Generics та колекції

### Використано

* List<T>;
* IReadOnlyCollection<T>;
* generic repositories.

### Приклади

* repositories;
* collections;
* test structures.

## 4. LINQ

### Використано

* filtering;
* sorting;
* aggregation;
* search operations.

### Приклади

* пошук товарів;
* analytics;
* repository operations.

## 5. Обробка помилок

### Використано

* custom exceptions;
* try/catch;
* validation;
* fault handling.

### Приклади

* InvalidOrderException
* InvalidQuantityException
* InsufficientStockException

## 6. Persistence

### Використано

* JSON persistence;
* async file operations;
* data storage.

### Приклади

```plaintext id="d4m8ps"
data/products.json
```

## 7. SOLID Principles

### Використано

### Single Responsibility Principle

* services;
* repositories;
* persistence layer.

### Dependency Inversion Principle

* interfaces;
* abstractions.

### Open/Closed Principle

* strategy pattern.

## 8. Патерни проєктування

### Repository Pattern

Використовується для роботи з даними.

### Strategy Pattern

Використовується для бізнес-правил та знижок.

### Layered Architecture

Система поділена на логічні шари.

## 9. UML

### Використано

* class diagram;
* sequence diagram.

## 10. Тестування

### Реалізовано

* unit tests;
* integration tests;
* exception tests.

### Інструменти

* xUnit;
* .NET Test SDK.

## 11. Refactoring

### Використано

* repository refactoring;
* persistence refactoring;
* code cleanup;
* naming improvements.

## 12. CI/CD

### Використано

* GitHub Actions;
* automated tests;
* pull request validation.

## Частково покриті теми

### Async Programming

Використовується частково у persistence layer.

### Performance Optimization

Проведено базову оптимізацію repository layer.

### Advanced Patterns

Реалізовано частково.

## Додаткові розширення

У проєкті додатково реалізовано:

* CI/CD;
* integration testing;
* release documentation;
* Git workflow;
* documentation architecture.

## Висновок

WarehouseManagementSystem покриває більшість основних тем курсу та демонструє практичне використання сучасних підходів .NET розробки.
