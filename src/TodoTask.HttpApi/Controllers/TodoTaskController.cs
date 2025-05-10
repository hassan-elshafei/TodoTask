using TodoTask.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TodoTask.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class TodoTaskController : AbpControllerBase
{
    protected TodoTaskController()
    {
        LocalizationResource = typeof(TodoTaskResource);
    }
}
