# USER GUIDE

## WarehouseManagementSystem

## Опис системи

WarehouseManagementSystem — це консольна система для управління складом, товарами та замовленнями.

Система дозволяє:

* додавати товари;
* переглядати склад;
* створювати замовлення;
* працювати з постачальниками;
* тестувати бізнес-логіку;
* зберігати дані у JSON.

## Запуск проєкту

## Вимоги

* .NET SDK 10
* VS Code

## Клонування репозиторію

```bash id="1f2kpo"
git clone https://github.com/valery2024-2024/WarehouseManagementSystem.git
```

## Перехід у папку проєкту

```bash id="91pldx"
cd WarehouseManagementSystem
```

## Збірка проєкту

```bash id="v72lka"
dotnet build
```

## Запуск застосунку

```bash id="z2wq1n"
dotnet run --project src/WarehouseManagementSystem.Console
```

## Запуск тестів

```bash id="u8m1vx"
dotnet test
```

## Основні функції

### Робота з товарами

Користувач може:

* створювати нові товари;
* змінювати кількість;
* переглядати список товарів.

### Робота із замовленнями

Система дозволяє:

* створювати замовлення;
* перевіряти залишки;
* застосовувати бізнес-правила.

## JSON Persistence

Товари автоматично зберігаються у:

```plaintext id="l92smd"
data/products.json
```

## Структура проєкту

```plaintext id="h6w2ja"
src/
tests/
docs/
data/
```

## Тестування

Проєкт містить:

* unit tests;
* integration tests;
* exception tests.

## Git Workflow

Для кожної лабораторної роботи використовується окрема git-гілка.

Приклад:

```plaintext id="y7v9qs"
lab36-testing-and-refactoring
lab37-finalization-and-patterns
```

## Типові команди

### Pull останніх змін

```bash id="m5v2ak"
git pull
```

### Створення нової гілки

```bash id="s0d8ne"
git checkout -b branch-name
```

### Push змін

```bash id="g1pk4m"
git push
```

## Висновок

WarehouseManagementSystem демонструє роботу багатошарової .NET архітектури, persistence layer, repository pattern, strategy pattern та системи тестування.
