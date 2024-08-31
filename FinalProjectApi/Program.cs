using Application.Services.Implementation;
using Application.Services.Interfaces;
using Domain.DomainServices;
using Domain.DomainServices.Implementation;
using Domain.Entities.Chat;
using Domain.RepositoryInterfaces;
using Infrastucture.Context;
using Infrastucture.Repository.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Services;
using Domain.DomainServices.Interface;
using System.Reflection;
using Application.CQRS.User.Command;
using Application.Exception;
using CloudinaryDotNet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseMySQL(builder.Configuration.GetConnectionString("AppString"),
            sqlOptions => sqlOptions.MigrationsAssembly("Infrastucture")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IResultRepository, ResultRepository>();
builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<IUserProgressRepository, UserProgressRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ResultHelper>();
builder.Services.AddScoped<IPaymentManager,PaymentManager>();
builder.Services.AddScoped<ChatHub>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddSingleton<IAuthService, AuthService>();
builder.Services.AddScoped<ICourseManager, CourseManager>();
builder.Services.AddScoped<IInstructorManager, InstructorManager>();
builder.Services.AddScoped<IEnrollmentManager, EnrollmentManager>();
builder.Services.AddScoped<IUserProgressManager, UserProgressManager>();
builder.Services.AddTransient<ICurrentUser, CurrentUser>();
builder.Services.AddSingleton(sp => new Cloudinary(new Account(
   builder.Configuration["Cloudinary:CloudName"],
    builder.Configuration["Cloudinary:ApiKey"],
    builder.Configuration["Cloudinary:ApiSecret"]
)));
builder.Services.AddAuthentication(x =>
           {
               x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           })
               .AddJwtBearer(x =>
              {
                  x.RequireHttpsMetadata = false;
                  x.SaveToken = true;
                  x.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      ValidateAudience = true,
                      ValidateIssuer = true,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
                      ValidIssuer = builder.Configuration["Jwt:Issuer"],
                      ValidAudience = builder.Configuration["Jwt:Audience"]
                  };

              });
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommand).Assembly));

builder.Services.AddCors(options => {
    options.AddPolicy("ClientSide", policyBuilder => {
         policyBuilder.WithOrigins("http://127.0.0.1:5501");
         policyBuilder.AllowAnyHeader();
         policyBuilder.AllowAnyMethod();
         policyBuilder.AllowCredentials();
    });
});
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
app.UseCors("ClientSide");
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
