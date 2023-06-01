using Microsoft.EntityFrameworkCore;
using HotelBooking.Configurations;
using HotelBooking.Contracts;
using HotelBooking.Data;
using HotelBooking.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<HotelBookingDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", o => o.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});
builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IRoomsRepository, RoomRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    string swaggerJsonBasPath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
    c.SwaggerEndpoint($"{swaggerJsonBasPath}/swagger/v1/swagger.json", "Hotel Booking API");
    c.DefaultModelsExpandDepth(-1);
});



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("AllowAll");

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
