using AutoMapper;
using FluentValidation.AspNetCore;
using LeilaoOnline.Domain.Validations;
using LeilaoOnline.Infra.CrossCutting.IoC;
using LeilaoOnline.Infra.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System;
using LeilaoOnline.Infra.CrossCutting.Filters;

namespace LeilaoOnline.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc(options => options.Filters.Add(new ValidateModelAttribute()))
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LeilaoValidator>());

            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Leilão Online",
                        Version = "v1",
                        Description = "Sistema de leilões online",
                        Contact = new OpenApiContact
                        {
                            Name = "Anderson Souza",
                            Url = new Uri("https://github.com/andersonssilveira96")
                        }
                    });
            });

            // Injeção de dependencia do Automapper
            var config = AutoMapperInjection.Config();
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            // Injeção de dependencia do projeto em geral.
            Injection.Inject(services);

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
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
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddDbContext<DataContext>
               (options => options.UseSqlServer(Configuration.GetConnectionString("db")));

            services.AddControllers()
                    .ConfigureApiBehaviorOptions(options =>
                    {
                        options.SuppressModelStateInvalidFilter = true;
                    })
                    .AddNewtonsoftJson();

        }
       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseCors(x => x
                     .AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader());
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Leilões Online V1");
            });

            app.UseRouting();
           
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
