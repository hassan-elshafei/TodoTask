using Localization.Resources.AbpUi;
using TodoTask.Localization;
using Volo.Abp.Account;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace TodoTask;

[DependsOn(
	typeof(TodoTaskApplicationContractsModule),
	typeof(AbpAccountHttpApiModule),
	typeof(AbpIdentityHttpApiModule),
	typeof(AbpPermissionManagementHttpApiModule),
	typeof(AbpTenantManagementHttpApiModule),
	typeof(AbpFeatureManagementHttpApiModule),
	typeof(AbpSettingManagementHttpApiModule)
	)]
public class TodoTaskHttpApiModule : AbpModule
{
	public override void ConfigureServices(ServiceConfigurationContext context)
	{
		Configure<AbpAspNetCoreMvcOptions>(options =>
		{
			options.ConventionalControllers.Create(typeof(TodoTaskApplicationModule).Assembly);
		});
	}


	private void ConfigureLocalization()
	{
		Configure<AbpLocalizationOptions>(options =>
		{
			options.Resources
				.Get<TodoTaskResource>()
				.AddBaseTypes(
					typeof(AbpUiResource)
				);
		});

	}
}
