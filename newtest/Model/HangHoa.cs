namespace newtest.Model
{
    public class HangHoaVM
    {
        public string HangHoaName { get; set; }
        public double Price { get; set; } 
    }

    public class HangHoa : HangHoaVM
    {
        public Guid Code { get; set; }
    }
}
