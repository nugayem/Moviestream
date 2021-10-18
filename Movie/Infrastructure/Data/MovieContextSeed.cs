using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Infrastructure.Data.Seed;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class MovieContextSeed
    {
          public static async Task SeedAsync(MovieDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {

                //     foreach (var item in types)
                //     {
                //         foreach(var genre in item.genres)
                //         {
                //             genrelist.Add(new Genre(){Name=genre});
                //         } 
                //         foreach(var actor in item.actors)
                //         {
                //             castlist.Add(new Cast(){ Nickname=actor, Firstname=actor.Split(' ')[0], Lastname=actor.Split(' ')[1]});
                //         } 
                //         foreach(var director in item.directors)
                //         {
                //             castlist.Add(new Cast(){ Nickname=director, Firstname=director.Split(' ')[0], Lastname=director.Split(' ')[1]});
                //         } 
                //     }
                //     var ditinctgenre= genrelist.Distinct().ToList();
                //     var ditinctcast= castlist.Distinct().ToList();

                //     await context.Genres.AddRangeAsync(ditinctgenre);
                //     await context.Casts.AddRangeAsync(ditinctcast);
                //     await context.SaveChangesAsync();
                // }

                List<Core.Entities.Genre> myGenreList = new List<Core.Entities.Genre>();
                if (!context.Genres.Any())
                {

                    try
                    {
                        var typeData = File.ReadAllText("../Infrastructure/Data/Seed/genres.json");

                        var types = JsonSerializer.Deserialize<List<Seed.Genre>>(typeData);

                        foreach (var item in types)
                        {
                            var genre = new Core.Entities.Genre() { Name = item.name };
                             

                            context.Genres.Add(genre);
                        }
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                if (!context.Movies.Any())
                {  
                    HttpClient client = new HttpClient();

                    try	
                    {
                        HttpResponseMessage response = await client.GetAsync("https://api.themoviedb.org/3/movie/latest?api_key=46965a2ac34a9fdac3f058bb83b971e5");
                        response.EnsureSuccessStatusCode();

                        var responseBody = await response.Content.ReadAsStringAsync();
                        var movies=JsonSerializer.Deserialize<Root>(responseBody);
 

                        var config = new MapperConfiguration(cfg => {
                                        cfg.CreateMap<Seed.Genre,Core.Entities.Genre>();
                                        cfg.CreateMap<Seed.ProductionCompany,Core.Entities.ProductionCompany>();
                                        cfg.CreateMap<Seed.ProductionCountry,Core.Entities.ProductionCompany>();
                                        cfg.CreateMap<Seed.SpokenLanguage,Core.Entities.SpokenLanguage>();
                                        cfg.CreateMap<Seed.Cast,Core.Entities.Profile>();
                                    });
                        IMapper iMapper = config.CreateMapper();
                        
                        


                        foreach (var amovie in movies.results)
                        {
                            var movie=  new Movie();
                            //movie.Genres= iMapper.Map<List<Core.Entities.Genre>>(amovie.genres);
                            //movie.ProductionCompany =  iMapper.Map<List<Core.Entities.ProductionCompany>>(amovie.production_companies);
                            //movie.SpokenLanguage= iMapper.Map<List<Core.Entities.SpokenLanguage>>(amovie.spoken_languages);  
                            //Getting Genre

                            var typeData = File.ReadAllText("../Infrastructure/Data/Seed/genres.json");

                            var types = JsonSerializer.Deserialize<List<Seed.Genre>>(typeData);

                            var lgenre = types.Where(a => amovie.genre_ids.Contains(a.id)).Select(a=> a.name).ToList();

                            var myGenre = context.Genres.Where(a => lgenre.Contains(a.Name)).ToList();

                            var language = new Core.Entities.SpokenLanguage() { Name = amovie.original_language , Alias= amovie.original_language};
                            var spokenlang = new List<Core.Entities.SpokenLanguage>();
                            spokenlang.Add(language);

                            context.SpokenLanguage.Add(language);
                            movie.ReleasedDate = DateTime.Parse(amovie.release_date );
                            movie.Revenue = 0;
                            movie.Genres = myGenre;
                            movie.Video = true;
                            movie.Title=amovie.title;
                            movie.Plot = amovie.overview;
                            movie.Tagline = amovie.overview;
                            movie.ImdbID = amovie.id.ToString();
                            movie.PosterPath = amovie.poster_path;
                            movie.SpokenLanguage = spokenlang;
                            movie.Popularity = Convert.ToInt32(amovie.popularity);
                             

                            context.Movies.Add(movie);
                        }

                        context.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                     
                }

            }
            catch{}
        }

        private static IDisposable HttpClient()
        {
            throw new NotImplementedException();
        }
    }
}