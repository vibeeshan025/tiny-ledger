# Teya.TinyLedger.Api

I am using .NET and C# to construct the app, but i do believe the concepts can be easily translated to other languages like Java / Kotlin.
The architecture is based on DDD, CQRS and Onion Project Structure

---

## Overview

- **Domain Layer**: Holds all business rules and logic using DDD concepts. 
- **Infrastructure**: Contains data storage, repositories, and external integrations.
- **API**: A lightweight project to hold the controller and API definitions.
- **Application**: Composition Project to to connect all structure.
- **Testing**: Testing Project

---

## Prerequisites

1. **.NET 9 SDK**
    - Download from [Microsoft’s .NET website](https://dotnet.microsoft.com/download/dotnet).
    - Verify via `dotnet --version` → Should display `9.x.x`.

2. **Git** (Optional)
    - If you prefer to clone repositories.

3. **IDE/Text Editor**
    - Visual Studio Code, Visual Studio 2022 (Preview with .NET 9 support), or another editor.

---

## Building and Running

1. **Acquire the Source**
    - `git clone https://github.com/YourOrg/Teya.TinyLedger.Api.git`
    - Or download the ZIP and unzip.

2. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

3. **Build**
   ```bash
   dotnet build
   ```
   This compiles the code.

4. **Run the API**
   ```bash
   dotnet run
   ```
    - The console output typically shows something like:
      ```
      Now listening on: http://localhost:5000
      Application started...
      ```
    - Visit `http://localhost:5000` in a browser or use a tool (e.g. `curl`, Postman) to access endpoints.

---

## Testing

1. **Navigate to the Test Project**
    - Often found in `Teya.TinyLedger.Tests` (or similar).

2. **Run Tests**
   ```bash
   dotnet test
   ```
    - Builds and runs all tests (unit + integration).

> **Tip for Non-.NET Engineers**:
> - Ensure you have `.NET 9 SDK` installed.
> - `dotnet test` automatically compiles and executes the tests.

---

## Domain-Driven Design (DDD)

- **Entities**: Key objects with an identity (e.g., `Transaction`, `LedgerEntry`).
- **Value Objects**: Immutable objects representing domain concepts (e.g., `Money`, `AccountId`).
- **Aggregates**: Groups of entities/objects forming a transactional boundary.
- **Ubiquitous Language**: Common language shared by domain experts and developers.

DDD keeps business logic centered, preventing “anemic domain” issues and letting us evolve features more naturally.

---

## CQRS

- **Commands (Write Model)**: Operations that change state. Think “create,” “update,” or “delete.”
- **Queries (Read Model)**: Operations that just fetch data.

Splitting read and write logic helps scale and simplify the codebase. Each side can be optimized independently without interference.

---

## Design Decisions

- **Minimal API** in .NET 9
    - Offers concise endpoints and simplified configuration.
- **Test with `WebApplicationFactory<Program>`**
    - Enables high-fidelity integration tests. We replicate the actual application environment within tests.
- **Clear Separation**
    - DDD for handling business concepts, CQRS for splitting read/write concerns, and a straightforward `Program.cs` for hosting.

## Manual Testing of API

- HTTP  http://localhost:5188/swagger/
- HTTPS https://localhost:7072/swagger/


## Closing Thoughts

- **Run and Test**: `dotnet build`, `dotnet run`, and `dotnet test` are your go-to commands.
- **DDD + CQRS**: Helps keep the code modular and business-focused.

We hope this README clarifies how to work