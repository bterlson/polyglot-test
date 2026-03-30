# Polyglot Monorepo Demo

A demo monorepo showcasing four languages — **C#**, **Java**, **Python**, and **TypeScript** — all managed by [mise](https://mise.jdx.dev/). Install mise, clone, and go. Everything else is automatic.

## Prerequisites

Only **mise** is required. It will install all runtimes and SDKs for you.

### Linux / macOS

```sh
curl https://mise.run | sh
```

### Windows

Install with [Scoop](https://scoop.sh/) (recommended — automatically adds shims to PATH):

```powershell
scoop install mise
```

Or with winget:

```powershell
winget install jdx.mise
```

### Activate mise in your shell

Mise must be activated so it can swap tool versions automatically when you enter a project directory. Add **one** of these to your shell profile:

**Bash** (`~/.bashrc`):
```sh
eval "$(mise activate bash)"
```

**Zsh** (`~/.zshrc`):
```sh
eval "$(mise activate zsh)"
```

**PowerShell** (`$HOME\Documents\PowerShell\Microsoft.PowerShell_profile.ps1`):
```powershell
(&mise activate pwsh) | Out-String | Invoke-Expression
```

**Fish** (`~/.config/fish/config.fish`):
```fish
mise activate fish | source
```

Then restart your terminal.

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

## Troubleshooting

### `mise install` times out downloading Java or Gradle

The JDK download is large and can time out on slower connections. The repo sets `http_timeout = "60s"` in `mise.toml`, but you can increase it further:

```sh
MISE_HTTP_TIMEOUT=120 mise install
```

Or on PowerShell:

```powershell
$env:MISE_HTTP_TIMEOUT="120"; mise install
```

If it keeps failing, try installing the problematic tools individually:

```sh
mise install java
mise install gradle
```

### Gradle fails with "Skipped due to failed dependency"

Gradle requires Java. If Java failed to install, Gradle will be skipped. Fix the Java install first, then re-run `mise install`.
