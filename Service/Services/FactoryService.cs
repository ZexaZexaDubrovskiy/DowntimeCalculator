using DowntimeCalculator.DAL;
using DowntimeCalculator.Service.UI;

namespace DowntimeCalculator.Service.Services;

/// <summary>
/// Представляет сервис по типу DI.
/// </summary>
public static class FactoryService
{
    /// <summary>
    /// Запуск приложения.
    /// </summary>
    /// <param name="form">Форма приложения.</param>
    /// <param name="timeProvider"><see cref="TimeProvider" />.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    public static FactoryLoopService Create(
        Form form,
        TimeProvider timeProvider,
        CancellationToken cancellationToken)
    {
        var scene = SceneFactory.Create(form);

        var db = new ApplicationDbContext();
        var repository = new DowntimeRepository(db);
        var downtimeService = new DowntimeService(
            timeProvider.GetUtcNow().DateTime,
            repository,
            timeProvider
        );

        var movementService = new MovementServices(
            scene.Quarto, 0.2
        );

        movementService.AccountUnitCreated += scene.Add;

        var coordinator = new DowntimeCoordinator(
            movementService,
            downtimeService,
            cancellationToken
        );

        return new FactoryLoopService(repository, movementService, cancellationToken);
    }
}