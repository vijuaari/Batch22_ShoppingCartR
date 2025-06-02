namespace ShoppingCartR.Utility
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email,string Subject, string htmlMessage);
    }
}
