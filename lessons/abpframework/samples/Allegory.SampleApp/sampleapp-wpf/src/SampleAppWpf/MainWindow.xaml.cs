using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Windows;
using Volo.Abp.Identity;
using Volo.Abp.IdentityModel;

namespace SampleAppWpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    IIdentityModelAuthenticationService _identityModelAuthenticationService;
    AbpIdentityClientOptions _identityClients;
    IServiceProvider _serviceProvider;

    public MainWindow(
        IIdentityModelAuthenticationService identityModelAuthenticationService,
        IOptions<AbpIdentityClientOptions> identityClients,
        IServiceProvider serviceProvider)
    {
        _identityClients = identityClients.Value;
        _identityModelAuthenticationService = identityModelAuthenticationService;
        _serviceProvider = serviceProvider;
        InitializeComponent();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        _identityClients.IdentityClients["Default"].UserName = username.Text;
        _identityClients.IdentityClients["Default"].UserPassword = password.Text;
        try
        {
            var result = await _identityModelAuthenticationService.TryAuthenticateAsync(new HttpClient(), "Default");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Kullanıcı adı/şifre hatalı");
            return;
        }

        Hide();
        UserRoleWindow userRoles = new UserRoleWindow(_serviceProvider.GetService<IIdentityRoleAppService>());
        userRoles.ShowDialog();
        Close();
    }
}
