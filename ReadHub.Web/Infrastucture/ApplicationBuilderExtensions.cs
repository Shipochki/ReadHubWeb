namespace ReadHub.Web.Infrastucture
{
	using Microsoft.AspNetCore.Identity;
	using ReadHub.Core.Data;
	using static ReadHub.Web.Areas.Admin.AdminConstants;

	public static class ApplicationBuilderExtensions
	{
		public static async Task<IApplicationBuilder> SeedAdmin(this IApplicationBuilder app)
		{
			using var scopedService = app.ApplicationServices.CreateScope();

			var service = scopedService.ServiceProvider;

			var userManager = service.GetRequiredService<UserManager<User>>();
			var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

			await Task.Run(async () =>
			{
				if (await roleManager.RoleExistsAsync(AdminRoleName))
				{
					return;
				}
			});

			var role = new IdentityRole { Name = AdminRoleName };

			await roleManager.CreateAsync(role);

			var admin = await userManager.FindByNameAsync(AdminEmail);

			await userManager.AddToRoleAsync(admin, role.Name);

			return app;
		}
	}
}
