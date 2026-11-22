# WeatherStation

WeatherStation — приложение на WPF для Windows, которое показывает прогноз погоды и ведёт локальный журнал наблюдений. Пользовательские сценарии описаны в [docs/spec.md](docs/spec.md).

## Разработка

- При добавлении функции или изменении зависимостей между слоями сверяйся с [архитектурой проекта](docs/architecture.md).
- Выбранные библиотеки и инструменты описаны в [docs/tooling.md](docs/tooling.md).
- Для ViewModel используй `CommunityToolkit.Mvvm`.
- Если задача ведётся через OpenSpec, сверяй реализацию с требованиями и списком задач соответствующего изменения в `openspec/changes/`.

## Проверка

После каждой задачи, меняющей C#, XAML или конфигурацию сборки, выполни из корня на Windows проверку стиля C#, сборку и тесты. Переходи к следующей команде после успешного завершения предыдущей.

```powershell
dotnet format style WeatherStation.slnx --verify-no-changes --severity info
dotnet build WeatherStation.slnx -c Release
dotnet test --solution WeatherStation.slnx -c Release --no-build
```

В отчёте укажи результаты проверок и причину любого сбоя или блокировки. Сборка и тесты также выполняются в [CI](.github/workflows/ci.yml).

Тестовый проект использует xUnit v3 и Microsoft.Testing.Platform. Для тестов, которым нужен диспетчер WPF, используй `[WpfFact]`.

## Правила коммитов

- Используй Conventional Commits. Формат сообщения — `<тип>(<область>): <краткое описание>`. Область можно опустить.
- Пиши сообщение коммита на английском языке. Достаточно одного короткого заголовка без тела сообщения.
- Единственный автор коммита — пользователь. Используй его имя и email из Git. Не указывай Codex как автора или соавтора и не добавляй строку `Co-authored-by`.

Пример для настройки запуска приложения:

```text
chore(startup): configure WPF startup with the .NET Host
```
