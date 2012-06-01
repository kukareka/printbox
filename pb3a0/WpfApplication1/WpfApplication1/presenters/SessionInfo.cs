
namespace WpfApplication1
{
    public class SessionInfo
    {
        public DocumentInfo documentInfo { get; set; }
        public PrintOptions printOptions { get; set; }

        public SessionInfo()
        {
            documentInfo = new DocumentInfo();
            printOptions = new PrintOptions();
        }        
    }
}
