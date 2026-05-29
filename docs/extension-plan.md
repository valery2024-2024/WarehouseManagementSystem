# Extension Plan

## Мета розширення

Після завершення основних лабораторних робіт було вирішено покращити проєкт WarehouseManagementSystem шляхом додавання нових механізмів оптимізації, кешування та розширеного пошуку.

## Загальна ідея

Було обрано три залежні розширення:

1. Generic Cache System
2. Cached Product Search + LINQ Analytics
3. Performance Tests та Benchmark Comparison

Кожне наступне розширення використовує результат попереднього.

## Розширення A — Generic Cache System

### Мета

Створити універсальний generic cache для кешування даних.

### Що буде реалізовано

* generic cache class;
* Dictionary<Guid, T>;
* methods:

  * Add
  * Get
  * Remove
  * Clear

### Для чого це потрібно

Кеш дозволить:

* зменшити кількість повторних пошуків;
* покращити продуктивність;
* показати використання generics та collections.

## Розширення B — Cached Product Search

### Мета/

Побудувати новий механізм пошуку товарів з використанням кешу та LINQ.

### Що буде реалізовано/

* cached product lookup;
* LINQ filtering;
* analytics;
* statistics.

## Залежність від A

Розширення використовує Generic Cache System для збереження результатів пошуку.

## Розширення C — Performance Tests

### Мета

Порівняти роботу пошуку:

* без кешу;
* з кешем.

### Що буде реалізовано

* performance comparison;
* benchmark tests;
* integration tests;
* documentation results.

### Залежність від B

Тести використовують cached search implementation.

## Очікуваний результат

Після реалізації розширень проєкт:

* краще демонструватиме generics;
* використовуватиме Dictionary;
* покаже optimization techniques;
* матиме додаткові integration tests;
* демонструватиме performance improvements.

## Теми курсу, які закриваються

* Generics
* Collections
* Dictionary
* LINQ
* Optimization
* Testing
* Refactoring
* Architecture improvements
