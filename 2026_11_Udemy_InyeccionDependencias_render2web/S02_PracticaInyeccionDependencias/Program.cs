using PracticaInyeccionDependencias.Datos;
using PracticaInyeccionDependencias.Datos.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

//Agregar interfaz y clase de dependencias o servicios
//builder.Services.Add(new ServiceDescriptor(
//        typeof(IServicioCiudades),
//        typeof(ServicioCiudades),
//        ServiceLifetime.Scoped
//    ));

//Forma abreviada y recomendada
//builder.Services.AddTransient<IServicioCiudades, ServicioCiudades>();
//builder.Services.AddSingleton<IServicioCiudades, ServicioCiudades>();
builder.Services.AddScoped<IServicioCiudades, ServicioCiudadesV2>();


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
