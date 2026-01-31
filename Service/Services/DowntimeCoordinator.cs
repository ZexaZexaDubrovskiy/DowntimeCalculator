namespace DowntimeCalculator.Service.Services;

/// <summary>
/// TODO.
/// </summary>
public class DowntimeCoordinator
{
    /// <summary>
    /// Todo
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