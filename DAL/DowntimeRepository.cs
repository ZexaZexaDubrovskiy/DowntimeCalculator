using DowntimeCalculator.Models;
using Newtonsoft.Json;

namespace DowntimeCalculator.DAL;

/// <inheritdoc />
/// <param name="applicationDbContext"><see cref="ApplicationDbContext" />>.</param>
public class DowntimeRepository(ApplicationDbContext applicationDbContext) : IDowntimeRepository
{
    #region Data
    #region Static
    private static readonly JsonSerializerSettings JsonSettings =
        new() {
            Formatting = Formatting.Indented
        };
    #endregion
    #endregion

    #region IDowntimeRepository members
    /// <inheritdoc />
    public async Task AddAsync(Downtime downtime, CancellationToken cancellationToken)
    {
        var downtimes = await LoadAsync(cancellationToken);
        downtimes.Add(downtime);
        await SaveAsync(downtimes, cancellationToken);
    }

    /// <inheritdoc />
    public Task RemoveAllAsync(CancellationToken cancellationToken)
    {
        return SaveAsync([], cancellationToken);
    }
    #endregion

    #region Private
    private async Task<List<Downtime>> LoadAsync(CancellationToken cancellationToken)
    {
        if (!File.Exists(applicationDbContext.DowntimeFilePath))
        {
            return [];
        }

        var json = await File.ReadAllTextAsync(applicationDbContext.DowntimeFilePath, cancellationToken);
        return JsonConvert.DeserializeObject<List<Downtime>>(json) ?? [];
    }

    private Task SaveAsync(List<Downtime> downtimes, CancellationToken cancellationToken)
    {
        return File.WriteAllTextAsync(
            applicationDbContext.DowntimeFilePath,
            JsonConvert.SerializeObject(downtimes, JsonSettings), cancellationToken);
    }
    #endregion
}