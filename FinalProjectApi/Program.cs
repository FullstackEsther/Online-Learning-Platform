using Domain.DomainServices;
using Domain.DomainServices.Implementation;
using Domain.Entities.Chat;
using Domain.RepositoryInterfaces;
using Infrastucture.Context;
using Infrastucture.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseMySQL(builder.Configuration.GetConnectionString("AppString"),
            sqlOptions => sqlOptions.MigrationsAssembly("Infrastucture")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IResultRepository, ResultRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IInstructorRepository,InstructorRepository>();
builder.Services.AddScoped<IEnrollmentRepository,EnrollmentRepository>();
builder.Services.AddScoped<ICourseRepository,CourseRepository>();
builder.Services.AddScoped<IChatRepository,ChatRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ResultHelper>();
builder.Services.AddScoped<PaymentManager>();
builder.Services.AddScoped<ChatHub>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
