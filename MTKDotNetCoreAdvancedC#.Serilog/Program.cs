using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Templates;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File(
        new CompactJsonFormatter(),
        "logs/RestApi.txt",
        rollingInterval: RollingInterval.Minute
    )
    .WriteTo.Console(new ExpressionTemplate("[{@t:HH:mm:ss} {@l:u3} {SourceContext}] {@m}\n{@x}"))
    //      .WriteTo
    //.MSSqlServer(
    //    connectionString: builder.Configuration.GetConnectionString("DbConnection"),
    //    sinkOptions: new MSSqlServerSinkOptions { TableName = "Tbl_Logs", AutoCreateSqlTable = true })
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
