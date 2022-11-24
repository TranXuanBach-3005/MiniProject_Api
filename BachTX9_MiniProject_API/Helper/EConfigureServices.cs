using BachTX9_MiniProject_API.AutoMapper;
using BachTX9_MiniProject_API.Data;
using BachTX9_MiniProject_API.JwtConfiguration;
using BachTX9_MiniProject_API.Repository;
using BachTX9_MiniProject_API.Repository.IRepository;
using BachTX9_MiniProject_API.Services;
using BachTX9_MiniProject_API.Services.IServices;
using BachTX9_MiniProject_API.UnitOfWorks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace BachTX9_MiniProject_API.Helper
{
    public static class EConfigureServices
    {
        public static void RegisterConfigure(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Asp_net_core_API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [Space] and then your token! \n\n Ex: Bearer token"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme{
                            Reference= new OpenApiReference
                                           {
                                               Type=ReferenceType.SecurityScheme,
                                               Id="Bearer"
                                            },
                            },
                        new string[]{}
                    }
                    });
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = false
                };
            });
        }
        public static void RegisterAuth(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddControllers()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddScoped<CloudImageForBach>();
            services.AddAutoMapper(typeof(Mapping).Assembly);
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<ITestService, TestService>();
            services.AddTransient<IUserTestService, UserTestService>();
            services.AddTransient<ITestRepository, TestRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserTestRepository, UserTestRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddDbContext<DataDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MyDbContext"));
            });
        }
    }
}