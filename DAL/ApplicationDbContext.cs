namespace DowntimeCalculator.DAL;

/// <summary>
/// Представляет контекст для работы с данными.
/// </summary>
public class ApplicationDbContext
{
    #region .ctor
    /// <summary>
    /// Инициализирует экземпляр <see cref="ApplicationDbContext" />.
    /// </summary>
    public ApplicationDbContext()
    {
        DowntimeFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "downtime.json");
        if (!File.Exists(DowntimeFilePath))
        {
            File.WriteAllText(DowntimeFilePath, "[]");
        }
    }
    #endregion

    #region Properties
    /// <summary>
    /// Предоставляет путь к простоям.
    /// </summary>
    public string DowntimeFilePath { get; }
    #endregion
}