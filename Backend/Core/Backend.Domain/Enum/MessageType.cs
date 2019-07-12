namespace Backend.Domain.Enum
{
    public enum MessageType
    {
        PrivateChat,
        GroupChat,
        Notification,
    }

    public enum MessageContentType
    {
        Text = 1,
        File = 2
    }
}
