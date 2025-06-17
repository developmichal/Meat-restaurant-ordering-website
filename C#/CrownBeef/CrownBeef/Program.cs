using IDal;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDal.IDal<Dto.CategoryDto>, Dal.CategoryDal>();
builder.Services.AddScoped<IBll.IBllServices<Dto.CategoryDto>, Bll.CategoryBll>();
builder.Services.AddScoped<IDal.IDalCustomer, Dal.CustomerDal>();
builder.Services.AddScoped<IBll.IBllCustomer, Bll.CustomerBll>();
builder.Services.AddScoped<IDal.IDalProduct, Dal.ProductDal>();
builder.Services.AddScoped<IBll.IBllProduct, Bll.ProductBll>();
builder.Services.AddScoped<IBll.IBllCompletePurchase, Bll.CompletePurchaseBll>();
builder.Services.AddScoped<IDal.IDalCompletePurchase, Dal.CompletePurchaseDal>();


//להזרקה של מסד הנתונים יש פקודה יעודית מאחר וזו פקודה שימושית ויש לה אופציות נוספות
//ישנם דרכים רבות להזריק מחלקה זו , אנחנו כעת נבחר בשיטה הבאה
builder.Services.AddDbContext<Dal.models.CrownBeefContext>
(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SeminarConnection")));

builder.Services.AddCors(opotion => opotion.AddPolicy("AllowAll",//נתינת שם להרשאה
    p => p.AllowAnyOrigin()//מאפשר כל מקור
    .AllowAnyMethod()//כל מתודה - פונקציה
    .AllowAnyHeader()));//וכל כותרת פונקציה

var app = builder.Build();
app.UseCors("AllowAll");

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
