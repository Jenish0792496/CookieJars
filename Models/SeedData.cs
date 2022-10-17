using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcCookieJars.Data;

namespace MvcCookieJars.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcCookieJarsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcCookieJarsContext>>()))
            {
                // Look for any movies.
                if (context.Cookie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Cookie.AddRange(
                     new Cookie
                     {
                         CookieName = "Snickerdoodles",
                         MainIngredents = "Snickerdoodles",
                         ReleaseDate = DateTime.Parse("1989-2-12"),
                         Pieces = "two",
                         Price = 5,
                         Rating = 1
                     },
                     new Cookie
                     {
                         CookieName = "Chocolate Chip Cookies",
                         MainIngredents = "Whitman, Massachusetts, ran",
                         ReleaseDate = DateTime.Parse("1895-6-2"),
                         Pieces = "two",
                         Price = 2,
                         Rating = 1
                     },
                      new Cookie
                      {
                          CookieName = "Oatmeal Raisin Cookies",
                          MainIngredents = "oatmeal raisin",
                          ReleaseDate = DateTime.Parse("1990-12-30"),
                          Pieces = "two",
                          Price = 7,
                          Rating = 1
                      },
                       new Cookie
                       {
                           CookieName = "Gingersnaps",
                           MainIngredents = "ginger, cinnamon, molasses, and nutmeg",
                           ReleaseDate = DateTime.Parse("1981-3-5"),
                           Pieces = "two",
                           Price = 1,
                           Rating = 1
                       },
                        new Cookie
                        {
                            CookieName = "Shortbread Cookies",
                            MainIngredents = "butter, flour",
                            ReleaseDate = DateTime.Parse("1991-8-19"),
                            Pieces = "two",
                            Price = 5,
                            Rating = 1
                        },
                         new Cookie
                         {
                             CookieName = "Peanut Butter Cookies",
                             MainIngredents = "Flour, peanut butter",
                             ReleaseDate = DateTime.Parse("1989-2-12"),
                             Pieces = "two",
                             Price = 2,
                             Rating = 1
                         },
                          new Cookie
                          {
                              CookieName = "Whoopie Pies",
                              MainIngredents = "pillowy cookies and a marshmallow",
                              ReleaseDate = DateTime.Parse("1998-2-22"),
                              Pieces = "two",
                              Price = 7,
                              Rating = 1
                          },
                           new Cookie
                           {
                               CookieName = "Sugar Cookies",
                               MainIngredents = "ugar, flour, butter, eggs, and vanilla",
                               ReleaseDate = DateTime.Parse("1894-6-6"),
                               Pieces = "two",
                               Price = 1,
                               Rating = 1
                           },
                            new Cookie
                            {
                                CookieName = "Molasses Cookies",
                                MainIngredents = " ginger",
                                ReleaseDate = DateTime.Parse("1999-3-6"),
                                Pieces = "two",
                                Price = 3,
                                Rating = 1
                            },
                             new Cookie
                             {
                                 CookieName = "Kiss Cookies",
                                 MainIngredents = " chocolate",
                                 ReleaseDate = DateTime.Parse("2020-2-12"),
                                 Pieces = "two",
                                 Price = 6,
                                 Rating = 1
                             }

                );
                context.SaveChanges();


            }
        }
    }
}
