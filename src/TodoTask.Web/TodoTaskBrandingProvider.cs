using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace TodoTask.Web;

[Dependency(ReplaceServices = true)]
public class TodoTaskBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "TodoTask";
}
