using DataStore_InMemory;
using UseCases.CategoriesUseCases;
using UseCases.Interfaces;
using UseCases.DataStorePluginInterfaces;
using DataStore_SQL;
using Microsoft.EntityFrameworkCore;
using DiscussionForum.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

//configure database service
builder.Services.AddDbContext<ByteBayForumsContext>(options =>
{
    //this is fed to ByteBayForumsContext.cs
    options.UseSqlServer(builder.Configuration.GetConnectionString(
        "ByteBayForumsConnectionString"
        ));

});


//configure identity service
builder.Services.AddDbContext<AccountContext>(options =>
{
    //this is fed to AccountContext.cs
    options.UseSqlServer(builder.Configuration.GetConnectionString(
        "ByteBayForumsConnectionString"
        ));

});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AccountContext>();

builder.Services.AddTransient<CategorySQLRepo>();
builder.Services.AddTransient<PostSQLRepo>();

if (builder.Environment.IsEnvironment("QA"))
{
    //repositories stay singleton
    builder.Services.AddSingleton<ICategoryRepository, CategoriesInMemoryRepository>();
    builder.Services.AddSingleton<IPostRepository, PostsInMemoryRepository>();
}
else
{
    // transient here, since we are not sharing our database instance accross requests
    builder.Services.AddTransient<ICategoryRepository, CategorySQLRepo>();
    builder.Services.AddTransient<IPostRepository, PostSQLRepo>();
}





//use cases stay transient - transient creates a new instance for every request
builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
//builder.Services.AddTransient<ISelectCategoryUseCase, ViewSelectedCategoryUseCase>();
//builder.Services.AddTransient<IUpdateCategoryUseCase, UpdateCategoryUseCase>();

var app = builder.Build();


app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

//this requires controllers with views service
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );




app.Run();
