namespace StellarClothing.AdminApp.Models
{
    public class HeadingMenu
    {
        public byte HeadingItem_id { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public bool HasChildren { get; set; }
        public byte Parent { get; set; }
        public byte ItemColumn { get; set; }
    }
}
