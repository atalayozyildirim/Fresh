using Bussiness.Concrete;
using Bussiness.utils.Rules;
using Bussnies.Abstract;
using DataAccsess.Abstract;
using DataAccsess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPostService, PostManager>();
builder.Services.AddScoped<IPostDal, EfPostDal>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<IProfileService, ProfileManager>();
builder.Services.AddScoped<IProfilDal, EfProfileDal>();
builder.Services.AddScoped<IlikeService,LikeManager>();
builder.Services.AddScoped<ILikeDal, EfLikeDal>();
builder.Services.AddScoped<ICommentDal, EfCommentDal>();
builder.Services.AddScoped<PostValidator>();
builder.Services.AddScoped<ProfileValidator>();
builder.Services.AddScoped<CommentValidator>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddDbContext<Context>((e) => e.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=mango;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));
builder.Services.AddDefaultIdentity<Users>(op => op.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<Context>();
builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", op =>
{
    op.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://localhost:5226",
        ValidAudience = "Fresh",
        IssuerSigningKey = new SymmetricSecurityKey((Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])))
    };
});

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(op =>
{
    op.Cookie.HttpOnly = true;
    op.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    op.LoginPath = "/auth/login";
    op.AccessDeniedPath = "/auth/login";
    op.SlidingExpiration = true;

});
// auth middleware 
builder.Services.AddControllers(opt => opt.Filters.Add(new AuthorizeFilter()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthorization();

app.UseAuthentication();
app.Run();

