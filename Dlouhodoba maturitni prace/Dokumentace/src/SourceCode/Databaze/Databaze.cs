builder.ConfigureServices((context, services) => {
    services.AddDbContext<AuthDBContext>(options =>
        options.UseMySQL(
            context.Configuration.GetConnectionString
                ("AuthDBContextConnection")));
