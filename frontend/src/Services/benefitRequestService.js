const benefitRequestsUrl = '/api/BenefitRequests'

async function getJson(url) {
  const response = await fetch(url)

  if (!response.ok) {
    throw new Error(`API request failed with status ${response.status}.`)
  }

  return response.json()
}

export function getBenefitRequests() {
  return getJson(benefitRequestsUrl)
}

export function getRequestStatistics() {
  return getJson(`${benefitRequestsUrl}/statistics`)
}
