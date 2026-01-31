namespace DowntimeCalculator.Models;

/// <summary>
/// Представляет агрегат Кварто.
/// </summary>
public sealed class Quarto : Panel
{
    #region .ctor
    /// <summary>
    /// Инициализирует экземпляр <see cref="Quarto" />.
    /// </summary>
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    private Quarto(int width, int height)
    {
        BackColor = Color.Red;
        Size = new Size(width, height);
        Location = new Point(900 / 2 + width, 0);
    }
    #endregion

    #region Public
    /// <summary>
    /// Создает Кварто.
    /// </summary>
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    public static Quarto Create(int width, int height)
    {
        return new Quarto(width, height);
    }
    #endregion
}