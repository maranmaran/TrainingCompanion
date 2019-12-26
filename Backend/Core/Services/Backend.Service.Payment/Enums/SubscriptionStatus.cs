namespace Backend.Service.Payment.Enums
{
    public enum SubscriptionStatus
    {
        Incomplete,
        Incomplete_Expired,
        Trialing,
        Active,
        Past_Due,
        Canceled,
        Unpaid
    }
}