﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace TodoTask;

[DependsOn(
	typeof(TodoTaskDomainModule),
	typeof(AbpAccountApplicationModule),
	typeof(TodoTaskApplicationContractsModule),
	typeof(AbpIdentityApplicationModule),
	typeof(AbpPermissionManagementApplicationModule),
	typeof(AbpTenantManagementApplicationModule),
	typeof(AbpFeatureManagementApplicationModule),
	typeof(AbpSettingManagementApplicationModule)
	)]
public class TodoTaskApplicationModule : AbpModule
{
	public override void ConfigureServices(ServiceConfigurationContext context)
	{
		Configure<AbpAutoMapperOptions>(options =>
		{
			options.AddMaps<TodoTaskApplicationModule>();
		});
	}
}
