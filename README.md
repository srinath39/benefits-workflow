# Copilot setup — Benefits Workflow Management

Copy the included `.github/` and `docs/` directories into the **root** of your existing `benefits-workflow` repository. Do not replace your existing application code.

## Expected layout
```
benefits-workflow/
  .github/copilot-instructions.md
  docs/LEARNING_ROADMAP.md
  docs/PROJECT_PROGRESS.md
  backend/
  frontend/
```

In VS Code, open the **repository root** folder, sign in to GitHub Copilot, and open Copilot Chat. Ensure repository instruction files are enabled in VS Code settings if applicable.

## First message to Copilot
> Read `.github/copilot-instructions.md`, `docs/LEARNING_ROADMAP.md`, and `docs/PROJECT_PROGRESS.md`. Inspect my real backend and React/Vite/Tailwind frontend. Reconcile the progress document with actual code. Tell me what is verified, what is missing, and the smallest next step to finish the live dashboard. Do not change files yet. Teach me concept by concept and wait for my confirmation.

After each verified feature, ask Copilot to update `docs/PROJECT_PROGRESS.md`. Keep `LEARNING_ROADMAP.md` as the plan, and use the source code as the source of truth for implementation.
