export enum SubscriptionStatus {
    incomplete = "incomplete",
    incomplete_expired  = "incomplete_expired",
    trialing = "trialing",
    active = "active",
    past_due = "past_due",
    canceled = "canceled",
    unpaid = "unpaid"
}

export enum SubscriptionStatusTranslation {
  incomplete = "SETTINGS.BILLING.INCOMPLETE",
  incomplete_expired  = "SETTINGS.BILLING.INCOMPLETE_EXPIRED",
  trialing = "SETTINGS.BILLING.TRIALING",
  active = "SETTINGS.BILLING.ACTIVE",
  past_due = "SETTINGS.BILLING.PAST_DUE",
  canceled = "SETTINGS.BILLING.CANCELED",
  unpaid = "SETTINGS.BILLING.UNPAID"
}
