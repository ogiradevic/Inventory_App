namespace Link_Inventory.Models.Entities
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }
    }
}