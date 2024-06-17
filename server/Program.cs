using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using server.DataLayer.DataContext;
using server.repository.IRepository;
using server.repository.Repository;
using server.services.IServices;
using server.services.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository,AuthRepository>();

builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserRepository,UserRepository>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("defaultString")));





builder.Services.AddScoped<server.DataLayer.Helpers.HashingHelper>();
builder.Services.AddScoped<server.DataLayer.Helpers.JwtHelper>();
builder.Services.AddScoped<server.DataLayer.Helpers.EmailSenderHelper>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("*") // Adjust the origin as needed
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers()
       .AddNewtonsoftJson(options =>
       {
           options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
           options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore; // Optional: Ignore null values
       });


// Add authorization services
builder.Services.AddAuthorization();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowReactApp");
// Use authentication and authorization middlewares
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();





app.Run();