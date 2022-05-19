var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();



//use take 2 functions first context so it couls handle request and responses
//and next which is a poiter to the next middleware

app.Use(async (context, next) =>//wait until the first middleware if compleyed and then start the second
{
    await context.Response.WriteAsync("start middleware1");
    await next();
    await context.Response.WriteAsync("after middleware2");
});
app.Run(async context =>//run by default make short circut so we use it in the last middleware instead of use
{

    await context.Response.WriteAsync("RUN");                                                                                                                                                                                                                                                                                                    
});
app.Run(async context =>
{
    await context.Response.WriteAsync("start middleware2");
   // await next();
});
//note:the last middleware (middleware2) make short circut and go back to middleware1  so we can write any response
//take reqest delegate
//note:
//request wz app.run make what is called "short circut "it returns the response directly to the client
//instead of go to the second middleware
//

// Configure the HTTP request pipeline.
/*if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
*/
//these are predefined middlewares
app.UseStaticFiles();//for any request for static files like css in wwroot folder

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//the program excute  only the first run function 
//req=>MW1 to MW2 and res MW2=>MW1
app.Run();
