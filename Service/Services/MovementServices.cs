using DowntimeCalculator.Models;

namespace DowntimeCalculator.Service.Services;

/// <summary>
/// Представляет сервис по передвижению учетных единиц.
/// </summary>
public class MovementServices
{
    /// <summary>
    /// Инициализирует экземпляр <see cref="MovementServices" />.
    /// </summary>
    /// <param name="quarto">Кварто.</param>
    /// <param name="deltaTime"></param>
    public MovementServices(Control quarto, double deltaTime)
    {
        _quarto = quarto;
        _deltaTime = deltaTime;
    }

    #region Delegates and events
    public event Action<AccountUnit>? AccountUnitCreated;
    public event Action<bool>? AnyUnitOnQuartoChanged;
    #endregion

    #region Data
    #region Fields
    private readonly List<AccountUnit> _accountUnits = [];
    private readonly Control _quarto;
    private bool _lastAnyOnQuarto;
    private readonly double _deltaTime;
    #endregion
    #endregion

    #region Properties
    public IReadOnlyList<AccountUnit> AccountUnits => _accountUnits;
    public double SpawnTime { get; set; }
    #endregion


    #region Public
    /// <summary>
    /// Создает УЕ.
    /// </summary>
    /// <param name="speed">Скорость.</param>
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    /// <param name="parentSize">Размер формы.</param>
    public void CreateUnit(double speed, int width, int height, Size parentSize)
    {
        var unit = AccountUnit.Create(speed, width, height, parentSize);
        _accountUnits.Add(unit);
        AccountUnitCreated?.Invoke(unit);
        unit.BringToFront();
    }

    /// <summary>
    /// Обработка тика.
    /// </summary>
    public void Tick()
    {
        var anyOnQuarto = false;

        foreach (var unit in _accountUnits)
        {
            unit.MoveForward(_deltaTime);

            if (unit.Bounds.IntersectsWith(_quarto.Bounds))
            {
                unit.BackColor = Color.Gray;
                anyOnQuarto = true;
            }
            else
            {
                unit.BackColor = Color.Orange;
            }
        }

        if (anyOnQuarto != _lastAnyOnQuarto)
        {
            _lastAnyOnQuarto = anyOnQuarto;
            AnyUnitOnQuartoChanged?.Invoke(anyOnQuarto);
        }
    }
    #endregion
}