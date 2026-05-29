# Defense Q&A

## Питання та відповіді для захисту

## 1. Основна мета проєкту?

Мета проєкту — створити консольну систему управління складом з використанням сучасних підходів .NET розробки, тестування та Git workflow.

## 2. Які технології використовувались?

У проєкті використовувались:

* C#
* .NET 10
* xUnit
* GitHub
* GitHub Actions
* JSON persistence

## 3. Яка архітектура використовується?

Проєкт побудований за принципами layered architecture:

* Domain;
* Application;
* Infrastructure;
* Console layer;
* Tests.

## 4. Які патерни використані?

Було використано:

* Repository Pattern;
* Strategy Pattern;
* layered architecture.

## 5. Для чого потрібен Repository Pattern?

Repository Pattern дозволяє відокремити логіку роботи з даними від бізнес-логіки.

## 6. Для чого використовується Strategy Pattern?

Strategy Pattern використовується для реалізації різних стратегій знижок та бізнес-правил.

## 7. Як реалізовано persistence?

Persistence реалізований через JSON файл:

```plaintext id="n4q8vk"
data/products.json
```

## 8. Які тести реалізовані?

У проєкті реалізовано:

* unit tests;
* integration tests;
* exception tests.

## 9. Що перевіряють integration tests?

Integration tests перевіряють взаємодію між:

* repositories;
* services;
* persistence layer;
* JSON storage.

## 10. Для чого використовується CI/CD?

GitHub Actions автоматично:

* запускає build;
* запускає tests;
* перевіряє pull requests.

## 11. Які проблеми виникали під час розробки?

Основні проблеми:

* JSON persistence;
* integration tests;
* git branches;
* repository refactoring.

## 12. Що було найскладнішим?

Найскладнішим було:

* побудувати правильну архітектуру;
* реалізувати persistence layer;
* налаштувати integration tests.

## 13. Що можна покращити у майбутньому?

У майбутньому можна додати:

* базу даних;
* web UI;
* authentication;
* cloud deployment;
* advanced analytics.

## 14. Які теми курсу були використані?

Було використано:

* ООП;
* generics;
* collections;
* LINQ;
* exception handling;
* SOLID;
* patterns;
* UML;
* testing;
* refactoring.

## 15. Чому проєкт готовий до релізу?

Проєкт готовий до релізу тому що:

* build проходить успішно;
* tests проходять успішно;
* CI працює;
* документація актуальна;
* структура проєкту стабільна.
