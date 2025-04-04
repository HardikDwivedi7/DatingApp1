using System.Text;
using API;
using API.Data;
using API.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
//builder.Services.AddDbContext<DataContext>(opt =>
//{
  //  opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
//});
//builder.Services.AddCors();
//builder.Services.AddScoped<ITokenService, TokenService>();
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options=>{
//         var tokenKey = builder.Configuration["TokenKey"]??throw new Exception("TokenKey not found");
//         options.TokenValidationParameters=new TokenValidationParameters{
//             ValidateIssuerSigningKey=true,
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
//             ValidateIssuer = false,
//             ValidateAudience = false
//         };
//     });
//Commented as now implemented in extensions
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod()
.WithOrigins("http://localhost:4200","https://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
