var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHangfire(opt =>
{
    opt.UseSqlServerStorage(builder.Configuration.GetConnectionString("DbConnection"))
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings();
});

builder.Services.AddHangfireServer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHangfireDashboard("/hangfire");

app.UseAuthorization();

app.MapControllers();

//BackgroundJob.Enqueue(() => Console.WriteLine("Fire and Forget Job"));

//BackgroundJob.Schedule(() => Console.WriteLine("Delay Job Sample!"),TimeSpan.FromSeconds(5));

//var jobId = Guid.NewGuid().ToString();
//RecurringJob.AddOrUpdate(jobId,() => Console.WriteLine("Recuring Job"), Cron.Daily);

RecurringJob.AddOrUpdate(
    "LastDayMessageJob",
    () => Console.WriteLine("This is your monthly message!"),
    "59 23 L * *" );


app.Run();
