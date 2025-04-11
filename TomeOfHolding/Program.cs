using Microsoft.EntityFrameworkCore;
using TomeOfHolding.BLL;
using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);

			// Calling mapperProfile to register all the mappings
			builder.Services.AddAutoMapper(typeof(MapperProfile));
			// Add services to the container.

			builder.Services.AddControllers();

			builder.Services.AddDbContext<TomeOfHoldingContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			//BLL services
			builder.Services.AddScoped<PlayerService>();
			builder.Services.AddScoped<CampaignService>();
			builder.Services.AddScoped<CharacterService>();
			builder.Services.AddScoped<CharacterSheetService>();

			//DAL Repos
			builder.Services.AddScoped<PlayerRepo>();
			builder.Services.AddScoped<CampaignRepo>();
			builder.Services.AddScoped<CharacterRepo>();
			builder.Services.AddScoped<CharacterSheetRepo>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment()) {
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
