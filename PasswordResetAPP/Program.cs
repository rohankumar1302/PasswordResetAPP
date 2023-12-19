using System;

class PasswordResetReminder
{
    private DateTime lastPasswordResetDate;

    public PasswordResetReminder(DateTime lastResetDate)
    {
        this.lastPasswordResetDate = lastResetDate;
    }

    public void CheckPasswordResetStatus()
    {
        TimeSpan timeSinceReset = DateTime.Now - lastPasswordResetDate;
        int daysRemaining = 120 - timeSinceReset.Days;

        if (daysRemaining <= 0)
        {
            DisplayFullSecurityPrompt();
            RestrictTaskManagerAccess();
        }
        else if (daysRemaining <= 15)
        {
            DisplayNotification(daysRemaining);
        }
    }

    private void DisplayNotification(int daysRemaining)
    {
        Console.WriteLine($"Password reset reminder: Your password is due for reset in {daysRemaining} days. Would you like to reset it now? (Close to dismiss)");
        Console.WriteLine("It's important to reset your password every 120 days for security reasons.");
        Console.WriteLine("If you need assistance, please contact our support team via the chat interface.");

        // Simulate a link to the support team's chat interface
        Console.WriteLine("Support Chat: https://Demo.com/support-chat");
        // Logic to handle user input to dismiss the prompt
    }

    private void DisplayFullSecurityPrompt()
    {
        Console.WriteLine("Security Alert: Your password reset is overdue. For security reasons, please reset your password immediately.");
        Console.WriteLine("To ensure your account's security, you are required to reset your password now.");

        // Simulate a link to the support team's chat interface
        Console.WriteLine("Support Chat: https://Demo.com/support-chat");
        // Logic to restrict closure of the prompt
    }

    private void RestrictTaskManagerAccess()
    {
        // Logic to restrict Task Manager access
    }
}

class Program
{
    static void Main()
    {
        DateTime lastResetDate = DateTime.Parse("2023-12-19"); // Replace with actual date
        PasswordResetReminder reminder = new PasswordResetReminder(lastResetDate);
        reminder.CheckPasswordResetStatus();
    }
}
