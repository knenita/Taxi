using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi.Common.Enumeracion;
using Taxi.Web.Data.Entities;
using Taxi.Web.Helpers;

namespace Taxi.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(
            DataContext dataContext,
            IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();//vrear o actualizar bd
            await CheckRolesAsync(); //adiciona despues
            var admin = await CheckUserAsync("1010", "Diana", "Russi", "dianarussi@yahoo.com", "350 634 2747", "Calle Luna Calle Sol", UserType.Admin);
            var driver = await CheckUserAsync("2020", "Diana", "Russi", "diana.russiposada@gmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.Driver);
            var user1 = await CheckUserAsync("3030", "Diana", "Russi", "diana.russiposada@hotmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.User);
            var user2 = await CheckUserAsync("4040", "Diana", "Russi", "informacionitelme@gmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.User);
            await CheckTaxisAsync(driver, user1, user2);

        }

        private async Task<UserEntity> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.Driver.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckTaxisAsync(
            UserEntity driver,
            UserEntity user1,
            UserEntity user2)
        {
            if (!_dataContext.Taxis.Any())
            {
                _dataContext.Taxis.Add(new TaxiEntity
                {
                    User = driver,
                    Plaque = "TPQ123",
                    Trips = new List<TripEntity>
                    {
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.5f,
                            Source = "ITM Fraternidad",
                            Target = "ITM Robledo",
                            Remarks = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." + 
                            " Proin ut nisi eu nisl lobortis consequat at ut lectus." + 
                            " Donec ut magna vitae sapien aliquet egestas. Pellentesque lorem elit, " + 
                            " rutrum sit amet mollis at, bibendum elementum nulla. Sed at libero imperdiet, " + 
                            " lobortis libero et, dapibus urna. Nam faucibus sapien risus, vitae pretium mi " + 
                            " tempor sit amet. Phasellus a diam a sem iaculis pretium. Vestibulum fermentum " + 
                            " condimentum mi, non tincidunt urna porttitor ut. Sed ut neque euismod, bibendum " + 
                            " nisi vitae, egestas lectus. Maecenas id tortor nulla. In nisi arcu, volutpat ut est " + 
                            " vel, pharetra iaculis eros. Mauris eleifend ullamcorper arcu eget mollis. Sed leo risus, " + 
                            " feugiat venenatis eros ac, mattis tincidunt sem. Praesent iaculis tortor ut lacinia " + 
                            " tincidunt.",
                            User = user1
                        },
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.8f,
                            Source = "ITM Robledo",
                            Target = "ITM Fraternidad",
                            Remarks = "Proin tincidunt maximus orci. Integer luctus porttitor tortor, et porttitor turpis porttitor a. Proin lobortis tincidunt diam, fringilla sollicitudin justo commodo vitae. Etiam nec molestie lacus. Aliquam cursus euismod est, in vulputate neque bibendum quis. Suspendisse blandit arcu eget faucibus egestas. Maecenas porttitor et elit et lacinia. Duis sodales, urna sed maximus maximus, lacus elit luctus ante, id mollis est ante id massa. Mauris sed elit odio. Maecenas id eros vitae justo facilisis tristique nec sit amet dui. Nam elementum sodales lobortis. Nam varius ante et purus sollicitudin consectetur. Donec semper tempus ex.",
                            User = user1
                        }
                    }
                });

                _dataContext.Taxis.Add(new TaxiEntity
                {
                    Plaque = "THW321",
                    User = driver,
                    Trips = new List<TripEntity>
                    {
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.5f,
                            Source = "ITM Fraternidad",
                            Target = "ITM Robledo",
                            Remarks = "Muy buen servicio",
                            User = user2
                        },
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.8f,
                            Source = "ITM Robledo",
                            Target = "ITM Fraternidad",
                            Remarks = "Conductor muy amable",
                            User = user2
                        }
                    }
                });

                await _dataContext.SaveChangesAsync();
            }
        }
    }
}