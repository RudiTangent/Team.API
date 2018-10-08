namespace Teams.API.Model
{
    public class TeamProjects
    {
        public int Id { get; set; }

        public Projects Project_Items { get; set; }

        public int Team_ID { get; set;}
    }
}