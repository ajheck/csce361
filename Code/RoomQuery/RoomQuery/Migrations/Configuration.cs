namespace RoomQuery.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RoomQuery.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<RoomQuery.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RoomQuery.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var students = new List<Student>

            {
                new Student {Nuid="11111111",    FirstName = "Andy",        LastName="Heck",        InSRC = false,      IsTA = true     },
                new Student {Nuid="22222222",    FirstName = "Jon",         LastName="Deck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="33333333",    FirstName = "Jon",         LastName="Keck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="44444444",    FirstName = "Tyler",       LastName="Barker",      InSRC = false,      IsTA = true     },
                new Student {Nuid="55555555",    FirstName = "Kate",        LastName="Deck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="66666666",    FirstName = "Colton",      LastName="Harper",      InSRC = false,      IsTA = true     },
                new Student {Nuid="77777777",    FirstName = "Kate",        LastName="Reck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="88888888",    FirstName = "Hannah",      LastName="Finnegan",    InSRC = false,      IsTA = true     },
                new Student {Nuid="99999999",    FirstName = "Chris",       LastName="Deck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="10101010",    FirstName = "Chris",       LastName="Keck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="12121212",    FirstName = "Chris",       LastName="Reck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="13131313",    FirstName = "Harold",      LastName="Heck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="14141414",    FirstName = "Harold",      LastName="Deck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="15151515",    FirstName = "Harold",      LastName="Keck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="16161616",    FirstName = "Harold",      LastName="Reck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="17171717",    FirstName = "Roland",      LastName="Heck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="18181818",    FirstName = "Roland",      LastName="Deck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="19191919",    FirstName = "Roland",      LastName="Keck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="20202020",    FirstName = "Roland",      LastName="Reck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="21212121",    FirstName = "Seamus",      LastName="Deck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="23232323",    FirstName = "Seamus",      LastName="Keck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="24242424",    FirstName = "Seamus",      LastName="Reck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="25252525",    FirstName = "Josh",        LastName="Peck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="26262626",    FirstName = "Danny",       LastName="Reck",        InSRC = false,      IsTA = false    },
                new Student {Nuid="27272727",    FirstName = "Fred",        LastName="Keck",        InSRC = false,      IsTA = false    }
            };

            var courses = new List<Course>
            {
                new Course { }
            };

            var officeHours = new List<OfficeHour>
            {
                new OfficeHour { }
            };

            var timeStamps = new List<SRCTimestamp>
            {
                new SRCTimestamp { }
            };

            var professors = new List<Professor>
            {
                new Professor { }
            };

            students.ForEach(s => context.Students.Add(s));
                context.SaveChanges();
        }
    }
}
