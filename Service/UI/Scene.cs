using DowntimeCalculator.Models;

namespace DowntimeCalculator.Service.UI;

/// <summary>
/// Представляет сцену.
/// </summary>
public sealed class Scene
{
    private readonly Control _control;

    /// <summary>
    /// Инициализирует экземпляр <see cref="Scene" />.
    /// </summary>
    /// <param name="root"><see cref="Control" />.</param>
    /// <param name="quarto">Кварто.</param>
    public Scene(Control root, Quarto quarto)
    {
        _control = root;
        Quarto = quarto;
    }

    /// <summary>
    /// Возвращает Кварто.
    /// </summary>
    public Quarto Quarto { get; }

    /// <summary>
    /// Добавляет новый <see cref="Control" />.
    /// </summary>
    /// <param name="control"><see cref="Control" />.</param>
    public void Add(Control control)
    {
        _control.Controls.Add(control);
    }
}