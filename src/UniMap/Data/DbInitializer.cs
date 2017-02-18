using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniMap.Models;

namespace UniMap.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Check if the DB is seeded
            if (context.Events.Any()) return;

            var tags = new Tag[]
            {
                new Tag { Name = "athletics" },
                new Tag { Name = "social" },
                new Tag { Name = "academic" },
                new Tag { Name = "community service" }
            };
            context.Tags.AddRange(tags);
            context.SaveChanges();

            var events = new Event[]
            {
                new Event { Title = "TTU Appathon", Address = "Rm 364, College of Media and Communication", Latitude = 33.581913, Longitude = -101.880353,
                    StartOn = DateTime.Parse("2/17/2017 6:30:00 PM"), EndOn = DateTime.Parse("2/18/2017 4:30:00 PM"),
                    Description = "Map It!" },
                new Event { Title = "CFP Annual Conference", Address = "Student Union Building", Latitude = 33.581406, Longitude = -101.874675,
                    StartOn = DateTime.Parse("1/13/2017 08:00:00 AM"), EndOn = DateTime.Parse("2/24/2017 11:00:00 PM"),
                    Description = "Spring of 2017 brings about a time to celebrate and look forward to how the Women's Studies Program at Texas Tech can and will contribute to our growing community." },
                new Event { Title = "Random Acts of Kindness (RAK) Day", Address = "SUB CopyMail", Latitude = 33.581913, Longitude = -101.880353,
                    StartOn = DateTime.Parse("2/24/2017 12:30:00 PM"), EndOn = DateTime.Parse("2/24/2017 2:30:00 PM"),
                    Description = "Look for TAB and Redeemer College Ministries around the SUB today as we seek to empower Tech Students to brighten each other's days with some Spontaneous acts of generosity!" },
                new Event { Title = "Engineering Week", Address = "100 Engineering Center, Lubbock, TX 79409", Latitude = 33.5854583, Longitude = -101.8797266,
                    StartOn = DateTime.Parse("2/20/2017 08:00:00 AM"), EndOn = DateTime.Parse("2/24/2017 9:00:00 PM"),
                    Description = "Come celebrate engineering with us! Events all week!" },
                new Event { Title = "Mario's Birthday!", Address = "Disappointment Island", Latitude = -50.6060029, Longitude = 165.9377545,
                    StartOn = DateTime.Parse("2/20/2017 12:00:01 AM"), EndOn = DateTime.Parse("2/20/2017 011:59:03 PM"),
                    Description = "OH MY GOSH! MARIO IS GETTING OLDER" },
                new Event { Title = "Business Stuff, I Guess", Address = "Jerry S. Rawls College of Business", Latitude = 33.5876931, Longitude = -101.8814158,
                    StartOn = DateTime.Parse("2/19/2017 08:00:00 AM"), EndOn = DateTime.Parse("2/19/2017 1:00:00 PM"),
                    Description = "1. Go to school\n2. ???\n3. Profit" },
                new Event { Title = "Let's Go Running", Address = "Drive of Champions, Lubbock, TX 79401", Latitude = 33.5866116, Longitude = -101.880182,
                    StartOn = DateTime.Parse("2/18/2017 06:45:00 PM"), EndOn = DateTime.Parse("2/18/2017 7:30:00 PM"),
                    Description = "Let us celebrate our time together by running around in circles." },
                new Event { Title = "Let's Integrate!", Address = "TTU Mathmatics building", Latitude = 33.584994, Longitude = -101.876101,
                    StartOn = DateTime.Parse("1/13/2017 08:00:00 AM"), EndOn = DateTime.Parse("2/24/2017 11:00:00 PM"),
                    Description = "Did you know that 1 + 1 = 2? If not, please come see us!"}
            };
            context.Events.AddRange(events);
            context.SaveChanges();

            var eventTags = new EventTag[]
            {
                new EventTag { Event = events[0], Tag = tags[1] },
                new EventTag { Event = events[0], Tag = tags[2] },
                new EventTag { Event = events[1], Tag = tags[2] },
                new EventTag { Event = events[1], Tag = tags[3] },
                new EventTag { Event = events[2], Tag = tags[1] },
                new EventTag { Event = events[3], Tag = tags[2] },
                new EventTag { Event = events[4], Tag = tags[2] },
                new EventTag { Event = events[5], Tag = tags[3] },
                new EventTag { Event = events[6], Tag = tags[1] },
                new EventTag { Event = events[7], Tag = tags[2] }
            };
            context.EventTags.AddRange(eventTags);
            context.SaveChanges();
        }
    }
}
