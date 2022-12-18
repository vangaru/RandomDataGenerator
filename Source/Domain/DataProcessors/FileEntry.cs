using System.ComponentModel.DataAnnotations.Schema;

namespace RandomDataGenerator.Domain.DataProcessors
{
    public class FileEntry
    {
        private string? _id;
        private string? _latinString;
        private string? _russianString;

        public string Id
        {
            get => _id ??= Guid.NewGuid().ToString();
            set => _id = value;
        }

        public DateTime Date { get; set; }
        
        public string LatinString 
        { 
            get => _latinString ?? throw new ApplicationException("Latin String is not defined."); 
            set => _latinString = value; 
        }

        public string RussianString
        {
            get => _russianString ?? throw new ApplicationException("Russian string is not defined");
            set => _russianString = value;
        }

        public int IntegerNumber { get; set; }

        public double FloatingNumber { get; set; }
    }
}