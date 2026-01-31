using DowntimeCalculator.Models;

namespace DowntimeCalculator.DAL;

/// <summary>
/// Представляет репозиторий для простоев.
/// </summary>
public interface IDowntimeRepository
{
    #region Overridable
    /// <summary>
    /// Добавляет простой.
    /// </summary>
    /// <param name="downtime">Простой.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns><see cref="Task" />.</returns>
    Task AddAsync(Downtime downtime, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет все простои.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns><see cref="Task" />.</returns>
    Task RemoveAllAsync(CancellationToken cancellationToken);
    #endregion
}