using DowntimeCalculator.DAL;
using DowntimeCalculator.Models;

namespace DowntimeCalculator.Service.Services;

/// <summary>
/// Представляет сервис по расчету простоев.
/// </summary>
/// <param name="currentDowntimeStart">Текущее время простоя.</param>
/// <param name="repository"><see cref="IDowntimeRepository" />.</param>
/// <param name="timeProvider"><see cref="TimeProvider" />.</param>
public class DowntimeService(
    DateTime? currentDowntimeStart,
    IDowntimeRepository repository,
    TimeProvider timeProvider)
{
    #region Data
    #region Fields
    private DateTime? _currentDowntimeStart =
        currentDowntimeStart ?? throw new ArgumentNullException(nameof(currentDowntimeStart));

    private readonly IDowntimeRepository
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    private readonly TimeProvider _timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
    #endregion
    #endregion

    #region Public
    /// <summary>
    /// Заканчивает расчет простоя.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task EndDowntimeAsync(CancellationToken cancellationToken)
    {
        if (_currentDowntimeStart == null)
        {
            return;
        }

        var downtime = Downtime.Create(_currentDowntimeStart.Value, timeProvider.GetUtcNow().UtcDateTime);
        _currentDowntimeStart = null;
        await _repository.AddAsync(downtime, cancellationToken);
    }

    /// <summary>
    /// Запускает расчет простоя.
    /// </summary>
    public void StartDowntime()
    {
        if (_currentDowntimeStart != null)
        {
            return;
        }

        _currentDowntimeStart = _timeProvider.GetUtcNow().UtcDateTime;
    }
    #endregion
}