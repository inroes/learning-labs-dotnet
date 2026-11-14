using PracticaInyeccionDependencias_INROES.Datos;
using PracticaInyeccionDependencias_INROES.Datos.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Agregar interfaz y clase de dependencias o servicios
builder.Services.Add(new ServiceDescriptor(
        typeof(IServicioCiudades),
        typeof(ServicioCiudades),
        ServiceLifetime.Scoped
    ));


//builder.Services.AddScoped<IServicioCiudades, ServicioCiudades>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
