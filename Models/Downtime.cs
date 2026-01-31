using Newtonsoft.Json;

namespace DowntimeCalculator.Models;

/// <summary>
/// Представляет простой.
/// </summary>
public class Downtime
{
    #region .ctor
    /// <summary>
    /// Инициализирует экземпляр <see cref="Downtime" />.
    /// </summary>
    /// <param name="startDateTime">Дата и время начала.</param>
    /// <param name="endDateTime">Дата и время конца.</param>
    /// <param name="duration">Продолжительность.</param>
    [JsonConstructor]
    private Downtime(DateTime startDateTime, DateTime endDateTime, double duration)
    {
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Duration = duration;
        Id = Guid.NewGuid();
    }
    #endregion

    #region Public
    /// <summary>
    /// Создает простой.
    /// </summary>
    /// <param name="startDateTime">Дата и время начала.</param>
    /// <param name="endDateTime">Дата и время конца.</param>
    public static Downtime Create(DateTime startDateTime, DateTime endDateTime)
    {
        return new Downtime(startDateTime, endDateTime, (endDateTime - startDateTime).TotalSeconds);
    }
    #endregion

    #region Properties
    /// <summary>
    /// Предоставляет продолжительность.
    /// </summary>
    public double Duration { get; init; }

    /// <summary>
    /// Предоставляет дату и время конца.
    /// </summary>
    public DateTime EndDateTime { get; init; }

    /// <summary>
    /// Предоставляет идентификатор.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Предоставляет дату и время начала.
    /// </summary>
    public DateTime StartDateTime { get; init; }
    #endregion
}