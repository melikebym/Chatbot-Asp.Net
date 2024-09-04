namespace AIChat.Models
{
    public class Option
    {
        public int OptionID { get; set; }         
        public string OptionName { get; set; }
        public string? OptionContent { get; set; }
        public string? OptionLink { get; set; }
        public int? ParentID { get; set; }    
        
        public virtual Option? Parent { get; set; } 
        public virtual ICollection<Option> Children { get; set; } = new List<Option>(); 

    }
}
