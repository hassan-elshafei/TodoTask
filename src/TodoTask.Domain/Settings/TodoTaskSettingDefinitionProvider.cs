using Volo.Abp.Settings;

namespace TodoTask.Settings;

public class TodoTaskSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(TodoTaskSettings.MySetting1));
    }
}
