using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;

namespace NewsBoardBE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<NewsBoardDatabaseSettings>(
                builder.Configuration.GetSection(nameof(NewsBoardDatabaseSettings)));

            builder.Services.AddSingleton<INewsBoardDatabaseSettings>(sp =>
            sp.GetRequiredService<IOptions<NewsBoardDatabaseSettings>>().Value);

            builder.Services.AddSingleton<IMongoClient>(s =>
            new MongoClient(builder.Configuration.GetValue<string>("NewsBoardDatabaseSettings:ConnectionString")));



            builder.Services.AddScoped<IUser, NewsBoardService>();
            builder.Services.AddScoped<INewsBoardServices<ContentShare>, ContentShareService>();
            builder.Services.AddScoped<INewsBoardServices<ContentTag>, ContentTagService>();
            builder.Services.AddScoped<INewsBoardServices<Follow>, FollowService>();
            builder.Services.AddScoped<INewsBoardServices<Notification>, NotificationService>();
            builder.Services.AddScoped<INewsBoardServices<Category>, CategoryService>();
            builder.Services.AddScoped<INewsBoardServices<PaymentTransaction>, PaymentTransactionService>();
            builder.Services.AddScoped<INewsBoardServices<Report>, ReportService>();
            builder.Services.AddScoped<INewsBoardServices<SearchHistory>, SearchHistoryService>();
            builder.Services.AddScoped<INewsBoardServices<Source>, SourceServices>();
            builder.Services.AddScoped<INewsBoardServices<Subscription>, SubscriptionService>();
            builder.Services.AddScoped<INewsBoardServices<Tags>, TagService>();
            builder.Services.AddScoped<INewsBoardServices<Trendings>, TrendingService>();
            builder.Services.AddScoped<IContentService, ContentService>();
            builder.Services.AddScoped<ILikeService, LikeService>();
            builder.Services.AddScoped<ICommentService, CommentService>();

            //............................
            //add mongIdentityConfiguration...
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(option =>
            {
                option.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    }
                    );
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(); 

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
