using Office.Repositories.Implementations.FavoriteSpace;
using Office.Repositories.Implementations.User;
using Office.Repositories.Interfaces.FavoriteSpace;
using Office.Repositories.Interfaces.Reservation;
using Office.Repositories.Interfaces.User;
using Office.Repositories.Interfaces.WorkSpace;
using Office.Services.Interfaces.FavoriteSpace;
using Office.Services.Interfaces.Reservation;
using Office.Services.Interfaces.User;
using Office.Services.Interfaces.WorkSpace;
using Office.Services.Implementations.FavoriteSpace;
using Office.Services.Implementations.Reservation;
using Office.Services.Implementations.User;
using Office.Services.Implementations.WorkSpace;
using Office.Repositories.Implementations.Reservation;
using Office.Repositories.Implementations.WorkSpace;


namespace Office.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IFavoriteSpaceRepository, FavoriteSpaceRepository>();
            builder.Services.AddScoped<IReservationRepository,ReservationRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IWorkSpaceRepository, WorkSpaceRepository>();

            builder.Services.AddScoped<IFavoriteSpaceService, FavoriteSpaceService>();
            builder.Services.AddScoped<IReservationService, ReservationService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IWorkSpaceService, WorkSpaceService>();





            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
