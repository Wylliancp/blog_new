namespace Domain.Utils
{
    public abstract class Validation<T> where T : class
    {
        
        public bool IsValid { get; private set; }
        
        public void ValidTasksTitle(string title)
        {
            IsValid = true;

            if(string.IsNullOrWhiteSpace(title))
                IsValid = false;
        }

        public void ValidTasksId(int id)
        {
            IsValid = true;

            if (id == 0)
                IsValid = false;
        }



    }
}