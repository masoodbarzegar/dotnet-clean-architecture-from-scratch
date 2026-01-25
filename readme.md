# .NET Project Management  
### Clean Architecture – From Zero to Clean Code

This repository documents a **complete, end-to-end journey of building a .NET application from scratch**, with a strong focus on **Clean Architecture, architectural thinking, and progressive refinement**.

The goal of this project is not just to deliver features, but to **demonstrate how clean, maintainable code is intentionally shaped over time**, starting from nothing and evolving step by step.

---

## 🎯 What This Repository Represents

This project represents my general approach to software development:

- Starting from **zero** (environment, tooling, structure)
- Setting correct architectural direction early
- Introducing abstractions **only when justified**
- Keeping Domain logic independent and protected
- Treating refactoring as part of the design process
- Building systems the way **real production systems evolve**

---

## 🧠 Architectural Philosophy

Instead of starting with a “perfect” architecture, this project follows a **progressive evolution model**:

1. Make the system run
2. Identify responsibilities and boundaries
3. Separate concerns deliberately
4. Push logic inward toward Domain & Application
5. Keep outer layers replaceable (API, UI, persistence)

---

## 🗂️ High-Level Architecture
                    ┌─────────────────────────────┐
                    │        UI (Blazor)          │
                    │  Pages · Components · UX    │
                    └──────────────┬──────────────┘
                                   │ HTTP
                                   ▼
                    ┌─────────────────────────────┐
                    │     API (FastEndpoints)     │
                    │  Routes · Requests · HTTP   │
                    └──────────────┬──────────────┘
                                   │ Calls
                                   ▼
        ┌──────────────────────────────────────────────────┐
        │          Application Layer                       │
        │  Use Cases · Handlers · DTOs · Validation        │
        │  Policies · Orchestration                        │
        └──────────────┬───────────────────────────┬───────┘
                       │ Depends on                 │ Interfaces
                       ▼                            ▲
        ┌─────────────────────────────┐   ┌───────────────────────┐
        │        Domain Layer         │   │   Infrastructure      │
        │  Entities · Business Rules  │   │  EF Core · Repos      │
        │  No Dependencies            │   │  Persistence · DB     │
        └─────────────────────────────┘   └───────────────────────┘

---

## 🧱 Project Evolution Overview

### Phase 0 – Environment & Setup
- WSL / Ubuntu setup
- .NET 8 SDK installation
- No code or commits (environment preparation only)

---

### Phase 1 – Domain First & Minimal Wiring
- Clean Architecture solution structure
- Independent Domain project
- First real Entity (`Project`)
- EF Core + SQLite in Infrastructure
- Minimal API wiring for verification only

---

### Phase 2 – Application Core
- Use case–driven structure
- Repository contracts (interfaces only)
- Real DTOs (not Entity copies)
- Validation owned by Application
- Business rules extracted from handlers

---

### Phase 3 – Infrastructure & Persistence
- EF Core repository implementations
- DbContext isolated in Infrastructure
- Dependency direction strictly enforced
- Infrastructure exposed via DI extensions

---

### Phase 4 – API Layer (FastEndpoints)
- Endpoint-per-use-case structure
- Request / Response contracts
- Validation at API boundary
- Pagination, filtering, sorting
- CancellationToken propagation

---

### Phase 5 – UI Layer (Blazor)
- Blazor UI consuming the API
- Project list with pagination, search, and sorting
- Loading and error states
- Create Project flow with UX states

---

## 🧩 Principles Demonstrated

- Clean Architecture
- Dependency Inversion
- Domain protection
- Progressive refactoring
- Explicit boundaries
- Real-world architectural thinking

---

## 🛠️ Tech Stack

- .NET 8
- ASP.NET Core
- FastEndpoints
- EF Core + SQLite
- Blazor (WASM)
- Dependency Injection

---

## 📌 Status

Active learning & practice project focused on architectural clarity.

---

> This repository reflects **how I think about architecture**, not just final code output.