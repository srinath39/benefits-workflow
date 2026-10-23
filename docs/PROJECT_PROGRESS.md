# Project Progress — Benefits Workflow Management

> Last context update: 2026-10-22. Source code and local API behavior were verified for the progress recorded below.

## Status snapshot
- Learning position: Day 4 of an 18-day intensive plan; centralized API exception handling is implemented and verified.
- Day 1 C# fundamentals: completed in lessons (console eligibility exercise, types, control flow, methods, arrays, validation, `const`/`readonly`).
- Day 2 OOP/API foundations: completed in lessons (domain entity, DTO, services, DI, controller, workflow endpoints).
- Day 3 LINQ: completed exercises (`List<T>`, `Where`, `FirstOrDefault`, `Any`, `OrderBy`, `OrderByDescending`, `Count`, `Sum`, `Select`, DTO projection).
- Day 3 React dashboard integration: implemented and browser-verified against the backend directly, without a Vite proxy. Statistics and request-list failures are handled independently; a simulated request-list failure displayed a dismissible alert while statistics remained visible.
- Backend build: `dotnet build backend\BenefitsWorkflow.slnx --no-restore` succeeded with 0 warnings and 0 errors.
- Frontend verification: `npm run build` and `npm run lint` succeeded in `frontend/`.
- CORS verification: the allowed Vite origin received `Access-Control-Allow-Origin`; an OPTIONS preflight returned 204 with requested method/header; an unrelated origin received no CORS allow-origin header.
- Frontend API URL configuration: `VITE_API_BASE_URL` is set in the local `frontend/.env`, which is ignored by `frontend/.gitignore`; the frontend reads it through Vite's `import.meta.env`.
- API exception handling: `KeyNotFoundException` maps to 404, `ArgumentException` to 400, `InvalidOperationException` to 409, and unexpected exceptions to a generic 500 Problem Details response with server-side error logging.
- Exception handling verification: the solution built successfully in an isolated output directory; live HTTP requests verified 404 for a missing request, 201 for valid creation, 409 for approval before review, and 400 for invalid applicant age. Error responses use `application/problem+json` and contain a trace ID.
- Database: not yet connected; temporary in-memory storage.

## Relevant repository layout
```
benefits-workflow/
├── frontend/                          # React + Vite + Tailwind
│   └── src/
│       ├── Services/benefitRequestService.js
│       ├── App.jsx
│       ├── index.css
│       └── main.jsx
└── backend/
    ├── BenefitsWorkflow.slnx
    └── src/
        ├── BenefitsWorkflow.Api/         # Controllers, Middleware, Program.cs
        ├── BenefitsWorkflow.Application/ # DTOs, Interfaces, Services
        ├── BenefitsWorkflow.Domain/      # Entities, Enums, Exceptions
        ├── BenefitsWorkflow.Infrastructure/ # Data, Repositories, Migrations
        └── BenefitsWorkflow.Playground/
```

## Domain model and business rules
- `BenefitRequest`: RequestId, ApplicantName, Age, MonthlySalary, Status, optional Approval.
- Constructor checks nonblank name, age >=18 (practice-only assumption), nonnegative salary.
- `AssignRequestId` only once; `UpdateAge` validates age.
- `StartReview()` allowed only from Submitted.
- `Approve()` and `Reject()` allowed only from UnderReview.
- Enum `EnumRequestStatus`: Submitted, UnderReview, Rejected, Approved (defined in `BenefitsWorkflow.Domain/Entities/EnumRequesStatus.cs`).
- A static `TotalRequests` field existed but was not maintained; dashboard counts should be computed from stored requests, not this field.

## Application and API implementation discussed
- `CreateRequestDto`: ApplicantName, Age, MonthlySalary.
- `RequestResponseDto`: RequestId, ApplicantName, Age, MonthlySalary, Status string.
- `RequestStatisticsDto`: TotalRequests, SubmittedRequests, UnderReviewRequests, ApprovedRequests, RejectedRequests.
- `IBenefitRequestService` / `BenefitRequestService` methods include `CreateRequest`, `GetAllRequests`, `GetApprovedRequests`, `StartReview`, `ApproveReview`, and `GetStatistics`.
- Service holds `List<BenefitRequest> _requests` and `_nextRequestId`; maps to response DTO using `Select` / mapping helper.
- Temporary DI: `AddSingleton<IBenefitRequestService, BenefitRequestService>()` to retain in-memory records while API is running; not suitable as a production concurrent data store.

| HTTP | Route | Reported status |
|---|---|---|
| POST | `/api/BenefitRequests` | Tested in Swagger |
| GET | `/api/BenefitRequests` | Implemented as list route; browser verified against backend directly |
| GET | `/api/BenefitRequests/{id}` | Implemented; missing-ID response verified as 404 |
| PUT | `/api/BenefitRequests/{id}/start-review` | Tested in Swagger |
| PUT | `/api/BenefitRequests/{id}/approve` | Tested in Swagger |
| GET | `/api/BenefitRequests/approved` | Tested in Swagger |
| GET | `/api/BenefitRequests/statistics` | Browser verified through Vite proxy |

## Known gaps and cautions
- The frontend uses Tailwind CSS v4 through its Vite plugin and calls `http://localhost:5189` directly. Vite has no API proxy configured. The ASP.NET Core Development CORS policy permits only the local Vite origins on ports 5173 and 5174 (localhost and 127.0.0.1).
- Direct local HTTP was selected because the installed localhost HTTPS development certificate is not trusted in this environment. Use HTTPS and an appropriate production origin policy outside local development; do not send credentials over the local HTTP setup.
- The dashboard loads statistics and the request list independently with `Promise.allSettled`, shows a dismissible alert and retry action for list failures, and includes loading, error, and empty states.
- The request table does not display salary. The existing API response DTO still contains salary, so authorization and data minimization need review before exposing the API outside local development.
- The API base URL can be overridden with `VITE_API_BASE_URL`; deployment must supply an HTTPS API URL and configure the corresponding allowed frontend origin.
- Vite `VITE_` variables are compiled into browser code and are not secret; only put non-sensitive configuration such as the API URL there.
- Swagger test requests are lost when the API process restarts.
- Rejection API, editing, withdraw, filtering/pagination, DB, auth, audit, uploads, notifications, tests, deployment: planned, not verified.
- Unexpected server errors return a generic message; detailed exceptions are logged by the API handler.
- POST now points `CreatedAtAction` to the get-by-ID route.
- Concurrency, sensitive field exposure and proper role checks must be addressed before production use.

## Immediate next task
1. Continue Day 4 by exploring nullable reference types and model validation.
2. Add focused automated tests for domain transitions and API error contracts when the test project is introduced.
3. Review HTTPS/CORS configuration and sensitive response fields before exposing the API outside local development.

## Definition of done for a feature
- Compiles / lints as applicable.
- Tested using Swagger, automated tests, or the running UI as appropriate.
- Respects current domain rules and architecture.
- Loading, empty, failure and invalid-input cases considered.
- Progress file updated with **actual** results.

## Working style
Teach concept -> explain why -> compare to Java if useful -> tiny exercise -> review answer -> implement one feature -> test -> record progress. React is 1 hour at the end of each day after backend work.
