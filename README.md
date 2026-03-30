# Polyglot Monorepo Demo

A demo monorepo showcasing four languages — **C#**, **Java**, **Python**, and **TypeScript** — all managed by [mise](https://mise.jdx.dev/). Install mise, clone, and go. Everything else is automatic.

## Prerequisites

Only **mise** is required. It will install all runtimes and SDKs for you.

### Linux / macOS

```sh
curl https://mise.run | sh
```

### Windows (PowerShell)

```powershell
irm https://mise.run | iex
```

Then activate mise in your shell — see the [mise docs](https://mise.jdx.dev/getting-started.html) for details.

## Getting Started

```sh
# 1. Clone the repo
git clone <repo-url> && cd polyglot-test

# 2. Trust the mise config and install all toolchains
mise trust && mise install

# 3. Install all project dependencies
mise run setup

# 4. Build everything
mise run build

# 5. Run all tests
mise run test

# 6. Run all apps
mise run run
```

## What Gets Installed

| Tool       | Version | Managed by |
|------------|---------|------------|
| .NET SDK   | 10      | mise       |
| Java JDK   | 25      | mise       |
| Gradle     | latest  | mise       |
| Python     | 3.13    | mise       |
| Node.js    | 24      | mise       |
| TypeScript | ~5.8    | npm        |

## Project Structure

```
polyglot-test/
├── mise.toml                 ← root config: tool versions + orchestration tasks
├── projects/
│   ├── dotnet-app/           ← C# console app + xUnit tests
│   ├── java-app/             ← Java console app + JUnit 5 tests (Gradle)
│   ├── python-app/           ← Python module + pytest tests
│   └── ts-app/               ← TypeScript app + Node built-in test runner
```

## Mise Tasks

### Run everything

| Command          | Description          |
|------------------|----------------------|
| `mise run build` | Build all projects   |
| `mise run test`  | Test all projects    |
| `mise run run`   | Run all projects     |
| `mise run setup` | Install dependencies |

### Per-project tasks

| Command               | Description               |
|-----------------------|---------------------------|
| `mise run dotnet:build` | Build C# project        |
| `mise run dotnet:test`  | Test C# project         |
| `mise run dotnet:run`   | Run C# project          |
| `mise run java:build`   | Build Java project      |
| `mise run java:test`    | Test Java project       |
| `mise run java:run`     | Run Java project        |
| `mise run python:setup` | Install Python deps     |
| `mise run python:test`  | Test Python project     |
| `mise run python:run`   | Run Python project      |
| `mise run ts:install`   | Install TypeScript deps |
| `mise run ts:build`     | Build TypeScript project|
| `mise run ts:test`      | Test TypeScript project |
| `mise run ts:run`       | Run TypeScript project  |

## Cross-Platform Notes

All mise tasks use language-native CLI commands (`dotnet`, `gradle`, `python`, `node`, `npm`) which work identically on Linux, macOS, and Windows. No shell-specific syntax is used.
