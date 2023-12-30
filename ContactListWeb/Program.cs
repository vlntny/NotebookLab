using ContactListLab.AppContext;
using ContactListLab.Model;
using ContactListLab.Presenter;
using ContactListLab.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TODO")));

builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IMyDatabase, MyDatabase>();
builder.Services.AddTransient<IContactList, ContactList>();


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();