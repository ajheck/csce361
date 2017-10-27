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


            /* ------------------------------- Students ------------------------------- */

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


            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            /* ------------------------------- Courses ------------------------------- */

            Course csce155a = new Course { CourseNumber = "CSCE 155A", CourseName = "Computer Science I", Roster = new List<Student>() };
            Course csce230 = new Course { CourseNumber = "CSCE 230", CourseName = "Computer Organization", Roster = new List<Student>() };
            Course csce361 = new Course { CourseNumber = "CSCE 361", CourseName = "Software Engineering", Roster = new List<Student>() };

            foreach (Student s in context.Students)
            {
                if (s.LastName.Equals("Keck"))
                {
                    csce155a.Roster.Add(s);
                }
                else if (s.LastName.Equals("Reck"))
                {
                    csce230.Roster.Add(s);
                }
                else if (s.LastName.Equals("Deck"))
                {
                    csce361.Roster.Add(s);
                }
                else if (s.LastName.Equals("Heck"))
                {
                    csce230.Roster.Add(s);
                }
                else if (s.LastName.Equals("Barker"))
                {
                    csce155a.Roster.Add(s);
                }
                else if (s.LastName.Equals("Finnegan"))
                {
                    csce361.Roster.Add(s);
                }
                else if (s.LastName.Equals("Harper"))
                {
                    csce361.Roster.Add(s);
                }
                else if (s.LastName.Equals("Peck"))
                {
                    csce230.Roster.Add(s);
                    csce361.Roster.Add(s);
                }
            }

            context.Courses.Add(csce155a);
            context.Courses.Add(csce230);
            context.Courses.Add(csce361);
            context.SaveChanges();


            /* ------------------------------- Office Hourse ------------------------------- */

            /* 
             * Definetly going to have to improve these... need to come up with some way of always
             * putting these at the same time each week, and then having one persons hours
             * fluctuate so that they can be the guniea pig for testing the "TA is in" funceionality
             */

            //Andys office hours
            OfficeHour hours = new OfficeHour
            {
                Student = context.Students.Where(x => x.Nuid == "11111111").FirstOrDefault(),
                Course = context.Courses.Where(x => x.CourseNumber == "CSCE 155A").FirstOrDefault(),
                Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0).AddDays(7),
                End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0).AddHours(2).AddDays(7)
            };

            context.OfficeHours.Add(hours);

            hours = new OfficeHour
            {
                Student = context.Students.Where(x => x.Nuid == "11111111").FirstOrDefault(),
                Course = context.Courses.Where(x => x.CourseNumber == "CSCE 155A").FirstOrDefault(),
                Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0).AddDays(2),
                End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0).AddDays(2).AddHours(2)
            };

            context.OfficeHours.Add(hours);

            //Tylers office hours
            hours = new OfficeHour
            {
                Student = context.Students.Where(x => x.Nuid == "44444444").FirstOrDefault(),
                Course = context.Courses.Where(x => x.CourseNumber == "CSCE 230").FirstOrDefault(),
                Start = DateTime.Now.AddHours(3.0),
                End = DateTime.Now.AddHours(6.0)
            };

            context.OfficeHours.Add(hours);

            //Hannah's office hours
            hours = new OfficeHour
            {
                Student = context.Students.Where(x => x.Nuid == "88888888").FirstOrDefault(),
                Course = context.Courses.Where(x => x.CourseNumber == "CSCE 155A").FirstOrDefault(),
                Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0).AddDays(3),
                End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0).AddDays(3).AddHours(2)
            };

            context.OfficeHours.Add(hours); hours = new OfficeHour
            {
                Student = context.Students.Where(x => x.Nuid == "88888888").FirstOrDefault(),
                Course = context.Courses.Where(x => x.CourseNumber == "CSCE 230").FirstOrDefault(),
                Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0).AddDays(1),
                End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0).AddDays(1).AddHours(2)
            };

            context.OfficeHours.Add(hours);

            context.SaveChanges();

            /* ------------------------------- Timestamps ------------------------------- */

            /*
             * Again it will be rough, but as we develop well need to add in better mock data
             * for more realistic data  
             */

            // Select all the students in CSCE 155A and have them checked in during Andy's CSCE 155A office hours
            foreach (Student s in csce155a.Roster)
            {
                var timestamp = new SRCTimestamp
                {
                    Student = s,
                    WasCheckIn = true,
                    Stamp = DateTime.Now
                };

                context.Timestamps.Add(timestamp);

                context.Students.Where(x => x.StudentID == s.StudentID).FirstOrDefault().InSRC = true;

            }

            // Check Andy in for his office hours
            var stamp = new SRCTimestamp
            {
                Student = context.Students.Where(x => x.Nuid == "11111111").FirstOrDefault(),
                WasCheckIn = true,
                Stamp = DateTime.Now
            };

            context.Timestamps.Add(stamp);

            context.Students.Where(x => x.Nuid == "11111111").FirstOrDefault().InSRC = true;

            context.SaveChanges();

            //Create realistic coming and goings for students of 230 for today
            DateTime checkinTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0);
            foreach (Student s in context.Students.Where(x => x.LastName == "Reck").ToList())
            {
                SRCTimestamp newStamp = new SRCTimestamp();
                newStamp.Student = s;
                newStamp.WasCheckIn = true;
                newStamp.Stamp = checkinTime;

                context.Timestamps.Add(newStamp);

                context.SaveChanges();

                DateTime checkoutTime = checkinTime;
                checkoutTime = checkoutTime.AddHours(.75);

                newStamp.WasCheckIn = false;
                newStamp.Stamp = checkoutTime;

                context.Timestamps.Add(newStamp);

                context.SaveChanges();

                checkinTime = checkinTime.AddHours(.33);
            }

            //Create realistic coming and goings for students of 230 for lastWeek
            checkinTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0);
            checkinTime = checkinTime.AddDays(-7.0);

            foreach (Student s in context.Students.Where(x => x.LastName == "Reck").ToList())
            {
                SRCTimestamp newStamp = new SRCTimestamp();
                newStamp.Student = s;
                newStamp.WasCheckIn = true;
                newStamp.Stamp = checkinTime;

                context.Timestamps.Add(newStamp);

                context.SaveChanges();

                DateTime checkoutTime = checkinTime;
                checkoutTime = checkoutTime.AddHours(1.5);

                newStamp.WasCheckIn = false;
                newStamp.Stamp = checkoutTime;

                context.Timestamps.Add(newStamp);

                context.SaveChanges();

                checkinTime = checkinTime.AddHours(.66);
            }

            /* ------------------------------- Professors ------------------------------- */

            /*
             * Not sure what to do about pass hashes for now....
             */

            var prof = new Professor
            {
                Nuid = "12345678",
                Courses = context.Courses.Where(x => x.CourseNumber == "CSCE 361").ToList(),
                PassHash = 0x0,
                FirstName = "Greg",
                LastName = "Rothermel"
            };

            context.Professors.Add(prof);

            context.SaveChanges();


        }
    }
}
