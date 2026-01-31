namespace DowntimeCalculator.Common;

/// <summary>
/// Представляет класс-расширение для работы с <see cref="TextBox" />.
/// </summary>
public static class TextBoxExtention
{
    #region Public
    /// <summary>
    /// Проверяет текст на наличие только цифр.
    /// </summary>
    /// <param name="e"><see cref="KeyPressEventArgs" />.</param>
    public static void IsDigit(KeyPressEventArgs e)
    {
        var ch = e.KeyChar;
        if (!char.IsDigit(ch) && ch != 8)
        {
            e.Handled = true;
        }
    }
    #endregion
}