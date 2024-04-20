using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Config;
using DataAccess.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//DataBase
builder.Services.AddDbContext<AppDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection")
));

//MapperRoad
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile());
});
builder.Services.AddSingleton(mappingConfig.CreateMapper());

//Cookie
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
  .AddCookie((opt =>
  {
      //opt.LoginPath = "/SignIn";
      opt.Cookie.HttpOnly = true;
      opt.Cookie.Name = "AuthCookie";
      opt.Cookie.MaxAge = TimeSpan.FromDays(10);

      opt.Events = new CookieAuthenticationEvents
      {
          OnRedirectToLogin = x =>
          {
              x.HttpContext.Response.StatusCode = 401;
              return Task.CompletedTask;
          }
      };
  }));

////Services
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IMenuSerice, MenuSerice>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Error/Error1", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//cookie
app.UseSession();
app.UseAuthentication();
///
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
