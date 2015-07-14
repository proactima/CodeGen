namespace CodeGenInput
{
    public class T4Info
    {
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public string GenericType { get; set; }
        public string CustomFactory { get; set; }
        public bool NotInFactory { get; set; }
        public bool IncludeInWith { get; set; }
        public bool UseOptionWrapper { get; set; }
    }
}