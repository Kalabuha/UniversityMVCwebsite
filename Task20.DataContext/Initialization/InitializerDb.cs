using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Task20.DataContext.DataBaseContext;
using Task20.Entities;

namespace Task20.DataContext.Initialization
{
    public static class InitializerDb
    {
        public static void Initialize(UniversityDbContext context)
        {
            if (!(context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator)!.Exists())
            {
                context.Database.Migrate();
                FillDb(context);
            }
        }

        private static void FillDb(UniversityDbContext context)
        {
            var teachers = new List<TeacherEntity>()
            {
                new TeacherEntity { Name = "Leslie", SacondName = "William", LastName = "Nielsen", Experience = "Nielsen's career began in dramatic roles on television during Television s Golden Age, appearing in 46 live programs in 1950 alone. He said there was very little gold, we only got $75 or $100 per show. He narrated documentaries and commercials and most of his early work as a dramatic actor was uneventful. Hal Erickson of Allmovie noted that much of Nielsen's early work was undistinguished; he was merely a handsome leading man in an industry overstocked with handsome leading men.", DateBirth = new DateTime(1926, 02, 11) },
                new TeacherEntity { Name = "Charles", SacondName = "Spencer", LastName = "Chaplin", Experience = "Having fulfilled his First National contract, Chaplin was free to make his first picture as an independent producer. In November 1922, he began filming A Woman of Paris, a romantic drama about ill-fated lovers. Chaplin intended it to be a star-making vehicle for Edna Purviance, and did not appear in the picture himself other than in a brief, uncredited cameo. He wished the film to have a realistic feel and directed his cast to give restrained performances. In real life, he explained, men and women try to hide their emotions rather than seek to express them.", DateBirth = new DateTime(1889, 04, 16) },
                new TeacherEntity { Name = "Alfred", SacondName = "Benny", LastName = "Hill", Experience = "After the Second World War, Hill worked as a performer on radio, making his debut on Variety Bandbox on 5 October 1947. His first appearance on television was in 1950. In addition, he attempted a sitcom anthology, Benny Hill, which ran from 1962 to 1963, in which he played a different character in each episode. In 1964, he played Nick Bottom in an all-star TV film production of William Shakespeare's A Midsummer Night's Dream.", DateBirth = new DateTime(1924, 04, 20) },
                new TeacherEntity { Name = "Patrick", SacondName = "Hewes", LastName = "Stewart", Experience = "Following a period with Manchester's Library Theatre, Stewart became a member of the Royal Shakespeare Company in 1966, remaining with them until 1982. He was an associate artist of the company in 1968. He appeared with actors such as Ben Kingsley and Ian Richardson. In January 1967, he made his debut TV appearance on Coronation Street as a fire officer. In 1969, he had a brief TV cameo role as Horatio, opposite Ian Richardson's Hamlet, in a performance of the gravedigger scene as part of episode six of Sir Kenneth Clark's Civilisation television series.", DateBirth = new DateTime(1940, 07, 13) },
                new TeacherEntity { Name = "Carlos", SacondName = "Chuck", LastName = "Norris", Experience = "He joined the United States Air Force as an Air Policeman (AP) in 1958 and was sent to Osan Air Base, South Korea. It was there that Norris acquired the nickname 'Chuck' and began his training in Tang Soo Do (tangsudo), an interest that led to black belts in that art and the founding of the Chun Kuk Do (Universal Way) form. When he returned to the United States, he continued to serve as an AP at March Air Force Base in California.", DateBirth = new DateTime(1940, 03, 10) },
                new TeacherEntity { Name = "Alfredo", SacondName = "James", LastName = "Pacino", Experience = "In 1967, Pacino spent a season at the Charles Playhouse in Boston, performing in Clifford Odets' Awake and Sing! (his first major paycheck: US$125 a week); and in Jean-Claude Van Itallie's America Hurrah. He met actress Jill Clayburgh on this play. They had a five-year romance and moved back together to New York City. In 1968, Pacino starred in Israel Horovitz's The Indian Wants the Bronx at the Astor Place Theatre, playing Murph, a street punk.", DateBirth = new DateTime(1940, 04, 25) },
                new TeacherEntity { Name = "Philip", SacondName = "Anthony", LastName = "Hopkins", Experience = "Hopkins made his first professional stage appearance in the Palace Theatre, Swansea, in 1960 with Swansea Little Theatre's production of Have a Cigarette. In 1965, after several years in repertory, he was spotted by Laurence Olivier, who invited him to join the Royal National Theatre in London. Hopkins became Olivier's understudy, and filled in when Olivier was struck with appendicitis during a 1967 production of August Strindberg's The Dance of Death.", DateBirth = new DateTime(1937, 12, 31) },
                new TeacherEntity { Name = "Jane", SacondName = "Seymour", LastName = "Fonda", Experience = "Fonda's stage work in the late 1950s laid the foundation for her film career in the 1960s. She averaged almost two movies a year throughout the decade, starting in 1960 with Tall Story, in which she recreated one of her Broadway roles as a college cheerleader pursuing a basketball star, played by Anthony Perkins. Frequent collaborator Robert Redford also made his debut in that film. Period of Adjustment and Walk on the Wild Side followed in 1962. The latter, in which she played a prostitute, earned her a Golden Globe for Most Promising Newcomer.", DateBirth = new DateTime(1937, 12, 21) },
                new TeacherEntity { Name = "Morgan", SacondName = "Memphis", LastName = "Freeman", Experience = "Freeman worked as a dancer at the 1964 World's Fair and was a member of the Opera Ring musical theatre group in San Francisco. He acted in a touring company version of The Royal Hunt of the Sun, and also appeared as an extra in Sidney Lumet's 1965 drama film The Pawnbroker starring Rod Steiger. Between acting and dancing jobs, Freeman realized that acting was where his heart lay. After [The Royal Hunt of the Sun], my acting career just took off, he later recalled.", DateBirth = new DateTime(1937, 07, 01) },
                new TeacherEntity { Name = "Charles", SacondName = "Robert", LastName = "Redford", Experience = "Redford's career, like that of many major stars who emerged in the 1950s, began in New York City, where an actor found work both on stage and in television. His Broadway debut was in a small role in Tall Story (1959), followed by parts in The Highest Tree (1959) and Sunday in New York (1961). His biggest Broadway success was as the stuffy newlywed husband of Elizabeth Ashley in the original 1963 cast of Neil Simon's Barefoot in the Park.", DateBirth = new DateTime(1936, 08, 18) },
                new TeacherEntity { Name = "Judith", SacondName = "Olivia", LastName = "Dench", Experience = "Dench made her first professional stage appearance in September of 1957 with the Old Vic Company at the Royal Court Theatre in Liverpool, as Ophelia in Hamlet. According to the reviewer for London Evening Standard, Dench had talent which will be shown to better advantage when she acquires some technique to go with it. Dench then made her London debut in the same production at the Old Vic.", DateBirth = new DateTime(1934, 12, 09) },
                new TeacherEntity { Name = "Clinton", SacondName = "Clint", LastName = "Eastwood", Experience = "According to a CBS press release for Rawhide, the Universal-International film company was shooting in Fort Ord when an enterprising assistant spotted Eastwood and invited him to meet the director, although this is disputed by Eastwood's unauthorized biographer, Patrick McGilligan. According to Eastwood's official biography, the key figure was a man named Chuck Hill, who was stationed in Fort Ord and had contacts in Hollywood.", DateBirth = new DateTime(1930, 03, 31) },
                new TeacherEntity { Name = "Betty", SacondName = "Marion", LastName = "White", Experience = "After the war, White made the rounds to movie studios looking for work, but was turned down because she was not photogenic. She started to look for radio jobs, where being photogenic did not matter. Her first radio jobs included reading commercials and playing bit parts, and sometimes even doing crowd noises.", DateBirth = new DateTime(1922, 01, 17) },
                new TeacherEntity { Name = "Norman", SacondName = "Nathan", LastName = "Lloyd", Experience = "In late summer 1939, Lloyd was invited to Hollywood, to join Welles and other Mercury Theatre members in the first film being prepared for RKO Pictures — Heart of Darkness. Given a six-week guarantee at $500 a week, he took part in a reading for the film, 62–65  which was to be presented entirely through a first-person camera. After elaborate pre-production the project never reached production because Welles was unable to trim $50,000 from its budget, 31 something RKO insisted upon as its revenue was declining sharply in Europe by autumn 1939.", DateBirth = new DateTime(1914, 11, 08) },
                new TeacherEntity { Name = "Carl", SacondName = "James", LastName = "Reiner", Experience = "Reiner performed in several Broadway musicals (including Inside U.S.A. and Alive and Kicking) and had the lead role in Call Me Mister. In 1950, he was cast by Max Leibman as a comic actor on Sid Caesar's Your Show of Shows, appearing on air in skits while also contributing ideas to such writers as Mel Brooks and Neil Simon. He did not receive credit for his sketch material, but won Emmy Awards in 1955 and 1956 as a supporting actor.", DateBirth = new DateTime(1922, 03, 20) },
            };

            var courses = new List<CourseEntity>()
            {
                new CourseEntity { Name = "Business Essentials.", Description = "Interpret data to inform business decisions, explore the economic foundations of strategy, and discover what’s behind the numbers in financial statements.", CreationDate = new DateTime(1998, 08, 1), Leader = teachers[0] },
                new CourseEntity { Name = "Leadership and Management.", Description = "Develop the leadership and management skills to get things done and bring out the best in your team, whether you’re an aspiring, new, or seasoned leader.", CreationDate = new DateTime(2001, 05, 25), Leader = teachers[1]},
                new CourseEntity { Name = "Entrepreneurship and Innovation.", Description = "Learn what it takes to harness innovation and transform a disruptive idea into a viable venture.", CreationDate = new DateTime(2005, 11, 14), Leader = teachers[2]},
            };

            var groups = new List<GroupEntity>()
            {
                // cg-yy: <номер курса><номер группы>-<год>
                new GroupEntity { Name = "11-98", Description = "First group", CreationDate = new DateTime(1998, 08, 01), Course = courses[0], Leader = teachers[3] },
                new GroupEntity { Name = "12-98", Description = "Sacond group", CreationDate = new DateTime(1998, 08, 01), Course = courses[1], Leader = teachers[4] },
                new GroupEntity { Name = "13-98", Description = "Third group", CreationDate = new DateTime(1998, 08, 01), Course = courses[1], Leader = teachers[5] },
                new GroupEntity { Name = "21-01", Description = "Fourth group", CreationDate = new DateTime(2001, 05, 25), Course = courses[1], Leader = teachers[6] },
                new GroupEntity { Name = "22-01", Description = "Fifth group", CreationDate = new DateTime(2001, 05, 25), Course = courses[1], Leader = teachers[7] },
                new GroupEntity { Name = "23-01", Description = "Sixth group", CreationDate = new DateTime(2001, 05, 25), Course = courses[1], Leader = teachers[8] },
                new GroupEntity { Name = "31-05", Description = "Seventh group", CreationDate = new DateTime(2005, 11, 14), Course = courses[2], Leader = teachers[9] },
                new GroupEntity { Name = "32-05", Description = "Eight group", CreationDate = new DateTime(2005, 11, 14), Course = courses[2], Leader = teachers[10] },
                new GroupEntity { Name = "33-05", Description = "Ninth group", CreationDate = new DateTime(2005, 11, 14), Course = courses[2], Leader = teachers[11] },
                new GroupEntity { Name = "11-08", Description = "Tenth group", CreationDate = new DateTime(2008, 04, 15), Course = courses[2], Leader = teachers[12] },
                new GroupEntity { Name = "12-08", Description = "Eleven group", CreationDate = new DateTime(2008, 04, 15), Course = courses[2], Leader = teachers[13] },
            };

            var students = new List<StudentEntity>()
            {
                new StudentEntity { Name = "Steve", SacondName = "John", LastName = "Carell", DateBirth = new DateTime(1962, 02, 16), DateAdmission = new DateTime(1998, 08, 01), Group = groups[0]},
                new StudentEntity { Name = "Simon", SacondName = "John", LastName = "Pegg", DateBirth = new DateTime(1970, 02, 14), DateAdmission = new DateTime(1998, 08, 01), Group = groups[0]},
                new StudentEntity { Name = "Rowan", SacondName = "Sebastian", LastName = "Atkinson", DateBirth = new DateTime(1955, 01, 06), DateAdmission = new DateTime(1998, 08, 01), Group = groups[0]},
                new StudentEntity { Name = "Jim", SacondName = "Eugene", LastName = "Carrey", DateBirth = new DateTime(1962, 01, 17), DateAdmission = new DateTime(1998, 08, 01), Group = groups[0]},
                new StudentEntity { Name = "Zachary", SacondName = "Knight", LastName = "Galifianakis", DateBirth = new DateTime(1969, 10, 01), DateAdmission = new DateTime(2001, 05, 25), Group = groups[1]},
                new StudentEntity { Name = "Thomas", SacondName = "Jacob", LastName = "Black", DateBirth = new DateTime(1969, 09, 28), DateAdmission = new DateTime(2001, 05, 25), Group = groups[1]},
                new StudentEntity { Name = "John", SacondName = "William", LastName = "Ferrell", DateBirth = new DateTime(1967, 07, 16), DateAdmission = new DateTime(2001, 05, 25), Group = groups[1]},
                new StudentEntity { Name = "Owen", SacondName = "Cunningham", LastName = "Wilson", DateBirth = new DateTime(1968, 11, 18), DateAdmission = new DateTime(2001, 05, 25), Group = groups[1]},
                new StudentEntity { Name = "Christopher", SacondName = "Julius", LastName = "Rock", DateBirth = new DateTime(1965, 02, 07), DateAdmission = new DateTime(2005, 11, 14), Group = groups[2]},
                new StudentEntity { Name = "Mena", SacondName = "Alexandra", LastName = "Suvari", DateBirth = new DateTime(1979, 02, 13), DateAdmission = new DateTime(2005, 11, 14), Group = groups[2]},
                new StudentEntity { Name = "Jennifer", SacondName = "McCarthy", LastName = "Wahlberg", DateBirth = new DateTime(1972, 11, 01), DateAdmission = new DateTime(2005, 11, 14), Group = groups[2]},
                new StudentEntity { Name = "Damon", SacondName = "Kyle", LastName = "Wayans", DateBirth = new DateTime(1960, 09, 04), DateAdmission = new DateTime(2005, 11, 14), Group = groups[2]},
                new StudentEntity { Name = "Elisha", SacondName = "Ann", LastName = "Cuthbert", DateBirth = new DateTime(1982, 11, 30), DateAdmission = new DateTime(2001, 05, 25), Group = groups[3]},
                new StudentEntity { Name = "Courteney", SacondName = "Bass", LastName = "Cox", DateBirth = new DateTime(1064, 06, 15), DateAdmission = new DateTime(2001, 05, 25), Group = groups[3]},
                new StudentEntity { Name = "Mary", SacondName = "Sean", LastName = "Young", DateBirth = new DateTime(1959, 11, 20), DateAdmission = new DateTime(2001, 05, 25), Group = groups[3]},
                new StudentEntity { Name = "Robert", SacondName = "Michael", LastName = "Schneider", DateBirth = new DateTime(1963, 10, 31), DateAdmission = new DateTime(2001, 05, 25), Group = groups[3]},
                new StudentEntity { Name = "Marlon", SacondName = "Lamont", LastName = "Wayans", DateBirth = new DateTime(1972, 07, 23), DateAdmission = new DateTime(2001, 05, 25), Group = groups[4]},
                new StudentEntity { Name = "Regina", SacondName = "Lee", LastName = "Hall", DateBirth = new DateTime(1970, 12, 12), DateAdmission = new DateTime(2001, 05, 25), Group = groups[4]},
                new StudentEntity { Name = "Ryan", SacondName = "Rodney", LastName = "Reynolds", DateBirth = new DateTime(1976, 10, 23), DateAdmission = new DateTime(2001, 05, 25), Group = groups[4]},
                new StudentEntity { Name = "Tara", SacondName = "Donna", LastName = "Reid", DateBirth = new DateTime(1975, 11, 08), DateAdmission = new DateTime(2001, 05, 25), Group = groups[5]},
                new StudentEntity { Name = "Jennifer", SacondName = "Audrey", LastName = "Coolidge", DateBirth = new DateTime(1961, 08, 28), DateAdmission = new DateTime(2001, 05, 25), Group = groups[5]},
                new StudentEntity { Name = "Scott", SacondName = "David", LastName = "Mechlowicz", DateBirth = new DateTime(1981, 01, 17), DateAdmission = new DateTime(2001, 05, 25), Group = groups[5]},
                new StudentEntity { Name = "Jacob", SacondName = "Rives", LastName = "Pitts", DateBirth = new DateTime(1979, 11, 20), DateAdmission = new DateTime(2001, 05, 25), Group = groups[5]},
                new StudentEntity { Name = "Michelle", SacondName = "Christine", LastName = "Trachtenberg", DateBirth = new DateTime(1985, 10, 11), DateAdmission = new DateTime(2001, 05, 25), Group = groups[5]},
                new StudentEntity { Name = "Emile", SacondName = "Davenport", LastName = "Hirsch", DateBirth = new DateTime(1985, 05, 13), DateAdmission = new DateTime(2005, 11, 14), Group = groups[6]},
                new StudentEntity { Name = "Timothy", SacondName = "David", LastName = "Olyphant", DateBirth = new DateTime(1968, 05, 20), DateAdmission = new DateTime(2005, 11, 14), Group = groups[7]},
                new StudentEntity { Name = "Orlando", SacondName = "Wayne", LastName = "Brown", DateBirth = new DateTime(1987, 12, 04), DateAdmission = new DateTime(2005, 11, 14), Group = groups[7]},
                new StudentEntity { Name = "Karyn", SacondName = "Parsons", LastName = "Rockwell", DateBirth = new DateTime(1966, 10, 08), DateAdmission = new DateTime(2005, 11, 14), Group = groups[7]},
                new StudentEntity { Name = "Steven", SacondName = "Alex", LastName = "Martini", DateBirth = new DateTime(1975, 04, 21), DateAdmission = new DateTime(2005, 11, 14), Group = groups[7]},
                new StudentEntity { Name = "Rachel", SacondName = "Anne", LastName = "McAdams", DateBirth = new DateTime(1978, 11, 17), DateAdmission = new DateTime(2005, 11, 14), Group = groups[8]},
                new StudentEntity { Name = "Anna", SacondName = "Kay", LastName = "Faris", DateBirth = new DateTime(1976, 11, 29), DateAdmission = new DateTime(2005, 11, 14), Group = groups[8]},
                new StudentEntity { Name = "Daniel", SacondName = "Thomas", LastName = "Cosgrove", DateBirth = new DateTime(1970, 12, 16), DateAdmission = new DateTime(2005, 11, 14), Group = groups[8]},
                new StudentEntity { Name = "Seann", SacondName = "William", LastName = "Scott", DateBirth = new DateTime(1976, 10, 03), DateAdmission = new DateTime(2005, 11, 14), Group = groups[8]},
                new StudentEntity { Name = "Frederick", SacondName = "Christopher", LastName = "Klein", DateBirth = new DateTime(1979, 03, 14), DateAdmission = new DateTime(2008, 04, 15), Group = groups[9]},
                new StudentEntity { Name = "Eddie", SacondName = "Kaye", LastName = "Thomas", DateBirth = new DateTime(1980, 10, 31), DateAdmission = new DateTime(2008, 04, 15), Group = groups[9]},
                new StudentEntity { Name = "David", SacondName = "William", LastName = "Duchovny", DateBirth = new DateTime(1960, 08, 07), DateAdmission = new DateTime(2008, 04, 15), Group = groups[10]},
                new StudentEntity { Name = "Gillian", SacondName = "Leigh", LastName = "Anderson", DateBirth = new DateTime(1968, 08, 09), DateAdmission = new DateTime(2008, 04, 15), Group = groups[10]},
            };

            foreach (var teacher in teachers)
                context.Teachers.Add(teacher);

            foreach (var course in courses)
                context.Courses.Add(course);

            foreach (var group in groups)
                context.Groups.Add(group);

            foreach (var student in students)
                context.Students.Add(student);

            context.SaveChanges();
        }
    }
}
