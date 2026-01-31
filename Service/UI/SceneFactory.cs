using DowntimeCalculator.Models;

namespace DowntimeCalculator.Service.UI;

/// <summary>
/// Представляет фабрику создания <see cref="Scene" />.
/// </summary>
public static class SceneFactory
{
    /// <summary>
    /// Создает <see cref="Scene" />.
    /// </summary>
    /// <param name="form">Форма.</param>
    /// <returns><see cref="Scene" />></returns>
    public static Scene Create(Form form)
    {
        var quarto = Quarto.Create(100, 600);
        form.Controls.Add(quarto);

        return new Scene(form, quarto);
    }
}