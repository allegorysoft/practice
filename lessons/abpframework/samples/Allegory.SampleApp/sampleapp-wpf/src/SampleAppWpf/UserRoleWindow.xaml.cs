using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Volo.Abp.Identity;

namespace SampleAppWpf
{
    /// <summary>
    /// Interaction logic for UserRoleWindow.xaml
    /// </summary>
    public partial class UserRoleWindow : Window
    {
        IIdentityRoleAppService _identityRoleAppService;
        
        public UserRoleWindow(IIdentityRoleAppService identityRoleAppService)
        {
            _identityRoleAppService = identityRoleAppService;
            InitializeComponent();
        }

        async Task ListRolesAsync()
        {
            listBox.Items.Clear();
            var result = await _identityRoleAppService.GetAllListAsync();
            result.Items.ToList().ForEach(role => listBox.Items.Add(role.Name));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await ListRolesAsync();
        }
        
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await ListRolesAsync();
        }

    }
}
