using DowntimeCalculator.ApplicationLayout.UseCases.ChangeFactorySettings;
using DowntimeCalculator.Common;
using DowntimeCalculator.Service.Services;

namespace DowntimeCalculator;

public partial class Form1 : Form
{
    #region Data
    #region Fields
    private readonly FactoryLoopService _factoryLoopService;
    #endregion
    #endregion

    #region .ctor
    public Form1(TimeProvider timeProvider, CancellationToken cancellationToken)
    {
        InitializeComponent();
        _factoryLoopService = FactoryService.Create(this, timeProvider, cancellationToken);
        _factoryLoopService.Start();
    }
    #endregion

    #region Overrided
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        _factoryLoopService.Stop();
        base.OnFormClosing(e);
    }
    #endregion

    private bool TryReadSettings(out ChangeFactorySettingInput settings)
    {
        settings = null!;

        if (string.IsNullOrWhiteSpace(WidthTextBox.Text) ||
            string.IsNullOrWhiteSpace(HeightTextBox.Text) ||
            string.IsNullOrWhiteSpace(SpeedTextBox.Text) ||
            string.IsNullOrWhiteSpace(TimeSpawnTextBox.Text))
        {
            return false;
        }

        settings = new ChangeFactorySettingInput
        (
            int.Parse(WidthTextBox.Text),
            int.Parse(HeightTextBox.Text),
            double.Parse(SpeedTextBox.Text),
            double.Parse(TimeSpawnTextBox.Text)
        );

        return true;
    }

    #region Private
    private void ChangeAccountUnitButton_Click(object sender, EventArgs e)
    {
        if (!TryReadSettings(out var settings))
        {
            MessageBox.Show("Вы не заполнили все обязательные поля.");
            return;
        }

        _factoryLoopService.UpdateSettings(settings);
    }

    private void HeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        TextBoxExtention.IsDigit(e);
    }

    private async void RemoveAllDowntimeButton_Click(object sender, EventArgs e)
    {
        _factoryLoopService.ResetDowntime();
    }

    private void SpeedTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        TextBoxExtention.IsDigit(e);
    }

    private void WidthTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        TextBoxExtention.IsDigit(e);
    }
    #endregion
}