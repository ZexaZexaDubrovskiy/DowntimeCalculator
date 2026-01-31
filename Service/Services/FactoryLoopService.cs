using DowntimeCalculator.ApplicationLayout.UseCases.ChangeFactorySettings;
using DowntimeCalculator.DAL;
using Timer = System.Windows.Forms.Timer;

namespace DowntimeCalculator.Service.Services;

/// <summary>
/// Представляет сервис запуска(зацикливания) приложения.
/// </summary>
public sealed class FactoryLoopService
{
    private readonly CancellationToken _cancellationToken;
    private readonly MovementServices _movement;
    private readonly Timer _moveTimer = new() { Interval = 50 };
    private readonly DowntimeRepository _repository;
    private readonly Timer _spawnTimer = new() { Interval = 2000 };
    private EventHandler eventHandler;

    /// <summary>
    /// Инициализирует экземпляр <see cref="FactoryLoopService" />.
    /// </summary>
    /// <param name="repository"><see cref="DowntimeRepository" />.</param>
    /// <param name="movement"><see cref="MovementServices" />.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public FactoryLoopService(DowntimeRepository repository, MovementServices movement,
        CancellationToken cancellationToken)
    {
        _repository = repository;
        _movement = movement;
        _cancellationToken = cancellationToken;
        _moveTimer.Tick += (_, _) => _movement.Tick();

        eventHandler = (_, _) =>
            _movement.CreateUnit(100, 100, 100, new Size(900, 600));

        _spawnTimer.Tick += eventHandler;
    }

    /// <summary>
    /// Старт таймера.
    /// </summary>
    public void Start()
    {
        _moveTimer.Start();
        _spawnTimer.Start();
    }

    /// <summary>
    /// Остановка таймера.
    /// </summary>
    public void Stop()
    {
        _moveTimer.Stop();
        _spawnTimer.Stop();
    }

    /// <summary>
    /// Очищение списка простоев.
    /// </summary>
    public async void ResetDowntime()
    {
        await _repository.RemoveAllAsync(_cancellationToken);
    }

    /// <summary>
    /// Обновление настроек для создания УЕ.
    /// </summary>
    /// <param name="settings"><see cref="ChangeFactorySettingInput" />.</param>
    public void UpdateSettings(ChangeFactorySettingInput settings)
    {
        _movement.SpawnTime = settings.DeltaTime;
        _spawnTimer.Stop();
        _spawnTimer.Tick -= eventHandler;
        eventHandler = (_, _) =>
            _movement.CreateUnit(
                settings.AccountUnitSpeed,
                settings.AccountUnitWidth,
                settings.AccountUnitHeight,
                new Size(900, 600)
            );
        _spawnTimer.Tick += eventHandler;
        _spawnTimer.Interval = Math.Max(1, (int)(settings.DeltaTime * 1000));
        _spawnTimer.Start();
    }
}