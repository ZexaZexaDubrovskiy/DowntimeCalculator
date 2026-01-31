namespace DowntimeCalculator.ApplicationLayout.UseCases.ChangeFactorySettings;

/// <summary>
/// Представляет настройки для изменения размеров УЕ.
/// </summary>
/// <param name="AccountUnitWidth">Ширина.</param>
/// <param name="AccountUnitHeight">Высота.</param>
/// <param name="AccountUnitSpeed">Скорость.</param>
/// <param name="DeltaTime"></param>
public record ChangeFactorySettingInput(
    int AccountUnitWidth,
    int AccountUnitHeight,
    double AccountUnitSpeed,
    double DeltaTime);