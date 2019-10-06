using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {

            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        Id ="a",
                        DisplayName = "Tochi",
                        UserName = "Tochi",
                        Email = "tochi@gmail.com"
                    },
                    new AppUser
                    {
                        Id="b",
                        DisplayName = "Bob",
                        UserName = "Bob",
                        Email = "bob@gmail.com"
                    },
                    new AppUser
                    {
                        Id="c",
                        DisplayName = "Tom",
                        UserName = "Tom",
                        Email = "tom@gmail.com"
                    },
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }

            };
            if (!context.Activities.Any())
            {
                var activities = new List<Activity>
                {
                    new Activity
                    {
                        Title = "Past Activity 1",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity 2 months ago",
                        Category = "drinks",
                        City = "London",
                        Venue = "Pub",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = true,
                                DateJoined=DateTime.Now.AddMonths(-2)
                            }
                        }
                    },
                    new Activity
                    {
                        Title = "Past Activity 2",
                        Date = DateTime.Now.AddMonths(-1),
                        Description = "Activity 1 month ago",
                        Category = "culture",
                        City = "Paris",
                        Venue = "Louvre",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = true,
                                DateJoined=DateTime.Now.AddMonths(-1)
                            },
                             new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = false,
                                DateJoined=DateTime.Now.AddMonths(-1)
                            }
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 1",
                        Date = DateTime.Now.AddMonths(1),
                        Description = "Activity 1 month in future",
                        Category = "culture",
                        City = "London",
                        Venue = "Natural History Museum",
                         UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = true,
                                DateJoined=DateTime.Now.AddMonths(1)
                            },
                             new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = false,
                                DateJoined=DateTime.Now.AddMonths(1)
                            }
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 2",
                        Date = DateTime.Now.AddMonths(2),
                        Description = "Activity 2 months in future",
                        Category = "music",
                        City = "London",
                        Venue = "O2 Arena",
                          UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = true,
                                DateJoined=DateTime.Now.AddMonths(2)
                            },
                             new UserActivity
                            {
                                AppUserId = "c",
                                IsHost = false,
                                DateJoined=DateTime.Now.AddMonths(2)
                            }
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 3",
                        Date = DateTime.Now.AddMonths(3),
                        Description = "Activity 3 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Another pub",
                          UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = true,
                                DateJoined=DateTime.Now.AddMonths(3)
                            },
                             new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = false,
                                DateJoined=DateTime.Now.AddMonths(3)
                            },
                             new UserActivity
                            {
                                AppUserId = "c",
                                IsHost = false,
                                DateJoined=DateTime.Now.AddMonths(3)
                            }
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 4",
                        Date = DateTime.Now.AddMonths(4),
                        Description = "Activity 4 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Yet another pub",
                         UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "c",
                                IsHost = true,
                                DateJoined=DateTime.Now.AddMonths(4)
                            },
                             new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = false,
                                DateJoined=DateTime.Now.AddMonths(4)
                            },
                             new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = false,
                                DateJoined=DateTime.Now.AddMonths(4)
                            }
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 5",
                        Date = DateTime.Now.AddMonths(5),
                        Description = "Activity 5 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Just another pub",
                         UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = true,
                                DateJoined=DateTime.Now.AddMonths(5)
                            },
                             new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = false,
                                DateJoined=DateTime.Now.AddMonths(5)
                            },
                             new UserActivity
                            {
                                AppUserId = "c",
                                IsHost = false,
                                DateJoined=DateTime.Now.AddMonths(5)
                            }
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 6",
                        Date = DateTime.Now.AddMonths(6),
                        Description = "Activity 6 months in future",
                        Category = "music",
                        City = "London",
                        Venue = "Roundhouse Camden",
                         UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = true,
                                DateJoined=DateTime.Now.AddMonths(6)
                            },
                             new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = false,
                                DateJoined=DateTime.Now.AddMonths(6)
                            },
                             new UserActivity
                            {
                                AppUserId = "c",
                                IsHost = false,
                                DateJoined=DateTime.Now.AddMonths(6)
                            }
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 7",
                        Date = DateTime.Now.AddMonths(7),
                        Description = "Activity 2 months ago",
                        Category = "travel",
                        City = "London",
                        Venue = "Somewhere on the Thames",
                         UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = true,
                                DateJoined=DateTime.Now.AddMonths(7)
                            },
                             new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = false,
                                DateJoined=DateTime.Now.AddMonths(7)
                            },
                             new UserActivity
                            {
                                AppUserId = "c",
                                IsHost = false,
                                DateJoined=DateTime.Now.AddMonths(7)
                            }
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 8",
                        Date = DateTime.Now.AddMonths(8),
                        Description = "Activity 8 months in future",
                        Category = "film",
                        City = "London",
                        Venue = "Cinema",
                         UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "c",
                                IsHost = true,
                                DateJoined=DateTime.Now.AddMonths(8)
                            },
                             new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = false,
                                DateJoined=DateTime.Now.AddMonths(8)
                            },
                             new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = false,
                                DateJoined=DateTime.Now.AddMonths(8)
                            }
                        }
                    }
                    
                };
                context.Activities.AddRange(activities);
                context.SaveChanges();
            }
            
        }
    }
}