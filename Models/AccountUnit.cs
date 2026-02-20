namespace DowntimeCalculator.Models;

/// <summary>
/// Представляет единицу учета.
/// </summary>
public sealed class AccountUnit : Panel
{
    #region .ctor
    /// <summary>
    /// Инициализирует экземпляр <see cref="AccountUnit" />.
    /// </summary>
    /// <param name="speed">Скорость.</param>
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    /// <param name="parentSize">Размеры родителя.</param>
    private AccountUnit(double speed, int width, int height, Size parentSize)
    {
        Speed = speed;
        BackColor = Color.Orange;
        Size = new Size(width, height);
        Id = Guid.NewGuid();
        Location = new Point(0, parentSize.Height / 2 - height / 2);
    }
    #endregion

    #region Properties
    /// <summary>
    /// Предоставляет идентификатор.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Предоставляет скорость движения.
    /// </summary>
    public double Speed { get; }
    #endregion

    #region Public
    /// <summary>
    /// Создает учетную единицу.
    /// </summary>
    /// <param name="speed">Скорость.</param>
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    /// <param name="parentSize">Размеры родителя.</param>
    public static AccountUnit Create(double speed, int width, int height, Size parentSize)
    {
        return new AccountUnit(speed, width, height, parentSize);
    }

    /// <summary>
    /// Передвигает учетную единицу.
    /// </summary>
    /// <param name="deltaTime">ТУДУ.</param>
    public void MoveForward(double deltaTime)
    {
        Location = new Point(
            Location.X + (int)(Speed * deltaTime),
            Location.Y
        );
    }
    #endregion
}