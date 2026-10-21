# Project Progress — Benefits Workflow Management

> Last context update: 2026-10-21. Source code and the local dashboard integration were inspected and verified for the progress recorded below.

## Status snapshot
- Learning position: Day 3 of an 18-day intensive plan; dashboard integration is now verified.
- Day 1 C# fundamentals: completed in lessons (console eligibility exercise, types, control flow, methods, arrays, validation, `const`/`readonly`).
- Day 2 OOP/API foundations: completed in lessons (domain entity, DTO, services, DI, controller, workflow endpoints).
- Day 3 LINQ: completed exercises (`List<T>`, `Where`, `FirstOrDefault`, `Any`, `OrderBy`, `OrderByDescending`, `Count`, `Sum`, `Select`, DTO projection).
- Day 3 React dashboard integration: implemented and verified in the browser against the local API. Statistics and request-list failures are handled independently; a simulated request-list failure displayed a dismissible alert while statistics remained visible.
- Backend build: `dotnet build backend\BenefitsWorkflow.slnx --no-restore` succeeded with 0 warnings and 0 errors.
- Frontend verification: `npm run build` and `npm run lint` succeeded in `frontend/`.
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
| GET | `/api/BenefitRequests` | Implemented as list route; browser verified through Vite proxy |
| GET | `/api/BenefitRequests/{id}` | Implemented |
| PUT | `/api/BenefitRequests/{id}/start-review` | Tested in Swagger |
| PUT | `/api/BenefitRequests/{id}/approve` | Tested in Swagger |
| GET | `/api/BenefitRequests/approved` | Tested in Swagger |
| GET | `/api/BenefitRequests/statistics` | Browser verified through Vite proxy |

## Known gaps and cautions
- The frontend uses Tailwind CSS v4 through its Vite plugin and a Vite development proxy to the API's configured HTTP URL (`http://localhost:5189`); this avoids browser CORS and HTTPS certificate issues during local development.
- The dashboard loads statistics and the request list independently with `Promise.allSettled`, shows a dismissible alert and retry action for list failures, and includes loading, error, and empty states.
- The request table does not display salary. The existing API response DTO still contains salary, so authorization and data minimization need review before exposing the API outside local development.
- The Vite proxy is development-only; deployment will need an API base URL/reverse-proxy configuration.
- Swagger test requests are lost when the API process restarts.
- Rejection API, editing, withdraw, filtering/pagination, DB, auth, audit, uploads, notifications, tests, deployment: planned, not verified.
- Global exception mapping for not found / invalid transitions is pending.
- POST now points `CreatedAtAction` to the get-by-ID route.
- Concurrency, sensitive field exposure and proper role checks must be addressed before production use.

## Immediate next task
1. Continue Day 4: learn exception flow and predictable HTTP error responses (400/404/409).
2. Add API error handling and test missing requests and invalid status transitions.
3. Configure a production API route before deployment; the current Vite proxy is development-only.

## Definition of done for a feature
- Compiles / lints as applicable.
- Tested using Swagger, automated tests, or the running UI as appropriate.
- Respects current domain rules and architecture.
- Loading, empty, failure and invalid-input cases considered.
- Progress file updated with **actual** results.

## Working style
Teach concept -> explain why -> compare to Java if useful -> tiny exercise -> review answer -> implement one feature -> test -> record progress. React is 1 hour at the end of each day after backend work.
