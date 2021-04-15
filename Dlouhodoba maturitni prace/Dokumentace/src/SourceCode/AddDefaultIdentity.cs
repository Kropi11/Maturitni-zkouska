services.AddDefaultIdentity<PPSPSUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
    })