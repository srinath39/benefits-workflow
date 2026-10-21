# Complete C# & .NET Learning Roadmap — One Enterprise Application

**Project:** Benefits Workflow Management Application  
**Duration:** 18 days × 6 hours/day = 108 hours; 5 hours/day C#/.NET backend and building (90 hours), 1 hour/day React (18 hours).  
**Starting point:** Days 1–2 completed; Day 3 LINQ complete; dashboard integration next.  
**Status note:** This is a target curriculum, not evidence that every feature is already implemented. See `PROJECT_PROGRESS.md` for confirmed work.

## 1. Learning philosophy and technology
Learn every major C#/.NET concept by building one connected feature in a real application rather than isolated mini-projects. Keep and evolve existing code.

- Backend: C# 14, .NET 10, ASP.NET Core Web API, LINQ.
- Frontend: React.js + Vite + Tailwind CSS (JavaScript).
- Database: SQL Server + Entity Framework Core.
- Architecture: modular layered backend — Domain, Application, Infrastructure, API; a separate Playground project for experiments.
- Security: authentication, authorization, role-based access.
- Quality: validation, exception handling, tests, logging, health checks.
- Deployment: Docker, environment configuration, deployment workflow.
- Start as one modular application, not microservices.

## 2. End-to-end product vision
An employee submits a benefit request; the system validates and stores it; a reviewer checks eligibility; a manager approves or rejects it; the system records changes and updates the dashboard and notifications.

**Business flow:**
1. Employee submits benefit request (form validation, DTO, API).
2. Request is persisted (EF Core, SQL Server, transactions).
3. Reviewer evaluates eligibility (domain rules, services, state transitions).
4. Manager approves or rejects (authorization, workflow, audit trail).
5. Dashboard and notifications reflect changes (React, LINQ, reporting, background processing).

**Target functional modules:**
| Module | Features |
|---|---|
| Dashboard | Request counts, charts, recent activity |
| Benefit Requests | Create, view, edit, withdraw, search |
| Workflow | Submit, review, approve, reject, reassign |
| Benefits Catalog | Benefit types, eligibility rules, limits |
| Users & Roles | Employee, reviewer, manager, admin |
| Documents | Upload/download supporting files |
| Audit Trail | Who changed what, when, why |
| Notifications | Status updates and reminders |
| Reports | Filtering, pagination, CSV export |
| Administration | Manage benefits, users, configuration |

Scope is ambitious; essential foundation is prioritized and advanced features are stretch goals.

## 3. Detailed 18-day concept-to-feature curriculum

### Phase 1 — C# fundamentals and application foundations

**Day 1 — C# basics (completed in learning sessions)**
- Concepts: C# vs .NET vs ASP.NET Core, program entry point/top-level statements, variables, numeric and string types, operators, conditions, loops, arrays, methods, scope, user input, parsing and validation, `const` vs `readonly`.
- Feature: console-based benefit eligibility calculator.
- Verification: run console examples; validate invalid input; explain type conversions.

**Day 2 — OOP and API foundations (completed in learning sessions)**
- Concepts: classes/objects, constructors, properties, encapsulation, access modifiers, inheritance, overriding/runtime polymorphism, abstract classes, interfaces, static vs instance, enums, reference vs value types, struct vs class, composition, DTOs, service interfaces, DI and controllers.
- Feature: `BenefitRequest` domain entity with validation/state transitions, create/list requests API, initial review/approval workflow.
- Verification: Swagger POST/GET and state transition behavior; keep business rules in domain.

**Day 3 — Collections, LINQ and dashboard (LINQ lessons completed; frontend pending)**
- Concepts: `List<T>`, generics, `Where`, `FirstOrDefault`, `Any`, `OrderBy`, `OrderByDescending`, `Count`, `Sum`, `Select`, DTO projection, LINQ chaining, React `fetch`, `useEffect`, `useState`, `Promise.all`.
- Features: approved requests endpoint, dashboard statistics API, live React/Tailwind cards and request table.
- Verification: Swagger `/approved` and `/statistics`; browser shows real data, loading/error/empty states.

### Phase 2 — Strong C# and production-style APIs

**Day 4 — Exceptions and HTTP semantics**
- Concepts: nullable reference types, exception flow, custom exceptions, error handling middleware, problem details, HTTP 400/404/409 and API contracts.
- Features: global exception handler; request-by-ID endpoint; predictable error responses for invalid transitions and missing requests.
- Verification: negative Swagger tests; no unhandled 500 for expected domain failures.

**Day 5 — Asynchronous programming**
- Concepts: `async`/`await`, `Task<T>`, `CancellationToken`, `HttpClient`, nonblocking I/O, concurrency fundamentals and exception propagation.
- Feature: async service contracts and simulated external benefit eligibility check.
- Verification: asynchronous behavior, timeout/cancellation and failure tests; avoid fake async around in-memory work.

**Day 6 — API contracts and validation**
- Concepts: model binding, Data Annotations, DTO validation, REST route design, DI lifetimes, input constraints and response codes.
- Features: validated create/edit endpoints, reject and withdraw operations; UI form validation and errors.
- Verification: valid/invalid payloads and illegal transitions tested.

### Phase 3 — Database and persistence

**Day 7 — SQL Server and EF Core foundations**
- Concepts: relational design, primary/foreign keys, relationships, `DbContext`, provider configuration, migrations, connection strings, secure configuration.
- Feature: persist benefit requests in SQL Server; migrate away from temporary in-memory list.
- Verification: data remains after API restart; migration can recreate schema.

**Day 8 — EF Core CRUD and tracking**
- Concepts: CRUD, `SaveChangesAsync`, change tracking, `AsNoTracking`, projections, LINQ translation, `IQueryable` vs `IEnumerable`.
- Feature: DB-backed request create/retrieve/edit and permitted delete operations.
- Verification: inspect generated SQL and validate persistence; do not delete audit-sensitive requests without explicit policy.

**Day 9 — Relationships and transactions**
- Concepts: one-to-many navigation properties, joins, transactions, indexes, query performance, eager loading/N+1 pitfalls.
- Features: benefits catalog, request status history and related records.
- Verification: relational integrity and atomic updates.

### Phase 4 — Enterprise workflow and security

**Day 10 — SOLID and configurable rules**
- Concepts: SOLID, interfaces/service boundaries, composition, strategy pattern, domain invariants and testability.
- Feature: configurable benefit eligibility strategies and robust workflow validation.
- Verification: alternate eligibility scenarios without controller changes.

**Day 11 — Authentication**
- Concepts: authentication vs authorization, ASP.NET Core Identity, secure password hashing, JWT bearer authentication, claims and token validation.
- Feature: login and users (registration or seeded test users), protected API routes.
- Verification: authenticated vs unauthenticated access; no hardcoded secrets.

**Day 12 — Roles and auditing**
- Concepts: authorization policies, role-based access, claims, audit logging, transactional state changes.
- Feature: employee/reviewer/manager/admin permissions; audit trail for status changes.
- Verification: permission matrix and recorded actor/time/action.

### Phase 5 — Advanced API features and testing

**Day 13 — Search, filtering and pagination**
- Concepts: query parameters, composed LINQ predicates, server-side sorting, pagination, stable ordering, performance considerations.
- Feature: request table with status/name filters, sort and paging; e.g. `GET /api/BenefitRequests?status=Approved`.
- Verification: consistent paging, invalid query handling, total counts.

**Day 14 — Secure file handling**
- Concepts: `IFormFile`, streams, size/type validation, storage abstraction, secure file names and authorization.
- Feature: upload/download supporting documents.
- Verification: reject invalid files and enforce access controls.

**Day 15 — Automated testing**
- Concepts: xUnit, mocks/fakes, unit vs integration tests, ASP.NET Core test host, dependency injection in tests.
- Feature: test suite for eligibility, state transitions, API endpoints and persistence.
- Verification: repeatable test run with passing results.

### Phase 6 — Production readiness

**Day 16 — Observability and configuration**
- Concepts: structured logging, options pattern, configuration by environment, health checks, caching basics, diagnostics.
- Feature: request logs, health endpoint, dashboard query optimization.
- Verification: logs are actionable and sensitive data is not leaked.

**Day 17 — Background processing and notifications**
- Concepts: hosted/background services, email integration, scheduling fundamentals, retries and idempotency.
- Feature: status notifications and reminder processing.
- Verification: prevent duplicate notifications; safe failure/retry behavior.

**Day 18 — Deployment and final integration**
- Concepts: Docker, environment variables, secrets, release configuration, deployment checks and security review.
- Feature: containerized full-stack app and end-to-end demo.
- Verification: clean build, automated tests, complete employee-to-manager workflow and deployment notes.

## 4. Parallel React plan (1 hour at the end of each day)
| Days | React + Tailwind focus | Backend connection |
|---|---|---|
| 1–3 | Setup, dashboard layout, statistics cards, request table | Create/list, stats |
| 4–6 | Request detail, create/edit forms, validation messages, approval actions | Workflow/validation APIs |
| 7–9 | Persistent data views, catalog, request history | EF Core/SQL Server |
| 10–12 | Eligibility display, login, protected routes, role-aware navigation | Rules/auth/roles |
| 13–15 | Search, filters, pagination, file uploads | Query/file APIs |
| 16–18 | Notifications UI, accessibility, polish, loading states | Notifications/production |

## 5. Architecture and responsibilities
```
React (pages/components/hooks/API services)
       | HTTP + JSON
ASP.NET Core API (controllers, middleware, auth)
       | application calls
Application (use cases, DTOs, interfaces, mapping)
       | domain rules + abstraction contracts
Domain (entities, enums, invariants, business rules)

Infrastructure (implements persistence/integration interfaces)
       | EF Core / external services
SQL Server / external providers
```
**Important:** This diagram is a runtime/collaboration overview, not a license for Domain to reference Infrastructure. Respect inward dependencies and keep infrastructure adapters behind abstractions.

## 6. Cross-cutting C#/.NET knowledge checklist
| Category | Topics |
|---|---|
| Language | Generics, delegates, lambdas, records, pattern matching, nullable types, extension methods |
| OOP/design | Interfaces, abstraction, composition, SOLID, strategy, DI |
| Runtime | GC, managed memory, value/reference semantics, `IDisposable`, `using` |
| Async | `Task`, `async`/`await`, cancellation, concurrency, exception propagation |
| ASP.NET Core | Middleware, routing, controllers, model binding, validation, DI lifetimes |
| Data | LINQ, EF Core, migrations, tracking, transactions, indexes, query optimization |
| Security | AuthN, AuthZ, JWT, roles, claims, secret management |
| Quality | Unit/integration tests, mocking, debugging, logging |
| Deployment | Config, Docker, health checks, environment management |

Advanced memory management, delegates, generics, concurrency and performance require deeper study beyond 18 days.

## 7. Final end-to-end feature checklist
- [ ] Live dashboard statistics and requests table
- [ ] Create and view benefit requests
- [ ] Review, approve, reject and withdraw requests
- [ ] SQL Server persistence with EF Core
- [ ] Benefit types and eligibility rules
- [ ] User authentication and role-based authorization
- [ ] Search, sorting and pagination
- [ ] Request history and audit trail
- [ ] Supporting document upload/download
- [ ] Notifications and reminders
- [ ] Unit and integration tests
- [ ] Deployable configuration / Docker / final demo

**Note:** Several backend subfeatures have been implemented already; checkboxes refer to completed **end-to-end** capabilities and should only be checked after verification.

## 8. Learning/implementation cycle for every concept
1. **Explain** what the concept is and why it exists.
2. **Compare** with Java where useful.
3. **Demonstrate** a small syntax/code example.
4. **Exercise**: ask learner to predict output or implement a small snippet.
5. **Review** the learner's response before advancing.
6. **Implement** the related Benefits Workflow feature in the existing repository.
7. **Verify** through Swagger, tests or running React UI.
8. **Record** actual progress in `docs/PROJECT_PROGRESS.md`.

Do not mark a feature complete merely because generated code exists.

## 9. Immediate sequence
1. Finish Day 3: inspect current frontend, verify Vite/Tailwind, API URLs, HTTPS/CORS; connect React to GET `/api/BenefitRequests` and `/statistics`; render five real cards and request table with loading/error/empty states.
2. Start Day 4: exceptions, middleware, custom domain errors, proper 404/400/409, GET by ID.
3. Progress toward SQL Server/EF Core persistent storage, avoiding premature broad rewrites.

## 10. Scope and schedule risk
108 hours is not enough for mastery of all listed topics plus production-hardening of every module. Prioritize a coherent working vertical slice and Days 1–12 foundation; treat uploads, notifications, caching, advanced reports and deployment refinements as flexible scope. Use the real repository and tests to decide what is truly complete.
