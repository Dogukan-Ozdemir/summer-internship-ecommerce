using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MultiShopOrderApplication.Features.CQRS.Handlers.AdressHandlers;
using MultiShopOrderApplication.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShopOrderApplication.Interfaces;
using MultiShopOrderApplication.Services;
using MultiShopOrderPersistence.Context;
using MultiShopOrderPersistence.Context;
using MultiShopOrderPersistence.Repositories;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.RequireHttpsMetadata = false;
    opt.Audience = "ResourceOrder";
    opt.MapInboundClaims = false;
});

builder.Services.AddDbContext<OrderContext>(options =>
{
    options.UseSqlServer("Server=localhost,1440;Initial Catalog=MultiShopOrderDB;User Id=sa;Password=123456aA*;TrustServerCertificate=True");
});

builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddAplicationService(builder.Configuration);
#region
builder.Services.AddScoped<GetAdressQueryHandler>();
builder.Services.AddScoped<CreateAdressCommandHandler>();
builder.Services.AddScoped<GEtAdressByIdQueryHandler>();
builder.Services.AddScoped<RemoveAdressCommandHandler>();
builder.Services.AddScoped<UpdateAdresssCommandHandler>();

builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();

builder.Services.AddScoped<GetOrderDetailByOrderingIdQueryHandler>();
#endregion


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


//welcome traveler. Sit here have a rest. You deserved it. 