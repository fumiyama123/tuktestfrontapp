namespace tuktestfrontapp.Components.Pages
{
    public partial class Zodiac
    {
        public OrientalZodiacModel orientalZodiac = new();
        public string? year;

        public void ShowYear()
        {
            orientalZodiac.StatusCode = 200;
            orientalZodiac.Value = "辰";
        }
    }
}
