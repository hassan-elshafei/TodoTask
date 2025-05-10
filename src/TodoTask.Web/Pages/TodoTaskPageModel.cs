using TodoTask.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace TodoTask.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class TodoTaskPageModel : AbpPageModel
{
    protected TodoTaskPageModel()
    {
        LocalizationResourceType = typeof(TodoTaskResource);
    }
}
