var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*Задание:
 Требуется написать web api в котором будет один метод по расчёту стоиомсти доставки. 
Расчёт происзводить с использованием методв "Расчет стоимости по тарифам без приоритета" из документации СДЭК.

Метод будет принимать вес в граммах, габариты в мм, фиас код города отправления, фиас код города получения. 
На выходе должен стоимости доставки с помощью транспортной компании СДЭК груза. Рассматриваем лишь одноместные отправления и курьерскую доставку.

*/



builder.Services.AddControllers();
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
