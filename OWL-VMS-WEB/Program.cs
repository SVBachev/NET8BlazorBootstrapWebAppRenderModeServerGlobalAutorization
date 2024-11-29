using Microsoft.AspNetCore.Authentication.Negotiate;
using OWL_VMS_WEB.Components;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddBlazorBootstrap(); // Add this line

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Отключите сжатие ответа для горячей перезагрузки
    // Всегда вызывайте UseResponseCompression первым в конвейере обработки запросов
    app.UseResponseCompression();

    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseWebSockets();

var webSocketOptions = new WebSocketOptions
{
    // KeepAliveInterval = TimeSpan.FromMinutes(5)
};

app.Run();
