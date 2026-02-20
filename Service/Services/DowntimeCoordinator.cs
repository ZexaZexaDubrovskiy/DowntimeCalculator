namespace DowntimeCalculator.Service.Services;

/// <summary>
/// Представляет сервис для создания простоев.
/// </summary>
public class DowntimeCoordinator
{
    /// <summary>
    /// Инициализирует экземпляр <see cref="DowntimeCoordinator" />.
    /// </summary>
    /// <param name="movement"></param>
    /// <param name="downtimeService"></param>
    /// <param name="token"></param>
    public DowntimeCoordinator(
        MovementServices movement,
        DowntimeService downtimeService,
        CancellationToken token)
    {
        movement.AnyUnitOnQuartoChanged += async anyOnQuarto =>
        {
            if (anyOnQuarto)
            {
                downtimeService.StartDowntime();
            }
            else
            {
                await downtimeService.EndDowntimeAsync(token);
            }
        };
    }
}