import { useCallback, useEffect, useState } from 'react'
import { getBenefitRequests, getRequestStatistics } from './Services/benefitRequestService.js'

const statisticCards = [
  { key: 'totalRequests', label: 'Total requests', color: 'border-slate-300' },
  { key: 'submittedRequests', label: 'Submitted', color: 'border-blue-400' },
  { key: 'underReviewRequests', label: 'Under review', color: 'border-amber-400' },
  { key: 'approvedRequests', label: 'Approved', color: 'border-emerald-400' },
  { key: 'rejectedRequests', label: 'Rejected', color: 'border-rose-400' },
]

const statusStyles = {
  Submitted: 'bg-blue-50 text-blue-700',
  UnderReview: 'bg-amber-50 text-amber-700',
  Approved: 'bg-emerald-50 text-emerald-700',
  Rejected: 'bg-rose-50 text-rose-700',
}

function fetchDashboardData() {
  return Promise.allSettled([
    getRequestStatistics(),
    getBenefitRequests(),
  ])
}

function App() {
  const [statistics, setStatistics] = useState(null)
  const [requests, setRequests] = useState([])
  const [loading, setLoading] = useState(true)
  const [statisticsError, setStatisticsError] = useState('')
  const [requestsError, setRequestsError] = useState('')
  const [notification, setNotification] = useState('')

  const applyDashboardData = useCallback(([statisticsResult, requestsResult]) => {
    if (statisticsResult.status === 'fulfilled') {
      setStatistics(statisticsResult.value)
      setStatisticsError('')
    } else {
      setStatisticsError('Statistics could not be loaded. Please try again.')
    }

    if (requestsResult.status === 'fulfilled') {
      setRequests(requestsResult.value)
      setRequestsError('')
      setNotification('')
    } else {
      const message = 'The request list could not be loaded. Please try again.'
      setRequestsError(message)
      setNotification(message)
    }

    setLoading(false)
  }, [])

  const loadDashboard = useCallback(() => {
    fetchDashboardData().then(applyDashboardData)
  }, [applyDashboardData])

  const refreshDashboard = () => {
    setLoading(true)
    setNotification('')
    loadDashboard()
  }

  useEffect(() => {
    let active = true

    fetchDashboardData().then((results) => {
      if (active) {
        applyDashboardData(results)
      }
    })

    return () => {
      active = false
    }
  }, [applyDashboardData])

  return (
    <main className="mx-auto min-h-screen max-w-7xl px-4 py-8 sm:px-6 lg:px-8">
      <header className="mb-8 flex flex-col gap-4 sm:flex-row sm:items-end sm:justify-between">
        <div>
          <p className="mb-2 text-sm font-semibold uppercase tracking-[0.16em] text-indigo-600">
            Benefits workflow
          </p>
          <h1 className="text-3xl font-bold tracking-tight text-slate-900 sm:text-4xl">
            Request dashboard
          </h1>
          <p className="mt-2 text-slate-600">
            A live overview of benefit requests and their current status.
          </p>
        </div>
        <button
          type="button"
          onClick={refreshDashboard}
          disabled={loading}
          className="rounded-lg border border-slate-300 bg-white px-4 py-2 text-sm font-semibold text-slate-700 shadow-sm transition hover:bg-slate-50 disabled:cursor-not-allowed disabled:opacity-60"
        >
          {loading ? 'Refreshing…' : 'Refresh'}
        </button>
      </header>

      {notification && (
        <div
          role="alert"
          className="mb-6 flex items-start justify-between gap-4 rounded-lg border border-rose-200 bg-rose-50 px-4 py-3 text-sm text-rose-800 shadow-sm"
        >
          <p>{notification}</p>
          <button
            type="button"
            onClick={() => setNotification('')}
            aria-label="Dismiss error notification"
            className="font-semibold text-rose-800 hover:text-rose-950"
          >
            Dismiss
          </button>
        </div>
      )}

      <section aria-label="Request statistics" className="mb-8">
        <div className="mb-4 flex items-center justify-between">
          <h2 className="text-lg font-semibold text-slate-900">Statistics</h2>
          {statisticsError && (
            <p role="status" className="text-sm text-rose-700">
              {statisticsError}
            </p>
          )}
        </div>
        <div className="grid grid-cols-1 gap-4 sm:grid-cols-2 lg:grid-cols-5">
          {statisticCards.map((card) => (
            <article
              key={card.key}
              className={`rounded-xl border-l-4 ${card.color} bg-white p-5 shadow-sm ring-1 ring-slate-200`}
            >
              <p className="text-sm font-medium text-slate-500">{card.label}</p>
              <p className="mt-2 text-3xl font-bold tabular-nums text-slate-900">
                {loading && !statistics ? '…' : (statistics?.[card.key] ?? '—')}
              </p>
            </article>
          ))}
        </div>
      </section>

      <section aria-labelledby="requests-heading" className="overflow-hidden rounded-xl bg-white shadow-sm ring-1 ring-slate-200">
        <div className="flex flex-col gap-2 border-b border-slate-200 px-5 py-4 sm:flex-row sm:items-center sm:justify-between">
          <div>
            <h2 id="requests-heading" className="text-lg font-semibold text-slate-900">
              Benefit requests
            </h2>
            <p className="text-sm text-slate-500">
              {requestsError ? 'Request data is unavailable.' : `${requests.length} request${requests.length === 1 ? '' : 's'}`}
            </p>
          </div>
        </div>

        {loading && requests.length === 0 ? (
          <p role="status" className="px-5 py-10 text-center text-sm text-slate-500">
            Loading benefit requests…
          </p>
        ) : requestsError ? (
          <div className="px-5 py-10 text-center">
            <p className="text-sm text-rose-700">{requestsError}</p>
            <button
              type="button"
              onClick={refreshDashboard}
              className="mt-3 text-sm font-semibold text-indigo-700 hover:text-indigo-900"
            >
              Try again
            </button>
          </div>
        ) : requests.length === 0 ? (
          <p className="px-5 py-10 text-center text-sm text-slate-500">
            No benefit requests have been submitted yet.
          </p>
        ) : (
          <div className="overflow-x-auto">
            <table className="min-w-full divide-y divide-slate-200 text-left">
              <thead className="bg-slate-50">
                <tr>
                  <th scope="col" className="px-5 py-3 text-xs font-semibold uppercase tracking-wide text-slate-500">Request ID</th>
                  <th scope="col" className="px-5 py-3 text-xs font-semibold uppercase tracking-wide text-slate-500">Applicant</th>
                  <th scope="col" className="px-5 py-3 text-xs font-semibold uppercase tracking-wide text-slate-500">Status</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100">
                {requests.map((request) => (
                  <tr key={request.requestId} className="hover:bg-slate-50">
                    <td className="whitespace-nowrap px-5 py-4 text-sm font-medium text-slate-700">
                      #{request.requestId}
                    </td>
                    <td className="whitespace-nowrap px-5 py-4 text-sm text-slate-900">
                      {request.applicantName}
                    </td>
                    <td className="whitespace-nowrap px-5 py-4 text-sm">
                      <span className={`inline-flex rounded-full px-2.5 py-1 text-xs font-semibold ${statusStyles[request.status] ?? 'bg-slate-100 text-slate-700'}`}>
                        {request.status}
                      </span>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}
      </section>
    </main>
  )
}

export default App
