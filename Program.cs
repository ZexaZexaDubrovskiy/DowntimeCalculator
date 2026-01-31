namespace DowntimeCalculator;

internal static class Program
{
    #region Private
    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1(TimeProvider.System, CancellationToken.None));
    }
    #endregion
}