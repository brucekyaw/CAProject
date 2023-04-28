using CAProject.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddDbContext<OnlineshopDBContext>(options => {
    var conn_str = builder.Configuration.GetConnectionString("conn_str");
    options.UseLazyLoadingProxies().UseSqlServer(conn_str);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

InitDB(app.Services);

app.Run();


void InitDB(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();
    OnlineshopDBContext db = scope.ServiceProvider.GetRequiredService<OnlineshopDBContext>();

    // for our debugging, we just start off by removing our old 
    // database (if there is one).
    db.Database.EnsureDeleted();
    // create a new database.
    db.Database.EnsureCreated();

    db.Add(new Product
    {
       // ProductId = 1,
        ProductName = "Microsoft Home & Student 2021",
        ProductImg = "/img/microsoft-office-student.jpg",
        ProductDescription = "For students and families who want classic Office apps installed on one PC or Mac for use at home or school.",
        ProductPrice = 139,
        ProductRating = 4.5
    });
    db.Add(new Product
    {
       // ProductId = 2,
        ProductName = "Adobe Acrobat Pro 2020 Mac OS",
        ProductImg = "/img/adobe-acrobat-pro-2020.jpg",
        ProductDescription = "With Adobe Acrobat Pro 2020, you can create, edit, fill, sign, and prepare your PDFs on Windows and Mac.",
        ProductPrice = 142,
        ProductRating = 4.2
    });
    db.Add(new Product
    {
       // ProductId = 3,
        ProductName = "Kaspersky Total Security 2023",
        ProductImg = "/img/kaspersky-total-security-2023.jpg",
        ProductDescription = "Kaspersky Total Security gives you a smarter way to protect your family’s digital world—on your PC, Mac and mobile devices. Along with award-winning protection for your privacy, money, communications and identity, it includes an easy-to-use password manager and extra security for your family’s precious photos, music and files. You also get powerful tools that do more to help you to keep your children safe—online and beyond. ",
        ProductPrice = 14.99,
        ProductRating = 4.7
    });
    db.Add(new Product
    {
       // ProductId = 4,
        ProductName = "Adobe Photoshop Elements 2023",
        ProductImg = "/img/adobe-photoshop-elements-2023.jpg",
        ProductDescription = "From simple tweaks and trims to advanced artistic options and effects, it’s never been easier to create beautiful, awe-inspiring photos and videos. With Adobe Sensei Artificial Intelligence, bring motion to your photos and click once to transform your videos with effects inspired by famous works of art. Add depth to photos with peek-through overlays, and showcase your memories with new collage and slideshow templates. Plus, go beyond your desktop with new web and mobile companion apps (English-only beta), and enjoy faster installation and performance plus Apple M1 chip support. Have fun with the easy picture editor and moviemaker for Mac and Windows.",
        ProductPrice = 99.99,
        ProductRating = 4.1
    });
    db.Add(new Product
    {
       // ProductId = 5,
        ProductName = "VideoStudio Ultimate 2021",
        ProductImg = "/img/videostudio-ultimate-2021.jpg",
        ProductDescription = "Corel VideoStudio Ultimate 2021 makes it fun and easy to produce your best videos yet, with streamlined tools and new creative extras. Explore hundreds of drag-and-drop graphics, titles and transitions, and more than 2,000 visual effects—including exclusive collections from industry leaders. Recreate popular video styles and edit videos for social media in minutes with new Instant Project Templates—even add personality and enhance reactions with brand-new AR Stickers!",
        ProductPrice = 69.69,
        ProductRating = 3.8
    });

    db.Add(new User
    {
        Username = "brucekyaw98",
        Password = "123",
        SessionId = null
    });
    db.Add(new User
    {
        Username = "nigga23",
        Password = "123",
        SessionId = null
    });
    db.Add(new User
    {
        Username = "bruh55",
        Password = "123",
        SessionId = null
    });

    db.SaveChanges();
}