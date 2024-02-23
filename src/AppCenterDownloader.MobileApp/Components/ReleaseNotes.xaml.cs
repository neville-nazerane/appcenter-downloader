using AppCenterDownloader.MobileApp.Services;

namespace AppCenterDownloader.MobileApp.Components;

public partial class ReleaseNotes : Label
{

    public static readonly BindableProperty ReleaseIdProperty = BindableProperty.Create(nameof(ReleaseId),
                                                                                        typeof(int),
                                                                                        typeof(ReleaseNotes));

    public int ReleaseId
    {
        get => (int)GetValue(ReleaseIdProperty);
        set => SetValue(ReleaseIdProperty, value);
    }

    public ReleaseNotes()
    {
        InitializeComponent();
    }

    private async void Tapped(object sender, TappedEventArgs e)
    {
        Text = "Loading...";
        var services = MauiProgram.Services.GetService<CentralService>();
        var wall = MauiProgram.Services.GetService<SourceWall>();

        var app = await wall.GetSelectedAppAsync();
        Text = await services.GetReleaseNotesAsync(wall.SelectedAccountKey, app, ReleaseId);
    }
}